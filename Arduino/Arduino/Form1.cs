using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace Arduino
{
    public partial class Form1 : Form
    {
        delegate void FuncaoRecepcao();
        public Form1()
        {
            InitializeComponent();

            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
        }

        void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            FuncaoRecepcao recepcaodelegate = new FuncaoRecepcao(RecepcaoSerial);
            Invoke(recepcaodelegate);
        }

        public void RecepcaoSerial()
        {
            txtRec.Text += serialPort1.ReadExisting();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            #region Config_ports
            String[] ValoresPort = SerialPort.GetPortNames();
            for (int i = 0; i < ValoresPort.Length; i++)
            {
                comboBox1.Items.Add(ValoresPort[i]);
            }

            comboBox1.Text = "Select";

            #endregion

            #region Config_Baud
            int[] ValoresBaud = { 2400, 4800, 9600, 19200, 38400, 57600 };
            for (int i = 0; i < ValoresBaud.Length; i++)
            {
                comboBox2.Items.Add(ValoresBaud[i].ToString());
            }

            comboBox2.Text = "9600";

            #endregion

            #region Config_Data

            comboBox3.Items.Add("7");
            comboBox3.Items.Add("8");
            comboBox3.Text = "8";

            #endregion

            #region Config_Stop
            comboBox4.Items.Add("None");
            comboBox4.Items.Add("One");
            comboBox4.Items.Add("Two");
            comboBox4.Text = "One";
            #endregion

            #region Config_Parity
            comboBox5.Items.Add("NONE");
            comboBox5.Items.Add("EVEN");
            comboBox5.Items.Add("OOO");
            comboBox5.Items.Add("MARK");
            comboBox5.Items.Add("SPACE");
            comboBox5.Text = "NONE";
            #endregion


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true) serialPort1.Close();

            else
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = int.Parse(comboBox2.Text);
                serialPort1.DataBits = int.Parse(comboBox3.Text);
                serialPort1.StopBits = (StopBits)(comboBox4.SelectedIndex);
                serialPort1.Parity = (Parity)(comboBox5.SelectedIndex);
             
            }

            try
            {
                serialPort1.Open();
                panel2.BackColor = Color.Green;
            }
            catch
            {
                MessageBox.Show("Erro ao Abrir a Porta");
                panel2.BackColor = Color.Gold;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRec.Text = null;
        }

        private void txtRec_TextChanged(object sender, EventArgs e)
        {

        }

    }
}