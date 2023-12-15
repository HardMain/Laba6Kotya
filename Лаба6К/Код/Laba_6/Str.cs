using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laba_6
{
    internal class Str
    {
        string? str;
        public Str() 
        {
            str = null;
        }
        public Str(string str)
        {
            this.str = str;
        }
        public void ManualFill()
        {
            Console.WriteLine("\tВведите строку");
            str = Console.ReadLine();
            Console.WriteLine();
        }
        public void PreparedLines()
        {
            string str1 = "gkeog mql? k g;gig. adw; gkdi dja, gj.,g oqt gotg.";
            string str2 = "gkr ggg. wi! rg wotkdo. w vmdn a;ptkw fg,dj qwt. t qritwq.";
            string str3 = "tigkawg,wp gjrw s. q[wa gitkv fqw! it fksaw fj;gr,aj.";

            string msg = $"\tВыберите строку из заготовленных\n1. {str1}\n\n2. {str2}\n\n3. {str3}\n\n-> ", errorMsg = "\nТакого пункта меню не существует!\n";
            bool notExit = true;
            
            do
            {
                int choice = CheckAndInput.InputIntNumber(msg);

                if (choice == 1)
                {
                    Console.WriteLine();
                    str = str1;
                    notExit = false;
                }
                else if (choice == 2)
                {
                    Console.WriteLine();
                    str = str2;
                    notExit = false;
                }
                else if (choice == 3)
                {
                    Console.WriteLine();
                    str = str3;
                    notExit = false;
                }
                else
                    Console.WriteLine(errorMsg);
            } while (notExit);
        }
        public void ShowStr()
        {
            Console.WriteLine("----- Строка -----");

            if (str == null || str.Length == 0)
            {
                Console.WriteLine("Пустая строка!\n");
                return;
            }    

            Console.WriteLine(str + '\n');
        }
        public void DeleteSentences()
        {   
            if (str == null || str.Length == 0)
            {
                Console.WriteLine("Нет предложений для удаления!");
                return;
            }

            string[] sentences = SplitIntoSentences();
            string tempStr = "";
            for (int i = 0; i < sentences.Length; i++)
            {
                if (i != 0 && i != sentences.Length - 2)
                    tempStr += sentences[i];
            }
            str = tempStr;
        }
        public string[] SplitIntoSentences()
        {
            string pattern = @"(?<=[.!?])";
            string[] sentences = Regex.Split(str, pattern);

            return sentences;
        }
        public void ContinuePartTwo()
        {
            string msg = "1. Продолжить задание\n2. Перейти к следующему\n-> ", errorMsg = "\nТакого пункта меню не существует!\n";
            bool notExit = true;

            do
            {
                int choice = CheckAndInput.InputIntNumber(msg);

                if (choice == 1)
                {
                    Console.WriteLine();
                    DeleteSentences();
                    ShowStr();
                    ContinuePartTwo();
                    notExit = false;
                }
                else if (choice == 2)
                    return;
                else
                    Console.WriteLine(errorMsg);
            } while (notExit);
        }
    }
}
