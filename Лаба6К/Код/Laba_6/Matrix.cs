using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laba_6
{
    internal class Matrix
    {
        static Random random = new Random();

        double[,] matrix;

        public Matrix()
        {
            int countRows = 0, countCols = 0;
            string msg = "";
            string errorMsg = "";

            msg = "Введите количество строк в матрице: ";
            errorMsg = "\nКоличество строк должно быть положительным числом!\n";
            countRows = CheckAndInput.InputPositiveNumber(msg, errorMsg);

            errorMsg = "\nКоличество столбцов должно быть положительным числом!\n";
            msg = "Введите количество столбцов в матрице: ";
            countCols = CheckAndInput.InputPositiveNumber(msg, errorMsg);

            matrix = new double[countRows, countCols];
            Console.WriteLine();
        }
        public void RandomFill()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = (double)(random.Next(-500, 500)) / 10;
            }
        }
        public void ManualFill()
        {
            string? msg;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    msg = $"Введите элемент для {i + 1}-й строки {j + 1}-го столбца: ";
                    matrix[i, j] = CheckAndInput.InputIntNumber(msg);
                }
            }
            Console.WriteLine();
        }
        public void ShowMatrix()
        {
            if (matrix.Length == 0)
            {
                Console.WriteLine("Матрица: <пустая>");
                return;
            }

            Console.WriteLine("----- Матрица -----");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j]} ");
                Console.WriteLine();
            }
        }
        public void DeleteRows()
        {
            if (matrix.Length == 0)
            {
                Console.WriteLine("\nНет строк для удаления!\n");
                return;
            }

            double maxElement = matrix.Cast<double>().Max();
            Console.WriteLine($"\nМаксимальный элемент: {maxElement}");

            List<int> indexRowsToDelete = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    //преобразование коллекции в одномерный массив
                    if (matrix[i, j] == maxElement)        
                    {
                        indexRowsToDelete.Add(i);
                        break;
                    }
                }
            }

            if (indexRowsToDelete.Count == 0)
            {
                Console.WriteLine("Не нашлось строк для удаления!\n");
                return;
            }
            else
            {
                Console.Write("Номер Строк(и) для удаления - ");
                for (int i = 0; i < indexRowsToDelete.Count; i++)
                {
                    if (i != indexRowsToDelete.Count - 1)
                        Console.Write($"{indexRowsToDelete[i] + 1},");
                    else
                        Console.Write($"{indexRowsToDelete[i] + 1}");
                }
            }

            Console.WriteLine("\n\n[Строки после удаления]");
            double[,] temp = new double[matrix.GetLength(0) - indexRowsToDelete.Count, matrix.GetLength(1)];
            for (int i = 0, z = 0; i < matrix.GetLength(0); i++)
            {
                if (!indexRowsToDelete.Contains(i))
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        temp[z, j] = matrix[i, j];
                    z++;
                }

            }
            matrix = temp;
        }
        public void ContinuePartOne()
        {
            string msg = "\n1. Продолжить задание\n2. Перейти к следующему\n-> ", errorMsg = "\nТакого пункта меню не существует!\n";
            bool notExit = true;

            do
            {
                int choice = CheckAndInput.InputIntNumber(msg);

                if (choice == 1)
                {
                    DeleteRows();
                    ShowMatrix();
                    ContinuePartOne();
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
