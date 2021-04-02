using CaphyonInternshipTest.IOWorkers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CaphyonInternshipTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Init I/O Workers
            string path = Directory.GetCurrentDirectory();
            InputWorker inputWorker = new InputWorker(Path.Combine(path, "disp.in"));
            OutputWorker outputWorker = new OutputWorker();

            // Init Graph
            Graph graph = new Graph(inputWorker.ProcessInput());

            // Execute Tasks
            Task1(path, outputWorker, graph);
            Task2(path, outputWorker, graph);
            Task3(path, outputWorker, graph);

        }

        private static void Task3(string path, OutputWorker outputWorker, Graph graph)
        {
            InputWorker inputWorker = new InputWorker(Path.Combine(path, "computers.in"));
            outputWorker.SetFileName(Path.Combine(path, "task3.out"));
            outputWorker.DisplayMissingDependencies(graph.GetMissingDependencies(inputWorker.ProcessInputAsList()));
        }

        private static void Task1(string path, OutputWorker outputWorker, Graph graph)
        {
            outputWorker.SetFileName(Path.Combine(path, "task1.out"));
            outputWorker.DisplayUniquePackages(graph.GetUniquePackages());
        }
        private static void Task2(string path, OutputWorker outputWorker, Graph graph)
        {
            outputWorker.SetFileName(Path.Combine(path, "task2.out"));
            outputWorker.DisplayPackagesAndDependencies(graph.GetPackagesWithDependencies());
        }

    }
}
