using System;
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
         FileStream filestream = File.Open(path, FileMode.Open, FileAccess.Read);
         StreamReader streamReader = new StreamReader(filestream);
         while (streamReader.Peek() >= 0)
         {
            stroka = streamReader.ReadLine();
            //Console.WriteLine(stroka);
         }

         streamReader.Close();
         //Console.WriteLine();
         Console.WriteLine("Исходный строковый массив {0}", nameArray);
         Console.WriteLine(stroka);

         // Определение количества столбцов в строке разделением строки на подстроки по пробелу
         // Символ пробела
         char symbolSpace = ' ';
         // Счетчик символов
         int symbolСount = 0;
         // Количество столбцов в строке
         int сolumn = 0;
         if (stroka != null)
         {
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
         }

         // Разделение строки на подстроки по пробелу и конвертация подстрок в double
         Console.WriteLine("Массив вещественных чисел {0}", nameArray);
         // Одномерный массив вещественных чисел
         double[] arrayDouble = new double[сolumn];
         // Построитель строк
         StringBuilder stringModified = new StringBuilder();
         // Счетчик символов обнуляем
         symbolСount = 0;
         // Количество столбцов в строке обнуляем
         сolumn = 0;
         if (stroka != null)
         {
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

         Console.WriteLine();
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
            //if (inputArray[i].CompareTo(numbercomparison) < 0)
            //{
            //   inputArray[i] = i;
            //}

            // Сравниваем значения double используя оператор равенства ==
            if (inputArray[i] < numbercomparison)
            {
               inputArray[i] = i;
            }

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

      // Обновлен метод +
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

      // Обновлен метод + 
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

      public static double[,] VvodArray(int n, int m)
      {
         string filePath = AppContext.BaseDirectory + "a.txt";
         // Двумерный массив вещественных чисел
         double[,] arrayDouble = { };
         // Чтение файла за одну операцию
         string[] allLines = File.ReadAllLines(filePath);
         if (allLines == null)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            Console.WriteLine("Исходный массив строк");
            int indexLines = 0;
            while (indexLines < allLines.Length)
            {
               allLines[indexLines] = allLines[indexLines];
               Console.WriteLine(allLines[indexLines]);
               indexLines++;
            }

            // Разделение строки на подстроки по пробелу для определения количества столбцов в строке
            int[] sizeArray = new int[allLines.Length];
            char symbolSpace = ' ';
            int countRow = 0;
            int countSymbol = 0;
            int countСolumn = 0;
            while (countRow < allLines.Length)
            {
               string line = allLines[countRow];
               while (countSymbol < line.Length)
               {
                  if (symbolSpace == line[countSymbol])
                  {
                     countСolumn++;
                  }

                  if (countSymbol == line.Length - 1)
                  {
                     countСolumn++;
                  }

                  countSymbol++;
               }

               sizeArray[countRow] = countСolumn;
               //Console.WriteLine("В строке {0} количество столбцов {1}", countRow, countСolumn);
               countСolumn = 0;
               countRow++;
               countSymbol = 0;
            }

            // Разделение строки на подстроки по пробелу и конвертация подстрок в double
            Console.WriteLine("Двухмерный числовой массив");
            StringBuilder stringModified = new StringBuilder();
            arrayDouble = new double[allLines.Length, sizeArray.Length];
            char spaceCharacter = ' ';
            int row = 0;
            int column = 0;
            int countCharacter = 0;
            while (row < arrayDouble.GetLength(0))
            {
               string line = allLines[row];
               while (column < sizeArray[row])
               {
                  while (countCharacter < line.Length)
                  {
                     if (spaceCharacter != line[countCharacter])
                     {
                        stringModified.Append(line[countCharacter]);
                     }
                     else
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToDouble(subLine);
                        Console.Write(arrayDouble[row, column] + " ");
                        stringModified.Clear();
                        column++;
                     }

                     if (countCharacter == line.Length - 1)
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToDouble(subLine);
                        Console.Write(arrayDouble[row, column]);
                        stringModified.Clear();
                        column++;
                     }

                     countCharacter++;
                  }

                  countCharacter = 0;
               }

               Console.WriteLine();
               column = 0;
               row++;
            }
            Console.ResetColor();
         }

         return arrayDouble;
      }

      public static double[,] InputArray(double[,] inputArray, int n, int m)
      {
         Console.WriteLine("Двумерный числовой массив для проведения поиска");
         double[,] outputArray = new double[n, m];
         for (int i = 0; i < n; i++)
         {
            for (int j = 0; j < m; j++)
            {
               outputArray[i, j] = inputArray[i, j];
               //Console.Write("{0:f2} ", outputArray[i, j]);
               //Console.Write("{0:f} ", outputArray[i, j]);
               Console.Write("{0} ", outputArray[i, j]);
            }
            Console.WriteLine();
         }

         return outputArray;
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

      // Обновлен метод + 
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

      // Обновлен метод + 
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