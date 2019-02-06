using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public partial class FormENB : Form
    {
        public static string pathENBLocalINI = FormMain.pathGameFolder + "enblocal.ini";
        public static string pathENBSeriesINI = FormMain.pathGameFolder + "enbseries.ini";
        string pathENBfolder = FormMain.pathGameFolder + @"Skyrim\ENB\";
        string compressMemory = "EnableCompression - уменьшает объем видеопамяти, снижает производительность.";
        string confirmTitle = "Подтверждение";
        string expandMemory = "ExpandSystemMemoryX64 - сдвигает адресное пространство игры в памяти.";
        string noFileSelect = "Не выбран файл.";
        string removeENBFiles = "Удалить все файлы ENB?";
        string reservedMemory = "ReservedMemorySizeMb - резервирование памяти под эффекты ENB.";
        bool eaa = false;
        bool saa = false;
        bool dof = false;
        bool taa = false;
        bool af = false;
        bool autovram = false;
        bool compress = false;
        bool fps = false;
        bool setupENB = false;
        bool expandmemory = false;

        public FormENB()
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
            toolTip1.SetToolTip(label3, reservedMemory);
            toolTip1.SetToolTip(comboBox3, reservedMemory);
            toolTip1.SetToolTip(button_Compress, compressMemory);
            toolTip1.SetToolTip(label9, compressMemory);
            toolTip1.SetToolTip(label17, expandMemory);
            toolTip1.SetToolTip(buttonExpandMemory, expandMemory);
            refreshFileList();
            refreshAllValue();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            FuncMisc.textColor(this, System.Drawing.SystemColors.ControlLight, System.Drawing.Color.FromArgb(30, 30, 30), false);
        }
        private void langTranslateEN()
        {
            button_deleteAllENB.Text = "UnInstall";
            button_unpackENB.Text = "Install";
            compressMemory = "EnableCompression - reduces the amount of video memory, reduces performance.";
            confirmTitle = "Confirm";
            expandMemory = "ExpandSystemMemoryX64 - shifts the address space of the game in memory.";
            label10.Text = @"Files from Skyrim\ENB";
            label13.Text = "Filtration:";
            label15.Text = "Video memory max.:";
            label16.Text = "Video memory:";
            label17.Text = "Shifts memory:";
            label3.Text = "Reserved memory:";
            label4.Text = "Antialiasing:";
            label5.Text = "FPS limit:";
            label8.Text = "Depth of field:";
            label9.Text = "Compress memory:";
            noFileSelect = "No file select.";
            removeENBFiles = "Delete all ENB files?";
            reservedMemory = "ReservedMemorySizeMb - reservation of memory for ENB effects.";
        }
        private void FormENB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button_Close_Click(this, new EventArgs());
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void refreshFileList()
        {
            if (Directory.Exists(pathENBfolder))
            {
                foreach (string line in Directory.GetFiles(pathENBfolder, "*.rar").OrderBy(f => f))
                {
                    listBox1.Items.Add(Path.GetFileName(line));
                }
                string last = FuncParser.stringRead(FormMain.pathLauncherINI, "ENB", "LastPreset");
                if (last != null && listBox1.Items.Contains(last))
                {
                    listBox1.SelectedItem = last;
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void refreshAllValue()
        {
            setupENB = FuncSettings.checkENB();
            if (!FuncSettings.checkENBoost())
            {
                refreshEAA();
                refreshSAA();
                refreshTAA();
                refreshDOF();
            }
            refresAutoDetect();
            refresbuttonExpandMemory();
            refresCompressMemory();
            refreshAF();
            refreshFPS();
            refreshMemory();
            restoreAllValue();
        }
        private void restoreAllValue()
        {
            FuncSettings.physicsFPS();
            FuncSettings.restoreENBAdapter();
            FuncSettings.restoreENBBorderless();
            FuncSettings.restoreENBVSync();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_unpackENB_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                FuncClear.removeENB();
                enbUnpack(listBox1.SelectedItem.ToString());
                FuncParser.iniWrite(FormMain.pathLauncherINI, "ENB", "LastPreset", listBox1.SelectedItem.ToString());
                if (listBox1.SelectedItem.ToString().ToLower().Contains("boost"))
                {
                    FuncMisc.refreshButton(button_DOF, "", "", "", null, false);
                    FuncMisc.refreshButton(button_EAA, "", "", "", null, false);
                    FuncMisc.refreshButton(button_SAA, "", "", "", null, false);
                    FuncMisc.refreshButton(button_TAA, "", "", "", null, false);
                    FuncMisc.unpackRAR(FormMain.pathLauncherFolder + @"CPFiles\System\GameText9.rar");
                }
                else
                {
                    FuncFiles.deleteAny(FormMain.pathGameFolder + @"Data\GameText9.bsa");
                }
            }
            else
            {
                MessageBox.Show(noFileSelect);
            }
        }
        private void enbUnpack(string filename)
        {
            FuncMisc.toggleButtons(this, false);
            listBox1.Enabled = false;
            FuncMisc.unpackRAR(pathENBfolder + filename);
            FuncMisc.toggleButtons(this, true);
            listBox1.Enabled = true;
            refreshAllValue();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_deleteAllENB_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(removeENBFiles, confirmTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FuncClear.removeENB();
                FuncSettings.checkENB();
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iMaxAnisotropy", "16");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bFXAAEnabled", "1");
                FuncParser.iniWrite(FormMain.pathLauncherINI, "ENB", "LastPreset", "");
                FuncMisc.unpackRAR(FormMain.pathLauncherFolder + @"CPFiles\System\GameText9.rar");
                refreshAllValue();
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_DOF_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(pathENBSeriesINI, "EFFECT", "EnableDepthOfField", (!dof).ToString().ToLower());
            refreshDOF();
        }
        private void refreshDOF()
        {
            dof = FuncMisc.refreshButton(button_DOF, pathENBSeriesINI, "EFFECT", "EnableDepthOfField", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_AA_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(pathENBLocalINI, "ANTIALIASING", "EnableEdgeAA", (!eaa).ToString().ToLower());
            refreshEAA();
        }
        private void refreshEAA()
        {
            eaa = FuncMisc.refreshButton(button_EAA, pathENBLocalINI, "ANTIALIASING", "EnableEdgeAA", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_SAA_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(pathENBLocalINI, "ANTIALIASING", "EnableSubPixelAA", (!saa).ToString().ToLower());
            refreshSAA();
        }
        private void refreshSAA()
        {
            saa = FuncMisc.refreshButton(button_SAA, pathENBLocalINI, "ANTIALIASING", "EnableSubPixelAA", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_TAA_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(pathENBLocalINI, "ANTIALIASING", "EnableTemporalAA", (!taa).ToString().ToLower());
            refreshTAA();
        }
        private void refreshTAA()
        {
            taa = FuncMisc.refreshButton(button_TAA, pathENBLocalINI, "ANTIALIASING", "EnableTemporalAA", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_AF_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(pathENBLocalINI, "ENGINE", "ForceAnisotropicFiltering", (!af).ToString().ToLower());
            refreshAF();
        }
        private void refreshAF()
        {
            af = FuncMisc.refreshButton(button_AF, pathENBLocalINI, "ENGINE", "ForceAnisotropicFiltering", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_FPS_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(pathENBLocalINI, "LIMITER", "EnableFPSLimit", (!fps).ToString().ToLower());
            refreshFPS();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (setupENB && fps)
            {
                FormMain.predictFPS = FuncParser.stringToInt(comboBox1.SelectedItem.ToString());
                FuncSettings.physicsFPS();
            }
        }
        private void refreshFPS()
        {
            fps = FuncMisc.refreshButton(button_FPS, pathENBLocalINI, "LIMITER", "EnableFPSLimit", null, false);
            if (setupENB && fps)
            {
                FuncMisc.refreshComboBox(comboBox1, new List<double>() { 30, 60, 75, 90, 120, 144, 240 }, FuncParser.intRead(pathENBLocalINI, "LIMITER", "FPSLimit"), false, comboBox1_SelectedIndexChanged);
            }
            else
            {
                comboBox1.SelectedIndex = -1;
            }
            comboBox1.Enabled = setupENB && fps;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (setupENB)
            {
                FuncParser.iniWrite(pathENBLocalINI, "MEMORY", "ReservedMemorySizeMb", comboBox3.SelectedItem.ToString());
            }
        }
        private void refreshMemory()
        {
            if (setupENB)
            {
                comboBox3.Enabled = true;
                FuncMisc.refreshComboBox(comboBox3, new List<double>() { 64, 128, 256, 384, 512, 640, 768, 896, 1024 }, FuncParser.intRead(pathENBLocalINI, "MEMORY", "ReservedMemorySizeMb"), false, comboBox3_SelectedIndexChanged);
            }
            else
            {
                comboBox3.SelectedIndex = -1;
                comboBox3.Enabled = false;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_Compress_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(pathENBLocalINI, "MEMORY", "EnableCompression", (!compress).ToString().ToLower());
            refresCompressMemory();
        }
        private void refresCompressMemory()
        {
            compress = FuncMisc.refreshButton(button_Compress, pathENBLocalINI, "MEMORY", "EnableCompression", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void buttonExpandMemory_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(pathENBLocalINI, "MEMORY", "ExpandSystemMemoryX64", (!expandmemory).ToString().ToLower());
            refresbuttonExpandMemory();
        }
        private void refresbuttonExpandMemory()
        {
            expandmemory = FuncMisc.refreshButton(buttonExpandMemory, pathENBLocalINI, "MEMORY", "ExpandSystemMemoryX64", null, false);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_AutoMemory_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(pathENBLocalINI, "MEMORY", "AutodetectVideoMemorySize", (!autovram).ToString().ToLower());
            refresAutoDetect();
        }
        private void refresAutoDetect()
        {
            autovram = FuncMisc.refreshButton(button_AutoMemory, pathENBLocalINI, "MEMORY", "AutodetectVideoMemorySize", null, false);
            FuncMisc.refreshNumericUpDown(numericUpDown1, pathENBLocalINI, "MEMORY", "VideoMemorySizeMb", numericUpDown1_ValueChanged);
            numericUpDown1.Enabled = setupENB && !autovram;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathLauncherINI, "ENB", "MemorySizeMb", numericUpDown1.Value.ToString());
            FuncSettings.restoreENBVideoMemory();
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