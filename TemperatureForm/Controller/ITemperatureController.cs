using TemperatureForm.Model;

namespace TemperatureForm.Controller
{
    public interface ITemperatureController
    {
        void SetView(TemperatureDesktopView view);

        void ConvertTemperature(double temperature, TemperatureScale scaleFrom, TemperatureScale scaleTo);
    }
}
