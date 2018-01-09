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
using LiveCharts.Configurations;
using LiveCharts; //Core of the library
using LiveCharts.Wpf; //The WPF controls
using LiveCharts.WinForms; //the WinForm wrappers
using System.Collections;
using OfficeOpenXml;

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
                for (int i = 0; i < 256; i++)
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
        System.Timers.Timer general_timer = new System.Timers.Timer(5000);
        SerialPort serialport = new SerialPort();
        static TcpListener servidorTCP = null;    
        NetworkStream stream_data;
        byte[] s = { 0x01, 0x02 };
        List<byte> ListaID_Temperatura = new List<byte>(256);
        List<byte> ListaID_Corrente = new List<byte>(256);
        List<byte> ListaID_TX = new List<byte>(256);
        byte flag_status_servidorTCP = 0x00;
        Protocolo Mensagem = new Protocolo();
        private BackgroundWorker bw_message;
        static private BackgroundWorker bw_message_TCP1;
        static private BackgroundWorker bw_message_TCP2;
        static private BackgroundWorker bw_message_TCP3;
        private BackgroundWorker bw_table;
        FileInfo TabelaExcel;
        String FolderPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
        string[] FilesOnFolder;
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

            bw_message_TCP1 = new BackgroundWorker();
            bw_message_TCP1.DoWork += new DoWorkEventHandler(bw_message_DoWork);

            bw_message_TCP2 = new BackgroundWorker();
            bw_message_TCP2.DoWork += new DoWorkEventHandler(bw_message_DoWork);

            bw_message_TCP3 = new BackgroundWorker();
            bw_message_TCP3.DoWork += new DoWorkEventHandler(bw_message_DoWork);


            this.bw_table = new BackgroundWorker();
            this.bw_table.DoWork += new DoWorkEventHandler(bw_table_DoWork);      
        }

        private void bw_table_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            try
            {
                byte[] recebido = (byte[])e.Argument;
                Handle_Table(recebido);
            }
            catch (Exception ex)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void ControlSystem_Load(object sender, EventArgs e)
        {
            Find_IP();
            Update_COM();
            general_timer.AutoReset = true;
            general_timer.Start();
            gauge_Acelerometro_X.Uses360Mode = true;
            gauge_Acelerometro_Y.Uses360Mode = true;
            gauge_Acelerometro_Z.Uses360Mode = true;

            combo_Acelerometro_mode.SelectedIndex = 0;
            cartesian_STemp.LegendLocation = LegendLocation.Right;
            cartesian_STemp.DataClick += CartesianChart1OnDataClick;

            combo_Acelerometro_Eixo.SelectedIndex = 0;
            combo_Acelerometro_mode.SelectedIndex = 0;
            combo_Analogico.SelectedIndex = 0;
            combo_GPIO.SelectedIndex = 0;
            combo_RTC.SelectedIndex = 0;
            //var dayConfig = Mappers.Xy<DateModel>()   
            //    .X(dayModel => (double)(dayModel.Hora));
            //    .Y(dayModel => dayModel.Value);
            //cartesian_STemp.Series = new SeriesCollection(dayConfig);
            //cartesianChart1.AxisX.Add(new Axis
            //{
            //    LabelFormatter = value => new System.DateTime((long)(value * TimeSpan.FromHours(1).Ticks)).ToString("t")
            //});
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }
        #region BackgroundWorkers
        private void bw_message_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            try
            {
                byte[] recebido = (byte[])e.Argument;

                Handle_Big_Frame(recebido);
            }
            catch (Exception ex)
            {
                //buttonTeste.Enabled = true;
#if TESTE
                MessageBox.Show(string.Format("Erro buttonTeste_Click \r\n {0}", ex.ToString()));
#endif
            }

        }
        public void Handle_Big_Frame(byte[] vetor)
        {
            int i, j, k;
            byte[] aux;
            for(i = 0; i < vetor.Length; i++)
            {
                if(vetor[i] == 0x01)
                {
                    for(j = i; j < vetor.Length; j++)
                    {
                        if(vetor[j] == 0x04)
                        {
                            aux = new byte[(j - i) + 1];
                            Array.Copy(vetor, i, aux, 0, aux.Length);
                            Handle_Frame(vetor);
                            i = j + 1;
                            break;
                        }
                    }
                }
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
            string data = string.Format("[{0}/{1}/{2} - {3}:{4}:{5}]", DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yy"), DateTime.Now.ToString("HH"), DateTime.Now.ToString("mm"), DateTime.Now.ToString("ss"));
            string string_aux;
            try
            {
                if (str == null) { return; }
                string_aux = string.Format("{0} : {1} \r\n\n", data, str);
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
                    //if (com_port.Items.Count > 0)
                    //{
                    //    com_port.SelectedIndex = 0;
                    //    com_baud.SelectedIndex = 1;
                    //}
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
            switch (button_com.Text)
            {
                case "Abrir Porta":
                    /* Testa se a com está aberta */
                    if (serialport.IsOpen)
                    {
                        serialport.Close();
                    }
                    try
                    {
                        if (com_port.Text == "" || com_baud.Text == "")
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
                        if (serialport.IsOpen)
                        {
                            if (!textLOG.Enabled)
                            {
                                textLOG.Enabled = true;
                            }
                            BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", string.Format("Porta Aberta. {0}. Baudrate: {1}", com_port.Text, com_baud.Text) });
                            //BeginInvoke(new Delegate_void_Serial_bytearray(Enviar_Serial), new object[] {Mensagem.Ler_Acelerometro(0x02, 0x55, 0x00)});
                            button_com.Text = "Fechar Porta";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    break;

                case "Fechar Porta":
                    /* Testa se a com está aberta */

                    try
                    {
                        serialport.Close();
                        if (!serialport.IsOpen)
                        {
                            button_com.Text = "Abrir Porta";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    break;
            }
        }

        private void Serialport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
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
            catch { }

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
                tcp_port.Text = "5001";
#endif
                #endregion
            }
            catch { }
        }

        private void button_tcp_Click(object sender, EventArgs e)
        {
            try
            {
                switch (button_tcp.Text)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {

                WindowState = FormWindowState.Maximized; // TODO
            }
        }

        static void OnClientAccepted(IAsyncResult ar)
        {
            TcpListener listener = ar.AsyncState as TcpListener;
            servidorTCP = listener;
            if (listener == null)
                return;

            try
            {
               TcpClient clientTCP = listener.EndAcceptTcpClient(ar);
                NetworkStream stream = clientTCP.GetStream();
                byte[] buffer = new byte[100];
                stream.BeginRead(buffer, 0, buffer.Length, OnClientRead, clientTCP);
            }
            finally
            {
                listener.BeginAcceptTcpClient(OnClientAccepted, listener);
            }
        }

        static void OnClientRead(IAsyncResult ar)
        {
            TcpClient client = ar.AsyncState as TcpClient;
            byte[] bytes = new byte[100];
            NetworkStream stream = client.GetStream();
            //long size = stream.Length;
            int i;
            bool dataAvailable = false;
            // Loop to receive all the data sent by the client.
            
            OnMessageReceived(bytes);
            while (true)
            {
                if (!dataAvailable)
                {
                    dataAvailable = stream.DataAvailable;
                    //Console.WriteLine("Data Available: "+dataAvailable);
                    if (servidorTCP.Pending())
                    {
                        Console.WriteLine("found new client");
                        break;
                    }
                }

                if (dataAvailable)
                {
                    i = stream.Read(bytes, 0, bytes.Length);//) != 0)
                    OnMessageReceived(bytes);
                    dataAvailable = false;
                }

                if (servidorTCP.Pending())
                {
                    Console.WriteLine("found new client");
                    break;
                }
            }

            Console.WriteLine("Client close");
            // Shutdown and end connection
            client.Close();
        }
    

        static void OnMessageReceived(byte[] recebido)
        {
            // process the message here
            if (recebido == null || recebido.Length == 0) { }
            else
            {
                try
                {
                    if (!bw_message_TCP1.IsBusy)
                    {
                        bw_message_TCP1.RunWorkerAsync(recebido);
                    }
                    else if (!bw_message_TCP2.IsBusy)
                    {
                        bw_message_TCP2.RunWorkerAsync(recebido);
                    }
                    else if (!bw_message_TCP3.IsBusy)
                    {
                        bw_message_TCP3.RunWorkerAsync(recebido);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        #region Tratamento de Dados
        void Handle_Frame(byte[] received_frame)
        {
            byte[] aux = new byte[received_frame.Length];
            byte[] byte_aux;
            string s;
            // Realiza uma cópia do frame recebido para não perder o original
            Array.Copy(received_frame, aux, aux.Length);

            // se o frame não for válido, ele não será manipulado
            // já retira os bytes de escape dentro da função
            if (!Mensagem.Frame_validation(ref aux))
            {
                //Escrever no log que a mensagem está errada
                BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "vermelho", "Mensagem inválida." });
                s = BitConverter.ToString(aux).Replace('-', ' ');
                BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "vermelho", BitConverter.ToString(aux).Replace('-', ' ') });
                return;
            }



            // Testar se o receptor é o Servidor. Se não for, encaminhar para destinatário.
            if (aux[2] != Mensagem.Lista_Enderecos[0])
            {
                // Escrever no log que o destinatário é outro
                BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "vermelho", "Mensagem recebida é endereçada a outro destinatário." });
                // Testar se o destinatário está cadastrado na lista
                if (Mensagem.Lista_Enderecos.Contains(aux[2]))
                {
                    // TODO -> encaminhar received frame para destinatário correto
                    //BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", "A mensagem será encaminhada para o destinatário correto."});
                    // TODO -> Enviar ACK e encaminhar
                }
                // se não estiver cadastrado, enviar NACK + CRC para remetente
                else
                {
                    BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", "Destinatário não está cadastrado." });
                    // TODO -> enviar NACK
                }
                return;
            }
            //this.bw_table.RunWorkerAsync(aux);
            switch (aux[4])
            {
                case 0x01: // Acelerometro
                    byte_aux = new byte[aux.Length - 4];
                    Array.Copy(aux, 1, byte_aux, 0, byte_aux.Length);
                    BeginInvoke(new Delegate_void_Handle_Array(Handle_Acelerometro), new object[] { byte_aux });
                    //BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", "Mensagem de acelerômetro" });
                    break;
                case 0x02: // Sensor de Temperatura
                    byte_aux = new byte[aux.Length - 4];
                    Array.Copy(aux, 1, byte_aux, 0, byte_aux.Length);
                    BeginInvoke(new Delegate_void_Handle_Array(Handle_SensorTemperatura), new object[] { byte_aux });
                    break;
                case 0x03: // Sensor de Corrente     
                    byte_aux = new byte[aux.Length - 4];
                    Array.Copy(aux, 1, byte_aux, 0, byte_aux.Length);
                    BeginInvoke(new Delegate_void_Handle_Array(Handle_SensorCorrente), new object[] { byte_aux });
                    break;
                case 0x04: // Sensor Ultrassônico     
                    byte_aux = new byte[aux.Length - 4];
                    Array.Copy(aux, 1, byte_aux, 0, byte_aux.Length);
                    BeginInvoke(new Delegate_void_Handle_Array(Handle_SensorUltrassonico), new object[] { byte_aux });
                    break;
                case 0x05: // Magnetômetro          
                    byte_aux = new byte[aux.Length - 4];
                    Array.Copy(aux, 1, byte_aux, 0, byte_aux.Length);
                    BeginInvoke(new Delegate_void_Handle_Array(Handle_Magnetometro), new object[] { byte_aux });
                    break;

                case 0x06: // RTC                 
                    byte_aux = new byte[aux.Length - 4];
                    Array.Copy(aux, 1, byte_aux, 0, byte_aux.Length);
                    BeginInvoke(new Delegate_void_Handle_Array(Handle_RTC), new object[] { byte_aux });
                    break;

                case 0x07: // Porta Digital           
                    byte_aux = new byte[aux.Length - 4];
                    Array.Copy(aux, 1, byte_aux, 0, byte_aux.Length);
                    BeginInvoke(new Delegate_void_Handle_Array(Handle_PortaDigital), new object[] { byte_aux });
                    break;

                case 0x08: // Porta Analógica        
                    byte_aux = new byte[aux.Length - 4];
                    Array.Copy(aux, 1, byte_aux, 0, byte_aux.Length);
                    BeginInvoke(new Delegate_void_Handle_Array(Handle_PortaAnalogica), new object[] { byte_aux });
                    break;
            }
        }

        void Handle_Table(byte[] received_frame)
        {
            if (received_frame.Length <= 0) { return; }
            byte ID = received_frame[1];
            string ID_str = ID.ToString();

            if (!ListaID_TX.Contains(ID))
            {
                #region Criar Tabela
                ListaID_TX.Add(ID);
                FilesOnFolder = Directory.GetFiles(FolderPath);
                TabelaExcel = new FileInfo(FolderPath + string.Format("\\Leitura de Sensores ID {0}.xlsx", ID_str));
                using (var package = new ExcelPackage(TabelaExcel))
                {
                    ExcelWorkbook workBook = package.Workbook;
                    ExcelWorksheet currentWorksheet1 = null;
                    ExcelWorksheet currentWorksheet2 = null;
                    ExcelWorksheet currentWorksheet3 = null;
                    ExcelWorksheet currentWorksheet4 = null;
                    ExcelWorksheet currentWorksheet5 = null;
                    ExcelWorksheet currentWorksheet6 = null;
                    ExcelWorksheet currentWorksheet7 = null;
                    ExcelWorksheet currentWorksheet8 = null;
                    workBook.Worksheets.Add("Acelerômetro");
                    package.Workbook.Worksheets.Add("Temperatura");
                    package.Workbook.Worksheets.Add("Corrente");
                    package.Workbook.Worksheets.Add("Ultrassônico");
                    package.Workbook.Worksheets.Add("Magnetômetro");
                    package.Workbook.Worksheets.Add("RTC");
                    package.Workbook.Worksheets.Add("Portas Digitais");
                    package.Workbook.Worksheets.Add("Portas Analógicas");
                    currentWorksheet1 = workBook.Worksheets.SingleOrDefault(w => w.Name == "Acelerômetro");
                    currentWorksheet2 = workBook.Worksheets.SingleOrDefault(w => w.Name == "Temperatura");
                    currentWorksheet3 = workBook.Worksheets.SingleOrDefault(w => w.Name == "Corrente");
                    currentWorksheet4 = workBook.Worksheets.SingleOrDefault(w => w.Name == "Ultrassônico");
                    currentWorksheet5 = workBook.Worksheets.SingleOrDefault(w => w.Name == "Magnetômetro");
                    currentWorksheet6 = workBook.Worksheets.SingleOrDefault(w => w.Name == "RTC");
                    currentWorksheet7 = workBook.Worksheets.SingleOrDefault(w => w.Name == "Portas Digitais");
                    currentWorksheet8 = workBook.Worksheets.SingleOrDefault(w => w.Name == "Portas Analógicas");
                    for (int i = 0; i < 256; i++)
                    {
                        currentWorksheet1.Cells[1, 1 + (6 * i)].Value = "Data";
                        currentWorksheet1.Cells[1, 2 + (6 * i)].Value = "Hora";
                        currentWorksheet1.Cells[1, 3 + (6 * i)].Value = "ID do Sensor";
                        currentWorksheet1.Cells[1, 4 + (6 * i)].Value = "Eixo X";
                        currentWorksheet1.Cells[1, 5 + (6 * i)].Value = "Eixo Y";
                        currentWorksheet1.Cells[1, 6 + (6 * i)].Value = "Eixo Z";

                        currentWorksheet2.Cells[1, 1 + (4 * i)].Value = "Data";
                        currentWorksheet2.Cells[1, 2 + (4 * i)].Value = "Hora";
                        currentWorksheet2.Cells[1, 3 + (4 * i)].Value = "ID do Sensor";
                        currentWorksheet2.Cells[1, 4 + (4 * i)].Value = "Temperatura";

                        currentWorksheet3.Cells[1, 1 + (4 * i)].Value = "Data";
                        currentWorksheet3.Cells[1, 2 + (4 * i)].Value = "Hora";
                        currentWorksheet3.Cells[1, 3 + (4 * i)].Value = "ID do Sensor";
                        currentWorksheet3.Cells[1, 4 + (4 * i)].Value = "Corrente";

                        currentWorksheet4.Cells[1, 1 + (4 * i)].Value = "Data";
                        currentWorksheet4.Cells[1, 2 + (4 * i)].Value = "Hora";
                        currentWorksheet4.Cells[1, 3 + (4 * i)].Value = "ID do Sensor";
                        currentWorksheet4.Cells[1, 4 + (4 * i)].Value = "Distância";

                        currentWorksheet5.Cells[1, 1 + (6 * i)].Value = "Data";
                        currentWorksheet5.Cells[1, 2 + (6 * i)].Value = "Hora";
                        currentWorksheet5.Cells[1, 3 + (6 * i)].Value = "ID do Sensor";
                        currentWorksheet5.Cells[1, 4 + (6 * i)].Value = "Eixo X";
                        currentWorksheet5.Cells[1, 5 + (6 * i)].Value = "Eixo Y";
                        currentWorksheet5.Cells[1, 6 + (6 * i)].Value = "Eixo Z";

                        currentWorksheet6.Cells[1, 1 + (5 * i)].Value = "Data";
                        currentWorksheet6.Cells[1, 2 + (5 * i)].Value = "Hora";
                        currentWorksheet6.Cells[1, 3 + (5 * i)].Value = "ID do Sensor";
                        currentWorksheet6.Cells[1, 4 + (5 * i)].Value = "Data do Sensor";
                        currentWorksheet6.Cells[1, 5 + (5 * i)].Value = "Horário do Sensor";

                        currentWorksheet7.Cells[1, 1 + (4 * i)].Value = "Data";
                        currentWorksheet7.Cells[1, 2 + (4 * i)].Value = "Hora";
                        currentWorksheet7.Cells[1, 3 + (4 * i)].Value = "ID do Sensor";
                        currentWorksheet7.Cells[1, 4 + (4 * i)].Value = "Valor da Porta";

                        currentWorksheet8.Cells[1, 1 + (4 * i)].Value = "Data";
                        currentWorksheet8.Cells[1, 2 + (4 * i)].Value = "Hora";
                        currentWorksheet8.Cells[1, 3 + (4 * i)].Value = "ID do Sensor";
                        currentWorksheet8.Cells[1, 4 + (4 * i)].Value = "Valor da Porta";
                    }
                    package.Save();
                }
                #endregion
                
            }
            else
            {

            }
        }

        /// <summary>
        /// Trata os dados da mensagem de acelerometro recebida, no array deve conter desdo SND até o fim dos dados
        /// </summary>
        /// <param name="array"></param>
        void Handle_Acelerometro(byte[] array)
        {
            string aux;
            int divisor = 16;
            switch (combo_Acelerometro_mode.SelectedIndex)
            {
                case 0:
                    gauge_Acelerometro_X.From = -2.5;
                    gauge_Acelerometro_X.To = +2.5;
                    gauge_Acelerometro_Y.From = -2.5;
                    gauge_Acelerometro_Y.To = +2.5;
                    gauge_Acelerometro_Z.From = -2.5;
                    gauge_Acelerometro_Z.To = 2.5;
                    divisor = 16;
                    break;
                case 1:
                    gauge_Acelerometro_X.From = -4.5;
                    gauge_Acelerometro_X.To = +4.5;
                    gauge_Acelerometro_Y.From = -4.5;
                    gauge_Acelerometro_Y.To = +4.5;
                    gauge_Acelerometro_Z.From = -4.5;
                    gauge_Acelerometro_Z.To = 4.5;
                    divisor = 8;
                    break;
                case 2:
                    gauge_Acelerometro_X.From = -8.5;
                    gauge_Acelerometro_X.To = +8.5;
                    gauge_Acelerometro_Y.From = -8.5;
                    gauge_Acelerometro_Y.To = +8.5;
                    gauge_Acelerometro_Z.From = -8.5;
                    gauge_Acelerometro_Z.To = 8.5;
                    divisor = 4;
                    break;
                case 3:
                    gauge_Acelerometro_X.From = -16.5;
                    gauge_Acelerometro_X.To = +16.5;
                    gauge_Acelerometro_Y.From = -16.5;
                    gauge_Acelerometro_Y.To = +16.5;
                    gauge_Acelerometro_Z.From = -16.5;
                    gauge_Acelerometro_Z.To = 16.5;
                    divisor = 2;
                    break;
            }
            if (array.Length <= 0) { return; }
            Int16 a = (Int16)((array[5] << 8) | array[6]);
            Double X = a;
            a = (Int16)((array[7] << 8) | array[8]);
            Double Y = a;
            a = (Int16)((array[9] << 8) | array[10]);
            Double Z = a;
            X /= (divisor * 1024);
            Y /= (divisor * 1024);
            Z /= (divisor * 1024);
            text_TX_ID_Acelerometro.Text = array[0].ToString();
            text_ID_Acelerometro.Text = array[4].ToString();
            gauge_Acelerometro_X.Value = Math.Round(X, 4);
            gauge_Acelerometro_Y.Value = Math.Round(Y, 4);
            gauge_Acelerometro_Z.Value = Math.Round(Z, 4);
            aux = string.Format("Mensagem recebida de acelerômetro \r\n ID do transmissor: {0}\r\n ID do sensor: {1}\r\n Eixo X: {2}\r\n Eixo Y: {3}\r\n Eixo Z: {4}",
                array[0].ToString(), array[4].ToString(), Math.Round(X, 4).ToString(), Math.Round(Y, 4).ToString(), Math.Round(Z, 4).ToString());
            BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", aux });
        }

        void Handle_SensorTemperatura(byte[] array)
        {
            string aux;
            if (array.Length <= 0) { return; }
            text_TX_ID_STemp.Text = array[0].ToString();
            text_ID_STemp.Text = array[4].ToString();
            int index;


            if (ListaID_Temperatura.Contains(array[4]))
            {
                index = ListaID_Temperatura.FindIndex(b => b == array[4]);
                double a = ((array[5] << 8) | array[6]);
                a /= 16;
                if (cartesian_STemp.Series[index].Values.Count > 100)
                {
                    cartesian_STemp.Series[index].Values.RemoveAt(0);
                    double[] temp = new double[100];
                }
                cartesian_STemp.Series[index].Values.Add(a);
                text_Temperatura_Inst.Text = a.ToString();
                aux = string.Format("Mensagem recebida de sensor de temperatura.\r\nID do Transmissor: {0}\r\nID do sensor: {1}\r\nTemperatura: {2}",
                    text_TX_ID_STemp.Text, text_ID_STemp.Text, a.ToString());
                BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", aux });
            }
            else
            {
                ListaID_Temperatura.Add(array[4]);
                index = ListaID_Temperatura.FindIndex(b => b == array[4]);
                Random r = new Random();
                System.Windows.Media.Color myColor = System.Windows.Media.Color.FromArgb((byte)r.Next(0, 256), (byte)r.Next(0, 256), (byte)r.Next(0, 256), (byte)r.Next(0, 256));
                System.Windows.Media.SolidColorBrush myBrush = new System.Windows.Media.SolidColorBrush(myColor);

                cartesian_STemp.Series.Add(new LineSeries
                {
                    Title = string.Format("ID {0}", BitConverter.ToString(array, 4, 1)),
                    LineSmoothness = 1, //straight lines, 1 really smooth lines
                                        //PointGeometry = System.Windows.Media.Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                    PointGeometrySize = 5,
                    PointForeground = myBrush
                });
                double a = ((array[5] << 8) | array[6]);
                a /= 16;
                cartesian_STemp.Series[index].Values = (new ChartValues<double> { a });
                text_Temperatura_Inst.Text = a.ToString();
                aux = string.Format("Mensagem recebida de sensor de temperatura.\r\nID do Transmissor: {0}\r\nID do sensor: {1}\r\nTemperatura: {2}",
                    text_TX_ID_STemp.Text, text_ID_STemp.Text, a.ToString());
                BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", aux });
            }
        }

        void Handle_SensorCorrente(byte[] array)
        {
            string aux;
            if (array.Length <= 0) { return; }
            text_TX_ID_SCorrente.Text = array[0].ToString();
            text_ID_SCorrente.Text = array[4].ToString();
            int index;

            if (ListaID_Corrente.Contains(array[4]))
            {
                index = ListaID_Corrente.FindIndex(b => b == array[4]);
                double a = ((array[5] << 8) | array[6]);
                a *= 0.2957;
                if (cartesian_SCorrente.Series[index].Values.Count > 100)
                {
                    cartesian_SCorrente.Series[index].Values.RemoveAt(0);
                }
                cartesian_SCorrente.Series[index].Values.Add(a);
                text_Corrente_Inst.Text = a.ToString();
                aux = string.Format("Mensagem recebida de sensor de corrente.\r\nID do Transmissor: {0}\r\nID do sensor: {1}\r\n Corrente: {2}",
                    text_TX_ID_SCorrente.Text, text_ID_SCorrente.Text, a.ToString());
                BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", aux });
            }
            else
            {
                ListaID_Corrente.Add(array[4]);
                index = ListaID_Corrente.FindIndex(b => b == array[4]);
                Random r = new Random();
                System.Windows.Media.Color myColor = System.Windows.Media.Color.FromArgb((byte)r.Next(0, 256), (byte)r.Next(0, 256), (byte)r.Next(0, 256), (byte)r.Next(0, 256));
                System.Windows.Media.SolidColorBrush myBrush = new System.Windows.Media.SolidColorBrush(myColor);

                cartesian_SCorrente.Series.Add(new LineSeries
                {
                    Title = string.Format("ID {0}", BitConverter.ToString(array, 4, 1)),
                    LineSmoothness = 1, //straight lines, 1 really smooth lines
                                        //PointGeometry = System.Windows.Media.Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                    PointGeometrySize = 5,
                    PointForeground = myBrush
                });
                double a = ((array[5] << 8) | array[6]);
                a *= 0.2957;
                cartesian_SCorrente.Series[index].Values = (new ChartValues<double> { a });
                text_Corrente_Inst.Text = a.ToString();
                aux = string.Format("Mensagem recebida de sensor de corrente.\r\nID do Transmissor: {0}\r\nID do sensor: {1}\r\n Corrente: {2}",
                    text_TX_ID_SCorrente.Text, text_ID_SCorrente.Text, a.ToString());
                BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", aux });
            }
        }

        void Handle_SensorUltrassonico(byte[] array)
        {
            string aux;
            if (array.Length <= 0) { return; }
            text_RX_SUltra_SND.Text = array[0].ToString();
            text_RX_SUltra_ID_Sensor.Text = array[4].ToString();
            text_RX_SUltra_Valor.Text = ((array[5] << 8) | array[6]).ToString() + "cm";
            aux = string.Format("Mensagem recebida de sensor ultrassônico.\r\nID do Transmissor: {0}\r\nID do sensor: {1}\r\n Distância(cm): {2}",
                    text_RX_SUltra_SND.Text, text_RX_SUltra_ID_Sensor.Text, ((array[5] << 8) | array[6]).ToString());
            BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", aux });
        }

        void Handle_Magnetometro(byte[] array)
        {
            string aux;
            int divisor = 12000;
            if (array.Length <= 0) { return; }
            Int16 a = (Int16)((array[5] << 8) | array[6]);
            Double X = a;
            a = (Int16)((array[7] << 8) | array[8]);
            Double Y = a;
            a = (Int16)((array[9] << 8) | array[10]);
            Double Z = a;
            X /= (divisor);
            Y /= (divisor);
            Z /= (divisor);
            text_RX_Mag_SND.Text = array[0].ToString();
            text_RX_Mag_ID_Sensor.Text = array[4].ToString();
            aux = string.Format("Mensagem recebida de magnetômetro \r\n ID do transmissor: {0}\r\n ID do sensor: {1}\r\n Eixo X: {2}\r\n Eixo Y: {3}\r\n Eixo Z: {4}",
                array[0].ToString(), array[4].ToString(), Math.Round(X, 4).ToString(), Math.Round(Y, 4).ToString(), Math.Round(Z, 4).ToString());
            BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", aux });
            text_RX_Mag_Valor.Text = string.Format("Eixo X: {0}\r\nEixo Y: {1}\r\nEixo Z: {2}", Math.Round(X, 4).ToString(), Math.Round(Y, 4).ToString(), Math.Round(Z, 4).ToString());
        }

        void Handle_RTC(byte[] array)
        {
            string str_aux = null;
            string str_aux2 = null;
            if (array.Length <= 0) { return; }
            text_RX_RTC_SND.Text = array[0].ToString();
            text_RX_RTC_ID_Sensor.Text = array[4].ToString();
            switch (array[5])
            {
                case 0:
                    str_aux = "Domingo, ";
                    break;
                case 1:
                    str_aux = "Segunda-Feira, ";
                    break;
                case 2:
                    str_aux = "Terça-Feira, ";
                    break;
                case 3:
                    str_aux = "Quarta-Feira, ";
                    break;
                case 4:
                    str_aux = "Quinta-Feira, ";
                    break;
                case 5:
                    str_aux = "Sexta-Feira, ";
                    break;
                case 6:
                    str_aux = "Sábado, ";
                    break;

            }
            switch (array[7])
            {
                case 0:
                    str_aux += String.Format("{1} de Janeiro de {0}", (2000 + array[8]).ToString(), array[6].ToString());
                    break;
                case 1:
                    str_aux += String.Format("{1} Fevereiro de {0}", (2000 + array[8]).ToString(), array[6].ToString());
                    break;
                case 2:
                    str_aux += String.Format("{1} Março de {0}", (2000 + array[8]).ToString(), array[6].ToString());
                    break;
                case 3:
                    str_aux += String.Format("{1} Abril de {0}", (2000 + array[8]).ToString(), array[6].ToString());
                    break;
                case 4:
                    str_aux += String.Format("{1} Maio de {0}", (2000 + array[8]).ToString(), array[6].ToString());
                    break;
                case 5:
                    str_aux += String.Format("{1} Junho de {0}", (2000 + array[8]).ToString(), array[6].ToString());
                    break;
                case 6:
                    str_aux += String.Format("{1} Julho de {0}", (2000 + array[8]).ToString(), array[6].ToString());
                    break;
                case 7:
                    str_aux += String.Format("{1} Agosto de {0}", (2000 + array[8]).ToString(), array[6].ToString());
                    break;
                case 8:
                    str_aux += String.Format("{1} Setembro de {0}", (2000 + array[8]).ToString(), array[6].ToString());
                    break;
                case 9:
                    str_aux += String.Format("{1} Outubro de {0}", (2000 + array[8]).ToString(), array[6].ToString());
                    break;
                case 10:
                    str_aux += String.Format("{1} Novembro de {0}", (2000 + array[8]).ToString(), array[6].ToString());
                    break;
                case 11:
                    str_aux += String.Format("{1} Dezembro de {0}", (2000 + array[8]).ToString(), array[6].ToString());
                    break;

            }
            str_aux += String.Format("\r\n{0}:{1}:{2}", ((array[9] * 10) + array[10]).ToString(), ((array[11] * 10) + array[12]).ToString(), ((array[13] * 10) + array[14]).ToString());
            text_RX_RTC_Valor.Text = str_aux;
            str_aux2 = string.Format("Mensagem recebida de Real Time Clock.\r\nID do Transmissor: {0}\r\nID do sensor: {1}\r\n Data e Hora: {2}",
                    text_RX_RTC_SND.Text, text_RX_RTC_ID_Sensor.Text, str_aux);
            BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", str_aux2 });
        }

        void Handle_PortaDigital(byte[] array)
        {
            string aux;
            if (array.Length <= 0) { return; }
            text_RX_GPIO_SND.Text = array[0].ToString();
            text_RX_GPIO_ID_Sensor.Text = array[4].ToString();
            if (array[5] == 1)
            {
                text_RX_GPIO_Valor.Text = "High";
            }
            else
            {
                text_RX_GPIO_Valor.Text = "Low";
            }

            aux = string.Format("Mensagem recebida de GPIO.\r\nID do Transmissor: {0}\r\nID do sensor: {1}\r\n Estado: {2}",
                    text_RX_GPIO_SND.Text, text_RX_GPIO_ID_Sensor.Text, text_RX_GPIO_Valor.Text);
            BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", aux });
        }

        void Handle_PortaAnalogica(byte[] array)
        {
            string aux;
            if (array.Length <= 0) { return; }
            text_RX_Analogico_SND.Text = array[0].ToString();
            text_RX_Analogico_ID_Sensor.Text = array[4].ToString();
            text_RX_Analogico_Valor.Text = ((array[5] << 8) | array[6]).ToString();
            aux = string.Format("Mensagem recebida de Porta Analógica.\r\nID do Transmissor: {0}\r\nID do sensor: {1}\r\n Valor: {2}",
                    text_RX_Analogico_SND.Text, text_RX_Analogico_ID_Sensor.Text, text_RX_Analogico_Valor.Text);
            BeginInvoke(new Delegate_void_String(Escreve_textLOG), new object[] { "", aux });
        }
        #endregion

        private void button_Acelerometro_Enviar_Click(object sender, EventArgs e)
        {
            string str_aux;
            uint byte_aux;
            if ((text_Acelerometro_ID.Text == "") || (combo_Acelerometro_Eixo.SelectedIndex == -1) || (text_Acelerometro_ID_Sensor.Text == ""))
            {
                MessageBox.Show("Os campos não podem ser deixados em branco.", "Erro");
                return;
            }
            if (int.Parse(text_Acelerometro_ID.Text) > 255)
            {
                MessageBox.Show("O valor de ID não pode ser maior que 255.", "Erro");
                return;
            }
            byte_aux = (byte)int.Parse(text_Acelerometro_ID.Text);
            BeginInvoke(new Delegate_void_Serial_bytearray(Enviar_Serial), new object[] { Mensagem.Ler_Acelerometro((byte)int.Parse(text_Acelerometro_ID.Text), (byte)int.Parse(text_Acelerometro_ID_Sensor.Text), (byte)combo_Acelerometro_Eixo.SelectedIndex) });

        }

        private void button_STemp_Enviar_Click(object sender, EventArgs e)
        {
            if ((text_STemp_TX_ID.Text == "") || (text_STemp_ID.Text == ""))
            {
                MessageBox.Show("Os campos não podem ser deixados em branco.", "Erro");
                return;
            }
            if ((int.Parse(text_STemp_TX_ID.Text) > 0xff) || (int.Parse(text_STemp_ID.Text) > 0xff))
            {
                MessageBox.Show("Os valores não podem ser maiores que 255.", "Erro");
                return;

            }
            BeginInvoke(new Delegate_void_Serial_bytearray(Enviar_Serial), new object[] { Mensagem.Ler_Temperatura(byte.Parse(text_STemp_TX_ID.Text), byte.Parse(text_STemp_ID.Text)) });

        }

        private void button_SCorrente_Enviar_Click(object sender, EventArgs e)
        {
            if ((text_SCorrente_RCP_ID.Text == "") || (text_SCorrente_ID.Text == ""))
            {
                MessageBox.Show("Os campos não podem ser deixados em branco.", "Erro");
                return;
            }
            if ((int.Parse(text_SCorrente_RCP_ID.Text) > 0xff) || (int.Parse(text_SCorrente_ID.Text) > 0xff))
            {
                MessageBox.Show("Os valores não podem ser maiores que 255.", "Erro");
                return;
            }
            BeginInvoke(new Delegate_void_Serial_bytearray(Enviar_Serial), new object[] { Mensagem.Ler_SensorCorrente(byte.Parse(text_SCorrente_RCP_ID.Text), byte.Parse(text_SCorrente_ID.Text)) });
        }

        private void button_Send_SUltra_Click(object sender, EventArgs e)
        {
            if ((text_TX_SUltra_RCP.Text == "") || (text_TX_SUltra_ID_Sensor.Text == ""))
            {
                MessageBox.Show("Os campos não podem ser deixados em branco.", "Erro");
                return;
            }
            if ((int.Parse(text_TX_SUltra_RCP.Text) > 0xff) || int.Parse(text_TX_SUltra_ID_Sensor.Text) > 0xff)
            {
                MessageBox.Show("Os valores não podem ser maiores que 255.", "Erro");
                return;
            }
            BeginInvoke(new Delegate_void_Serial_bytearray(Enviar_Serial), new object[] { Mensagem.Ler_SUltra(byte.Parse(text_TX_SUltra_RCP.Text), byte.Parse(text_TX_SUltra_ID_Sensor.Text)) });

        }

        private void button_Send_Magnetometro_Click(object sender, EventArgs e)
        {
            if ((text_TX_Mag_RCP.Text == "") || (text_TX_Mag_ID_Sensor.Text == ""))
            {
                MessageBox.Show("Os campos não podem ser deixados em branco.", "Erro");
                return;
            }
            if ((int.Parse(text_TX_Mag_RCP.Text) > 0xff) || int.Parse(text_TX_Mag_ID_Sensor.Text) > 0xff)
            {
                MessageBox.Show("Os valores não podem ser maiores que 255.", "Erro");
                return;
            }
            //BeginInvoke(new Delegate_void_Serial_bytearray(Enviar_Serial), new object[] { Mensagem.Ler_Magnetometro(byte.Parse(text_TX_Mag_RCP.Text), byte.Parse(text_TX_Mag_ID_Sensor.Text)) });
        }

        private void button_Send_RTC_Click(object sender, EventArgs e)
        {
            if ((text_TX_RTC_RCP.Text == "") || (text_TX_RTC_ID_Sensor.Text == ""))
            {
                MessageBox.Show("Os campos não podem ser deixados em branco.", "Erro");
                return;
            }
            if ((int.Parse(text_TX_RTC_RCP.Text) > 0xff) || int.Parse(text_TX_RTC_ID_Sensor.Text) > 0xff)
            {
                MessageBox.Show("Os valores não podem ser maiores que 255.", "Erro");
                return;
            }
            BeginInvoke(new Delegate_void_Serial_bytearray(Enviar_Serial), new object[] { Mensagem.Enviar_RTC(byte.Parse(text_TX_RTC_RCP.Text), byte.Parse(text_TX_RTC_ID_Sensor.Text), combo_RTC.SelectedIndex) });
        }

        private void button_Send_GPIO_Click(object sender, EventArgs e)
        {
            if ((text_TX_GPIO_RCP.Text == "") || (text_TX_GPIO_ID_Sensor.Text == ""))
            {
                MessageBox.Show("Os campos não podem ser deixados em branco.", "Erro");
                return;
            }
            if ((int.Parse(text_TX_GPIO_RCP.Text) > 0xff) || int.Parse(text_TX_GPIO_ID_Sensor.Text) > 0xff)
            {
                MessageBox.Show("Os valores não podem ser maiores que 255.", "Erro");
                return;
            }
            BeginInvoke(new Delegate_void_Serial_bytearray(Enviar_Serial), new object[] { Mensagem.Enviar_GPIO(byte.Parse(text_TX_GPIO_RCP.Text), byte.Parse(text_TX_GPIO_ID_Sensor.Text), combo_GPIO.SelectedIndex) });
        }

        private void button_Send_Analogico_Click(object sender, EventArgs e)
        {
            if ((text_TX_Analogico_RCP.Text == "") || (text_TX_Analogico_ID_Sensor.Text == "") || (text_Analogico_value.Text == ""))
            {
                MessageBox.Show("Os campos não podem ser deixados em branco.", "Erro");
                return;
            }
            if ((int.Parse(text_TX_Analogico_RCP.Text) > 0xff) || int.Parse(text_TX_Analogico_ID_Sensor.Text) > 0xff)
            {
                MessageBox.Show("Os valores não podem ser maiores que 255.", "Erro");
                return;
            }
            BeginInvoke(new Delegate_void_Serial_bytearray(Enviar_Serial), new object[] { Mensagem.Enviar_Analogico(byte.Parse(text_TX_Analogico_RCP.Text), byte.Parse(text_TX_Analogico_ID_Sensor.Text), combo_Analogico.SelectedIndex, UInt16.Parse(text_Analogico_value.Text)) });
        }

        private void combo_Analogico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Analogico.SelectedIndex == 1)
            {
                text_Analogico_value.Enabled = true;
            }
            else
            {
                text_Analogico_value.Enabled = false;
            }
        }

        private void buttonCleanLOG_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja apagar o LOG de mensagens?", "Atenção", MessageBoxButtons.YesNo))
            {
                textLOG.Clear();
            }
        }

        private void buttonSaveLOG_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Deseja salvar o LOG de respostas?", "Atenção", MessageBoxButtons.YesNo))
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.DefaultExt = "*.txt";
                saveFileDialog1.Filter = "txt files | *.txt";
                saveFileDialog1.FileName = "LOG de Mensagens";
                // aguarda o usuário decidir onde salvará o arquivo
                try
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //salva o arquivo
                        textLOG.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.UnicodePlainText);
                        MessageBox.Show("Arquivo Salvo");

                    }
                    else
                    {
                        MessageBox.Show("Arquivo não foi salvo");
                    }
                }
                catch
                {
                    // avisa caso ocorra algum erro
                    MessageBox.Show("Falha");
                }
            }
        }
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
        public byte Acelerometro = 0x01;
        public byte SensorTemperatura = 0x02;
        public byte SensorCorrente = 0x03;
        public byte SensorUltrassonico = 0x04;
        public byte Magnetometro = 0x05;
        public byte RTC = 0x06;
        public byte PortaDigital = 0x07;
        public byte PortaAnalogica = 0x08;
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
        public bool Frame_validation(ref byte[] msg)
        {


            ulong crc;
            int index_sof = 0;
            int index_EOF = 0;
            for (int i = 0; i < msg.Length; i++)
            {
                if (msg[i] == 0x01)
                {
                    index_sof = i;
                }
                if (msg[i] == 0x04)
                {
                    index_EOF = i;
                    break;
                }
            }
            byte[] aux = new byte[index_EOF - index_sof + 1];
            Array.Copy(msg, index_sof, aux, 0, aux.Length);
            if ((aux[index_sof] != SOF) || (aux[index_EOF] != EOF))
            {
                return false;
            }
            Array.Copy(msg, aux, aux.Length);
            Escape_Bytes(ref aux, 0x01);

            crc = (ulong)((aux[aux.Length - 3] << 8) | (aux[aux.Length - 2]));
            if (crc == 0)
            {
                msg = new byte[aux.Length];
                Array.Copy(aux, msg, msg.Length);
                return true;
            }
            if (crc != CRC_Calc(aux))
            {
                return false;
            }

            Array.Copy(aux, msg, msg.Length);
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
            switch (tipo)
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
            byte[] rtrn = new byte[7 + cmd.Length];
            ulong crc_calc;
            rtrn[0] = SOF;
            rtrn[1] = (byte)Lista_Enderecos[0];
            rtrn[2] = receptor;
            rtrn[3] = (byte)(cmd.Length - 1);
            Array.Copy(cmd, 0, rtrn, 4, cmd.Length);
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

        public byte[] Ler_SUltra(byte RCP, byte ID)
        {
            byte[] CMD = { SensorUltrassonico, ID };
            return Montar_Frame(RCP, CMD);
        }

        public byte[] Enviar_RTC(byte RCP, byte ID, int tipo)
        {
            byte[] CMD = new byte[] { RTC, ID, (byte)tipo };
            string s;
            int a = 0;
            byte[] date = new byte[9];
            date[0] = (byte)DateTime.Now.DayOfWeek;
            date[1] = (byte)(DateTime.Now.Month - 1);
            date[2] = (byte)(DateTime.Now.Year - 2000);
            s = DateTime.Now.ToString("hh");
            date[3] = (byte)((int.Parse(s) >> 8) & 0xFF);
            date[4] = (byte)((int.Parse(s) >> 0) & 0xFF);
            s = DateTime.Now.ToString("mm");
            date[5] = (byte)((int.Parse(s) >> 8) & 0xFF);
            date[6] = (byte)((int.Parse(s) >> 0) & 0xFF);
            s = DateTime.Now.ToString("ss");
            date[7] = (byte)((int.Parse(s) >> 8) & 0xFF);
            date[8] = (byte)((int.Parse(s) >> 0) & 0xFF);
            switch (tipo)
            {
                case 0x01:
                    CMD = new byte[12];
                    CMD[0] = RTC;
                    CMD[1] = ID;
                    CMD[2] = (byte)tipo;
                    Array.Copy(date, 0, CMD, 3, date.Length);
                    break;
            }
            return Montar_Frame(RCP, CMD);
        }

        public byte[] Enviar_Analogico(byte RCP, byte ID, int tipo, UInt16 valor)
        {
            byte[] CMD = null;
            if (tipo == 1)
            {
                CMD = new byte[] { PortaAnalogica, ID, (byte)tipo, (byte)((valor >> 8) & 0xff), (byte)(valor & 0xFF) };
            }
            else
            {
                CMD = new byte[] { PortaAnalogica, ID, (byte)tipo };
            }
            return Montar_Frame(RCP, CMD);
        }

        public byte[] Enviar_GPIO(byte RCP, byte ID, int tipo)
        {
            byte[] CMD = { PortaDigital, ID, (byte)tipo };
            return Montar_Frame(RCP, CMD);
        }
        #endregion
    }
    public class DateModel
    {
        public string Hora { get; set; }
        public double Value { get; set; }
    }
}
