using System;
using System.Collections.Generic;

namespace Algo8
{
    class Program
    {
        static void Main(string[] args)
        {
            // проверка

            // генерация массива со случайными числами 

            int[] arr = new int[50];
            Random rnd = new Random();

            for(int i =0; i< arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 99);
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine();
            // выполнение сортировки и проверка

            BucketSort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                
                Console.WriteLine(arr[i]);
            }

        }

        static void BucketSort(int[] a)
        {
            // поиск диапазона значений в массиве-источнике
            int minValue = a[0];
            int maxValue = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < minValue)
                {
                    minValue = a[i];
                }
                else if (a[i] > maxValue)
                {
                    maxValue = a[i];
                }
            }



            // количество корзин равно диапазону элементов в массиве-источнике, поделенному на 10, плюс 1
            int b = 1+ (maxValue - minValue) / 10;

            // создаем массив корзин

            List<int>[] busket = new List<int>[b];

            // инициализация корзин

            for(int i=0; i<b; i++)
            {
                busket[i] = new List<int>();

            }

           
            // распределяем элементы массива по корзинам
            // делим элемент на 10 кладем в корзину с соответствующим индексом


            for(int i = 0; i<a.Length;i++)
            {
                int ind = a[i]/10;
                
                busket[ind].Add(a[i]);

            }

            // выполняем сортировку элементов внутри корзин, использовала штатный метод


            for (int i = 0; i < b; i++)
            {
                busket[i].Sort();

            }

            // собираем элементы в массив-источник

            int n = 0;
            for (int i = 0; i < b; i++)
            {
               for (int j = 0; j<busket[i].Count; j++)
                {
                    a[n++] = busket[i][j];
                }

            }

        }

        

    }
}
