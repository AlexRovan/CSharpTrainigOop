using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TemperatureForm.Controller;
using TemperatureForm.Model;

namespace TemperatureForm
{
    public partial class DesktopView : Form
    {
        public TemperatureController controller;

        public DesktopView(TemperatureController controller)
        {
            List<TemperatureScales> temperatureScales = new List<TemperatureScales>
            {
                new TemperatureScales { Description="Кельвины", Name="Kelvin"},
                new TemperatureScales { Description="Фаренгейты", Name="Fahrenheit"},
                new TemperatureScales { Description="Цельсии", Name="Celsius"},
            };

            this.controller = controller;
            InitializeComponent();

            temperatureScaleFrom.DataSource = new List<TemperatureScales>(temperatureScales);
            temperatureScaleFrom.DisplayMember = "Description";
            temperatureScaleFrom.ValueMember = "Name";
            temperatureScaleFrom.SelectedIndex = 2;

            temperatureScaleTo.DataSource = new List<TemperatureScales>(temperatureScales);
            temperatureScaleTo.DisplayMember = "Description";
            temperatureScaleTo.ValueMember = "Name";
            temperatureScaleTo.SelectedIndex = 0;
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                var temp = Double.Parse(initialTemperature.Text);
                var scaleFrom = (TemperatureScales)temperatureScaleFrom.SelectedItem;
                var scaleTo = (TemperatureScales)temperatureScaleTo.SelectedItem;

                controller.ConvertTemperature(temp, scaleFrom, scaleTo);
            }
            catch (FormatException)
            {
                MessageBox.Show("Температура может быть только числом.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка преобразования: {ex.Message}.");
            }
        }

        public void SetResultTemperature(string resultingTemperatureString)
        {
            obtainedTemperature.Clear();
            obtainedTemperature.Text = resultingTemperatureString;
        }
    }
}
