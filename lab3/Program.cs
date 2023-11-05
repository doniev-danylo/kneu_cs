using System.Reflection;

namespace ReflectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom("/Users/donevd/Documents/КНЕУ/апбд/kneu_cs/lab3/TemperatureConverter.dll");
            Type type = assembly.GetType("TemperatureConverter.TemperatureConverter");
            MethodInfo method = type.GetMethod("ConvertCelsiusToFahrenheit");

            double temperatureInCelsius = 20.0;
            object result = method.Invoke(null, new object[] { temperatureInCelsius });

            Console.WriteLine($"Температура у Цельсіях: {temperatureInCelsius}");
            Console.WriteLine($"Температура у Фаренгейтах: {result}");
        }
    }
}