using TemperatureForm.Model;
using TemperatureForm.View;

namespace TemperatureForm.Controller
{
    public interface ITemperatureController
    {
        void SetView(ITemperatureView view);

        void ConvertTemperature(double temperature, TemperatureScale scaleFrom, TemperatureScale scaleTo);
    }
}
