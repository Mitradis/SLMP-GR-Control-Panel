using System.Collections.Generic;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public partial class FormWidget : Form
    {
        FormMain mainFormStyle = null;

        public FormWidget()
        {
            InitializeComponent();
            FuncMisc.setFormFont(this);
            if (FormMain.numberStyle > 1)
            {
                ImageBackgroundImage();
            }
            if (FormMain.langTranslate == "EN")
            {
                langTranslateEN();
            }
            else
            {
                refreshCB2();
            }
            if (FuncParser.readAsBool(FormMain.pathLauncherINI, "General", "HideWebButtons"))
            {
                ClientSize = new System.Drawing.Size(232, 60);
                label1.Size = new System.Drawing.Size(232, 60);
                pictureBox4.Visible = false;
                button_Updates.Visible = false;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void ImageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            label2.ForeColor = System.Drawing.SystemColors.ControlLight;
        }
        private void langTranslateEN()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new object[] { "Bright", "Dark" });
            refreshCB2();
            label2.Text = "Style:";
            button_Updates.Text = "Updates";
            pictureBox3.BackgroundImage = Properties.Resources.EN;
            pictureBox2.BackgroundImage = Properties.Resources.RUoff;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            FormMain.numberStyle = comboBox2.SelectedIndex + 1;
            mainFormStyle = Owner as FormMain;
            mainFormStyle.refreshStyle();
            if (comboBox2.SelectedIndex == 0)
            {
                BackgroundImage = Properties.Resources.FormBackgroundNone;
                label2.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                ImageBackgroundImage();
            }
        }
        private void refreshCB2()
        {
            FuncMisc.refreshComboBox(comboBox2, new List<double>() { 1, 2 }, FormMain.numberStyle, false, comboBox2_SelectedIndexChanged);
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void pictureBox2_Click(object sender, System.EventArgs e)
        {
            FormMain.langTranslate = "RU";
            mainFormStyle = Owner as FormMain;
            mainFormStyle.setLangTranslateRU();
            label2.Text = "Стиль:";
            button_Updates.Text = "Обновления";
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new object[] { "Светлый", "Темный" });
            refreshCB2();
            pictureBox2.BackgroundImage = Properties.Resources.RU;
            pictureBox3.BackgroundImage = Properties.Resources.ENoff;
        }
        private void pictureBox3_Click(object sender, System.EventArgs e)
        {
            FormMain.langTranslate = "EN";
            mainFormStyle = Owner as FormMain;
            mainFormStyle.setLangTranslateEN();
            pictureBox2.BackgroundImage = Properties.Resources.RUoff;
            langTranslateEN();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_Updates_Click(object sender, System.EventArgs e)
        {
            var form = new FormUpdates();
            form.ShowDialog(this.Owner);
            form = null;
        }
    }
}