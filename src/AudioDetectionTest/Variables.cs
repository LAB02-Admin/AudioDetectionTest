using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreAudio;

namespace AudioDetectionTest
{
    internal static class Variables
    {
        /// <summary>
        /// Application info
        /// </summary>
        internal static string Version { get; } = $"{Assembly.GetExecutingAssembly().GetName().Version.Major}.{Assembly.GetExecutingAssembly().GetName().Version.Minor}.{Assembly.GetExecutingAssembly().GetName().Version.Build}.{Assembly.GetExecutingAssembly().GetName().Version.Revision}";

        /// <summary>
        /// Internal references
        /// </summary>
        internal static Main FrmM { get; set; }

        /// <summary>
        /// Audio references
        /// </summary>
        internal static MMDeviceEnumerator DefaultDeviceEnumerator { get; set; } = null;

        /// <summary>
        /// Local IO
        /// </summary>
        internal static string StartupPath { get; } = Path.GetDirectoryName(Application.ExecutablePath);
        internal static string LogPath { get; } = Path.Combine(StartupPath, "logs");
    }
}
