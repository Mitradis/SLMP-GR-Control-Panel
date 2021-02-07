namespace SLMPLauncher
{
    partial class FormPrograms
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_CreationKit;
        private System.Windows.Forms.Button button_TES5Edit;
        private System.Windows.Forms.Button button_TES5LODGen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

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
            this.button_Close = new System.Windows.Forms.Button();
            this.button_CreationKit = new System.Windows.Forms.Button();
            this.button_TES5Edit = new System.Windows.Forms.Button();
            this.button_TES5LODGen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.button_Close.Location = new System.Drawing.Point(257, 8);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(25, 25);
            this.button_Close.TabIndex = 1;
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.MouseEnter += new System.EventHandler(this.button_Close_MouseEnter);
            this.button_Close.MouseLeave += new System.EventHandler(this.button_Close_MouseLeave);
            // 
            // button_CreationKit
            // 
            this.button_CreationKit.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_CreationKit.Location = new System.Drawing.Point(80, 62);
            this.button_CreationKit.Name = "button_CreationKit";
            this.button_CreationKit.Size = new System.Drawing.Size(130, 30);
            this.button_CreationKit.TabIndex = 2;
            this.button_CreationKit.Text = "Creation Kit";
            this.button_CreationKit.UseVisualStyleBackColor = true;
            this.button_CreationKit.Click += new System.EventHandler(this.button_CreationKit_Click);
            // 
            // button_TES5Edit
            // 
            this.button_TES5Edit.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_TES5Edit.Location = new System.Drawing.Point(7, 98);
            this.button_TES5Edit.Name = "button_TES5Edit";
            this.button_TES5Edit.Size = new System.Drawing.Size(130, 30);
            this.button_TES5Edit.TabIndex = 3;
            this.button_TES5Edit.Text = "TES5Edit";
            this.button_TES5Edit.UseVisualStyleBackColor = true;
            this.button_TES5Edit.Click += new System.EventHandler(this.button_TES5Edit_Click);
            // 
            // button_TES5LODGen
            // 
            this.button_TES5LODGen.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_TES5LODGen.Location = new System.Drawing.Point(153, 98);
            this.button_TES5LODGen.Name = "button_TES5LODGen";
            this.button_TES5LODGen.Size = new System.Drawing.Size(130, 30);
            this.button_TES5LODGen.TabIndex = 4;
            this.button_TES5LODGen.Text = "TES5LodGen";
            this.button_TES5LODGen.UseVisualStyleBackColor = true;
            this.button_TES5LODGen.Click += new System.EventHandler(this.button_TES5LODGen_Click);
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
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 49);
            this.label2.TabIndex = 0;
            this.label2.Text = "Распаковка программ\r\nв корень игры:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormPrograms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SLMPLauncher.Properties.Resources.FormBackgroundNone;
            this.CancelButton = this.button_Close;
            this.ClientSize = new System.Drawing.Size(290, 135);
            this.ControlBox = false;
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_CreationKit);
            this.Controls.Add(this.button_TES5Edit);
            this.Controls.Add(this.button_TES5LODGen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrograms";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }
    }
}
