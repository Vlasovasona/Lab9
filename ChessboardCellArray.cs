using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_10
{
    public class ChessboardCellArray: IInit
    {

        static Random rnd = new Random();
        public static byte countArr = 0;

        ChessboardCell[] arr;
        public int Length
        {
            get => arr.Length;
        }

        public ChessboardCellArray()                         //по умолчанию создается массив с одним объектом, который формируется с помощью (опять же) конструктора по умолчанию
        {
            arr = new ChessboardCell[1];
            arr[0] = new ChessboardCell();
            countArr++;
        }

        public void Init()                                  //конструктор с параметром
        {
            Console.WriteLine($"Введите длину массива");
            sbyte length = sbyte.Parse(Console.ReadLine());
            arr = new ChessboardCell[length];
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Введите координату x для {i + 1} клетки");
                int first = int.Parse(Console.ReadLine());
                Console.WriteLine($"Введите координату y для {i + 1} клетки");
                int second = int.Parse(Console.ReadLine());
                arr[i] = new ChessboardCell(first, second);
            }
            countArr++;
        }

        public void RandomInit()                                  
        {
            int length = rnd.Next(1, 9);
            arr = new ChessboardCell[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = new ChessboardCell(rnd.Next(1,9), rnd.Next(1,9));
            }
            countArr++;
        }



        public ChessboardCellArray(ChessboardCellArray other)                   //конструктор копирования
        {
            countArr++;
            this.arr = new ChessboardCell[other.Length];
            for (int i = 0; i < other.Length; i++)
                this.arr[i] = new ChessboardCell(other.arr[i]);                 //мы выделяем новую область памяти и делаем глубокое клонирование, т.к. иначе при поверхностном
        }                                                                       //у нас бы изменялись элементы обоих массивов, потому что новый массив содержал бы ссылки на 
                                                                                //элементы второго

        public void Show()
        {
            if (arr.Length == 0)
                Console.WriteLine("Массив пуст");
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i].Show();
                }
            }
        }
        
        public ChessboardCell this[int index]                                   //индексатор
        {
            get
            {
                if (0 <= index && index < arr.Length)
                    return arr[index];
                else
                    throw new Exception("Индекс выходит за пределы коллекции");
            }
            set
            {
                if (0 <= index && index < arr.Length)
                    arr[index] = value;
                else
                    Console.WriteLine("Индекс выходит за пределы коллекции");
            }
        }
        public static byte CountArrOutput()
        {
            return countArr;
        }
    }
}
