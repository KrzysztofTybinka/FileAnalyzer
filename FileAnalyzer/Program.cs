﻿namespace FileAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File Analyzer is a command-line interface application that provides \n" +
                "methods to analyze data files using different functions given by the user. \n" +
                "User inputs data in format: attribute -method value path\n\n" +
                "Where:\n- attribute is file attribute user wants to perform function on.\n" +
                "- method is one of the available methods to perform with given attribute.\n" +
                "- value is method argument.\n-path is a file path.\n\n" +
                "Available methods:\n" +
                "-gt - greater than, prints all attribute values that are greater than given value.\n" +
                "-st - smaller than, prints all attribute values that are smaller than given value.\n" +
                "-pt - prints list of attribute values with length specified by the value (for all input 0).\n\n" +
                "Supported file types - json, xml\n" +
                "─────────────────────────────────────────────────────────────────\n\n");

            while (true)
            {
                try
                {
                    Console.WriteLine("Input data in format: attribute -method value path\nTo escape press enter.");
                    string? input = Console.ReadLine();

                    if (String.IsNullOrEmpty(input))
                    {
                        Environment.Exit(0);
                    }

                    Phrase phrase = new Phrase();
                    Console.WriteLine();
                    phrase.Interpret(input).ForEach(x => Console.Write(x + " "));

                    Console.WriteLine("\n");
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found, try again.\n");
                }
                catch(KeyNotFoundException)
                {
                    Console.WriteLine("Incorrect atribute name, try again.\n");
                }
                catch(FileLoadException)
                {
                    Console.WriteLine("File type not supported, try again with different file type.\n");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input format, try again.\n");
                }
            }

        }
    }
}