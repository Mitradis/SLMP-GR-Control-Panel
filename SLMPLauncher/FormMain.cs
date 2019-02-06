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
        public static string pathLauncherFolder = FuncFiles.pathAddSlash(AppDomain.CurrentDomain.BaseDirectory);
        public static string pathGameFolder = FuncFiles.pathAddSlash(Path.GetDirectoryName(Path.GetDirectoryName(pathLauncherFolder)));
        public static string pathPrograms = pathGameFolder + @"_Programs\";
        public static string pathProgramFiles = pathPrograms + @"ProgramFiles\";
        public static string pathMyDoc = FuncFiles.pathAddSlash(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + @"My Games\Skyrim\";
        public static string pathSkyrimINI = pathMyDoc + @"Skyrim.ini";
        public static string pathSkyrimPrefsINI = pathMyDoc + @"SkyrimPrefs.ini";
        public static string pathAppData = FuncFiles.pathAddSlash(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)) + @"Skyrim\";
        public static string panelFileVersion = FileVersionInfo.GetVersionInfo(Process.GetCurrentProcess().MainModule.FileName).ProductVersion;
        public static string pathLauncherINI = pathLauncherFolder + "SLMPLauncher.ini";
        public static string pathIgnoreINI = pathLauncherFolder + "SLMPIgnoreFiles.ini";
        public static string argsStartsWith = null;
        public static string argsWaitBefore = null;
        public static string langTranslate = "RU";
        public static string alreadyExists = null;
        public static string couldNotDelete = null;
        public static string couldNotMove = null;
        public static string couldRun = null;
        public static string couldUnpack = null;
        public static string couldWriteFile = null;
        public static string failedCopy = null;
        public static string failedCreate = null;
        public static int numberStyle = 1;
        public static int predictFPS = 60;
        public static int settingsPreset = 2;
        public static string customFont = null;
        public static FontStyle customFontStyle = System.Drawing.FontStyle.Regular;
        public static string pathFNISRAR = pathLauncherFolder + @"CPFiles\System\FNIS.rar";
        string pathFNIS = pathGameFolder + @"Data\Tools\GenerateFNIS_for_Users\GenerateFNISforUsers.exe";
        string pathDSR = pathGameFolder + @"Data\SkyProc Patchers\Dual Sheath Redux Patch\Dual Sheath Redux Patch.jar";
        string pathHelp = pathProgramFiles + @"SLMP-GR Help.chm";
        string pathWB = pathProgramFiles + @"Wrye Bash\Wrye Bash.exe";
        string registryPath = @"SOFTWARE\Bethesda Softworks\Skyrim";
        string registryKey = "Installed Path";
        string clearDirectory = null;
        string confirmTitle = null;
        string failWriteToRegistry = null;
        string noIniFound = null;
        string notFound = null;
        string notFoundTemplates = null;
        string notInDirectory = null;
        string setSettings = null;
        string settingsReset = null;
        string unPackFNIS = null;
        string[] typeSettings = null;
        bool windgetOpen = false;
        int mouseWindowX = 0;
        int mouseWindowY = 0;
        public Bitmap BMBackgroundImage;
        public Bitmap BMbuttonClear;
        public Bitmap BMbuttonClearGlow;
        public Bitmap BMbuttonFull;
        public Bitmap BMbuttonFullGlow;
        public Bitmap BMbuttonFullPressed;
        public Bitmap BMbuttonHalf;
        public Bitmap BMbuttonHalfGlow;
        public Bitmap BMbuttonHalfPressed;
        public Bitmap BMbuttonOne;
        public Bitmap BMbuttonOneGlow;
        public Bitmap BMbuttonlogo;
        public Bitmap BMbuttonlogoGlow;
        public Bitmap BMbuttonlogoPressed;
        FormWidget settingsWidget = null;

        public FormMain()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(pathLauncherFolder);
            if (File.Exists(pathLauncherINI))
            {
                if (panelFileVersion != FuncParser.stringRead(pathLauncherINI, "General", "Version_CP"))
                {
                    FuncParser.iniWrite(pathLauncherINI, "General", "Version_CP", panelFileVersion);
                }
                int wLeft = FuncParser.intRead(pathLauncherINI, "General", "POS_WindowLeft");
                int wTop = FuncParser.intRead(pathLauncherINI, "General", "POS_WindowTop");
                if (wLeft < 0 || wTop < 0)
                {
                    StartPosition = FormStartPosition.CenterScreen;
                }
                else
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
                if (FuncParser.stringRead(pathLauncherINI, "General", "Language").ToUpper() == "EN")
                {
                    langTranslate = "EN";
                    setLangTranslateEN();
                }
                else
                {
                    setLangTranslateRU();
                }
                predictFPS = FuncParser.intRead(pathLauncherINI, "Game", "PredictFPS");
                if (predictFPS < 30 || predictFPS > 240)
                {
                    predictFPS = 60;
                }
                if (!FuncParser.keyExists(pathLauncherINI, "Game", "ZFighting"))
                {
                    FuncParser.iniWrite(pathLauncherINI, "Game", "ZFighting", "0");
                }
                int nearDistance = FuncParser.intRead(pathLauncherINI, "Game", "NearDistance");
                if (nearDistance < 15 || nearDistance > 25)
                {
                    FuncParser.iniWrite(pathLauncherINI, "Game", "NearDistance", "18");
                }
                customFont = FuncParser.stringRead(pathLauncherINI, "Font", "CP_Font");
                if (customFont != null)
                {
                    var ifc = new InstalledFontCollection();
                    for (int i = ifc.Families.Length - 1; i >= 0; i--)
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
            }
            else
            {
                setLangTranslateRU();
                StartPosition = FormStartPosition.CenterScreen;
                OnProcessExit(this, new EventArgs());
            }
            if (!File.Exists(pathSkyrimPrefsINI) || !File.Exists(pathSkyrimINI))
            {
                resetSettings();
            }
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            refreshStyle();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void OnProcessExit(object sender, EventArgs e)
        {
            if (!File.Exists(pathLauncherINI))
            {
                FuncMisc.writeToFile(pathLauncherINI, new List<string>() { "[General]", "Version_CP=" + panelFileVersion, "HideWebButtons=false", "POS_WindowTop=100", "POS_WindowLeft=100", "SettingsPreset=2", "NumberStyle=1", "AspectRatio=-1", "Language=RU", "", "[Game]", "PredictFPS=60", "ZFighting=0", "NearDistance=18", "", "[ENB]", "MemorySizeMb=0", "LastPreset=", "", "[Font]", "CP_Font=", "", "Exaples:", "   Comic Sans MS", "   Courier New", "   Franklin Gothic Medium", "   Georgia", "   Impact", "   Lucida Sans Unicode", "   Microsoft Sans Serif", "   Palatino Linotype", "   Tahoma", "   Times New Roman", "   Trebuchet MS", "", "[Updates]", "UpdateHost=http://www.slmp.ru/_SLMP-GR/2019VE/" });
            }
            else
            {
                FuncParser.iniWrite(pathLauncherINI, "General", "SettingsPreset", settingsPreset.ToString());
                FuncParser.iniWrite(pathLauncherINI, "General", "NumberStyle", numberStyle.ToString());
                FuncParser.iniWrite(pathLauncherINI, "General", "Language", langTranslate);
                FuncParser.iniWrite(pathLauncherINI, "Game", "PredictFPS", predictFPS.ToString());
                if (Top >= 0 && Left >= 0)
                {
                    FuncParser.iniWrite(pathLauncherINI, "General", "POS_WindowTop", Top.ToString());
                    FuncParser.iniWrite(pathLauncherINI, "General", "POS_WindowLeft", Left.ToString());
                }
            }
            AppDomain.CurrentDomain.ProcessExit -= new EventHandler(OnProcessExit);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_WryeBash_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(pathWB))
            {
                pressButtonEvent(button_WryeBash, BMbuttonFullPressed, button_MouseEnter, button_MouseLeave);
                FuncMisc.runProcess(pathWB, null, WryeBashExited, this, false);
            }
            else
            {
                MessageBox.Show(pathWB + notFound);
            }
        }
        private void WryeBashExited(object sender, EventArgs e)
        {
            unPressButtonEvent(button_WryeBash, BMbuttonFull, button_MouseEnter, button_MouseLeave);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_DSRStart_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(pathDSR))
            {
                pressButtonEvent(button_DSRStart, BMbuttonHalfPressed, buttonH_MouseEnter, buttonH_MouseLeave);
                FuncMisc.runProcess(pathDSR, null, DSRExited, this, false);
            }
            else
            {
                MessageBox.Show(pathDSR + notFound);
            }
        }
        private void DSRExited(object sender, EventArgs e)
        {
            unPressButtonEvent(button_DSRStart, BMbuttonHalf, buttonH_MouseEnter, buttonH_MouseLeave);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_FNIS_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(pathFNIS))
            {
                if (File.Exists(pathFNISRAR))
                {
                    DialogResult dialogResult = MessageBox.Show(unPackFNIS, confirmTitle, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        FuncMisc.unpackRAR(pathFNISRAR);
                    }
                }
                pressButtonEvent(button_FNISStart, BMbuttonHalfPressed, buttonH_MouseEnter, buttonH_MouseLeave);
                FuncMisc.runProcess(pathFNIS, null, FNISExited, this, false);
            }
            else
            {
                MessageBox.Show(pathFNIS + notFound);
            }
        }
        private void FNISExited(object sender, EventArgs e)
        {
            unPressButtonEvent(button_FNISStart, BMbuttonHalf, buttonH_MouseEnter, buttonH_MouseLeave);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_GameDirectory_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (Directory.Exists(pathGameFolder))
            {
                Process.Start(pathGameFolder);
            }
            else
            {
                MessageBox.Show(pathGameFolder + notFound);
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_ProgrammsFolder_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (Directory.Exists(pathPrograms))
            {
                Process.Start(pathPrograms);
            }
            else
            {
                MessageBox.Show(pathPrograms + notFound);
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_MyDocs_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (Directory.Exists(pathMyDoc))
            {
                Process.Start(pathMyDoc);
            }
            else
            {
                MessageBox.Show(pathMyDoc + notFound);
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_ResetSettings_Click(object sender, EventArgs e)
        {
            label1.Focus();
            DialogResult dialogResult = MessageBox.Show(settingsReset, confirmTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                resetSettings();
                button_Options_Click(this, new EventArgs());
            }
        }
        public void resetSettings()
        {
            if (File.Exists(pathLauncherFolder + "Skyrim.ini") && File.Exists(pathLauncherFolder + "SkyrimPrefs.ini") && File.Exists(pathLauncherFolder + @"MasterList\Plugins.txt"))
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
                    MessageBox.Show(failWriteToRegistry + registryPath + " " + registryKey + "=" + pathGameFolder);
                }
                FuncFiles.deleteAny(pathSkyrimINI);
                FuncFiles.deleteAny(pathSkyrimPrefsINI);
                FuncFiles.deleteAny(pathMyDoc + "Logs");
                FuncFiles.deleteAny(pathMyDoc + "SKSE");
                FuncFiles.deleteAny(pathMyDoc + "SkyProc");
                FuncFiles.deleteAny(pathMyDoc + "BashSettings.dat");
                FuncFiles.deleteAny(pathMyDoc + "BashSettings.dat.bak");
                FuncFiles.deleteAny(pathMyDoc + "RendererInfo.txt");
                FuncFiles.deleteAny(pathMyDoc + @"Saves\Bash");
                FuncFiles.creatDirectory(pathMyDoc);
                FuncFiles.copyAny(pathLauncherFolder + "Skyrim.ini", pathSkyrimINI);
                FuncFiles.copyAny(pathLauncherFolder + "SkyrimPrefs.ini", pathSkyrimPrefsINI);
                FuncFiles.copyAny(pathLauncherFolder + @"MasterList\BashSettings.dat", pathMyDoc + "BashSettings.dat");
                FuncFiles.deleteAny(pathAppData + @"Plugins.txt");
                FuncFiles.deleteAny(pathAppData + @"LoadOrder.txt");
                FuncFiles.deleteAny(pathAppData + @"Plugins.tes5viewsettings");
                FuncFiles.creatDirectory(pathAppData);
                FuncFiles.copyAny(pathLauncherFolder + @"MasterList\Plugins.txt", pathAppData + @"Plugins.txt");
                FuncFiles.copyAny(pathLauncherFolder + @"MasterList\Plugins.txt", pathAppData + @"LoadOrder.txt");
                FuncFiles.copyAny(pathLauncherFolder + @"MasterList\Plugins.tes5viewsettings", pathAppData + @"Plugins.tes5viewsettings");
                FuncSettings.setSettingsPreset(settingsPreset);
                FuncParser.iniWrite(pathSkyrimPrefsINI, "Display", "iSize W", Screen.PrimaryScreen.Bounds.Width.ToString());
                FuncParser.iniWrite(pathSkyrimPrefsINI, "Display", "iSize H", Screen.PrimaryScreen.Bounds.Height.ToString());
                FuncSettings.physicsFPS();
                FuncSettings.restoreENBAdapter();
                FuncSettings.restoreENBBorderless();
                FuncSettings.restoreENBVSync();
                MessageBox.Show(typeSettings[settingsPreset] + setSettings);
            }
            else
            {
                MessageBox.Show(notFoundTemplates);
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_ClearDirectory_Click(object sender, EventArgs e)
        {
            label1.Focus();
            DialogResult dialogResult = MessageBox.Show(clearDirectory, confirmTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FuncFiles.deleteAny(pathMyDoc + "SKSE");
                FuncFiles.deleteAllInFolder(pathMyDoc + "Logs", "*");
                FuncFiles.deleteAllInFolder(pathMyDoc + "Saves", "*.bak");
                FuncFiles.deleteAny(pathGameFolder + @"..\Skyrim Mods");
                FuncClear.clearGameFolder();
            }
        }
        private void button_AddFileToIgnore_Click(object sender, EventArgs e)
        {
            label1.Focus();
            openFileDialog1.InitialDirectory = pathGameFolder;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (openFileDialog1.FileName.ToLower().Contains(pathGameFolder.ToLower()))
                {
                    foreach (string line in openFileDialog1.FileNames)
                    {
                        File.AppendAllText(pathIgnoreINI, line.Remove(0, pathGameFolder.Length) + Environment.NewLine);
                    }
                }
                else
                {
                    MessageBox.Show(notInDirectory);
                }
            }
        }
        private void button_AddFolderToIgnore_Click(object sender, EventArgs e)
        {
            label1.Focus();
            folderBrowserDialog1.SelectedPath = pathGameFolder;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (folderBrowserDialog1.SelectedPath.ToLower().Contains(pathGameFolder.ToLower()))
                {
                    File.AppendAllText(pathIgnoreINI, folderBrowserDialog1.SelectedPath.Remove(0, pathGameFolder.Length) + Environment.NewLine);
                }
                else
                {
                    MessageBox.Show(notInDirectory);
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_RemPrograms_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (Directory.Exists(pathProgramFiles))
            {
                var form = new FormPrograms();
                form.ShowDialog();
                form = null;
            }
            else
            {
                MessageBox.Show(pathProgramFiles + notFound);
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_ENBmenu_Click(object sender, EventArgs e)
        {
            label1.Focus();
            var form = new FormENB();
            form.ShowDialog();
            form = null;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_Mods_Click(object sender, EventArgs e)
        {
            label1.Focus();
            var form = new FormMods();
            form.ShowDialog();
            form = null;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_Skyrim_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(pathGameFolder + "SKSE.exe"))
            {
                pressButtonEvent(button_Skyrim, BMbuttonlogoPressed, buttonSkyrim_MouseEnter, buttonSkyrim_MouseLeave);
                if (argsStartsWith != null && File.Exists(argsStartsWith))
                {
                    FuncMisc.runProcess(argsStartsWith, null, null, null, false);
                }
                if (argsWaitBefore != null)
                {
                    int WaitTime = FuncParser.stringToInt(argsWaitBefore);
                    if (WaitTime > 0)
                    {
                        FuncMisc.toggleButtons(this, false);
                        Thread.Sleep(WaitTime * 1000);
                        FuncMisc.toggleButtons(this, true);
                        button_Skyrim.Enabled = false;
                    }
                }
                FuncMisc.runProcess(pathGameFolder + "SKSE.exe", "-forcesteamloader", SKSEExited, this, false);
            }
            else
            {
                MessageBox.Show("SKSE.exe" + notFound);
            }
        }
        private void SKSEExited(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("SKYRIM");
            if (processes.Length > 0)
            {
                processes[0].EnableRaisingEvents = true;
                processes[0].Exited += processGAMEExited;
            }
            else
            {
                processGAMEExited(this, new EventArgs());
            }
        }
        private void processGAMEExited(object sender, EventArgs e)
        {
            unPressButtonEvent(button_Skyrim, BMbuttonlogo, buttonSkyrim_MouseEnter, buttonSkyrim_MouseLeave);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_Options_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(pathSkyrimINI) && File.Exists(pathSkyrimPrefsINI) && File.Exists(pathAppData + @"Plugins.txt") && File.Exists(pathAppData + @"LoadOrder.txt") && Directory.Exists(pathGameFolder + @"Data\"))
            {
                var form = new FormOptions();
                form.ShowDialog();
                form = null;
            }
            else
            {
                MessageBox.Show(noIniFound);
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_Help_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(pathHelp))
            {
                Process.Start(pathHelp);
            }
            else
            {
                MessageBox.Show(pathHelp + notFound);
            }
        }
        private void button_Widget_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (!windgetOpen)
            {
                windgetOpen = true;
                settingsWidget = new FormWidget();
                settingsWidget.DesktopLocation = new Point(Left, Top - settingsWidget.Size.Height);
                settingsWidget.Show(this);
                button_Widget.BackgroundImage = Properties.Resources.buttonWidgetPressed;
            }
            else
            {
                windgetOpen = false;
                settingsWidget.Dispose();
                settingsWidget = null;
                button_Widget.BackgroundImage = Properties.Resources.buttonWidget;
            }
        }
        private void button_Minimize_Click(object sender, EventArgs e)
        {
            label1.Focus();
            WindowState = FormWindowState.Minimized;
            if (windgetOpen)
            {
                windgetOpen = false;
                settingsWidget.Dispose();
                settingsWidget = null;
                button_Widget.BackgroundImage = Properties.Resources.buttonWidget;
            }
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            label1.Focus();
            Application.Exit();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseWindowX = e.X + 1;
            mouseWindowY = e.Y + 1;
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
            Location = new Point(Cursor.Position.X - mouseWindowX, Cursor.Position.Y - mouseWindowY);
            if (windgetOpen)
            {
                settingsWidget.Location = new Point(Left, Top - settingsWidget.Size.Height);
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void pressButtonEvent(Button button, Bitmap bg, EventHandler nenter, EventHandler mleave)
        {
            button.Enabled = false;
            button.MouseEnter -= nenter;
            button.MouseLeave -= mleave;
            button.BackgroundImage = bg;
        }
        private void unPressButtonEvent(Button button, Bitmap bg, EventHandler nenter, EventHandler mleave)
        {
            button.Enabled = true;
            button.MouseEnter += nenter;
            button.MouseLeave += mleave;
            button.BackgroundImage = bg;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public void setLangTranslateRU()
        {
            alreadyExists = "Файл уже существует: ";
            button_ClearDirectory.Text = "Очистка";
            button_GameDirectory.Text = "Директория Игры";
            button_Mods.Text = "Моды";
            button_MyDocs.Text = "Мои Документы";
            button_Options.Text = "Настройки Игры";
            button_ProgrammsFolder.Text = "Все Программы";
            button_RemPrograms.Text = "Программы";
            button_ResetSettings.Text = "Сброс Настроек";
            clearDirectory = "Очистить директорию?";
            confirmTitle = "Подтверждение";
            couldNotDelete = "Не удалось удалить: ";
            couldNotMove = "Не удалось переместить: ";
            couldRun = "Не удалось запустить файл: ";
            couldUnpack = "Не найден UnRAR.exe или архив: ";
            couldWriteFile = "Не удалось записать файл: ";
            failWriteToRegistry = "Не удалось записать путь в реест: ";
            failedCopy = "Не удалось скопировать: ";
            failedCreate = "Не удалось создать папку: ";
            noIniFound = "Файлы настроек Skyrim не сформированы. Сделайте сброс настроек.";
            notFound = " не найден(а).";
            notFoundTemplates = "Нет шаблонов конфигурационных файлов для сброса настроек.";
            notInDirectory = "Выбран(ы) объект(ы) вне директории игры.";
            setSettings = " настройки установлены.";
            settingsReset = "Сбросить настройки?";
            toolTip1.SetToolTip(button_AddFileToIgnore, "Добавление файла(ов) в шаблон игнор листа.");
            toolTip1.SetToolTip(button_AddFolderToIgnore, "Добавление папки в шаблон игнор листа.");
            toolTip1.SetToolTip(button_ClearDirectory, "Удаляет \"чужие\" файлы. В т.ч. распакованные программы.");
            toolTip1.SetToolTip(button_DSRStart, "Патчер Dual Sheath Redux. Применять после изменения модов содержащих оружие.");
            toolTip1.SetToolTip(button_ENBmenu, "Меню управления ENB с выбором различных пресетов.");
            toolTip1.SetToolTip(button_FNISStart, "Патчер FNIS. Применять после изменения модов содержащих анимации.");
            toolTip1.SetToolTip(button_GameDirectory, "Открывает папку-директорию игры.");
            toolTip1.SetToolTip(button_Mods, "Установка опциональных модов.");
            toolTip1.SetToolTip(button_MyDocs, "Открывает папку с ini файлами и сохранениями.");
            toolTip1.SetToolTip(button_Options, "Настройка конфигурации, параметров игры, управление подключаемыми файлами.");
            toolTip1.SetToolTip(button_ProgrammsFolder, "Открывает папку с ярлыками программ для редактирования игры.");
            toolTip1.SetToolTip(button_RemPrograms, "Распаковка различных программ для редактирования игры.");
            toolTip1.SetToolTip(button_ResetSettings, "Полный сброс настроек игры и восстановление последовательности модов.");
            toolTip1.SetToolTip(button_Skyrim, "Запустить игру.");
            toolTip1.SetToolTip(button_WryeBash, "Сортировщик модов. Моды имеющие конфликты будут красными.");
            typeSettings = new string[] { "Низкие", "Средние", "Высокие", "Ультра" };
            unPackFNIS = @"Распаковать стандартные файлы FNIS из архива:" + Environment.NewLine + pathFNISRAR;
        }
        public void setLangTranslateEN()
        {
            alreadyExists = "File already exists: ";
            button_ClearDirectory.Text = "Clear";
            button_GameDirectory.Text = "Game Directory";
            button_Mods.Text = "Mods";
            button_MyDocs.Text = "My Documents";
            button_Options.Text = "Game Settings";
            button_ProgrammsFolder.Text = "All Programs";
            button_RemPrograms.Text = "Programs";
            button_ResetSettings.Text = "Reset Settings";
            clearDirectory = "Clear directory?";
            confirmTitle = "Confirm";
            couldNotDelete = "Could not delete: ";
            couldNotMove = "Failed to move: ";
            couldRun = "Could not launch file: ";
            couldUnpack = "UnRAR.exe not found or arhive: ";
            couldWriteFile = "Could not write file: ";
            failWriteToRegistry = "Could not write path to the registry: ";
            failedCopy = "Could not copy: ";
            failedCreate = "Could not create folder: ";
            noIniFound = "Skyrim configuration files are not generated. Reset the settings.";
            notFound = " not found.";
            notFoundTemplates = "No configuration file templates for resetting settings.";
            notInDirectory = "Selected object(s) outside the game directory.";
            setSettings = " settings are set.";
            settingsReset = "Reset settings?";
            toolTip1.SetToolTip(button_AddFileToIgnore, "Adding a file(s) to the ignore list template.");
            toolTip1.SetToolTip(button_AddFolderToIgnore, "Adding a folder to the ignore list template.");
            toolTip1.SetToolTip(button_ClearDirectory, "Delete \"strangers\" files. Including unpacked programs.");
            toolTip1.SetToolTip(button_DSRStart, "Patcher Dual Sheath Redux. Apply after the change in the mods containing the weapons.");
            toolTip1.SetToolTip(button_ENBmenu, "The ENB control menu with a selection of different presets.");
            toolTip1.SetToolTip(button_FNISStart, "Patcher FNIS. Apply after the change in the mods containing the animation.");
            toolTip1.SetToolTip(button_GameDirectory, "Opens folder-directory of the game.");
            toolTip1.SetToolTip(button_Mods, "Installing optional mods.");
            toolTip1.SetToolTip(button_MyDocs, "Opens a folder with ini files and saves.");
            toolTip1.SetToolTip(button_Options, "Configuring the configuration, game settings, managing the connected files.");
            toolTip1.SetToolTip(button_ProgrammsFolder, "Opens a folder with shortcuts for editing games.");
            toolTip1.SetToolTip(button_RemPrograms, "Unpacking various programs for editing games.");
            toolTip1.SetToolTip(button_ResetSettings, "Full reset of game settings and recovery of a sequence of mods.");
            toolTip1.SetToolTip(button_Skyrim, "Start the game.");
            toolTip1.SetToolTip(button_WryeBash, "Mods sorter. Mods having conflicts will be red.");
            typeSettings = new string[] { "Low", "Medium", "Hight", "Ultra" };
            unPackFNIS = "Unpack the standard FNIS files from the archive:" + Environment.NewLine + pathFNISRAR;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
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
                FuncMisc.textColor(this, System.Drawing.SystemColors.ControlText, System.Drawing.Color.FromArgb(232, 232, 232), true);
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
                FuncMisc.textColor(this, System.Drawing.SystemColors.ControlLight, System.Drawing.Color.FromArgb(30, 30, 30), true);
            }
            if (button_Skyrim.Enabled == true)
            {
                button_Skyrim.BackgroundImage = BMbuttonlogo;
            }
            else
            {
                button_Skyrim.BackgroundImage = BMbuttonlogoPressed;
            }
            if (button_WryeBash.Enabled == true)
            {
                button_WryeBash.BackgroundImage = BMbuttonFull;
            }
            else
            {
                button_WryeBash.BackgroundImage = BMbuttonFullPressed;
            }
            if (button_DSRStart.Enabled == true)
            {
                button_DSRStart.BackgroundImage = BMbuttonHalf;
            }
            else
            {
                button_DSRStart.BackgroundImage = BMbuttonHalfPressed;
            }
            if (button_FNISStart.Enabled == true)
            {
                button_FNISStart.BackgroundImage = BMbuttonHalf;
            }
            else
            {
                button_FNISStart.BackgroundImage = BMbuttonHalfPressed;
            }
            button_ProgrammsFolder.BackgroundImage = BMbuttonFull;
            button_GameDirectory.BackgroundImage = BMbuttonFull;
            button_ResetSettings.BackgroundImage = BMbuttonFull;
            button_ClearDirectory.BackgroundImage = BMbuttonClear;
            button_AddFolderToIgnore.BackgroundImage = BMbuttonOne;
            button_AddFileToIgnore.BackgroundImage = BMbuttonOne;
            button_Mods.BackgroundImage = BMbuttonHalf;
            button_MyDocs.BackgroundImage = BMbuttonFull;
            button_RemPrograms.BackgroundImage = BMbuttonFull;
            button_ENBmenu.BackgroundImage = BMbuttonHalf;
            button_Options.BackgroundImage = BMbuttonFull;
            BackgroundImage = BMBackgroundImage;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = BMbuttonFullGlow;
        }
        private void button_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = BMbuttonFull;
        }
        private void buttonH_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = BMbuttonHalfGlow;
        }
        private void buttonH_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = BMbuttonHalf;
        }
        private void buttonAdd_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = BMbuttonOneGlow;
        }
        private void buttonAdd_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = BMbuttonOne;
        }
        private void buttonSkyrim_MouseEnter(object sender, EventArgs e)
        {
            button_Skyrim.BackgroundImage = BMbuttonlogoGlow;
        }
        private void buttonSkyrim_MouseLeave(object sender, EventArgs e)
        {
            button_Skyrim.BackgroundImage = BMbuttonlogo;
        }
        private void buttonClearDirectory_MouseEnter(object sender, EventArgs e)
        {
            button_ClearDirectory.BackgroundImage = BMbuttonClearGlow;
        }
        private void buttonClearDirectory_MouseLeave(object sender, EventArgs e)
        {
            button_ClearDirectory.BackgroundImage = BMbuttonClear;
        }
        private void buttonHelp_MouseEnter(object sender, EventArgs e)
        {
            button_Help.BackgroundImage = Properties.Resources.buttonHelpGlow;
        }
        private void buttonHelp_MouseLeave(object sender, EventArgs e)
        {
            button_Help.BackgroundImage = Properties.Resources.buttonHelp;
        }
        private void buttonWidget_MouseEnter(object sender, EventArgs e)
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
        private void buttonWidget_MouseLeave(object sender, EventArgs e)
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
        private void buttonMinimize_MouseEnter(object sender, EventArgs e)
        {
            button_Minimize.BackgroundImage = Properties.Resources.buttonMinimizeGlow;
        }
        private void buttonMinimize_MouseLeave(object sender, EventArgs e)
        {
            button_Minimize.BackgroundImage = Properties.Resources.buttonMinimize;
        }
        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            button_Close.BackgroundImage = Properties.Resources.buttonCloseGlow;
        }
        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            button_Close.BackgroundImage = Properties.Resources.buttonClose;
        }
    }
}