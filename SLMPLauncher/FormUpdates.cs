using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public partial class FormUpdates : Form
    {
        string pathUpdateFolder = FuncFiles.pathAddSlash(FormMain.pathLauncherFolder + "Updates");
        string nameUpdateInfo = "UpdateInfo.ini";
        string nameControlPanel = "SLMPLauncher.exe";
        string nameHostName = FuncParser.stringRead(FormMain.pathLauncherINI, "Updates", "UpdateHost");
        string downloadFileType = null;
        string downloadFileName = null;
        string textAvailable = "Доступно";
        string textCheck = "Проверить";
        string textContinue = "Продолжить?";
        string textInstalled = "Установлено";
        string textNoSyncWithUI = "Скачанный файл не соответствует UpdateInfo. Повторите попытку.";
        string textNoTools = "Нет компонентов для установки обновления (файла обновления, 7z или UpdateInfo).";
        string textNoUpdate = "Нет обновлений";
        string textPleaseRead = "Пожалуйста прочтите предупреждение: ";
        string textRequiredVersion = "Вы должны сначала установить: ";
        string textSize = "Размер: ";
        string textStop = "Стоп";
        string textUpdate = "Обновить";
        string textWrongPing = "Нет доступа к: ";
        string textUpdateExt = FormMain.archiveExt[FormMain.updatesExtension];
        bool stopDownload = false;
        bool updateInstall = false;
        bool updatesCPFound = false;
        bool updatesFound = false;
        int numberSelectFile = -1;
        List<int> realIndexI = new List<int>();
        List<int> realIndex = new List<int>();
        List<string> installPreLoad = new List<string>();
        WebClient client = new WebClient();

        public FormUpdates()
        {
            InitializeComponent();
            FuncMisc.setFormFont(this);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            if (FormMain.numberStyle > 1)
            {
                imageBackgroundImage();
            }
            if (FormMain.langTranslate == "EN")
            {
                langTranslateEN();
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            FuncMisc.textColor(this, System.Drawing.SystemColors.ControlLight, System.Drawing.Color.Black, false);
        }
        private void langTranslateEN()
        {
            button_AboutUpdate.Text = "About update";
            button_CheckUpdate.Text = "Check";
            button_UpdateCP.Text = "Not check";
            label2.Text = "Update for CP:";
            label3.Text = "Available files:";
            label4.Text = "Not check";
            label6.Text = "Game and control panel updates";
            textAvailable = "Available";
            textCheck = "Check";
            textContinue = "Continue?";
            textInstalled = "Installed";
            textNoSyncWithUI = "The downloaded file does not correspond to UpdateInfo. Try again.";
            textNoTools = "No components to install the update (update file, 7z or UpdateInfo).";
            textNoUpdate = "No updates";
            textPleaseRead = "Please read notification: ";
            textRequiredVersion = "You must before install: ";
            textSize = "Size: ";
            textStop = "Stop";
            textUpdate = "Update";
            textWrongPing = "No access to: ";
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_CheckUpdate_Click(object sender, EventArgs e)
        {
            if (stopDownload)
            {
                client.CancelAsync();
                stopDownload = false;
                enableDisableButtons();
            }
            else
            {
                stopDownload = true;
                enableDisableButtons();
                if (updatesFound)
                {
                    string line1 = FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file_warning");
                    bool confirm = false;
                    bool request = false;
                    if (line1 != null)
                    {
                        if (FuncMisc.dialogResult(textPleaseRead + line1 + Environment.NewLine + Environment.NewLine + textContinue))
                        {
                            confirm = true;
                        }
                        line1 = null;
                    }
                    else
                    {
                        confirm = true;
                    }
                    if (confirm)
                    {
                        string line2 = FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_request_update");
                        if (line2 != null)
                        {
                            if (FuncParser.doubleRead(pathUpdateFolder + nameUpdateInfo, "Update_" + line2, "update_file_version") <= FuncParser.doubleRead(FormMain.pathLauncherINI, "Updates", "Update_" + line2 + "_Version"))
                            {
                                request = true;
                            }
                            else
                            {
                                MessageBox.Show(textRequiredVersion + FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "Update_" + line2, "update_file"));
                            }
                            line2 = null;
                        }
                        else
                        {
                            request = true;
                        }
                    }
                    if (confirm && request)
                    {
                        if (checkUpdateFile(false))
                        {
                            unpackUpdates(true);
                        }
                        else
                        {
                            FuncFiles.deleteAny(pathUpdateFolder + "file" + numberSelectFile + textUpdateExt);
                            downloadFileName = "file" + numberSelectFile + textUpdateExt;
                            downloadFileType = "UpdateG";
                            client_DownloadProgressStart();
                        }
                    }
                    else
                    {
                        stopDownload = false;
                        enableDisableButtons();
                    }
                }
                else
                {
                    FuncFiles.deleteAny(pathUpdateFolder + nameUpdateInfo);
                    downloadFileName = nameUpdateInfo;
                    downloadFileType = "CheckU";
                    realIndexI.Clear();
                    realIndex.Clear();
                    installPreLoad.Clear();
                    client_DownloadProgressStart();
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_AboutUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file_discription"));
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_UpdateCP_Click(object sender, EventArgs e)
        {
            stopDownload = true;
            enableDisableButtons();
            FuncFiles.deleteAny(pathUpdateFolder + nameControlPanel);
            downloadFileName = nameControlPanel;
            downloadFileType = "UpdateCP";
            client_DownloadProgressStart();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void enableDisableButtons()
        {
            if (updatesFound)
            {
                if (stopDownload)
                {
                    comboBox_Updates.Enabled = false;
                    button_AboutUpdate.Enabled = false;
                    button_CheckUpdate.Text = textStop;
                }
                else
                {
                    comboBox_Updates.Enabled = true;
                    button_AboutUpdate.Enabled = true;
                    label5.Text = textSize + FuncParser.convertFileSize(FuncParser.intRead(pathUpdateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file_filesize"));
                    if (updateInstall)
                    {
                        button_CheckUpdate.Enabled = false;
                        button_CheckUpdate.Text = textInstalled;
                    }
                    else
                    {
                        button_CheckUpdate.Enabled = true;
                        button_CheckUpdate.Text = textUpdate;
                    }
                }
            }
            else
            {
                comboBox_Updates.Enabled = false;
                button_AboutUpdate.Enabled = false;
                label5.Text = "";
                if (stopDownload)
                {
                    button_CheckUpdate.Text = textStop;
                }
                else
                {
                    button_CheckUpdate.Text = textCheck;
                }
            }
            if (updatesCPFound)
            {
                if (stopDownload)
                {
                    button_UpdateCP.Enabled = false;
                }
                else
                {
                    button_UpdateCP.Enabled = true;
                    button_UpdateCP.Text = textUpdate;
                }
            }
            else
            {
                button_UpdateCP.Enabled = false;
                button_UpdateCP.Text = textNoUpdate;
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void client_DownloadProgressStart()
        {
            try
            {
                FuncFiles.creatDirectory(pathUpdateFolder);
                client.DownloadFileAsync(new Uri(nameHostName + downloadFileName), pathUpdateFolder + downloadFileName);
            }
            catch
            {
                stopDownload = false;
                enableDisableButtons();
                MessageBox.Show(textWrongPing + nameHostName + downloadFileName);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (stopDownload)
            {
                if (File.Exists(pathUpdateFolder + nameUpdateInfo))
                {
                    if (downloadFileType == "CheckU")
                    {
                        int count1 = FuncParser.intRead(pathUpdateFolder + nameUpdateInfo, "General", "numbers_files_update");
                        if (count1 > 0)
                        {
                            for (int i = 1; i <= count1; i++)
                            {
                                comboBox_Updates.SelectedIndexChanged -= comboBox_Updates_SelectedIndexChanged;
                                if (checkUpdateVersion(i))
                                {
                                    realIndexI.Add(i);
                                    installPreLoad.Add(textInstalled + " / " + FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "Update_" + i, "update_file"));
                                }
                                else
                                {
                                    realIndex.Add(i);
                                    comboBox_Updates.Items.Add(textAvailable + " / " + FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "Update_" + i, "update_file"));
                                }
                                comboBox_Updates.SelectedIndexChanged += comboBox_Updates_SelectedIndexChanged;
                            }
                            int count2 = realIndexI.Count;
                            for (int i = 0; i < count2; i++)
                            {
                                realIndex.Add(realIndexI[i]);
                                comboBox_Updates.Items.Add(installPreLoad[i]);
                            }
                            if (comboBox_Updates.Items.Count > 0)
                            {
                                comboBox_Updates.SelectedIndex = 0;
                            }
                            updatesFound = true;
                            label4.Text = count1.ToString();
                        }
                        else
                        {
                            updatesFound = false;
                            label4.Text = textNoUpdate;
                        }
                        string line = FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "General", "version_control_panel");
                        if (line != null)
                        {
                            int result = new Version(FormMain.panelFileVersion).CompareTo(new Version(line));
                            updatesCPFound = result < 0;
                        }
                    }
                    if (downloadFileType == "UpdateG")
                    {
                        if (checkUpdateFile(true))
                        {
                            unpackUpdates(false);
                        }
                    }
                    if (downloadFileType == "UpdateCP")
                    {
                        string version1 = FileVersionInfo.GetVersionInfo(pathUpdateFolder + nameControlPanel).ProductVersion;
                        if (version1 == FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "General", "version_control_panel"))
                        {
                            FuncFiles.writeToFile(FormMain.pathLauncherFolder + "Update.bat", new List<string>() { 
                                "@Echo off",
                                "mode con:cols=50 lines=10",
                                "color 0E",
                                "cd %~dp0",
                                "SET CP_S=" + FormMain.pathLauncherExecuting,
                                "SET CP_U=" + pathUpdateFolder + nameControlPanel,
                                "Echo Please Wait 5 second before start update.",
                                "TIMEOUT /T 2 /NOBREAK >nul 2>nul",
                                "IF EXIST \"%CP_U%\" (",
                                "Echo -Update file found.",
                                "TIMEOUT /T 1 /NOBREAK >nul 2>nul",
                                "Echo -Delete old file control panel.",
                                "del \"%CP_S%\" /Q >nul 2>nul",
                                "TIMEOUT /T 1 /NOBREAK >nul 2>nul",
                                "Echo -Move new file control panel.",
                                "move /Y \"%CP_U%\" \"%CP_S%\" >nul 2>nul",
                                "TIMEOUT /T 1 /NOBREAK >nul 2>nul",
                                "Echo -Expectation launching new control panel.",
                                "start \"Run new file\" \"%CP_S%\" >nul 2>nul",
                                ") else (",
                                "Echo -Update file not found...",
                                "TIMEOUT /T 5 /NOBREAK >nul 2>nul",
                                ")",
                                "Echo -Closing.",
                                "TIMEOUT /T 2 /NOBREAK >nul 2>nul",
                                "del \"" + FormMain.pathLauncherFolder + "Update.bat\" /Q >nul 2>nul"});
                            FuncFiles.runProcess(FormMain.pathLauncherFolder + "Update.bat", null, null, false, true, false);
                            Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show(textNoSyncWithUI);
                            FuncFiles.deleteAny(pathUpdateFolder + nameControlPanel);
                        }
                    }
                }
                else
                {
                    updatesFound = false;
                    updatesCPFound = false;
                }
            }
            stopDownload = false;
            progressBar1.Value = 0;
            enableDisableButtons();
        }

        private bool checkUpdateFile(bool fromDL)
        {
            if (File.Exists(pathUpdateFolder + "file" + numberSelectFile + textUpdateExt) && File.Exists(pathUpdateFolder + nameUpdateInfo) && File.Exists(FormMain.pathLauncherFolder + "7z.exe"))
            {
                if (new FileInfo(pathUpdateFolder + "file" + numberSelectFile + textUpdateExt).Length == FuncParser.intRead(pathUpdateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file_filesize"))
                {
                    return true;
                }
                else
                {
                    if (fromDL)
                    {
                        MessageBox.Show(textNoSyncWithUI);
                    }
                    FuncFiles.deleteAny(pathUpdateFolder + "file" + numberSelectFile + textUpdateExt);
                }
            }
            else
            {
                if (fromDL)
                {
                    MessageBox.Show(textNoTools);
                }
            }
            return false;
        }
        private void unpackUpdates(bool readyDL)
        {
            for (int i = 1; i <= 200; i++)
            {
                if (FuncParser.keyExists(pathUpdateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_delete_file_" + i.ToString()))
                {
                    FuncFiles.deleteAny(FormMain.pathGameFolder + FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_delete_file_" + i.ToString()));
                }
                else
                {
                    break;
                }
            }
            FuncFiles.unpackArhive(pathUpdateFolder + "file" + numberSelectFile + textUpdateExt, false, false);
            FuncParser.iniWrite(FormMain.pathLauncherINI, "Updates", "Update_" + numberSelectFile + "_Version", FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file_version"));
            comboBox_Updates_SelectedIndexChanged(this, new EventArgs());
            if (readyDL)
            {
                stopDownload = false;
                enableDisableButtons();
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void comboBox_Updates_SelectedIndexChanged(object sender, EventArgs e)
        {
            numberSelectFile = realIndex[comboBox_Updates.SelectedIndex];
            if (checkUpdateVersion(numberSelectFile))
            {
                updateInstall = true;
                comboBox_Updates.SelectedIndexChanged -= comboBox_Updates_SelectedIndexChanged;
                comboBox_Updates.Items[comboBox_Updates.SelectedIndex] = textInstalled + " / " + FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file");
                comboBox_Updates.SelectedIndexChanged += comboBox_Updates_SelectedIndexChanged;
            }
            else
            {
                updateInstall = false;
            }
            enableDisableButtons();
        }
        private bool checkUpdateVersion(int index)
        {
            if (FuncParser.doubleRead(pathUpdateFolder + nameUpdateInfo, "Update_" + index, "update_file_version") <= FuncParser.doubleRead(FormMain.pathLauncherINI, "Updates", "Update_" + index + "_Version"))
            {
                return true;
            }
            return false;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_Close_MouseEnter(object sender, EventArgs e)
        {
            button_Close.BackgroundImage = Properties.Resources.buttonCloseGlow;
        }
        private void button_Close_MouseLeave(object sender, EventArgs e)
        {
            button_Close.BackgroundImage = Properties.Resources.buttonClose;
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            client.DownloadProgressChanged -= new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted -= new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.CancelAsync();
            FuncFiles.deleteAny(pathUpdateFolder + nameControlPanel);
            FuncFiles.deleteAny(pathUpdateFolder + nameUpdateInfo);
        }
    }
}