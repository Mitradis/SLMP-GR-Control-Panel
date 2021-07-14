using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public partial class FormOptions : Form
    {
        string pathMyDocLogs = FuncFiles.pathAddSlash(FormMain.pathMyDoc + "Logs") + "Script";
        public static List<int> screenListW = new List<int>();
        public static List<int> screenListH = new List<int>();
        List<List<string>> masterFiles = new List<List<string>>();
        List<string> ignoreNames = new List<string>() { "Skyrim.esm", "Update.esm", "Dawnguard.esm", "HearthFires.esm", "Dragonborn.esm" };
        string pathToPlugins = FormMain.pathAppData + "Plugins.txt";
        string pathToLoader = FormMain.pathAppData + "LoadOrder.txt";
        string textDateChange = "Не удалось изменить дату изменения файла: ";
        string textGrassDensity = "iMinGrassSize - расстояние между кустами травы, меньше - плотнее.";
        string textMaxFPS = "fMaxTime - отвечает за поведение физики в игре при разном FPS.";
        string textNearDistance = "Меньше - сильнее мерцания. Больше - больше отсечения объектов вблизи.";
        string textRedateMods = "Массовое изменение даты изменения файлов по возрастанию.";
        string textShadowResolution = "iShadowMapResolution - \"тяжелый\" параметр теней.";
        string textZFighting = "Уменьшает мерцание гор вдали.";
        string selectedScreen = null;
        int nextESMIndex = 0;
        bool blockRefreshList = true;
        bool fxaa = false;
        bool goodAllMasters = true;
        bool hideobjects = false;
        bool papyrus = false;
        bool rland = false;
        bool robj = false;
        bool rsky = false;
        bool rtree = false;
        bool startMoveItem = false;
        bool vsync = false;
        bool window = false;
        bool zfighting = false;
        ListViewItem itemStartMove = null;
        Screen[] screens = Screen.AllScreens;
        DateTime lastWriteData = Directory.GetLastWriteTime(FormMain.pathDataFolder);

        public FormOptions()
        {
            InitializeComponent();
            FuncMisc.setFormFont(this);
            if (FormMain.numberStyle > 1)
            {
                imageBackgroundImage();
            }
            if (FormMain.langTranslate == "EN")
            {
                langTranslateEN();
            }
            toolTip1.SetToolTip(label15TAB, textShadowResolution);
            toolTip1.SetToolTip(comboBox_ShadowTAB, textShadowResolution);
            toolTip1.SetToolTip(label25TAB, textGrassDensity);
            toolTip1.SetToolTip(label26TAB, textGrassDensity);
            toolTip1.SetToolTip(trackBar_GrassDensityTAB, textGrassDensity);
            toolTip1.SetToolTip(button_RedateMods, textRedateMods);
            toolTip1.SetToolTip(label3, textMaxFPS);
            toolTip1.SetToolTip(numericUpDown1, textMaxFPS);
            toolTip1.SetToolTip(label4, textZFighting);
            toolTip1.SetToolTip(button_ZFighting, textZFighting);
            toolTip1.SetToolTip(comboBox_ZFighting, textNearDistance);
            refreshScreenIndex();
            refreshScreenResolution();
            refreshSettings();
            refreshModsList();
            timer2.Enabled = true;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            FuncMisc.textColor(this, SystemColors.ControlLight, Color.FromArgb(25, 25, 25), false);
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (lastWriteData != Directory.GetLastWriteTime(FormMain.pathDataFolder))
            {
                timer2.Enabled = false;
                refreshModsList();
                timer2.Enabled = true;
                lastWriteData = Directory.GetLastWriteTime(FormMain.pathDataFolder);
            }
        }
        private void langTranslateEN()
        {
            button_ActivatedAll.Text = "Enable all";
            button_Common.Text = "Common";
            button_Distance.Text = "Distances";
            button_Hight.Text = "Hight";
            button_LogsFolder.Text = "Logs folder";
            button_Low.Text = "Low";
            button_Medium.Text = "Medium";
            button_RedateMods.Text = "Redate mods";
            button_Restore.Text = "Restore";
            button_Ultra.Text = "Ultra";
            comboBox_DecalsTAB.Items.Clear();
            comboBox_DecalsTAB.Items.AddRange(new object[] { "No", "Medium", "Hight", "Ultra" });
            comboBox_LODObjectsTAB.Items.Clear();
            comboBox_LODObjectsTAB.Items.AddRange(new object[] { "Low", "Medium", "Hight", "Ultra" });
            comboBox_TexturesTAB.Items.Clear();
            comboBox_TexturesTAB.Items.AddRange(new object[] { "Hight", "Medium", "Low" });
            filesName.Text = "Files:";
            label9TAB.Text = "Resolution:";
            label16TAB.Text = "Water reflections:";
            label11TAB.Text = "Antialiasing:";
            label12TAB.Text = "Filtration:";
            label13TAB.Text = "Textures quality:";
            label38TAB.Text = "Shadow:";
            label15TAB.Text = "Shadow resolution:";
            label14TAB.Text = "Decals:";
            label23TAB.Text = "Window:";
            label2.Text = "Presets";
            label25TAB.Text = "Grass density:";
            label17TAB.Text = "Sky:";
            label18TAB.Text = "Landscape:";
            label19TAB.Text = "Objects:";
            label20TAB.Text = "Trees:";
            label27TAB.Text = "Objects:";
            label34TAB.Text = "Items:";
            label7.Text = "Mods On/All:";
            label29TAB.Text = "Characters:";
            label36TAB.Text = "Grass:";
            label31TAB.Text = "Lighting:";
            label33TAB.Text = "Far objects:";
            label40TAB.Text = "Objects details fade:";
            label10TAB.Text = "Display index:";
            label3.Text = "Max FPS:";
            label21TAB.Text = "Resolution:";
            label6.Text = "Master files:";
            label5.Text = "Papyrus logs:";
            textDateChange = "Could not change the date the file was modified: ";
            textGrassDensity = "iMinGrassSize - distance between the grass bushes, smaller - denser.";
            textNearDistance = "Less - stronger flickering of mountains. Larger - stronger clipping textures near objects.";
            textMaxFPS = "fMaxTime - responsible for the correct operation of the game with different FPS.";
            textRedateMods = "Mass change of the date of change of files in ascending order.";
            textShadowResolution = "iShadowMapResolution - \"heaviest\" shadow parameter.";
            textZFighting = "Reduces the flickering of mountains away.";
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void refreshSettings()
        {
            refreshAF();
            refreshActors();
            refreshDecals();
            refreshFXAA();
            refreshGrass();
            refreshGrassDistance();
            refreshHideObjects();
            refreshItems();
            refreshLODObjects();
            refreshLights();
            refreshObjects();
            refreshPapyrus();
            refreshMaxFPS();
            refreshShadow();
            refreshShadowRange();
            refreshTextures();
            refreshVsync();
            refreshWaterReflect();
            refreshWaterReflectLand();
            refreshWaterReflectObjects();
            refreshWaterReflectSky();
            refreshWaterReflectTrees();
            refreshWindow();
            refreshZFighting();
            refreshZFightingCB();
            FuncSettings.checkENB();
            refreshAA();
            comboBox_AATAB.Enabled = FormMain.setupENB < 2;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            itemStartMove = GetItemFromPoint(listView1, Cursor.Position);
            if (!blockRefreshList && itemStartMove != null && !ignoreNames.Exists(s => s.Equals(itemStartMove.Text, StringComparison.OrdinalIgnoreCase)))
            {
                startMoveItem = true;
                timer1.Enabled = true;
            }
        }
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (startMoveItem)
            {
                startMoveItem = false;
                timer1.Enabled = false;
                listView1.Cursor = Cursors.Default;
                ListViewItem itemEndMove = GetItemFromPoint(listView1, Cursor.Position);
                if (itemEndMove != null && itemEndMove != itemStartMove && itemEndMove.Index >= ignoreNames.Count - 1)
                {
                    blockRefreshList = true;
                    masterFiles.Insert(itemEndMove.Index + 1, masterFiles[itemStartMove.Index]);
                    masterFiles.RemoveAt(itemStartMove.Index);
                    listView1.Items.Remove(itemStartMove);
                    listView1.Items.Insert(itemEndMove.Index + 1, itemStartMove);
                    scanAllMods();
                    writeMasterFile();
                    blockRefreshList = false;
                }
                itemStartMove = null;
            }
        }
        private void listView1_MouseLeave(object sender, EventArgs e)
        {
            if (startMoveItem)
            {
                startMoveItem = false;
                timer1.Enabled = false;
                itemStartMove = null;
                listView1.Cursor = Cursors.Default;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (startMoveItem)
            {
                if (itemStartMove != GetItemFromPoint(listView1, Cursor.Position))
                {
                    listView1.Cursor = Cursors.NoMoveVert;
                }
                else
                {
                    listView1.Cursor = Cursors.Default;
                }
            }
        }
        private ListViewItem GetItemFromPoint(ListView listView, Point mousePosition)
        {
            Point localPoint = listView.PointToClient(mousePosition);
            return listView.GetItemAt(localPoint.X, localPoint.Y);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item.Index != -1)
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(masterFiles[e.Item.Index].ToArray());
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!blockRefreshList)
            {
                blockRefreshList = true;
                goodAllMasters = true;
                bool fail = false;
                if (e.Item.Checked)
                {
                    checkItem(e.Item, true);
                }
                else if (!ignoreNames.Exists(s => s.Equals(e.Item.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    uncheckItem(e.Item.Text);
                }
                else
                {
                    fail = true;
                    e.Item.Checked = !e.Item.Checked;
                }
                if (!fail && goodAllMasters)
                {
                    setFileID();
                    writeMasterFile();
                }
                blockRefreshList = false;
            }
        }
        private void checkItem(ListViewItem item, bool check)
        {
            int lastIndex = -1;
            bool goodSort = false;
            bool hasMasters = false;
            foreach (string line in masterFiles[item.Index])
            {
                hasMasters = true;
                ListViewItem findItem = listView1.FindItemWithText(line);
                if (findItem != null && findItem.Index > lastIndex && item.Index > findItem.Index)
                {
                    if (!findItem.Checked && check)
                    {
                        checkItem(findItem, true);
                    }
                    lastIndex = findItem.Index;
                    goodSort = true;
                }
                else
                {
                    goodSort = false;
                    goodAllMasters = false;
                    break;
                }
            }
            if (!hasMasters)
            {
                goodSort = true;
            }
            if (!goodSort)
            {
                item.ForeColor = Color.Red;
            }
            else if (item.Text.EndsWith(".esm", StringComparison.OrdinalIgnoreCase) || FuncParser.checkESM(FormMain.pathDataFolder + item.Text))
            {
                item.ForeColor = Color.Blue;
            }
            else
            {
                item.ForeColor = Color.Black;
            }
            if (check)
            {
                item.Checked = goodAllMasters;
            }
        }
        private void uncheckItem(string item)
        {
            int count = listView1.Items.Count;
            for (int i = 0; i < count; i++)
            {
                foreach (string line in masterFiles[i])
                {
                    if (string.Equals(line, item, StringComparison.OrdinalIgnoreCase))
                    {
                        listView1.Items[i].Checked = false;
                        uncheckItem(listView1.Items[i].Text);
                    }
                }
            }
        }
        private void scanAllMods()
        {
            foreach (ListViewItem item in listView1.Items)
            {
                goodAllMasters = true;
                checkItem(item, item.Checked);
            }
            setFileID();
        }
        private void setFileID()
        {
            int fileID = 0;
            int count = listView1.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (listView1.Items[i].Checked)
                {
                    listView1.Items[i].SubItems[1].Text = BitConverter.ToString(BitConverter.GetBytes(fileID), 0, 1);
                    fileID++;
                }
                else
                {
                    listView1.Items[i].SubItems[1].Text = "";
                }
            }
        }
        private void refreshModsList()
        {
            blockRefreshList = true;
            listView1.Items.Clear();
            listBox1.Items.Clear();
            masterFiles.Clear();
            nextESMIndex = 0;
            if (File.Exists(pathToPlugins) && File.Exists(pathToLoader) && Directory.Exists(FormMain.pathDataFolder))
            {
                List<string> pluginsList = new List<string>(File.ReadAllLines(pathToPlugins));
                List<string> loaderList = new List<string>(File.ReadAllLines(pathToLoader));
                List<string> mergedList = new List<string>(pluginsList);
                List<string> dataESFiles = new List<string>();
                int count = loaderList.Count;
                for (int i = 0; i < count; i++)
                {
                    if (!mergedList.Exists(s => s.Equals(loaderList[i], StringComparison.OrdinalIgnoreCase)))
                    {
                        if (mergedList.Count > i)
                        {
                            mergedList.Insert(i, loaderList[i]);
                        }
                        else
                        {
                            mergedList.Add(loaderList[i]);
                        }
                    }
                }
                foreach (string line in Directory.EnumerateFiles(FormMain.pathDataFolder, "*.esm"))
                {
                    string file = Path.GetFileName(line);
                    if (!ignoreNames.Exists(s => s.Equals(file, StringComparison.OrdinalIgnoreCase)))
                    {
                        dataESFiles.Add(file);
                    }
                }
                foreach (string line in Directory.EnumerateFiles(FormMain.pathDataFolder, "*.esp"))
                {
                    dataESFiles.Add(Path.GetFileName(line));
                }
                foreach (string line in ignoreNames)
                {
                    if (File.Exists(FormMain.pathDataFolder + line))
                    {
                        addToListView(line, true);
                    }
                }
                foreach (string line in mergedList)
                {
                    if (dataESFiles.Exists(s => s.Equals(line, StringComparison.OrdinalIgnoreCase)))
                    {
                        if (pluginsList.Exists(s => s.Equals(line, StringComparison.OrdinalIgnoreCase)))
                        {
                            addToListView(Path.GetFileName(FormMain.pathDataFolder + line), true);
                        }
                        else
                        {
                            addToListView(Path.GetFileName(FormMain.pathDataFolder + line), false);
                        }
                    }
                }
                foreach (string line in dataESFiles)
                {
                    if (!loaderList.Exists(s => s.Equals(line, StringComparison.OrdinalIgnoreCase)) && !pluginsList.Exists(s => s.Equals(line, StringComparison.OrdinalIgnoreCase)))
                    {
                        addToListView(line, false);
                    }
                }
                pluginsList = null;
                loaderList = null;
                mergedList = null;
                dataESFiles = null;
                scanAllMods();
                writeMasterFile();
            }
            blockRefreshList = false;
        }
        private void addToListView(string line, bool check)
        {
            ListViewItem item = new ListViewItem();
            item.Text = line;
            item.Checked = check;
            item.SubItems.Add("");
            if (!listView1.Items.Contains(item))
            {
                if (line.EndsWith(".esm", StringComparison.OrdinalIgnoreCase) || FuncParser.checkESM(FormMain.pathDataFolder + line))
                {
                    masterFiles.Insert(nextESMIndex, FuncParser.parserESPESM(FormMain.pathDataFolder + line));
                    listView1.Items.Insert(nextESMIndex, item);
                    nextESMIndex++;
                }
                else
                {
                    masterFiles.Add(FuncParser.parserESPESM(FormMain.pathDataFolder + line));
                    listView1.Items.Add(item);
                }
            }
        }
        private void writeMasterFile()
        {
            List<string> writeList = new List<string>();
            foreach (ListViewItem item in listView1.CheckedItems)
            {
                if (!string.Equals(item.Text, "Skyrim.esm", StringComparison.OrdinalIgnoreCase))
                {
                    writeList.Add(item.Text);
                }
            }
            FuncFiles.writeToFile(pathToPlugins, writeList);
            writeList.Clear();
            foreach (ListViewItem item in listView1.Items)
            {
                writeList.Add(item.Text);
            }
            FuncFiles.writeToFile(pathToLoader, writeList);
            writeList = null;
            label8.Text = listView1.CheckedItems.Count.ToString() + " / " + listView1.Items.Count.ToString();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_ActivatedAll_Click(object sender, EventArgs e)
        {
            blockRefreshList = true;
            foreach (ListViewItem item in listView1.Items)
            {
                if (!item.Checked)
                {
                    checkItem(item, true);
                }
            }
            setFileID();
            writeMasterFile();
            blockRefreshList = false;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_Restore_Click(object sender, EventArgs e)
        {
            FuncFiles.deleteAny(FormMain.pathAppData + "Plugins.txt");
            FuncFiles.deleteAny(FormMain.pathAppData + "LoadOrder.txt");
            if (File.Exists(FormMain.pathLauncherFolder + "Plugins.txt"))
            {
                FuncFiles.copyAny(FormMain.pathLauncherFolder + "Plugins.txt", FormMain.pathAppData + "Plugins.txt");
                FuncFiles.copyAny(FormMain.pathLauncherFolder + "Plugins.txt", FormMain.pathAppData + "LoadOrder.txt");
            }
            else
            {
                FuncFiles.writeToFile(FormMain.pathAppData + "Plugins.txt", FuncSettings.pluginsTXT());
                FuncFiles.writeToFile(FormMain.pathAppData + "LoadOrder.txt", FuncSettings.pluginsTXT());
            }
            refreshModsList();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_RedateMods_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                DateTime dt = new DateTime(2021, 1, 1, 12, 0, 0, DateTimeKind.Local);
                foreach (string line in Directory.EnumerateFiles(FormMain.pathDataFolder, "*.bsa"))
                {
                    try
                    {
                        File.SetLastWriteTime(line, dt);
                    }
                    catch
                    {
                        MessageBox.Show(textDateChange + line);
                    }
                }
                foreach (ListViewItem item in listView1.CheckedItems)
                {
                    try
                    {
                        File.SetLastWriteTime(FormMain.pathDataFolder + item.Text, dt);
                    }
                    catch
                    {
                        MessageBox.Show(textDateChange + FormMain.pathDataFolder + item.Text);
                    }
                    dt = dt.AddMinutes(1);
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_Low_Click(object sender, EventArgs e)
        {
            FuncSettings.setSettingsPreset(0);
            refreshSettings();
        }
        private void button_Medium_Click(object sender, EventArgs e)
        {
            FuncSettings.setSettingsPreset(1);
            refreshSettings();
        }
        private void button_Hight_Click(object sender, EventArgs e)
        {
            FuncSettings.setSettingsPreset(2);
            refreshSettings();
        }
        private void button_Ultra_Click(object sender, EventArgs e)
        {
            FuncSettings.setSettingsPreset(3);
            refreshSettings();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void comboBox_ResolutionTAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iSize W", screenListW[comboBox_ResolutionTAB.SelectedIndex].ToString());
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iSize H", screenListH[comboBox_ResolutionTAB.SelectedIndex].ToString());
            aspectRatioFiles();
        }
        private void refreshScreenResolution()
        {
            screenListW.Clear();
            screenListH.Clear();
            comboBox_ResolutionTAB.Items.Clear();
            FuncResolutions.Resolutions(selectedScreen);
            if (screenListW.Count == screenListH.Count && screenListW.Count > 0)
            {
                int count = screenListW.Count;
                for (int i = 0; i < count; i++)
                {
                    comboBox_ResolutionTAB.Items.Add(screenListW[i].ToString() + " x " + screenListH[i].ToString());
                }
            }
            comboBox_ResolutionTAB.SelectedIndexChanged -= comboBox_ResolutionTAB_SelectedIndexChanged;
            comboBox_ResolutionTAB.SelectedIndex = comboBox_ResolutionTAB.Items.IndexOf(FuncParser.stringRead(FormMain.pathSkyrimPrefsINI, "Display", "iSize W") + " x " + FuncParser.stringRead(FormMain.pathSkyrimPrefsINI, "Display", "iSize H"));
            comboBox_ResolutionTAB.SelectedIndexChanged += comboBox_ResolutionTAB_SelectedIndexChanged;
            aspectRatioFiles();
        }
        private void aspectRatioFiles()
        {
            if (comboBox_ResolutionTAB.SelectedIndex != -1)
            {
                FuncMisc.setAspectRatio(screenListW[comboBox_ResolutionTAB.SelectedIndex], screenListH[comboBox_ResolutionTAB.SelectedIndex]);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void comboBox_ScreenTAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Display", "iAdapter", comboBox_ScreenTAB.SelectedIndex.ToString());
            selectedScreen = screens[comboBox_ScreenTAB.SelectedIndex].DeviceName;
            refreshScreenResolution();
            FuncSettings.restoreENBAdapter();
        }
        private void refreshScreenIndex()
        {
            comboBox_ScreenTAB.Items.Clear();
            if (screens.Length > 0)
            {
                int count = screens.Length;
                for (int i = 0; i < count; i++)
                {
                    comboBox_ScreenTAB.Items.Add(i.ToString());
                }
                int value = FuncParser.intRead(FormMain.pathSkyrimINI, "Display", "iAdapter");
                if (value >= 0 && value < comboBox_ScreenTAB.Items.Count)
                {
                    comboBox_ScreenTAB.SelectedIndexChanged -= comboBox_ScreenTAB_SelectedIndexChanged;
                    comboBox_ScreenTAB.SelectedIndex = value;
                    selectedScreen = screens[value].DeviceName;
                    comboBox_ScreenTAB.SelectedIndexChanged += comboBox_ScreenTAB_SelectedIndexChanged;
                }
                FuncSettings.restoreENBAdapter();
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void comboBox_AATAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iMultiSample", comboBox_AATAB.SelectedItem.ToString());
        }
        private void refreshAA()
        {
            FuncMisc.refreshComboBox(comboBox_AATAB, new double[] { 0, 2, 4, 8 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Display", "iMultiSample"), false, comboBox_AATAB_SelectedIndexChanged);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void comboBox_AFTAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iMaxAnisotropy", comboBox_AFTAB.SelectedItem.ToString());
            if (File.Exists(FormMain.pathENBLocalINI))
            {
                FuncParser.iniWrite(FormMain.pathENBLocalINI, "ENGINE", "MaxAnisotropy", comboBox_AFTAB.SelectedItem.ToString());
            }
        }
        private void refreshAF()
        {
            FuncMisc.refreshComboBox(comboBox_AFTAB, new double[] { 0, 2, 4, 8, 16 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Display", "iMaxAnisotropy"), false, comboBox_AFTAB_SelectedIndexChanged);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void comboBox_ShadowTAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iShadowMapResolution", comboBox_ShadowTAB.SelectedItem.ToString());
        }
        private void refreshShadow()
        {
            FuncMisc.refreshComboBox(comboBox_ShadowTAB, new double[] { 512, 1024, 2048, 4096 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Display", "iShadowMapResolution"), false, comboBox_ShadowTAB_SelectedIndexChanged);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void comboBox_TexturesTAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iTexMipMapSkip", comboBox_TexturesTAB.SelectedIndex.ToString());
        }
        private void refreshTextures()
        {
            FuncMisc.refreshComboBox(comboBox_TexturesTAB, new double[] { 0, 1, 2 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Display", "iTexMipMapSkip"), false, comboBox_TexturesTAB_SelectedIndexChanged);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void comboBox_DecalsTAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_DecalsTAB.SelectedIndex == 0)
            {
                setDecals("0", "0", "0", "0.0000", "0");
            }
            else if (comboBox_DecalsTAB.SelectedIndex == 1)
            {
                setDecals("1", "3", "30", "30.0000", "35");
            }
            else if (comboBox_DecalsTAB.SelectedIndex == 2)
            {
                setDecals("1", "5", "50", "60.0000", "55");
            }
            else if (comboBox_DecalsTAB.SelectedIndex == 3)
            {
                setDecals("1", "7", "70", "90.0000", "75");
            }
        }
        private void setDecals(string bDecals, string uMaxSkinDecalPerActor, string uMaxSkinDecals, string fDecalLifetime, string iMaxSkinDecalsPerFrame)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Decals", "bDecals", bDecals);
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Decals", "uMaxSkinDecalPerActor", uMaxSkinDecalPerActor);
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Decals", "uMaxSkinDecals", uMaxSkinDecals);
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Display", "fDecalLifetime", fDecalLifetime);
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iMaxSkinDecalsPerFrame", iMaxSkinDecalsPerFrame);
        }
        private void refreshDecals()
        {
            FuncMisc.refreshComboBox(comboBox_DecalsTAB, new double[] { 0, 35, 55, 75 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Display", "iMaxSkinDecalsPerFrame"), false, comboBox_DecalsTAB_SelectedIndexChanged);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void comboBox_LODObjectsTAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_LODObjectsTAB.SelectedIndex == 0)
            {
                setLODObjects("12500.0000", "75000.0000", "25000.0000", "15000.0000", "0.4000", "3500.0000", "50000.0000");
            }
            else if (comboBox_LODObjectsTAB.SelectedIndex == 1)
            {
                setLODObjects("25000.0000", "100000.0000", "32768.0000", "20480.0000", "0.7500", "4000.0000", "150000.0000");
            }
            else if (comboBox_LODObjectsTAB.SelectedIndex == 2)
            {
                setLODObjects("40000.0000", "150000.0000", "40000.0000", "25000.0000", "1.1000", "5000.0000", "300000.0000");
            }
            else if (comboBox_LODObjectsTAB.SelectedIndex == 3)
            {
                setLODObjects("75000.0000", "250000.0000", "70000.0000", "35000.0000", "1.5000", "16896.0000", "600000.0000");
            }
        }
        private void setLODObjects(string fTreeLoadDistance, string fBlockMaximumDistance, string fBlockLevel1Distance, string fBlockLevel0Distance, string fSplitDistanceMult, string fTreesMidLODSwitchDist, string fSkyCellRefFadeDistance)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fTreeLoadDistance", fTreeLoadDistance);
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fTreesMidLODSwitchDist", fTreesMidLODSwitchDist);
            if (!zfighting)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockMaximumDistance", fBlockMaximumDistance);
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockLevel1Distance", fBlockLevel1Distance);
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockLevel0Distance", fBlockLevel0Distance);
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fSplitDistanceMult", fSplitDistanceMult);
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "MAIN", "fSkyCellRefFadeDistance", fSkyCellRefFadeDistance);
            }
        }
        private void refreshLODObjects()
        {
            FuncMisc.refreshComboBox(comboBox_LODObjectsTAB, new double[] { 12500, 25000, 40000, 75000 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fTreeLoadDistance"), false, comboBox_LODObjectsTAB_SelectedIndexChanged);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            FormMain.maxFPS = numericUpDown1.Value;
            FuncSettings.physicsFPS();
        }
        private void refreshMaxFPS()
        {
            numericUpDown1.Value = FormMain.maxFPS;
            FuncSettings.physicsFPS();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void comboBox_WaterReflectTAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Water", "iWaterReflectWidth", comboBox_WaterReflectTAB.SelectedItem.ToString());
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Water", "iWaterReflectHeight", comboBox_WaterReflectTAB.SelectedItem.ToString());
        }
        private void refreshWaterReflect()
        {
            FuncMisc.refreshComboBox(comboBox_WaterReflectTAB, new double[] { 512, 1024, 2048 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Water", "iWaterReflectWidth"), false, comboBox_WaterReflectTAB_SelectedIndexChanged);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void comboBox_ZFighting_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Display", "fNearDistance", comboBox_ZFighting.SelectedItem.ToString() + ".0000");
            FuncParser.iniWrite(FormMain.pathLauncherINI, "Game", "NearDistance", comboBox_ZFighting.SelectedItem.ToString());
        }
        private void refreshZFightingCB()
        {
            FuncMisc.refreshComboBox(comboBox_ZFighting, new double[] { 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, FuncParser.intRead(FormMain.pathSkyrimINI, "Display", "fNearDistance"), false, comboBox_ZFighting_SelectedIndexChanged);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_ZFighting_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathLauncherINI, "Game", "ZFighting", (!zfighting).ToString().ToLower());
            refreshZFighting();
            if (!zfighting)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimINI, "Display", "fNearDistance", "15.0000");
                comboBox_LODObjectsTAB_SelectedIndexChanged(this, new EventArgs());
                refreshZFightingCB();
            }
        }
        private void refreshZFighting()
        {
            zfighting = FuncMisc.refreshButton(button_ZFighting, FormMain.pathLauncherINI, "Game", "ZFighting", null, false);
            comboBox_ZFighting.Enabled = zfighting;
            if (zfighting)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimINI, "Display", "fNearDistance", FuncParser.stringRead(FormMain.pathLauncherINI, "Game", "NearDistance") + ".0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Terrainmanager", "fBlockMaximumDistance", "500000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Terrainmanager", "fBlockLevel1Distance", "140000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Terrainmanager", "fBlockLevel0Distance", "75000.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Terrainmanager", "fSplitDistanceMult", "4.0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "MAIN", "fSkyCellRefFadeDistance", "600000.0000");
                refreshZFightingCB();
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_Papyrus_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Papyrus", "bEnableLogging", Convert.ToInt32(!papyrus).ToString());
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Papyrus", "bEnableTrace", Convert.ToInt32(!papyrus).ToString());
            refreshPapyrus();
        }
        private void refreshPapyrus()
        {
            papyrus = FuncMisc.refreshButton(button_Papyrus, FormMain.pathSkyrimINI, "Papyrus", "bEnableLogging", null, false);
            if (papyrus)
            {
                FuncFiles.creatDirectory(pathMyDocLogs);
            }
        }
        private void button_LogsFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(pathMyDocLogs))
            {
                Process.Start(pathMyDocLogs);
            }
            else if (Directory.Exists(FormMain.pathMyDoc))
            {
                Process.Start(FormMain.pathMyDoc);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_ReflectSkyTAB_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Water", "bReflectSky", Convert.ToInt32(!rsky).ToString());
            refreshWaterReflectSky();
        }
        private void refreshWaterReflectSky()
        {
            rsky = FuncMisc.refreshButton(button_ReflectSkyTAB, FormMain.pathSkyrimINI, "Water", "bReflectSky", null, false);
        }
        private void button_ReflectLanscapeTAB_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Water", "bReflectLODLand", Convert.ToInt32(!rland).ToString());
            refreshWaterReflectLand();
        }
        private void refreshWaterReflectLand()
        {
            rland = FuncMisc.refreshButton(button_ReflectLanscapeTAB, FormMain.pathSkyrimINI, "Water", "bReflectLODLand", null, false);
        }
        private void button_ReflectObjectsTAB_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Water", "bReflectLODObjects", Convert.ToInt32(!robj).ToString());
            refreshWaterReflectObjects();
        }
        private void refreshWaterReflectObjects()
        {
            robj = FuncMisc.refreshButton(button_ReflectObjectsTAB, FormMain.pathSkyrimINI, "Water", "bReflectLODObjects", null, false);
        }
        private void button_ReflectTreesTAB_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Water", "bReflectLODTrees", Convert.ToInt32(!rtree).ToString());
            refreshWaterReflectTrees();
        }
        private void refreshWaterReflectTrees()
        {
            rtree = FuncMisc.refreshButton(button_ReflectTreesTAB, FormMain.pathSkyrimINI, "Water", "bReflectLODTrees", null, false);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_WindowTAB_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bFull Screen", Convert.ToInt32(window).ToString());
            refreshWindow();
        }
        private void refreshWindow()
        {
            window = FuncMisc.refreshButton(button_WindowTAB, FormMain.pathSkyrimPrefsINI, "Display", "bFull Screen", null, true);
            FuncSettings.restoreENBBorderless();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_VsyncTAB_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Display", "iPresentInterval", Convert.ToInt32(!vsync).ToString());
            refreshVsync();
        }
        private void refreshVsync()
        {
            vsync = FuncMisc.refreshButton(button_VsyncTAB, FormMain.pathSkyrimINI, "Display", "iPresentInterval", null, false);
            FuncSettings.restoreENBVSync();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_FXAATAB_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bFXAAEnabled", Convert.ToInt32(!fxaa).ToString());
            refreshFXAA();
        }
        private void refreshFXAA()
        {
            fxaa = FuncMisc.refreshButton(button_FXAATAB, FormMain.pathSkyrimPrefsINI, "Display", "bFXAAEnabled", null, false);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_HideObjectsTAB_Click(object sender, EventArgs e)
        {
            if (hideobjects)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel1FadeDist", "16896.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel2FadeDist", "16896.0000");
            }
            else
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel1FadeDist", "4096.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel2FadeDist", "3072.0000");
            }
            refreshHideObjects();
        }
        private void refreshHideObjects()
        {
            hideobjects = FuncMisc.refreshButton(button_HideObjectsTAB, FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel1FadeDist", "4096.0000", false);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void trackBar_GrassDensityTAB_Scroll(object sender, EventArgs e)
        {

            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Grass", "iMinGrassSize", (trackBar_GrassDensityTAB.Value * 5).ToString());
            label26TAB.Text = (trackBar_GrassDensityTAB.Value * 5).ToString();
        }
        private void refreshGrass()
        {
            FuncMisc.refreshTrackBar(trackBar_GrassDensityTAB, FormMain.pathSkyrimINI, "Grass", "iMinGrassSize", 5, label26TAB);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void trackBar_GrassDistanceTAB_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Grass", "fGrassStartFadeDistance", (trackBar_GrassDistanceTAB.Value * 1000).ToString());
            label37TAB.Text = (trackBar_GrassDistanceTAB.Value * 1000).ToString();
        }
        private void refreshGrassDistance()
        {
            FuncMisc.refreshTrackBar(trackBar_GrassDistanceTAB, FormMain.pathSkyrimPrefsINI, "Grass", "fGrassStartFadeDistance", 1000, label37TAB);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void trackBar_ObjectsTAB_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultObjects", (trackBar_ObjectsTAB.Value).ToString());
            label28TAB.Text = trackBar_ObjectsTAB.Value.ToString();
        }
        private void refreshObjects()
        {
            FuncMisc.refreshTrackBar(trackBar_ObjectsTAB, FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultObjects", -1, label28TAB);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void trackBar_ItemsTAB_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultItems", (trackBar_ItemsTAB.Value).ToString());
            label35TAB.Text = trackBar_ItemsTAB.Value.ToString();
        }
        private void refreshItems()
        {
            FuncMisc.refreshTrackBar(trackBar_ItemsTAB, FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultItems", -1, label35TAB);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void trackBar_ActorsTAB_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultActors", (trackBar_ActorsTAB.Value).ToString());
            label30TAB.Text = trackBar_ActorsTAB.Value.ToString();
        }
        private void refreshActors()
        {
            FuncMisc.refreshTrackBar(trackBar_ActorsTAB, FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultActors", -1, label30TAB);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void trackBar_LightsTAB_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fLightLODStartFade", (trackBar_LightsTAB.Value * 100).ToString());
            label32TAB.Text = (trackBar_LightsTAB.Value * 100).ToString();
        }
        private void refreshLights()
        {
            FuncMisc.refreshTrackBar(trackBar_LightsTAB, FormMain.pathSkyrimPrefsINI, "Display", "fLightLODStartFade", 100, label32TAB);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void trackBar_ShadowTAB_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fShadowDistance", (trackBar_ShadowTAB.Value * 500).ToString());
            label39TAB.Text = (trackBar_ShadowTAB.Value * 500).ToString();
        }
        private void refreshShadowRange()
        {
            FuncMisc.refreshTrackBar(trackBar_ShadowTAB, FormMain.pathSkyrimPrefsINI, "Display", "fShadowDistance", 500, label39TAB);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void buttons_ChangeTabs_Click(object sender, EventArgs e)
        {
            foreach (Control line in Controls)
            {
                if (line.Name.EndsWith("TAB"))
                {
                    line.Visible = !line.Visible;
                }
            }
            button_Common.Enabled = !button_Common.Enabled;
            button_Distance.Enabled = !button_Distance.Enabled;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
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