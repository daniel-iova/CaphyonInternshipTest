using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CaphyonInternshipTest.IOWorkers
{
    public class OutputWorker
    {
        private string FileName { get; set; }

        public OutputWorker()
        {
        }

        public void SetFileName(string fileName)
        {
            FileName = fileName;
        }

        public void DisplayUniquePackages(List<string> list)
        {
            File.WriteAllLines(FileName, list);
        }

        public void DisplayPackagesAndDependencies(Dictionary<string, List<string>> packageDictionary)
        {
            File.WriteAllText(FileName, "");
            foreach (var package in packageDictionary)
            {
                File.AppendAllText(FileName, package.Key + ' ');
                if (package.Value != null)
                {
                    string dependencies = "";
                    package.Value.ForEach(dep => dependencies += dep + " ");
                    File.AppendAllText(FileName, dependencies);
                }
                File.AppendAllText(FileName, "\n");
            }
        }
        
        public void DisplayMissingDependencies(List<List<string>> missingList)
        {
            File.WriteAllText(FileName, "");
            foreach (var missing in missingList)
            {
                if (missing != null)
                {
                    string missingString = "";
                    missing.ForEach(dep => missingString += dep + " ");
                    File.AppendAllText(FileName, missingString);
                }
                File.AppendAllText(FileName, "\n");
            }
        }

    }
}
