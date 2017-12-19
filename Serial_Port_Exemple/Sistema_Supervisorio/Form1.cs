using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Timers;
using System.Threading;

namespace Sistema_Supervisorio
{
    public partial class Form1 : Form
    {
        SerialPort PortaSerial = new SerialPort();
        System.Timers.Timer general_timer = new System.Timers.Timer(1000);
        public Form1()
        {
            InitializeComponent();
            general_timer.Elapsed += General_timer_Handler;
            general_timer.Start();
        }
        
        private void Form1_Load(object sender, EventArgs e)
            {
                Buscar_Porta_Serial();
            }

        public delegate void Delegate_void_NoPam();

        public void Buscar_Porta_Serial()
        {
            try
            {
                /* Testa se a porta serial está aberta 
                 * Se estiver, não é necessário atualizar a lista
                   de portas seriais
                 */
                if (!PortaSerial.IsOpen)
                {
                    /* Procura as COMs disponíveis no computador */
                    foreach (string str in SerialPort.GetPortNames())
                    {
                        /* Testa se a COM str já não está adicionada
                         * na lista
                         *  */
                        if (comboBox1.FindString(str) == -1)
                        {
                            /* Adiciona a COM str na lista */
                            comboBox1.Items.Add(str);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void General_timer_Handler(object sender, ElapsedEventArgs e)
        {
            if (!PortaSerial.IsOpen)
            {
                Invoke(new Delegate_void_NoPam(Buscar_Porta_Serial));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* switch para determinar ação a ser tomada */
            switch(button1.Text)
            {
                case "Abrir Porta":
                    if(PortaSerial.IsOpen)
                    {
                        PortaSerial.Close();
                    }
                    if((comboBox1.Text == "") || (comboBox2.Text == ""))
                    {
                        MessageBox.Show("Os campos de configuração não podem ser deixados em branco");
                        break;
                    }
                    try
                    {
                        /* Configuração da porta serial*/
                        PortaSerial.PortName = comboBox1.Text;
                        PortaSerial.BaudRate = int.Parse(comboBox2.Text);
                        PortaSerial.Parity = Parity.None;
                        PortaSerial.DataBits = 8;
                        PortaSerial.StopBits = StopBits.One;
                        PortaSerial.DataReceived += new SerialDataReceivedEventHandler(PortaSerial_DataReceivedHandler);

                        PortaSerial.Open();

                        button1.Text = "Fechar Porta";
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao abrir porta serial.");
                    }
                    break;

                case "Fechar Porta":
                    try
                    {
                        PortaSerial.Close();
                        button1.Text = "Abrir Porta";
                    }
                    catch{}
                    break;
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            /* As mensagens só podem ser enviadas se a porta serial estiver aberta
             * e se o campo de dados não estiver vazio            
             */
            if(PortaSerial.IsOpen && richTextBox2.Text != "")
            {   
                /* Os dados inseridos na caixa de texto
                 * serão enviados em ASCII
                 */
                PortaSerial.Write(richTextBox2.Text);
                richTextBox1.AppendText("TX: " + richTextBox2.Text + "\r\n");
                richTextBox2.Clear();
            }         
        }

        private void PortaSerial_DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort Serial = (SerialPort)sender;
            Thread.Sleep(20);
            int bytes = Serial.BytesToRead;
            byte[] recebido = new byte[bytes];
            Serial.Read(recebido, 0, bytes);
            BeginInvoke(new Delegate_void_String(Append_Text), new object[] { richTextBox1, "RX: " + BitConverter.ToString(recebido).Replace('-', ' ') + "\r\n" });
        }
        public delegate void Delegate_void_String(RichTextBox textbox, string text);
        public void Append_Text(RichTextBox textbox, string text)
        {
            textbox.AppendText(text);
            textbox.ScrollToCaret();
        }
    }

}
