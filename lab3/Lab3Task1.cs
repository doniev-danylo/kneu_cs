using System.Reflection;

namespace ReflectionApp
{
    class Lab3Task1
    {
        static string PathResolver(string filePath)
        {
            var projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.FullName;
            var filePathFromRoot = Path.Combine(projectDirectory, filePath);
            Console.WriteLine(filePath);

            if (File.Exists(filePathFromRoot))
            {
                return filePathFromRoot;
            }

            return filePath;
        }

        static void Main(string[] args)
        {
            Assembly assembly =
                Assembly.LoadFrom(PathResolver("TemperatureConverter.dll"));
            Type type = assembly.GetType("TemperatureConverter.TemperatureConverter");
            MethodInfo method = type.GetMethod("ConvertCelsiusToFahrenheit");

            double temperatureInCelsius = 20.0;
            object result = method.Invoke(null, new object[] { temperatureInCelsius });

            Console.WriteLine($"Температура у Цельсіях: {temperatureInCelsius}");
            Console.WriteLine($"Температура у Фаренгейтах: {result}");
        }
    }
}