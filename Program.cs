namespace ConsoleApp25
{
    using System;

    namespace DelegateTransformationExample
    {
        class Program
        {
            // Делегат для обчислення послідовностей чисел
            delegate void SequenceGenerator(int count);

            // Метод для виведення перших `count` парних чисел
            static void GenerateEvenNumbers(int count)
            {
                Console.WriteLine("Перші {0} парних чисел:", count);
                for (int i = 1; i <= count; i++)
                {
                    Console.Write((i * 2) + " ");
                }
                Console.WriteLine();
            }

            // Метод для виведення перших `count` чисел Фібоначчі
            static void GenerateFibonacciNumbers(int count)
            {
                Console.WriteLine("Перші {0} чисел Фібоначчі:", count);
                int a = 1, b = 1;

                for (int i = 1; i <= count; i++)
                {
                    Console.Write(a + " ");
                    int temp = a + b;
                    a = b;
                    b = temp;
                }
                Console.WriteLine();
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Виберіть, що ви хочете обчислити:");
                Console.WriteLine("1 - Парні числа");
                Console.WriteLine("2 - Числа Фібоначчі");

                string choice = Console.ReadLine();
                if (string.IsNullOrEmpty(choice))
                {
                    Console.WriteLine("Потрібно було ввести вибір.");
                    return;
                }

                Console.Write("Введіть кількість чисел для обчислення: ");
                string inputCount = Console.ReadLine();
                if (!int.TryParse(inputCount, out int count) || count <= 0)
                {
                    Console.WriteLine("Некоректна кількість. Потрібно ввести додатне число.");
                    return;
                }

                // Змінна для делегата
                SequenceGenerator generator;

                // Вибір делегата на основі вибору користувача
                if (choice == "1")
                {
                    generator = GenerateEvenNumbers;
                }
                else if (choice == "2")
                {
                    generator = GenerateFibonacciNumbers;
                }
                else
                {
                    Console.WriteLine("Некоректний вибір.");
                    return;
                }

                // Виконання вибраного методу
                generator(count);
            }
        }
    }

}
