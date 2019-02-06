using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public class FuncMisc
    {
        public static bool refreshButton(Button button, string file, string section, string parameter, string value, bool invert)
        {
            if (FuncParser.keyExists(file, section, parameter))
            {
                button.Enabled = true;
                string readString = FuncParser.stringRead(file, section, parameter);
                bool toggle = false;
                toggle = readString != null && (readString == value || readString == "1" || readString.ToLower() == "true");
                toggle = invert ? !toggle : toggle;
                if (toggle)
                {
                    button.BackgroundImage = Properties.Resources.buttonToggleOn;
                }
                else
                {
                    button.BackgroundImage = Properties.Resources.buttonToggleOff;
                }
                return toggle;
            }
            else
            {
                button.BackgroundImage = Properties.Resources.buttonToggleDisable;
                button.Enabled = false;
                return false;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void refreshTrackBar(TrackBar trackbar, string file, string section, string parameter, int division, Label label)
        {
            if (FuncParser.keyExists(file, section, parameter))
            {
                trackbar.Enabled = true;
                int readINT = FuncParser.intRead(file, section, parameter);
                if (division != -1)
                {
                    readINT = readINT / division;
                }
                if (readINT >= trackbar.Minimum && readINT <= trackbar.Maximum)
                {
                    if (division != -1)
                    {
                        label.Text = (readINT * division).ToString();
                    }
                    else
                    {
                        label.Text = readINT.ToString();
                    }
                    trackbar.Value = readINT;
                }
                else
                {
                    label.Text = "N/A";
                }
            }
            else
            {
                label.Text = "N/A";
                trackbar.Enabled = false;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void refreshComboBox(ComboBox combobox, List<double> list, double value, bool notEqual, EventHandler onchange)
        {
            if (onchange != null)
            {
                combobox.SelectedIndexChanged -= onchange;
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (value == list[i] || (notEqual && value < list[i]))
                {
                    combobox.SelectedIndex = i;
                    break;
                }
                else if (i == list.Count - 1)
                {
                    combobox.SelectedIndex = -1;
                }
            }
            if (onchange != null)
            {
                combobox.SelectedIndexChanged += onchange;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void refreshNumericUpDown(NumericUpDown numeric, string file, string section, string parametr, EventHandler onchange)
        {
            int value = FuncParser.intRead(file, section, parametr);
            if (onchange != null)
            {
                numeric.ValueChanged -= onchange;
            }
            if (value >= numeric.Minimum && value <= numeric.Maximum)
            {
                numeric.Value = value;
            }
            else
            {
                numeric.Value = numeric.Minimum;
            }
            if (onchange != null)
            {
                numeric.ValueChanged += onchange;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void toggleButtons(Form form, bool action)
        {
            foreach (Control line in form.Controls)
            {
                if (line is Button)
                {
                    line.Enabled = action;
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void textColor(Form form, Color color, Color trackbar, bool button)
        {
            foreach (Control line in form.Controls)
            {
                if (line is Label || (line is Button && button))
                {
                    line.ForeColor = color;
                }
                else if (line is TrackBar)
                {
                    line.BackColor = trackbar;
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void setFormFont(Form form)
        {
            if (FormMain.customFont != null)
            {
                foreach (Control line in form.Controls)
                {
                    if (line is Label || line is Button || line is ListBox || line is ListView || line is ComboBox || line is NumericUpDown)
                    {
                        line.Font = new System.Drawing.Font(FormMain.customFont, line.Font.Size, FormMain.customFontStyle, System.Drawing.GraphicsUnit.Point);
                    }
                }
            }
        }
        public static void supportStrikeOut(string font)
        {
            if (!testStrikeOut(font, FontStyle.Regular))
            {
                if (testStrikeOut(font, FontStyle.Bold))
                {
                    FormMain.customFontStyle = FontStyle.Bold;
                }
                else if (testStrikeOut(font, FontStyle.Italic))
                {
                    FormMain.customFontStyle = FontStyle.Italic;
                }
                else if (testStrikeOut(font, FontStyle.Strikeout))
                {
                    FormMain.customFontStyle = FontStyle.Strikeout;
                }
                else if (testStrikeOut(font, FontStyle.Underline))
                {
                    FormMain.customFontStyle = FontStyle.Underline;
                }
                else
                {
                    FormMain.customFont = null;
                }
            }
        }
        public static bool testStrikeOut(string font, FontStyle style)
        {
            try
            {
                using (Font strikeout = new Font(font, 10, style))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void writeToFile(string path, List<string> list)
        {
            try
            {
                FuncFiles.deleteAny(path);
                File.WriteAllLines(path, list, new UTF8Encoding(false));
            }
            catch
            {
                MessageBox.Show(FormMain.couldWriteFile + path);
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void wideScreenMods()
        {
            if (FuncParser.intRead(FormMain.pathLauncherINI, "General", "AspectRatio") == 4)
            {
                if (File.Exists(FormMain.pathGameFolder + @"Data\Frostfall.esp") && (!File.Exists(FormMain.pathGameFolder + @"Data\Frostfall-WS.esp") || !File.Exists(FormMain.pathGameFolder + @"Data\Frostfall-WS.bsa")))
                {
                    FuncMisc.unpackRAR(FormMain.pathLauncherFolder + @"CPFiles\System\AR(4)FF.rar");
                }
                if (File.Exists(FormMain.pathGameFolder + @"Data\DisableFastTravel.bsa") && new FileInfo(FormMain.pathGameFolder + @"Data\DisableFastTravel.bsa").Length != 45594)
                {
                    FuncMisc.unpackRAR(FormMain.pathLauncherFolder + @"CPFiles\System\AR(4)DFT.rar");
                }
            }
            else
            {
                FuncFiles.deleteAny(FormMain.pathGameFolder + @"Data\Frostfall-WS.esp");
                FuncFiles.deleteAny(FormMain.pathGameFolder + @"Data\Frostfall-WS.bsa");
                if (File.Exists(FormMain.pathGameFolder + @"Data\DisableFastTravel.bsa") && new FileInfo(FormMain.pathGameFolder + @"Data\DisableFastTravel.bsa").Length != 45595)
                {
                    FuncMisc.unpackRAR(FormMain.pathLauncherFolder + @"CPFiles\DisableFastTravel.rar");
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void unpackRAR(string path)
        {
            Directory.SetCurrentDirectory(FormMain.pathLauncherFolder);
            if (File.Exists(path) && File.Exists(FormMain.pathLauncherFolder + "UnRAR.exe"))
            {
                runProcess(FormMain.pathLauncherFolder + "UnRAR.exe", " x -y \"" + path + "\"" + " " + "\"" + FormMain.pathGameFolder + "\"", null, null, true);
            }
            else
            {
                MessageBox.Show(FormMain.couldUnpack + path);
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void runProcess(string path, string arg, EventHandler onexit, Form form, bool wait)
        {
            if (File.Exists(path))
            {
                Directory.SetCurrentDirectory(Path.GetDirectoryName(path));
                Process Run = new Process();
                Run.StartInfo.FileName = path;
                Run.StartInfo.Arguments = arg;
                if (onexit != null && form != null && !wait)
                {
                    Run.EnableRaisingEvents = true;
                    Run.Exited += onexit;
                }
                try
                {
                    Run.Start();
                    if (wait)
                    {
                        Run.WaitForExit();
                    }
                }
                catch
                {
                    MessageBox.Show(FormMain.couldRun + path);
                }
                Directory.SetCurrentDirectory(FormMain.pathLauncherFolder);
            }
        }
    }
}