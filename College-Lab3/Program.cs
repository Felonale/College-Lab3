using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace College_Lab3
{
    public class Info
    {
        public static void About()
        {
            Console.WriteLine("About Lab\n" +
                "Copyright ©2022-2023 by\n" +
                "Felonale(Lapenko Danil)\n" +
                "Published by Felonale\n" +
                "https://github.com/Felonale/College-Lab3\n" +
                "\nКод благословлён Аллахом Ар-Рахимом");
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
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        public static void First()
        {
            int[,] matrix3x3 = new int[3, 3];
            int matrixSize = matrix3x3.GetLength(0);
            FullMatrix(matrix3x3); //Метод, заполняющий матрицу
            ShowMatrix(matrix3x3); //Метод, отобажающий матрицу
            //Начало 1 условия - Найти сумму элементов главной диагонали
            int sumdiag = 0; //Переменная для хранения суммы диагонали
            for (int i = 0; i < matrixSize; i++)
            {
                sumdiag += matrix3x3[i,i];
            }
            Console.WriteLine($"Сумма главной диагонали - {sumdiag}");
            //Конец 1 условия
            //Начало 2 условия - Сравнить произведение верхней и нижней треугольных матриц
            int upperTriMatrixMulti = 1;
            int lowerTriMatrixMulti = 1;
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = i; j < matrix3x3.GetLength(1); j++)
                {
                    upperTriMatrixMulti *= matrix3x3[i, j]; //Читаем все ячейки от диагонали до конца строки
                }
            }
            for (int i = 1; i < matrixSize; i++)
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
            for (int i = 0; i < matrixSize; i++)
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
            int[,] newMatrix3x3 = new int[matrixSize, matrix3x3.GetLength(1)]; //Создаем новую матрицу с размером прошлого массива
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrix3x3.GetLength(1); j++)
                {
                    if (j + 1 < matrix3x3.GetLength(1)) //Если мы пытаемся плюсовать ячейку, у которой ещё есть пространство справа, плюсуем ячейки
                        newMatrix3x3[i, j] = matrix3x3[i, j] + matrix3x3[i, j + 1];
                    else if (j + 1 >= matrix3x3.GetLength(1) && i + 1 < matrixSize)//Если мы пытаемся плюсовать последнюю в строке ячейку и она
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
            Console.Write("Сейчас будет особенное веселье с обратной матрицей. Подтвердите готовность, нажав любую кнопку.");
            Console.ReadKey();
            Console.WriteLine();
            //Начало 5 условия - Найти обратную матрицу через алгебраические дополнения и в конце осуществить проверку
            double detA = 0; //Формула вычисления: a11·a22·a33 + a12·a23·a31 + a13·a21·a32 - a13·a22·a31 - a11·a23·a32 - a12·a21·a33
            int tempMultiDetA = 1;
            Console.Write("detA: ");                                                                     //Всё ниже я выполнил с божьей помощью и 3 часами работы
            for (int i = 0; i < matrixSize; i++) //Считаем каждый сегмент умножений (a11·a22·a33) и плюсуем друг с другом
            {
                Console.Write("(");
                for (int k = 0, j = i; k < matrixSize && j < i + matrixSize; j++, k++) //Код ниже позволяет (поверить в бога) перемножает три диагонали, начиная с основной и делая два шага вправо
                {
                    tempMultiDetA *= matrix3x3[k, j % matrixSize];
                    Console.Write(matrix3x3[k, j % matrixSize]);
                    if (k != 2)
                        Console.Write("*");
                }
                detA += tempMultiDetA; tempMultiDetA = 1;
                Console.Write(")");
                if(i != 2)
                    Console.Write(" + ");
            }
            for (int i = 0; i < matrixSize; i++)
            {
                Console.Write(" - (");
                for (int k = 0, j = matrixSize - 1 - i; k < matrixSize; j--, k++) //Код ниже позволяет (поверить в бога) перемножает три диагонали, начиная с основной и делая два шага влево
                {
                    if (j == -1) //Когда
                        j = 2;
                    tempMultiDetA *= matrix3x3[k, j % matrixSize];
                    Console.Write(matrix3x3[k, j % matrixSize]);
                    if (k != 2)
                        Console.Write("*");
                }
                detA -= tempMultiDetA; tempMultiDetA = 1;
                Console.Write(")");
            }
            Console.WriteLine(" = " + detA);
            //Конец вычисления detA
            Console.WriteLine("Найдем миноры M и алгебраические дополнения A. В матрице А вычеркиваем по 1 строке и по 1 столбцу по очереди.");
            int[,] matrixC = new int[matrixSize, matrixSize]; //Создаём союзную матрицу
            int[,] Minor = new int[matrixSize - 1, matrixSize - 1]; //Создаём минорную матрицу, которая будет хранить в себе промежуточные данные
            for (int mRow = 0; mRow < matrixSize; mRow++) //Чередуем вычеркнутую строку
            {
                for (int mCollumn = 0; mCollumn < matrixSize; mCollumn++) //Чередуем вычеркнутую строку
                {
                    Console.WriteLine($"Найдем минор M{mRow+1}{mCollumn+1} и алгебраическое дополнение A{mRow + 1}{mCollumn + 1}. В изначальной матрице вычеркиваем строку {mRow+1} и столбец {mCollumn+1}");
                    Minor[0, 0] = matrix3x3[(mRow + 1) % matrixSize, (mCollumn + 1) % matrixSize];
                    Minor[0, 1] = matrix3x3[(mRow + 1) % matrixSize, (mCollumn + 2) % matrixSize];
                    Minor[1, 0] = matrix3x3[(mRow + 2) % matrixSize, (mCollumn + 1) % matrixSize];
                    Minor[1, 1] = matrix3x3[(mRow + 2) % matrixSize, (mCollumn + 2) % matrixSize];
                    ShowMatrix(Minor);
                    matrixC[mRow, mCollumn] = Minor[0, 0] + Minor[1, 1] + Minor[0, 1] + Minor[1, 0]; //Пользуемся формулой a11·a22 - a12·a21
                    Console.WriteLine($"A{mRow+1}{mCollumn+1} = {Minor[0, 0]} + {Minor[1, 1]} + {Minor[0, 1]} + {Minor[1, 0]} = {matrixC[mRow, mCollumn]}");
                }
            }
            Console.WriteLine("Получилась союзная матрица C:");
            ShowMatrix(matrixC);
            int[,] tempMatrixC = new int[matrixSize, matrixSize]; //Создаём временные матрицы для транспонирования
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    tempMatrixC[j, i] = matrixC[i, j]; //Транспонируем матрицу, перенося результат во временную матрицу
                }
            }

            matrixC = new int[matrixSize, matrixSize]; //Изменяем первоначальные матрицы на измерения транспонированных
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrixC[i, j] = tempMatrixC[i, j]; //Добавляем данные из ячеек временных массивов в первоначальные матрицы
                }
            }
            Console.WriteLine("Теперь нам необходимо транспонировать матрицу C в матрицу C*:");
            ShowMatrix(matrixC);
            Console.WriteLine("Обратная матрица вычисляется по формуле A\x207B\xB9 = С*/detA:");
            double[,] matrixInversed = new double[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrixInversed[i, j] = matrixC[i, j] / detA;
                    Console.Write($"{matrixInversed[i,j]}\t");
                }
                Console.WriteLine();
            }
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
            int countPairConsonants = 0; //Пары согласных
            int countUpper = 0, countLower = 0; //Верхний и нижний регистр
            string countLongestWord = "", countShortestWord = wordsToCheck[0];
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
                        if (i + 1 < strToCheck.Length && Char.ToLower(strToCheck[i]) == Char.ToLower(strToCheck[i + 1])) //Считаем пары согласых символов для подсчёта пар
                            countPairConsonants++;
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
                if (str.Length > countLongestWord.Length)
                    countLongestWord = str;
                if (str.Length < countShortestWord.Length)
                    countShortestWord = str;
            }
            Console.WriteLine($"В предложении\n" +
                $"Гласных: {countVowels}\t Согласных: {countConsonants}\n" +
                $"Пробелов: {countSpaces} Точек: {countDots} Запятых: {countCommas} Восклицательных: {countExclam} Вопросительных: {countQuestion} Двоеточий: {countColons}\n" +
                $"Парных согласных: {countPairConsonants}\n" +
                $"Букв в верхнем регисторе: {countUpper}\tВ нижнем: {countLower}\n" +
                $"Самое длинное слово: {countLongestWord}\t Самое короткое слово: {countShortestWord}\n");
            Console.Write("Заменить все гласные на символ: ");
            string strVowelsToChar = "" + strToCheck;
            string charForReplace = Console.ReadLine().Trim();
            while (charForReplace.Length != 1)
            {
                Console.Write("Строка не является символом. Введите символ(Пример: a): ");
                charForReplace = Console.ReadLine();
            }
            foreach(char c in alphabetVowels) //Проверяем каждый символ в алфавите и заменяем все совпадения в тексте
            {
                strVowelsToChar = strVowelsToChar.Replace(c, char.Parse(charForReplace));
            }
            Console.WriteLine(strVowelsToChar);

            string strToCopy = null;
            int[] strToCopyData = new int[2]; //Создаём массив для хранения информации о строке (0 - начало копирования, 1 - количество символов)
            while (strToCopy == null)
            {
                Console.WriteLine(strToCheck);
                Console.Write($"Введите, с какого символа начать копирование 1-{strToCheck.Length}: ");
                while (!int.TryParse(Console.ReadLine().Trim(), out strToCopyData[0])) //Проверяем, является ли вводимое - числом
                {
                    Console.Write("Введено не число, повторите ввод: ");
                }
                if (strToCopyData[0] < 0 || strToCopyData[0] > strToCheck.Length) //Проверяем, является ли введённое число действительным
                {
                    Console.WriteLine("Указан неверный символ для начала копирования.");
                    continue;
                }

                Console.Write("Введите, сколько символов копировать: ");
                while (!int.TryParse(Console.ReadLine().Trim(), out strToCopyData[1])) //Проверяем, является ли вводимое - числом
                {
                    Console.Write("Введено не число, повторите ввод: ");
                }
                if (strToCopyData[1] < 0 || strToCheck.Length - strToCopyData[0] < strToCopyData[1]) //Проверяем, является ли введённое число действительным
                {
                    Console.WriteLine("Указано неверное количество символов для начала копирования.");
                    continue;
                }
                strToCopyData[0]--; //Так как любой массив начинается с нулевой ячейки, если пользователь укажет копирование с первого символа, программа должна начать с нулевого
                strToCopy = strToCheck.Substring(strToCopyData[0], strToCopyData[1]);
            }
            Console.WriteLine($"Скопированная часть строки: {strToCopy}");

            char[] charToMirror = strToCheck.ToCharArray(); //Создаём массив символов и помещаем туда исходный текст
            Array.Reverse(charToMirror); //Зеркалим полученный массив строк
            string strMirrored = new string(charToMirror);
            Console.WriteLine($"Перевёрнутый текст: {strMirrored}");

            string strFirstSymbLong = ""; //Получить новый текст, состоящий из первого символа исходной строки, длиною равной количеству символов самого длинного слова в исходной строке.
            for (int i = 0; i < countLongestWord.Length; i++)
            {
                strFirstSymbLong += strToCheck[0];
            }
            Console.WriteLine($"Текст, состоящий из первой буквы исходного текста длиной с самое длинное слово: {strFirstSymbLong}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
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
