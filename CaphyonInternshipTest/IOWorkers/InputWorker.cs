using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaphyonInternshipTest.IOWorkers
{
    public class InputWorker
    {
        private string FileName { get; set; }
        public InputWorker(string fileName)
        {
            FileName = fileName;
        }

        public Dictionary<string , List<string>> ProcessInput()
        {
            var lines = File
                .ReadAllLines(FileName)
                .Select(pair => new KeyValuePair<string, string>(pair.Split(' ').First(),
                                                                 pair.Split(' ').Last()));

            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            foreach (var pair in lines)
            {
                if (!graph.TryAdd(pair.Key, new List<string> { pair.Value }))
                {
                    graph[pair.Key].Add(pair.Value);
                }
            }
            return graph;
        }

        public List<List<string>> ProcessInputAsList()
        {
            List<List<string>> lines = new List<List<string>>();
            foreach (var pair in File.ReadAllLines(FileName))
            {
                var split = pair.Split(' ').ToList();
                lines.Add(split);
            }
            return lines;
        }
    }
}
