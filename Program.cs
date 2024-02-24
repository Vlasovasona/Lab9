using Library_10;


namespace Лаба_10
{
    internal class Program
    {
        static sbyte InputSbyteNumber(string msg = "Введиче число")
        {
            Console.WriteLine(msg);
            bool isConvert;
            sbyte number;
            do
            {
                isConvert = sbyte.TryParse(Console.ReadLine(), out number);
                if (!isConvert) Console.WriteLine("Неправильно введено число. Возможно вы ввели слишком длинное число. Попробуйте заново");
            } while (!isConvert);
            return number;
        }

        static double MeasuringMiddleValue(Instrument[] array, double value)        //метод, вычисляющий среднюю точность изм. инструментов (as)
        {
            double middleValue = 0;
            int count = 0;
            foreach (Instrument inst in array)
            {
                MeasuringTool measTool = inst as MeasuringTool;
                if (measTool!=null)
                {
                    if(measTool.accuracy < value)
                    {
                        middleValue += measTool.accuracy;
                        count++;
                    }
                }
            }
            return middleValue/count;
        }

        static int MaxWorkingTime(Instrument[] array)                               //метод, который позволяет найти макс время работы электр. инструмента(is)
        {
            int maxTime = 0;
            foreach (Instrument inst in array)
            {
                if (inst is ElectricTool tool && tool.workingTime > maxTime)
                {
                    maxTime = tool.workingTime;
                }
            }
            return maxTime;
        }

        static void NameOfHandTools(Instrument[] array)                             //вывести названия всех ручных инструментов (typeof)
        {
            Type t = typeof(HandTool);
            foreach (Instrument inst in array)
            {
                if (t == inst.GetType())
                    inst.Show();
            }
        }

        static Instrument[] CreateMasFirst()
        {
            Instrument[] array = new Instrument[20];                                //создаем и заполняем массив
            for (int i = 0; i < 5; i++)                                             //абстрактные методы по умолчанию являются виртуальными, нужен override
            {
                Instrument inst = new Instrument();
                inst.RandomInit();
                array[i] = inst;
            }
            for (int i = 5; i < 10; i++)
            {
                HandTool hand = new HandTool();
                hand.RandomInit();
                array[i] = hand;
            }
            for (int i = 10; i < 15; i++)
            {
                ElectricTool elect = new ElectricTool();
                elect.RandomInit();
                array[i] = elect;
            }
            for (int i = 15; i < array.Length; i++)
            {
                MeasuringTool meas = new MeasuringTool();
                meas.RandomInit();
                array[i] = meas;
            }
            return array;
        }

        static void IInitMas()
        {
            IInit[] array2 = new IInit[20];                                                     //создали массив из объектов разных классов с помощью интерфейса IInit
            for (int i = 0; i < 4; i++)
            {
                array2[i] = new ChessboardCell();
                array2[i].RandomInit();
            }
            for (int i = 4; i < 8; i++)
            {
                array2[i] = new HandTool();
                array2[i].RandomInit();
            }
            for (int i = 8; i < 12; i++)
            {
                array2[i] = new MeasuringTool();
                array2[i].RandomInit();
            }
            for (int i = 12; i < 16; i++)
            {
                array2[i] = new ElectricTool();
                array2[i].RandomInit();
            }
            for (int i = 16; i < array2.Length; i++)
            {
                array2[i] = new Instrument();
                array2[i].RandomInit();
            }
            foreach (var item in array2)
            {
                item.Show();
            }
        }

        static ElectricTool[] CreateElectricToolMas()
        {
            ElectricTool[] array3 = new ElectricTool[5];                                                                //создаем новый массив с электрическими инструментами для демонстрации пункта 8 и 9
            for (int i = 0; i < array3.Length; i++)
            {
                array3[i] = new ElectricTool();
                array3[i].RandomInit();
            }
            return array3;
        }

        static void ShowMas(ElectricTool[] array)
        {
            if (array == null)
                Console.WriteLine("Массив пуст");
            else
            {
                foreach (ElectricTool item in array)
                {
                    item.Show();
                }
            }
        }

