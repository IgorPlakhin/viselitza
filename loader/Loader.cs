
// подключаем библиотеку для работы с файлами
//using System.Collections.Generic;
//using System.IO;

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



