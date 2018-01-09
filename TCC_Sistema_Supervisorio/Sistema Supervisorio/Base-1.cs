#define TEST

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.IO;
using LiveCharts; //Core of the library
using LiveCharts.Wpf; //The WPF controls
using LiveCharts.WinForms; //the WinForm wrappers


namespace Sistema_Supervisorio
{
    public partial class ControlSystem : Form
    {
        #region Variables
        class ClientContext
        {
            public TcpClient Client;
            public Stream Stream;
            public byte[] Buffer = new byte[4];
            public MemoryStream Message = new MemoryStream();
        }
        class ParametrosSenders
        {
            public ParametrosSenders(byte id)
            {
                Address = id;
                for (int i = 0; i < 256;  i++)
                {
                    Lista_Acelerometro.Add(new byte[6]);
                    Lista_STemp.Add(new byte[6]);
                }
            }
            IEnumerable<byte[]> capacity; 
            public byte Address;
            public List<byte[]> Lista_Acelerometro = new List<byte[]>(256);
            public List<byte[]> Lista_STemp = new List<byte[]>(256);
        }
        List<ParametrosSenders> Lista_Senders = new List<ParametrosSenders>(256);
        System.Timers.Timer general_timer = new System.Timers.Timer(1000);
        SerialPort serialport = new SerialPort();
        TcpListener servidorTCP;
        NetworkStream stream_data;
        byte[] s = { 0x01, 0x02 };
        
