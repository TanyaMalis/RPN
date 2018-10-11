using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("H:\\f.txt"))
            {
                FileStream f = new FileStream("H:\\f.txt", FileMode.OpenOrCreate, FileAccess.Read);
                byte[] array = new byte[f.Length];
                f.Read(array, 0, array.Length);
                string textFromFile = Encoding.Default.GetString(array);

                Stroka str = new Stroka(textFromFile);
                List<string> strok = str.OutString();
                double res = str.Calculate(); 

                Console.WriteLine("Оригинальная строка: {0}", textFromFile);
                Console.Write("Преобразованная строка: ");
                foreach (string s in strok)
                {
                    Console.Write("{0}", s);
                }
                Console.WriteLine();
                Console.WriteLine("Результат: {0}", res);

                Console.ReadLine();
            }
        }

    }
}
