
// подключаем библиотеку для работы с файлами
//using System.Collections.Generic;
//using System.IO;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;



//namespace _123
//{
//    class Loader
//    {
//        static int index = 0;

//        static void Main(string[] args)
//        {


//            string filePath = @"\11.txt"; // имя файла

//            string str = " ";
//            string[] strng;

//            HashSet<string> zs = new HashSet<string>();
//            zs.Add("Deer");
//            zs.Add("Bear");
//            zs.Add("Swallow");
//            zs.Add("Rabbit");


//            //}
//            // открываем файл если нет файла то создаем файл
//            using (StreamWriter fileStream = File.Exists(filePath) ? File.AppendText(filePath) : File.CreateText(filePath))
//            {

//                foreach (string s in zs)
//                {
//                    fileStream.WriteLine(s);
//                }
//            }

//            Random random = new Random();
//            strng = File.ReadAllLines(filePath, Encoding.Default);
//            index = random.Next(0, strng.Length);
//            Console.WriteLine(strng[index]);


//            Console.OutputEncoding = Encoding.GetEncoding(1251);
//        }
//    }
//}


//namespace ConsoleApplication1
//    {
//        class Program1
//        {
//            static void Main(string[] args)
//            {
//                string filePath = "//1.txt"; // имя файла
//            string str=" ";

//            List<string> zs = new List<string>();
//            zs.Add ("Deer");
//            zs.Add("Bear");
//            zs.Add("Swallow");
//            zs.Add("Rabbit");



//            // открываем файл если нет файла то создаем файл
//            using (StreamWriter fileStream = File.Exists(filePath) ? File.AppendText(filePath) : File.CreateText(filePath))
//            {
//                foreach (string s in zs)
//                {
//                    fileStream.WriteLine(zs[0]);
//                }
//            }
//            }
//        }
//    }



