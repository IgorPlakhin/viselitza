
using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;



namespace _123
    {
        class Program
        {
          static  int index = 0;  

            static void Main(string[] args)
            {
           

            string filePath = @"\11.txt"; // имя файла
            
             string str = " ";
            string [] strng;

            HashSet<string> zs = new HashSet<string>();
            zs.Add("Deer");
            zs.Add("Bear");
            zs.Add("Swallow");
            zs.Add("Rabbit");


            //}
            // открываем файл если нет файла то создаем файл
            using (StreamWriter fileStream = File.Exists(filePath) ? File.AppendText(filePath) : File.CreateText(filePath))
            {

                foreach (string s in zs)
                {
                    fileStream.WriteLine(s);
                }
               
            }

            Random random = new Random();
            strng = File.ReadAllLines(filePath, Encoding.Default);

            index = random.Next(0, strng.Length);
            Console.WriteLine(strng[index]);


            Console.OutputEncoding = Encoding.GetEncoding(1251);
             //   Console.Write("Введите слово которое нужно будет отгадывать: ");
                string zagSL = strng[index];
                int lg = zagSL.Length, kilm = 0;
               // List<string> zs = new List<string>();
                int pop = 0;
                Console.Clear();
                while (true)
                {
                    if (pop == 5)
                    {
                        Console.WriteLine("Вы проиграли!");
                        Console.ReadKey();
                        break;
                    }
                    if (kilm == lg)
                    {
                        Console.WriteLine("Вы выиграли!");
                        Console.ReadKey();
                        break;
                    }
                    Console.Write("Введите букву: ");
                    string ch = Console.ReadLine().ToLower();
                    if (zagSL.Contains(ch[0]) && !zs.Contains(ch[0].ToString()))
                    {
                        for (int i = 0; i < zagSL.Length; i++)
                            if (zagSL[i] == ch[0])
                                ++kilm;
                        Console.WriteLine("Буква " + ch[0] + " есть в этом слове.");
                        zs.Add(ch[0].ToString());
                    }
                    else ++pop;
                }
                }
            }
        }
    

