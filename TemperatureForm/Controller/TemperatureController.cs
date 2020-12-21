using System;
using TemperatureForm.Model;

namespace TemperatureForm.Controller
{
    public class TemperatureController
    {
        private TemperatureConverter temperatureConverter = new TemperatureConverter();
        private DesktopView view;
       
        public TemperatureController(TemperatureConverter temperatureConverter)
        {
            this.temperatureConverter = temperatureConverter;
        }

        public void SetView(DesktopView view)
        {
            this.view = view;
        }

        public void ConvertTemperature(double temperature, TemperatureScales scaleFrom, TemperatureScales scaleTo)
        {
            double result = temperatureConverter.Convert(temperature, scaleFrom, scaleTo);
            
            switch (scaleTo.Name)
            {
                case TemperatureConverter.kelvinScaleName:

                    view.SetResultTemperature($"Результат в градусах Кельвина {result}");
                    break;
                case TemperatureConverter.fahrenheitScaleName:

                    view.SetResultTemperature($"Результат в градусах Фаренгейта {result}");
                    break;
                case TemperatureConverter.celsiusScaleName:

                    view.SetResultTemperature($"Результат в градусах Цельсия {result}");
                    break;       
                default:
                    throw new ArgumentException("Указана некорретная температурная шкала.");
            }
        }

    }
}
