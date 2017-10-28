using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dawn_of_War_Widescreen_Fix
{
    class FileStorage
    {
        public String FilePath { get; private set; }
        public List<Tuple<String, bool>> Files { get; private set; }

        public Tuple<String, bool> LocalIni { get; private set; }
        public Tuple<String, bool> W40k { get; private set; }
        public Tuple<String, bool> W40kWA { get; private set; }
        public Tuple<String, bool> Platform { get; private set; }
        public Tuple<String, bool> SpDx9 { get; private set; }
        public Tuple<String, bool> UserInterface { get; private set; }
        private List<String> targetFiles;


        public FileStorage()
        {
            FilePath = "";
            Files = new List<Tuple<String, bool>>();

            LocalIni = new Tuple<String, bool>("Local.ini", false);

            W40k = new Tuple<String, bool>("W40k.exe", false);
            W40kWA = new Tuple<String, bool>("W40kWA.exe", false);
            Platform = new Tuple<String, bool>("Platform.dll", false);
            SpDx9 = new Tuple<String, bool>("spDx9.dll", false);
            UserInterface = new Tuple<String, bool>("UserInterface.dll", false);
            targetFiles = new List<String>() { W40k.Item1, W40kWA.Item1, Platform.Item1, SpDx9.Item1, UserInterface.Item1 };
        }

        public void SetFilePath(String path)
        {
            FilePath = "";
            if (File.Exists(path))
            {
                String directoryName = Path.GetDirectoryName(path);
                List<String> directoryContent = ProcessDirectory(directoryName);
    
                ConcurrentBag<Tuple<String, bool>> resultCollection = new ConcurrentBag<Tuple<String, bool>>();
                Parallel.ForEach(targetFiles, (currentFile) => {
                    resultCollection.Add(new Tuple<String, bool>(currentFile, directoryContent.Contains(currentFile)));
                });

                foreach (Tuple<String, bool> foundElements in resultCollection)
                {
                    if ((foundElements.Item1.Equals(W40k.Item1) || foundElements.Item1.Equals(W40kWA.Item1)) && foundElements.Item2 == true)
                    {
                        FilePath = directoryName;
                        Files = resultCollection.ToList();
                        break;
                    }
                }

                if (directoryContent.Contains(LocalIni.Item1)) {
                    LocalIni = new Tuple<String, bool>(LocalIni.Item1, true);
                }
            }
        }

        private List<String> ProcessDirectory(string targetDirectory)
        {
            List<String> files = new List<String>();
            foreach (string fileName in Directory.GetFiles(targetDirectory))
            {
                files.Add(Path.GetFileName(fileName));
            }
            return files;
        }

        public bool CheckFilePath()
        {
            return (FilePath.Length > 0) ? true : false;
        }
    }
}