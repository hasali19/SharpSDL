using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SharpSDL.Processor
{
    /// <summary>
    /// Processes the bindings files to replace extern methods with
    /// the boilerplate delegate code.
    /// </summary>
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Path not specified.");
                return 1;
            }

            var path = Path.GetFullPath(args[0]);

            if (!Directory.Exists(path))
            {
                Console.WriteLine($"{path} is not a directory.");
                return 2;
            }

            ProcessDirectory(path);

            return 0;
        }

        private static void ProcessDirectory(string path)
        {
            Console.WriteLine($"Processing directory: {path}");
            Console.WriteLine();

            foreach (var file in Directory.EnumerateFiles(path, "*.cs"))
            {
                Console.WriteLine($"Processing file: {file}");
                Console.WriteLine();

                ProcessFile(file);
            }

            Console.WriteLine();
            Console.WriteLine("Done!");
        }

        private static void ProcessFile(string file)
        {
            var result = new List<string>();

            foreach (var line in File.ReadLines(file))
            {
                if (line.Contains("static extern"))
                {
                    result.Add(ProcessExternFunction(line, out var name));
                    Console.WriteLine($"Processing function: {name}");
                }
                else
                {
                    result.Add(line);
                }
            }

            File.WriteAllLines(file, result);
        }

        private static string ProcessExternFunction(string line, out string name)
        {
            const string pattern = @"static extern ([\w|*]+) (\w+)\((.+)?\);";

            var indent = new string(' ', line.Length - line.TrimStart().Length);
            var match = Regex.Match(line, pattern);

            name = match.Groups[2].Value;

            var returnType = match.Groups[1].Value;
            var parameters = match.Groups[3].Value;
            var arguments = string.IsNullOrWhiteSpace(parameters)
                ? ""
                : string.Join(", ", parameters.Split(", ")
                    .Select(param => param.Split(' ')[1]));

            return $"{indent}[UnmanagedFunctionPointer(CallingConvention.Cdecl)]" + Environment.NewLine
                + $"{indent}private delegate {returnType} {name}_d({parameters});" + Environment.NewLine
                + Environment.NewLine
                + $"{indent}private static {name}_d {name}_f;" + Environment.NewLine
                + Environment.NewLine
                + $"{indent}public static {returnType} {name}({parameters}) => {name}_f({arguments});";
        }
    }
}
