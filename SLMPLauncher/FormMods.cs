using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public partial class FormMods : Form
    {
        public static string pathCPFiles = FormMain.pathGameFolder + @"Skyrim\CPFiles\";
        string confirmDelete = "Удалить мод?";
        string confirmTitle = "Подтверждение";
        string noFileSelect = "Не выбран файл.";
        string noUninstalFile = "Нет .txt файла инструкции.";

        public FormMods()
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
            refreshFileList();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            FuncMisc.textColor(this, System.Drawing.SystemColors.ControlLight, System.Drawing.Color.FromArgb(30, 30, 30), false);
        }
        private void langTranslateEN()
        {
            button_ModInstall.Text = "Install";
            button_ModUnInstall.Text = "UnInstall";
            confirmDelete = "Delete mod?";
            confirmTitle = "Confirm";
            label3.Text = @"Files from Skyrim\CPFiles";
            noFileSelect = "No file select.";
            noUninstalFile = "No .txt instruction file.";
        }
        private void FormMods_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button_Close_Click(this, new EventArgs());
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void refreshFileList()
        {
            if (Directory.Exists(pathCPFiles))
            {
                foreach (string line in Directory.GetFiles(pathCPFiles, "*.rar").OrderBy(f => f))
                {
                    listBox1.Items.Add(Path.GetFileName(line));
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_ModInstall_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                fileUnpack(listBox1.SelectedItem.ToString());
                if (listBox1.SelectedItem.ToString().ToLower().Contains("frostfall") || listBox1.SelectedItem.ToString().ToLower().Contains("disablefasttravel"))
                {
                    FuncMisc.wideScreenMods();
                }
            }
            else
            {
                MessageBox.Show(noFileSelect);
            }
        }
        private void fileUnpack(string filename)
        {
            FuncMisc.toggleButtons(this, false);
            listBox1.Enabled = false;
            FuncMisc.unpackRAR(pathCPFiles + filename);
            FuncMisc.toggleButtons(this, true);
            listBox1.Enabled = true;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_ModUnInstall_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                DialogResult dialogResult = MessageBox.Show(confirmDelete, confirmTitle, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (File.Exists(pathCPFiles + listBox1.SelectedItem.ToString().Replace(".rar", ".txt")))
                    {
                        foreach (string line in File.ReadLines(pathCPFiles + listBox1.SelectedItem.ToString().Replace(".rar", ".txt")))
                        {
                            FuncFiles.deleteAny(FormMain.pathGameFolder + line);
                        }
                        if (listBox1.SelectedItem.ToString().ToUpper().Contains("OSA") && File.Exists(FormMain.pathFNISRAR))
                        {
                            FuncMisc.unpackRAR(FormMain.pathFNISRAR);
                        }
                        FuncClear.emptyFolder(FormMain.pathGameFolder);
                    }
                    else
                    {
                        MessageBox.Show(noUninstalFile);
                    }
                }
            }
            else
            {
                MessageBox.Show(noFileSelect);
            }
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