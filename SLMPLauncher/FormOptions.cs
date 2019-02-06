using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public partial class FormOptions : Form
    {
        static string pathDataFolder = FormMain.pathGameFolder + @"Data\";
        string pathToPlugins = FormMain.pathAppData + @"Plugins.txt";
        string pathToLoader = FormMain.pathAppData + @"LoadOrder.txt";
        string errorDateChange = "Не удалось изменить дату изменения файла: ";
        string grassDensity = "Расстояние между кустами травы, чем оно меньше, тем плотнее трава.";
        string nearDistance = "Меньше - сильнее мерцания гор. Больше - сильнее отсечения текстур вблизи объектов.";
        string predictFPS = "Отвечает за правильную работу игры при разном FPS.";
        string redateMods = "Массовое изменение даты изменения файлов по возрастанию.";
        string shadowResolution = "Изменение самого \"тяжелого\" параметра теней.";
        string zFighting = "Уменьшает мерцание гор вдали.";
        DateTime lastWriteData = Directory.GetLastWriteTime(pathDataFolder);
        List<string> listToListESM = new List<string>();
        List<string> listToListESP = new List<string>();
        List<int> screenListW = new List<int>();
        List<int> screenListH = new List<int>();
        ListViewItem itemStartMove = null;
        bool blockRefreshList = true;
        bool goodAllMasters = true;
        bool hideobjects = false;
        bool startMoveItem = false;
        bool fxaa = false;
        bool papyrus = false;
        bool rland = false;
        bool robj = false;
        bool rsky = false;
        bool rtree = false;
        bool vsync = false;
        bool window = false;
        bool zfighting = false;

        public FormOptions()
        {
            InitializeComponent();
            FuncMisc.setFormFont(this);
            Directory.SetCurrentDirectory(FormMain.pathLauncherFolder);
            if (FormMain.numberStyle > 1)
            {
                imageBackgroundImage();
            }
            if (FormMain.langTranslate == "EN")
            {
                langTranslateEN();
            }
            toolTip1.SetToolTip(label16TAB, shadowResolution);
            toolTip1.SetToolTip(comboBoxShadowResTAB, shadowResolution);
            toolTip1.SetToolTip(label21TAB, grassDensity);
            toolTip1.SetToolTip(label22TAB, grassDensity);
            toolTip1.SetToolTip(trackBarGrassTAB, grassDensity);
            toolTip1.SetToolTip(button_RedateMods, redateMods);
            toolTip1.SetToolTip(label5, predictFPS);
            toolTip1.SetToolTip(comboBoxPredictFPS, predictFPS);
            toolTip1.SetToolTip(label6, zFighting);
            toolTip1.SetToolTip(button_ZFighting, zFighting);
            toolTip1.SetToolTip(comboBoxZFighting, nearDistance);
            refreshSettings();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            FuncMisc.textColor(this, System.Drawing.SystemColors.ControlLight, System.Drawing.Color.FromArgb(30, 30, 30), false);
        }
        private void FormOptions_Shown(object sender, EventArgs e)
        {
            refreshModsList();
            timer2.Enabled = true;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (lastWriteData != Directory.GetLastWriteTime(pathDataFolder))
            {
                timer2.Enabled = false;
                refreshModsList();
                timer2.Enabled = true;
                lastWriteData = Directory.GetLastWriteTime(pathDataFolder);
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
            comboBoxDecalsTAB.Items.Clear();
            comboBoxDecalsTAB.Items.AddRange(new object[] { "No / Low", "Medium / Medium", "Hight / Hight", "Ultra / Ultra" });
            comboBoxLODObjectsTAB.Items.Clear();
            comboBoxLODObjectsTAB.Items.AddRange(new object[] { "Low", "Medium", "Hight", "Ultra" });
            comboBoxTexturesTAB.Items.Clear();
            comboBoxTexturesTAB.Items.AddRange(new object[] { "Hight", "Medium", "Low" });
            errorDateChange = "Could not change the date the file was modified: ";
            filesName.Text = "Files:";
            grassDensity = "The distance between the grass bushes, the smaller it is, the denser the grass.";
            label10TAB.Text = "Resolution:";
            label11TAB.Text = "Water reflections:";
            label12TAB.Text = "Antialiasing:";
            label13TAB.Text = "Filtration:";
            label14TAB.Text = "Textures quality:";
            label15TAB.Text = "Shadow:";
            label16TAB.Text = "Shadow resolution:";
            label17TAB.Text = "Decals / Particles:";
            label18TAB.Text = "Window:";
            label2.Text = "Presets";
            label21TAB.Text = "Grass density:";
            label23TAB.Text = "Sky:";
            label24TAB.Text = "Landscape:";
            label25TAB.Text = "Objects:";
            label26TAB.Text = "Trees:";
            label27TAB.Text = "Objects:";
            label29TAB.Text = "Items:";
            label3.Text = "Mods On/All:";
            label31TAB.Text = "Characters:";
            label33TAB.Text = "Grass:";
            label35TAB.Text = "Lighting:";
            label37TAB.Text = "Far objects:";
            label38TAB.Text = "Objects details fade:";
            label40TAB.Text = "Display index:";
            label5.Text = "Expected FPS:";
            label6TAB.Text = "Resolution:";
            label7.Text = "Master files:";
            label9.Text = "Papyrus logs:";
            nearDistance = "Less - stronger flickering of mountains. Larger - stronger clipping textures near objects.";
            predictFPS = "Responsible for the correct operation of the game with different FPS.";
            redateMods = "Mass change of the date of change of files in ascending order.";
            shadowResolution = "Changing the \"heaviest\" shadow parameter.";
            zFighting = "Reduces the flickering of mountains away.";
        }
        private void FormOptions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button_Close_Click(this, new EventArgs());
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void refreshSettings()
        {
            refreshActors();
            refreshDecals();
            refreshGrass();
            refreshGrassDistance();
            refreshHideObjects();
            refreshItems();
            refreshLights();
            refreshLODObjects();
            refreshObjects();
            refreshPredictFPS();
            refreshScreenIndex();
            refreshScreenResolution();
            refreshShadow();
            refreshShadowRange();
            refreshTextures();
            refreshValueLabelPapyrus();
            refreshVsync();
            refreshWaterReflect();
            refreshWaterReflectLand();
            refreshWaterReflectObjects();
            refreshWaterReflectSky();
            refreshWaterReflectTrees();
            refreshWindow();
            refreshZFighting();
            refreshZFightingCB();
            if (FuncSettings.checkENB())
            {
                comboBoxAFTAB.Enabled = false;
                if (!FuncSettings.checkENBoost())
                {
                    comboBoxAATAB.Enabled = false;
                    button_FXAATAB.Enabled = false;
                }
                else
                {
                    refreshFXAA();
                    refreshAA();
                }
            }
            else
            {
                refreshFXAA();
                refreshAA();
                refreshAF();
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            itemStartMove = GetItemFromPoint(listView1, Cursor.Position);
            if (!blockRefreshList && itemStartMove != null && itemStartMove.Text != "Skyrim.esm" && itemStartMove.Text != "Update.esm" && itemStartMove.Text != "Dawnguard.esm" && itemStartMove.Text != "HearthFires.esm" && itemStartMove.Text != "Dragonborn.esm")
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
                listView1.Cursor = System.Windows.Forms.Cursors.Default;
                ListViewItem itemEndMove = GetItemFromPoint(listView1, Cursor.Position);
                if (itemEndMove != null && itemEndMove != itemStartMove && itemEndMove.Index > 3)
                {
                    blockRefreshList = true;
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
            startMoveItem = false;
            timer1.Enabled = false;
            itemStartMove = null;
            listView1.Cursor = System.Windows.Forms.Cursors.Default;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (startMoveItem)
            {
                if (itemStartMove != GetItemFromPoint(listView1, Cursor.Position))
                {
                    listView1.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
                }
                else
                {
                    listView1.Cursor = System.Windows.Forms.Cursors.Default;
                }
            }
        }
        private ListViewItem GetItemFromPoint(ListView listView, Point mousePosition)
        {
            Point localPoint = listView.PointToClient(mousePosition);
            return listView.GetItemAt(localPoint.X, localPoint.Y);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(FuncParser.parserESPESM(pathDataFolder + e.Item.Text).ToArray());
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!blockRefreshList)
            {
                blockRefreshList = true;
                bool fail = false;
                if (e.Item.Checked)
                {
                    goodAllMasters = true;
                    checkItem(e.Item, true);
                }
                else if (e.Item.Text != "Skyrim.esm" && e.Item.Text != "Update.esm" && e.Item.Text != "Dawnguard.esm" && e.Item.Text != "HearthFires.esm" && e.Item.Text != "Dragonborn.esm")
                {
                    uncheckItem(e.Item.Text.ToLower());
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
            foreach (string line in FuncParser.parserESPESM(pathDataFolder + item.Text))
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
                item.ForeColor = System.Drawing.Color.Red;
            }
            else if (item.Text.ToLower().EndsWith(".esm") || FuncParser.checkESM(pathDataFolder + item.Text))
            {
                item.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                item.ForeColor = System.Drawing.Color.Black;
            }
            if (check)
            {
                item.Checked = goodAllMasters;
            }
        }
        private void uncheckItem(string item)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                foreach (string line in FuncParser.parserESPESM(pathDataFolder + listView1.Items[i].Text))
                {
                    if (line.ToLower() == item)
                    {
                        listView1.Items[i].Checked = false;
                        uncheckItem(listView1.Items[i].Text.ToLower());
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
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked)
                {
                    item.SubItems[1].Text = FuncParser.loadOrderID(fileID);
                    fileID++;
                }
                else
                {
                    item.SubItems[1].Text = "";
                }
            }
        }
        private void refreshModsList()
        {
            blockRefreshList = true;
            listView1.Items.Clear();
            listBox1.Items.Clear();
            listToListESM.Clear();
            listToListESP.Clear();
            if (File.Exists(pathToPlugins) && File.Exists(pathToLoader) && Directory.Exists(pathDataFolder))
            {
                List<string> pluginsList = new List<string>();
                pluginsList.AddRange(File.ReadAllLines(pathToPlugins));
                List<string> loaderList = new List<string>();
                loaderList.AddRange(File.ReadAllLines(pathToLoader));
                List<string> filesDataES = new List<string>();
                foreach (string line in Directory.GetFiles(pathDataFolder))
                {
                    string file = Path.GetFileName(line);
                    string fileLower = file.ToLower();
                    if ((fileLower.ToLower().EndsWith(".esm") || fileLower.ToLower().EndsWith(".esp")) && fileLower.ToLower() != "skyrim.esm" && fileLower.ToLower() != "update.esm" && fileLower.ToLower() != "dawnguard.esm" && fileLower.ToLower() != "hearthfires.esm" && fileLower.ToLower() != "dragonborn.esm")
                    {
                        filesDataES.Add(file);
                    }
                }
                if (File.Exists(pathDataFolder + "Skyrim.esm") && File.Exists(pathDataFolder + "Update.esm") && File.Exists(pathDataFolder + "Dawnguard.esm") && File.Exists(pathDataFolder + "HearthFires.esm") && File.Exists(pathDataFolder + "Dragonborn.esm"))
                {
                    listToListESM.Add("<*>Skyrim.esm");
                    listToListESM.Add("<*>Update.esm");
                    listToListESM.Add("<*>Dawnguard.esm");
                    listToListESM.Add("<*>HearthFires.esm");
                    listToListESM.Add("<*>Dragonborn.esm");
                }
                foreach (string line in loaderList)
                {
                    for (int i = 0; i < filesDataES.Count; i++)
                    {
                        if (filesDataES[i].Equals(line, StringComparison.OrdinalIgnoreCase))
                        {
                            if (pluginsList.Contains(line, StringComparer.OrdinalIgnoreCase))
                            {
                                addToLTL(filesDataES[i], "<*>");
                            }
                            else
                            {
                                addToLTL(filesDataES[i], "");
                            }
                            break;
                        }
                    }
                }
                foreach (string line in pluginsList)
                {
                    for (int i = 0; i < filesDataES.Count; i++)
                    {
                        if (filesDataES[i].Equals(line, StringComparison.OrdinalIgnoreCase))
                        {
                            if (!loaderList.Contains(line, StringComparer.OrdinalIgnoreCase))
                            {
                                addToLTL(filesDataES[i], "<*>");
                                break;
                            }
                        }
                    }
                }
                foreach (string line in filesDataES)
                {
                    if (!loaderList.Contains(line, StringComparer.OrdinalIgnoreCase) && !pluginsList.Contains(line, StringComparer.OrdinalIgnoreCase))
                    {
                        addToLTL(line, "");
                    }
                }
                filesDataES = null;
                pluginsList = null;
                loaderList = null;
                foreach (string line in listToListESM)
                {
                    addToLV(line);
                }
                foreach (string line in listToListESP)
                {
                    addToLV(line);
                }
                scanAllMods();
                writeMasterFile();
                blockRefreshList = false;
            }
        }
        private void addToLTL(string line, string check)
        {
            if (line.ToLower().EndsWith(".esm") || FuncParser.checkESM(pathDataFolder + line))
            {
                listToListESM.Add(check + line);
            }
            else
            {
                listToListESP.Add(check + line);
            }
        }
        private void addToLV(string line)
        {
            ListViewItem item = new ListViewItem();
            if (line.StartsWith("<*>"))
            {
                item.Text = line.Remove(0, 3);
                item.Checked = true;
            }
            else
            {
                item.Text = line;
            }
            item.SubItems.Add("");
            listView1.Items.Add(item);
        }
        private void writeMasterFile()
        {
            List<string> writeList = new List<string>();
            foreach (ListViewItem item in listView1.CheckedItems)
            {
                if (item.Text.ToLower() != "skyrim.esm")
                {
                    writeList.Add(item.Text);
                }
            }
            FuncMisc.writeToFile(pathToPlugins, writeList);
            writeList.Clear();
            foreach (ListViewItem item in listView1.Items)
            {
                writeList.Add(item.Text);
            }
            FuncMisc.writeToFile(pathToLoader, writeList);
            writeList = null;
            label4.Text = listView1.CheckedItems.Count.ToString() + " / " + listView1.Items.Count.ToString();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_ActivatedAll_Click(object sender, EventArgs e)
        {
            blockRefreshList = true;
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = true;
            }
            scanAllMods();
            writeMasterFile();
            blockRefreshList = false;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_Restore_Click(object sender, EventArgs e)
        {
            FuncFiles.deleteAny(FormMain.pathAppData + @"Plugins.txt");
            FuncFiles.deleteAny(FormMain.pathAppData + @"LoadOrder.txt");
            FuncFiles.copyAny(FormMain.pathLauncherFolder + @"MasterList\Plugins.txt", FormMain.pathAppData + @"Plugins.txt");
            FuncFiles.copyAny(FormMain.pathLauncherFolder + @"MasterList\Plugins.txt", FormMain.pathAppData + @"LoadOrder.txt");
            refreshModsList();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_RedateMods_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                DateTime dt = new DateTime(2019, 1, 1, 12, 0, 0, DateTimeKind.Local);
                foreach (string line in Directory.GetFiles(pathDataFolder, "*.bsa"))
                {
                    try
                    {
                        File.SetLastWriteTime(line, dt);
                    }
                    catch
                    {
                        MessageBox.Show(errorDateChange + line);
                    }
                }
                foreach (ListViewItem item in listView1.CheckedItems)
                {
                    try
                    {
                        File.SetLastWriteTime(pathDataFolder + item.Text, dt);
                    }
                    catch
                    {
                        MessageBox.Show(errorDateChange + pathDataFolder + item.Text);
                    }
                    dt = dt.AddMinutes(1);
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
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
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iSize W", screenListW[comboBoxResolutionTAB.SelectedIndex].ToString());
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iSize H", screenListH[comboBoxResolutionTAB.SelectedIndex].ToString());
            setAspectRatioFiles();
        }
        private void refreshScreenResolution()
        {
            screenListW.Clear();
            screenListH.Clear();
            comboBoxResolutionTAB.Items.Clear();
            addResolution(FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Display", "iSize W"), FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Display", "iSize H"));
            bool fail = false;
            try
            {
                var scope = new ManagementScope();
                var query = new ObjectQuery("SELECT * FROM CIM_VideoControllerResolution");
                using (var searcher = new ManagementObjectSearcher(scope, query))
                {
                    var results = searcher.Get();
                    foreach (var result in results)
                    {
                        addResolution(FuncParser.stringToInt(result["HorizontalResolution"].ToString()), FuncParser.stringToInt(result["VerticalResolution"].ToString()));
                    }
                }
            }
            catch
            {
                fail = true;
            }
            if (fail || comboBoxResolutionTAB.Items.Count < 2)
            {
                foreach (string line in FuncResolutions.Resolutions())
                {
                    int divider = line.IndexOf("/");
                    addResolution(FuncParser.stringToInt(line.Remove(divider)), FuncParser.stringToInt(line.Remove(0, divider + 1)));
                }
            }
            comboBoxResolutionTAB.SelectedIndex = 0;
            setAspectRatioFiles();
        }
        private void addResolution(int width, int height)
        {
            string line = width.ToString() + " x " + height.ToString();
            if (width >= 800 && height >= 600 && !comboBoxResolutionTAB.Items.Contains(line))
            {
                screenListW.Add(width);
                screenListH.Add(height);
                comboBoxResolutionTAB.Items.Add(line);
            }
        }
        private void setAspectRatioFiles()
        {
            if (comboBoxResolutionTAB.SelectedIndex != -1)
            {
                double[] arlist = new double[] { 1.3, 1.4, 1.7, 1.8, 2.5 };
                double ar = (double)screenListW[comboBoxResolutionTAB.SelectedIndex] / screenListH[comboBoxResolutionTAB.SelectedIndex];
                int arl = FuncParser.intRead(FormMain.pathLauncherINI, "General", "AspectRatio");
                for (int i = 0; i < arlist.Length; i++)
                {
                    if (ar <= arlist[i])
                    {
                        if (arl != i)
                        {
                            FuncMisc.unpackRAR(FormMain.pathLauncherFolder + @"CPFiles\System\AR(" + i.ToString() + ").rar");
                            FuncParser.iniWrite(FormMain.pathLauncherINI, "General", "AspectRatio", i.ToString());
                            FuncMisc.wideScreenMods();
                        }
                        break;
                    }
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxScreen_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Display", "iAdapter", comboBoxScreenTAB.SelectedIndex.ToString());
            FuncSettings.restoreENBAdapter();
        }
        private void refreshScreenIndex()
        {
            FuncSettings.restoreENBAdapter();
            Screen[] screens = Screen.AllScreens;
            if (screens.Count() > 1)
            {
                comboBoxScreenTAB.Items.Clear();
                for (int i = 0; i < screens.Count(); i++)
                {
                    comboBoxScreenTAB.Items.Add(i.ToString());
                }
            }
            int value = FuncParser.intRead(FormMain.pathSkyrimINI, "Display", "iAdapter");
            if (value > -1 && value < comboBoxScreenTAB.Items.Count)
            {
                comboBoxScreenTAB.SelectedIndexChanged -= comboBoxScreen_SelectedIndexChanged;
                comboBoxScreenTAB.SelectedIndex = value;
                comboBoxScreenTAB.SelectedIndexChanged += comboBoxScreen_SelectedIndexChanged;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxAA_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iMultiSample", comboBoxAATAB.SelectedItem.ToString());
        }
        private void refreshAA()
        {
            FuncMisc.refreshComboBox(comboBoxAATAB, new List<double>() { 0, 2, 4, 8 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Display", "iMultiSample"), false, comboBoxAA_SelectedIndexChanged);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxAF_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iMaxAnisotropy", comboBoxAFTAB.SelectedItem.ToString());
        }
        private void refreshAF()
        {
            FuncMisc.refreshComboBox(comboBoxAFTAB, new List<double>() { 0, 2, 4, 8, 16 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Display", "iMaxAnisotropy"), false, comboBoxAF_SelectedIndexChanged);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxShadowRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iShadowMapResolution", comboBoxShadowResTAB.SelectedItem.ToString());
        }
        private void refreshShadow()
        {
            FuncMisc.refreshComboBox(comboBoxShadowResTAB, new List<double>() { 512, 1024, 2048, 4096 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Display", "iShadowMapResolution"), false, comboBoxShadowRes_SelectedIndexChanged);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxTextures_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iTexMipMapSkip", comboBoxTexturesTAB.SelectedIndex.ToString());
        }
        private void refreshTextures()
        {
            FuncMisc.refreshComboBox(comboBoxTexturesTAB, new List<double>() { 0, 1, 2 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Display", "iTexMipMapSkip"), false, comboBoxTextures_SelectedIndexChanged);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxDecals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDecalsTAB.SelectedIndex == 0)
            {
                setDecals("0", "0", "0", "0", "0", "0", "250");
            }
            else if (comboBoxDecalsTAB.SelectedIndex == 1)
            {
                setDecals("1", "1", "35", "20", "20", "20", "500");
            }
            else if (comboBoxDecalsTAB.SelectedIndex == 2)
            {
                setDecals("1", "1", "50", "40", "50", "50", "750");
            }
            else if (comboBoxDecalsTAB.SelectedIndex == 3)
            {
                setDecals("1", "1", "100", "60", "100", "100", "950");
            }
        }
        private void setDecals(string bDecals, string bSkinnedDecals, string uMaxSkinDecals, string uMaxSkinDecalsPerActor, string iMaxDecalsPerFrame, string iMaxSkinDecalsPerFrame, string iMaxDesired)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Decals", "bDecals", bDecals);
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Decals", "bSkinnedDecals", bSkinnedDecals);
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Decals", "uMaxSkinDecals", uMaxSkinDecals);
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Decals", "uMaxSkinDecalsPerActor", uMaxSkinDecalsPerActor);
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iMaxDecalsPerFrame", iMaxDecalsPerFrame);
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iMaxSkinDecalsPerFrame", iMaxSkinDecalsPerFrame);
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Particles", "iMaxDesired", iMaxDesired);
        }
        private void refreshDecals()
        {
            FuncMisc.refreshComboBox(comboBoxDecalsTAB, new List<double>() { 0, 20, 50, 100 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Display", "iMaxDecalsPerFrame"), false, comboBoxDecals_SelectedIndexChanged);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxLODObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLODObjectsTAB.SelectedIndex == 0)
            {
                setLODObjects("12500.0000", "75000.0000", "25000.0000", "15000.0000", "0.4000", "3500.0000", "50000.0000");
            }
            else if (comboBoxLODObjectsTAB.SelectedIndex == 1)
            {
                setLODObjects("25000.0000", "100000.0000", "32768.0000", "20480.0000", "0.7500", "4000.0000", "150000.0000");
            }
            else if (comboBoxLODObjectsTAB.SelectedIndex == 2)
            {
                setLODObjects("40000.0000", "150000.0000", "40000.0000", "25000.0000", "1.1000", "5000.0000", "300000.0000");
            }
            else if (comboBoxLODObjectsTAB.SelectedIndex == 3)
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
            FuncMisc.refreshComboBox(comboBoxLODObjectsTAB, new List<double>() { 12500, 25000, 40000, 75000 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fTreeLoadDistance"), false, comboBoxLODObjects_SelectedIndexChanged);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxPredictFPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormMain.predictFPS = FuncParser.stringToInt(comboBoxPredictFPS.SelectedItem.ToString());
            FuncSettings.physicsFPS();
        }
        private void refreshPredictFPS()
        {
            FuncSettings.physicsFPS();
            FuncMisc.refreshComboBox(comboBoxPredictFPS, new List<double>() { 0.0333, 0.0166, 0.0133, 0.0111, 0.0083, 0.0069, 0.0041 }, FuncParser.doubleRead(FormMain.pathSkyrimINI, "HAVOK", "fMaxTime"), false, comboBoxPredictFPS_SelectedIndexChanged);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxWaterReflect_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Water", "iWaterReflectWidth", comboBoxWaterReflectTAB.SelectedItem.ToString());
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Water", "iWaterReflectHeight", comboBoxWaterReflectTAB.SelectedItem.ToString());
        }
        private void refreshWaterReflect()
        {
            FuncMisc.refreshComboBox(comboBoxWaterReflectTAB, new List<double>() { 512, 1024, 2048 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Water", "iWaterReflectWidth"), false, comboBoxWaterReflect_SelectedIndexChanged);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBoxZFighting_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Display", "fNearDistance", comboBoxZFighting.SelectedItem.ToString() + ".0000");
            FuncParser.iniWrite(FormMain.pathLauncherINI, "Game", "NearDistance", comboBoxZFighting.SelectedItem.ToString());
        }
        private void refreshZFightingCB()
        {
            FuncMisc.refreshComboBox(comboBoxZFighting, new List<double>() { 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, FuncParser.intRead(FormMain.pathSkyrimINI, "Display", "fNearDistance"), false, comboBoxZFighting_SelectedIndexChanged);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_ZFighting_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathLauncherINI, "Game", "ZFighting", Convert.ToInt32(!zfighting).ToString());
            refreshZFighting();
            if (!zfighting)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimINI, "Display", "fNearDistance", "15.0000");
                comboBoxLODObjects_SelectedIndexChanged(this, new EventArgs());
                refreshZFightingCB();
            }
        }
        private void refreshZFighting()
        {
            zfighting = FuncMisc.refreshButton(button_ZFighting, FormMain.pathLauncherINI, "Game", "ZFighting", null, false);
            comboBoxZFighting.Enabled = zfighting;
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
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_Papyrus_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Papyrus", "bEnableLogging", Convert.ToInt32(!papyrus).ToString());
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Papyrus", "bEnableTrace", Convert.ToInt32(!papyrus).ToString());
            refreshValueLabelPapyrus();
        }
        private void refreshValueLabelPapyrus()
        {
            papyrus = FuncMisc.refreshButton(button_Papyrus, FormMain.pathSkyrimINI, "Papyrus", "bEnableLogging", null, false);
            if (papyrus)
            {
                FuncFiles.creatDirectory(FormMain.pathMyDoc + "Logs");
            }
        }
        private void button_LogsFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(FormMain.pathMyDoc + @"Logs\"))
            {
                Process.Start(FormMain.pathMyDoc + @"Logs\");
            }
            else if (Directory.Exists(FormMain.pathMyDoc))
            {
                Process.Start(FormMain.pathMyDoc);
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_ReflectSky_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Water", "bReflectSky", Convert.ToInt32(!rsky).ToString());
            refreshWaterReflectSky();
        }
        private void refreshWaterReflectSky()
        {
            rsky = FuncMisc.refreshButton(button_ReflectSkyTAB, FormMain.pathSkyrimINI, "Water", "bReflectSky", null, false);
        }

        private void button_ReflectLanscape_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Water", "bReflectLODLand", Convert.ToInt32(!rland).ToString());
            refreshWaterReflectLand();
        }
        private void refreshWaterReflectLand()
        {
            rland = FuncMisc.refreshButton(button_ReflectLanscapeTAB, FormMain.pathSkyrimINI, "Water", "bReflectLODLand", null, false);
        }

        private void button_ReflectObjects_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Water", "bReflectLODObjects", Convert.ToInt32(!robj).ToString());
            refreshWaterReflectObjects();
        }
        private void refreshWaterReflectObjects()
        {
            robj = FuncMisc.refreshButton(button_ReflectObjectsTAB, FormMain.pathSkyrimINI, "Water", "bReflectLODObjects", null, false);
        }

        private void button_ReflectTrees_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Water", "bReflectLODTrees", Convert.ToInt32(!rtree).ToString());
            refreshWaterReflectTrees();
        }
        private void refreshWaterReflectTrees()
        {
            rtree = FuncMisc.refreshButton(button_ReflectTreesTAB, FormMain.pathSkyrimINI, "Water", "bReflectLODTrees", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_Window_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bFull Screen", Convert.ToInt32(window).ToString());
            refreshWindow();
        }
        private void refreshWindow()
        {
            FuncSettings.restoreENBBorderless();
            window = FuncMisc.refreshButton(button_WindowTAB, FormMain.pathSkyrimPrefsINI, "Display", "bFull Screen", null, true);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_Vsync_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Display", "iPresentInterval", Convert.ToInt32(!vsync).ToString());
            refreshVsync();
        }
        private void refreshVsync()
        {
            FuncSettings.restoreENBVSync();
            vsync = FuncMisc.refreshButton(button_VsyncTAB, FormMain.pathSkyrimINI, "Display", "iPresentInterval", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_FXAA_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bFXAAEnabled", Convert.ToInt32(!fxaa).ToString());
            refreshFXAA();
        }
        private void refreshFXAA()
        {
            fxaa = FuncMisc.refreshButton(button_FXAATAB, FormMain.pathSkyrimPrefsINI, "Display", "bFXAAEnabled", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_HideObjects_Click(object sender, EventArgs e)
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
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void trackBarGrass_Scroll(object sender, EventArgs e)
        {

            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Grass", "iMinGrassSize", (trackBarGrassTAB.Value * 5).ToString());
            label22TAB.Text = (trackBarGrassTAB.Value * 5).ToString();
        }
        private void refreshGrass()
        {
            FuncMisc.refreshTrackBar(trackBarGrassTAB, FormMain.pathSkyrimINI, "Grass", "iMinGrassSize", 5, label22TAB);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void trackBarGrassDistance_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Grass", "fGrassStartFadeDistance", (trackBarGrassDistanceTAB.Value * 1000).ToString());
            label34TAB.Text = (trackBarGrassDistanceTAB.Value * 1000).ToString();
        }
        private void refreshGrassDistance()
        {
            FuncMisc.refreshTrackBar(trackBarGrassDistanceTAB, FormMain.pathSkyrimPrefsINI, "Grass", "fGrassStartFadeDistance", 1000, label34TAB);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void trackBarObjects_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultObjects", (trackBarObjectsTAB.Value).ToString());
            label28TAB.Text = trackBarObjectsTAB.Value.ToString();
        }
        private void refreshObjects()
        {
            FuncMisc.refreshTrackBar(trackBarObjectsTAB, FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultObjects", -1, label28TAB);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void trackBarItems_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultItems", (trackBarItemsTAB.Value).ToString());
            label30TAB.Text = trackBarItemsTAB.Value.ToString();
        }
        private void refreshItems()
        {
            FuncMisc.refreshTrackBar(trackBarItemsTAB, FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultItems", -1, label30TAB);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void trackBarActors_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultActors", (trackBarActorsTAB.Value).ToString());
            label32TAB.Text = trackBarActorsTAB.Value.ToString();
        }
        private void refreshActors()
        {
            FuncMisc.refreshTrackBar(trackBarActorsTAB, FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultActors", -1, label32TAB);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void trackBarLights_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fLightLODStartFade", (trackBarLightsTAB.Value * 100).ToString());
            label36TAB.Text = (trackBarLightsTAB.Value * 100).ToString();
        }
        private void refreshLights()
        {
            FuncMisc.refreshTrackBar(trackBarLightsTAB, FormMain.pathSkyrimPrefsINI, "Display", "fLightLODStartFade", 100, label36TAB);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void trackBarShadow_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fShadowDistance", (trackBarShadowTAB.Value * 500).ToString());
            label39TAB.Text = (trackBarShadowTAB.Value * 500).ToString();
        }
        private void refreshShadowRange()
        {
            FuncMisc.refreshTrackBar(trackBarShadowTAB, FormMain.pathSkyrimPrefsINI, "Display", "fShadowDistance", 500, label39TAB);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttons_ChangeTabs_Click(object sender, EventArgs e)
        {
            foreach (Control line in this.Controls)
            {
                if ((line is Label || line is Button || line is TrackBar || line is ComboBox || line is PictureBox) && line.Name.EndsWith("TAB"))
                {
                    line.Visible = !line.Visible;
                }
            }
            button_Common.Enabled = !button_Common.Enabled;
            button_Distance.Enabled = !button_Distance.Enabled;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            button_Close.BackgroundImage = Properties.Resources.buttonCloseGlow;
        }
        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            button_Close.BackgroundImage = Properties.Resources.buttonClose;
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}