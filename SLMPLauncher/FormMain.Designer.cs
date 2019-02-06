namespace SLMPLauncher
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button button_ClearDirectory;
        private System.Windows.Forms.Button button_ResetSettings;
        private System.Windows.Forms.Button button_DSRStart;
        private System.Windows.Forms.Button button_RemPrograms;
        private System.Windows.Forms.Button button_WryeBash;
        private System.Windows.Forms.Button button_ProgrammsFolder;
        private System.Windows.Forms.Button button_GameDirectory;
        private System.Windows.Forms.Button button_Skyrim;
        private System.Windows.Forms.Button button_ENBmenu;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button_FNISStart;
        private System.Windows.Forms.Button button_AddFileToIgnore;
        private System.Windows.Forms.Button button_AddFolderToIgnore;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_Mods;
        private System.Windows.Forms.Button button_Widget;
        private System.Windows.Forms.Button button_Minimize;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_Options;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Help;
        private System.Windows.Forms.Button button_MyDocs;

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
            this.button_ClearDirectory = new System.Windows.Forms.Button();
            this.button_ResetSettings = new System.Windows.Forms.Button();
            this.button_DSRStart = new System.Windows.Forms.Button();
            this.button_RemPrograms = new System.Windows.Forms.Button();
            this.button_WryeBash = new System.Windows.Forms.Button();
            this.button_ProgrammsFolder = new System.Windows.Forms.Button();
            this.button_GameDirectory = new System.Windows.Forms.Button();
            this.button_ENBmenu = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button_Skyrim = new System.Windows.Forms.Button();
            this.button_FNISStart = new System.Windows.Forms.Button();
            this.button_AddFileToIgnore = new System.Windows.Forms.Button();
            this.button_AddFolderToIgnore = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_Mods = new System.Windows.Forms.Button();
            this.button_Widget = new System.Windows.Forms.Button();
            this.button_Minimize = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_Options = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Help = new System.Windows.Forms.Button();
            this.button_MyDocs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_ClearDirectory
            // 
            this.button_ClearDirectory.BackColor = System.Drawing.Color.Transparent;
            this.button_ClearDirectory.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonClear;
            this.button_ClearDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ClearDirectory.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_ClearDirectory.FlatAppearance.BorderSize = 0;
            this.button_ClearDirectory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_ClearDirectory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_ClearDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ClearDirectory.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ClearDirectory.Location = new System.Drawing.Point(298, 84);
            this.button_ClearDirectory.Name = "button_ClearDirectory";
            this.button_ClearDirectory.Size = new System.Drawing.Size(116, 30);
            this.button_ClearDirectory.TabIndex = 10;
            this.button_ClearDirectory.TabStop = false;
            this.button_ClearDirectory.Text = "Очистка";
            this.button_ClearDirectory.UseVisualStyleBackColor = false;
            this.button_ClearDirectory.Click += new System.EventHandler(this.button_ClearDirectory_Click);
            this.button_ClearDirectory.MouseEnter += new System.EventHandler(this.buttonClearDirectory_MouseEnter);
            this.button_ClearDirectory.MouseLeave += new System.EventHandler(this.buttonClearDirectory_MouseLeave);
            // 
            // button_ResetSettings
            // 
            this.button_ResetSettings.BackColor = System.Drawing.Color.Transparent;
            this.button_ResetSettings.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonFull;
            this.button_ResetSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ResetSettings.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_ResetSettings.FlatAppearance.BorderSize = 0;
            this.button_ResetSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_ResetSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_ResetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ResetSettings.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ResetSettings.Location = new System.Drawing.Point(298, 48);
            this.button_ResetSettings.Name = "button_ResetSettings";
            this.button_ResetSettings.Size = new System.Drawing.Size(178, 30);
            this.button_ResetSettings.TabIndex = 9;
            this.button_ResetSettings.TabStop = false;
            this.button_ResetSettings.Text = "Сброс Настроек";
            this.button_ResetSettings.UseVisualStyleBackColor = false;
            this.button_ResetSettings.Click += new System.EventHandler(this.button_ResetSettings_Click);
            this.button_ResetSettings.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_ResetSettings.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button_DSRStart
            // 
            this.button_DSRStart.BackColor = System.Drawing.Color.Transparent;
            this.button_DSRStart.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonHalf;
            this.button_DSRStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_DSRStart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_DSRStart.FlatAppearance.BorderSize = 0;
            this.button_DSRStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_DSRStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_DSRStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DSRStart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_DSRStart.Location = new System.Drawing.Point(12, 84);
            this.button_DSRStart.Name = "button_DSRStart";
            this.button_DSRStart.Size = new System.Drawing.Size(86, 30);
            this.button_DSRStart.TabIndex = 2;
            this.button_DSRStart.TabStop = false;
            this.button_DSRStart.Text = "DSR";
            this.button_DSRStart.UseVisualStyleBackColor = false;
            this.button_DSRStart.Click += new System.EventHandler(this.button_DSRStart_Click);
            this.button_DSRStart.MouseEnter += new System.EventHandler(this.buttonH_MouseEnter);
            this.button_DSRStart.MouseLeave += new System.EventHandler(this.buttonH_MouseLeave);
            // 
            // button_RemPrograms
            // 
            this.button_RemPrograms.BackColor = System.Drawing.Color.Transparent;
            this.button_RemPrograms.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonFull;
            this.button_RemPrograms.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_RemPrograms.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_RemPrograms.FlatAppearance.BorderSize = 0;
            this.button_RemPrograms.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_RemPrograms.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_RemPrograms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_RemPrograms.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_RemPrograms.Location = new System.Drawing.Point(12, 192);
            this.button_RemPrograms.Name = "button_RemPrograms";
            this.button_RemPrograms.Size = new System.Drawing.Size(178, 30);
            this.button_RemPrograms.TabIndex = 7;
            this.button_RemPrograms.TabStop = false;
            this.button_RemPrograms.Text = "Программы";
            this.button_RemPrograms.UseVisualStyleBackColor = false;
            this.button_RemPrograms.Click += new System.EventHandler(this.button_RemPrograms_Click);
            this.button_RemPrograms.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_RemPrograms.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button_WryeBash
            // 
            this.button_WryeBash.BackColor = System.Drawing.Color.Transparent;
            this.button_WryeBash.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonFull;
            this.button_WryeBash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_WryeBash.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_WryeBash.FlatAppearance.BorderSize = 0;
            this.button_WryeBash.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_WryeBash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_WryeBash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_WryeBash.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_WryeBash.Location = new System.Drawing.Point(12, 48);
            this.button_WryeBash.Name = "button_WryeBash";
            this.button_WryeBash.Size = new System.Drawing.Size(178, 30);
            this.button_WryeBash.TabIndex = 1;
            this.button_WryeBash.TabStop = false;
            this.button_WryeBash.Text = "Wrye Bash";
            this.button_WryeBash.UseVisualStyleBackColor = false;
            this.button_WryeBash.Click += new System.EventHandler(this.button_WryeBash_Click);
            this.button_WryeBash.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_WryeBash.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button_ProgrammsFolder
            // 
            this.button_ProgrammsFolder.BackColor = System.Drawing.Color.Transparent;
            this.button_ProgrammsFolder.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonFull;
            this.button_ProgrammsFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ProgrammsFolder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_ProgrammsFolder.FlatAppearance.BorderSize = 0;
            this.button_ProgrammsFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_ProgrammsFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_ProgrammsFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ProgrammsFolder.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ProgrammsFolder.Location = new System.Drawing.Point(298, 156);
            this.button_ProgrammsFolder.Name = "button_ProgrammsFolder";
            this.button_ProgrammsFolder.Size = new System.Drawing.Size(178, 30);
            this.button_ProgrammsFolder.TabIndex = 14;
            this.button_ProgrammsFolder.TabStop = false;
            this.button_ProgrammsFolder.Text = "Все Программы";
            this.button_ProgrammsFolder.UseVisualStyleBackColor = false;
            this.button_ProgrammsFolder.Click += new System.EventHandler(this.button_ProgrammsFolder_Click);
            this.button_ProgrammsFolder.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_ProgrammsFolder.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button_GameDirectory
            // 
            this.button_GameDirectory.BackColor = System.Drawing.Color.Transparent;
            this.button_GameDirectory.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonFull;
            this.button_GameDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_GameDirectory.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_GameDirectory.FlatAppearance.BorderSize = 0;
            this.button_GameDirectory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_GameDirectory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_GameDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_GameDirectory.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_GameDirectory.Location = new System.Drawing.Point(298, 192);
            this.button_GameDirectory.Name = "button_GameDirectory";
            this.button_GameDirectory.Size = new System.Drawing.Size(178, 30);
            this.button_GameDirectory.TabIndex = 15;
            this.button_GameDirectory.TabStop = false;
            this.button_GameDirectory.Text = "Директория Игры";
            this.button_GameDirectory.UseVisualStyleBackColor = false;
            this.button_GameDirectory.Click += new System.EventHandler(this.button_GameDirectory_Click);
            this.button_GameDirectory.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_GameDirectory.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // button_ENBmenu
            // 
            this.button_ENBmenu.BackColor = System.Drawing.Color.Transparent;
            this.button_ENBmenu.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonHalf;
            this.button_ENBmenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ENBmenu.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_ENBmenu.FlatAppearance.BorderSize = 0;
            this.button_ENBmenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_ENBmenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_ENBmenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ENBmenu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ENBmenu.Location = new System.Drawing.Point(12, 156);
            this.button_ENBmenu.Name = "button_ENBmenu";
            this.button_ENBmenu.Size = new System.Drawing.Size(86, 30);
            this.button_ENBmenu.TabIndex = 5;
            this.button_ENBmenu.TabStop = false;
            this.button_ENBmenu.Text = "ENB";
            this.button_ENBmenu.UseVisualStyleBackColor = false;
            this.button_ENBmenu.Click += new System.EventHandler(this.button_ENBmenu_Click);
            this.button_ENBmenu.MouseEnter += new System.EventHandler(this.buttonH_MouseEnter);
            this.button_ENBmenu.MouseLeave += new System.EventHandler(this.buttonH_MouseLeave);
            // 
            // button_Skyrim
            // 
            this.button_Skyrim.BackColor = System.Drawing.Color.Transparent;
            this.button_Skyrim.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonlogo;
            this.button_Skyrim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Skyrim.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Skyrim.FlatAppearance.BorderSize = 0;
            this.button_Skyrim.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_Skyrim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_Skyrim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Skyrim.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_Skyrim.Location = new System.Drawing.Point(197, 48);
            this.button_Skyrim.Name = "button_Skyrim";
            this.button_Skyrim.Size = new System.Drawing.Size(94, 174);
            this.button_Skyrim.TabIndex = 8;
            this.button_Skyrim.TabStop = false;
            this.button_Skyrim.UseVisualStyleBackColor = false;
            this.button_Skyrim.Click += new System.EventHandler(this.button_Skyrim_Click);
            this.button_Skyrim.MouseEnter += new System.EventHandler(this.buttonSkyrim_MouseEnter);
            this.button_Skyrim.MouseLeave += new System.EventHandler(this.buttonSkyrim_MouseLeave);
            // 
            // button_FNISStart
            // 
            this.button_FNISStart.BackColor = System.Drawing.Color.Transparent;
            this.button_FNISStart.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonHalf;
            this.button_FNISStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_FNISStart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_FNISStart.FlatAppearance.BorderSize = 0;
            this.button_FNISStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_FNISStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_FNISStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_FNISStart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_FNISStart.Location = new System.Drawing.Point(104, 84);
            this.button_FNISStart.Name = "button_FNISStart";
            this.button_FNISStart.Size = new System.Drawing.Size(86, 30);
            this.button_FNISStart.TabIndex = 3;
            this.button_FNISStart.TabStop = false;
            this.button_FNISStart.Text = "FNIS";
            this.button_FNISStart.UseVisualStyleBackColor = false;
            this.button_FNISStart.Click += new System.EventHandler(this.button_FNIS_Click);
            this.button_FNISStart.MouseEnter += new System.EventHandler(this.buttonH_MouseEnter);
            this.button_FNISStart.MouseLeave += new System.EventHandler(this.buttonH_MouseLeave);
            // 
            // button_AddFileToIgnore
            // 
            this.button_AddFileToIgnore.BackColor = System.Drawing.Color.Transparent;
            this.button_AddFileToIgnore.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonOne;
            this.button_AddFileToIgnore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_AddFileToIgnore.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_AddFileToIgnore.FlatAppearance.BorderSize = 0;
            this.button_AddFileToIgnore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_AddFileToIgnore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_AddFileToIgnore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AddFileToIgnore.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_AddFileToIgnore.Location = new System.Drawing.Point(448, 84);
            this.button_AddFileToIgnore.Name = "button_AddFileToIgnore";
            this.button_AddFileToIgnore.Size = new System.Drawing.Size(28, 30);
            this.button_AddFileToIgnore.TabIndex = 12;
            this.button_AddFileToIgnore.TabStop = false;
            this.button_AddFileToIgnore.Text = "F";
            this.button_AddFileToIgnore.UseVisualStyleBackColor = false;
            this.button_AddFileToIgnore.Click += new System.EventHandler(this.button_AddFileToIgnore_Click);
            this.button_AddFileToIgnore.MouseEnter += new System.EventHandler(this.buttonAdd_MouseEnter);
            this.button_AddFileToIgnore.MouseLeave += new System.EventHandler(this.buttonAdd_MouseLeave);
            // 
            // button_AddFolderToIgnore
            // 
            this.button_AddFolderToIgnore.BackColor = System.Drawing.Color.Transparent;
            this.button_AddFolderToIgnore.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonOne;
            this.button_AddFolderToIgnore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_AddFolderToIgnore.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_AddFolderToIgnore.FlatAppearance.BorderSize = 0;
            this.button_AddFolderToIgnore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_AddFolderToIgnore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_AddFolderToIgnore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AddFolderToIgnore.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_AddFolderToIgnore.Location = new System.Drawing.Point(417, 84);
            this.button_AddFolderToIgnore.Name = "button_AddFolderToIgnore";
            this.button_AddFolderToIgnore.Size = new System.Drawing.Size(28, 30);
            this.button_AddFolderToIgnore.TabIndex = 11;
            this.button_AddFolderToIgnore.TabStop = false;
            this.button_AddFolderToIgnore.Text = "D";
            this.button_AddFolderToIgnore.UseVisualStyleBackColor = false;
            this.button_AddFolderToIgnore.Click += new System.EventHandler(this.button_AddFolderToIgnore_Click);
            this.button_AddFolderToIgnore.MouseEnter += new System.EventHandler(this.buttonAdd_MouseEnter);
            this.button_AddFolderToIgnore.MouseLeave += new System.EventHandler(this.buttonAdd_MouseLeave);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Multiselect = true;
            // 
            // button_Mods
            // 
            this.button_Mods.BackColor = System.Drawing.Color.Transparent;
            this.button_Mods.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonHalf;
            this.button_Mods.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Mods.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Mods.FlatAppearance.BorderSize = 0;
            this.button_Mods.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_Mods.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_Mods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Mods.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Mods.Location = new System.Drawing.Point(104, 156);
            this.button_Mods.Name = "button_Mods";
            this.button_Mods.Size = new System.Drawing.Size(86, 30);
            this.button_Mods.TabIndex = 6;
            this.button_Mods.TabStop = false;
            this.button_Mods.Text = "Моды";
            this.button_Mods.UseVisualStyleBackColor = false;
            this.button_Mods.Click += new System.EventHandler(this.button_Mods_Click);
            this.button_Mods.MouseEnter += new System.EventHandler(this.buttonH_MouseEnter);
            this.button_Mods.MouseLeave += new System.EventHandler(this.buttonH_MouseLeave);
            // 
            // button_Widget
            // 
            this.button_Widget.BackColor = System.Drawing.Color.Transparent;
            this.button_Widget.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonWidget;
            this.button_Widget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Widget.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Widget.FlatAppearance.BorderSize = 0;
            this.button_Widget.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_Widget.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_Widget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Widget.Location = new System.Drawing.Point(43, 12);
            this.button_Widget.Name = "button_Widget";
            this.button_Widget.Size = new System.Drawing.Size(25, 25);
            this.button_Widget.TabIndex = 17;
            this.button_Widget.TabStop = false;
            this.button_Widget.UseVisualStyleBackColor = false;
            this.button_Widget.Click += new System.EventHandler(this.button_Widget_Click);
            this.button_Widget.MouseEnter += new System.EventHandler(this.buttonWidget_MouseEnter);
            this.button_Widget.MouseLeave += new System.EventHandler(this.buttonWidget_MouseLeave);
            // 
            // button_Minimize
            // 
            this.button_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.button_Minimize.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonMinimize;
            this.button_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Minimize.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Minimize.FlatAppearance.BorderSize = 0;
            this.button_Minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_Minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Minimize.Location = new System.Drawing.Point(420, 12);
            this.button_Minimize.Name = "button_Minimize";
            this.button_Minimize.Size = new System.Drawing.Size(25, 25);
            this.button_Minimize.TabIndex = 18;
            this.button_Minimize.TabStop = false;
            this.button_Minimize.UseVisualStyleBackColor = false;
            this.button_Minimize.Click += new System.EventHandler(this.button_Minimize_Click);
            this.button_Minimize.MouseEnter += new System.EventHandler(this.buttonMinimize_MouseEnter);
            this.button_Minimize.MouseLeave += new System.EventHandler(this.buttonMinimize_MouseLeave);
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
            this.button_Close.Location = new System.Drawing.Point(451, 12);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(25, 25);
            this.button_Close.TabIndex = 19;
            this.button_Close.TabStop = false;
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            this.button_Close.MouseEnter += new System.EventHandler(this.buttonClose_MouseEnter);
            this.button_Close.MouseLeave += new System.EventHandler(this.buttonClose_MouseLeave);
            // 
            // button_Options
            // 
            this.button_Options.BackColor = System.Drawing.Color.Transparent;
            this.button_Options.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonFull;
            this.button_Options.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Options.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Options.FlatAppearance.BorderSize = 0;
            this.button_Options.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_Options.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_Options.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Options.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Options.Location = new System.Drawing.Point(12, 120);
            this.button_Options.Name = "button_Options";
            this.button_Options.Size = new System.Drawing.Size(178, 30);
            this.button_Options.TabIndex = 4;
            this.button_Options.TabStop = false;
            this.button_Options.Text = "Настройки Игры";
            this.button_Options.UseVisualStyleBackColor = false;
            this.button_Options.Click += new System.EventHandler(this.button_Options_Click);
            this.button_Options.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_Options.MouseLeave += new System.EventHandler(this.button_MouseLeave);
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
            // button_Help
            // 
            this.button_Help.BackColor = System.Drawing.Color.Transparent;
            this.button_Help.BackgroundImage = global::SLMPLauncher.Properties.Resources.buttonHelp;
            this.button_Help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Help.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Help.FlatAppearance.BorderSize = 0;
            this.button_Help.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_Help.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_Help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Help.Location = new System.Drawing.Point(12, 12);
            this.button_Help.Name = "button_Help";
            this.button_Help.Size = new System.Drawing.Size(25, 25);
            this.button_Help.TabIndex = 16;
            this.button_Help.TabStop = false;
            this.button_Help.UseVisualStyleBackColor = false;
            this.button_Help.Click += new System.EventHandler(this.button_Help_Click);
            this.button_Help.MouseEnter += new System.EventHandler(this.buttonHelp_MouseEnter);
            this.button_Help.MouseLeave += new System.EventHandler(this.buttonHelp_MouseLeave);
            // 
            // button_MyDocs
            // 
            this.button_MyDocs.BackColor = System.Drawing.Color.Transparent;
            this.button_MyDocs.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_buttonFull;
            this.button_MyDocs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_MyDocs.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_MyDocs.FlatAppearance.BorderSize = 0;
            this.button_MyDocs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button_MyDocs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button_MyDocs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_MyDocs.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_MyDocs.Location = new System.Drawing.Point(298, 120);
            this.button_MyDocs.Name = "button_MyDocs";
            this.button_MyDocs.Size = new System.Drawing.Size(178, 30);
            this.button_MyDocs.TabIndex = 13;
            this.button_MyDocs.TabStop = false;
            this.button_MyDocs.Text = "Мои Документы";
            this.button_MyDocs.UseVisualStyleBackColor = false;
            this.button_MyDocs.Click += new System.EventHandler(this.button_MyDocs_Click);
            this.button_MyDocs.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_MyDocs.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SLMPLauncher.Properties.Resources._1_MainForm;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(488, 234);
            this.ControlBox = false;
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Minimize);
            this.Controls.Add(this.button_Help);
            this.Controls.Add(this.button_Widget);
            this.Controls.Add(this.button_Options);
            this.Controls.Add(this.button_Skyrim);
            this.Controls.Add(this.button_Mods);
            this.Controls.Add(this.button_AddFolderToIgnore);
            this.Controls.Add(this.button_AddFileToIgnore);
            this.Controls.Add(this.button_ENBmenu);
            this.Controls.Add(this.button_GameDirectory);
            this.Controls.Add(this.button_MyDocs);
            this.Controls.Add(this.button_ProgrammsFolder);
            this.Controls.Add(this.button_WryeBash);
            this.Controls.Add(this.button_RemPrograms);
            this.Controls.Add(this.button_FNISStart);
            this.Controls.Add(this.button_DSRStart);
            this.Controls.Add(this.button_ResetSettings);
            this.Controls.Add(this.button_ClearDirectory);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SLMP: Skyrim Control Panel";
            this.ResumeLayout(false);

        }
    }
}

