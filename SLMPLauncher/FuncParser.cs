using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SLMPLauncher
{
    public class FuncParser
    {
        static List<string> cacheFile = new List<string>();
        static int startIndex = -1;
        static int enbIndex = -1;
        static int lineIndex = -1;
        static bool blockClearEK = false;
        static bool blockClearSR = false;
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static bool keyExists(string path, string section, string key)
        {
            startIndex = -1;
            enbIndex = -1;
            lineIndex = -1;
            bool findSection = false;
            bool findKey = false;
            if (File.Exists(path) && !string.IsNullOrEmpty(section) && !string.IsNullOrEmpty(key))
            {
                cacheFile = new List<string>(File.ReadAllLines(path));
                for (int i = 0; i < cacheFile.Count; i++)
                {
                    if (!findSection && cacheFile[i].ToLower() == "[" + section.ToLower() + "]")
                    {
                        findSection = true;
                        startIndex = i;
                        enbIndex = i;
                    }
                    else if (findSection && cacheFile[i].StartsWith("[") && cacheFile[i].EndsWith("]"))
                    {
                        break;
                    }
                    else if (findSection && cacheFile[i].Length > 0)
                    {
                        if (cacheFile[i].ToLower().StartsWith(key.ToLower() + "="))
                        {
                            findKey = true;
                            lineIndex = i;
                            break;
                        }
                        else
                        {
                            enbIndex = i;
                        }
                    }
                }
            }
            if (!blockClearEK)
            {
                cacheFile = null;
            }
            return findKey;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static string stringRead(string path, string section, string key)
        {
            string outString = null;
            blockClearEK = true;
            if (keyExists(path, section, key))
            {
                outString = cacheFile[lineIndex].Remove(0, (key + "=").Length);
                if (outString.Length == 0)
                {
                    outString = null;
                }
            }
            blockClearEK = false;
            if (!blockClearSR)
            {
                cacheFile = null;
            }
            return outString;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void iniWrite(string path, string section, string key, string value)
        {
            bool readyToWrite = false;
            blockClearSR = true;
            string line = stringRead(path, section, key);
            blockClearSR = false;
            if (lineIndex != -1)
            {
                if (line == null || value == null || line.ToLower() != value.ToLower())
                {
                    cacheFile[lineIndex] = key + "=" + value;
                    readyToWrite = true;
                }
            }
            else
            {
                if (startIndex != -1 && enbIndex != -1)
                {
                    cacheFile[enbIndex] += Environment.NewLine + key + "=" + value;
                    readyToWrite = true;
                }
                else
                {
                    File.AppendAllText(path, Environment.NewLine + "[" + section + "]" + Environment.NewLine + key + "=" + value + Environment.NewLine);
                }
            }
            if (readyToWrite)
            {
                FuncMisc.writeToFile(path, cacheFile);
            }
            cacheFile = null;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static int intRead(string path, string section, string key)
        {
            int value = -1;
            string line = stringRead(path, section, key);
            if (!string.IsNullOrEmpty(line))
            {
                value = stringToInt(line);
            }
            return value;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static double doubleRead(string path, string section, string key)
        {
            double value = -1.0;
            string line = stringRead(path, section, key);
            if (!string.IsNullOrEmpty(line))
            {
                value = stringToDouble(line);
            }
            return value;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static bool readAsBool(string path, string section, string key)
        {
            string line = stringRead(path, section, key);
            return line != null && (line == "1" || line.ToLower() == "true");
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static int stringToInt(string input)
        {
            int value = -1;
            if (!string.IsNullOrEmpty(input))
            {
                if (input.Contains("."))
                {
                    Int32.TryParse(input.Remove(input.IndexOf('.')), out value);
                }
                else if (input.Contains(","))
                {
                    Int32.TryParse(input.Remove(input.IndexOf(',')), out value);
                }
                else
                {
                    Int32.TryParse(input, out value);
                }
            }
            return value;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static double stringToDouble(string input)
        {
            double value = -1;
            if (!string.IsNullOrEmpty(input))
            {
                Double.TryParse(input.Replace(',', '.'), NumberStyles.Number, CultureInfo.InvariantCulture, out value);
            }
            return value;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static string convertFileSize(double input)
        {
            string[] units = new string[] { "B", "KB", "MB", "GB", "TB", "PB" };
            double mod = 1024.0;
            int i = 0;
            while (input >= mod)
            {
                input /= mod;
                i++;
            }
            return Math.Round(input, 2) + units[i];
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static List<string> parserESPESM(string file)
        {
            List<string> outString = new List<string>();
            if (File.Exists(file) && new FileInfo(file).Length > 50)
            {
                try
                {
                    FileStream fs = File.OpenRead(file);
                    byte[] bytesFile1 = new byte[4];
                    fs.Read(bytesFile1, 0, 4);
                    if (string.Join("", bytesFile1) == "84698352")
                    {
                        bool must = false;
                        int read = 0;
                        string line = null;
                        byte[] bytesFile2 = new byte[1024];
                        fs.Seek(46, SeekOrigin.Begin);
                        fs.Seek(47 + fs.ReadByte(), SeekOrigin.Begin);
                        fs.Read(bytesFile2, 0, 1024);
                        for (int i = 0; i < bytesFile2.Count(); i++)
                        {
                            read = bytesFile2[i];
                            if ((line == "GRUP" || line == "ONAM") && !must)
                            {
                                break;
                            }
                            else if (line == "MAST" && !must)
                            {
                                must = true;
                                line = null;
                            }
                            else if (read >= 32 && read <= 126)
                            {
                                line += Convert.ToChar(read).ToString();
                            }
                            else if (must && !string.IsNullOrEmpty(line))
                            {
                                outString.Add(line);
                                must = false;
                                line = null;
                            }
                            else
                            {
                                line = null;
                            }
                        }
                        bytesFile2 = null;
                    }
                    bytesFile1 = null;
                    fs.Close();
                }
                catch
                {
                    outString.Clear();
                    outString.Add("ERROR FILE READ");
                }
            }
            return outString;
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static bool checkESM(string file)
        {
            if (File.Exists(file) && new FileInfo(file).Length > 50)
            {
                try
                {
                    FileStream fs = File.OpenRead(file);
                    fs.Seek(8, SeekOrigin.Begin);
                    int read = fs.ReadByte();
                    fs.Close();
                    return read == 1 || read == 129;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static string loadOrderID(int number)
        {
            if (number < 256)
            {
                return BitConverter.ToString(BitConverter.GetBytes(number), 0, 1);
            }
            else
            {
                return null;
            }
        }
    }
}