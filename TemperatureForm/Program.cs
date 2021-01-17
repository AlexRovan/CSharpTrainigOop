using System;
using System.Windows.Forms;
using TemperatureForm.Controller;
using TemperatureForm.Model;

namespace TemperatureForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var temperatureConverter = new TemperatureConverter();
            var controller = new TemperatureController(temperatureConverter);
            var view = new TemperatureView(controller);

            controller.SetView(view);
          
            Application.Run(view);
        }
    }
}
