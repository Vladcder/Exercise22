using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{

    internal class Program
    {
        static int[] FormArray(int size)
        {
            int[] array= new int[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(int.MinValue, int.MaxValue);          
            }
            return array;   
        }


       static void ShowArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        static int FindMax(int[] array)
        {
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max) 
                    max = array[i];
            }
            return max;
        }

        static long FindSum(int[] array)
        {
            long sum=0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }


        static void Main(string[] args)
        {
            int size = Convert.ToInt32(Console.ReadLine());
            Task<int[]> task1 = new Task<int[]>(()=>FormArray(size));
            Task task2 = task1.ContinueWith(t => Console.WriteLine("Вид массива до сортировки"));
            Task task3 = task2.ContinueWith(t => ShowArray(task1.Result));
            Task<int> task4 = task3.ContinueWith<int>(t => FindMax(task1.Result));
            Task<long> task5 = task4.ContinueWith(t => FindSum(task1.Result));
            Task task6 = task5.ContinueWith(t => Console.WriteLine($"Максимальное число в массиве {task4.Result}, сумма чисел в массиве {task5.Result}"));
            task1.Start();
            Console.ReadKey();
        }
    }
}
