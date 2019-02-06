using System.IO;
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
                    MessageBox.Show(FormMain.couldNotDelete + path);
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
                    MessageBox.Show(FormMain.couldNotDelete + path);
                }
            }
        }
        public static void deleteAllInFolder(string path, string ext)
        {
            if (Directory.Exists(path))
            {
                foreach (string line in Directory.GetFiles(path, ext))
                {
                    FuncFiles.deleteAny(line);
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
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
                        MessageBox.Show(FormMain.couldNotMove + from + " > " + to);
                    }
                }
                else
                {
                    MessageBox.Show(FormMain.alreadyExists + to);
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
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
                    MessageBox.Show(FormMain.failedCopy + from);
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
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
                    MessageBox.Show(FormMain.failedCreate + dir);
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static string pathAddSlash(string path)
        {
            if (path.EndsWith(@"/") || path.EndsWith(@"\"))
            {
                return path;
            }
            else if (path.Contains(@"/"))
            {
                return path + @"/";
            }
            else if (path.Contains(@"\"))
            {
                return path + @"\";
            }
            return path;
        }
    }
}