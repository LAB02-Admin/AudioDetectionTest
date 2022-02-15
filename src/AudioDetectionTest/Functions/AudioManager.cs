using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AudioDetectionTest.Models;
using CoreAudio;
using CoreAudio.Interfaces;
using Serilog;

namespace AudioDetectionTest.Functions
{
    internal static class AudioManager
    {
        private static readonly Dictionary<int, string> ApplicationNames = new Dictionary<int, string>();
        private static MMDevice _audioDevice;
        
        private static bool _active = true;

        internal static int RefreshInterval { get; set; } = 5;

        /// <summary>
        /// Prepares the audio devices and checks for availability
        /// </summary>
        /// <returns></returns>
        internal static bool Initialize()
        {
            try
            {
                // get the default devices
                Variables.DefaultDeviceEnumerator = new MMDeviceEnumerator();
                if (Variables.DefaultDeviceEnumerator == null)
                {
                    Log.Error("[AUDIOMANAGER] Unable to retrieve an audio device enumerator");
                    Variables.FrmM.CriticalError("Unable to retrieve an audio device enumerator, unable to recover.\r\n\r\nPlease consult the logs for more info.");
                    return false;
                }

                // launch monitor
                Task.Run(MonitorAudioDevices);

                // done
                Log.Information("[AUDIOMANAGER] Initialization complete");
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[AUDIOMANAGER] Error initializing: {err}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Periodically checks the state of all audio devices, fetching volume, applications and -info
        /// </summary>
        private static async void MonitorAudioDevices()
        {
            var firstRun = true;
            
            try
            {
                while (_active)
                {
                    // we're not waiting on the first run, from then on every x seconds
                    if (firstRun) firstRun = false;
                    else await Task.Delay(TimeSpan.FromSeconds(RefreshInterval));

                    // get our info
                    try
                    {
                        // get the default audio device
                        _audioDevice = Variables.DefaultDeviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
                        if (_audioDevice == null)
                        {
                            Log.Error("[AUDIOMANAGER] Unable to retrieve an audio device");
                            Variables.FrmM.CriticalError("Error while retrieving info.\r\n\r\nPlease consult the logs for more info.");
                            return;
                        }
                        
                        // show the name
                        Variables.FrmM.SetAudioDevice(_audioDevice.FriendlyName);

                        // show the state
                        var deviceState = GetReadableState(_audioDevice.State);
                        Variables.FrmM.SetAudioDeviceState(deviceState);

                        // show the volume
                        var masterVolume = (int)(_audioDevice.AudioEndpointVolume?.MasterVolumeLevelScalar * 100 ?? 0);
                        Variables.FrmM.SetMasterVolume(masterVolume);

                        // get session and volume info
                        var sessionInfos = GetSessions(out var peakVolume);

                        // show session info
                        Variables.FrmM.SetSessionInfo(sessionInfos);

                        // show peak volume
                        Variables.FrmM.SetPeakVolume(peakVolume);
                    }
                    catch (Exception ex)
                    {
                        // only worry if we're active
                        if (!_active) return;

                        Log.Fatal(ex, "[AUDIOMANAGER] Fatal exception while retrieving info: {err}", ex.Message);
                        Variables.FrmM.CriticalError("Error while retrieving info.\r\n\r\nPlease consult the logs for more info.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[AUDIOMANAGER] Fatal exception while looping: {err}", ex.Message);
                Variables.FrmM.CriticalError("Error while retrieving info.\r\n\r\nPlease consult the logs for more info.");
            }
        }

        private static List<AudioSessionInfo> GetSessions(out float peakVolume)
        {
            var sessionInfos = new List<AudioSessionInfo>();
            peakVolume = 0f;

            try
            {
                var errors = false;

                foreach (var device in Variables.DefaultDeviceEnumerator.EnumerateAudioEndPoints(EDataFlow.eRender, DEVICE_STATE.DEVICE_STATE_ACTIVE))
                {
                    // refresh all sessions
                    device.AudioSessionManager2?.RefreshSessions();

                    // process sessions (and get peak volume)
                    foreach (var session in device.AudioSessionManager2?.Sessions.Where(x => x != null))
                    {
                        try
                        {
                            // filter inactive sessions
                            if (session.State != AudioSessionState.AudioSessionStateActive) continue;

                            // prepare sessioninfo
                            var sessionInfo = new AudioSessionInfo();

                            // get displayname
                            string displayName;
                            var procId = (int)session.GetProcessID;
                            if (procId <= 0)
                            {
                                // faulty process id, use the provided displayname
                                displayName = session.DisplayName;
                            }
                            else
                            {
                                if (ApplicationNames.ContainsKey(procId)) displayName = ApplicationNames[procId];
                                else
                                {
                                    // we don't know this app yet, get process info
                                    using (var p = Process.GetProcessById(procId))
                                    {
                                        displayName = p.ProcessName;
                                        ApplicationNames.Add(procId, displayName);
                                    }
                                }
                            }

                            // set displayname
                            sessionInfo.Application = displayName;
                            
                            // get muted state
                            sessionInfo.Muted = session.SimpleAudioVolume?.Mute ?? false;

                            // set master volume
                            sessionInfo.MasterVolume = session.SimpleAudioVolume?.MasterVolume * 100 ?? 0f;
                            
                            // set peak volume
                            sessionInfo.PeakVolume = session.AudioMeterInformation?.MasterPeakValue * 100 ?? 0f;

                            // new max?
                            if (sessionInfo.PeakVolume > peakVolume) peakVolume = sessionInfo.PeakVolume;

                            // store the session info
                            sessionInfos.Add(sessionInfo);
                        }
                        catch (Exception ex)
                        {
                            Log.Fatal(ex, "[AUDIOMANAGER] [{app}] Exception while retrieving info: {err}", session.DisplayName, ex.Message);
                            errors = true;
                        }
                        finally
                        {
                            // session?.Dispose();
                        }
                    }
                }

                // let user know if there are errors
                if (errors) Variables.FrmM.CriticalError("Errors while retrieving application info.\r\n\r\nPlease consult the logs for more info.");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[AUDIOMANAGER] Fatal exception while looping: {err}", ex.Message);
                Variables.FrmM.CriticalError("Errors while retrieving application info.\r\n\r\nPlease consult the logs for more info.");
            }

            return sessionInfos;
        }

        /// <summary>
        /// Converts the audio device's state to a better readable form
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private static string GetReadableState(DEVICE_STATE state)
        {
            switch (state)
            {
                case DEVICE_STATE.DEVICE_STATE_ACTIVE:
                    return "ACTIVE";
                case DEVICE_STATE.DEVICE_STATE_DISABLED:
                    return "DISABLED";
                case DEVICE_STATE.DEVICE_STATE_NOTPRESENT:
                    return "NOT PRESENT";
                case DEVICE_STATE.DEVICE_STATE_UNPLUGGED:
                    return "UNPLUGGED";
                case DEVICE_STATE.DEVICE_STATEMASK_ALL:
                    return "STATEMASK_ALL";
                default:
                    return "UNKNOWN";
            }
        }

        /// <summary>
        /// Stops monitoring and disposes all objects
        /// </summary>
        internal static void Shutdown()
        {
            try
            {
                // stop monitoring
                _active = false;
                
                // wait a bit (on the main thread)
                Thread.Sleep(250);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[AUDIOMANAGER] Error shutting down: {err}", ex.Message);
            }
        }
    }
}
