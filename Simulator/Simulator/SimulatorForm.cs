using System.IO;
using System.IO.Ports;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Simulator
{
    public partial class SimulatorForm : Form
    {
        private SerialPort comPort = null;
        private DataStore dataStore = null;

        private ushort slaveId = 1;

        public SimulatorForm()
        {                           
            InitializeComponent();
        }

        class DataStore
        { 
            private ushort[] InputRegisters { get; set; }
            private ushort[] HoldingRegisters { get; set; }

            public DataStore()
            {
                InputRegisters = new ushort[256];
                HoldingRegisters = new ushort[256];
            }
            public void setSingleRegisterData(string adress, ushort data = 0)
            {
                int decAdress = int.Parse(adress, System.Globalization.NumberStyles.HexNumber);

                if (decAdress >= 256 && decAdress < 512) InputRegisters[decAdress - 256] = data;

                if (decAdress >= 512) HoldingRegisters[decAdress - 512] = data;
            }
            public ushort getSingleRegisterData(string adress)
            {
                int decAdress = int.Parse(adress, System.Globalization.NumberStyles.HexNumber);

                if (decAdress >= 256 && decAdress < 512) return InputRegisters[decAdress - 256];

                else if (decAdress >= 512) return HoldingRegisters[decAdress - 512];

                else return 5;
            }
        }

        private void activeButton_Click(object sender, System.EventArgs e)
        {
            object selectedPort = portComboBox.SelectedItem;

            portLabel.Text = selectedPort.ToString();

            try 
            {
                comPort.PortName = selectedPort.ToString();
                comPort.BaudRate = 9600;
                comPort.DataBits = 8;
                comPort.Parity = Parity.None;
                comPort.StopBits = StopBits.One;
                comPort.DataReceived += ComPort_DataReceived;

                comPort.Open();

                dataStore = new DataStore();

                dataStore.setSingleRegisterData("100");
                dataStore.setSingleRegisterData("200");

                activeButton.Enabled = false;
                deactiveButton.Enabled = true;
                dataBox.Enabled = true;
            }
            catch
            {
                portComboBox.Items.Remove(selectedPort);

                MessageBox.Show("Порт " + selectedPort.ToString() + " не доступен, выберите другой");
            }
        }
        private void refreshButton_Click(object sender, System.EventArgs e)
        {
            activeButton.Enabled = true;

            string[] ports = SerialPort.GetPortNames();

            comPort = new SerialPort();

            portComboBox.Items.Clear();
            portComboBox.Items.AddRange(ports);

            if (comPort.IsOpen)
            {
                deactiveButton.Enabled = false;
                activeButton.Enabled = true;

                comPort.Close();
            }
        }
        private void deactiveButton_Click(object sender, System.EventArgs e)
        {
            comPort.Close();

            activeButton.Enabled = true;
            deactiveButton.Enabled = false;
            dataBox.Enabled = false;

            portLabel.Text = "Порт не выбран";
        }
        private void setFirstRegisterButton_Click(object sender, EventArgs e)
        {
            dataStore.setSingleRegisterData("100", (ushort)numericUpDownFirstValue.Value);

            firstRegisterLabel.Text = numericUpDownFirstValue.Value.ToString();
        }
        private void setSecondRegisterButton_Click(object sender, EventArgs e)
        {
            dataStore.setSingleRegisterData("200", (ushort)numericUpDownSecondValue.Value);

            secondRegisterLabel.Text = numericUpDownSecondValue.Value.ToString();
        }

        private void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread th = new Thread(Response);
            th.Start();

            UpdateForm();
        }
        private void ChoseResponse(string[] partsRequest)
        {
            switch (ushort.Parse(partsRequest[1]))
            {
                case 3: //03 Read Holding Registers
                    comPort.Write(slaveId.ToString() + " " + partsRequest[1] + " " + dataStore.getSingleRegisterData(partsRequest[2]).ToString() + " 0000"); //Пока что без контрольной суммы
                    break;

                case 6: //06 Preset Single Register
                    dataStore.setSingleRegisterData(partsRequest[2], ushort.Parse(partsRequest[3]));
                    break;

                default:
                    break;
            }
        }

        private void Response()
        {
            string request = comPort.ReadExisting();  //приходит либо строка 16ричных чисел, либо массив битов, работаем с первым вариантом

            string[] partsRequest = request.Split(' '); //11 03 006B 0003 7687  slaveId || Func || First Adress || Count registers  || CRC

            if (ushort.Parse(partsRequest[0]) != slaveId) return;

            ChoseResponse(partsRequest);
        }

        private void UpdateForm()
        {
            firstRegisterLabel.Text = dataStore.getSingleRegisterData("100").ToString();
            secondRegisterLabel.Text = dataStore.getSingleRegisterData("200").ToString();
        }
    }
}
