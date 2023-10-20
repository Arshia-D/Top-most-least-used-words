using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAA_S3
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            string filename = @"Path"; //Enter your desired path.
          
            Dictionary<string, int> wordCounts = CountWords(filename);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Top 10 most used words:");
            Console.ResetColor();
            PrintWordCounts(GetTopWords(wordCounts));

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nTop 10 least used words:");
            Console.ResetColor();
            PrintWordCounts(GetBottomWords(wordCounts));

            Console.ReadKey();
        }

        static Dictionary<string, int> CountWords(string filename)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(' ');
                    foreach (string word in words)
                    {
                        if (wordCounts.ContainsKey(word))
                        {
                            wordCounts[word]++;
                        }
                        else
                        {
                            wordCounts.Add(word, 1);
                        }
                    }
                }
            }
            return wordCounts;
        }

        static IEnumerable<KeyValuePair<string, int>> GetTopWords(Dictionary<string, int> wordCounts)
        {
            return wordCounts.OrderByDescending(kv => kv.Value).Take(10);
        }

        static IEnumerable<KeyValuePair<string, int>> GetBottomWords(Dictionary<string, int> wordCounts)
        {
            return wordCounts.OrderBy(kv => kv.Value).Take(10);
        }

        static void PrintWordCounts(IEnumerable<KeyValuePair<string, int>> wordCounts)
        {
            foreach (var kv in wordCounts)
            {
                Console.WriteLine("{0}: {1}", kv.Key, kv.Value);
            }
        }
    }
}