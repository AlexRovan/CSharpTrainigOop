namespace TemperatureForm.Model.Temperature
{
    class Fahrenheit
    {
        public static double ConvertToKelvin(double fahrenheit)
        {
            return (fahrenheit + 459.67) * 5 / 9;
        }

        public static double ConvertToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}
