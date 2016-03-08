﻿namespace CultureGenerator
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Collections.Generic;

    class Program
    {
        static string filePrefix = "kendo.culture";
        static string outputPath = "C:\\work\\kendo\\src\\cultures";
        static string culturePatternPath = "kendo.culture.format.txt";
        static string culturePattern = "";

        static void Main(string[] args)
        {
            Console.WriteLine("/*** Culture Generator ***/");

            List<CultureInfo> cultures = null;

            foreach (string param in args)
            {
                if (param.StartsWith("--path="))
                {
                    outputPath = param.Substring("--path=".Length);
                }
                else if (param.StartsWith("--pattern-path="))
                {
                    culturePatternPath = param.Substring("--pattern-path=".Length);
                }
                else if (param.StartsWith("--culture="))
                {
                    try
                    {
                        cultures = new List<CultureInfo> {
                            new CultureInfo(param.Substring("--culture=".Length))
                        };
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
                else if (param.StartsWith("--file-prefix="))
                {
                    filePrefix = param.Substring("--file-prefix=".Length);
                }
                else if (param == "--help")
                {
                    Console.Write(@"
Usage:CultureGenerator [<options>]

options:
    --culture=<CultureName> The name of the culture to generate script from

    --path=<PATH> The output path where the file will be created. Default: C:\Work\Kendo\src\cultures

    --pattern-path=<PATH> Full Path to the culture pattern used to generate culture.js files. Default: current folder\pattern name => .\kendo.culture.format.txt

    --file-prefix=<PREFIX> The prefix of the culture file name. Default: kendo.globalize
");
                    return;
                }
            }

            Console.WriteLine("Retrieve culture pattern...");
            try
            {
                Console.WriteLine(culturePatternPath);
                culturePattern = File.ReadAllText(culturePatternPath);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("error: FileNotFoundException!");
                Console.WriteLine(ex.Message);
                return;
            }

            Directory.CreateDirectory(outputPath);

            Console.WriteLine("Start generating culture files...");

            if (cultures == null)
            {
                cultures = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();
            }

            //Generate {filePrefix}.culture.{cultureName}.js for all cultures.
            cultures.ForEach(WriteCulture);

            Console.WriteLine("End...");
        }

        private static void WriteCulture(CultureInfo cultureInfo)
        {
            if (!string.IsNullOrEmpty(cultureInfo.Name))
            {
                var filePath = String.Format(@"{0}\{1}.{2}.js", outputPath, filePrefix, cultureInfo.Name);
                File.WriteAllText(filePath, cultureInfo.Format(culturePattern), Encoding.UTF8);
                Console.WriteLine(filePath);
            }
        }
    }
}