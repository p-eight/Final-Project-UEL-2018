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
using Newtonsoft.Json;
using System.IO;

namespace Sistema_Supervisorio
{
    public partial class Form1 : Form
    {
        SerialPort PortaSerial = new SerialPort();
        System.Timers.Timer general_timer = new System.Timers.Timer(1000);
        public class Mensagem
        {
            public string Data = string.Format("{0}/{1}/{2}", DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"),
                DateTime.Now.ToString("yy"));
            public string Hora = string.Format("{0}:{1}:{2}", DateTime.Now.ToString("HH"), DateTime.Now.ToString("mm"),
                DateTime.Now.ToString("ss"));
            public string msg_recebida;

            public Mensagem(string msg)
            {
                msg_recebida = msg;
            }
        }
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
            switch (button1.Text)
            {
                case "Abrir Porta":
                    if (PortaSerial.IsOpen)
                    {
                        PortaSerial.Close();
                    }
                    if ((comboBox1.Text == "") || (comboBox2.Text == ""))
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
                    catch { }
                    break;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            /* As mensagens só podem ser enviadas se a porta serial estiver aberta
             * e se o campo de dados não estiver vazio            
             */
            if (PortaSerial.IsOpen && richTextBox2.Text != "")
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
            Criar_Arquivo_JSON(BitConverter.ToString(recebido).Replace('-',' '));
            Tratar_Mensagem(recebido);
        }
        public delegate void Delegate_void_String(RichTextBox textbox, string text);
        public void Append_Text(RichTextBox textbox, string text)
        {
            textbox.AppendText(text);
            textbox.ScrollToCaret();
        }

        private void Tratar_Mensagem(byte[] mensagem)
        {
            /*
             * Cria uma string contendo a data e hora atual a partir do relógio interno do computador.
             * O formato da data será do tipo: [dd/mm/aa - hh:mm:ss]
             */
            string timestamp = string.Format("[{0}/{1}/{2} - {3}:{4}:{5}]", DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"),
                DateTime.Now.ToString("yy"), DateTime.Now.ToString("HH"), DateTime.Now.ToString("mm"), DateTime.Now.ToString("ss"));
            if (mensagem == null || mensagem.Length <= 0)
            {
                BeginInvoke(new Delegate_void_String(Append_Text), new object[] { richTextBox1,
                    string.Format("{0} - A mensagem recebida está vazia. \r\n", timestamp) });
                return;
            }

            /*
             * Agora é realizado o teste se a mensagem é válida, ou seja, se tem os valores esperados como
             * início e fim de mensagem.
             * Início de mensagem == 0x0A
             * Fim de mensagem == 0xA0.
             */
            if ((mensagem[0] != 0x0A) || (mensagem[mensagem.Length - 1] != 0xA0))
            {
                /*
                 * Se a mensagem for inválida, apenas aparecerá o alerta na tela e finaliza o método.
                 */ 
                BeginInvoke(new Delegate_void_String(Append_Text), new object[] { richTextBox1,
                    string.Format("{0} - A mensagem recebida é inválida. \r\n", timestamp) });
                return;
            }
            else
            {
                /*
                 * Se a mensagem for válida, também é escrita a mensagem na tela.
                 */ 
                BeginInvoke(new Delegate_void_String(Append_Text), new object[] { richTextBox1,
                    string.Format("{0} - A mensagem recebida é válida. \r\n Mensagem recebida: {1}.\r\n", timestamp, BitConverter.ToString(mensagem).Replace('-',' '))});
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
             * Para nomear o arquivo será utilizada a data atual
             * Para isto utiliza-se a estrutura DateTime.
             */ 
            string str_aux = string.Format("{0}-{1}-{2} LOG", DateTime.Now.ToString("yy"),
                DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"));
            /*
             * Utiliza a classe SaveFileDialog, que habilita o usuário escolher
             * onde deseja salvar o arquivo.
             */
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            /*
             * Define que arquivos de texto (*.txt) será o tipo padrão do arquivo
             */ 
            saveFileDialog1.DefaultExt = "*.txt";
            saveFileDialog1.Filter = "txt files | *.txt";
            /*
             * Já inclui o nome automaticamente no arquivo
             */ 
            saveFileDialog1.FileName = str_aux;
            /*
             * aguarda o usuário decidir onde salvará o arquivo
             */ 
            try
            {
                /*
                 * Abre a janela para que o usuário salve o arquivo.
                 * Se não houver falhas no processo, será exibido um pop-up indicando isto;
                 * ou, caso ocorra uma falha ou o usuário cancele a operação de salvar o arquivo
                 * também será exibido um pop-up.
                 */
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //salva o arquivo
                    richTextBox2.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.UnicodePlainText);
                    MessageBox.Show("Arquivo Salvo");

                }
                else
                {
                    MessageBox.Show("Arquivo não foi salvo");
                }
            }
            catch
            {
                /*
                 * avisa caso ocorra alguma exceção de software
                 */
                MessageBox.Show("Falha");
            }
        }

        private void Criar_Arquivo_JSON(string msg)
        {
            /*
             * Cria uma nova variável do tipo 'Mensagem' conforme criado anteriormente
             */ 
            Mensagem MSG_Save = new Mensagem(msg);
            /*
             * Utiliza a biblioteca Newtonsoft para converter a struct para o formatato
             * json.
             */
            string json_string = JsonConvert.SerializeObject(MSG_Save);
            try
            {
                /*
                 * Determina automaticamente a pasta (folder) onde o arquivo será salvo,
                 * será salvo na pasta onde está sendo executado o software.
                 */
                String FolderPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
                /*
                 * Lista todos os arquivos contidos na pasta para determinar se é necessário criar um novo arquivo
                 * ou se já existe um arquivo com o nome desejado
                 */
                string[] ArquivosnaPasta = Directory.GetFiles(FolderPath);
                /*
                 * Testa se existe um arquivo com o nome desejado; caso não exista, será criado um novo arquivo
                 * e será informado na interface do usuário onde o arquivo será salvo
                 */ 
                if (!ArquivosnaPasta.Contains(FolderPath + string.Format("\\Exemplo Arquivo JSON.txt")))
                {
                    /*
                     * Cria o arquivo com o nome: Exemplo Arquivo JSON.txt
                     */
                    using (StreamWriter sw = File.CreateText(FolderPath + string.Format("\\Exemplo Arquivo JSON.txt")))
                    {
                        /*
                         * Informa ao usuário onde o novo arquivo será salvo
                         */
                        BeginInvoke(new Delegate_void_String(Append_Text), new object[] { richTextBox1,
                            string.Format("Arquivo JSON salvo em: {0}\r\n", FolderPath)});
                        /*
                         * Escreve a string formatada em JSON e pula uma linha
                         */
                        sw.Write(json_string + "\r\n");
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FolderPath + string.Format("\\Exemplo Arquivo JSON.txt")))
                    {
                        /*
                         * Escreve a string formatada em JSON e pula uma linha
                         */
                        sw.Write(json_string + "\r\n");
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }

}
