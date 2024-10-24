using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_Z2
{
    internal class Number_2
    {
        static void Main(string[] args)
        {
            double a = 0.2;//Начало диапазона x
            double b = 1.0;//Конец диапазона x
            const int n = 10;//Количество членов ряда
            const double e = 0.0001;//Заданная точность
            double step = (b - a) / 10;//Шаг x

            double An;//n элемент послед-ти
            double Sn;//сумма ряда с n членами
            double Se;//сумма ряда с точность e
            
            int kolZnakov;
            bool isNumber;
            //Нахождение кол-во знаков после запятой, в выводе
            do
            {
                Console.WriteLine("Введите целое число от 1 до 16 - кол-во знакнов после запятой, в выводе значений");//Вывели на экран информацию 
                isNumber = int.TryParse(Console.ReadLine(), out kolZnakov);//преобразование в int
                if (!isNumber)
                {
                    Console.WriteLine("Введено не целое число");
                }
                else if (kolZnakov>16 || kolZnakov<1)
                {
                    Console.WriteLine("Число не входит в числа от 1 до 16");
                    isNumber = false;
                }
            } while (!isNumber );
            Console.WriteLine($"X\t\tSn(n={n})\tSe(e = {e})\tY");
            //Подсчёт суммы для заданного кол-во элементов
            for (double x = a; x < b; x+=step)//Перебор элементов с заданным шагом
            {
                An = (x - 1) / (x + 1);//0 элемент послед-ти
                Sn = An;//начинаем подсчёт суммы
                for (int i = 0; i < n; i++)//Подсчёт суммы при n членах ряда
                {
                    An *= (Math.Pow((x-1)/(x+1), 2)) * ((2.0 * i + 1)/ (2.0 * i + 3));//рекуррентное соотношение
                    Sn += An;
                }
                //Подсчёт суммы для заданной точности
                An = (x - 1) / (x + 1);//0 элемент послед-ти
                Se = An; ;//начинаем подсчёт суммы 
                int j = 0;
                do
                {
                    An *= (Math.Pow((x - 1) / (x + 1), 2)) * ((2.0 * j + 1) / (2.0 * j + 3));//рекуррентное соотношение
                    Se += An;
                    j++;
                } while (Math.Abs(An) > 0.0001);//условия цикла
                double Y = Math.Log(x)*1/2;//Подсчёт точного значения
                Console.WriteLine($"X = {x:F2}\t"
                    +$"Sn = {Sn.ToString($"F{kolZnakov}")}\t" 
                    +$"Se = {Se.ToString($"F{kolZnakov}")}\t"
                    +$"Y = {Y.ToString($"F{kolZnakov}")}");
            }
        }
    }
}
