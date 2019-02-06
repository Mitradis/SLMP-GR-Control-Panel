using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SLMPLauncher
{
    internal sealed class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            bool fail = false;
            try
            {
                if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    Environment.Exit(0);
                }
                foreach (string line in new string[] { @"data\dawnguard.esm", @"data\dragonborn.esm", @"data\gamecomm.bsa", @"data\gamemesh1.bsa", @"data\gamemesh2.bsa", @"data\gamemesh3.bsa", @"data\gametext1.bsa", @"data\gametext2.bsa", @"data\gametext3.bsa", @"data\gametext4.bsa", @"data\gametext5.bsa", @"data\gametext6.bsa", @"data\gametext7.bsa", @"data\gametext8.bsa", @"data\gamevoice1.bsa", @"data\gamevoice2.bsa", @"data\hearthfires.esm", @"data\skyrim.esm", @"data\update.esm", @"skyrim.exe", @"tesv.exe", @"atimgpud.dll", @"binkw32.dll", @"steam_api.dll" })
                {
                    if (!File.Exists(FormMain.pathGameFolder + line))
                    {
                        fail = true;
                    }
                }
            }
            catch
            {
                fail = true;
            }
            if (fail)
            {
                MessageBox.Show(@"Панель Управления должна располагаться по адресу:" + Environment.NewLine + @"Директория Игры\Skyrim\" + Environment.NewLine + Environment.NewLine + @"The Control Panel should be located at:" + Environment.NewLine + @"Game Directory\Skyrim\");
                Environment.Exit(0);
            }
            if (args != null)
            {
                foreach (string line in args)
                {
                    if (line.Length > 3)
                    {
                        if (line.StartsWith("-s=", StringComparison.OrdinalIgnoreCase))
                        {
                            FormMain.argsStartsWith = line.Remove(0, 3);
                        }
                        else if (line.StartsWith("-w=", StringComparison.OrdinalIgnoreCase))
                        {
                            FormMain.argsWaitBefore = line.Remove(0, 3);
                        }
                    }
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}