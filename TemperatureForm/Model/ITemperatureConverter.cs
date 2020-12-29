namespace TemperatureForm.Model
{
    interface ITemperatureConverter
    {
        double Convert(double temperature, TemperatureScale scaleFrom, TemperatureScale scaleTo);
    }
}
