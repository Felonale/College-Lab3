using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Lab3
{
    public class Info
    {
        public static void About()
        {
            Console.WriteLine("About Lab\n" +
                "Copyright © 2022-2022 by\n" +
                "Felonale(Lapenko Danil)\n" +
                "Published by Felonale\n" +
                "https://github.com/Felonale/College-Lab2");
        }
    }
    public class Exercises //Класс для заданий
    {
        private static void FullMatrix(int[,] matrix)
        {
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-99, 99); //Заполняем массив случайными числами от -99 до 99
                }
            }
        }

        private static void ShowMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]}\t");
                }
                Console.WriteLine();
            }
        }

        public static void First()
        {
            int[,] matrix3x3 = new int[3, 3];
            FullMatrix(matrix3x3); //Метод, заполняющий матрицу
            ShowMatrix(matrix3x3); //Метод, отобажающий матрицу
            //Начало 1 условия - Найти сумму элементов главной диагонали
            int sumdiag = 0; //Переменная для хранения суммы диагонали
            for (int i = 0; i < matrix3x3.GetLength(0); i++)
            {
                sumdiag += matrix3x3[i,i];
            }
            Console.WriteLine($"Сумма главной диагонали - {sumdiag}");
            //Конец 1 условия
            //Начало 2 условия - Сравнить произведение верхней и нижней треугольных матриц
            int upperTriMatrixMulti = 1;
            int lowerTriMatrixMulti = 1;
            for (int i = 0; i < matrix3x3.GetLength(0); i++)
            {
                for (int j = i; j < matrix3x3.GetLength(1); j++)
                {
                    upperTriMatrixMulti *= matrix3x3[i, j]; //Читаем все ячейки от диагонали до конца строки
                }
            }
            for (int i = 1; i < matrix3x3.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    lowerTriMatrixMulti *= matrix3x3[i, j];//Читаем все ячейки от начала строки до диагонали
                }
            }
            Console.WriteLine($"Произведение верхней треугольной матрицы({upperTriMatrixMulti}) " +
                $"{(upperTriMatrixMulti > lowerTriMatrixMulti ? "больше" : "меньше")} произведения нижней треугольной матрицы {lowerTriMatrixMulti}");
            //Конец 2 условия
            //Начало 3 условия - Найти разность всех положительных элементов
            int diffOfPositive; //Переменная для хранения разности
            List<int> positiveNums = new List<int>();
            for (int i = 0; i < matrix3x3.GetLength(0); i++)
            {
                for (int j = 0; j < matrix3x3.GetLength(1); j++)
                {
                    if (matrix3x3[i, j] > 0)
                        positiveNums.Add(matrix3x3[i, j]);
                }
            }
            diffOfPositive = positiveNums[0]; //Задаем первое число, как начало разности
            positiveNums.Remove(positiveNums[0]); //Удаляем первое число, так как мы добавили его в переменную
            foreach(int num in positiveNums) //Перебираем каждый элемент списка и вычитаем каждое число из перменной
            {
                diffOfPositive -= num;
            }
            Console.WriteLine($"Разница всех положительных чисел: {diffOfPositive}");
            //Конец 3 условия
            //Начало 4 условия - Получить новую матрицу путём поочерёдного сложения элементов матрицы с последующими элементами
            int[,] newMatrix3x3 = new int[matrix3x3.GetLength(0), matrix3x3.GetLength(1)]; //Создаем новую матрицу с размером прошлого массива
            for (int i = 0; i < matrix3x3.GetLength(0); i++)
            {
                for (int j = 0; j < matrix3x3.GetLength(1); j++)
                {
                    if (j + 1 < matrix3x3.GetLength(1)) //Если мы пытаемся плюсовать ячейку, у которой ещё есть пространство справа, плюсуем ячейки
                        newMatrix3x3[i, j] = matrix3x3[i, j] + matrix3x3[i, j + 1];
                    else if (j + 1 > matrix3x3.GetLength(1) && i + 1 < matrix3x3.GetLength(0))//Если мы пытаемся плюсовать последнюю в строке ячейку и она
                                                                                              //не является последней, мы плюсуем последнюю ячейку в строке и начало
                                                                                              //следующей строки
                        newMatrix3x3[i, j] = matrix3x3[i, j] + matrix3x3[i + 1, 0];
                    else //Если вариантов больше не осталось, значит эта ячейка - последняя. Добавляем лишь последнее значение из первоначальной
                        newMatrix3x3[i, j] = matrix3x3[i, j];
                }
            }
            Console.WriteLine("Новая матрица после сложения элементов: ");
            ShowMatrix(newMatrix3x3);
            //Конец 4 условия
            //Начало 5 условия - Найти обратную матрицу через алгебраические дополнения и в конце осуществить проверку

            //Конец 5 условия

        }

        public static void Second()
        {
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяabcdefghijklmnopqrstuvwxyz";
            string alphabetVowels = "аеёиоуыэюяaeiouy";
            string alphabetConsonants = "бвгджйклмнпрстфхчцшщbcdfghjklmnpqrstvwxyz";
            /*string alphabetRU = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string alphabetRUVowels = "аеёиоуыэюя";
            string alphabetRUConsonants = "бвгджйклмнпрстфхчцшщ";
            string alphabetEN = "abcdefghijklmnopqrstuvwxyz";
            string alphabetENVowels = "aeiouy";
            string alphabetENConsonants = "bcdfghjklmnpqrstvwxyz";*/
            Console.Write("Введите текст: ");
            string strToCheck = Console.ReadLine();
            string[] wordsToCheck = strToCheck.Split(' '); //Переменная, хранящая слова в введённом предложении
            //Переменные для подсчёта
            int countVowels = 0, countConsonants = 0; //Гласные и согласные
            int countSpaces = 0, countDots = 0, countCommas = 0, countExclam = 0, countQuestion = 0, countColons = 0; //Знаки препинания
            int pairConsonants = 0; //Пары согласных
            int countUpper = 0, countLower = 0; //Верхний и нижний регистр
            string maxWord = "", minWord = "";
            for (int i = 0; i < strToCheck.Length; i++) //Перебираем все символы в предложении
            {
                if (Char.IsUpper(strToCheck[i]))
                    countUpper++;
                else if (Char.IsLower(strToCheck[i]))
                    countLower++;
                if (alphabet.Contains(Char.ToLower(strToCheck[i]))) //Проверяем, относится ли символ к любому алфавиту
                {
                    if (alphabetVowels.Contains(Char.ToLower(strToCheck[i]))) //Относится ли проверяемая буква к гласным
                        countVowels++;
                    else if (alphabetConsonants.Contains(Char.ToLower(strToCheck[i]))) //Относится ли проверяемая буква к согласным
                    {
                        countConsonants++;
                        if (i + 1 < strToCheck.Length && Char.ToLower(strToCheck[i]) == Char.ToLower(strToCheck[i++])) //Считаем пары согласых символов для подсчёта пар
                            pairConsonants++;
                    }
                }
                else
                {
                    switch (strToCheck[i])
                    {
                        case ' ': countSpaces++; break;
                        case '.': countDots++; break;
                        case ',': countCommas++; break;
                        case '!': countExclam++; break;
                        case '?': countQuestion++; break;
                        case ':': countColons++; break;
                        default: break;
                    }
                }
            }
            foreach(string str in wordsToCheck)
            {
                if (str.Length > maxWord.Length)
                    maxWord = str;
                if (str.Length < minWord.Length)
                    minWord = str;
            }
            Console.WriteLine($"В предложении\n" +
                $"Гласных: {countVowels}\t Согласных: {countConsonants}\n" +
                $"Пробелов: {countSpaces} Точек: {countDots} Запятых: {countCommas} Восклицательных: {countExclam} Вопросительных: {countQuestion} Двоеточий: {countColons}\n" +
                $"");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите номер заданий 1-2('exit' для выхода. 'about' для информации): ");
                switch (Console.ReadLine())
                {
                    case "1": Console.Clear(); Exercises.First(); break;
                    case "2": Console.Clear(); Exercises.Second(); break;
                    case "exit": Environment.Exit(0); break;
                    case "about": Console.Clear(); Info.About(); break;
                    default: Console.WriteLine("Введен неверный параметр."); break;
                }
            }
        }
    }
}
