﻿
namespace Simulator
{
    partial class SimulatorForm
    {
      
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.activeButton = new System.Windows.Forms.Button();
            this.deactiveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.firstRegisterLabel = new System.Windows.Forms.Label();
            this.secondRegisterLabel = new System.Windows.Forms.Label();
            this.dataBox = new System.Windows.Forms.GroupBox();
            this.numericUpDownSecondValue = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFirstValue = new System.Windows.Forms.NumericUpDown();
            this.setFirstRegisterButton = new System.Windows.Forms.Button();
            this.setSecondRegisterButton = new System.Windows.Forms.Button();
            this.dataBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSecondValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFirstValue)).BeginInit();
            this.SuspendLayout();
            // 
            // portComboBox
            // 
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.portComboBox.Location = new System.Drawing.Point(12, 12);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(121, 21);
            this.portComboBox.TabIndex = 0;
            this.portComboBox.Text = "Выберите порт";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(166, 12);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(102, 23);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Обновить";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // activeButton
            // 
            this.activeButton.Enabled = false;
            this.activeButton.Location = new System.Drawing.Point(166, 41);
            this.activeButton.Name = "activeButton";
            this.activeButton.Size = new System.Drawing.Size(102, 23);
            this.activeButton.TabIndex = 2;
            this.activeButton.Text = "Активировать";
            this.activeButton.UseVisualStyleBackColor = true;
            this.activeButton.Click += new System.EventHandler(this.activeButton_Click);
            // 
            // deactiveButton
            // 
            this.deactiveButton.Enabled = false;
            this.deactiveButton.Location = new System.Drawing.Point(166, 70);
            this.deactiveButton.Name = "deactiveButton";
            this.deactiveButton.Size = new System.Drawing.Size(102, 23);
            this.deactiveButton.TabIndex = 3;
            this.deactiveButton.Text = "Деактивировать";
            this.deactiveButton.UseVisualStyleBackColor = true;
            this.deactiveButton.Click += new System.EventHandler(this.deactiveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выбранный порт:";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(12, 75);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(88, 13);
            this.portLabel.TabIndex = 5;
            this.portLabel.Text = "Порт не выбран";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Регистр 0х100: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Регистр 0х200: ";
            // 
            // firstRegisterLabel
            // 
            this.firstRegisterLabel.AutoSize = true;
            this.firstRegisterLabel.Location = new System.Drawing.Point(90, 25);
            this.firstRegisterLabel.Name = "firstRegisterLabel";
            this.firstRegisterLabel.Size = new System.Drawing.Size(13, 13);
            this.firstRegisterLabel.TabIndex = 8;
            this.firstRegisterLabel.Text = "0";
            // 
            // secondRegisterLabel
            // 
            this.secondRegisterLabel.AutoSize = true;
            this.secondRegisterLabel.Location = new System.Drawing.Point(90, 57);
            this.secondRegisterLabel.Name = "secondRegisterLabel";
            this.secondRegisterLabel.Size = new System.Drawing.Size(13, 13);
            this.secondRegisterLabel.TabIndex = 9;
            this.secondRegisterLabel.Text = "0";
            // 
            // dataBox
            // 
            this.dataBox.Controls.Add(this.numericUpDownSecondValue);
            this.dataBox.Controls.Add(this.numericUpDownFirstValue);
            this.dataBox.Controls.Add(this.setFirstRegisterButton);
            this.dataBox.Controls.Add(this.setSecondRegisterButton);
            this.dataBox.Controls.Add(this.label2);
            this.dataBox.Controls.Add(this.secondRegisterLabel);
            this.dataBox.Controls.Add(this.label3);
            this.dataBox.Controls.Add(this.firstRegisterLabel);
            this.dataBox.Enabled = false;
            this.dataBox.Location = new System.Drawing.Point(12, 99);
            this.dataBox.Name = "dataBox";
            this.dataBox.Size = new System.Drawing.Size(256, 88);
            this.dataBox.TabIndex = 10;
            this.dataBox.TabStop = false;
            this.dataBox.Text = "Данные регистров";
            // 
            // numericUpDownSecondValue
            // 
            this.numericUpDownSecondValue.Location = new System.Drawing.Point(123, 55);
            this.numericUpDownSecondValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownSecondValue.Name = "numericUpDownSecondValue";
            this.numericUpDownSecondValue.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownSecondValue.TabIndex = 13;
            // 
            // numericUpDownFirstValue
            // 
            this.numericUpDownFirstValue.Location = new System.Drawing.Point(124, 23);
            this.numericUpDownFirstValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownFirstValue.Name = "numericUpDownFirstValue";
            this.numericUpDownFirstValue.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownFirstValue.TabIndex = 11;
            // 
            // setFirstRegisterButton
            // 
            this.setFirstRegisterButton.Location = new System.Drawing.Point(175, 21);
            this.setFirstRegisterButton.Name = "setFirstRegisterButton";
            this.setFirstRegisterButton.Size = new System.Drawing.Size(75, 23);
            this.setFirstRegisterButton.TabIndex = 11;
            this.setFirstRegisterButton.Text = "Записать";
            this.setFirstRegisterButton.UseVisualStyleBackColor = true;
            this.setFirstRegisterButton.Click += new System.EventHandler(this.setFirstRegisterButton_Click);
            // 
            // setSecondRegisterButton
            // 
            this.setSecondRegisterButton.Location = new System.Drawing.Point(175, 54);
            this.setSecondRegisterButton.Name = "setSecondRegisterButton";
            this.setSecondRegisterButton.Size = new System.Drawing.Size(75, 23);
            this.setSecondRegisterButton.TabIndex = 12;
            this.setSecondRegisterButton.Text = "Записать";
            this.setSecondRegisterButton.UseVisualStyleBackColor = true;
            this.setSecondRegisterButton.Click += new System.EventHandler(this.setSecondRegisterButton_Click);
            // 
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 194);
            this.Controls.Add(this.dataBox);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deactiveButton);
            this.Controls.Add(this.activeButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.portComboBox);
            this.Name = "SimulatorForm";
            this.Text = "Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.dataBox.ResumeLayout(false);
            this.dataBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSecondValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFirstValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox portComboBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button activeButton;
        private System.Windows.Forms.Button deactiveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label firstRegisterLabel;
        private System.Windows.Forms.Label secondRegisterLabel;
        private System.Windows.Forms.GroupBox dataBox;
        private System.Windows.Forms.Button setFirstRegisterButton;
        private System.Windows.Forms.Button setSecondRegisterButton;
        private System.Windows.Forms.NumericUpDown numericUpDownSecondValue;
        private System.Windows.Forms.NumericUpDown numericUpDownFirstValue;
    }
}

