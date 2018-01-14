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
                            streamTCP = null;
                        }
                        /* Agora é possível fechar o servidor sem que aconteçam maiores problemas */
                        if(servidorTCP != null)
                        {
                            servidorTCP.Stop();
                            servidorTCP = null;
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
            /*Faz-se uma transformação de objeto para TcpListener para que o código trate
             * a variável desta maneira */
            servidorTCP = ar.AsyncState as TcpListener;
            /*Testa se a variável não é nula. Caso seja, finaliza o método */
            if (servidorTCP == null)
            {
                return;
            }

            try
            {
                /* Termina a aceitação do cliente TCP de forma assincrona e adiciona o cliente na variavel
                 * clienteTCP */
                clienteTCP = servidorTCP.EndAcceptTcpClient(ar);
                /* Retorna a stream de dados do cliente para que seja possível manipula-la lendo ou escrevendo
                 * dados */
                streamTCP = clienteTCP.GetStream();
                byte[] buffer = new byte[100];
                /* Leitura assíncrona da stream de dados */
                streamTCP.BeginRead(buffer, 0, buffer.Length, Callback_LerCliente, clienteTCP);
                BeginInvoke(new Delegate_void_String(Append_Text), new object[] { richTextBox1,
                        string.Format("Cliente conectado.")});
            }
            catch { }
        }

        private void Callback_LerCliente(IAsyncResult ar)
        {
            /*Faz-se uma transformação de objeto para TcpClient para que o código trate
             * a variável desta maneira */
            clienteTCP = ar.AsyncState as TcpClient;
            /* Cria o buffer onde será armazenada a leitura */
            byte[] bytes = new byte[1024];
            int i;
            /* Apenas deve-se abrir a stream de dados se o cliente estiver conectado */
            if(clienteTCP.Connected)
            {
                streamTCP = clienteTCP.GetStream();
            }
            /* Testa se a stream pode ser lida e se o cliente está conectado, enquanto isto for verdadeiro
             * deve-se checar se há dados disponíveis para serem lidos */
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                /* Testa de o campo de dados não está vazio */
                if (richTextBox2.Text == "")
                {
                    MessageBox.Show("Não há mensagem a ser enviada", "Atenção");
                    return;
                }
                /* Testa se o servidor e a stream de dados estão funcionais */
                if ((servidorTCP == null) || (streamTCP == null) || (streamTCP.CanWrite == false))
                {
                    MessageBox.Show("Não foi possível enviar a mensagem. Problema com o servidor ou com a stream de dados", "Atenção");
                    return;
                }
                /* Converte o texto da richTextBox2 para um vetor de bytes */
                byte[] texto = Encoding.ASCII.GetBytes(richTextBox2.Text);
                /* Envia o vetor texto pela stream de dados para o cliente */
                streamTCP.Write(texto, 0, texto.Length);
                /* Escreve em richTextBox1 a mensagem enviada */
                BeginInvoke(new Delegate_void_String(Append_Text), new object[] { richTextBox1,
                        string.Format("Mensagem enviada: {0}", richTextBox2.Text)});
                richTextBox2.Clear();
            }
            catch { }
        }
    }
}
