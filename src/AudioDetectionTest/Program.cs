using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace AudioDetectionTest
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // initialize logging
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Async(a =>
                    a.File(Path.Combine(Variables.LogPath, $"[{DateTime.Now:yyyy-MM-dd}] adt_.log"),
                        rollingInterval: RollingInterval.Day,
                        fileSizeLimitBytes: 10000000,
                        retainedFileCountLimit: 10,
                        rollOnFileSizeLimit: true,
                        buffered: true,
                        flushToDiskInterval: TimeSpan.FromMilliseconds(150)))
                .CreateLogger();
            
            // initialize ui
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // launch application
            Variables.FrmM = new Main();
            Application.Run(Variables.FrmM);
        }
    }
}
