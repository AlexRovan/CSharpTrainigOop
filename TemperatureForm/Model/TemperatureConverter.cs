using System;
using TemperatureForm.Model.Temperature;

namespace TemperatureForm.Model
{
    public class TemperatureConverter : ITemperatureConverter
    {
        public const string KelvinScaleName = "Kelvin";
        public const string CelsiusScaleName = "Celsius";
        public const string FahrenheitScaleName = "Fahrenheit";
        private const double MinimumCelsiusTemperature = -273.15;
        private const double MinimumKelvinTemperature = 0;
        private const double MinimumFahrenheitTemperature = -459.67;

        public double Convert(double temperature, TemperatureScale scaleFrom, TemperatureScale scaleTo)
        {
            switch (scaleFrom.Name)
            {
                case CelsiusScaleName:

                    if (temperature < MinimumCelsiusTemperature)
                    {
                        throw new Exception("Температура не может быть меньше абсолютного 0.");
                    }

                    if (Equals(scaleTo.Name, KelvinScaleName))
                    {
                        return Celsius.ConvertToKelvin(temperature);
                    }

                    if (Equals(scaleTo.Name, FahrenheitScaleName))
                    {
                        return Celsius.ConvertToFahrenheit(temperature);
                    }

                    break;
                case FahrenheitScaleName:

                    if (temperature < MinimumFahrenheitTemperature)
                    {
                        throw new Exception("Температура не может быть меньше абсолютного 0.");
                    }

                    if (Equals(scaleTo.Name, KelvinScaleName))
                    {
                        return Fahrenheit.ConvertToKelvin(temperature);
                    }

                    if (Equals(scaleTo.Name, CelsiusScaleName))
                    {
                        return Fahrenheit.ConvertToCelsius(temperature);
                    }

                    break;
                case KelvinScaleName:

                    if (temperature < MinimumKelvinTemperature)
                    {
                        throw new Exception("Теспература не может быть меньше абсолютного 0.");
                    }

                    if (Equals(scaleTo.Name, FahrenheitScaleName))
                    {
                        return Kelvin.ConvertToFahrenheit(temperature);
                    }

                    if (Equals(scaleTo.Name, CelsiusScaleName))
                    {
                        return Kelvin.ConvertToCelsius(temperature);
                    }

                    break;
                default:
                    throw new ArgumentException("Указана некорретная температурная шкала.");

            }
            return temperature;
        }
    }
}
