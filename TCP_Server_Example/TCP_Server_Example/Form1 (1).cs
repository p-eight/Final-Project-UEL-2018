using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_Server_Example
{

    public partial class Form1 : Form
    {
        string IP4_Endereco;
        string IP4_Porta;
        static TcpListener servidorTCP = null;
        static TcpClient clienteTCP = null;
        static NetworkStream streamTCP = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Encontrar_IP();
        }

        public void Encontrar_IP()
        {
            try
            {
                /*
                 * Este loop irá procurar por endereços DNS e determinar o IP
                 * da máquina utilizada
                 */
                foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
                {
                    if (IPA.AddressFamily == AddressFamily.InterNetwork)
                    {
                        IP4_Endereco = IPA.ToString();
                        break;
                    }
                }
                textBox1.Text = IP4_Endereco;
                /*
                 * Será utilizado como porta padrão a porta 5001
                 */
                textBox2.Text = "5001";
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                /* Neste switch é tomada a decisão de abrir ou fechar
                 o servidor conforme o texto do botão.*/
                switch (button1.Text)
                {
                    case "Abrir Servidor":
                        /* Testa se a caixas de texto não estão vazias. Se estiverem
                         * não é possível abrir o servidor. */
                        if((textBox1.Text == "") && (textBox2.Text == ""))
                        {
                            MessageBox.Show("O servidor TCP/IP não pode ser iniciado com parâmetros em branco.", "Atenção");
                            return;
                        }
                        /* Atribui uma nova instância TcpListener na variável servidorTCP.
                         * Converte os valores das caixas de texto para formato apropriado
                         * para o servidor. */
                        servidorTCP = new TcpListener(IPAddress.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
                        /*Inicia o servidor TCP*/
                        servidorTCP.Start();
                        /*Escrever na caixa de LOG que o servidor está conectado*/
                        BeginInvoke(new Delegate_void_String(Append_Text), new object[] { richTextBox1,
                        string.Format("Servidor conectado. IP: {0} . Porta: {1} .", textBox1.Text, textBox2.Text)});
                        /*Dá inicio a uma operação assíncrona que irá aguardar uma conexão
                         de cliente. É necessário passar um callback que será executado quando
                         ocorrer a conexão e o um objeto para ser manuseado, neste caso a variavel
                         do servidor. */
                        servidorTCP.BeginAcceptTcpClient(Callback_AceitarCliente, servidorTCP);
                        /*Altera o texto do botão para quando ocorrer um novo clique, feche o
                         servidor.*/
                        button1.Text = "Fechar Servidor";
                        break;

                    case "Fechar Servidor":
                        /*Para fechar o servidor sem causar erros, primeiro é necessário fechar a stream de dados.
                          É uma boa prática testar se os elementos não são nulos antes de manipulalos
                         */
                        if(streamTCP != null)
                        {
                            streamTCP.Close();
                        }
                        /* Agora é possível fechar o servidor sem que aconteçam maiores problemas */
                        if(servidorTCP != null)
                        {
                            servidorTCP.Stop();
                        }
                        /* Voltamos o botão para a função de abrir servidor */
                        button1.Text = "Abrir Servidor";
                        break;
                }
            }
            /* Aqui realiza-se o tratamento de erros, neste caso apenas iremos fechar a stream de dados
             * e o servidor em caso de erro, e entao retornar o botão para a função de abrir servidor */
            catch(Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Houve um erro no servidor TCP. O servidor foi fechado.", "Atenção");
                if (streamTCP != null)
                {
                    streamTCP.Close();
                }
                if (servidorTCP != null)
                {
                    servidorTCP.Stop();
                }
                button1.Text = "Abrir Servidor";
            }
        }
        public delegate void Delegate_void_String(RichTextBox textbox, string text);
        public void Append_Text(RichTextBox textbox, string text)
        {
            textbox.AppendText(text+"\r\n");
            textbox.ScrollToCaret();
        }
        private void Callback_AceitarCliente(IAsyncResult ar)
        {
            servidorTCP = ar.AsyncState as TcpListener;
            //servidorTCP = listener;
            if (servidorTCP == null)
                return;

            try
            {
                clienteTCP = servidorTCP.EndAcceptTcpClient(ar);
                streamTCP = clienteTCP.GetStream();
                byte[] buffer = new byte[100];
                streamTCP.BeginRead(buffer, 0, buffer.Length, Callback_LerCliente, clienteTCP);
                BeginInvoke(new Delegate_void_String(Append_Text), new object[] { richTextBox1,
                        string.Format("Cliente conectado.")});
            }
            finally
            {
                //servidorTCP.BeginAcceptTcpClient(Callback_AceitarCliente, servidorTCP);
            }
        }

        private void Callback_LerCliente(IAsyncResult ar)
        {
            clienteTCP = ar.AsyncState as TcpClient;
            byte[] bytes = new byte[100];
            int i;
            if(clienteTCP.Connected)
            {
                streamTCP = clienteTCP.GetStream();
            }
            // Loop to receive all the data sent by the client.

            while (clienteTCP.Connected && streamTCP.CanRead)
            {
                if (streamTCP.DataAvailable)
                {
                    i = streamTCP.Read(bytes, 0, bytes.Length);
                    BeginInvoke(new Delegate_void_String(Append_Text), new object[] { richTextBox1,
                        string.Format("Mensagem recebida: {0}", Encoding.UTF8.GetString(bytes, 0, i))});
                }
            }

            BeginInvoke(new Delegate_void_String(Append_Text), new object[] { richTextBox1,
                        "O cliente se desconectou" });
            // Shutdown and end connection
            //clienteTCP.Close();
        }
    }
}
