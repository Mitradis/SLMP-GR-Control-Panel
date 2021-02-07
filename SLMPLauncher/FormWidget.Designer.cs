namespace SLMPLauncher
{
    partial class FormWidget
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button button_EN;
        private System.Windows.Forms.Button button_RU;
        private System.Windows.Forms.Button button_Updates;
        private System.Windows.Forms.ComboBox comboBox_Styles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.button_EN = new System.Windows.Forms.Button();
            this.button_RU = new System.Windows.Forms.Button();
            this.button_Updates = new System.Windows.Forms.Button();
            this.comboBox_Styles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button_EN
            // 
            this.button_EN.BackgroundImage = global::SLMPLauncher.Properties.Resources.ENoff;
            this.button_EN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_EN.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_EN.FlatAppearance.BorderSize = 0;
            this.button_EN.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_EN.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_EN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_EN.Location = new System.Drawing.Point(169, 13);
            this.button_EN.Name = "button_EN";
            this.button_EN.Size = new System.Drawing.Size(56, 34);
            this.button_EN.TabIndex = 3;
            this.button_EN.UseVisualStyleBackColor = false;
            this.button_EN.Click += new System.EventHandler(this.button_EN_Click);
            // 
            // button_RU
            // 
            this.button_RU.BackgroundImage = global::SLMPLauncher.Properties.Resources.RU;
            this.button_RU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_RU.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_RU.FlatAppearance.BorderSize = 0;
            this.button_RU.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_RU.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_RU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_RU.Location = new System.Drawing.Point(107, 13);
            this.button_RU.Name = "button_RU";
            this.button_RU.Size = new System.Drawing.Size(56, 34);
            this.button_RU.TabIndex = 2;
            this.button_RU.UseVisualStyleBackColor = false;
            this.button_RU.Click += new System.EventHandler(this.button_RU_Click);
            // 
            // button_Updates
            // 
            this.button_Updates.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Updates.Location = new System.Drawing.Point(238, 13);
            this.button_Updates.Name = "button_Updates";
            this.button_Updates.Size = new System.Drawing.Size(118, 34);
            this.button_Updates.TabIndex = 4;
            this.button_Updates.Text = "Обновления";
            this.button_Updates.UseVisualStyleBackColor = true;
            this.button_Updates.Click += new System.EventHandler(this.button_Updates_Click);
            // 
            // comboBox_Styles
            // 
            this.comboBox_Styles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Styles.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_Styles.FormattingEnabled = true;
            this.comboBox_Styles.Items.AddRange(new object[] {
            "Светлый",
            "Темный"});
            this.comboBox_Styles.Location = new System.Drawing.Point(8, 29);
            this.comboBox_Styles.Name = "comboBox_Styles";
            this.comboBox_Styles.Size = new System.Drawing.Size(84, 23);
            this.comboBox_Styles.TabIndex = 1;
            this.comboBox_Styles.SelectedIndexChanged += new System.EventHandler(this.comboBox_Styles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 60);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(7, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Стиль:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Location = new System.Drawing.Point(99, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1, 60);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox2.Location = new System.Drawing.Point(231, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1, 60);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // FormWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::SLMPLauncher.Properties.Resources.FormBackgroundNone;
            this.ClientSize = new System.Drawing.Size(363, 60);
            this.ControlBox = false;
            this.Controls.Add(this.button_EN);
            this.Controls.Add(this.button_RU);
            this.Controls.Add(this.button_Updates);
            this.Controls.Add(this.comboBox_Styles);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWidget";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }
    }
}