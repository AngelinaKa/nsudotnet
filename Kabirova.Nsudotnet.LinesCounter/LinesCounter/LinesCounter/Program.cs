using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LinesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Выбор директории и поиск файлов с заданным разрешением
            string path = @"C:\Users\Ангелина.notebook\Desktop";
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] csFiles = dir.GetFiles("*.cs", SearchOption.AllDirectories);
            Console.WriteLine("{0} .cs files found in {1}", csFiles.Length,path);
            Console.WriteLine();
            
            // Поиск и подсчет пустых строк и строк с комментариями
            foreach (FileInfo f in csFiles)
            {
                string[] NewFile = File.ReadAllLines(f.FullName);
                int Count = 0;
                foreach (string str in NewFile)
                {
                    if (String.IsNullOrWhiteSpace(str) == true || str.StartsWith("// ") == true)
                        Count++;
                }
                Console.WriteLine("Full name of file: {0}", f.FullName);
                Console.WriteLine("Number of empty lines or lines with comments {0}.", Count);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
