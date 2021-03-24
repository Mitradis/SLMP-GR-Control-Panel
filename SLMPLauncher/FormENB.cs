using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public partial class FormENB : Form
    {
        string textAA = "Сглаживание ";
        string textAF = "ForceAnisotropicFiltering - форсирование AF на большем числе объектов.";
        string textAO = "AmbientOcclusion - затенение на объектах, снижает производительность.";
        string textCompression = "EnableCompression - уменьшает потребление VRAM, снижает производительность.";
        string textDOF = "DepthOfField - фокусировка, размытие заднего фона.";
        string textExpandMemory = "ExpandSystemMemoryX64 - сдвигает адресное пространство игры в памяти.";
        string textNoFile = "Не выбран файл.";
        string textRemoveENB = "Удалить все файлы ENB?";
        string textReservedMemory = "ReservedMemorySizeMb - размер буфера между VRAM и RAM.";
        bool af = false;
        bool ao = false;
        bool autovram = false;
        bool compress = false;
        bool dof = false;
        bool eaa = false;
        bool expandmemory = false;
        bool fps = false;
        bool saa = false;
        bool taa = false;

        public FormENB()
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
            toolTip1.SetToolTip(label9, textReservedMemory);
            toolTip1.SetToolTip(comboBox_ReservedMemory, textReservedMemory);
            toolTip1.SetToolTip(label11, textCompression);
            toolTip1.SetToolTip(button_Compress, textCompression);
            toolTip1.SetToolTip(label10, textExpandMemory);
            toolTip1.SetToolTip(button_ExpandMemory, textExpandMemory);
            toolTip1.SetToolTip(label2, textDOF);
            toolTip1.SetToolTip(button_DOF, textDOF);
            toolTip1.SetToolTip(label3, textAO);
            toolTip1.SetToolTip(button_AO, textAO);
            toolTip1.SetToolTip(label7, textAF);
            toolTip1.SetToolTip(button_AF, textAF);
            toolTip1.SetToolTip(comboBox_AF, textAF);
            toolTip1.SetToolTip(label6, textAA + "EdgeAA");
            toolTip1.SetToolTip(button_EAA, textAA + "EdgeAA");
            toolTip1.SetToolTip(label4, textAA + "SubPixelAA");
            toolTip1.SetToolTip(button_SAA, textAA + "SubPixelAA");
            toolTip1.SetToolTip(label5, textAA + "TemporalAA");
            toolTip1.SetToolTip(button_TAA, textAA + "TemporalAA");
            refreshFileList();
            refreshAllValue();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            FuncMisc.textColor(this, System.Drawing.SystemColors.ControlLight, System.Drawing.Color.Black, false);
        }
        private void langTranslateEN()
        {
            button_Install.Text = "Install";
            button_Uninstall.Text = "Uninstall";
            label14.Text = @"Files from Skyrim\ENB";
            label3.Text = "Amb. occlusion:";
            label12.Text = "VRAM maximum:";
            label13.Text = "VRAM size:";
            label10.Text = "Shifts memory:";
            label9.Text = "Buffer memory:";
            label7.Text = "Force AF";
            label8.Text = "FPS limit:";
            label2.Text = "Depth of field:";
            label11.Text = "Compress VRAM:";
            textAA = "Antialiasing ";
            textAF = "ForceAnisotropicFiltering - forcing AF on more objects.";
            textAO = "AmbientOcclusion - shading on objects, reduces performance.";
            textCompression = "EnableCompression - reduces VRAM consumption, reduces performance.";
            textDOF = "DepthOfField - focus, blur background.";
            textExpandMemory = "ExpandSystemMemoryX64 - shifts the address space of the game in memory.";
            textNoFile = "No file select.";
            textRemoveENB = "Delete all ENB files?";
            textReservedMemory = "ReservedMemorySizeMb - buffer size between VRAM and RAM.";
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void refreshFileList()
        {
            if (Directory.Exists(FormMain.pathENBFolder))
            {
                foreach (string line in Directory.EnumerateFiles(FormMain.pathENBFolder))
                {
                    if (FormMain.archiveExt.Exists(s => s.Equals(Path.GetExtension(line), StringComparison.OrdinalIgnoreCase)))
                    {
                        listBox1.Items.Add(Path.GetFileName(line));
                    }
                }
                string last = FuncParser.stringRead(FormMain.pathLauncherINI, "ENB", "LastPreset");
                if (last != null && listBox1.Items.Contains(last))
                {
                    listBox1.SelectedItem = last;
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void refreshAllValue()
        {
            FuncSettings.checkENB();
            FuncSettings.physicsFPS();
            FuncSettings.restoreENBAdapter();
            FuncSettings.restoreENBBorderless();
            FuncSettings.restoreENBVSync();
            refreshFPS();
            refreshAF();
            refreshReservedMemory();
            refreshExpandMemory();
            refreshCompressMemory();
            refreshAutoDetect();
            if (FormMain.setupENB == 2)
            {
                refreshDOF();
                refreshAO();
                refreshSAA();
                refreshTAA();
                refreshEAA();
            }
            else
            {
                FuncMisc.refreshButton(button_DOF, "", "", "", null, false);
                FuncMisc.refreshButton(button_AO, "", "", "", null, false);
                FuncMisc.refreshButton(button_SAA, "", "", "", null, false);
                FuncMisc.refreshButton(button_TAA, "", "", "", null, false);
                FuncMisc.refreshButton(button_EAA, "", "", "", null, false);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_Install_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                FuncMisc.toggleButtons(this, false);
                listBox1.Enabled = false;
                FuncClear.removeENB();
                FuncFiles.unpackArhive(FormMain.pathENBFolder + listBox1.SelectedItem.ToString(), false, false);
                FuncParser.iniWrite(FormMain.pathLauncherINI, "ENB", "LastPreset", listBox1.SelectedItem.ToString());
                listBox1.Enabled = true;
                FuncMisc.toggleButtons(this, true);
                refreshAllValue();
            }
            else
            {
                MessageBox.Show(textNoFile);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_Uninstall_Click(object sender, EventArgs e)
        {
            if (FuncMisc.dialogResult(textRemoveENB))
            {
                FuncClear.removeENB();
                FuncParser.iniWrite(FormMain.pathLauncherINI, "ENB", "LastPreset", "");
                refreshAllValue();
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_DOF_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathENBSeriesINI, "EFFECT", "EnableDepthOfField", (!dof).ToString().ToLower());
            refreshDOF();
        }
        private void refreshDOF()
        {
            dof = FuncMisc.refreshButton(button_DOF, FormMain.pathENBSeriesINI, "EFFECT", "EnableDepthOfField", null, false);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_AO_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathENBSeriesINI, "EFFECT", "EnableAmbientOcclusion", (!ao).ToString().ToLower());
            refreshAO();
        }
        private void refreshAO()
        {
            ao = FuncMisc.refreshButton(button_AO, FormMain.pathENBSeriesINI, "EFFECT", "EnableAmbientOcclusion", null, false);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_SAA_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathENBLocalINI, "ANTIALIASING", "EnableSubPixelAA", (!saa).ToString().ToLower());
            refreshSAA();
        }
        private void refreshSAA()
        {
            saa = FuncMisc.refreshButton(button_SAA, FormMain.pathENBLocalINI, "ANTIALIASING", "EnableSubPixelAA", null, false);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_TAA_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathENBLocalINI, "ANTIALIASING", "EnableTemporalAA", (!taa).ToString().ToLower());
            refreshTAA();
        }
        private void refreshTAA()
        {
            taa = FuncMisc.refreshButton(button_TAA, FormMain.pathENBLocalINI, "ANTIALIASING", "EnableTemporalAA", null, false);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_EAA_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathENBLocalINI, "ANTIALIASING", "EnableEdgeAA", (!eaa).ToString().ToLower());
            refreshEAA();
        }
        private void refreshEAA()
        {
            eaa = FuncMisc.refreshButton(button_EAA, FormMain.pathENBLocalINI, "ANTIALIASING", "EnableEdgeAA", null, false);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_AF_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathENBLocalINI, "ENGINE", "ForceAnisotropicFiltering", (!af).ToString().ToLower());
            refreshAF();
        }
        private void comboBox_AF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (af)
            {
                FuncParser.iniWrite(FormMain.pathENBLocalINI, "ENGINE", "MaxAnisotropy", comboBox_AF.SelectedItem.ToString());
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iMaxAnisotropy", comboBox_AF.SelectedItem.ToString());
            }
        }
        private void refreshAF()
        {
            af = FuncMisc.refreshButton(button_AF, FormMain.pathENBLocalINI, "ENGINE", "ForceAnisotropicFiltering", null, false);
            if (af)
            {
                FuncMisc.refreshComboBox(comboBox_AF, new List<double>() { 0, 2, 4, 8, 16 }, FuncParser.intRead(FormMain.pathENBLocalINI, "ENGINE", "MaxAnisotropy"), false, comboBox_AF_SelectedIndexChanged);
            }
            else
            {
                comboBox_AF.SelectedIndex = -1;
            }
            comboBox_AF.Enabled = af;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_FPS_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathENBLocalINI, "LIMITER", "EnableFPSLimit", (!fps).ToString().ToLower());
            refreshFPS();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (fps)
            {
                FormMain.maxFPS = numericUpDown1.Value;
                FuncSettings.physicsFPS();
            }
        }
        private void refreshFPS()
        {
            fps = (FormMain.setupENB == 2 && FuncMisc.refreshButton(button_FPS, FormMain.pathENBLocalINI, "LIMITER", "EnableFPSLimit", null, false)) || (FormMain.setupENB == 1 && File.Exists(FormMain.pathGameFolder + "d3d9.ini"));
            if (FormMain.setupENB == 1)
            {
                FuncMisc.refreshButton(button_FPS, "", "", "", null, false);
            }
            numericUpDown1.Value = FormMain.maxFPS;
            numericUpDown1.Enabled = fps;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void comboBox_ReservedMemory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File.Exists(FormMain.pathENBLocalINI))
            {
                FuncParser.iniWrite(FormMain.pathENBLocalINI, "MEMORY", "ReservedMemorySizeMb", comboBox_ReservedMemory.SelectedItem.ToString());
            }
        }
        private void refreshReservedMemory()
        {
            comboBox_ReservedMemory.Enabled = File.Exists(FormMain.pathENBLocalINI);
            FuncMisc.refreshComboBox(comboBox_ReservedMemory, new List<double>() { 64, 128, 256, 384, 512, 640, 768, 896, 1024 }, FuncParser.intRead(FormMain.pathENBLocalINI, "MEMORY", "ReservedMemorySizeMb"), false, comboBox_ReservedMemory_SelectedIndexChanged);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_ExpandMemory_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathENBLocalINI, "MEMORY", "ExpandSystemMemoryX64", (!expandmemory).ToString().ToLower());
            refreshExpandMemory();
        }
        private void refreshExpandMemory()
        {
            expandmemory = FuncMisc.refreshButton(button_ExpandMemory, FormMain.pathENBLocalINI, "MEMORY", "ExpandSystemMemoryX64", null, false);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_Compress_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathENBLocalINI, "MEMORY", "EnableCompression", (!compress).ToString().ToLower());
            refreshCompressMemory();
        }
        private void refreshCompressMemory()
        {
            compress = FuncMisc.refreshButton(button_Compress, FormMain.pathENBLocalINI, "MEMORY", "EnableCompression", null, false);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_AutoMemory_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathENBLocalINI, "MEMORY", "AutodetectVideoMemorySize", (!autovram).ToString().ToLower());
            refreshAutoDetect();
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathENBLocalINI, "MEMORY", "VideoMemorySizeMb", numericUpDown2.Value.ToString());
            FormMain.memorySizeENB = numericUpDown2.Value;
        }
        private void refreshAutoDetect()
        {
            autovram = FuncMisc.refreshButton(button_AutoMemory, FormMain.pathENBLocalINI, "MEMORY", "AutodetectVideoMemorySize", null, false);
            FuncParser.iniWrite(FormMain.pathENBLocalINI, "MEMORY", "VideoMemorySizeMb", FormMain.memorySizeENB.ToString());
            numericUpDown2.Enabled = !autovram && button_AutoMemory.Enabled;
            numericUpDown2.Value = FormMain.memorySizeENB;
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