        static void Main(string[] args)
        {
            sbyte answer2, answerGlobal;
            do
            {
                Instrument[] array = CreateMasFirst(); 
                Console.WriteLine("1. Первая часть");
                Console.WriteLine("2. Вторая часть");
                Console.WriteLine("3. Третья часть");
                Console.WriteLine("4. Выйти");

                answerGlobal = InputSbyteNumber("Выберите, какую часть работы вы хотите посмотреть");

                switch (answerGlobal)
                {
                    case 1: //первая часть лабораторной 
                        {
                            Console.WriteLine("_______Демонстрация первой части лабораторной работы_______");
                            Console.WriteLine("Демонстрация обычного метода Show:");
                            foreach (Instrument item in array)
                            {
                                item.ShowUsual();
                            }
                            Console.WriteLine("Демонстрация виртуального метода Show");
                            foreach (Instrument item in array)
                            {
                                item.Show();
                            }
                            break;
                        } //первая часть закончена
                    case 2: //вторая часть лабораторной
                        {
                            Console.WriteLine("_______Демонстрация второй части либораторной работы_______");
                            Console.WriteLine($"Средняя точность измерительных инструментов массива array: {MeasuringMiddleValue(array, 0.2)}");
                            Console.WriteLine($"Максимальное время работы электрических инструментов из массива arry: {MaxWorkingTime(array)}");
                            Console.WriteLine("Печать всех ручных инструментов:");
                            NameOfHandTools(array);
                            break;
                        } //демонстрация второй части лабораторной работы окончена
                    case 3: //третья часть лабораторной работы
                        {
                            ElectricTool[] array3 = CreateElectricToolMas();
                            sbyte answer3;
                            do
                            {

                                Console.WriteLine("1. Демонатрция работы IInit");
                                Console.WriteLine("2. Показать количество сформированных элементов каждого класса");
                                Console.WriteLine("3. Compare и BinarySearch");
                                Console.WriteLine("4. Копирование и клонирование");
                                Console.WriteLine("5. Выход");
                                answer2 = InputSbyteNumber();

                                switch (answer2)
                                {
                                    case 1:  //демонстрируем IInit
                                        {
                                            Console.WriteLine("Создаем массив с помощью интерфеса IInit и выводим на экран");
                                            IInitMas();
                                            break;
                                        }
                                    case 2: //сформированные объекты
                                        {
                                            Console.WriteLine("Количество созданных объектов каждого класса:");
                                            Console.WriteLine($"Всего создано {ChessboardCell.count} объектов класса ChessboardCell");                      //подсчет созданных объектов каждого класса
                                            Console.WriteLine($"Всего создано {ChessboardCellArray.countArr} объектов класса ChessboardCellArray");
                                            Console.WriteLine($"Всего создано {Instrument.count} объектов класса Instrument");
                                            Console.WriteLine($"Всего создано {HandTool.count} объектов класса HandTool");
                                            Console.WriteLine($"Всего создано {ElectricTool.count} объектов класса ElectricTool");
                                            Console.WriteLine($"Всего создано {MeasuringTool.count} объектов класса MeasuringTool");
                                            Console.WriteLine();
                                            break;
                                        }
                                    case 3: //Compare и BinarySearch
                                        {
                                            Console.WriteLine("Массив до изменений:");
                                            ShowMas(array3);
                                            Console.WriteLine();

                                            ElectricTool inst1 = new ElectricTool(2, "Лобзик", "Аккумулятор", 100);
                                            array3[0] = inst1;
                                            Array.Sort(array3);                                                                                         //сортировка по имени с помощью метода CompareTo

                                            int pos = Array.BinarySearch(array3, new ElectricTool(2, "Лобзик", "Аккумулятор", 100));
                                            foreach (ElectricTool item in array3)                                                                       //вывод сформированного массива после сортировки
                                            {
                                                item.Show();
                                            }
                                            Console.WriteLine("Массив отсортирован по имени");
                                            if (pos < 0) Console.WriteLine("Элемент не найден");
                                            else Console.WriteLine($"Элемент {inst1.id}: {inst1.Name} находится на {pos + 1} позиции");
                                            Console.WriteLine();

                                            ElectricTool inst2 = new ElectricTool(5, "Шлифовальная машинка", "Аккумулятор", 120);
                                            array3[0] = inst2;
                                            Array.Sort(array3, new SortByWorkingTime());
                                            int pos2 = Array.BinarySearch(array3, new ElectricTool(5, "Шлифовальная машинка", "Аккумулятор", 120));        //демонстрация работы ICompare для массива электрических инструментов, 
                                            foreach (Instrument item in array3)                                                                         //время работы от аккумулятора отсортировано по возрастанию
                                            {
                                                item.Show();
                                            }
                                            Console.WriteLine("Массив отсортирован по времени работы от аккумулятора для электронных инструментов");
                                            if (pos2 < 0) Console.WriteLine("Элемент не найден");
                                            else Console.WriteLine($"Элемент {inst2.id}: {inst2.Name} находится на {pos2 + 1} позиции");
                                            Console.WriteLine();
                                            break;
                                        }
                                    case 4: 
                                        {
                                            Console.WriteLine("До изменения");
                                            Instrument instrument = new Instrument();
                                            instrument.RandomInit();
                                            instrument.Show();
                                            Instrument copy = (Instrument)instrument.ShallowCopy();
                                            copy.Show();
                                            Instrument clon = (Instrument)instrument.Clone();
                                            clon.Show();

                                            Console.WriteLine("После изменения");
                                            copy.Name = "copy" + instrument.Name;
                                            copy.id.number = 100;
                                            clon.Name = "clon" + instrument.Name;
                                            clon.id.number = 200;
                                            instrument.Show();
                                            copy.Show();
                                            clon.Show();
                                            break;
                                        }
                                    case 5: //выход из кейса
                                        {
                                            Console.WriteLine("Демонстрация завершена");
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Неправильно задан пункт меню");
                                            break;
                                        }
                                }

                            } while (answer2 != 5);
                            break;
                        } 
                }
            } while (answerGlobal != 4);
        }
    }
}
