namespace TemperatureForm.Model.Temperature
{
    class Kelvin
    {
        public static double ConvertToFahrenheit(double kelvin)
        {
            return kelvin * 9 / 5 - 459.67;
        }

        public static double ConvertToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }
    }
}
