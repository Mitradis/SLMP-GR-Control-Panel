using System;
using System.IO;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public partial class FormPrograms : Form
    {
        public FormPrograms()
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
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            label2.ForeColor = System.Drawing.SystemColors.ControlLight;
        }
        private void langTranslateEN()
        {
            label2.Text = "Unpack programs at " + Environment.NewLine + "the root of the game:";
        }
        private void FormPrograms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button_Close_Click(this, new EventArgs());
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_UnpackCreationKit_Click(object sender, EventArgs e)
        {
            programsUnpack("CREATIONKIT.rar");
        }
        private void button_UnpackTESVEdit_Click(object sender, EventArgs e)
        {
            programsUnpack("TES5EDIT.rar");
        }
        private void button_UnpackLodGEN_Click(object sender, EventArgs e)
        {
            programsUnpack("TES5LODGEN.rar");
        }
        private void programsUnpack(string FileName)
        {
            FuncMisc.toggleButtons(this, false);
            FuncMisc.unpackRAR(FormMain.pathProgramFiles + FileName);
            FuncMisc.toggleButtons(this, true);
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