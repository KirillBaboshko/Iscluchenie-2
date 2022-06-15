using System;
using static System.Console;

namespace Iscluchenie_2
{
    class GarbageHelper
    {
        //Метод, создающий мусор
        public void MakeGarbage()
        {
            for (int i = 0; i < 1000; i++)
            {
                Person p = new Person();
            }
        }
        class Person
        {
            string _name;
            string _surname;
            byte _age;
        }
    }
    class ExampleNameOf
    {
        public string Name { set; get; }
        public ExampleNameOf(string name)
        {
            if(name==null)
            {
                throw new ArgumentException(nameof(name));
            }
            Name = name;
        }
    }
    class DisposeExample : IDisposable
    {
        private bool isDisposed = false;
        private void Cleaning(bool disposing)
        {
            if(!isDisposed)
            {
                if(disposing)
                {
                    WriteLine("Освобождение управляемых ресурсов");
                }
                WriteLine("Освобождение неуправляемых ресурсов");
            }
            isDisposed = true;
        }
        public void Dispose()
        {
            Cleaning(true);
            GC.SuppressFinalize(this);

        }
        ~DisposeExample()
        {
            Cleaning(false);
        }
    }
    class Program
    {
        
        static int DivisionNumbers(int n1, int n2)
        {
            int result = 0;
            try
            {
                result = n1 / n2;
            }
            catch (DivideByZeroException de)
            {
                throw new Exception("Проверка фильтров исключения", de);
            }
            return result;
        }
        static void Main(string[] args)
        {
            DisposeExample de = new DisposeExample();
            de.Dispose();
            DisposeExample test1 = new DisposeExample();
            test1.Dispose();
            //try
            //{
            //    ExampleNameOf examle = new ExampleNameOf(null);
            //}
            //catch(Exception e)
            //{
            //    WriteLine(e.Message);
            //}

            //WriteLine("Демонстрация System.GC");
            //WriteLine($"Максимальное поколение:{ GC.MaxGeneration}");
            //GarbageHelper hlp = new GarbageHelper();
            ////узнаем поколение, в котором находится объект
            //WriteLine($"Поколение объекта: { GC.GetGeneration(hlp)}");
            //// количество занятой памяти
            //WriteLine($"Занято памяти(байт): { GC.GetTotalMemory(false)}");
            //hlp.MakeGarbage(); //создаем мусор
            //WriteLine($"Занято памяти(байт): { GC.GetTotalMemory(false)}");
            //GC.Collect(0); //вызываем явный сбор мусора 
            //               //в поколении 0
            //WriteLine($"Занято памяти(байт): { GC.GetTotalMemory(false)}");
            //WriteLine($"Поколение объекта:{ GC.GetGeneration(hlp)}");
            //GC.Collect(); //вызываем явный сбор мусора 
            //   //во всех поколениях
            //WriteLine($"Занято памяти(байт): { GC.GetTotalMemory(false)}");
            //WriteLine($"Поколение объекта: { GC.GetGeneration(hlp)}");

            //WriteLine("Введите два числа");
            //int number1, number2, result = 0;
            //try
            //{
            //    number1 = int.Parse(ReadLine());
            //    number2 = int.Parse(ReadLine());
            //    result = DivisionNumbers(number1, number2);
            //    WriteLine($"Результат деления чисел:{ result }");
            //}
            //catch (Exception e) when (e.InnerException !=
            //null)
            //{
            //    WriteLine(e.Message); //дополнительная 
            //                          //информация
            //    WriteLine(e.InnerException.Message);
            //    //предыдущее исключение
            //}
            //catch (Exception e)
            //{
            //    WriteLine(e.Message);
            //}
        }
    }
}
