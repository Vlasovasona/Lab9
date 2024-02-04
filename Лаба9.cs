using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp2
{
    //ДОБАВИТЬ try catch ДЛЯ ВЫВОДА ИСКЛЮЧЕНИЙ В СВОЙСТВАХ!!

    internal class Лаба9
    {
        public static sbyte InputSbyteNumber(string msg = "Введите число")
        {
            Console.WriteLine(msg);
            bool isConvert;
            sbyte number;
            do
            {
                isConvert = sbyte.TryParse(Console.ReadLine(), out number);
                if (!isConvert || number < 1)
                {
                    Console.WriteLine("Неправильно введено число. Возможно вы ввели слишком длинное число. Попробуйте заново");
                    isConvert = false;
                }
            } while (!isConvert);
            return number;
        }

        public static ChessboardCell Func(ChessboardCellArray arr)
        {
            int minimum = 10000;
            ChessboardCell cell = new ChessboardCell();
            for (int i = 0; i < arr.Length; i++)
            {
                int differ = (int)arr[i];                               //использовали перегруженную операцию для сложения координат клетки
                if (differ < minimum)
                {
                    minimum = differ;
                    cell = arr[i];
                }
            }
            return cell;
        }



        //cell1 хранит в стеке ссылку на кучу с двумя переменными (horizontal и vertical)
        static void Main(string[] strings)
        {
                                                                        //задание 1
            Console.WriteLine("__________Задание 1__________");

            Console.WriteLine("___Конструктор без параметров___");
            ChessboardCell cell1 = new ChessboardCell();                //создали объект класса 
            cell1.Show();

            Console.WriteLine("___Конструктор с параметрами___");
            ChessboardCell cell2 = new ChessboardCell(4,4);             //конструктор, он не возвращает значение
            cell2.Show();

            Console.WriteLine("___Конструктор копирования___");
            ChessboardCell cell3 = new ChessboardCell(cell2);           //обратились к конструктору копирования, передали значения из конструктора с параметрами,в памяти переменные будут храниться отдельно
            cell3.Show();


            Console.WriteLine("Результат работы статического метода для 1 и 2 точек (имеют ли они одинаковый цвет на шахматной доске):");
            Console.WriteLine(ChessboardCell.Same(cell1, cell2));       //демонстрируем работу статического метода для объектов cell1 и cell2

            Console.WriteLine("Результат работы метода класса для 1 и 2 точек (имеют ли они одинаковый цвет на шахматной доске):");
            bool result = cell1.BlackOrWhite(cell1, cell2);
            Console.WriteLine(result);
            Console.WriteLine();

                                                                        //задание 1 закончилось

                                                                        //задание 2
            Console.WriteLine("__________Задание 2__________");

            Console.WriteLine("Использование унарной операции /++/ (увеличиваем обе координаты клетки на 1)");

                                                                        //Унарные операции
            Console.WriteLine("Изначальные координаты точки:");
            cell1.Show();
            Console.WriteLine("Результат:");
            cell1++;
            cell1.Show();

            Console.WriteLine("Демонстрация работы для точки (8, 8):");
            ChessboardCell cellMistake = new ChessboardCell(8,8);       //Показываю работу метода для точки с координатой (8,8)
            cellMistake++;
            cellMistake.Show();

            Console.WriteLine("Использование унарной операции /!/ (меняем координаты клетки относительно главной диагонали)");
            Console.WriteLine("Точка до изменений:");
            cell1.Show();
            ChessboardCell cell4 = !cell1;
            Console.WriteLine("Точка с измененными координатами:");
            cell4.Show();
            Console.WriteLine();

                                                                        //Бинарные операции
            Console.WriteLine("Использование операции приведения типа /==/");
            ChessboardCell cell5 = new ChessboardCell(3,2);
            Console.WriteLine("Первая точка:");
            cell5.Show();
            Console.WriteLine("Вторая точка:");
            cell2.Show();
            Console.WriteLine("Результат вычислений (может ли конь переместиться между этими точками за один ход): ");
            Console.WriteLine(cell5==cell2);
            Console.WriteLine();

            Console.WriteLine("Использование операции приведения типа /!=/ (проверка находятся ли клетки на разных вертикалях)");
            cell5.Show();
            cell2.Show();
            Console.WriteLine(cell5!=cell2);

                                                                        //Операции приведения типа
                                                                        //Явная 
            Console.WriteLine("Координаты точки:");
            cell5.Show();
            int t = (int)cell5;
            Console.WriteLine("Сумма координат точек: " + t);
                                                                        //Не явная
            string cellToString = cell5;
            Console.WriteLine("Цвет клетки - " + cellToString);
            //задание 2 закончилось

            //задание 3 начало 
            sbyte answer;
            do
            {
                Console.WriteLine("1. Ручной ввод");
                Console.WriteLine("2. Генератор случайных чисел");
                Console.WriteLine("3. Выход");
                answer = InputSbyteNumber("Выберите способ, которым вы хотите заполнить массив");
                switch (answer)
                {
                    case 1:
                        sbyte length = InputSbyteNumber("Введите длину массива");
                        ChessboardCellArray arrayHand = new ChessboardCellArray(length);
                        arrayHand.Show();
                        break;
                    case 2:
                        sbyte lengthRand = InputSbyteNumber("Введите длину случайного массива");
                        ChessboardCellArray arrayRand = new ChessboardCellArray(lengthRand, 1);
                        arrayRand.Show();
                        break;
                    case 3:
                        Console.WriteLine("Вы завершили работу с конструктором массивов");
                        break;
                    default:
                        Console.WriteLine("Неправиьно задан пункт меню");
                        break;
                }
            } while (answer != 3);
            

            Console.WriteLine();
            ChessboardCellArray array1 = new ChessboardCellArray(5, 1); 
            Console.WriteLine("___Первый массив___");
            array1.Show();
            Console.WriteLine();

            ChessboardCellArray array2 = new ChessboardCellArray(array1); //создали коллекцию на основе существующей с помощью метода копирования
            Console.WriteLine("___Второй массив___");
            array2.Show();
            Console.WriteLine();

            ChessboardCellArray arrayEmpty = new ChessboardCellArray();
            Console.WriteLine("___Вывод массива из конструктора по умолчанию___");
            arrayEmpty.Show();
            Console.WriteLine();

            array1[0] = new ChessboardCell(8, 2);
            array1[0].Show();                               //демонстрация работы get
            Console.WriteLine("___Первый массив___");
            array1.Show();
            Console.WriteLine();
            Console.WriteLine("___Второй массив___");
            array2.Show();
            Console.WriteLine();

            try
            {
                array1[110] = new ChessboardCell(8, 8);                 
                Console.WriteLine(array1[100]);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();                                        //демострация работы функции 
            Console.WriteLine("Самая близкая клетка к клтке (1,1) для последнего массива:");
            ChessboardCell resultArr = Func(array2);
            resultArr.Show();


            Console.WriteLine("___Кол-во созданных объектов и коллекций___");
            Console.WriteLine($"Всего создано {ChessboardCell.count} объектов класса");
            Console.WriteLine($"Всего создано {ChessboardCellArray.countArr} коллекций");
            
                                                                        //конец третьего задания
        }
    }
}
