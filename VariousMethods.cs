﻿using System;
using System.IO;
using System.Text;

namespace LibraryFor1DArray
{
   public class VariousMethods
   {
      public static int NumberArrayElements(string nameArray)
      {
         int n;
         do
         {
            Console.WriteLine("Введите количество элементов массива {0}", nameArray);
            int.TryParse(Console.ReadLine(), out n);
            //n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0 || n > 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (n <= 0 || n > 20);

         return n;
      }

      public static double[] VvodArray(string path, string nameArray)
      {
         string stroka = null;
         double[] arrayDouble = { };
         FileStream filestream = File.Open(path, FileMode.Open, FileAccess.Read);
         if (filestream == null || filestream.Length == 0)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            StreamReader streamReader = new StreamReader(filestream);
            while (streamReader.Peek() >= 0)
            {
               stroka = streamReader.ReadLine();
               //Console.WriteLine(stroka);
            }

            // Определение количества столбцов в строке разделением строки на подстроки по пробелу
            // Символ пробела
            char symbolSpace = ' ';
            // Счетчик символов
            int symbolСount = 0;
            // Количество столбцов в строке
            int сolumn = 0;
            if (stroka != null)
            {
               Console.WriteLine("Исходный строковый массив {0}", nameArray);
               Console.WriteLine(stroka);
               while (symbolСount < stroka.Length)
               {
                  if (symbolSpace == stroka[symbolСount])
                  {
                     сolumn++;
                  }

                  if (symbolСount == stroka.Length - 1)
                  {
                     сolumn++;
                  }

                  symbolСount++;
               }

               //Console.WriteLine("Количество столбцов {0}", сolumn);

               // Разделение строки на подстроки по пробелу и конвертация подстрок в double
               Console.WriteLine("Массив вещественных чисел {0}", nameArray);
               // Одномерный массив вещественных чисел
               arrayDouble = new double[сolumn];
               // Построитель строк
               StringBuilder stringModified = new StringBuilder();
               // Счетчик символов обнуляем
               symbolСount = 0;
               // Количество столбцов в строке обнуляем
               сolumn = 0;
               while (symbolСount < stroka.Length)
               {
                  if (symbolSpace != stroka[symbolСount])
                  {
                     stringModified.Append(stroka[symbolСount]);
                  }
                  else
                  {
                     string subLine = stringModified.ToString();
                     arrayDouble[сolumn] = Convert.ToDouble(subLine);
                     Console.Write(arrayDouble[сolumn] + " ");
                     stringModified.Clear();
                     сolumn++;
                  }

                  if (symbolСount == stroka.Length - 1)
                  {
                     string subLine = stringModified.ToString();
                     arrayDouble[сolumn] = Convert.ToDouble(subLine);
                     Console.Write(arrayDouble[сolumn]);
                     stringModified.Clear();
                     сolumn++;
                  }

                  symbolСount++;
               }
            }

            streamReader.Close();
            Console.WriteLine();
         }

         return arrayDouble;
      }

      public static double[] InputArray(double[] inputArray, int n, string nameArray)
      {
         Console.WriteLine("Массив вещественных чисел {0} для проведения поиска", nameArray);
         double[] outputArray = new double[n];


         int i = 0;
         while (i < n)
         {
            outputArray[i] = inputArray[i];
            //Console.Write("{0:f2} ", outputArray[i]);
            //Console.Write("{0:f} ", outputArray[i]);
            Console.Write("{0} ", outputArray[i]);
            i++;
         }

         Console.WriteLine();
         return outputArray;
      }

      public static double FindMaxArray(double[] inputArray, string nameArray)
      {
         // Поиск максимального элемента строки (без флагов bool)
         // Cчитаем, что максимум - это первый элемент строки
         double max = inputArray[0];
         int column = 0;
         while (column < inputArray.Length)
         {
            if (max < inputArray[column])
            {
               max = inputArray[column];
            }

            column++;
         }

         Console.WriteLine("Максимум в массиве {0} равен: {1}", nameArray, max);
         //Console.WriteLine("Максимум в массиве {0} равен: {1:f2}", nameArray, max);
         return max;
      }