        byte flag_status_servidorTCP = 0x00;
        Protocolo Mensagem = new Protocolo();
        private BackgroundWorker bw_message;
        #endregion
        public ControlSystem()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized; // TODO
            general_timer.Elapsed += General_timer_Handler;
            this.bw_message = new BackgroundWorker();
            this.bw_message.DoWork += new DoWorkEventHandler(bw_message_DoWork);
            this.bw_message.ProgressChanged += new ProgressChangedEventHandler(bw_message_ProgressChanged);
            this.bw_message.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_message_RunWorkerCompleted);
            this.bw_message.WorkerReportsProgress = true;
            //ParametrosSenders a = new ParametrosSenders(0);
            //for (int i = 0; i < 256; i++)
            //{
            //    Lista_Senders.Add(ParametrosSenders a)
            //}
        }
        private void ControlSystem_Load(object sender, EventArgs e)
        {
            Find_IP();
            Update_COM();
            general_timer.AutoReset = true;
            general_timer.Start();
            gauge_Acelerometro_X.Uses360Mode = true;
            gauge_Acelerometro_X.From = 0;
            gauge_Acelerometro_X.To = 0xFFFF;
            gauge_Acelerometro_Y.Uses360Mode = true;
            gauge_Acelerometro_Y.From = 0;
            gauge_Acelerometro_Y.To = 0xFFFF;
            gauge_Acelerometro_Z.Uses360Mode = true;
            gauge_Acelerometro_Z.From = 0;
            gauge_Acelerometro_Z.To = 0xFFFF;
            gauge_STemp.Uses360Mode = true;
            gauge_STemp.From = -126;
            gauge_STemp.To = 125;
            //Add_ID();
            for(int i =0; i < 0xff; i++)
            {
                cartesian_STemp.Series.Add(new LineSeries
                {
                    Title = string.Format("Series {0}", (i+1).ToString())
                    LineSmoothness = 1, //straight lines, 1 really smooth lines
                    PointGeometry = System.Windows.Media.Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                    PointGeometrySize = 50,
                    PointForeground = System.Windows.Media.Brushes.Gray
                });
            }
        }
        #region BackgroundWorkers
        private void bw_message_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
           try
            {
                byte[] recebido = (byte[])e.Argument;
                Handle_Frame(recebido);
            }
            catch (Exception ex)
            {
                //buttonTeste.Enabled = true;
#if TESTE
                MessageBox.Show(string.Format("Erro buttonTeste_Click \r\n {0}", ex.ToString()));
#endif
            }

        }
        private void bw_message_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }
        private void bw_message_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //this.label1.Text = e.ProgressPercentage.ToString() + "% complete";
            string s = (string)e.UserState;
            switch (s)
            {
                case "oi":
                    //if (textNCartao.Text == "") { textNCartao.Text = "0"; }
                    //if (textNSerie.Text == "") { textNSerie.Text = "0"; }
                    break;
            }

        }

        #endregion
        #region Delegates functions
        /// <summary>
        /// Função Delegate genérica para funções void sem parâmetro
        /// </summary>
        public delegate void Delegate_void_NoPam();
        public delegate void Delegate_void_String(string color, string s);
        public delegate void Delegate_void_Serial_bytearray(byte[] msg);
        public delegate void Delegate_void_Handle_Array(byte[] array);
        public delegate void Delegate_Change_RichTextBox(RichTextBox textbox, Color cor, string texto);
        public delegate void Delegate_Button_Perform_Click(Button botao);
        #endregion
        public void Button_Perform_Click(Button botao)
        {
            botao.PerformClick();
        }
        private void Escreve_textLOG(string color, string str)
        {
            string data = string.Format("[{0}:{1}:{2}]", DateTime.Now.ToString("HH"), DateTime.Now.ToString("mm"), DateTime.Now.ToString("ss"));
            string string_aux;
            try
            {
                if (str == null) { return; }
                string_aux = string.Format("{0} : {1} \r\n", data, str);
                textLOG.AppendText(string_aux);
                textLOG.Select((textLOG.Text.Length - string_aux.Length), string_aux.Length);
                switch (color)
                {
                    case "vermelho":
                        textLOG.SelectionColor = Color.Red;
                        break;
                    case "azul":
                        textLOG.SelectionColor = Color.Blue;
                        break;
                    default:
                        textLOG.SelectionColor = Color.Black;
                        break;
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            textLOG.SelectionStart = textLOG.Text.Length;
            textLOG.ScrollToCaret();
            //Application.DoEvents();
        }
        private void General_timer_Handler(object sender, ElapsedEventArgs e)
        {
            if (!serialport.IsOpen)
            {  
                BeginInvoke(new Delegate_void_NoPam(Update_COM));
            }
            if(checkBox_Acelerometro_AutoUpdate.Checked)
            {
                BeginInvoke(new Delegate_Button_Perform_Click(Button_Perform_Click), new object []{ button_Acelerometro_Enviar });             
            }
        }
        private void Change_Change_RichTextBox(RichTextBox textbox, Color cor, string texto)
        {
            try
            {
                textbox.BackColor = cor;
                textbox.Text = texto;
            }
            catch
            { }
        }
        
        /// <summary>
        /// Função que buscar novas COM disponíves se não houver nenhuma já aberta
        /// </summary>
        private void Update_COM()
        {
            try
            {
                /* Testa se há COM aberta */
                if (!serialport.IsOpen)
                {
                    /* Procura as COMs disponíveis */
                    foreach (string str in SerialPort.GetPortNames())
                    {
                        /* Testa se a COM str já não está na lista */
                        if (com_port.FindString(str) == -1)
                        {
                            /* Adiciona a COM str na lista */
                            com_port.Items.Add(str);
                        }
                    }
                    /* Se alguma COM foi encontrada, seleciona a primeira da lista */
                    if (com_port.Items.Count > 0)
                    {
                        com_port.SelectedIndex = 0;
                        com_baud.SelectedIndex = 1;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }          
        }
        
        private void button_com_Click(object sender, EventArgs e)
        {
            /* Testa se o botão deve abrir ou fechar a porta*/
            switch(button_com.Text)
            {
                case "Abrir Porta":
                    /* Testa se a com está aberta */
                    if(serialport.IsOpen)
                    {
                        serialport.Close(); 
                    }
                    try
                    {
                        if(com_port.Text == "" || com_baud.Text == "")
                        {
                            MessageBox.Show("A porta não pode ser iniciada com parâmetros em branco.", "Atenção");
                            return;
                        }
                        /* Configura a COM conforme as configurações inseridas na tela inicial */
                        #region Configuração de Porta
                        serialport.PortName = com_port.Text;
                        serialport.BaudRate = int.Parse(com_baud.Text);
                        serialport.Parity = Parity.None;
                        serialport.DataBits = 8;
                        serialport.StopBits = StopBits.One;
                        serialport.DataReceived += new SerialDataReceivedEventHandler(Serialport_DataReceived);
                        #endregion
                        /* Abre a comunicação */                                                                      
                        serialport.Open();
                        /* Testa se a porta for aberta, e realiza as configurações se estiver ok */
                        if(serialport.IsOpen)
                        {
                            if(!textLOG.Enabled)
                            {
                                textLOG.Enabled = true;
                            }
                            Invoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", string.Format("Porta Aberta. {0}. Baudrate: {1}", com_port.Text, com_baud.Text) });
                            //Invoke(new Delegate_void_Serial_bytearray(Enviar_Serial), new object[] {Mensagem.Ler_Acelerometro(0x02, 0x55, 0x00)});
                            button_com.Text = "Fechar Porta";
                        }      
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    break;

                case "Fechar Porta":
                    /* Testa se a com está aberta */
                    if(serialport.IsOpen)
                    {
                        try
                        {
                            serialport.Close();
                            if(!serialport.IsOpen)
                            {
                                button_com.Text = "Abrir Porta";
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    break;
            }
        }

        private void Serialport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort Serial = (SerialPort)sender;
            Thread.Sleep(50);
            int bytes = Serial.BytesToRead;
            byte[] recebido = new byte[bytes];  
            Serial.Read(recebido, 0, bytes);
            if (recebido == null || recebido.Length == 0) { }
            else
            {
                if (!this.bw_message.IsBusy)
                {
                    this.bw_message.RunWorkerAsync(recebido);
                }
            }
        }

        private void Enviar_Serial(byte[] msg)
        {
            try
            {
                if (serialport.IsOpen)
                {
                    serialport.Write(msg, 0, msg.Length);
                    BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", string.Format("TX: {0}", BitConverter.ToString(msg).Replace('-', ' ')) });
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Find_IP()
        {
            try
            {
                #region Get External IP
                /* string externalip = new WebClient().DownloadString("http://icanhazip.com");
               externalip = new System.Net.WebClient().DownloadString("http://bot.whatismyipaddress.com");
               externalip = new System.Net.WebClient().DownloadString("http://ipinfo.io/ip");
               externalip = externalip.Trim();
               textIP.Text = externalip;    */
                #endregion
                #region Get IPV4
                string IP4Address = String.Empty;

                foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
                {
                    if (IPA.AddressFamily == AddressFamily.InterNetwork)
                    {
                        IP4Address = IPA.ToString();
                        break;
                    }
                }
#if (!TESTE)
               tcp_ip.Text = IP4Address;
               tcp_port.Text = "5001";
#else
                tcp_ip.Text = "127.0.0.1";
                tcp_port.Text = "4000";
#endif
                #endregion
            }
            catch { }
        }

        private void button_tcp_Click(object sender, EventArgs e)
        {
            try
            {   switch(button_tcp.Text)
                {
                    case "Abrir Servidor":
                        if (tcp_ip.Text == "" || tcp_port.Text == "")
                        {
                            MessageBox.Show("O servidor TCP/IP não pode ser iniciado com parâmetros em branco.", "Atenção");
                            return;
                        }
                        if (flag_status_servidorTCP == 0x00)
                        {
                            servidorTCP = new TcpListener(IPAddress.Parse(tcp_ip.Text), Int32.Parse(tcp_port.Text));
                            servidorTCP.Start();

                            servidorTCP.BeginAcceptTcpClient(OnClientAccepted, servidorTCP);

                            flag_status_servidorTCP = 0x01;
                            button_tcp.Text = "Fechar Servidor";
                        }
                        break;

                    default:
                        flag_status_servidorTCP = 0x00;
                        servidorTCP.Stop();

                        button_tcp.Text = "Abrir Servidor";
                        break;
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl.SelectedIndex == 1)
            {

                WindowState = FormWindowState.Maximized; // TODO
            }
        }

        static void OnClientAccepted(IAsyncResult ar)
        {
            TcpListener listener = ar.AsyncState as TcpListener;
            if (listener == null)
                return;

            try
            {
                ClientContext context = new ClientContext();
                context.Client = listener.EndAcceptTcpClient(ar);
                context.Stream = context.Client.GetStream();
                context.Stream.BeginRead(context.Buffer, 0, context.Buffer.Length, OnClientRead, context);  
            }
            finally
            {
                listener.BeginAcceptTcpClient(OnClientAccepted, listener);
            }
        }

        static void OnClientRead(IAsyncResult ar)
        {
            ClientContext context = ar.AsyncState as ClientContext;
            if (context == null)
                return;

            try
            {
                int read = context.Stream.EndRead(ar);
                context.Message.Write(context.Buffer, 0, read);

                string length = Encoding.ASCII.GetString(context.Buffer, 0, read);
                byte[] buffer = new byte[1024];
                //while (length > 0)
                //{
                //    read = context.Stream.Read(buffer, 0, Math.Min(buffer.Length, length));
                //    context.Message.Write(buffer, 0, read);
                //    length -= read;
                //}

                OnMessageReceived(context);
            }
            catch (System.Exception)
            {
                context.Client.Close();
                context.Stream.Dispose();
                context.Message.Dispose();
                context = null;
            }
            finally
            {
                if (context != null)
                    context.Stream.BeginRead(context.Buffer, 0, context.Buffer.Length, OnClientRead, context);
            }
        }

        static void OnMessageReceived(ClientContext context)
        {
            // process the message here
            var x = context.Buffer[0];
        }
        #region Tratamento de Dados
        void Handle_Frame(byte[] received_frame)
        {
            byte[] aux = new byte[received_frame.Length];
            byte[] byte_aux;
            // Realiza uma cópia do frame recebido para não perder o original
            Array.Copy(received_frame, aux, aux.Length);

            // se o frame não for válido, ele não será manipulado
            if (!Mensagem.Frame_validation(aux))
            {
                //Escrever no log que a mensagem está errada
                Invoke(new Delegate_void_String(Escreve_textLOG), new object[] { "vermelho", "Mensagem inválida."});
                Invoke(new Delegate_void_String(Escreve_textLOG), new object[] { "vermelho", BitConverter.ToString(aux).Replace('-', ' ')});
                return;
            }

            // Retirar os escape bytes da mensagem para poder manipular. Sempre utilizar o vetor aux para não alterar a mensagem original
            Mensagem.Escape_Bytes(ref aux, 0x01);

            // Testar se o receptor é o Servidor. Se não for, encaminhar para destinatário.
            if(aux[2] != Mensagem.Lista_Enderecos[0])
            {
                // Escrever no log que o destinatário é outro
                Invoke(new Delegate_void_String(Escreve_textLOG), new object[] { "vermelho", "Mensagem recebida é endereçada a outro destinatário."});
                // Testar se o destinatário está cadastrado na lista
                if (Mensagem.Lista_Enderecos.Contains(aux[2]))
                {
                    // TODO -> encaminhar received frame para destinatário correto
                    //Invoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", "A mensagem será encaminhada para o destinatário correto."});
                    // TODO -> Enviar ACK e encaminhar
                }
                // se não estiver cadastrado, enviar NACK + CRC para remetente
                else
                {
                    Invoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", "Destinatário não está cadastrado." });
                    // TODO -> enviar NACK
                }
                return;
            }
            
            switch(aux[4])
            {
                case 0x01: // Acelerometro
                    byte_aux = new byte[aux.Length - 4];
                    Array.Copy(aux, 1, byte_aux, 0, byte_aux.Length);
                    Invoke(new Delegate_void_Handle_Array(Handle_Acelerometro), new object[] { byte_aux });
                    //Invoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", "Mensagem de acelerômetro" });
                    break;
                case 0x02: // Sensor de Temperatura
                    byte_aux = new byte[aux.Length - 4];
                    Array.Copy(aux, 1, byte_aux, 0, byte_aux.Length);
                    Invoke(new Delegate_void_Handle_Array(Handle_SensorTemperatura), new object[] { byte_aux });
                    break;
                case 0x03: // SensorTemperatura 
                    break;
                case 0x04: // SensorCorrente       
                    break;
                case 0x05: // SensorUltrassonico    
                    break;
                case 0x06: // Magnetometro       
                    break;
            }
        }
        /// <summary>
        /// Trata os dados da mensagem de acelerometro recebida, no array deve conter desdo SND até o fim dos dados
        /// </summary>
        /// <param name="array"></param>
        void Handle_Acelerometro(byte[] array)
        {
            string aux;
            if(array.Length <= 0) { return; }
            text_TX_ID_Acelerometro.Text = array[0].ToString();
            text_ID_Acelerometro.Text = array[4].ToString();
            gauge_Acelerometro_X.Value = ((array[5] << 8) | array[6]);
            gauge_Acelerometro_Y.Value = ((array[7] << 8) | array[8]);
            gauge_Acelerometro_Z.Value = ((array[9] << 8) | array[10]);
            aux = string.Format("Mensagem recebida de acelerômetro \r\n ID do transmissor: {0}\r\n ID do sensor: {1}\r\n Eixo X: {2}\r\n Eixo Y: {3}\r\n Eixo Z: {4}",
                array[0].ToString(), array[4].ToString(),((array[5] << 8) | array[6]).ToString(), ((array[7] << 8) | array[8]).ToString(), ((array[9] << 8) | array[10]));
            Invoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", aux });
            //TODO mudar endereços para o valor recebido, usar array[x]
            //Lista_Senders[array[0]].Lista_Acelerometro[0] = new byte[6];
            //Array.Copy(dados, Lista_Senders[array[0]].Lista_Acelerometro[0], Lista_Senders[array[0]].Lista_Acelerometro[0].Length);
        }

        void Handle_SensorTemperatura(byte[] array)
        {
            string aux;      
            if (array.Length <= 0) { return; }
            text_TX_ID_STemp.Text = array[0].ToString();
            text_ID_STemp.Text = array[4].ToString();
            gauge_STemp.Value = (float)array[5];
            cartesian_STemp.Series[array[4]].Values.Add(array[5]);
        }
        #endregion

        private void button_Acelerometro_Enviar_Click(object sender, EventArgs e)
        {
            string str_aux;
            uint byte_aux;
            if((text_Acelerometro_ID.Text == "") || (combo_Acelerometro_Eixo.SelectedIndex == -1) || (text_Acelerometro_ID_Sensor.Text == ""))
            {
                Invoke(new Delegate_Change_RichTextBox(Change_Change_RichTextBox), new object[] { text_Acelerometro_Status, Color.Red, "Erro" });
                MessageBox.Show("Os campos não podem ser deixados em branco.", "Erro");
                return;
            }
            if(int.Parse(text_Acelerometro_ID.Text) > 255)
            {
                Invoke(new Delegate_Change_RichTextBox(Change_Change_RichTextBox), new object[] { text_Acelerometro_Status, Color.Red, "Erro" });
                MessageBox.Show("O valor de ID não pode ser maior que 255.", "Erro");
                return;
            }
            byte_aux = (byte)int.Parse(text_Acelerometro_ID.Text);
            Invoke(new Delegate_void_Serial_bytearray(Enviar_Serial), new object[] { Mensagem.Ler_Acelerometro((byte)int.Parse(text_Acelerometro_ID.Text), (byte)int.Parse(text_Acelerometro_ID_Sensor.Text), (byte)combo_Acelerometro_Eixo.SelectedIndex) });
            Invoke(new Delegate_Change_RichTextBox(Change_Change_RichTextBox), new object[] { text_Acelerometro_Status, Color.Green, "Enviado" });
        }

        private void button_STemp_Enviar_Click(object sender, EventArgs e)
        {
           /* if((combo_STemp_ID.SelectedIndex == -1) || (text_STemp_ID.Text == ""))
            {
                Invoke(new Delegate_Change_RichTextBox(Change_Change_RichTextBox), new object[] { text_Acelerometro_Status, Color.Red, "Erro" });
                MessageBox.Show("Os campos não podem ser deixados em branco.", "Erro");
                return;
            }
            if(int.Parse(combo_STemp_ID.Text) > 0xff)
            {
                Invoke(new Delegate_Change_RichTextBox(Change_Change_RichTextBox), new object[] { text_Acelerometro_Status, Color.Red, "Erro" });
                MessageBox.Show("O valor de ID não pode ser maior que 255.", "Erro");
                return;

            }
            Invoke(new Delegate_void_Serial_bytearray(Enviar_Serial), new object[] { Mensagem.Ler_Temperatura(byte.Parse(combo_STemp_ID.Text), byte.Parse(text_STemp_ID.Text)) });
            Invoke(new Delegate_Change_RichTextBox(Change_Change_RichTextBox), new object[] { text_STemp_Status, Color.Green, "Enviado" });
        */}

        
    }
    public class Protocolo
    {   /*SOF - SND - RCP - DSZ - CMD - PRTMT1 - PRTMT2 - PRMTn - CRCmsb - CRClsb - EOF*/
        public Protocolo()
        {
            Lista_Enderecos.Add(SCADA);
        }
        #region Constantes do Protocolo
        private byte SOF = 0x01;
        public List<byte> Lista_Enderecos = new List<byte>();
        private byte EOF = 0x04;
        private byte ESCAPE = 0x10;
        public const byte SCADA = 0x00;
        #endregion
        
        #region Sensores
        public const byte Acelerometro = 0x01;
        public const byte SensorTemperatura = 0x02;
        public const byte SensorCorrente = 0x03;
        public const byte SensorUltrassonico = 0x04;
        public const byte Magnetometro = 0x05;
        #endregion

        #region Functions para frames
        ulong CRC_Calc(byte[] msg)
        { //calcula o CRC do frame, e retorna valor de 16b
            ushort newchar;
            int test;
            int crcword;
            crcword = 0xffff;

            //int i = 1;
            for (int i = 1; i < (msg.Length - 3); i++)
            {
                newchar = msg[i];
                for (int j = 0; j < 8; j++)
                {
                    test = (ushort)(newchar & 0x00FF);
                    test = (ushort)(test << (j + 8));
                    test = (ushort)(test ^ crcword);
                    test = (ushort)(test & 0x8000);

                    if (test != 0)
                    {
                        crcword = (ushort)(crcword << 1);
                        crcword = (ushort)(crcword ^ 0x1021);
                    }
                    else
                    {
                        crcword = (ushort)(crcword << 1);
                    }
                }
            }
            return (ushort)crcword;
        }
        /// <summary>
        /// Valida o frame passado. São comparados os valores de SOF e EOF, retirados os Escape Bytes e calculado o CRC. O frame passado não é alterado, é utilizada uma cópia interna.
        /// </summary>
        /// <param name="msg">Vetor de bytes a ser validado</param>
        /// <returns>Retorna se o frame é válido ou não (bool).</returns>
        public bool Frame_validation(byte[] msg)
        {
            byte[] aux = new byte[msg.Length];
            Array.Copy(msg, aux, aux.Length);
            ulong crc;
            if ((aux[0] != SOF) || (aux[msg.Length-1] != EOF))
            {
                return false;
            }

            Escape_Bytes(ref aux, 0x01);

            crc = (ulong)((aux[aux.Length - 3] << 8) | (aux[aux.Length - 2]));
            if(crc == 0)
            {
                return true;
            }
            if(crc != CRC_Calc(aux))
            {
                return false;
            } 
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg">Vetor de bytes no qual se deseja adicionar ou retirar bytes de escape.</param>
        /// <param name="tipo">Utilizar 0x00 para adicionar os bytes de escape em msg. Utilizar 0x01 para retirar os bytes de escape de msg.</param>
        /// <returns></returns>
        public void Escape_Bytes(ref byte[] msg, byte tipo)
        {
            int cnt_escape = 0;
            byte[] aux;
            switch(tipo)
            {
                case 0x00:
                    for (int i = 1; i < msg.Length - 1; i++)
                    {
                        if ((msg[i] == SOF) || (msg[i] == ESCAPE) || (msg[i] == EOF))
                        { cnt_escape++; }
                    }

                    aux = new byte[msg.Length + cnt_escape];

                    aux[0] = msg[0];

                    for (int i = 1, j = 1; i < msg.Length - 1; i++)
                    {
                        if ((msg[i] == SOF) || (msg[i] == ESCAPE) || (msg[i] == EOF))
                        {
                            aux[j++] = 0x10;
                            aux[j++] = (byte)(msg[i] + 0x20);
                        }
                        else
                        {
                            aux[j++] = msg[i];
                        }
                    }

                    aux[aux.Length - 1] = msg[msg.Length - 1];
                    msg = new byte[aux.Length];
                    Array.Copy(aux, msg, msg.Length);

                    break;

                case 0x01:
                    for (int i = 1; i < msg.Length - 1; i++)
                    {
                        if ((msg[i] == ESCAPE))
                        { cnt_escape++; }
                    }

                    aux = new byte[msg.Length - cnt_escape];

                    aux[0] = msg[0];

                    for (int i = 1, j = 1; i < msg.Length - 1; i++)
                    {
                        if ((msg[i] == ESCAPE))
                        {
                            aux[j++] = (byte)(msg[++i] - 0x20);
                        }
                        else
                        {
                            aux[j++] = msg[i];
                        }
                    }

                    aux[aux.Length - 1] = msg[msg.Length - 1];
                    msg = new byte[aux.Length];
                    Array.Copy(aux, msg, msg.Length);

                    break;
            }
            

        }

        byte[] Montar_Frame(byte receptor, byte[] cmd)
        {
            byte[] rtrn = new byte[8 + cmd.Length];
            ulong crc_calc;
            rtrn[0] = SOF;
            rtrn[1] = (byte)Lista_Enderecos[0];
            rtrn[2] = receptor;
            rtrn[3] = (byte)(((cmd.Length-1) >> 8) & 0xFF);
            rtrn[4] = (byte)(((cmd.Length-1) >> 0) & 0xFF);
            Array.Copy(cmd, 0, rtrn, 5, cmd.Length);
            crc_calc = CRC_Calc(rtrn);
            rtrn[rtrn.Length - 3] = (byte)((crc_calc >> 8) & 0xFF);
            rtrn[rtrn.Length - 2] = (byte)(crc_calc & 0xFF);
            rtrn[rtrn.Length - 1] = EOF;
            Escape_Bytes(ref rtrn, 0x00);
            return rtrn;
        }
        #endregion

        #region Funções
        /// <summary>
        /// Envia comando requisitando leitura de um acelerômetro
        /// </summary>
        /// <param name="RCP">Endereço do receptor</param>
        /// <param name="ID">Número de ID do acelerômetro</param>
        /// <param name="Eixo">Eixo que deve ser retornado valor. 0x00 - Todos. 0x01 - Eixo X. 0x02 - Eixo Y. 0x03 - Eixo Z.</param>
        /// <returns></returns>
        public byte[] Ler_Acelerometro(byte RCP, byte ID, byte Eixo)
        {
            byte[] CMD = { Acelerometro, ID, Eixo };
            return Montar_Frame(RCP, CMD);   
        }
        //public byte[] Ler_TempMicro(byte RCP, byte ID)
        //{
        //    byte[] CMD = { SensorTempMicro, ID };
        //    return Montar_Frame(RCP, CMD);
        //}
        public byte[] Ler_Temperatura(byte RCP, byte ID)
        {
            byte[] CMD = { SensorTemperatura, ID };
            return Montar_Frame(RCP, CMD);
        }
        public byte[] Ler_SensorCorrente(byte RCP, byte ID)
        {
            byte[] CMD = { SensorCorrente, ID };
            return Montar_Frame(RCP, CMD);
        }
        #endregion
    }    
}
