using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public static class FuncFiles
    {
        public static void deleteAny(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch
                {
                    MessageBox.Show(FormMain.textCouldNotDelete + path);
                }
            }
            else if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path, true);
                }
                catch
                {
                    MessageBox.Show(FormMain.textCouldNotDelete + path);
                }
            }
        }
        public static void deleteAllInFolder(string path, string ext)
        {
            if (Directory.Exists(path))
            {
                foreach (string line in Directory.EnumerateFiles(path, ext))
                {
                    deleteAny(line);
                }
            }
        }
        public static void deleteModFile(string mod)
        {
            string path = Path.GetFullPath(FormMain.pathDataFolder + mod);
            if (path.Remove(0, FormMain.gameDirLength).Length > 5)
            {
                deleteAny(path);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void moveAny(string from, string to)
        {
            if (File.Exists(from))
            {
                if (!File.Exists(to))
                {
                    creatDirectory(Path.GetDirectoryName(to));
                    try
                    {
                        File.Move(from, to);
                    }
                    catch
                    {
                        MessageBox.Show(FormMain.textCouldNotMove + from + " > " + to);
                    }
                }
                else
                {
                    MessageBox.Show(FormMain.textAlreadyExists + to);
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void copyAny(string from, string to)
        {
            if (File.Exists(from))
            {
                try
                {
                    File.Copy(from, to, true);
                }
                catch
                {
                    MessageBox.Show(FormMain.textFailedCopy + from);
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void creatDirectory(string dir)
        {
            if (!Directory.Exists(dir))
            {
                try
                {
                    Directory.CreateDirectory(dir);
                }
                catch
                {
                    MessageBox.Show(FormMain.textFailedCreate + dir);
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void appendToFile(string path, string line)
        {
            try
            {
                File.AppendAllText(path, line + Environment.NewLine, new UTF8Encoding(false));
            }
            catch
            {
                MessageBox.Show(FormMain.textCouldWriteFile + path);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void writeToFile(string path, List<string> list)
        {
            try
            {
                File.WriteAllLines(path, list, new UTF8Encoding(false));
            }
            catch
            {
                MessageBox.Show(FormMain.textCouldWriteFile + path);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void unpackArhive(string path, bool noext, bool data)
        {
            if (noext)
            {
                foreach (string line in FormMain.archiveExt)
                {
                    if (File.Exists(path + line))
                    {
                        path = path + line;
                        break;
                    }
                }
            }
            if (File.Exists(path) && File.Exists(FormMain.pathLauncherFolder + "7z.exe"))
            {
                runProcess(FormMain.pathLauncherFolder + "7z.exe", " x -y \"" + path + "\"" + " " + "-o\"" + (data ? FormMain.pathDataFolder : FormMain.pathGameFolder) + "\"", null, null, true, true);
            }
            else
            {
                MessageBox.Show(FormMain.textCouldUnpack + path);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void runProcess(string path, string arg, EventHandler onexit, Form form, bool shell, bool wait)
        {
            if (File.Exists(path))
            {
                Process process = new Process();
                process.StartInfo.FileName = path;
                if (arg != null)
                {
                    process.StartInfo.Arguments = arg;
                }
                process.StartInfo.WorkingDirectory = Path.GetDirectoryName(path);
                process.StartInfo.UseShellExecute = shell;
                if (onexit != null && form != null && !wait)
                {
                    process.EnableRaisingEvents = true;
                    process.Exited += onexit;
                }
                try
                {
                    process.Start();
                    if (wait)
                    {
                        process.WaitForExit();
                    }
                }
                catch
                {
                    MessageBox.Show(FormMain.textCouldRun + path);
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static bool checkOnlyLatinChars(string path)
        {
            try
            {
                byte[] ascii = Encoding.UTF8.GetBytes(path);
                for (int i = 0; i < ascii.Length; i++)
                {
                    if (ascii[i] == 63 || ascii[i] < 32 || ascii[i] > 126)
                    {
                        ascii = null;
                        return false;
                    }
                }
                ascii = null;
                return true;
            }
            catch
            {
                return false;
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static string pathAddSlash(string path)
        {
            if (!path.EndsWith("/") && !path.EndsWith(@"\"))
            {
                if (path.Contains("/"))
                {
                    path += "/";
                }
                else if (path.Contains(@"\"))
                {
                    path += @"\";
                }
            }
            return path;
        }
    }
}