      public static double[] FindMax(double[,] inputArray)
      {
         // Поиск максимального элемента строки (без флагов bool)
         double[] arrayMax = new double[inputArray.GetLength(0)];
         int rowOut = 0;
         int columnOut = 0;
         while (rowOut < inputArray.GetLength(0))
         {
            // Cчитаем, что максимум - это первый элемент строки
            double maxOut = inputArray[rowOut, 0];
            while (columnOut < inputArray.GetLength(1))
            {
               if (maxOut < inputArray[rowOut, columnOut])
               {
                  maxOut = inputArray[rowOut, columnOut];
               }

               columnOut++;
            }

            arrayMax[rowOut] = maxOut;
            //Console.WriteLine("Максимум в строке {0} равен: {1}", rowOut, maxOut);
            columnOut = 0;
            rowOut++;
         }

         Console.WriteLine("Массив максимальных значений строк");
         int indexMax = 0;
         while (indexMax < arrayMax.Length)
         {
            Console.Write("{0} ", arrayMax[indexMax]);
            indexMax++;
         }

         Console.WriteLine();
         return arrayMax;
      }

      public static double[] ReplacingMax(double[] inputArray, double max)
      {
         double[] outputArray = new double[inputArray.Length];
         int i = 0;
         while (i < inputArray.Length)
         {
            // Сравниваем значения double используя метод CompareTo(Double) 
            if (inputArray[i].CompareTo(max) == 0)
            {
               outputArray[i] = inputArray[i];
            }
            else
            {
               outputArray[i] = i;
            }

            // Сравниваем значения double используя метод Equals(Double)
            //if (inputArray[i].Equals(max))
            //{
            //   outputArray[i] = inputArray[i];
            //}
            //else
            //{
            //   outputArray[i] = i;
            //}

            i++;
         }

         return outputArray;
      }

      public static bool FindZero(double[] inputArray, string nameArray)
      {
         double numbercomparison = 0;
         bool flag = false;
         int i = 0;
         while (i < inputArray.Length && flag == false)
         {
            // Сравниваем значения double используя метод CompareTo(Double) 
            if (inputArray[i].CompareTo(numbercomparison) == 0)
            {
               flag = true;
            }

            // Сравниваем значения double используя метод Equals(Double)
            //if (inputArray[i].Equals(numbercomparison))
            //{
            //   flag = true;
            //}

            // Сравниваем значения double используя оператор равенства ==
            //if (inputArray[i] == 0)
            //{
            //   flag = true;
            //}

            i++;
         }

         if (flag)
         {
            Console.WriteLine("В массиве {0} имеется элемент равный нулю", nameArray);
         }
         else
         {
            Console.WriteLine("В массиве {0} отсутствует элемент равный нулю", nameArray);
         }

         return flag;
      }

      public static double[] ReplacingZero(double[] inputArray)
      {
         double numbercomparison = 0;
         int i = 0;
         while (i < inputArray.Length)
         {
            // Сравниваем значения double используя метод CompareTo(Double) 
            if (inputArray[i].CompareTo(numbercomparison) < 0)
            {
               inputArray[i] = i;
            }

            // Сравниваем значения double используя оператор равенства ==
            //if (inputArray[i] < numbercomparison)
            //{
            //   inputArray[i] = i;
            //}

            i++;
         }

         return inputArray;
      }

      public static void FileAppendString(string[] stringArray, string filePath)
      {
         // Запись массива строк в файл
         Console.WriteLine("Запись массива строк в файл");
         File.AppendAllLines(filePath, stringArray);
      }

      public static int SearchingNull(double[] inputArray, string nameArray)
      {
         double numbercomparison = 0;
         int count = 0;
         int i = 0;
         while (i < inputArray.Length)
         {
            // Сравниваем значения double используя метод CompareTo(Double) 
            if (inputArray[i].CompareTo(numbercomparison) == 0)
            {
               count++;
            }

            // Сравниваем значения double используя метод Equals(Double)
            //if (inputArray[i].Equals(numbercomparison))
            //{
            //   count++;
            //}

            // Сравниваем значения double используя оператор равенства ==
            //if (inputArray[i] == 0)
            //{
            //   count++;
            //}

            i++;
         }

         if (count != 0)
         {
            Console.WriteLine("В массиве {0} элементов равных нулю: {1}", nameArray, count);
         }
         else
         {
            Console.WriteLine("В массиве {0} нет элементов равных нулю", nameArray);
         }

         return count;
      }

      public static void ComparisonNull(int a, int b, int c)
      {
         string[] name = { "A", "B", "C" };
         int[] arr = { a, b, c };
         // Поиск минимального элемента строки (без флагов bool)
         int min = arr[0];
         int counter = 0;
         while (counter < arr.Length)
         {
            // Cчитаем, что минимум - это первый элемент строки
            if (arr[counter] < min)
            {
               min = arr[counter];
            }

            counter++;
         }
         Console.WriteLine("Минимум  равен: {0}", min);

         // Проверка массивов на минимум элементов
         counter = 0;
         while (counter < arr.Length)
         {
            // Cчитаем, что минимум - это первый элемент строки
            if (arr[counter] == min)
            {
               Console.WriteLine("В массиве {0} минимальное количество элементов равных нулю: {1}", name[counter], min);
            }

            counter++;
         }
      }

