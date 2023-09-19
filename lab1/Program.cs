public class Program
{
    private static void Task1()
    {
        Console.WriteLine("Task 1");
        Console.Write("Enter a number between 0 and 100: ");
        var input = Console.ReadLine();

        if (int.TryParse(input, out var number))
        {
            switch (number)
            {
                case >= 0 and <= 14:
                    Console.WriteLine("The number is in the range [0-14]");
                    break;
                case <= 35:
                    Console.WriteLine("The number is in the range [15-35]");
                    break;
                case <= 50:
                    Console.WriteLine("The number is in the range [36-50]");
                    break;
                case <= 100:
                    Console.WriteLine("The number is in the range [50-100]");
                    break;
                default:
                    Console.WriteLine("The number is not in any of the specified ranges.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("That's not a valid number.");
        }
    }

    private static void Task2()
    {
        Console.WriteLine("Task 2");
        Console.Write("Enter the number of clients: ");
        var input = Console.ReadLine();

        if (int.TryParse(input, out var n))
        {
            long fact = 1;
            var count = 1;
            do
            {
                fact *= count;
                count++;
            } while (count <= n);

            Console.WriteLine($"Number of possible delivery routes: {fact}");
        }
        else
        {
            Console.WriteLine("That's not a valid number.");
        }
    }


    private static void ConcatenateStrings()
    {
        Console.WriteLine("Concatenate Strings | variant 5");
        Console.Write("Enter the first string: ");
        var str1 = Console.ReadLine();

        Console.Write("Enter the second string: ");
        var str2 = Console.ReadLine();

        Console.WriteLine($"Result: {str1 + str2}");
    }


    public static void Main()
    {
        while (true)
        {
            Task1();
            Task2();
            ConcatenateStrings();
        }
    }
}