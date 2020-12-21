using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var view = new DesktopView(controller);

            controller.SetView(view);
          
            Application.Run(view);
        }
    }
}
