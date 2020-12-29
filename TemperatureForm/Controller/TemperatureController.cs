using System;
using TemperatureForm.Model;
using TemperatureForm.View;

namespace TemperatureForm.Controller
{
    public class TemperatureController:ITemperatureController
    {
        private ITemperatureConverter temperatureConverter = new TemperatureConverter();
        private ITemperatureDesktopView view;

        public TemperatureController(TemperatureConverter temperatureConverter)
        {
            this.temperatureConverter = temperatureConverter;
        }

        public void SetView(TemperatureDesktopView view)
        {
            this.view = view;
        }

        public void ConvertTemperature(double temperature, TemperatureScale scaleFrom, TemperatureScale scaleTo)
        {
            double result = temperatureConverter.Convert(temperature, scaleFrom, scaleTo);

            switch (scaleTo.Name)
            {
                case TemperatureConverter.KelvinScaleName:

                    view.SetResultTemperature($"в градусах Кельвина", result);
                    break;
                case TemperatureConverter.FahrenheitScaleName:

                    view.SetResultTemperature($"в градусах Фаренгейта", result);
                    break;
                case TemperatureConverter.CelsiusScaleName:

                    view.SetResultTemperature($"в градусах Цельсия", result);
                    break;
                default:
                    throw new ArgumentException("Указана некорретная температурная шкала.");
            }
        }

    }
}