      public static void ComparisonNegative(int a, int b, int c)
      {
         string[] name = { "A", "B", "C" };
         int[] arr = { a, b, c };
         // Поиск минимального элемента строки (без флагов bool)
         int min = arr[0];
         int counter = 0;
         while (counter < arr.Length)
         {
            // Cчитаем, что минимум - это первый элемент строки
            if (arr[counter] < min)
            {
               min = arr[counter];
            }

            counter++;
         }
         Console.WriteLine("Наименьшее количество отрицательных элементов в массивах {0}, {1}, {2} равно: {3}", name[0], name[1], name[2], min);

         // Проверка массивов на минимум элементов
         counter = 0;
         while (counter < arr.Length)
         {
            // Cчитаем, что минимум - это первый элемент строки
            if (arr[counter] == min)
            {
               Console.WriteLine("В массиве {0} наименьшее количество отрицательных элементов", name[counter]);
            }

            counter++;
         }
      }

      public static void ComparisonValue(int a, int b, int c)
      {
         if (a == b && a == c)
         {
            Console.WriteLine("Отрицательных элементов в массивах A, В, С равное количество");
         }
         if (a < b && a < c)
         {
            Console.WriteLine("Отрицательных элементов меньше в массиве A");
         }
         if (b < a && b < c)
         {
            Console.WriteLine("Отрицательных элементов меньше в массиве B");
         }
         if (c < a && c < b)
         {
            Console.WriteLine("Отрицательных элементов меньше в массиве C");
         }
      }

      public static int SearchingNegative(double[] inputArray, string nameArray)
      {
         int count = 0;
         int i = 0;
         while (i < inputArray.Length)
         {
            if (inputArray[i] < 0)
            {
               count++;
            }

            i++;
         }

         Console.WriteLine("В массиве {0} отрицательных элементов: {1}", nameArray, count);
         if (count == 0)
         {
            Console.WriteLine("В массиве {0} нет отрицательных элементов", nameArray);
         }

         return count;
      }

      public static int SearchingNegativeNumbers(double[] inputArray, string nameArray)
      {
         int count = 0;
         int i = 0;
         while (i < inputArray.Length)
         {
            if (inputArray[i] < 0)
            {
               count++;
            }

            i++;
         }

         Console.WriteLine("В массиве {0} отрицательных элементов: {1}", nameArray, count);
         if (count == 0)
         {
            Console.WriteLine("В массиве {0} нет отрицательных элементов", nameArray);
         }

         return count;
      }

      public static string[] VivodStringArray(double[] inputArray)
      {
         // Объединение одномерного массива максимальных значений строк double[]
         // в одномерный массив строк string[] для записи в файл (в одну строку массива)
         Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         int row = 0;
         while (row < inputArray.Length)
         {
            if (row != inputArray.Length - 1)
            {
               stringModified.Append(inputArray[row] + " ");
            }
            else
            {
               stringModified.Append(inputArray[row]);
            }

            row++;
         }

         Console.WriteLine(stringModified);
         string[] stringArray = { stringModified.ToString() };
         return stringArray;
      }

      public static void FileWriteString(string[] stringArray)
      {
         // Запись массива строк в файл
         Console.WriteLine("Запись массива строк в файл");
         string filePath = AppContext.BaseDirectory + "b.txt";
         File.WriteAllLines(filePath, stringArray);
      }

      public static string[] VivodArrayString(double[] inputArray)
      {
         // Объединение одномерного массива максимальных значений строк double[]
         // в одномерный массив строк string[] для записи в файл
         Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         string[] arrayString = new string[inputArray.Length];
         int row = 0;
         while (row < inputArray.Length)
         {
            stringModified.Append(inputArray[row]);
            string subLine = stringModified.ToString();
            arrayString[row] = subLine;
            Console.WriteLine(subLine);
            stringModified.Clear();
            row++;
         }

         return arrayString;
      }

      public static void FileWriteArray(string[] arrayString)
      {
         // Запись массива строк в файл
         Console.WriteLine("Запись массива строк в файл");
         string filePath = AppContext.BaseDirectory + "c.txt";
         File.WriteAllLines(filePath, arrayString);
      }
   }
}