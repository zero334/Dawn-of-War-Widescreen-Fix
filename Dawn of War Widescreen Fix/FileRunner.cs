using System;
using System.Collections.Generic;
using System.IO;

namespace Dawn_of_War_Widescreen_Fix
{
    class FileRunner
    {
        readonly AttributeStorage attributes;
        public FileRunner(AttributeStorage attributes)
        {
            this.attributes = attributes;
        }

        public bool ProcessFiles()
        {
            String filePath = attributes.FileStorage.FilePath;
            List<Tuple<String, bool>> files = attributes.FileStorage.Files;

            foreach (Tuple<String, bool> file in files)
            {
                if (file.Item2) {
                    String currentFile = filePath + '\\' + file.Item1;

                    byte[] fileContent = File.ReadAllBytes(currentFile);

                    String hexFile = ByteArrayToString(fileContent);
                    String replacedFileContent = hexFile.Replace(attributes.BaseString, attributes.ReplacementString);

                    byte[] fixedFileContent = StringToByteArray(replacedFileContent);

                    File.WriteAllBytes(currentFile, fixedFileContent);
                }
            }

            String iniFile = filePath + '\\' + attributes.FileStorage.LocalIni.Item1;
            String[] iniFileLinesInput = File.ReadAllLines(iniFile);
            List<String> iniFileLinesOutput = new List<String>();

            foreach (String line in iniFileLinesInput)
            {
                if (line.Contains("screenwidth"))
                {
                    iniFileLinesOutput.Add(RemoveAfter(line, '=') + attributes.Width);
                }
                else if (line.Contains("screenheight"))
                {
                    iniFileLinesOutput.Add(RemoveAfter(line, '=') + attributes.Height);
                }
                else
                {
                    iniFileLinesOutput.Add(line);
                }
            }
            File.WriteAllLines(iniFile, iniFileLinesOutput);
            return true;
        }

        public bool BackupFiles() {
            String filePath = attributes.FileStorage.FilePath;
            List<Tuple<String, bool>> files = attributes.FileStorage.Files;
            foreach (Tuple<String, bool> file in files)
            {
                if (file.Item2)
                {
                    String currentFile = filePath + '\\' + file.Item1;
                    String backupFile = filePath + '\\' + Path.GetFileNameWithoutExtension(currentFile) + "_backup" + Path.GetExtension(currentFile);
                    File.Copy(currentFile, backupFile);
                }
            }
            return true;
        }

        private static String RemoveAfter(String input, char delimiter)
        {
            int index = input.LastIndexOf(delimiter);
            if (index > 0)
            {
                return input.Substring(0, index + 1);
            }
            return input;
        }

        private static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        private static string ByteArrayToString(byte[] bytes)
        {
            char[] c = new char[bytes.Length * 2];
            int b;
            for (UInt32 i = 0; i < bytes.Length; i++)
            {
                b = bytes[i] >> 4;
                c[i * 2] = (char)(55 + b + (((b - 10) >> 31) & -7));
                b = bytes[i] & 0xF;
                c[i * 2 + 1] = (char)(55 + b + (((b - 10) >> 31) & -7));
            }
            return new String(c);
        }
    }
}