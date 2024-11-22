using System;

class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message) { }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nОберіть дію:");
            Console.WriteLine("1 - Поділити два числа");
            Console.WriteLine("2 - Обчислити квадратний корінь числа");
            Console.WriteLine("3 - Перевірити, чи рядок можна перетворити у число");
            Console.WriteLine("0 - Вийти з програми");
            Console.Write("Ваш вибір: ");

            try
            {
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DivideTwoNumbers();
                        break;

                    case "2":
                        CalculateSquareRoot();
                        break;

                    case "3":
                        ValidateAndConvertStringToNumber();
                        break;

                    case "0":
                        Console.WriteLine("Вихід із програми. До побачення!");
                        return;

                    default:
                        Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неочікувана помилка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Дякуємо за використання програми.");
            }
        }
    }

    static void DivideTwoNumbers()
    {
        try
        {
            Console.Write("Введіть перше число: ");
            if (!double.TryParse(Console.ReadLine(), out double num1))
                throw new FormatException("Введене значення не є числом.");

            Console.Write("Введіть друге число: ");
            if (!double.TryParse(Console.ReadLine(), out double num2))
                throw new FormatException("Введене значення не є числом.");

            if (num2 == 0)
                throw new DivideByZeroException("Ділення на нуль неможливе.");

            double result = num1 / num2;
            Console.WriteLine($"Результат: {num1} / {num2} = {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: Ви ввели некоректне значення.");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Завершено операцію ділення.");
        }
    }

    static void CalculateSquareRoot()
    {
        try
        {
            Console.Write("Введіть число: ");
            double number = Convert.ToDouble(Console.ReadLine());

            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number), "Число не повинно бути від'ємним.");

            double squareRoot = Math.Sqrt(number);
            Console.WriteLine($"Квадратний корінь числа {number}: {squareRoot}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: Ви ввели некоректне значення.");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Завершено обчислення квадратного кореня.");
        }
    }

    static void ValidateAndConvertStringToNumber()
    {
        try
        {
            Console.Write("Введіть рядок: ");
            string userInput = Console.ReadLine().Trim();  // Очищення від зайвих пробілів

            if (double.TryParse(userInput, out double number))
            {
                if (number < 0)
                {
                    Console.WriteLine("Квадратний корінь від від'ємного числа не існує.");
                }
                else
                {
                    double squareRoot = Math.Sqrt(number);
                    Console.WriteLine($"Квадратний корінь числа {number}: {squareRoot}");
                }
            }
            else
            {
                throw new InvalidInputException("Введений рядок не можна перетворити у число.");
            }
        }
        catch (InvalidInputException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Завершено перевірку введеного рядка.");
        }
    }
}
