using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TemperatureForm.Controller;
using TemperatureForm.Model;
using TemperatureForm.View;

namespace TemperatureForm
{
    public partial class TemperatureView : Form, ITemperatureView
    {
        public ITemperatureController controller;

        public TemperatureView(ITemperatureController controller)
        {
            List<TemperatureScale> temperatureScales = new List<TemperatureScale>
            {
                new TemperatureScale { Description="Кельвины", Name="Kelvin"},
                new TemperatureScale { Description="Фаренгейты", Name="Fahrenheit"},
                new TemperatureScale { Description="Цельсии", Name="Celsius"},
            };

            this.controller = controller;
            InitializeComponent();

            KeyPreview = true;

            temperatureScaleFrom.DataSource = new List<TemperatureScale>(temperatureScales);
            temperatureScaleFrom.DisplayMember = "Description";
            temperatureScaleFrom.ValueMember = "Name";
            temperatureScaleFrom.SelectedIndex = 2;

            temperatureScaleTo.DataSource = new List<TemperatureScale>(temperatureScales);
            temperatureScaleTo.DisplayMember = "Description";
            temperatureScaleTo.ValueMember = "Name";
            temperatureScaleTo.SelectedIndex = 0;
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                var temperature = Double.Parse(initialTemperature.Text);
                var scaleFrom = (TemperatureScale)temperatureScaleFrom.SelectedItem;
                var scaleTo = (TemperatureScale)temperatureScaleTo.SelectedItem;

                controller.ConvertTemperature(temperature, scaleFrom, scaleTo);
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

        public void SetResultTemperature(string resultingTemperatureString, double temperature)
        {
            obtainedTemperature.Clear();
            obtainedTemperature.Text = temperature.ToString();
            labelResultScale.Text = resultingTemperatureString;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnConvert_Click(sender, e);

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }
    }
}
