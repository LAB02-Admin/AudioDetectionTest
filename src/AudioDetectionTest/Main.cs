using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioDetectionTest.Functions;
using AudioDetectionTest.Models;
using Serilog;

namespace AudioDetectionTest
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LblVersion.Text = $"v{Variables.Version}";
            Log.Information("Launching Audio Detection Test version {v}", Variables.Version);

            Task.Run(async delegate
            {
                // wait a bit for gui to properly load
                await Task.Delay(750);

                // prepare the audio manager
                var ok = AudioManager.Initialize();
                if (ok) return;

                // nope
                CriticalError("Erorr while initializing the audio manager, consult the logs for more info.");
            });
        }

        /// <summary>
        /// Show the default audio device's name in the UI
        /// </summary>
        /// <param name="name"></param>
        internal void SetAudioDevice(string name)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => SetAudioDevice(name)));
                return;
            }

            TbDefaultDevice.Text = $" {name}";
        }

        /// <summary>
        /// Show the default audio device's current state in the UI
        /// </summary>
        /// <param name="state"></param>
        internal void SetAudioDeviceState(string state)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => SetAudioDeviceState(state)));
                return;
            }

            TbDefaultDeviceState.Text = $" {state}";
        }

        /// <summary>
        /// Show the master volume in the UI
        /// </summary>
        /// <param name="volume"></param>
        internal void SetMasterVolume(float volume)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => SetMasterVolume(volume)));
                return;
            }

            var vol = Math.Round(volume);
            TbMasterVolume.Text = $" {vol}";
        }

        /// <summary>
        /// Show the peak volume level in the UI
        /// </summary>
        /// <param name="volume"></param>
        internal void SetPeakVolume(float volume)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => SetPeakVolume(volume)));
                return;
            }

            TbPeakVolume.Text = volume == 0 ? " 0" : $" {volume:N6}";
        }

        /// <summary>
        /// Shows the session infos in the UI
        /// </summary>
        /// <param name="sessions"></param>
        internal void SetSessionInfo(List<AudioSessionInfo> sessions)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => SetSessionInfo(sessions)));
                return;
            }

            LvSessions.BeginUpdate();
            LvSessions.Items.Clear();

            foreach (var session in sessions)
            {
                var lviSession = new ListViewItem(session.Application);

                var muted = session.Muted ? "YES" : "NO";
                lviSession.SubItems.Add(muted);

                var masterVol = Math.Round(session.MasterVolume);
                var masterVolume = $"{masterVol}";

                var peakVolume = session.PeakVolume == 0 ? "0" : $"{session.PeakVolume:N6}";

                lviSession.SubItems.Add(masterVolume);
                lviSession.SubItems.Add(peakVolume);

                LvSessions.Items.Add(lviSession);
            }

            LvSessions.EndUpdate();
        }

        /// <summary>
        /// Let the user know we've encountered a critical error, and shutdown
        /// </summary>
        /// <param name="message"></param>
        internal void CriticalError(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => CriticalError(message)));
                return;
            }

            MessageBox.Show(message, "Audio Detection Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }
        
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // hide ourselves
            Visible = false;
            
            // properly dispose all audio objects
            AudioManager.Shutdown();

            // flush the logs
            Log.CloseAndFlush();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSetRefreshInterval_Click(object sender, EventArgs e)
        {
            var refreshStr = TbRefreshInterval.Text.Trim();
            if (string.IsNullOrEmpty(refreshStr))
            {
                MessageBox.Show("Please enter a valid number higher than 1.", "ADT", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                ActiveControl = TbRefreshInterval;
                return;
            }

            var parsed = int.TryParse(refreshStr, out var refresh);
            if (!parsed)
            {
                MessageBox.Show("Please enter a valid number higher than 1.", "ADT", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                ActiveControl = TbRefreshInterval;
                return;
            }

            AudioManager.RefreshInterval = refresh;
            MessageBox.Show($"Refresh interval set to: {refresh}", "ADT", MessageBoxButtons.OK);
        }
    }
}
