namespace SLMPLauncher
{
	partial class FormPrograms
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button_UnpackCreationKit;
        private System.Windows.Forms.Button button_UnpackTESVEdit;
		private System.Windows.Forms.Button button_UnpackLodGEN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Label label1;

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
            this.button_UnpackCreationKit = new System.Windows.Forms.Button();
            this.button_UnpackTESVEdit = new System.Windows.Forms.Button();
            this.button_UnpackLodGEN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_UnpackCreationKit
            // 
            this.button_UnpackCreationKit.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_UnpackCreationKit.Location = new System.Drawing.Point(80, 62);
            this.button_UnpackCreationKit.Name = "button_UnpackCreationKit";
            this.button_UnpackCreationKit.Size = new System.Drawing.Size(130, 30);
            this.button_UnpackCreationKit.TabIndex = 1;
            this.button_UnpackCreationKit.TabStop = false;
            this.button_UnpackCreationKit.Text = "Creation Kit";
            this.button_UnpackCreationKit.UseVisualStyleBackColor = true;
            this.button_UnpackCreationKit.Click += new System.EventHandler(this.button_UnpackCreationKit_Click);
            // 
            // button_UnpackTESVEdit
            // 
            this.button_UnpackTESVEdit.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_UnpackTESVEdit.Location = new System.Drawing.Point(7, 98);
            this.button_UnpackTESVEdit.Name = "button_UnpackTESVEdit";
            this.button_UnpackTESVEdit.Size = new System.Drawing.Size(130, 30);
            this.button_UnpackTESVEdit.TabIndex = 2;
            this.button_UnpackTESVEdit.TabStop = false;
            this.button_UnpackTESVEdit.Text = "TES5Edit";
            this.button_UnpackTESVEdit.UseVisualStyleBackColor = true;
            this.button_UnpackTESVEdit.Click += new System.EventHandler(this.button_UnpackTESVEdit_Click);
            // 
            // button_UnpackLodGEN
            // 
            this.button_UnpackLodGEN.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_UnpackLodGEN.Location = new System.Drawing.Point(153, 98);
            this.button_UnpackLodGEN.Name = "button_UnpackLodGEN";
            this.button_UnpackLodGEN.Size = new System.Drawing.Size(130, 30);
            this.button_UnpackLodGEN.TabIndex = 3;
            this.button_UnpackLodGEN.TabStop = false;
            this.button_UnpackLodGEN.Text = "TES5LodGen";
            this.button_UnpackLodGEN.UseVisualStyleBackColor = true;
            this.button_UnpackLodGEN.Click += new System.EventHandler(this.button_UnpackLodGEN_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 49);
            this.label2.TabIndex = 0;
            this.label2.Text = "Распаковка программ\r\nв корень игры:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.button_Close.Location = new System.Drawing.Point(257, 8);
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
            this.label1.Size = new System.Drawing.Size(290, 135);
            this.label1.TabIndex = 0;
            // 
            // FormPrograms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SLMPLauncher.Properties.Resources.FormBackgroundNone;
            this.ClientSize = new System.Drawing.Size(290, 135);
            this.ControlBox = false;
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_UnpackLodGEN);
            this.Controls.Add(this.button_UnpackTESVEdit);
            this.Controls.Add(this.button_UnpackCreationKit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrograms";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SLMP: Programs Install";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPrograms_KeyDown);
            this.ResumeLayout(false);

        }
	}
}
