namespace SLMPLauncher
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button button_AddIgnoreFiles;
        private System.Windows.Forms.Button button_ClearDirectory;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_DSR;
        private System.Windows.Forms.Button button_ENB;
        private System.Windows.Forms.Button button_FNIS;
        private System.Windows.Forms.Button button_GameFolder;
        private System.Windows.Forms.Button button_Help;
        private System.Windows.Forms.Button button_Minimize;
        private System.Windows.Forms.Button button_Mods;
        private System.Windows.Forms.Button button_MyDocs;
        private System.Windows.Forms.Button button_Options;
        private System.Windows.Forms.Button button_Programs;
        private System.Windows.Forms.Button button_ProgramsFolder;
        private System.Windows.Forms.Button button_ResetSettings;
        private System.Windows.Forms.Button button_Skyrim;
        private System.Windows.Forms.Button button_Widget;
        private System.Windows.Forms.Button button_WryeBash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.button_AddIgnoreFiles = new System.Windows.Forms.Button();
            this.button_ClearDirectory = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_DSR = new System.Windows.Forms.Button();
            this.button_ENB = new System.Windows.Forms.Button();
            this.button_FNIS = new System.Windows.Forms.Button();
            this.button_GameFolder = new System.Windows.Forms.Button();
            this.button_Help = new System.Windows.Forms.Button();
            this.button_Minimize = new System.Windows.Forms.Button();
            this.button_Mods = new System.Windows.Forms.Button();
            this.button_MyDocs = new System.Windows.Forms.Button();
            this.button_Options = new System.Windows.Forms.Button();
            this.button_Programs = new System.Windows.Forms.Button();
            this.button_ProgramsFolder = new System.Windows.Forms.Button();
            this.button_ResetSettings = new System.Windows.Forms.Button();
            this.button_Skyrim = new System.Windows.Forms.Button();
            this.button_Widget = new System.Windows.Forms.Button();
            this.button_WryeBash = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button_AddIgnoreFiles
            // 
            this.button_AddIgnoreFiles.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonOne;
            this.button_AddIgnoreFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_AddIgnoreFiles.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_AddIgnoreFiles.FlatAppearance.BorderSize = 0;
            this.button_AddIgnoreFiles.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_AddIgnoreFiles.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_AddIgnoreFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AddIgnoreFiles.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_AddIgnoreFiles.Location = new System.Drawing.Point(448, 84);
            this.button_AddIgnoreFiles.Name = "button_AddIgnoreFiles";
            this.button_AddIgnoreFiles.Size = new System.Drawing.Size(28, 30);
            this.button_AddIgnoreFiles.TabIndex = 10;
            this.button_AddIgnoreFiles.Text = "F";
            this.button_AddIgnoreFiles.UseVisualStyleBackColor = false;
            this.button_AddIgnoreFiles.Click += new System.EventHandler(this.button_AddIgnoreFiles_Click);
            this.button_AddIgnoreFiles.MouseEnter += new System.EventHandler(this.button_Add_MouseEnter);
            this.button_AddIgnoreFiles.MouseLeave += new System.EventHandler(this.button_Add_MouseLeave);
            // 
            // button_ClearDirectory
            // 
            this.button_ClearDirectory.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonClear;
            this.button_ClearDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ClearDirectory.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_ClearDirectory.FlatAppearance.BorderSize = 0;
            this.button_ClearDirectory.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_ClearDirectory.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_ClearDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ClearDirectory.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ClearDirectory.Location = new System.Drawing.Point(298, 84);
            this.button_ClearDirectory.Name = "button_ClearDirectory";
            this.button_ClearDirectory.Size = new System.Drawing.Size(147, 30);
            this.button_ClearDirectory.TabIndex = 9;
            this.button_ClearDirectory.Text = "Очистка";
            this.button_ClearDirectory.UseVisualStyleBackColor = false;
            this.button_ClearDirectory.Click += new System.EventHandler(this.button_ClearDirectory_Click);
            this.button_ClearDirectory.MouseEnter += new System.EventHandler(this.button_ClearDirectory_MouseEnter);
            this.button_ClearDirectory.MouseLeave += new System.EventHandler(this.button_ClearDirectory_MouseLeave);
            // 
            // button_Close
            // 
            this.button_Close.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonClose;
            this.button_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Close.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_Close.FlatAppearance.BorderSize = 0;
            this.button_Close.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Close.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.Location = new System.Drawing.Point(451, 12);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(25, 25);
            this.button_Close.TabIndex = 17;
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            this.button_Close.MouseEnter += new System.EventHandler(this.button_Close_MouseEnter);
            this.button_Close.MouseLeave += new System.EventHandler(this.button_Close_MouseLeave);
            // 
            // button_DSR
            // 
            this.button_DSR.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonHalf;
            this.button_DSR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_DSR.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_DSR.FlatAppearance.BorderSize = 0;
            this.button_DSR.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_DSR.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_DSR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DSR.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_DSR.Location = new System.Drawing.Point(12, 84);
            this.button_DSR.Name = "button_DSR";
            this.button_DSR.Size = new System.Drawing.Size(86, 30);
            this.button_DSR.TabIndex = 1;
            this.button_DSR.Text = "DSR";
            this.button_DSR.UseVisualStyleBackColor = false;
            this.button_DSR.Click += new System.EventHandler(this.button_DSR_Click);
            this.button_DSR.MouseEnter += new System.EventHandler(this.button_Half_MouseEnter);
            this.button_DSR.MouseLeave += new System.EventHandler(this.button_Half_MouseLeave);
            // 
            // button_ENB
            // 
            this.button_ENB.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonHalf;
            this.button_ENB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ENB.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_ENB.FlatAppearance.BorderSize = 0;
            this.button_ENB.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_ENB.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_ENB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ENB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ENB.Location = new System.Drawing.Point(12, 156);
            this.button_ENB.Name = "button_ENB";
            this.button_ENB.Size = new System.Drawing.Size(86, 30);
            this.button_ENB.TabIndex = 4;
            this.button_ENB.Text = "ENB";
            this.button_ENB.UseVisualStyleBackColor = false;
            this.button_ENB.Click += new System.EventHandler(this.button_ENB_Click);
            this.button_ENB.MouseEnter += new System.EventHandler(this.button_Half_MouseEnter);
            this.button_ENB.MouseLeave += new System.EventHandler(this.button_Half_MouseLeave);
            // 
            // button_FNIS
            // 
            this.button_FNIS.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonHalf;
            this.button_FNIS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_FNIS.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_FNIS.FlatAppearance.BorderSize = 0;
            this.button_FNIS.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_FNIS.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_FNIS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_FNIS.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_FNIS.Location = new System.Drawing.Point(104, 84);
            this.button_FNIS.Name = "button_FNIS";
            this.button_FNIS.Size = new System.Drawing.Size(86, 30);
            this.button_FNIS.TabIndex = 2;
            this.button_FNIS.Text = "FNIS";
            this.button_FNIS.UseVisualStyleBackColor = false;
            this.button_FNIS.Click += new System.EventHandler(this.button_FNIS_Click);
            this.button_FNIS.MouseEnter += new System.EventHandler(this.button_Half_MouseEnter);
            this.button_FNIS.MouseLeave += new System.EventHandler(this.button_Half_MouseLeave);
            // 
            // button_GameFolder
            // 
            this.button_GameFolder.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonFull;
            this.button_GameFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_GameFolder.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_GameFolder.FlatAppearance.BorderSize = 0;
            this.button_GameFolder.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_GameFolder.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_GameFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_GameFolder.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_GameFolder.Location = new System.Drawing.Point(298, 192);
            this.button_GameFolder.Name = "button_GameFolder";
            this.button_GameFolder.Size = new System.Drawing.Size(178, 30);
            this.button_GameFolder.TabIndex = 13;
            this.button_GameFolder.Text = "Директория Игры";
            this.button_GameFolder.UseVisualStyleBackColor = false;
            this.button_GameFolder.Click += new System.EventHandler(this.button_GameFolder_Click);
            this.button_GameFolder.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_GameFolder.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button_Help
            // 
            this.button_Help.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonHelp;
            this.button_Help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Help.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_Help.FlatAppearance.BorderSize = 0;
            this.button_Help.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Help.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Help.Location = new System.Drawing.Point(12, 12);
            this.button_Help.Name = "button_Help";
            this.button_Help.Size = new System.Drawing.Size(25, 25);
            this.button_Help.TabIndex = 14;
            this.button_Help.UseVisualStyleBackColor = false;
            this.button_Help.Click += new System.EventHandler(this.button_Help_Click);
            this.button_Help.MouseEnter += new System.EventHandler(this.button_Help_MouseEnter);
            this.button_Help.MouseLeave += new System.EventHandler(this.button_Help_MouseLeave);
            // 
            // button_Minimize
            // 
            this.button_Minimize.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonMinimize;
            this.button_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Minimize.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_Minimize.FlatAppearance.BorderSize = 0;
            this.button_Minimize.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Minimize.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Minimize.Location = new System.Drawing.Point(420, 12);
            this.button_Minimize.Name = "button_Minimize";
            this.button_Minimize.Size = new System.Drawing.Size(25, 25);
            this.button_Minimize.TabIndex = 16;
            this.button_Minimize.UseVisualStyleBackColor = false;
            this.button_Minimize.Click += new System.EventHandler(this.button_Minimize_Click);
            this.button_Minimize.MouseEnter += new System.EventHandler(this.button_Minimize_MouseEnter);
            this.button_Minimize.MouseLeave += new System.EventHandler(this.button_Minimize_MouseLeave);
            // 
            // button_Mods
            // 
            this.button_Mods.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonHalf;
            this.button_Mods.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Mods.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_Mods.FlatAppearance.BorderSize = 0;
            this.button_Mods.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Mods.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Mods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Mods.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Mods.Location = new System.Drawing.Point(104, 156);
            this.button_Mods.Name = "button_Mods";
            this.button_Mods.Size = new System.Drawing.Size(86, 30);
            this.button_Mods.TabIndex = 5;
            this.button_Mods.Text = "Моды";
            this.button_Mods.UseVisualStyleBackColor = false;
            this.button_Mods.Click += new System.EventHandler(this.button_Mods_Click);
            this.button_Mods.MouseEnter += new System.EventHandler(this.button_Half_MouseEnter);
            this.button_Mods.MouseLeave += new System.EventHandler(this.button_Half_MouseLeave);
            // 
            // button_MyDocs
            // 
            this.button_MyDocs.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonFull;
            this.button_MyDocs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_MyDocs.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_MyDocs.FlatAppearance.BorderSize = 0;
            this.button_MyDocs.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_MyDocs.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_MyDocs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_MyDocs.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_MyDocs.Location = new System.Drawing.Point(12, 192);
            this.button_MyDocs.Name = "button_MyDocs";
            this.button_MyDocs.Size = new System.Drawing.Size(178, 30);
            this.button_MyDocs.TabIndex = 6;
            this.button_MyDocs.Text = "Мои Документы";
            this.button_MyDocs.UseVisualStyleBackColor = false;
            this.button_MyDocs.Click += new System.EventHandler(this.button_MyDocs_Click);
            this.button_MyDocs.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_MyDocs.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button_Options
            // 
            this.button_Options.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonFull;
            this.button_Options.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Options.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_Options.FlatAppearance.BorderSize = 0;
            this.button_Options.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Options.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Options.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Options.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Options.Location = new System.Drawing.Point(12, 120);
            this.button_Options.Name = "button_Options";
            this.button_Options.Size = new System.Drawing.Size(178, 30);
            this.button_Options.TabIndex = 3;
            this.button_Options.Text = "Настройки Игры";
            this.button_Options.UseVisualStyleBackColor = false;
            this.button_Options.Click += new System.EventHandler(this.button_Options_Click);
            this.button_Options.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_Options.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button_Programs
            // 
            this.button_Programs.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonFull;
            this.button_Programs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Programs.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_Programs.FlatAppearance.BorderSize = 0;
            this.button_Programs.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Programs.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Programs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Programs.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Programs.Location = new System.Drawing.Point(298, 120);
            this.button_Programs.Name = "button_Programs";
            this.button_Programs.Size = new System.Drawing.Size(178, 30);
            this.button_Programs.TabIndex = 11;
            this.button_Programs.Text = "Программы";
            this.button_Programs.UseVisualStyleBackColor = false;
            this.button_Programs.Click += new System.EventHandler(this.button_Programs_Click);
            this.button_Programs.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_Programs.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button_ProgramsFolder
            // 
            this.button_ProgramsFolder.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonFull;
            this.button_ProgramsFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ProgramsFolder.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_ProgramsFolder.FlatAppearance.BorderSize = 0;
            this.button_ProgramsFolder.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_ProgramsFolder.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_ProgramsFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ProgramsFolder.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ProgramsFolder.Location = new System.Drawing.Point(298, 156);
            this.button_ProgramsFolder.Name = "button_ProgramsFolder";
            this.button_ProgramsFolder.Size = new System.Drawing.Size(178, 30);
            this.button_ProgramsFolder.TabIndex = 12;
            this.button_ProgramsFolder.Text = "Все Программы";
            this.button_ProgramsFolder.UseVisualStyleBackColor = false;
            this.button_ProgramsFolder.Click += new System.EventHandler(this.button_ProgramsFolder_Click);
            this.button_ProgramsFolder.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_ProgramsFolder.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button_ResetSettings
            // 
            this.button_ResetSettings.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonFull;
            this.button_ResetSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ResetSettings.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_ResetSettings.FlatAppearance.BorderSize = 0;
            this.button_ResetSettings.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_ResetSettings.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_ResetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ResetSettings.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ResetSettings.Location = new System.Drawing.Point(298, 48);
            this.button_ResetSettings.Name = "button_ResetSettings";
            this.button_ResetSettings.Size = new System.Drawing.Size(178, 30);
            this.button_ResetSettings.TabIndex = 8;
            this.button_ResetSettings.Text = "Сброс Настроек";
            this.button_ResetSettings.UseVisualStyleBackColor = false;
            this.button_ResetSettings.Click += new System.EventHandler(this.button_ResetSettings_Click);
            this.button_ResetSettings.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_ResetSettings.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button_Skyrim
            // 
            this.button_Skyrim.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonlogo;
            this.button_Skyrim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Skyrim.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_Skyrim.FlatAppearance.BorderSize = 0;
            this.button_Skyrim.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Skyrim.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Skyrim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Skyrim.Location = new System.Drawing.Point(197, 48);
            this.button_Skyrim.Name = "button_Skyrim";
            this.button_Skyrim.Size = new System.Drawing.Size(94, 174);
            this.button_Skyrim.TabIndex = 7;
            this.button_Skyrim.UseVisualStyleBackColor = false;
            this.button_Skyrim.Click += new System.EventHandler(this.button_Skyrim_Click);
            this.button_Skyrim.MouseEnter += new System.EventHandler(this.button_Skyrim_MouseEnter);
            this.button_Skyrim.MouseLeave += new System.EventHandler(this.button_Skyrim_MouseLeave);
            // 
            // button_Widget
            // 
            this.button_Widget.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonWidget;
            this.button_Widget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Widget.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_Widget.FlatAppearance.BorderSize = 0;
            this.button_Widget.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Widget.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_Widget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Widget.Location = new System.Drawing.Point(43, 12);
            this.button_Widget.Name = "button_Widget";
            this.button_Widget.Size = new System.Drawing.Size(25, 25);
            this.button_Widget.TabIndex = 15;
            this.button_Widget.UseVisualStyleBackColor = false;
            this.button_Widget.Click += new System.EventHandler(this.button_Widget_Click);
            this.button_Widget.MouseEnter += new System.EventHandler(this.button_Widget_MouseEnter);
            this.button_Widget.MouseLeave += new System.EventHandler(this.button_Widget_MouseLeave);
            // 
            // button_WryeBash
            // 
            this.button_WryeBash.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonFull;
            this.button_WryeBash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_WryeBash.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button_WryeBash.FlatAppearance.BorderSize = 0;
            this.button_WryeBash.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.button_WryeBash.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.button_WryeBash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_WryeBash.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_WryeBash.Location = new System.Drawing.Point(12, 48);
            this.button_WryeBash.Name = "button_WryeBash";
            this.button_WryeBash.Size = new System.Drawing.Size(178, 30);
            this.button_WryeBash.TabIndex = 0;
            this.button_WryeBash.Text = "Wrye Bash";
            this.button_WryeBash.UseVisualStyleBackColor = false;
            this.button_WryeBash.Click += new System.EventHandler(this.button_WryeBash_Click);
            this.button_WryeBash.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_WryeBash.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(488, 234);
            this.label1.TabIndex = 0;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Multiselect = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_MainForm;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(488, 234);
            this.ControlBox = false;
            this.Controls.Add(this.button_AddIgnoreFiles);
            this.Controls.Add(this.button_ClearDirectory);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_DSR);
            this.Controls.Add(this.button_ENB);
            this.Controls.Add(this.button_FNIS);
            this.Controls.Add(this.button_GameFolder);
            this.Controls.Add(this.button_Help);
            this.Controls.Add(this.button_Minimize);
            this.Controls.Add(this.button_Mods);
            this.Controls.Add(this.button_MyDocs);
            this.Controls.Add(this.button_Options);
            this.Controls.Add(this.button_Programs);
            this.Controls.Add(this.button_ProgramsFolder);
            this.Controls.Add(this.button_ResetSettings);
            this.Controls.Add(this.button_Skyrim);
            this.Controls.Add(this.button_Widget);
            this.Controls.Add(this.button_WryeBash);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Skyrim Control Panel";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
            this.ResumeLayout(false);

        }
    }
}

