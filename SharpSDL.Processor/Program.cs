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
        private const string LoaderFileName = "SDL.Loader.cs";

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

            var functions = new HashSet<string>();
            var loaderPath = Path.Combine(path, LoaderFileName);

            Console.WriteLine($"Reading loader from: {loaderPath}");

            if (!File.Exists(loaderPath))
            {
                Console.WriteLine("Loader does not exist.");
            }
            else
            {
                foreach (var function in ParseLoaderFunctions(loaderPath))
                {
                    functions.Add(function);
                }

                Console.WriteLine($"Found {functions.Count} existing functions.");
            }

            Console.WriteLine();

            foreach (var file in Directory.EnumerateFiles(path, "*.cs"))
            {
                Console.WriteLine($"Processing file: {file}");

                foreach (var function in ProcessFile(file))
                {
                    Console.WriteLine($"Processing function: {function}");

                    functions.Add(function);
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Generating loader at {loaderPath}.");

            GenerateLoader(loaderPath, functions.OrderBy(f => f));

            Console.WriteLine();
            Console.WriteLine("Done!");
        }

        private static IEnumerable<string> ParseLoaderFunctions(string path)
        {
            const string pattern = @"(\w+_f) = library\.LoadFunction<(\w+_d)>\(nameof\((.+)\)\);";

            foreach (var line in File.ReadLines(path))
            {
                var match = Regex.Match(line, pattern);

                if (!match.Success)
                {
                    continue;
                }

                yield return match.Groups[3].Value;
            }
        }

        private static IEnumerable<string> ProcessFile(string file)
        {
            var result = new List<string>();
            var functions = new List<string>();

            foreach (var line in File.ReadLines(file))
            {
                if (line.Contains("static extern"))
                {
                    result.Add(ProcessExternFunction(line, out var name));
                    functions.Add(name);
                }
                else
                {
                    result.Add(line);
                }
            }

            File.WriteAllLines(file, result);

            return functions;
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

        private static void GenerateLoader(string loaderPath, IEnumerable<string> functions)
        {
            using (StreamWriter writer = new StreamWriter(loaderPath))
            {
                writer.WriteLine("using NativeLibraryLoader;");
                writer.WriteLine();
                writer.WriteLine("namespace SharpSDL");
                writer.WriteLine("{");
                writer.WriteLine("    public static partial class SDL");
                writer.WriteLine("    {");
                writer.WriteLine("        private static NativeLibrary library;");
                writer.WriteLine();
                writer.WriteLine("        public static void LoadLibrary(string name = \"SDL2\")");
                writer.WriteLine("        {");
                writer.WriteLine("            library?.Dispose();");
                writer.WriteLine("            library = new NativeLibrary(name);");
                writer.WriteLine();

                foreach (var function in functions)
                {
                    writer.WriteLine($"            {function}_f = library.LoadFunction<{function}_d>(nameof({function}));");
                }

                writer.WriteLine("        }");
                writer.WriteLine("    }");
                writer.WriteLine("}");
            }
        }
    }
}
