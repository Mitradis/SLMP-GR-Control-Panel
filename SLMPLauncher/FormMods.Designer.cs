namespace SLMPLauncher
{
    partial class FormMods
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_ModInstall;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_ModUnInstall;

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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_ModInstall = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_ModUnInstall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(8, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(240, 191);
            this.listBox1.TabIndex = 3;
            this.listBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Файлы из Skyrim\\CPFiles";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_ModInstall
            // 
            this.button_ModInstall.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ModInstall.Location = new System.Drawing.Point(7, 229);
            this.button_ModInstall.Name = "button_ModInstall";
            this.button_ModInstall.Size = new System.Drawing.Size(117, 30);
            this.button_ModInstall.TabIndex = 1;
            this.button_ModInstall.TabStop = false;
            this.button_ModInstall.Text = "Установить";
            this.button_ModInstall.UseVisualStyleBackColor = true;
            this.button_ModInstall.Click += new System.EventHandler(this.button_ModInstall_Click);
            // 
            // button_Close
            // 
            this.button_Close.BackColor = System.Drawing.Color.Transparent;
            this.button_Close.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonClose;
            this.button_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Close.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Close.FlatAppearance.BorderSize = 0;
            this.button_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.Location = new System.Drawing.Point(223, 8);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(25, 25);
            this.button_Close.TabIndex = 4;
            this.button_Close.TabStop = false;
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            this.button_Close.MouseEnter += new System.EventHandler(this.buttonClose_MouseEnter);
            this.button_Close.MouseLeave += new System.EventHandler(this.buttonClose_MouseLeave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 266);
            this.label1.TabIndex = 0;
            // 
            // button_ModUnInstall
            // 
            this.button_ModUnInstall.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ModUnInstall.Location = new System.Drawing.Point(132, 229);
            this.button_ModUnInstall.Name = "button_ModUnInstall";
            this.button_ModUnInstall.Size = new System.Drawing.Size(117, 30);
            this.button_ModUnInstall.TabIndex = 2;
            this.button_ModUnInstall.TabStop = false;
            this.button_ModUnInstall.Text = "Удалить";
            this.button_ModUnInstall.UseVisualStyleBackColor = true;
            this.button_ModUnInstall.Click += new System.EventHandler(this.button_ModUnInstall_Click);
            // 
            // FormMods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SLMPLauncher.Properties.Resources.FormBackgroundNone;
            this.ClientSize = new System.Drawing.Size(256, 266);
            this.ControlBox = false;
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_ModUnInstall);
            this.Controls.Add(this.button_ModInstall);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMods";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SLMP: Mods";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMods_KeyDown);
            this.ResumeLayout(false);

        }
    }
}