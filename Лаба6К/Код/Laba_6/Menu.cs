using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6
{
    internal static class Menu
    {
        static public void CallMenu()
        {
            bool isNonExit = true;
            int choice = 0;
            string msg = "", errorMsg = "\nТакого пункта меню не существует!\n";

            do
            {
                Console.Clear();
                Console.WriteLine("----- Добро пожаловать в МЕНЮ программы! -----\n");
                msg = "1. Удалить все строки, в которых есть число, совпадающее с максимальным элементом.\n" +
                      "2. Удалить первое и последнее предложение в строке.\n" +
                      "3. Завершить работу программы.\n-> ";

                choice = CheckAndInput.InputIntNumber(msg);
                switch (choice)
                {
                    case 1:
                        Console.Clear(); Matrix matrix = new Matrix(); choiceFill(matrix); matrix.ShowMatrix(); matrix.DeleteRows(); matrix.ShowMatrix(); matrix.ContinuePartOne(); Console.WriteLine(); break;
                    case 2:
                        Console.Clear(); Str str = new Str(); choiceFill(str); str.ShowStr(); str.DeleteSentences(); str.ShowStr(); str.ContinuePartTwo(); break;
                    case 3:
                        isNonExit = false; break;
                    default:
                        Console.WriteLine(errorMsg); break;
                }

                if (isNonExit)
                {
                    Console.Write("Нажмите любую клавишу для продолжения. . .");
                    Console.ReadKey();
                }

            } while (isNonExit);
        }
        static public void choiceFill(Matrix matrix)
        {
            string msg = "\tВыберите как заполнить рваный массив\n1.Вручную\n2.Рандомно\n-> ", errorMsg = "\nТакого пункта меню не существует!\n";
            bool notExit = true;

            do
            {
                int choice = CheckAndInput.InputIntNumber(msg);

                if (choice == 1)
                {
                    Console.WriteLine();
                    matrix.ManualFill();
                    notExit = false;
                }
                else if (choice == 2)
                {
                    Console.WriteLine();
                    matrix.RandomFill();
                    notExit = false;
                }
                else
                    Console.WriteLine(errorMsg);
            } while (notExit);
        }
        static public void choiceFill(Str str)
        {
            string msg = "\tВыберите как заполнить строку\n1.Вручную\n2.Выбрать заготовленную\n-> ", errorMsg = "\nТакого пункта меню не существует!\n";
            bool notExit = true;

            do
            {
                int choice = CheckAndInput.InputIntNumber(msg);

                if (choice == 1)
                {
                    Console.WriteLine();
                    str.ManualFill();
                    notExit = false;
                }
                else if (choice == 2)
                {
                    Console.WriteLine();
                    str.PreparedLines();
                    notExit = false;
                }
                else
                    Console.WriteLine(errorMsg);
            } while (notExit);
        }
    }
}
