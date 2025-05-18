using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace HW2
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("File Analyzer - .NET Core");
            Console.WriteLine("This tool analyzes text files and provides statistics.");

            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a file path as a command-line argument.");
                Console.WriteLine("Example: dotnet run myfile.txt");
                return;
            }

            string filePath = args[0];

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File '{filePath}' does not exist.");
                return;
            }

            try
            {
                Console.WriteLine($"Analyzing file: {filePath}");

                // Read the file content
                string content = File.ReadAllText(filePath);

                // TODO: Implement analysis functionality
                // 1. Count words
                // 2. Count characters (with and without whitespace)
                // 3. Count sentences
                // 4. Identify most common words
                // 5. Average word length

                // Example implementation for counting lines:
                int lineCount = File.ReadAllLines(filePath).Length;
                Console.WriteLine($"Number of lines: {lineCount}");


                // TODO: Additional analysis to be implemented
                int wordCount = content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
                Console.WriteLine($"Number of words: {wordCount}");

                Console.WriteLine($"Characters (with whitespace): {content.Length}");

                int charWithoutWhitespace = content.Count(c => !char.IsWhiteSpace(c));
                Console.WriteLine($"Characters (without whitespace): {charWithoutWhitespace}");

                int sentenceCount = content.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
                Console.WriteLine($"Number of sentences: {sentenceCount}");

                // Most common words
                string[] words = content.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var mostWords = words.Select(x => x.Trim().ToLower()).Where(x => x.All(char.IsLetterOrDigit))
                    .GroupBy(x => x).Take(1);
                foreach (var word in mostWords)
                {
                    Console.WriteLine($"most common words : {word.Key} count : {word.Count()}");
                }
                double x = words.Average(x => x.Length);
                Console.WriteLine($"Average : {x}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error during file analysis: {ex.Message}");
            }
        }
    }
}
