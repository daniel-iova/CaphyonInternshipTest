using CaphyonInternshipTest.IOWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaphyonInternshipTest
{
    public class Graph
    {
        private Dictionary<string, List<string>> AdjacencyDictionary { get; set; }
        public Graph(Dictionary<string, List<string>> adjacencyDictionary)
        {
            AdjacencyDictionary = adjacencyDictionary;
            
        }
        // Task 1 Method
        public List<string> GetUniquePackages()
        {
            List<string> unique = new List<string>();
            foreach (var pair in AdjacencyDictionary)
            {
                if (!unique.Contains(pair.Key)) unique.Add(pair.Key);
                foreach (var dep in pair.Value.Where(dep => !unique.Contains(dep))) { 
                    unique.Add(dep);
                    }
            }
            unique.Sort();
            return unique;
        }
        // Task 2 Methods
        internal Dictionary<string, List<string>> GetPackagesWithDependencies()
        {
            Dictionary<string, List<string>> pkgsWithDeps = new Dictionary<string, List<string>>();
            var uniquePackages = GetUniquePackages();
            foreach (var key in uniquePackages)
            {
                if (!AdjacencyDictionary.ContainsKey(key))
                {
                    pkgsWithDeps.Add(key, null);
                }
                else
                {
                    pkgsWithDeps.Add(key, DFS(key, uniquePackages));
                }
            }
            return pkgsWithDeps;
        }
        private List<string> DFS(string key, List<string> uniquePackages)
        {
            List<string> dependencies = new List<string>();
            var Visited = new Dictionary<string, bool>();
            uniquePackages.ForEach(package => Visited.Add(package, false));
            DFSUtil(dependencies, key, key, Visited);
            dependencies.Sort();
            return dependencies;
        }
        private void DFSUtil(List<string> dependencies, string key, string currentKey, Dictionary<string, bool> Visited)
        {
            Visited[currentKey] = true;
            if (currentKey != key) dependencies.Add(currentKey);
            if (AdjacencyDictionary.ContainsKey(currentKey))
            {
                foreach (string adjacent in AdjacencyDictionary[currentKey])
                {
                    string adj = adjacent;
                    if (!Visited[adj])
                    {
                        DFSUtil(dependencies, key, adj, Visited);
                    }
                }
            }
        }
        // Task 3 Methods
        public List<List<string>> GetMissingDependencies(List<List<string>> erroredList)
        {
            var correctDictionary = GetPackagesWithDependencies();
            List<List<string>> missing = new List<List<string>>();

            foreach (List<string> line in erroredList)
            {
                missing.Add(correctDictionary[line[0]]?.Except(line)?.ToList());
            }
            return missing;
        }
    }
}
