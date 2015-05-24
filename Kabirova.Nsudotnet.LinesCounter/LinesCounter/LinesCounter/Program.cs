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
            // Выбор директории и поиск файлов с заданным расширением
            Console.WriteLine("Choose directory:");
            string path = Console.ReadLine();
            Console.WriteLine("Choose type of files:");
            string type = Console.ReadLine();

            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] csFiles = dir.GetFiles(type, SearchOption.AllDirectories);
            Console.WriteLine("{0} {1} files found in {2}", csFiles.Length,type,path);
            Console.WriteLine();
            
            // Поиск и подсчет пустых строк и строк с комментариями
            foreach (FileInfo f in csFiles)
            {
                string[] NewFile = File.ReadAllLines(f.FullName);
                int Count = 0;
                foreach (string str in NewFile)
                {
                    if (String.IsNullOrWhiteSpace(str) == true || str.StartsWith("// ") == true || str.Contains(" // "))
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
