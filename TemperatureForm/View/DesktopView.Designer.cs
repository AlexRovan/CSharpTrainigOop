namespace TemperatureForm
{
    partial class DesktopView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label labelResult;
            this.btnConvert = new System.Windows.Forms.Button();
            this.initialTemperature = new System.Windows.Forms.TextBox();
            this.obtainedTemperature = new System.Windows.Forms.TextBox();
            this.inputTempLabel = new System.Windows.Forms.Label();
            this.temperatureScaleFrom = new System.Windows.Forms.ComboBox();
            this.temperatureScaleTo = new System.Windows.Forms.ComboBox();
            labelResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new System.Drawing.Point(70, 75);
            labelResult.Name = "labelResult";
            labelResult.Size = new System.Drawing.Size(59, 13);
            labelResult.TabIndex = 4;
            labelResult.Text = "Результат";
            // 
            // btnConvert
            // 
            this.btnConvert.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConvert.Location = new System.Drawing.Point(135, 39);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(100, 23);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "Конвертировать";
            this.btnConvert.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.BtnConvert_Click);
            // 
            // initialTemperature
            // 
            this.initialTemperature.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.initialTemperature.Location = new System.Drawing.Point(135, 15);
            this.initialTemperature.MaxLength = 7;
            this.initialTemperature.Name = "initialTemperature";
            this.initialTemperature.Size = new System.Drawing.Size(100, 20);
            this.initialTemperature.TabIndex = 1;
            // 
            // obtainedTemperature
            // 
            this.obtainedTemperature.Location = new System.Drawing.Point(135, 68);
            this.obtainedTemperature.Name = "obtainedTemperature";
            this.obtainedTemperature.ReadOnly = true;
            this.obtainedTemperature.Size = new System.Drawing.Size(215, 20);
            this.obtainedTemperature.TabIndex = 2;
            // 
            // inputTempLabel
            // 
            this.inputTempLabel.AutoSize = true;
            this.inputTempLabel.Location = new System.Drawing.Point(13, 18);
            this.inputTempLabel.Name = "inputTempLabel";
            this.inputTempLabel.Size = new System.Drawing.Size(116, 13);
            this.inputTempLabel.TabIndex = 3;
            this.inputTempLabel.Text = "Введите температуру";
            // 
            // temperatureScaleFrom
            // 
            this.temperatureScaleFrom.DisplayMember = "1";
            this.temperatureScaleFrom.FormattingEnabled = true;
            this.temperatureScaleFrom.Location = new System.Drawing.Point(241, 15);
            this.temperatureScaleFrom.Name = "temperatureScaleFrom";
            this.temperatureScaleFrom.Size = new System.Drawing.Size(109, 21);
            this.temperatureScaleFrom.TabIndex = 5;
            this.temperatureScaleFrom.ValueMember = "1";
            // 
            // temperatureScaleTo
            // 
            this.temperatureScaleTo.DisplayMember = "2";
            this.temperatureScaleTo.FormattingEnabled = true;
            this.temperatureScaleTo.Location = new System.Drawing.Point(241, 41);
            this.temperatureScaleTo.Name = "temperatureScaleTo";
            this.temperatureScaleTo.Size = new System.Drawing.Size(109, 21);
            this.temperatureScaleTo.TabIndex = 6;
            this.temperatureScaleTo.ValueMember = "2";
            // 
            // DesktopView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 115);
            this.Controls.Add(this.temperatureScaleTo);
            this.Controls.Add(this.temperatureScaleFrom);
            this.Controls.Add(labelResult);
            this.Controls.Add(this.inputTempLabel);
            this.Controls.Add(this.obtainedTemperature);
            this.Controls.Add(this.initialTemperature);
            this.Controls.Add(this.btnConvert);
            this.Name = "DesktopView";
            this.Text = "Конвертер температуры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox initialTemperature;
        private System.Windows.Forms.TextBox obtainedTemperature;
        private System.Windows.Forms.Label inputTempLabel;
        private System.Windows.Forms.ComboBox temperatureScaleFrom;
        private System.Windows.Forms.ComboBox temperatureScaleTo;
    }
}

