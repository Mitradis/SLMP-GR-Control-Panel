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
        string pathUpdateFolder = FormMain.pathLauncherFolder + @"Updates\";
        string nameUpdateInfo = "UpdateInfo.ini";
        string nameControlPanel = "SLMPLauncher.exe";
        string nameHostName = FuncParser.stringRead(FormMain.pathLauncherINI, "Updates", "UpdateHost");
        string downloadFileType = null;
        string downloadFileName = null;
        string buttonCvsU_TC = "Проверить";
        string buttonCvsU_TI = "Установлено";
        string buttonCvsU_TS = "Стоп";
        string buttonCvsU_TU = "Обновить";
        string buttonUpdateCP_TE = "Обновить";
        string buttonUpdateCP_TN = "Нет обновления";
        string confirmDelete = "Пожалуйста прочтите предупреждение: ";
        string confirmTitle = "Подтверждение";
        string continueUpdate = "Продолжить?";
        string installedUpdate = "Установлено / ";
        string installedUpdateN = "Обновление / ";
        string label4_T = "Нет обновлений";
        string label5_T = "Размер: ";
        string noTools = "Нет компонентов для установки обновления (файла обновления, UnRAR или UpdateInfo).";
        string notRequestVersion = "Вы должны сначала установить: ";
        string notSyncWithUI = "Скачанный файл не соответствует UpdateInfo. Повторите попытку.";
        string wrongPing = "Нет доступа к: ";
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
            Directory.SetCurrentDirectory(FormMain.pathLauncherFolder);
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
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            FuncMisc.textColor(this, System.Drawing.SystemColors.ControlLight, System.Drawing.Color.FromArgb(30, 30, 30), false);
        }
        private void langTranslateEN()
        {
            buttonCvsU_TC = "Check";
            buttonCvsU_TI = "Installed";
            buttonCvsU_TS = "Stop";
            buttonCvsU_TU = "Update";
            buttonUpdateCP_TE = "Update";
            buttonUpdateCP_TN = "No updates";
            button_AboutUpdate.Text = "About update";
            button_CvsU.Text = "Check";
            button_UpdateCP.Text = "Not check";
            confirmDelete = "Please read notification: ";
            confirmTitle = "Confirm";
            continueUpdate = "Continue?";
            installedUpdate = "Installed / ";
            installedUpdateN = "Update / ";
            label2.Text = "Update for CP:";
            label3.Text = "Available files:";
            label4.Text = "Not check";
            label4_T = "No updates";
            label5_T = "Size: ";
            label6.Text = "Game and control panel updates";
            noTools = "No components to install the update (update file, UnRAR or UpdateInfo).";
            notRequestVersion = "You must before install: ";
            notSyncWithUI = "The downloaded file does not correspond to UpdateInfo. Try again.";
            wrongPing = "No access to: ";
        }
        private void FormUpdates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button_Close_Click(this, new EventArgs());
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_CheckU_Click(object sender, EventArgs e)
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
                        DialogResult dialogResult = MessageBox.Show(confirmDelete + line1 + Environment.NewLine + Environment.NewLine + continueUpdate, confirmTitle, MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
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
                                MessageBox.Show(notRequestVersion + FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "Update_" + line2, "update_file"));
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
                            FuncFiles.deleteAny(pathUpdateFolder + "file" + numberSelectFile + ".rar");
                            downloadFileName = "file" + numberSelectFile + ".rar";
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
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_AboutUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file_discription"));
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void button_UpdateCP_Click(object sender, EventArgs e)
        {
            stopDownload = true;
            enableDisableButtons();
            FuncFiles.deleteAny(pathUpdateFolder + nameControlPanel);
            downloadFileName = nameControlPanel;
            downloadFileType = "UpdateCP";
            client_DownloadProgressStart();
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void enableDisableButtons()
        {
            if (updatesFound)
            {
                if (stopDownload)
                {
                    comboBox1.Enabled = false;
                    button_AboutUpdate.Enabled = false;
                    button_CvsU.Text = buttonCvsU_TS;
                }
                else
                {
                    comboBox1.Enabled = true;
                    button_AboutUpdate.Enabled = true;
                    label5.Text = label5_T + FuncParser.convertFileSize(FuncParser.intRead(pathUpdateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file_filesize"));
                    if (updateInstall)
                    {
                        button_CvsU.Enabled = false;
                        button_CvsU.Text = buttonCvsU_TI;
                    }
                    else
                    {
                        button_CvsU.Enabled = true;
                        button_CvsU.Text = buttonCvsU_TU;
                    }
                }
            }
            else
            {
                comboBox1.Enabled = false;
                button_AboutUpdate.Enabled = false;
                label5.Text = "";
                if (stopDownload)
                {
                    button_CvsU.Text = buttonCvsU_TS;
                }
                else
                {
                    button_CvsU.Text = buttonCvsU_TC;
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
                    button_UpdateCP.Text = buttonUpdateCP_TE;
                }
            }
            else
            {
                button_UpdateCP.Enabled = false;
                button_UpdateCP.Text = buttonUpdateCP_TN;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
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
                MessageBox.Show(wrongPing + nameHostName + downloadFileName);
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (stopDownload)
            {
                if (File.Exists(pathUpdateFolder + nameUpdateInfo))
                {
                    if (downloadFileType == "CheckU")
                    {
                        int CountComboBox = FuncParser.intRead(pathUpdateFolder + nameUpdateInfo, "General", "numbers_files_update");
                        if (CountComboBox > 0)
                        {
                            for (int i = 1; i <= CountComboBox; i++)
                            {
                                comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
                                if (checkUpdateVersion(i))
                                {
                                    realIndexI.Add(i);
                                    installPreLoad.Add(installedUpdate + FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "Update_" + i, "update_file"));
                                }
                                else
                                {
                                    realIndex.Add(i);
                                    comboBox1.Items.Add(installedUpdateN + FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "Update_" + i, "update_file"));
                                }
                                comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
                            }
                            for (int i = 0; i < realIndexI.Count; i++)
                            {
                                realIndex.Add(realIndexI[i]);
                                comboBox1.Items.Add(installPreLoad[i]);
                            }
                            if (comboBox1.Items.Count > 0)
                            {
                                comboBox1.SelectedIndex = 0;
                            }
                            updatesFound = true;
                            label4.Text = CountComboBox.ToString();
                        }
                        else
                        {
                            updatesFound = false;
                            label4.Text = label4_T;
                        }
                        string line = FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "General", "version_control_panel");
                        if (line != null)
                        {
                            var result = new Version(FormMain.panelFileVersion).CompareTo(new Version(line));
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
                            FuncMisc.writeToFile(FormMain.pathLauncherFolder + "Update.bat", new List<string>() { "@Echo off", "mode con:cols=50 lines=10", "color 0E", "cd %~dp0 >nul 2>nul", "SET CP_S=" + FormMain.pathLauncherFolder + nameControlPanel, "SET CP_U=" + pathUpdateFolder + nameControlPanel, "Echo Please Wait 5 second before start update.", "TIMEOUT /T 2 /NOBREAK > nul", "IF EXIST \"%CP_U%\" (", "Echo -Update file found.", "TIMEOUT /T 1 /NOBREAK > nul", "Echo -Deleted old file control panel.", "del \"%CP_S%\" /Q >nul 2>nul", "TIMEOUT /T 1 /NOBREAK > nul", "Echo -Trying move new file control panel.", "move /Y \"%CP_U%\" \"%CP_S%\" >nul 2>nul", "TIMEOUT /T 1 /NOBREAK > nul", "Echo -Expectation launching new control panel.", "start \"Run new file\" \"%CP_S%\" >nul 2>nul", ") else (", "Echo -Update file not found...", "TIMEOUT /T 5 /NOBREAK > nul", ")", "Echo -Ready. Closing.", "TIMEOUT /T 2 /NOBREAK > nul", "del \"" + FormMain.pathLauncherFolder + "Update.bat\" /Q >nul 2>nul" });
                            Process.Start(FormMain.pathLauncherFolder + "Update.bat");
                            Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show(notSyncWithUI);
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
            if (File.Exists(pathUpdateFolder + "file" + numberSelectFile + ".rar") && File.Exists(pathUpdateFolder + nameUpdateInfo) && File.Exists(FormMain.pathLauncherFolder + "UnRAR.exe"))
            {
                if (new FileInfo(pathUpdateFolder + "file" + numberSelectFile + ".rar").Length == FuncParser.intRead(pathUpdateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file_filesize"))
                {
                    return true;
                }
                else
                {
                    if (fromDL)
                    {
                        MessageBox.Show(notSyncWithUI);
                    }
                    FuncFiles.deleteAny(pathUpdateFolder + "file" + numberSelectFile + ".rar");
                }
            }
            else
            {
                if (fromDL)
                {
                    MessageBox.Show(noTools);
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
            FuncMisc.unpackRAR(pathUpdateFolder + "file" + numberSelectFile + ".rar");
            FuncParser.iniWrite(FormMain.pathLauncherINI, "Updates", "Update_" + numberSelectFile + "_Version", FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file_version"));
            comboBox1_SelectedIndexChanged(this, new EventArgs());
            if (readyDL)
            {
                stopDownload = false;
                enableDisableButtons();
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numberSelectFile = realIndex[comboBox1.SelectedIndex];
            if (checkUpdateVersion(numberSelectFile))
            {
                updateInstall = true;
                comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
                comboBox1.Items[comboBox1.SelectedIndex] = installedUpdate + FuncParser.stringRead(pathUpdateFolder + nameUpdateInfo, "Update_" + numberSelectFile, "update_file");
                comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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
            client.DownloadProgressChanged -= new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted -= new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.CancelAsync();
            FuncFiles.deleteAny(pathUpdateFolder + nameControlPanel);
            FuncFiles.deleteAny(pathUpdateFolder + nameUpdateInfo);
            Dispose();
        }
    }
}