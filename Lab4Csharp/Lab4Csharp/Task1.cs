using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using static System.Console;

namespace Lab4Csharp
{
    class Task1
    {
        static readonly string RESOURCES_PATH = Path.Combine(Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location), @"Resources");

        static void Main(string[] args)
        {
            List<string> fileNames = AddTrackedFileNames();
            List<long> validPairProducts = new List<long>();
            int[] pairValues = new int[2];
            string line;
            try
            {
                using (StreamWriter notFoundedFilesTracker = new StreamWriter(
                    File.Open(RESOURCES_PATH + "\\" + "no_file.txt", FileMode.Create)))
                using (StreamWriter invalidFilesTracker = new StreamWriter(
                    File.Open(RESOURCES_PATH + "\\" + "bad_data.txt", FileMode.Create)))
                using (StreamWriter overflowTypeFilesTracker = new StreamWriter(
                    File.Open(RESOURCES_PATH + "\\" + "overflow.txt", FileMode.Create)))
                {
                    for (int i = 0; i < fileNames.Count; i++)
                    {
                        try
                        {
                            using (StreamReader streamReader = new StreamReader(
                                File.Open(RESOURCES_PATH + "\\" + fileNames[i], FileMode.Open)))
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    line = streamReader.ReadLine();
                                    pairValues[j] = int.Parse(line);
                                }
                            }
                        }
                        catch (FileNotFoundException ex)
                        {
                            notFoundedFilesTracker.Write(fileNames[i] + " ");
                            WriteLine(ex.Message);
                            continue;
                        }
                        catch (Exception ex) when (
                           ex is FormatException 
                        || ex is ArgumentNullException 
                        || ex is ArgumentException)
                        {
                            invalidFilesTracker.Write(fileNames[i] + " ");
                            WriteLine("Invalid argument in file " + fileNames[i]);
                            continue;
                        }
                        catch (OverflowException ex)
                        {
                            overflowTypeFilesTracker.Write(fileNames[i] + " ");
                            WriteLine(ex.Message);
                            continue;
                        }
                        validPairProducts.Add(pairValues[0] * pairValues[1]);
                    }
                }
            }
            catch (IOException ex)
            {
                WriteLine(ex.Message);
            }
            PrintStatistics(validPairProducts);
            ReadKey();
        }

        private static List<string> AddTrackedFileNames()
        {
            List<string> fileNames = new List<string>(19);
            for (int i = 10; i < 30; i++) fileNames.Add(i + ".txt");
            return fileNames;
        }

        private static void PrintStatistics(List<long> validPairProducts)
        {
            WriteLine("Products: ");
            for (int i = 0; i < validPairProducts.Count; i++)
            {
                Write(validPairProducts[i] + "\t");
            }
            WriteLine("\nProducts average: " + (validPairProducts.Count > 0 ? validPairProducts.Average() : 0));
            WriteLine("Sum of all valid pair products: " + validPairProducts.Sum());
        }
    }
}
