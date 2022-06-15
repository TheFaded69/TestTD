using System.IO;
using System.IO.Ports;
using System;
using System.Threading;

using System.Windows.Forms;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data_collecting
{
    public partial class Collector : Form
    {
        SerialPort comPort = new SerialPort();

        private int frequancuRequest = 1; //1 секунда по умолчанию

        private SqlConnection sqlConnection = null;

        private Thread th = null;

        private string adress;
        public Collector()
        {
            InitializeComponent();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            activeButton.Enabled = true;

            string[] ports = SerialPort.GetPortNames();

            portComboBox.Items.Clear();
            portComboBox.Items.AddRange(ports);

            if (comPort.IsOpen) comPort.Close();
        }

        static void RemoveAt(ref string[] array, int index)
        {
            string[] newArray = new string[array.Length - 1];

            for (int i = 0; i < index; i++) newArray[i] = array[i];

            for (int i = index + 1; i < array.Length; i++) newArray[i - 1] = array[i];

            array = newArray;
        }

        private void activeButton_Click(object sender, EventArgs e)
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

                dataBox.Enabled = true;
                activeButton.Enabled = false;
                deactiveButton.Enabled = true;
            }
            catch
            {
                portComboBox.Items.Remove(selectedPort);

                MessageBox.Show("Порт " + selectedPort.ToString() + " не доступен, выберите другой");
            }
        }

        private void deactiveButton_Click(object sender, EventArgs e)
        {
            comPort.Close();

            activeButton.Enabled = true;
            deactiveButton.Enabled = false;

            portLabel.Text = "Порт не выбран";
        }

        private void setFirstRegisterButton_Click(object sender, EventArgs e)
        {
            //На будущее
        }

        private void setSecondRegisterButton_Click(object sender, EventArgs e)
        {
            string request = "1 6 200 ";

            request += numericUpDownSecondValue.Value.ToString();
            
            comPort.Write(request);
        }

        private void frequancyButton_Click(object sender, EventArgs e)
        {
            frequancuRequest = int.Parse(frequancyBox.Text);
        }

        //private void frequancyBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)


        private void readButton_Click(object sender, EventArgs e)  //отдельный поток для метода
        {
            if (readButton.Text == "Считать")
            {
                readButton.Text = "Прекратить";

                adress = adressComboBox.Text;

                ParameterizedThreadStart SendData = new ParameterizedThreadStart(sendData);

                th = new Thread(SendData);
                th.Start(adressComboBox.Text);
                
            }
            else
            {
                readButton.Text = "Считать";
                th.Abort();
                //th = null;
            }

        }

        private void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            saveData();
        }

        private void sendData(object adress)
        {
            while (readButton.Text == "Прекратить")
            {
                string temp_adress = adress as string;

                if (temp_adress.Contains("x")) temp_adress = temp_adress.Substring(temp_adress.IndexOf("x") + 1);

                string request = "1 3 " + temp_adress;

                comPort.Write(request);

                Thread.Sleep(frequancuRequest * 1000);
            }
        }

        private void saveData()
        { 
            string response = comPort.ReadExisting();  

            string[] partsResponse = response.Split(' '); 

            string result = DateTime.Now + "|| По адресу " + adress + " хранится: " + partsResponse[2];

            StreamWriter sw = new StreamWriter("Result.txt", true); //HTML можно в тупую через sw, добавлять строку перед сабстрокой </body>
            
            sw.WriteLine(result);

            sw.Close();

            SqlCommand sqlCommand = new SqlCommand($"INSERT INTO CollectorData (Request_time, SlaveID, Adress, Data) VALUES (@Request_time, @SlaveID, @Adress, @Data)", sqlConnection);

            sqlCommand.Parameters.AddWithValue("Request_time", DateTime.Now.ToString());
            sqlCommand.Parameters.AddWithValue("SlaveID", int.Parse(partsResponse[0]));
            sqlCommand.Parameters.AddWithValue("Adress", adress);
            sqlCommand.Parameters.AddWithValue("Data", int.Parse(partsResponse[2]));

            sqlCommand.ExecuteNonQuery();
        }

        private void Collector_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CollectorDB"].ConnectionString);

            sqlConnection.Open();
        }
    }
}
