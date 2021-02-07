using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SLMPLauncher
{
    public class FuncParser
    {
        static List<string> cacheFile = new List<string>();
        static int startIndex = -1;
        static int enbIndex = -1;
        static int lineIndex = -1;
        static bool blockClearKE = false;
        static bool blockClearSR = false;
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static bool keyExists(string file, string section, string key)
        {
            startIndex = -1;
            enbIndex = -1;
            lineIndex = -1;
            bool findSection = false;
            bool findKey = false;
            if (File.Exists(file))
            {
                cacheFile.AddRange(File.ReadAllLines(file));
                for (int i = 0; i < cacheFile.Count; i++)
                {
                    if (!string.IsNullOrEmpty(cacheFile[i]) && !cacheFile[i].StartsWith(";"))
                    {
                        if (!findSection && cacheFile[i].Equals("[" + section + "]", StringComparison.OrdinalIgnoreCase))
                        {
                            findSection = true;
                            startIndex = i;
                            enbIndex = i;
                        }
                        else if (findSection && cacheFile[i].StartsWith("[") && cacheFile[i].EndsWith("]"))
                        {
                            break;
                        }
                        else if (findSection)
                        {
                            if (cacheFile[i].StartsWith(key + "=", StringComparison.OrdinalIgnoreCase))
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
            }
            if (blockClearKE)
            {
                blockClearKE = false;
            }
            else
            {
                cacheFile.Clear();
            }
            return findKey;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static string stringRead(string file, string section, string key)
        {
            string outString = null;
            blockClearKE = true;
            if (keyExists(file, section, key))
            {
                outString = cacheFile[lineIndex].Remove(0, (key + "=").Length);
                if (string.IsNullOrEmpty(outString))
                {
                    outString = null;
                }
            }
            if (blockClearSR)
            {
                blockClearSR = false;
            }
            else
            {
                cacheFile.Clear();
            }
            return outString;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void iniWrite(string file, string section, string key, string value)
        {
            bool readyToWrite = false;
            blockClearSR = true;
            string line = stringRead(file, section, key);
            if (lineIndex != -1)
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = null;
                }
                if (!string.Equals(line, value, StringComparison.OrdinalIgnoreCase))
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
                else if (File.Exists(file))
                {
                    FuncFiles.appendToFile(file, Environment.NewLine + "[" + section + "]" + Environment.NewLine + key + "=" + value);
                }
            }
            if (readyToWrite)
            {
                FuncFiles.writeToFile(file, cacheFile);
            }
            cacheFile.Clear();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static int intRead(string file, string section, string key)
        {
            return stringToInt(stringRead(file, section, key));
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static double doubleRead(string file, string section, string key)
        {
            return stringToDouble(stringRead(file, section, key));
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static bool readAsBool(string file, string section, string key)
        {
            string line = stringRead(file, section, key);
            return line != null && (line == "1" || string.Equals(line, "true", StringComparison.OrdinalIgnoreCase));
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
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
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static double stringToDouble(string input)
        {
            double value = -1;
            if (!string.IsNullOrEmpty(input))
            {
                Double.TryParse(input.Replace(',', '.'), NumberStyles.Number, CultureInfo.InvariantCulture, out value);
            }
            return value;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
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
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static List<string> parserESPESM(string file)
        {
            List<string> outString = new List<string>();
            if (File.Exists(file) && new FileInfo(file).Length > 50)
            {
                try
                {
                    FileStream fs = File.OpenRead(file);
                    byte[] bytesFile = new byte[8];
                    fs.Read(bytesFile, 0, 8);
                    if (equalsByteArrays(new byte[] { bytesFile[0], bytesFile[1], bytesFile[2], bytesFile[3] }, new byte[] { 84, 69, 83, 52 }))
                    {
                        int length = BitConverter.ToInt32(bytesFile, 4);
                        bytesFile = new byte[length];
                        fs.Seek(28, SeekOrigin.Begin);
                        fs.Read(bytesFile, 0, length);
                        fs.Close();
                        int attempts = 0;
                        bool start = false;
                        for (int i = BitConverter.ToInt16(bytesFile, 0) + 2; (i + 6) < length; i++)
                        {
                            if (equalsByteArrays(new byte[] { bytesFile[i], bytesFile[i + 1], bytesFile[i + 2], bytesFile[i + 3] }, new byte[] { 77, 65, 83, 84 }))
                            {
                                start = true;
                                int count = BitConverter.ToInt16(bytesFile, i + 4) - 1;
                                byte[] bytesText = new byte[count];
                                Buffer.BlockCopy(bytesFile, i + 6, bytesText, 0, count);
                                outString.Add(Encoding.UTF8.GetString(bytesText));
                                i += count + 20;
                            }
                            else if (!start && attempts < 5)
                            {
                                attempts++;
                                i += 5 + BitConverter.ToInt16(bytesFile, i + 4);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        fs.Close();
                        outString.Add("NOT TES5 FILE");
                    }
                    bytesFile = null;
                }
                catch
                {
                    outString.Clear();
                    outString.Add("FILE READ ERROR");
                }
            }
            return outString;
        }
        private static bool equalsByteArrays(byte[] ba1, byte[] ba2)
        {
            for (int i = 0; i < ba1.Length; i++)
            {
                if (ba1[i] != ba2[i])
                {
                    return false;
                }
            }
            return true;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
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
    }
}