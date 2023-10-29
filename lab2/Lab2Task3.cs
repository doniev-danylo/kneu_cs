namespace lab2;

public class Lab2Task3
{
    public class ComplexNumber
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public ComplexNumber Add(ComplexNumber other)
    {
        return new ComplexNumber(Real + other.Real, Imaginary + other.Imaginary);
    }
    
    public ComplexNumber Subtract(ComplexNumber other)
    {
        return new ComplexNumber(Real - other.Real, Imaginary - other.Imaginary);
    }
    
    public ComplexNumber Multiply(ComplexNumber other)
    {
        double real = Real * other.Real - Imaginary * other.Imaginary;
        double imaginary = Real * other.Imaginary + Imaginary * other.Real;
        return new ComplexNumber(real, imaginary);
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}

    public static void RunTask3()
    {
        ComplexNumber complex1 = new ComplexNumber(3, 2); // 3 + 2i
        ComplexNumber complex2 = new ComplexNumber(1, 7); // 1 + 7i

        Console.WriteLine($"Complex1: {complex1}");
        Console.WriteLine($"Complex2: {complex2}");

        ComplexNumber result = complex1.Add(complex2);
        Console.WriteLine($"Add: {result}");

        result = complex1.Subtract(complex2);
        Console.WriteLine($"Subtract: {result}");

        result = complex1.Multiply(complex2);
        Console.WriteLine($"Multiply: {result}");
    }
}