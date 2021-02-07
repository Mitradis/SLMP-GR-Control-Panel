namespace SLMPLauncher
{
    partial class FormUpdates
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button button_AboutUpdate;
        private System.Windows.Forms.Button button_CheckUpdate;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_UpdateCP;
        private System.Windows.Forms.ComboBox comboBox_Updates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.ProgressBar progressBar1;

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
            this.button_AboutUpdate = new System.Windows.Forms.Button();
            this.button_CheckUpdate = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_UpdateCP = new System.Windows.Forms.Button();
            this.comboBox_Updates = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // button_AboutUpdate
            // 
            this.button_AboutUpdate.Enabled = false;
            this.button_AboutUpdate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_AboutUpdate.Location = new System.Drawing.Point(192, 193);
            this.button_AboutUpdate.Name = "button_AboutUpdate";
            this.button_AboutUpdate.Size = new System.Drawing.Size(165, 30);
            this.button_AboutUpdate.TabIndex = 5;
            this.button_AboutUpdate.Text = "Об обновлении";
            this.button_AboutUpdate.UseVisualStyleBackColor = true;
            this.button_AboutUpdate.Click += new System.EventHandler(this.button_AboutUpdate_Click);
            // 
            // button_CheckUpdate
            // 
            this.button_CheckUpdate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_CheckUpdate.Location = new System.Drawing.Point(7, 193);
            this.button_CheckUpdate.Name = "button_CheckUpdate";
            this.button_CheckUpdate.Size = new System.Drawing.Size(165, 30);
            this.button_CheckUpdate.TabIndex = 4;
            this.button_CheckUpdate.Text = "Проверить";
            this.button_CheckUpdate.UseVisualStyleBackColor = true;
            this.button_CheckUpdate.Click += new System.EventHandler(this.button_CheckUpdate_Click);
            // 
            // button_Close
            // 
            this.button_Close.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonClose;
            this.button_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Close.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Close.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_Close.FlatAppearance.BorderSize = 0;
            this.button_Close.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Close.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.Location = new System.Drawing.Point(331, 8);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(25, 25);
            this.button_Close.TabIndex = 1;
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            this.button_Close.MouseEnter += new System.EventHandler(this.button_Close_MouseEnter);
            this.button_Close.MouseLeave += new System.EventHandler(this.button_Close_MouseLeave);
            // 
            // button_UpdateCP
            // 
            this.button_UpdateCP.Enabled = false;
            this.button_UpdateCP.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_UpdateCP.Location = new System.Drawing.Point(198, 44);
            this.button_UpdateCP.Name = "button_UpdateCP";
            this.button_UpdateCP.Size = new System.Drawing.Size(159, 30);
            this.button_UpdateCP.TabIndex = 2;
            this.button_UpdateCP.Text = "Не проверено";
            this.button_UpdateCP.UseVisualStyleBackColor = true;
            this.button_UpdateCP.Click += new System.EventHandler(this.button_UpdateCP_Click);
            // 
            // comboBox_Updates
            // 
            this.comboBox_Updates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Updates.Enabled = false;
            this.comboBox_Updates.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_Updates.FormattingEnabled = true;
            this.comboBox_Updates.Location = new System.Drawing.Point(8, 109);
            this.comboBox_Updates.Name = "comboBox_Updates";
            this.comboBox_Updates.Size = new System.Drawing.Size(348, 23);
            this.comboBox_Updates.TabIndex = 3;
            this.comboBox_Updates.SelectedIndexChanged += new System.EventHandler(this.comboBox_Updates_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 230);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Обновление ПУ:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(5, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Доступные файлы:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(198, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Не проверено";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(340, 20);
            this.label5.TabIndex = 0;
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(7, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(350, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "Обновление игры и панели управления";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox11.Location = new System.Drawing.Point(0, 39);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(364, 1);
            this.pictureBox11.TabIndex = 0;
            this.pictureBox11.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 171);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(348, 12);
            this.progressBar1.TabIndex = 0;
            // 
            // FormUpdates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SLMPLauncher.Properties.Resources.FormBackgroundNone;
            this.CancelButton = this.button_Close;
            this.ClientSize = new System.Drawing.Size(364, 230);
            this.ControlBox = false;
            this.Controls.Add(this.button_AboutUpdate);
            this.Controls.Add(this.button_CheckUpdate);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_UpdateCP);
            this.Controls.Add(this.comboBox_Updates);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUpdates";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);

        }
    }
}