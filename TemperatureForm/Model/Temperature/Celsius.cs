namespace TemperatureForm.Model.Temperature
{
    class Celsius
    {
        public static double ConvertToFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }

        public static double ConvertToKelvin(double celsius)
        {
            return celsius + 273.15;
        }
    }
}
