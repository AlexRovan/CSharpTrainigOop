using System;

namespace TemperatureForm.Model
{
    public class TemperatureScales
    {
        public string Description { get; set; }

        public string Name { get; set; }
    }

    public class TemperatureConverter
    {
        public const string kelvinScaleName  = "Kelvin";
        public const string celsiusScaleName = "Celsius";
        public const string fahrenheitScaleName = "Fahrenheit";
        private const double minimumCelsiusTemperature = -273.15;
        private const double minimumKelvinTemperature = 0;
        private const double minimumFahrenheitTemperature = -459.67;

        public double Convert(double temperature, TemperatureScales scaleFrom, TemperatureScales scaleTo)
        {
            switch (scaleFrom.Name)
            {
                case celsiusScaleName:

                    if (temperature < minimumCelsiusTemperature)
                    {
                        throw new Exception("Температура не может быть меньше абсолютного 0.");
                    }

                    if (Equals(scaleTo.Name, kelvinScaleName))
                    {
                        return ConvertCelsiusToKelvin(temperature);
                    }

                    if (Equals(scaleTo.Name, fahrenheitScaleName))
                    {
                        return ConvertCelsiusToFahrenheit(temperature);
                    }

                    break;
                case fahrenheitScaleName:

                    if (temperature < minimumFahrenheitTemperature)
                    {
                        throw new Exception("Температура не может быть меньше абсолютного 0.");
                    }

                    if (Equals(scaleTo.Name, kelvinScaleName))
                    {
                        return ConvertFahrenheitToKelvin(temperature);
                    }

                    if (Equals(scaleTo.Name, celsiusScaleName))
                    {
                        return ConvertFahrenheitToCelsius(temperature);
                    }

                    break;
                case kelvinScaleName:

                    if (temperature < minimumKelvinTemperature)
                    {
                        throw new Exception("Теспература не может быть меньше абсолютного 0.");
                    }

                    if (Equals(scaleTo.Name, fahrenheitScaleName))
                    {
                        return ConvertKelvinToFahrenheit(temperature);
                    }

                    if (Equals(scaleTo.Name, celsiusScaleName))
                    {
                        return ConvertKelvinToCelsius(temperature);
                    }

                    break;
                default:
                    throw new ArgumentException("Указана некорретная температурная шкала.");

            }
            return temperature;
        }

        private double ConvertCelsiusToKelvin(double celsius)
        {
            return celsius + 273.15;
        }

        private double ConvertCelsiusToFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }

        private double ConvertKelvinToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }

        private double ConvertKelvinToFahrenheit(double kelvin)
        {
            return kelvin * 9 / 5 - 459.67;
        }

        private double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        private double ConvertFahrenheitToKelvin(double fahrenheit)
        {
            return (fahrenheit + 459.67) * 5 / 9;
        }
    }
}
