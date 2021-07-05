using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public partial class FormMain : Form
    {
        public static List<string> archiveExt = new List<string>() { ".rar", ".7z", ".zip", ".zipx" };
        public static string pathLauncherExecuting = Process.GetCurrentProcess().MainModule.FileName;
        public static string pathLauncherFolder = FuncFiles.pathAddSlash(Path.GetDirectoryName(pathLauncherExecuting));
        public static string pathGameFolder = FuncFiles.pathAddSlash(Path.GetFullPath(pathLauncherFolder + ".."));
        public static string pathDataFolder = FuncFiles.pathAddSlash(pathGameFolder + "Data");
        public static string pathENBFolder = FuncFiles.pathAddSlash(pathLauncherFolder + "ENB");
        public static string pathModsFolder = FuncFiles.pathAddSlash(pathLauncherFolder + "Mods");
        public static string pathSystemFolder = FuncFiles.pathAddSlash(pathLauncherFolder + "System");
        public static string pathProgramsFolder = FuncFiles.pathAddSlash(pathGameFolder + "_Programs");
        public static string pathMyDoc = FuncFiles.pathAddSlash(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Games", "Skyrim"));
        public static string pathSkyrimINI = pathMyDoc + "Skyrim.ini";
        public static string pathSkyrimPrefsINI = pathMyDoc + "SkyrimPrefs.ini";
        public static string pathAppData = FuncFiles.pathAddSlash(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Skyrim"));
        public static string panelFileVersion = FileVersionInfo.GetVersionInfo(pathLauncherExecuting).ProductVersion;
        public static string pathLauncherINI = pathLauncherFolder + "SLMPLauncher.ini";
        public static string pathIgnoreINI = pathLauncherFolder + "SLMPIgnoreFiles.ini";
        public static string pathENBLocalINI = pathGameFolder + "enblocal.ini";
        public static string pathENBSeriesINI = pathGameFolder + "enbseries.ini";
        public static string argsStartsWith = null;
        public static string langTranslate = "RU";
        public static string customFont = null;
        public static string textAlreadyExists = null;
        public static string textConfirmTitle = null;
        public static string textCouldNotDelete = null;
        public static string textCouldNotMove = null;
        public static string textCouldRun = null;
        public static string textCouldUnpack = null;
        public static string textCouldWriteFile = null;
        public static string textFailedCopy = null;
        public static string textFailedCreate = null;
        public static string textNotFound = null;
        public static decimal maxFPS = 60;
        public static decimal memorySizeENB = 2048;
        public static int gameDirLength = pathGameFolder.Length;
        public static int numberStyle = 1;
        public static int settingsPreset = 2;
        public static int setupENB = 0;
        public static int updatesExtension = 1;
        internal static FormMain formMain = null;
        public static FontStyle customFontStyle = FontStyle.Regular;
        string pathFNIS = FuncFiles.pathAddSlash(Path.Combine(pathDataFolder + "Tools", "GenerateFNIS_for_Users")) + "GenerateFNISforUsers.exe";
        string pathDSR = FuncFiles.pathAddSlash(Path.Combine(pathDataFolder + "SkyProc Patchers", "Dual Sheath Redux Patch")) + "Dual Sheath Redux Patch.jar";
        string pathHelp = pathProgramsFolder + "SLMP-GR Help.chm";
        string pathWB = FuncFiles.pathAddSlash(pathProgramsFolder + "Wrye Bash") + "Wrye Bash.exe";
        string pathAllApps = pathProgramsFolder + "AllPrograms.exe";
        string registryPath = @"SOFTWARE\Bethesda Softworks\Skyrim";
        string registryKey = "Installed Path";
        string textClearDirectory = null;
        string textNoInIFound = null;
        string textNotInDirectory = null;
        string textRegistryFail = null;
        string textSetSettings = null;
        string textSetSettingsFail = null;
        string textSettingsReset = null;
        string textUseStandart = null;
        string[] typeSettings = null;
        int argsWaitBefore = 0;
        const int CS_DBLCLKS = 0x8;
        const int WS_MINIMIZEBOX = 0x20000;
        bool windgetOpen = false;
        Bitmap BMBackgroundImage;
        Bitmap BMbuttonClear;
        Bitmap BMbuttonClearGlow;
        Bitmap BMbuttonFull;
        Bitmap BMbuttonFullGlow;
        Bitmap BMbuttonFullPressed;
        Bitmap BMbuttonHalf;
        Bitmap BMbuttonHalfGlow;
        Bitmap BMbuttonHalfPressed;
        Bitmap BMbuttonOne;
        Bitmap BMbuttonOneGlow;
        Bitmap BMbuttonlogo;
        Bitmap BMbuttonlogoGlow;
        Bitmap BMbuttonlogoPressed;
        FormWidget settingsWidget = null;
        Point lastLocation;

        public FormMain()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(pathLauncherFolder);
            if (!FuncFiles.checkOnlyLatinChars(pathGameFolder))
            {
                MessageBox.Show("Папка игры или путь до нее могут содержать только латинские символы." + Environment.NewLine + Environment.NewLine + "The game folder or the path to it can contain only latin characters.");
                Environment.Exit(0);
            }
            if (!Directory.Exists(pathDataFolder))
            {
                MessageBox.Show(@"Панель Управления должна располагаться по адресу: Директория Игры\Любая Папка\" + Environment.NewLine + Environment.NewLine + @"The Control Panel should be located at: Game Directory\Any Folder\");
                Environment.Exit(0);
            }
            string[] arguments = Environment.GetCommandLineArgs();
            if (arguments.Length > 0)
            {
                foreach (string line in arguments)
                {
                    if (line.StartsWith("-s=", StringComparison.OrdinalIgnoreCase))
                    {
                        argsStartsWith = line.Remove(0, 3);
                    }
                    else if (line.StartsWith("-w=", StringComparison.OrdinalIgnoreCase))
                    {
                        argsWaitBefore = FuncParser.stringToInt(line.Remove(0, 3));
                    }
                }
                arguments = null;
            }
            if (!File.Exists(pathSkyrimPrefsINI) || !File.Exists(pathSkyrimINI))
            {
                FuncParser.iniWrite(pathLauncherINI, "General", "FirstRun", "true");
            }
            if (File.Exists(pathLauncherINI))
            {
                FuncParser.iniWrite(pathLauncherINI, "General", "Version_CP", panelFileVersion);
                int wLeft = FuncParser.intRead(pathLauncherINI, "General", "POS_WindowLeft");
                int wTop = FuncParser.intRead(pathLauncherINI, "General", "POS_WindowTop");
                if (wLeft >= 0 && wTop >= 0)
                {
                    if (wLeft > (Screen.PrimaryScreen.Bounds.Width - Size.Width))
                    {
                        wLeft = Screen.PrimaryScreen.Bounds.Width - Size.Width;
                    }
                    if (wTop > (Screen.PrimaryScreen.Bounds.Height - Size.Height))
                    {
                        wTop = Screen.PrimaryScreen.Bounds.Height - Size.Height;
                    }
                    StartPosition = FormStartPosition.Manual;
                    Location = new Point(wLeft, wTop);
                }
                settingsPreset = FuncParser.intRead(pathLauncherINI, "General", "SettingsPreset");
                if (settingsPreset < 0 || settingsPreset > 3)
                {
                    settingsPreset = 2;
                }
                numberStyle = FuncParser.intRead(pathLauncherINI, "General", "NumberStyle");
                if (numberStyle < 1 || numberStyle > 2)
                {
                    numberStyle = 1;
                }
                if (string.Equals(FuncParser.stringRead(pathLauncherINI, "General", "Language"), "EN", StringComparison.OrdinalIgnoreCase))
                {
                    langTranslate = "EN";
                    setLangTranslateEN();
                }
                else
                {
                    setLangTranslateRU();
                }
                maxFPS = FuncParser.intRead(pathLauncherINI, "Game", "MaxFPS");
                if (maxFPS < 30 || maxFPS > 360)
                {
                    maxFPS = 60;
                }
                memorySizeENB = FuncParser.intRead(pathLauncherINI, "ENB", "MemorySizeMb");
                if (memorySizeENB < 0 || memorySizeENB > 32768)
                {
                    memorySizeENB = 2048;
                }
                if (!FuncParser.keyExists(pathLauncherINI, "Game", "ZFighting"))
                {
                    FuncParser.iniWrite(pathLauncherINI, "Game", "ZFighting", "false");
                }
                int nearDistance = FuncParser.intRead(pathLauncherINI, "Game", "NearDistance");
                if (nearDistance < 15 || nearDistance > 25)
                {
                    FuncParser.iniWrite(pathLauncherINI, "Game", "NearDistance", "18");
                }
                customFont = FuncParser.stringRead(pathLauncherINI, "Font", "CP_Font");
                if (customFont != null)
                {
                    InstalledFontCollection ifc = new InstalledFontCollection();
                    int count = ifc.Families.Length;
                    for (int i = 0; i < count; i++)
                    {
                        if (ifc.Families[i].Name == customFont)
                        {
                            FuncMisc.supportStrikeOut(customFont);
                            FuncMisc.setFormFont(this);
                            break;
                        }
                        else if (i == 0)
                        {
                            customFont = null;
                        }
                    }
                    ifc = null;
                }
                updatesExtension = FuncParser.intRead(pathLauncherINI, "Updates", "UpdatesExtension");
                if (updatesExtension < 0 || updatesExtension > 3)
                {
                    updatesExtension = 1;
                }
                if (FuncParser.readAsBool(pathLauncherINI, "General", "FirstRun"))
                {
                    resetSettings(true);
                }
            }
            else
            {
                setLangTranslateRU();
                StartPosition = FormStartPosition.CenterScreen;
                closeControlPanel(this, new EventArgs());
                resetSettings(true);
            }
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(closeControlPanel);
            refreshStyle();
            formMain = this;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }
        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && button_Skyrim.Enabled)
            {
                button_Skyrim_Click(this, new EventArgs());
            }
        }
        private void closeControlPanel(object sender, EventArgs e)
        {
            if (!File.Exists(pathLauncherINI))
            {
                FuncFiles.writeToFile(pathLauncherINI, new List<string>() {
                "[General]",
                "Version_CP=" + panelFileVersion,
                "HideWebButton=true",
                "POS_WindowTop=100",
                "POS_WindowLeft=100",
                "SettingsPreset=2",
                "NumberStyle=1",
                "AspectRatio=-1",
                "FirstRun=true",
                "Language=RU",
                "",
                "[Game]",
                "MaxFPS=60",
                "ZFighting=false",
                "NearDistance=18",
                "",
                "[ENB]",
                "MemorySizeMb=2048",
                "LastPreset=",
                "",
                "[Font]",
                "; common font for CP, examples:",
                ";    Comic Sans MS",
                ";    Courier New",
                ";    Franklin Gothic Medium",
                ";    Georgia",
                ";    Impact",
                ";    Lucida Sans Unicode",
                ";    Microsoft Sans Serif",
                ";    Palatino Linotype",
                ";    Tahoma",
                ";    Times New Roman",
                ";    Trebuchet MS",
                "CP_Font=",
                "",
                "[Updates]",
                "; files extension index: .rar, .7z, .zip, .zipx",
                "UpdatesExtension=1",
                "UpdateHost=http://www.www.www/" });
            }
            else
            {
                FuncParser.iniWrite(pathLauncherINI, "General", "SettingsPreset", settingsPreset.ToString());
                FuncParser.iniWrite(pathLauncherINI, "General", "NumberStyle", numberStyle.ToString());
                FuncParser.iniWrite(pathLauncherINI, "General", "Language", langTranslate);
                FuncParser.iniWrite(pathLauncherINI, "Game", "MaxFPS", maxFPS.ToString());
                FuncParser.iniWrite(pathLauncherINI, "ENB", "MemorySizeMb", memorySizeENB.ToString());
                if (Top >= 0 && Left >= 0)
                {
                    FuncParser.iniWrite(pathLauncherINI, "General", "POS_WindowTop", Top.ToString());
                    FuncParser.iniWrite(pathLauncherINI, "General", "POS_WindowLeft", Left.ToString());
                }
            }
            AppDomain.CurrentDomain.ProcessExit -= new EventHandler(closeControlPanel);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_WryeBash_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(pathWB))
            {
                pressedButtonEvent(button_WryeBash, BMbuttonFullPressed, button_MouseEnter, button_MouseLeave);
                FuncFiles.runProcess(pathWB, null, closeWryeBash, false, false, false);
            }
            else
            {
                MessageBox.Show(pathWB + textNotFound);
            }
        }
        private void closeWryeBash(object sender, EventArgs e)
        {
            raisedButtonEvent(button_WryeBash, BMbuttonFull, button_MouseEnter, button_MouseLeave);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_DSR_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(pathDSR))
            {
                pressedButtonEvent(button_DSR, BMbuttonHalfPressed, button_Half_MouseEnter, button_Half_MouseLeave);
                FuncFiles.runProcess(pathDSR, "-jar \"" + pathDSR + "\"", closeDSR, true, false, false);
            }
            else
            {
                MessageBox.Show(pathDSR + textNotFound);
            }
        }
        private void closeDSR(object sender, EventArgs e)
        {
            raisedButtonEvent(button_DSR, BMbuttonHalf, button_Half_MouseEnter, button_Half_MouseLeave);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_FNIS_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(pathFNIS))
            {
                pressedButtonEvent(button_FNIS, BMbuttonHalfPressed, button_Half_MouseEnter, button_Half_MouseLeave);
                FuncFiles.runProcess(pathFNIS, null, closeFNIS, false, false, false);
            }
            else
            {
                MessageBox.Show(pathFNIS + textNotFound);
            }
        }
        private void closeFNIS(object sender, EventArgs e)
        {
            raisedButtonEvent(button_FNIS, BMbuttonHalf, button_Half_MouseEnter, button_Half_MouseLeave);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_GameFolder_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (Directory.Exists(pathGameFolder))
            {
                Process.Start(pathGameFolder);
            }
            else
            {
                MessageBox.Show(pathGameFolder + textNotFound);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_ProgramsFolder_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(pathAllApps))
            {
                FuncFiles.runProcess(pathAllApps, null, null, false, false, false);
            }
            else
            {
                MessageBox.Show(pathAllApps + textNotFound);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_MyDocs_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (Directory.Exists(pathMyDoc))
            {
                Process.Start(pathMyDoc);
            }
            else
            {
                MessageBox.Show(pathMyDoc + textNotFound);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_ResetSettings_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (FuncMisc.dialogResult(textSettingsReset))
            {
                resetSettings(false);
                button_Options_Click(this, new EventArgs());
            }
        }
        public void resetSettings(bool showHelp)
        {
            try
            {
                RegistryKey key;
                key = Registry.LocalMachine.CreateSubKey(registryPath);
                key.SetValue(registryKey, pathGameFolder);
                key.Close();
            }
            catch
            {
                MessageBox.Show(textRegistryFail + registryPath + " " + registryKey + "=" + pathGameFolder);
            }
            FuncFiles.deleteAny(pathMyDoc + "Logs");
            FuncFiles.deleteAny(pathMyDoc + "SKSE");
            FuncFiles.deleteAny(pathMyDoc + "SkyProc");
            FuncFiles.deleteAny(pathMyDoc + "BethINI Cache");
            FuncFiles.deleteAny(pathMyDoc + "BashSettings.dat");
            FuncFiles.deleteAny(pathMyDoc + "BashSettings.dat.bak");
            FuncFiles.deleteAny(pathMyDoc + "BashLoadOrders.dat");
            FuncFiles.deleteAny(pathMyDoc + "BashLoadOrders.dat.bak");
            FuncFiles.deleteAny(pathMyDoc + "ModChecker.html");
            FuncFiles.deleteAny(pathMyDoc + "RendererInfo.txt");
            FuncFiles.deleteAny(FuncFiles.pathAddSlash(pathMyDoc + "Saves") + "Bash");
            FuncFiles.deleteAny(pathSkyrimINI);
            FuncFiles.deleteAny(pathMyDoc + "Skyrim.ini.BethINIbackup");
            FuncFiles.deleteAny(pathSkyrimPrefsINI);
            FuncFiles.deleteAny(pathMyDoc + "SkyrimPrefs.ini.BethINIbackup");
            FuncFiles.creatDirectory(pathMyDoc);
            if (File.Exists(pathLauncherFolder + "Skyrim.ini"))
            {
                FuncFiles.copyAny(pathLauncherFolder + "Skyrim.ini", pathSkyrimINI);
            }
            else
            {
                MessageBox.Show(textUseStandart + pathLauncherFolder + "Skyrim.ini");
                FuncFiles.writeToFile(pathSkyrimINI, FuncSettings.skyrimINI());
            }
            if (File.Exists(pathLauncherFolder + "SkyrimPrefs.ini"))
            {
                FuncFiles.copyAny(pathLauncherFolder + "SkyrimPrefs.ini", pathSkyrimPrefsINI);
            }
            else
            {
                MessageBox.Show(textUseStandart + pathLauncherFolder + "SkyrimPrefs.ini");
                FuncFiles.writeToFile(pathSkyrimPrefsINI, FuncSettings.skyrimPrefsINI());
            }
            if (File.Exists(pathProgramsFolder + "BashSettings.dat"))
            {
                FuncFiles.copyAny(pathProgramsFolder + "BashSettings.dat", pathMyDoc + "BashSettings.dat");
            }
            FuncFiles.deleteAny(pathAppData + "DLCList.txt");
            FuncFiles.deleteAny(pathAppData + "Plugins.txt");
            FuncFiles.deleteAny(pathAppData + "LoadOrder.txt");
            FuncFiles.deleteAny(pathAppData + "Plugins.tes5viewsettings");
            FuncFiles.creatDirectory(pathAppData);
            if (File.Exists(pathLauncherFolder + "Plugins.txt"))
            {
                FuncFiles.copyAny(pathLauncherFolder + "Plugins.txt", pathAppData + "Plugins.txt");
                FuncFiles.copyAny(pathLauncherFolder + "Plugins.txt", pathAppData + "LoadOrder.txt");
            }
            else
            {
                MessageBox.Show(textUseStandart + pathLauncherFolder + "Plugins.txt");
                FuncFiles.writeToFile(pathAppData + "Plugins.txt", FuncSettings.pluginsTXT());
                FuncFiles.writeToFile(pathAppData + "LoadOrder.txt", FuncSettings.pluginsTXT());
            }
            if (File.Exists(pathProgramsFolder + "Plugins.tes5viewsettings"))
            {
                FuncFiles.copyAny(pathProgramsFolder + "Plugins.tes5viewsettings", pathAppData + "Plugins.tes5viewsettings");
            }
            if (File.Exists(pathSkyrimINI) && File.Exists(pathSkyrimPrefsINI))
            {
                FuncSettings.setSettingsPreset(settingsPreset);
                FuncParser.iniWrite(pathSkyrimPrefsINI, "Display", "iSize W", Screen.PrimaryScreen.Bounds.Width.ToString());
                FuncParser.iniWrite(pathSkyrimPrefsINI, "Display", "iSize H", Screen.PrimaryScreen.Bounds.Height.ToString());
                FuncMisc.setAspectRatio(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                FuncSettings.physicsFPS();
                FuncSettings.restoreENBAdapter();
                FuncSettings.restoreENBBorderless();
                FuncSettings.restoreENBVSync();
                MessageBox.Show(typeSettings[settingsPreset] + textSetSettings);
            }
            else
            {
                MessageBox.Show(textSetSettingsFail);
            }
            if (showHelp)
            {
                FuncParser.iniWrite(pathLauncherINI, "General", "FirstRun", "false");
                button_Help_Click(this, new EventArgs());
            }

        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_ClearDirectory_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (FuncMisc.dialogResult(textClearDirectory))
            {
                FuncFiles.deleteAny(pathMyDoc + "SKSE");
                FuncFiles.deleteAllInFolder(pathMyDoc + "Logs", "*");
                FuncFiles.deleteAllInFolder(pathMyDoc + "Saves", "*.bak");
                FuncFiles.deleteAny(FuncFiles.pathAddSlash(Path.GetFullPath(pathGameFolder + "..")) + "Skyrim Mods");
                FuncClear.clearGameFolder();
            }
        }
        private void button_AddIgnoreFiles_Click(object sender, EventArgs e)
        {
            label1.Focus();
            openFileDialog1.InitialDirectory = pathGameFolder;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (openFileDialog1.FileName.IndexOf(pathGameFolder, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    List<string> ignoreList = new List<string>();
                    ignoreList.AddRange(File.ReadAllLines(pathIgnoreINI));
                    foreach (string line in openFileDialog1.FileNames)
                    {
                        string file = line.Remove(0, gameDirLength);
                        if (!ignoreList.Exists(s => s.Equals(file, StringComparison.OrdinalIgnoreCase)))
                        {
                            ignoreList.Add(file);
                        }
                    }
                    string path = Path.GetDirectoryName(openFileDialog1.FileName);
                    while (path.Length > gameDirLength)
                    {
                        string folder = path.Remove(0, gameDirLength);
                        if (!ignoreList.Exists(s => s.Equals(folder, StringComparison.OrdinalIgnoreCase)))
                        {
                            ignoreList.Add(folder);
                        }
                        path = Path.GetDirectoryName(path);
                    }
                    FuncFiles.writeToFile(pathIgnoreINI, ignoreList);
                    ignoreList.Clear();
                }
                else
                {
                    MessageBox.Show(textNotInDirectory);
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_Options_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(pathSkyrimINI) && File.Exists(pathSkyrimPrefsINI) && File.Exists(pathAppData + "Plugins.txt") && File.Exists(pathAppData + "LoadOrder.txt") && Directory.Exists(pathDataFolder))
            {
                formShowDialog(new FormOptions());
            }
            else
            {
                MessageBox.Show(textNoInIFound);
            }
        }
        private void button_ENB_Click(object sender, EventArgs e)
        {
            formShowDialog(new FormENB());
        }
        private void button_Mods_Click(object sender, EventArgs e)
        {
            formShowDialog(new FormMods());
        }
        private void button_Programs_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(pathProgramsFolder))
            {
                formShowDialog(new FormPrograms());
            }
            else
            {
                label1.Focus();
                MessageBox.Show(pathProgramsFolder + textNotFound);
            }
        }
        private void formShowDialog(Form form)
        {
            label1.Focus();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                form.Dispose();
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_Skyrim_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(pathGameFolder + "SKSE.exe"))
            {
                pressedButtonEvent(button_Skyrim, BMbuttonlogoPressed, button_Skyrim_MouseEnter, button_Skyrim_MouseLeave);
                if (argsStartsWith != null && File.Exists(argsStartsWith))
                {
                    FuncFiles.runProcess(argsStartsWith, null, null, false, true, false);
                }
                if (argsWaitBefore > 0)
                {
                    Thread.Sleep(argsWaitBefore * 1000);
                }
                FuncFiles.runProcess(pathGameFolder + "SKSE.exe", "-forcesteamloader", closeSKSE, false, false, false);
            }
            else
            {
                MessageBox.Show(pathGameFolder + "SKSE.exe" + textNotFound);
            }
        }
        private void closeSKSE(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("SKYRIM");
            if (processes.Length > 0)
            {
                processes[0].EnableRaisingEvents = true;
                processes[0].Exited += closeGAME;
            }
            else
            {
                closeGAME(this, new EventArgs());
            }
        }
        private void closeGAME(object sender, EventArgs e)
        {
            raisedButtonEvent(button_Skyrim, BMbuttonlogo, button_Skyrim_MouseEnter, button_Skyrim_MouseLeave);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_Help_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(pathHelp))
            {
                FuncFiles.runProcess(pathHelp, null, null, false, true, false);
            }
            else
            {
                MessageBox.Show(pathHelp + textNotFound);
            }
        }
        public void button_Widget_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (!windgetOpen)
            {
                windgetOpen = true;
                bool hide = FuncParser.readAsBool(pathLauncherINI, "General", "HideWebButton");
                settingsWidget = new FormWidget(hide);
                if (hide)
                {
                    settingsWidget.ClientSize = new System.Drawing.Size(232, 60);
                }
                settingsWidget.DesktopLocation = new Point(Left, Top - settingsWidget.Size.Height);
                settingsWidget.Show(this);
                button_Widget.BackgroundImage = Properties.Resources.buttonWidgetPressed;
            }
            else
            {
                windgetOpen = false;
                settingsWidget.Dispose();
                button_Widget.BackgroundImage = Properties.Resources.buttonWidget;
            }
        }
        private void button_Minimize_Click(object sender, EventArgs e)
        {
            label1.Focus();
            WindowState = FormWindowState.Minimized;
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            label1.Focus();
            Application.Exit();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
            label1.MouseMove += MainForm_MouseMove;
            label1.MouseLeave += MainForm_MouseLeave;
        }
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            label1.MouseMove -= MainForm_MouseMove;
            label1.MouseLeave -= MainForm_MouseLeave;
        }
        private void MainForm_MouseLeave(object sender, EventArgs e)
        {
            label1.MouseMove -= MainForm_MouseMove;
            label1.MouseLeave -= MainForm_MouseLeave;
        }
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
            if (windgetOpen)
            {
                settingsWidget.Location = new Point(Left, Top - settingsWidget.Size.Height);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void pressedButtonEvent(Button button, Bitmap bg, EventHandler nenter, EventHandler mleave)
        {
            button.Enabled = false;
            button.MouseEnter -= nenter;
            button.MouseLeave -= mleave;
            button.BackgroundImage = bg;
        }
        private void raisedButtonEvent(Button button, Bitmap bg, EventHandler nenter, EventHandler mleave)
        {
            button.Enabled = true;
            button.MouseEnter += nenter;
            button.MouseLeave += mleave;
            button.BackgroundImage = bg;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public void setLangTranslateRU()
        {
            button_ClearDirectory.Text = "Очистка";
            button_GameFolder.Text = "Директория Игры";
            button_Mods.Text = "Моды";
            button_MyDocs.Text = "Мои Документы";
            button_Options.Text = "Настройки Игры";
            button_ProgramsFolder.Text = "Все Программы";
            button_Programs.Text = "Программы";
            button_ResetSettings.Text = "Сброс Настроек";
            textAlreadyExists = "Файл уже существует: ";
            textClearDirectory = "Очистить директорию? ВНИМАНИЕ: Все файлы не относящиеся к сборке и не внесенные в игнор-лист будут удалены!";
            textConfirmTitle = "Подтверждение";
            textCouldNotDelete = "Не удалось удалить: ";
            textCouldNotMove = "Не удалось переместить: ";
            textCouldRun = "Не удалось запустить файл: ";
            textCouldUnpack = "Не найден 7z.exe или архив: ";
            textCouldWriteFile = "Не удалось записать файл: ";
            textFailedCopy = "Не удалось скопировать: ";
            textFailedCreate = "Не удалось создать папку: ";
            textNoInIFound = "Файлы настроек Skyrim не сформированы. Сделайте сброс настроек.";
            textNotFound = " не найден(а).";
            textNotInDirectory = "Выбран(ы) объект(ы) вне директории игры.";
            textRegistryFail = "Не удалось записать путь в реест: ";
            textSetSettings = " настройки установлены.";
            textSetSettingsFail = "Не удалось сбросить настройки. Проверьте права доступа к ini файлам в: " + Environment.NewLine + pathMyDoc;
            textSettingsReset = "Сбросить настройки?";
            textUseStandart = "Будут использованы стандартные шаблоны настроек т.к. не найден файл: " + Environment.NewLine;
            toolTip1.SetToolTip(button_AddIgnoreFiles, "Добавление файла(ов) с папкой(ами) в шаблон игнор листа.");
            toolTip1.SetToolTip(button_ClearDirectory, "Удаляет \"чужие\" файлы. В т.ч. распакованные программы.");
            toolTip1.SetToolTip(button_DSR, "Патчер Dual Sheath Redux. Применять после изменения модов содержащих оружие.");
            toolTip1.SetToolTip(button_ENB, "Меню управления ENB с выбором различных пресетов.");
            toolTip1.SetToolTip(button_FNIS, "Патчер FNIS. Применять после изменения модов содержащих анимации.");
            toolTip1.SetToolTip(button_GameFolder, "Открывает папку-директорию игры.");
            toolTip1.SetToolTip(button_Mods, "Установка опциональных модов.");
            toolTip1.SetToolTip(button_MyDocs, "Открывает папку с ini файлами и сохранениями.");
            toolTip1.SetToolTip(button_Options, "Настройка конфигурации, параметров игры, управление подключаемыми файлами.");
            toolTip1.SetToolTip(button_ProgramsFolder, "Открывает папку с ярлыками программ для редактирования игры.");
            toolTip1.SetToolTip(button_Programs, "Распаковка различных программ для редактирования игры.");
            toolTip1.SetToolTip(button_ResetSettings, "Полный сброс настроек игры и восстановление последовательности модов.");
            toolTip1.SetToolTip(button_Skyrim, "Запустить игру.");
            toolTip1.SetToolTip(button_WryeBash, "Сортировщик модов. Моды имеющие конфликты будут красными.");
            typeSettings = new string[] { "Низкие", "Средние", "Высокие", "Ультра" };
        }
        public void setLangTranslateEN()
        {
            button_ClearDirectory.Text = "Clear";
            button_GameFolder.Text = "Game Directory";
            button_Mods.Text = "Mods";
            button_MyDocs.Text = "My Documents";
            button_Options.Text = "Game Settings";
            button_ProgramsFolder.Text = "All Programs";
            button_Programs.Text = "Programs";
            button_ResetSettings.Text = "Reset Settings";
            textAlreadyExists = "File already exists: ";
            textClearDirectory = "Clear directory? ATTENTION: All files not related to the assembly and not included in the ignore list will be deleted!";
            textConfirmTitle = "Confirm";
            textCouldNotDelete = "Could not delete: ";
            textCouldNotMove = "Failed to move: ";
            textCouldRun = "Could not launch file: ";
            textCouldUnpack = "7z.exe not found or arhive: ";
            textCouldWriteFile = "Could not write file: ";
            textFailedCopy = "Could not copy: ";
            textFailedCreate = "Could not create folder: ";
            textNoInIFound = "Skyrim configuration files are not generated. Reset the settings.";
            textNotFound = " not found.";
            textNotInDirectory = "Selected object(s) outside the game directory.";
            textRegistryFail = "Could not write path to the registry: ";
            textSetSettings = " settings are set.";
            textSetSettingsFail = "Failed to reset settings. Check permissions for ini files in: " + Environment.NewLine + pathMyDoc;
            textSettingsReset = "Reset settings?";
            textUseStandart = "Standard templates of settings will be used because file not found: " + Environment.NewLine;
            toolTip1.SetToolTip(button_AddIgnoreFiles, "Adding a file(s) with folder(s) to the ignore list template.");
            toolTip1.SetToolTip(button_ClearDirectory, "Delete \"strangers\" files. Including unpacked programs.");
            toolTip1.SetToolTip(button_DSR, "Patcher Dual Sheath Redux. Apply after the change in the mods containing the weapons.");
            toolTip1.SetToolTip(button_ENB, "The ENB control menu with a selection of different presets.");
            toolTip1.SetToolTip(button_FNIS, "Patcher FNIS. Apply after the change in the mods containing the animation.");
            toolTip1.SetToolTip(button_GameFolder, "Opens folder-directory of the game.");
            toolTip1.SetToolTip(button_Mods, "Installing optional mods.");
            toolTip1.SetToolTip(button_MyDocs, "Opens a folder with ini files and saves.");
            toolTip1.SetToolTip(button_Options, "Configuring the configuration, game settings, managing the connected files.");
            toolTip1.SetToolTip(button_ProgramsFolder, "Opens a folder with shortcuts for editing games.");
            toolTip1.SetToolTip(button_Programs, "Unpacking various programs for editing games.");
            toolTip1.SetToolTip(button_ResetSettings, "Full reset of game settings and recovery of a sequence of mods.");
            toolTip1.SetToolTip(button_Skyrim, "Start the game.");
            toolTip1.SetToolTip(button_WryeBash, "Mods sorter. Mods having conflicts will be red.");
            typeSettings = new string[] { "Low", "Medium", "Hight", "Ultra" };
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public void refreshStyle()
        {
            if (numberStyle == 1)
            {
                BMBackgroundImage = Properties.Resources._1_MainForm;
                BMbuttonClear = Properties.Resources._1_buttonClear;
                BMbuttonClearGlow = Properties.Resources._1_buttonClearGlow;
                BMbuttonFull = Properties.Resources._1_buttonFull;
                BMbuttonFullGlow = Properties.Resources._1_buttonFullGlow;
                BMbuttonFullPressed = Properties.Resources._1_buttonFullPressed;
                BMbuttonHalf = Properties.Resources._1_buttonHalf;
                BMbuttonHalfGlow = Properties.Resources._1_buttonHalfGlow;
                BMbuttonHalfPressed = Properties.Resources._1_buttonHalfPressed;
                BMbuttonOne = Properties.Resources._1_buttonOne;
                BMbuttonOneGlow = Properties.Resources._1_buttonOneGlow;
                BMbuttonlogo = Properties.Resources._1_buttonlogo;
                BMbuttonlogoGlow = Properties.Resources._1_buttonlogoGlow;
                BMbuttonlogoPressed = Properties.Resources._1_buttonlogoPressed;
                FuncMisc.textColor(this, SystemColors.ControlText, Color.White, true);
            }
            else
            {
                BMBackgroundImage = Properties.Resources._2_MainForm;
                BMbuttonClear = Properties.Resources._2_buttonClear;
                BMbuttonClearGlow = Properties.Resources._2_buttonClearGlow;
                BMbuttonFull = Properties.Resources._2_buttonFull;
                BMbuttonFullGlow = Properties.Resources._2_buttonFullGlow;
                BMbuttonFullPressed = Properties.Resources._2_buttonFullPressed;
                BMbuttonHalf = Properties.Resources._2_buttonHalf;
                BMbuttonHalfGlow = Properties.Resources._2_buttonHalfGlow;
                BMbuttonHalfPressed = Properties.Resources._2_buttonHalfPressed;
                BMbuttonOne = Properties.Resources._2_buttonOne;
                BMbuttonOneGlow = Properties.Resources._2_buttonOneGlow;
                BMbuttonlogo = Properties.Resources._2_buttonlogo;
                BMbuttonlogoGlow = Properties.Resources._2_buttonlogoGlow;
                BMbuttonlogoPressed = Properties.Resources._2_buttonlogoPressed;
                FuncMisc.textColor(this, SystemColors.ControlLight, Color.Black, true);
            }
            if (button_Skyrim.Enabled)
            {
                button_Skyrim.BackgroundImage = BMbuttonlogo;
            }
            else
            {
                button_Skyrim.BackgroundImage = BMbuttonlogoPressed;
            }
            if (button_WryeBash.Enabled)
            {
                button_WryeBash.BackgroundImage = BMbuttonFull;
            }
            else
            {
                button_WryeBash.BackgroundImage = BMbuttonFullPressed;
            }
            if (button_DSR.Enabled)
            {
                button_DSR.BackgroundImage = BMbuttonHalf;
            }
            else
            {
                button_DSR.BackgroundImage = BMbuttonHalfPressed;
            }
            if (button_FNIS.Enabled)
            {
                button_FNIS.BackgroundImage = BMbuttonHalf;
            }
            else
            {
                button_FNIS.BackgroundImage = BMbuttonHalfPressed;
            }
            button_ProgramsFolder.BackgroundImage = BMbuttonFull;
            button_GameFolder.BackgroundImage = BMbuttonFull;
            button_ResetSettings.BackgroundImage = BMbuttonFull;
            button_ClearDirectory.BackgroundImage = BMbuttonClear;
            button_AddIgnoreFiles.BackgroundImage = BMbuttonOne;
            button_Mods.BackgroundImage = BMbuttonHalf;
            button_MyDocs.BackgroundImage = BMbuttonFull;
            button_Programs.BackgroundImage = BMbuttonFull;
            button_ENB.BackgroundImage = BMbuttonHalf;
            button_Options.BackgroundImage = BMbuttonFull;
            BackgroundImage = BMBackgroundImage;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = BMbuttonFullGlow;
        }
        private void button_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = BMbuttonFull;
        }
        private void button_Half_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = BMbuttonHalfGlow;
        }
        private void button_Half_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = BMbuttonHalf;
        }
        private void button_Add_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = BMbuttonOneGlow;
        }
        private void button_Add_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = BMbuttonOne;
        }
        private void button_Skyrim_MouseEnter(object sender, EventArgs e)
        {
            button_Skyrim.BackgroundImage = BMbuttonlogoGlow;
        }
        private void button_Skyrim_MouseLeave(object sender, EventArgs e)
        {
            button_Skyrim.BackgroundImage = BMbuttonlogo;
        }
        private void button_ClearDirectory_MouseEnter(object sender, EventArgs e)
        {
            button_ClearDirectory.BackgroundImage = BMbuttonClearGlow;
        }
        private void button_ClearDirectory_MouseLeave(object sender, EventArgs e)
        {
            button_ClearDirectory.BackgroundImage = BMbuttonClear;
        }
        private void button_Help_MouseEnter(object sender, EventArgs e)
        {
            button_Help.BackgroundImage = Properties.Resources.buttonHelpGlow;
        }
        private void button_Help_MouseLeave(object sender, EventArgs e)
        {
            button_Help.BackgroundImage = Properties.Resources.buttonHelp;
        }
        private void button_Widget_MouseEnter(object sender, EventArgs e)
        {
            if (windgetOpen)
            {
                button_Widget.BackgroundImage = Properties.Resources.buttonWidgetPressed;
            }
            else
            {
                button_Widget.BackgroundImage = Properties.Resources.buttonWidgetGlow;
            }
        }
        private void button_Widget_MouseLeave(object sender, EventArgs e)
        {
            if (windgetOpen)
            {
                button_Widget.BackgroundImage = Properties.Resources.buttonWidgetPressed;
            }
            else
            {
                button_Widget.BackgroundImage = Properties.Resources.buttonWidget;
            }
        }
        private void button_Minimize_MouseEnter(object sender, EventArgs e)
        {
            button_Minimize.BackgroundImage = Properties.Resources.buttonMinimizeGlow;
        }
        private void button_Minimize_MouseLeave(object sender, EventArgs e)
        {
            button_Minimize.BackgroundImage = Properties.Resources.buttonMinimize;
        }
        private void button_Close_MouseEnter(object sender, EventArgs e)
        {
            button_Close.BackgroundImage = Properties.Resources.buttonCloseGlow;
        }
        private void button_Close_MouseLeave(object sender, EventArgs e)
        {
            button_Close.BackgroundImage = Properties.Resources.buttonClose;
        }
    }
}