// script moved from its own project with namespace TemperatureConverter
// to demonstrate source code for build TemperatureConverter.dll
namespace TemperatureConverter;

public static class TemperatureConverter
{
    public static double ConvertCelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9.0 / 5.0) + 32.0;
    }
}