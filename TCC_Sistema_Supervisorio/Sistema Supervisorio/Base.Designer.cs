namespace Sistema_Supervisorio
{
    partial class ControlSystem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlSystem));
            this.groupBoxTCP = new System.Windows.Forms.GroupBox();
            this.button_tcp = new System.Windows.Forms.Button();
            this.tcp_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tcp_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSerial = new System.Windows.Forms.GroupBox();
            this.button_com = new System.Windows.Forms.Button();
            this.com_baud = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.com_port = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab_configuracao = new System.Windows.Forms.TabPage();
            this.tab_log = new System.Windows.Forms.TabPage();
            this.buttonSaveLOG = new System.Windows.Forms.Button();
            this.buttonCleanLOG = new System.Windows.Forms.Button();
            this.textLOG = new System.Windows.Forms.RichTextBox();
            this.tab_Acelerometro = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combo_Acelerometro_mode = new System.Windows.Forms.ComboBox();
            this.text_ID_Acelerometro = new System.Windows.Forms.TextBox();
            this.text_TX_ID_Acelerometro = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gauge_Acelerometro_Z = new LiveCharts.WinForms.SolidGauge();
            this.gauge_Acelerometro_Y = new LiveCharts.WinForms.SolidGauge();
            this.gauge_Acelerometro_X = new LiveCharts.WinForms.SolidGauge();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupCmdAcelerometro = new System.Windows.Forms.GroupBox();
            this.text_Acelerometro_ID = new System.Windows.Forms.TextBox();
            this.button_Acelerometro_Enviar = new System.Windows.Forms.Button();
            this.combo_Acelerometro_Eixo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.text_Acelerometro_ID_Sensor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tab_Temperatura = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.text_Temperatura_Inst = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.text_ID_STemp = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.text_TX_ID_STemp = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cartesian_STemp = new LiveCharts.WinForms.CartesianChart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.text_STemp_TX_ID = new System.Windows.Forms.TextBox();
            this.button_STemp_Enviar = new System.Windows.Forms.Button();
            this.text_STemp_ID = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tab_Corrente = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cartesian_SCorrente = new LiveCharts.WinForms.CartesianChart();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.text_Corrente_Inst = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.text_ID_SCorrente = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.text_TX_ID_SCorrente = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.text_SCorrente_RCP_ID = new System.Windows.Forms.TextBox();
            this.button_SCorrente_Enviar = new System.Windows.Forms.Button();
            this.text_SCorrente_ID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tab_Outros = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.text_Analogico_value = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.button_Send_Analogico = new System.Windows.Forms.Button();
            this.label53 = new System.Windows.Forms.Label();
            this.text_RX_Analogico_Valor = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.text_RX_Analogico_ID_Sensor = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.combo_Analogico = new System.Windows.Forms.ComboBox();
            this.text_RX_Analogico_SND = new System.Windows.Forms.TextBox();
            this.text_TX_Analogico_RCP = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.text_TX_Analogico_ID_Sensor = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.combo_GPIO = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.text_RX_GPIO_Valor = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.text_RX_GPIO_ID_Sensor = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.text_TX_GPIO_RCP = new System.Windows.Forms.TextBox();
            this.text_RX_GPIO_SND = new System.Windows.Forms.TextBox();
            this.text_TX_GPIO_ID_Sensor = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.button_Send_GPIO = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.text_TX_RTC_RCP = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.text_RX_RTC_Valor = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.text_RX_RTC_ID_Sensor = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.combo_RTC = new System.Windows.Forms.ComboBox();
            this.text_RX_RTC_SND = new System.Windows.Forms.TextBox();
            this.text_TX_RTC_ID_Sensor = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.button_Send_RTC = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.text_RX_Mag_Valor = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.text_RX_Mag_ID_Sensor = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.text_TX_Mag_RCP = new System.Windows.Forms.TextBox();
            this.text_RX_Mag_SND = new System.Windows.Forms.TextBox();
            this.text_TX_Mag_ID_Sensor = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.button_Send_Magnetometro = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.text_RX_SUltra_Valor = new System.Windows.Forms.TextBox();
            this.text_RX_SUltra_ID_Sensor = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.text_RX_SUltra_SND = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.button_Send_SUltra = new System.Windows.Forms.Button();
            this.text_TX_SUltra_ID_Sensor = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.text_TX_SUltra_RCP = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.check_JSON = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxTCP.SuspendLayout();
            this.groupBoxSerial.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tab_configuracao.SuspendLayout();
            this.tab_log.SuspendLayout();
            this.tab_Acelerometro.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupCmdAcelerometro.SuspendLayout();
            this.tab_Temperatura.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tab_Corrente.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tab_Outros.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTCP
            // 
            this.groupBoxTCP.Controls.Add(this.button_tcp);
            this.groupBoxTCP.Controls.Add(this.tcp_port);
            this.groupBoxTCP.Controls.Add(this.label2);
            this.groupBoxTCP.Controls.Add(this.tcp_ip);
            this.groupBoxTCP.Controls.Add(this.label1);
            this.groupBoxTCP.Location = new System.Drawing.Point(6, 6);
            this.groupBoxTCP.Name = "groupBoxTCP";
            this.groupBoxTCP.Size = new System.Drawing.Size(148, 166);
            this.groupBoxTCP.TabIndex = 1;
            this.groupBoxTCP.TabStop = false;
            this.groupBoxTCP.Text = "Comunicação TCP/IP";
            // 
            // button_tcp
            // 
            this.button_tcp.Location = new System.Drawing.Point(9, 97);
            this.button_tcp.Name = "button_tcp";
            this.button_tcp.Size = new System.Drawing.Size(121, 54);
            this.button_tcp.TabIndex = 4;
            this.button_tcp.Text = "Abrir Servidor";
            this.button_tcp.UseVisualStyleBackColor = true;
            this.button_tcp.Click += new System.EventHandler(this.button_tcp_Click);
            // 
            // tcp_port
            // 
            this.tcp_port.Location = new System.Drawing.Point(9, 71);
            this.tcp_port.Name = "tcp_port";
            this.tcp_port.Size = new System.Drawing.Size(121, 20);
            this.tcp_port.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Porta:";
            // 
            // tcp_ip
            // 
            this.tcp_ip.Location = new System.Drawing.Point(9, 32);
            this.tcp_ip.Name = "tcp_ip";
            this.tcp_ip.Size = new System.Drawing.Size(121, 20);
            this.tcp_ip.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // groupBoxSerial
            // 
            this.groupBoxSerial.Controls.Add(this.button_com);
            this.groupBoxSerial.Controls.Add(this.com_baud);
            this.groupBoxSerial.Controls.Add(this.label4);
            this.groupBoxSerial.Controls.Add(this.com_port);
            this.groupBoxSerial.Controls.Add(this.label3);
            this.groupBoxSerial.Location = new System.Drawing.Point(160, 6);
            this.groupBoxSerial.Name = "groupBoxSerial";
            this.groupBoxSerial.Size = new System.Drawing.Size(146, 166);
            this.groupBoxSerial.TabIndex = 2;
            this.groupBoxSerial.TabStop = false;
            this.groupBoxSerial.Text = "Comunicação Serial";
            // 
            // button_com
            // 
            this.button_com.Location = new System.Drawing.Point(9, 99);
            this.button_com.Name = "button_com";
            this.button_com.Size = new System.Drawing.Size(121, 54);
            this.button_com.TabIndex = 5;
            this.button_com.Text = "Abrir Porta";
            this.button_com.UseVisualStyleBackColor = true;
            this.button_com.Click += new System.EventHandler(this.button_com_Click);
            // 
            // com_baud
            // 
            this.com_baud.FormattingEnabled = true;
            this.com_baud.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.com_baud.Location = new System.Drawing.Point(9, 72);
            this.com_baud.Name = "com_baud";
            this.com_baud.Size = new System.Drawing.Size(121, 21);
            this.com_baud.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Baudrate:";
            // 
            // com_port
            // 
            this.com_port.FormattingEnabled = true;
            this.com_port.Location = new System.Drawing.Point(9, 32);
            this.com_port.Name = "com_port";
            this.com_port.Size = new System.Drawing.Size(121, 21);
            this.com_port.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Porta Serial:";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tab_configuracao);
            this.tabControl.Controls.Add(this.tab_log);
            this.tabControl.Controls.Add(this.tab_Acelerometro);
            this.tabControl.Controls.Add(this.tab_Temperatura);
            this.tabControl.Controls.Add(this.tab_Corrente);
            this.tabControl.Controls.Add(this.tab_Outros);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1288, 582);
            this.tabControl.TabIndex = 3;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tab_configuracao
            // 
            this.tab_configuracao.BackColor = System.Drawing.SystemColors.Control;
            this.tab_configuracao.Controls.Add(this.groupBox13);
            this.tab_configuracao.Controls.Add(this.groupBoxSerial);
            this.tab_configuracao.Controls.Add(this.groupBoxTCP);
            this.tab_configuracao.Location = new System.Drawing.Point(4, 22);
            this.tab_configuracao.Name = "tab_configuracao";
            this.tab_configuracao.Padding = new System.Windows.Forms.Padding(3);
            this.tab_configuracao.Size = new System.Drawing.Size(1280, 556);
            this.tab_configuracao.TabIndex = 0;
            this.tab_configuracao.Text = "Configuração";
            // 
            // tab_log
            // 
            this.tab_log.BackColor = System.Drawing.SystemColors.Control;
            this.tab_log.Controls.Add(this.buttonSaveLOG);
            this.tab_log.Controls.Add(this.buttonCleanLOG);
            this.tab_log.Controls.Add(this.textLOG);
            this.tab_log.Location = new System.Drawing.Point(4, 22);
            this.tab_log.Name = "tab_log";
            this.tab_log.Padding = new System.Windows.Forms.Padding(3);
            this.tab_log.Size = new System.Drawing.Size(1280, 556);
            this.tab_log.TabIndex = 1;
            this.tab_log.Text = "Log de Comunicação";
            // 
            // buttonSaveLOG
            // 
            this.buttonSaveLOG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveLOG.Location = new System.Drawing.Point(1118, 3);
            this.buttonSaveLOG.Name = "buttonSaveLOG";
            this.buttonSaveLOG.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveLOG.TabIndex = 2;
            this.buttonSaveLOG.Text = "Salvar LOG";
            this.buttonSaveLOG.UseVisualStyleBackColor = true;
            this.buttonSaveLOG.Click += new System.EventHandler(this.buttonSaveLOG_Click);
            // 
            // buttonCleanLOG
            // 
            this.buttonCleanLOG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCleanLOG.Location = new System.Drawing.Point(1199, 3);
            this.buttonCleanLOG.Name = "buttonCleanLOG";
            this.buttonCleanLOG.Size = new System.Drawing.Size(75, 23);
            this.buttonCleanLOG.TabIndex = 1;
            this.buttonCleanLOG.Text = "Apagar LOG";
            this.buttonCleanLOG.UseVisualStyleBackColor = true;
            this.buttonCleanLOG.Click += new System.EventHandler(this.buttonCleanLOG_Click);
            // 
            // textLOG
            // 
            this.textLOG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLOG.BackColor = System.Drawing.Color.White;
            this.textLOG.Enabled = false;
            this.textLOG.Location = new System.Drawing.Point(7, 36);
            this.textLOG.Name = "textLOG";
            this.textLOG.ReadOnly = true;
            this.textLOG.Size = new System.Drawing.Size(1267, 514);
            this.textLOG.TabIndex = 0;
            this.textLOG.Text = "";
            // 
            // tab_Acelerometro
            // 
            this.tab_Acelerometro.BackColor = System.Drawing.SystemColors.Control;
            this.tab_Acelerometro.Controls.Add(this.groupBox1);
            this.tab_Acelerometro.Controls.Add(this.groupCmdAcelerometro);
            this.tab_Acelerometro.Location = new System.Drawing.Point(4, 22);
            this.tab_Acelerometro.Name = "tab_Acelerometro";
            this.tab_Acelerometro.Size = new System.Drawing.Size(1280, 556);
            this.tab_Acelerometro.TabIndex = 2;
            this.tab_Acelerometro.Text = "Acelerômetros";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.combo_Acelerometro_mode);
            this.groupBox1.Controls.Add(this.text_ID_Acelerometro);
            this.groupBox1.Controls.Add(this.text_TX_ID_Acelerometro);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.gauge_Acelerometro_Z);
            this.groupBox1.Controls.Add(this.gauge_Acelerometro_Y);
            this.groupBox1.Controls.Add(this.gauge_Acelerometro_X);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(210, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1070, 552);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acelerômetros";
            // 
            // combo_Acelerometro_mode
            // 
            this.combo_Acelerometro_mode.FormattingEnabled = true;
            this.combo_Acelerometro_mode.Items.AddRange(new object[] {
            "+- 2g",
            "+- 4g",
            "+- 8g",
            "+-16g"});
            this.combo_Acelerometro_mode.Location = new System.Drawing.Point(7, 80);
            this.combo_Acelerometro_mode.Name = "combo_Acelerometro_mode";
            this.combo_Acelerometro_mode.Size = new System.Drawing.Size(121, 21);
            this.combo_Acelerometro_mode.TabIndex = 13;
            // 
            // text_ID_Acelerometro
            // 
            this.text_ID_Acelerometro.BackColor = System.Drawing.Color.White;
            this.text_ID_Acelerometro.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_ID_Acelerometro.Location = new System.Drawing.Point(647, 80);
            this.text_ID_Acelerometro.Multiline = true;
            this.text_ID_Acelerometro.Name = "text_ID_Acelerometro";
            this.text_ID_Acelerometro.ReadOnly = true;
            this.text_ID_Acelerometro.Size = new System.Drawing.Size(90, 70);
            this.text_ID_Acelerometro.TabIndex = 12;
            this.text_ID_Acelerometro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // text_TX_ID_Acelerometro
            // 
            this.text_TX_ID_Acelerometro.BackColor = System.Drawing.Color.White;
            this.text_TX_ID_Acelerometro.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_TX_ID_Acelerometro.Location = new System.Drawing.Point(270, 80);
            this.text_TX_ID_Acelerometro.Multiline = true;
            this.text_TX_ID_Acelerometro.Name = "text_TX_ID_Acelerometro";
            this.text_TX_ID_Acelerometro.ReadOnly = true;
            this.text_TX_ID_Acelerometro.Size = new System.Drawing.Size(90, 70);
            this.text_TX_ID_Acelerometro.TabIndex = 11;
            this.text_TX_ID_Acelerometro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(880, 233);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 25);
            this.label13.TabIndex = 10;
            this.label13.Text = "Eixo Z";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(499, 232);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 25);
            this.label12.TabIndex = 9;
            this.label12.Text = "Eixo Y";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(153, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 24);
            this.label11.TabIndex = 8;
            this.label11.Text = "Eixo X";
            // 
            // gauge_Acelerometro_Z
            // 
            this.gauge_Acelerometro_Z.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gauge_Acelerometro_Z.Location = new System.Drawing.Point(739, 331);
            this.gauge_Acelerometro_Z.Name = "gauge_Acelerometro_Z";
            this.gauge_Acelerometro_Z.Size = new System.Drawing.Size(326, 181);
            this.gauge_Acelerometro_Z.TabIndex = 7;
            // 
            // gauge_Acelerometro_Y
            // 
            this.gauge_Acelerometro_Y.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gauge_Acelerometro_Y.Location = new System.Drawing.Point(360, 331);
            this.gauge_Acelerometro_Y.Name = "gauge_Acelerometro_Y";
            this.gauge_Acelerometro_Y.Size = new System.Drawing.Size(326, 181);
            this.gauge_Acelerometro_Y.TabIndex = 6;
            this.gauge_Acelerometro_Y.Text = "gauge_Acelerometro_Y";
            // 
            // gauge_Acelerometro_X
            // 
            this.gauge_Acelerometro_X.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gauge_Acelerometro_X.Location = new System.Drawing.Point(6, 331);
            this.gauge_Acelerometro_X.Name = "gauge_Acelerometro_X";
            this.gauge_Acelerometro_X.Size = new System.Drawing.Size(326, 181);
            this.gauge_Acelerometro_X.TabIndex = 5;
            this.gauge_Acelerometro_X.Text = "gauge_Acelerometro_X";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(644, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "ID do Acelerômetro:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(267, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "ID do Transmissor:";
            // 
            // groupCmdAcelerometro
            // 
            this.groupCmdAcelerometro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupCmdAcelerometro.Controls.Add(this.text_Acelerometro_ID);
            this.groupCmdAcelerometro.Controls.Add(this.button_Acelerometro_Enviar);
            this.groupCmdAcelerometro.Controls.Add(this.combo_Acelerometro_Eixo);
            this.groupCmdAcelerometro.Controls.Add(this.label7);
            this.groupCmdAcelerometro.Controls.Add(this.text_Acelerometro_ID_Sensor);
            this.groupCmdAcelerometro.Controls.Add(this.label6);
            this.groupCmdAcelerometro.Controls.Add(this.label5);
            this.groupCmdAcelerometro.Location = new System.Drawing.Point(3, 3);
            this.groupCmdAcelerometro.Name = "groupCmdAcelerometro";
            this.groupCmdAcelerometro.Size = new System.Drawing.Size(200, 472);
            this.groupCmdAcelerometro.TabIndex = 0;
            this.groupCmdAcelerometro.TabStop = false;
            this.groupCmdAcelerometro.Text = "Comandos";
            // 
            // text_Acelerometro_ID
            // 
            this.text_Acelerometro_ID.Location = new System.Drawing.Point(10, 32);
            this.text_Acelerometro_ID.Name = "text_Acelerometro_ID";
            this.text_Acelerometro_ID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.text_Acelerometro_ID.Size = new System.Drawing.Size(121, 20);
            this.text_Acelerometro_ID.TabIndex = 10;
            this.text_Acelerometro_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_Acelerometro_Enviar
            // 
            this.button_Acelerometro_Enviar.Location = new System.Drawing.Point(7, 150);
            this.button_Acelerometro_Enviar.Name = "button_Acelerometro_Enviar";
            this.button_Acelerometro_Enviar.Size = new System.Drawing.Size(125, 50);
            this.button_Acelerometro_Enviar.TabIndex = 7;
            this.button_Acelerometro_Enviar.Text = "Enviar Comando";
            this.button_Acelerometro_Enviar.UseVisualStyleBackColor = true;
            this.button_Acelerometro_Enviar.Click += new System.EventHandler(this.button_Acelerometro_Enviar_Click);
            // 
            // combo_Acelerometro_Eixo
            // 
            this.combo_Acelerometro_Eixo.FormattingEnabled = true;
            this.combo_Acelerometro_Eixo.Items.AddRange(new object[] {
            "Todos",
            "Eixo X",
            "Eixo Y",
            "Eixo Z"});
            this.combo_Acelerometro_Eixo.Location = new System.Drawing.Point(10, 123);
            this.combo_Acelerometro_Eixo.Name = "combo_Acelerometro_Eixo";
            this.combo_Acelerometro_Eixo.Size = new System.Drawing.Size(121, 21);
            this.combo_Acelerometro_Eixo.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Eixo de Leitura:";
            // 
            // text_Acelerometro_ID_Sensor
            // 
            this.text_Acelerometro_ID_Sensor.Location = new System.Drawing.Point(10, 77);
            this.text_Acelerometro_ID_Sensor.Name = "text_Acelerometro_ID_Sensor";
            this.text_Acelerometro_ID_Sensor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.text_Acelerometro_ID_Sensor.Size = new System.Drawing.Size(121, 20);
            this.text_Acelerometro_ID_Sensor.TabIndex = 4;
            this.text_Acelerometro_ID_Sensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "ID do Sensor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "ID do Receptor:";
            // 
            // tab_Temperatura
            // 
            this.tab_Temperatura.BackColor = System.Drawing.SystemColors.Control;
            this.tab_Temperatura.Controls.Add(this.groupBox4);
            this.tab_Temperatura.Controls.Add(this.groupBox3);
            this.tab_Temperatura.Controls.Add(this.groupBox2);
            this.tab_Temperatura.Location = new System.Drawing.Point(4, 22);
            this.tab_Temperatura.Name = "tab_Temperatura";
            this.tab_Temperatura.Size = new System.Drawing.Size(1280, 556);
            this.tab_Temperatura.TabIndex = 3;
            this.tab_Temperatura.Text = "Sensores de Temperatura";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.text_Temperatura_Inst);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.text_ID_STemp);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.text_TX_ID_STemp);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(3, 198);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(170, 350);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dados Recebidos";
            // 
            // text_Temperatura_Inst
            // 
            this.text_Temperatura_Inst.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_Temperatura_Inst.Location = new System.Drawing.Point(10, 210);
            this.text_Temperatura_Inst.Multiline = true;
            this.text_Temperatura_Inst.Name = "text_Temperatura_Inst";
            this.text_Temperatura_Inst.Size = new System.Drawing.Size(154, 70);
            this.text_Temperatura_Inst.TabIndex = 13;
            this.text_Temperatura_Inst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 194);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(93, 13);
            this.label19.TabIndex = 12;
            this.label19.Text = "Valor Instantâneo:";
            // 
            // text_ID_STemp
            // 
            this.text_ID_STemp.BackColor = System.Drawing.Color.White;
            this.text_ID_STemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_ID_STemp.Location = new System.Drawing.Point(10, 121);
            this.text_ID_STemp.Multiline = true;
            this.text_ID_STemp.Name = "text_ID_STemp";
            this.text_ID_STemp.ReadOnly = true;
            this.text_ID_STemp.Size = new System.Drawing.Size(154, 70);
            this.text_ID_STemp.TabIndex = 11;
            this.text_ID_STemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "ID do Transmissor:";
            // 
            // text_TX_ID_STemp
            // 
            this.text_TX_ID_STemp.BackColor = System.Drawing.Color.White;
            this.text_TX_ID_STemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_TX_ID_STemp.Location = new System.Drawing.Point(10, 32);
            this.text_TX_ID_STemp.Multiline = true;
            this.text_TX_ID_STemp.Name = "text_TX_ID_STemp";
            this.text_TX_ID_STemp.ReadOnly = true;
            this.text_TX_ID_STemp.Size = new System.Drawing.Size(154, 70);
            this.text_TX_ID_STemp.TabIndex = 10;
            this.text_TX_ID_STemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(150, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "ID do Sensor de Temperatura:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cartesian_STemp);
            this.groupBox3.Location = new System.Drawing.Point(177, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1100, 550);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gráfico de Temperatura";
            // 
            // cartesian_STemp
            // 
            this.cartesian_STemp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartesian_STemp.BackColor = System.Drawing.Color.White;
            this.cartesian_STemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cartesian_STemp.Location = new System.Drawing.Point(6, 20);
            this.cartesian_STemp.Name = "cartesian_STemp";
            this.cartesian_STemp.Size = new System.Drawing.Size(1088, 530);
            this.cartesian_STemp.TabIndex = 8;
            this.cartesian_STemp.Text = "chart_Temperatura";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.text_STemp_TX_ID);
            this.groupBox2.Controls.Add(this.button_STemp_Enviar);
            this.groupBox2.Controls.Add(this.text_STemp_ID);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(170, 190);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Comandos";
            // 
            // text_STemp_TX_ID
            // 
            this.text_STemp_TX_ID.Location = new System.Drawing.Point(10, 37);
            this.text_STemp_TX_ID.Name = "text_STemp_TX_ID";
            this.text_STemp_TX_ID.Size = new System.Drawing.Size(153, 20);
            this.text_STemp_TX_ID.TabIndex = 8;
            this.text_STemp_TX_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_STemp_Enviar
            // 
            this.button_STemp_Enviar.Location = new System.Drawing.Point(10, 104);
            this.button_STemp_Enviar.Name = "button_STemp_Enviar";
            this.button_STemp_Enviar.Size = new System.Drawing.Size(153, 31);
            this.button_STemp_Enviar.TabIndex = 7;
            this.button_STemp_Enviar.Text = "Enviar Comando";
            this.button_STemp_Enviar.UseVisualStyleBackColor = true;
            this.button_STemp_Enviar.Click += new System.EventHandler(this.button_STemp_Enviar_Click);
            // 
            // text_STemp_ID
            // 
            this.text_STemp_ID.Location = new System.Drawing.Point(10, 78);
            this.text_STemp_ID.Name = "text_STemp_ID";
            this.text_STemp_ID.Size = new System.Drawing.Size(153, 20);
            this.text_STemp_ID.TabIndex = 6;
            this.text_STemp_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "ID do Sensor:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "ID do Receptor:";
            // 
            // tab_Corrente
            // 
            this.tab_Corrente.BackColor = System.Drawing.SystemColors.Control;
            this.tab_Corrente.Controls.Add(this.groupBox7);
            this.tab_Corrente.Controls.Add(this.groupBox6);
            this.tab_Corrente.Controls.Add(this.groupBox5);
            this.tab_Corrente.Location = new System.Drawing.Point(4, 22);
            this.tab_Corrente.Name = "tab_Corrente";
            this.tab_Corrente.Size = new System.Drawing.Size(1280, 556);
            this.tab_Corrente.TabIndex = 4;
            this.tab_Corrente.Text = "Sensores de Corrente";
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.cartesian_SCorrente);
            this.groupBox7.Location = new System.Drawing.Point(179, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1100, 550);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Gráfico de Corrente";
            // 
            // cartesian_SCorrente
            // 
            this.cartesian_SCorrente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartesian_SCorrente.BackColor = System.Drawing.Color.White;
            this.cartesian_SCorrente.Location = new System.Drawing.Point(6, 20);
            this.cartesian_SCorrente.Name = "cartesian_SCorrente";
            this.cartesian_SCorrente.Size = new System.Drawing.Size(1088, 530);
            this.cartesian_SCorrente.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.text_Corrente_Inst);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.text_ID_SCorrente);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.text_TX_ID_SCorrente);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Location = new System.Drawing.Point(4, 200);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(170, 350);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Dados Recebidos";
            // 
            // text_Corrente_Inst
            // 
            this.text_Corrente_Inst.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_Corrente_Inst.Location = new System.Drawing.Point(10, 210);
            this.text_Corrente_Inst.Multiline = true;
            this.text_Corrente_Inst.Name = "text_Corrente_Inst";
            this.text_Corrente_Inst.Size = new System.Drawing.Size(154, 70);
            this.text_Corrente_Inst.TabIndex = 19;
            this.text_Corrente_Inst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 194);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 13);
            this.label20.TabIndex = 18;
            this.label20.Text = "Valor Instantâneo:";
            // 
            // text_ID_SCorrente
            // 
            this.text_ID_SCorrente.BackColor = System.Drawing.Color.White;
            this.text_ID_SCorrente.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_ID_SCorrente.Location = new System.Drawing.Point(10, 121);
            this.text_ID_SCorrente.Multiline = true;
            this.text_ID_SCorrente.Name = "text_ID_SCorrente";
            this.text_ID_SCorrente.ReadOnly = true;
            this.text_ID_SCorrente.Size = new System.Drawing.Size(154, 70);
            this.text_ID_SCorrente.TabIndex = 17;
            this.text_ID_SCorrente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(95, 13);
            this.label21.TabIndex = 14;
            this.label21.Text = "ID do Transmissor:";
            // 
            // text_TX_ID_SCorrente
            // 
            this.text_TX_ID_SCorrente.BackColor = System.Drawing.Color.White;
            this.text_TX_ID_SCorrente.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_TX_ID_SCorrente.Location = new System.Drawing.Point(10, 32);
            this.text_TX_ID_SCorrente.Multiline = true;
            this.text_TX_ID_SCorrente.Name = "text_TX_ID_SCorrente";
            this.text_TX_ID_SCorrente.ReadOnly = true;
            this.text_TX_ID_SCorrente.Size = new System.Drawing.Size(154, 70);
            this.text_TX_ID_SCorrente.TabIndex = 16;
            this.text_TX_ID_SCorrente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 105);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(150, 13);
            this.label22.TabIndex = 15;
            this.label22.Text = "ID do Sensor de Temperatura:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.text_SCorrente_RCP_ID);
            this.groupBox5.Controls.Add(this.button_SCorrente_Enviar);
            this.groupBox5.Controls.Add(this.text_SCorrente_ID);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Location = new System.Drawing.Point(4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(170, 190);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Comandos";
            // 
            // text_SCorrente_RCP_ID
            // 
            this.text_SCorrente_RCP_ID.Location = new System.Drawing.Point(10, 36);
            this.text_SCorrente_RCP_ID.Name = "text_SCorrente_RCP_ID";
            this.text_SCorrente_RCP_ID.Size = new System.Drawing.Size(154, 20);
            this.text_SCorrente_RCP_ID.TabIndex = 13;
            this.text_SCorrente_RCP_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SCorrente_Enviar
            // 
            this.button_SCorrente_Enviar.Location = new System.Drawing.Point(10, 104);
            this.button_SCorrente_Enviar.Name = "button_SCorrente_Enviar";
            this.button_SCorrente_Enviar.Size = new System.Drawing.Size(154, 31);
            this.button_SCorrente_Enviar.TabIndex = 12;
            this.button_SCorrente_Enviar.Text = "Enviar Comando";
            this.button_SCorrente_Enviar.UseVisualStyleBackColor = true;
            this.button_SCorrente_Enviar.Click += new System.EventHandler(this.button_SCorrente_Enviar_Click);
            // 
            // text_SCorrente_ID
            // 
            this.text_SCorrente_ID.Location = new System.Drawing.Point(10, 78);
            this.text_SCorrente_ID.Name = "text_SCorrente_ID";
            this.text_SCorrente_ID.Size = new System.Drawing.Size(154, 20);
            this.text_SCorrente_ID.TabIndex = 11;
            this.text_SCorrente_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "ID do Sensor:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 13);
            this.label17.TabIndex = 9;
            this.label17.Text = "ID do Receptor:";
            // 
            // tab_Outros
            // 
            this.tab_Outros.BackColor = System.Drawing.SystemColors.Control;
            this.tab_Outros.Controls.Add(this.groupBox12);
            this.tab_Outros.Controls.Add(this.groupBox11);
            this.tab_Outros.Controls.Add(this.groupBox10);
            this.tab_Outros.Controls.Add(this.groupBox9);
            this.tab_Outros.Controls.Add(this.groupBox8);
            this.tab_Outros.Location = new System.Drawing.Point(4, 22);
            this.tab_Outros.Name = "tab_Outros";
            this.tab_Outros.Size = new System.Drawing.Size(1280, 556);
            this.tab_Outros.TabIndex = 5;
            this.tab_Outros.Text = "Outros Sensores";
            // 
            // groupBox12
            // 
            this.groupBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox12.Controls.Add(this.label23);
            this.groupBox12.Controls.Add(this.text_Analogico_value);
            this.groupBox12.Controls.Add(this.label51);
            this.groupBox12.Controls.Add(this.label57);
            this.groupBox12.Controls.Add(this.label52);
            this.groupBox12.Controls.Add(this.button_Send_Analogico);
            this.groupBox12.Controls.Add(this.label53);
            this.groupBox12.Controls.Add(this.text_RX_Analogico_Valor);
            this.groupBox12.Controls.Add(this.label55);
            this.groupBox12.Controls.Add(this.text_RX_Analogico_ID_Sensor);
            this.groupBox12.Controls.Add(this.label56);
            this.groupBox12.Controls.Add(this.combo_Analogico);
            this.groupBox12.Controls.Add(this.text_RX_Analogico_SND);
            this.groupBox12.Controls.Add(this.text_TX_Analogico_RCP);
            this.groupBox12.Controls.Add(this.label54);
            this.groupBox12.Controls.Add(this.text_TX_Analogico_ID_Sensor);
            this.groupBox12.Location = new System.Drawing.Point(1077, 3);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(200, 550);
            this.groupBox12.TabIndex = 4;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Portas Analógicas";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(110, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(34, 13);
            this.label23.TabIndex = 52;
            this.label23.Text = "Valor:";
            // 
            // text_Analogico_value
            // 
            this.text_Analogico_value.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Analogico_value.Enabled = false;
            this.text_Analogico_value.Location = new System.Drawing.Point(113, 39);
            this.text_Analogico_value.Name = "text_Analogico_value";
            this.text_Analogico_value.Size = new System.Drawing.Size(30, 20);
            this.text_Analogico_value.TabIndex = 51;
            this.text_Analogico_value.Text = "0";
            this.text_Analogico_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label51
            // 
            this.label51.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(5, 375);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(83, 13);
            this.label51.TabIndex = 50;
            this.label51.Text = "Valor Recebido:";
            // 
            // label57
            // 
            this.label57.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(3, 16);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(94, 13);
            this.label57.TabIndex = 43;
            this.label57.Text = "Tipo do Comando:";
            // 
            // label52
            // 
            this.label52.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(5, 331);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(72, 13);
            this.label52.TabIndex = 49;
            this.label52.Text = "ID do Sensor:";
            // 
            // button_Send_Analogico
            // 
            this.button_Send_Analogico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Send_Analogico.Location = new System.Drawing.Point(6, 154);
            this.button_Send_Analogico.Name = "button_Send_Analogico";
            this.button_Send_Analogico.Size = new System.Drawing.Size(187, 66);
            this.button_Send_Analogico.TabIndex = 34;
            this.button_Send_Analogico.Text = "Enviar Comando";
            this.button_Send_Analogico.UseVisualStyleBackColor = true;
            this.button_Send_Analogico.Click += new System.EventHandler(this.button_Send_Analogico_Click);
            // 
            // label53
            // 
            this.label53.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(5, 287);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(95, 13);
            this.label53.TabIndex = 48;
            this.label53.Text = "ID do Transmissor:";
            // 
            // text_RX_Analogico_Valor
            // 
            this.text_RX_Analogico_Valor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_RX_Analogico_Valor.BackColor = System.Drawing.Color.White;
            this.text_RX_Analogico_Valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_RX_Analogico_Valor.Location = new System.Drawing.Point(4, 395);
            this.text_RX_Analogico_Valor.Multiline = true;
            this.text_RX_Analogico_Valor.Name = "text_RX_Analogico_Valor";
            this.text_RX_Analogico_Valor.ReadOnly = true;
            this.text_RX_Analogico_Valor.Size = new System.Drawing.Size(187, 145);
            this.text_RX_Analogico_Valor.TabIndex = 40;
            this.text_RX_Analogico_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label55
            // 
            this.label55.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(6, 106);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(72, 13);
            this.label55.TabIndex = 47;
            this.label55.Text = "ID do Sensor:";
            // 
            // text_RX_Analogico_ID_Sensor
            // 
            this.text_RX_Analogico_ID_Sensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_RX_Analogico_ID_Sensor.BackColor = System.Drawing.Color.White;
            this.text_RX_Analogico_ID_Sensor.Location = new System.Drawing.Point(5, 352);
            this.text_RX_Analogico_ID_Sensor.Name = "text_RX_Analogico_ID_Sensor";
            this.text_RX_Analogico_ID_Sensor.ReadOnly = true;
            this.text_RX_Analogico_ID_Sensor.Size = new System.Drawing.Size(187, 20);
            this.text_RX_Analogico_ID_Sensor.TabIndex = 39;
            this.text_RX_Analogico_ID_Sensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label56
            // 
            this.label56.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(6, 62);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(83, 13);
            this.label56.TabIndex = 46;
            this.label56.Text = "ID do Receptor:";
            // 
            // combo_Analogico
            // 
            this.combo_Analogico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_Analogico.FormattingEnabled = true;
            this.combo_Analogico.Items.AddRange(new object[] {
            "Ler",
            "Escrever"});
            this.combo_Analogico.Location = new System.Drawing.Point(6, 38);
            this.combo_Analogico.Name = "combo_Analogico";
            this.combo_Analogico.Size = new System.Drawing.Size(30, 21);
            this.combo_Analogico.TabIndex = 29;
            this.combo_Analogico.SelectedIndexChanged += new System.EventHandler(this.combo_Analogico_SelectedIndexChanged);
            // 
            // text_RX_Analogico_SND
            // 
            this.text_RX_Analogico_SND.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_RX_Analogico_SND.BackColor = System.Drawing.Color.White;
            this.text_RX_Analogico_SND.Location = new System.Drawing.Point(5, 308);
            this.text_RX_Analogico_SND.Name = "text_RX_Analogico_SND";
            this.text_RX_Analogico_SND.ReadOnly = true;
            this.text_RX_Analogico_SND.Size = new System.Drawing.Size(187, 20);
            this.text_RX_Analogico_SND.TabIndex = 37;
            this.text_RX_Analogico_SND.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // text_TX_Analogico_RCP
            // 
            this.text_TX_Analogico_RCP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_TX_Analogico_RCP.Location = new System.Drawing.Point(6, 83);
            this.text_TX_Analogico_RCP.Name = "text_TX_Analogico_RCP";
            this.text_TX_Analogico_RCP.Size = new System.Drawing.Size(187, 20);
            this.text_TX_Analogico_RCP.TabIndex = 31;
            this.text_TX_Analogico_RCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label54
            // 
            this.label54.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(5, 274);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(245, 13);
            this.label54.TabIndex = 35;
            this.label54.Text = "----------------Dados Recebidos-----------------------------------";
            // 
            // text_TX_Analogico_ID_Sensor
            // 
            this.text_TX_Analogico_ID_Sensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_TX_Analogico_ID_Sensor.Location = new System.Drawing.Point(6, 127);
            this.text_TX_Analogico_ID_Sensor.Name = "text_TX_Analogico_ID_Sensor";
            this.text_TX_Analogico_ID_Sensor.Size = new System.Drawing.Size(187, 20);
            this.text_TX_Analogico_ID_Sensor.TabIndex = 33;
            this.text_TX_Analogico_ID_Sensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox11.Controls.Add(this.label44);
            this.groupBox11.Controls.Add(this.label50);
            this.groupBox11.Controls.Add(this.label45);
            this.groupBox11.Controls.Add(this.combo_GPIO);
            this.groupBox11.Controls.Add(this.label46);
            this.groupBox11.Controls.Add(this.text_RX_GPIO_Valor);
            this.groupBox11.Controls.Add(this.label48);
            this.groupBox11.Controls.Add(this.text_RX_GPIO_ID_Sensor);
            this.groupBox11.Controls.Add(this.label49);
            this.groupBox11.Controls.Add(this.text_TX_GPIO_RCP);
            this.groupBox11.Controls.Add(this.text_RX_GPIO_SND);
            this.groupBox11.Controls.Add(this.text_TX_GPIO_ID_Sensor);
            this.groupBox11.Controls.Add(this.label47);
            this.groupBox11.Controls.Add(this.button_Send_GPIO);
            this.groupBox11.Location = new System.Drawing.Point(808, 4);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(200, 550);
            this.groupBox11.TabIndex = 3;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Portas Digitais";
            // 
            // label44
            // 
            this.label44.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(5, 374);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(83, 13);
            this.label44.TabIndex = 45;
            this.label44.Text = "Valor Recebido:";
            // 
            // label50
            // 
            this.label50.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(3, 16);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(94, 13);
            this.label50.TabIndex = 42;
            this.label50.Text = "Tipo do Comando:";
            // 
            // label45
            // 
            this.label45.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(5, 330);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(72, 13);
            this.label45.TabIndex = 44;
            this.label45.Text = "ID do Sensor:";
            // 
            // combo_GPIO
            // 
            this.combo_GPIO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_GPIO.FormattingEnabled = true;
            this.combo_GPIO.Items.AddRange(new object[] {
            "Ler Porta",
            "Escrever HIGH",
            "Escrever LOW"});
            this.combo_GPIO.Location = new System.Drawing.Point(6, 37);
            this.combo_GPIO.Name = "combo_GPIO";
            this.combo_GPIO.Size = new System.Drawing.Size(187, 21);
            this.combo_GPIO.TabIndex = 15;
            // 
            // label46
            // 
            this.label46.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(5, 286);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(95, 13);
            this.label46.TabIndex = 43;
            this.label46.Text = "ID do Transmissor:";
            // 
            // text_RX_GPIO_Valor
            // 
            this.text_RX_GPIO_Valor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_RX_GPIO_Valor.BackColor = System.Drawing.Color.White;
            this.text_RX_GPIO_Valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_RX_GPIO_Valor.Location = new System.Drawing.Point(4, 394);
            this.text_RX_GPIO_Valor.Multiline = true;
            this.text_RX_GPIO_Valor.Name = "text_RX_GPIO_Valor";
            this.text_RX_GPIO_Valor.ReadOnly = true;
            this.text_RX_GPIO_Valor.Size = new System.Drawing.Size(187, 145);
            this.text_RX_GPIO_Valor.TabIndex = 26;
            this.text_RX_GPIO_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label48
            // 
            this.label48.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(6, 105);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(72, 13);
            this.label48.TabIndex = 42;
            this.label48.Text = "ID do Sensor:";
            // 
            // text_RX_GPIO_ID_Sensor
            // 
            this.text_RX_GPIO_ID_Sensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_RX_GPIO_ID_Sensor.BackColor = System.Drawing.Color.White;
            this.text_RX_GPIO_ID_Sensor.Location = new System.Drawing.Point(5, 351);
            this.text_RX_GPIO_ID_Sensor.Name = "text_RX_GPIO_ID_Sensor";
            this.text_RX_GPIO_ID_Sensor.ReadOnly = true;
            this.text_RX_GPIO_ID_Sensor.Size = new System.Drawing.Size(187, 20);
            this.text_RX_GPIO_ID_Sensor.TabIndex = 25;
            this.text_RX_GPIO_ID_Sensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label49
            // 
            this.label49.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(6, 61);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(83, 13);
            this.label49.TabIndex = 41;
            this.label49.Text = "ID do Receptor:";
            // 
            // text_TX_GPIO_RCP
            // 
            this.text_TX_GPIO_RCP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_TX_GPIO_RCP.Location = new System.Drawing.Point(6, 82);
            this.text_TX_GPIO_RCP.Name = "text_TX_GPIO_RCP";
            this.text_TX_GPIO_RCP.Size = new System.Drawing.Size(187, 20);
            this.text_TX_GPIO_RCP.TabIndex = 17;
            this.text_TX_GPIO_RCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // text_RX_GPIO_SND
            // 
            this.text_RX_GPIO_SND.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_RX_GPIO_SND.BackColor = System.Drawing.Color.White;
            this.text_RX_GPIO_SND.Location = new System.Drawing.Point(5, 307);
            this.text_RX_GPIO_SND.Name = "text_RX_GPIO_SND";
            this.text_RX_GPIO_SND.ReadOnly = true;
            this.text_RX_GPIO_SND.Size = new System.Drawing.Size(187, 20);
            this.text_RX_GPIO_SND.TabIndex = 23;
            this.text_RX_GPIO_SND.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // text_TX_GPIO_ID_Sensor
            // 
            this.text_TX_GPIO_ID_Sensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_TX_GPIO_ID_Sensor.Location = new System.Drawing.Point(6, 126);
            this.text_TX_GPIO_ID_Sensor.Name = "text_TX_GPIO_ID_Sensor";
            this.text_TX_GPIO_ID_Sensor.Size = new System.Drawing.Size(187, 20);
            this.text_TX_GPIO_ID_Sensor.TabIndex = 19;
            this.text_TX_GPIO_ID_Sensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label47
            // 
            this.label47.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(5, 273);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(245, 13);
            this.label47.TabIndex = 21;
            this.label47.Text = "----------------Dados Recebidos-----------------------------------";
            // 
            // button_Send_GPIO
            // 
            this.button_Send_GPIO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Send_GPIO.Location = new System.Drawing.Point(6, 153);
            this.button_Send_GPIO.Name = "button_Send_GPIO";
            this.button_Send_GPIO.Size = new System.Drawing.Size(187, 66);
            this.button_Send_GPIO.TabIndex = 20;
            this.button_Send_GPIO.Text = "Enviar Comando";
            this.button_Send_GPIO.UseVisualStyleBackColor = true;
            this.button_Send_GPIO.Click += new System.EventHandler(this.button_Send_GPIO_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.label37);
            this.groupBox10.Controls.Add(this.label43);
            this.groupBox10.Controls.Add(this.label38);
            this.groupBox10.Controls.Add(this.text_TX_RTC_RCP);
            this.groupBox10.Controls.Add(this.label39);
            this.groupBox10.Controls.Add(this.text_RX_RTC_Valor);
            this.groupBox10.Controls.Add(this.label41);
            this.groupBox10.Controls.Add(this.text_RX_RTC_ID_Sensor);
            this.groupBox10.Controls.Add(this.label42);
            this.groupBox10.Controls.Add(this.combo_RTC);
            this.groupBox10.Controls.Add(this.text_RX_RTC_SND);
            this.groupBox10.Controls.Add(this.text_TX_RTC_ID_Sensor);
            this.groupBox10.Controls.Add(this.label40);
            this.groupBox10.Controls.Add(this.button_Send_RTC);
            this.groupBox10.Location = new System.Drawing.Point(546, 4);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(200, 550);
            this.groupBox10.TabIndex = 2;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Real Time Clock";
            // 
            // label37
            // 
            this.label37.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(5, 374);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(83, 13);
            this.label37.TabIndex = 31;
            this.label37.Text = "Valor Recebido:";
            // 
            // label43
            // 
            this.label43.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 16);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(94, 13);
            this.label43.TabIndex = 28;
            this.label43.Text = "Tipo do Comando:";
            // 
            // label38
            // 
            this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(5, 330);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(72, 13);
            this.label38.TabIndex = 30;
            this.label38.Text = "ID do Sensor:";
            // 
            // text_TX_RTC_RCP
            // 
            this.text_TX_RTC_RCP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_TX_RTC_RCP.Location = new System.Drawing.Point(6, 82);
            this.text_TX_RTC_RCP.Name = "text_TX_RTC_RCP";
            this.text_TX_RTC_RCP.Size = new System.Drawing.Size(187, 20);
            this.text_TX_RTC_RCP.TabIndex = 31;
            this.text_TX_RTC_RCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label39
            // 
            this.label39.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(5, 286);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(95, 13);
            this.label39.TabIndex = 29;
            this.label39.Text = "ID do Transmissor:";
            // 
            // text_RX_RTC_Valor
            // 
            this.text_RX_RTC_Valor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_RX_RTC_Valor.BackColor = System.Drawing.Color.White;
            this.text_RX_RTC_Valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_RX_RTC_Valor.Location = new System.Drawing.Point(4, 394);
            this.text_RX_RTC_Valor.Multiline = true;
            this.text_RX_RTC_Valor.Name = "text_RX_RTC_Valor";
            this.text_RX_RTC_Valor.ReadOnly = true;
            this.text_RX_RTC_Valor.Size = new System.Drawing.Size(187, 145);
            this.text_RX_RTC_Valor.TabIndex = 40;
            this.text_RX_RTC_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label41
            // 
            this.label41.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(6, 105);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(72, 13);
            this.label41.TabIndex = 28;
            this.label41.Text = "ID do Sensor:";
            // 
            // text_RX_RTC_ID_Sensor
            // 
            this.text_RX_RTC_ID_Sensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_RX_RTC_ID_Sensor.BackColor = System.Drawing.Color.White;
            this.text_RX_RTC_ID_Sensor.Location = new System.Drawing.Point(5, 351);
            this.text_RX_RTC_ID_Sensor.Name = "text_RX_RTC_ID_Sensor";
            this.text_RX_RTC_ID_Sensor.ReadOnly = true;
            this.text_RX_RTC_ID_Sensor.Size = new System.Drawing.Size(187, 20);
            this.text_RX_RTC_ID_Sensor.TabIndex = 39;
            this.text_RX_RTC_ID_Sensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label42
            // 
            this.label42.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(6, 61);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(83, 13);
            this.label42.TabIndex = 27;
            this.label42.Text = "ID do Receptor:";
            // 
            // combo_RTC
            // 
            this.combo_RTC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_RTC.FormattingEnabled = true;
            this.combo_RTC.Items.AddRange(new object[] {
            "Requisitar Data e Hora",
            "Enviar Data e Hora"});
            this.combo_RTC.Location = new System.Drawing.Point(6, 37);
            this.combo_RTC.Name = "combo_RTC";
            this.combo_RTC.Size = new System.Drawing.Size(187, 21);
            this.combo_RTC.TabIndex = 0;
            // 
            // text_RX_RTC_SND
            // 
            this.text_RX_RTC_SND.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_RX_RTC_SND.BackColor = System.Drawing.Color.White;
            this.text_RX_RTC_SND.Location = new System.Drawing.Point(5, 307);
            this.text_RX_RTC_SND.Name = "text_RX_RTC_SND";
            this.text_RX_RTC_SND.ReadOnly = true;
            this.text_RX_RTC_SND.Size = new System.Drawing.Size(187, 20);
            this.text_RX_RTC_SND.TabIndex = 37;
            this.text_RX_RTC_SND.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // text_TX_RTC_ID_Sensor
            // 
            this.text_TX_RTC_ID_Sensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_TX_RTC_ID_Sensor.Location = new System.Drawing.Point(6, 126);
            this.text_TX_RTC_ID_Sensor.Name = "text_TX_RTC_ID_Sensor";
            this.text_TX_RTC_ID_Sensor.Size = new System.Drawing.Size(187, 20);
            this.text_TX_RTC_ID_Sensor.TabIndex = 33;
            this.text_TX_RTC_ID_Sensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label40
            // 
            this.label40.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(5, 273);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(245, 13);
            this.label40.TabIndex = 35;
            this.label40.Text = "----------------Dados Recebidos-----------------------------------";
            // 
            // button_Send_RTC
            // 
            this.button_Send_RTC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Send_RTC.Location = new System.Drawing.Point(6, 153);
            this.button_Send_RTC.Name = "button_Send_RTC";
            this.button_Send_RTC.Size = new System.Drawing.Size(187, 66);
            this.button_Send_RTC.TabIndex = 34;
            this.button_Send_RTC.Text = "Enviar Comando";
            this.button_Send_RTC.UseVisualStyleBackColor = true;
            this.button_Send_RTC.Click += new System.EventHandler(this.button_Send_RTC_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.label30);
            this.groupBox9.Controls.Add(this.label31);
            this.groupBox9.Controls.Add(this.label32);
            this.groupBox9.Controls.Add(this.text_RX_Mag_Valor);
            this.groupBox9.Controls.Add(this.label34);
            this.groupBox9.Controls.Add(this.text_RX_Mag_ID_Sensor);
            this.groupBox9.Controls.Add(this.label35);
            this.groupBox9.Controls.Add(this.text_TX_Mag_RCP);
            this.groupBox9.Controls.Add(this.text_RX_Mag_SND);
            this.groupBox9.Controls.Add(this.text_TX_Mag_ID_Sensor);
            this.groupBox9.Controls.Add(this.label33);
            this.groupBox9.Controls.Add(this.button_Send_Magnetometro);
            this.groupBox9.Location = new System.Drawing.Point(270, 4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(200, 550);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Magnetômetro";
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(5, 374);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(83, 13);
            this.label30.TabIndex = 18;
            this.label30.Text = "Valor Recebido:";
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(5, 330);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(72, 13);
            this.label31.TabIndex = 17;
            this.label31.Text = "ID do Sensor:";
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(5, 286);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(95, 13);
            this.label32.TabIndex = 16;
            this.label32.Text = "ID do Transmissor:";
            // 
            // text_RX_Mag_Valor
            // 
            this.text_RX_Mag_Valor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_RX_Mag_Valor.BackColor = System.Drawing.Color.White;
            this.text_RX_Mag_Valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_RX_Mag_Valor.Location = new System.Drawing.Point(4, 394);
            this.text_RX_Mag_Valor.Multiline = true;
            this.text_RX_Mag_Valor.Name = "text_RX_Mag_Valor";
            this.text_RX_Mag_Valor.ReadOnly = true;
            this.text_RX_Mag_Valor.Size = new System.Drawing.Size(187, 145);
            this.text_RX_Mag_Valor.TabIndex = 26;
            this.text_RX_Mag_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(6, 105);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(72, 13);
            this.label34.TabIndex = 15;
            this.label34.Text = "ID do Sensor:";
            // 
            // text_RX_Mag_ID_Sensor
            // 
            this.text_RX_Mag_ID_Sensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_RX_Mag_ID_Sensor.BackColor = System.Drawing.Color.White;
            this.text_RX_Mag_ID_Sensor.Location = new System.Drawing.Point(5, 351);
            this.text_RX_Mag_ID_Sensor.Name = "text_RX_Mag_ID_Sensor";
            this.text_RX_Mag_ID_Sensor.ReadOnly = true;
            this.text_RX_Mag_ID_Sensor.Size = new System.Drawing.Size(187, 20);
            this.text_RX_Mag_ID_Sensor.TabIndex = 25;
            this.text_RX_Mag_ID_Sensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label35
            // 
            this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 61);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(83, 13);
            this.label35.TabIndex = 14;
            this.label35.Text = "ID do Receptor:";
            // 
            // text_TX_Mag_RCP
            // 
            this.text_TX_Mag_RCP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_TX_Mag_RCP.Location = new System.Drawing.Point(6, 82);
            this.text_TX_Mag_RCP.Name = "text_TX_Mag_RCP";
            this.text_TX_Mag_RCP.Size = new System.Drawing.Size(187, 20);
            this.text_TX_Mag_RCP.TabIndex = 17;
            this.text_TX_Mag_RCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // text_RX_Mag_SND
            // 
            this.text_RX_Mag_SND.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_RX_Mag_SND.BackColor = System.Drawing.Color.White;
            this.text_RX_Mag_SND.Location = new System.Drawing.Point(5, 307);
            this.text_RX_Mag_SND.Name = "text_RX_Mag_SND";
            this.text_RX_Mag_SND.ReadOnly = true;
            this.text_RX_Mag_SND.Size = new System.Drawing.Size(187, 20);
            this.text_RX_Mag_SND.TabIndex = 23;
            this.text_RX_Mag_SND.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // text_TX_Mag_ID_Sensor
            // 
            this.text_TX_Mag_ID_Sensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_TX_Mag_ID_Sensor.Location = new System.Drawing.Point(6, 126);
            this.text_TX_Mag_ID_Sensor.Name = "text_TX_Mag_ID_Sensor";
            this.text_TX_Mag_ID_Sensor.Size = new System.Drawing.Size(187, 20);
            this.text_TX_Mag_ID_Sensor.TabIndex = 19;
            this.text_TX_Mag_ID_Sensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(5, 273);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(245, 13);
            this.label33.TabIndex = 21;
            this.label33.Text = "----------------Dados Recebidos-----------------------------------";
            // 
            // button_Send_Magnetometro
            // 
            this.button_Send_Magnetometro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Send_Magnetometro.Location = new System.Drawing.Point(6, 153);
            this.button_Send_Magnetometro.Name = "button_Send_Magnetometro";
            this.button_Send_Magnetometro.Size = new System.Drawing.Size(187, 66);
            this.button_Send_Magnetometro.TabIndex = 20;
            this.button_Send_Magnetometro.Text = "Enviar Comando";
            this.button_Send_Magnetometro.UseVisualStyleBackColor = true;
            this.button_Send_Magnetometro.Click += new System.EventHandler(this.button_Send_Magnetometro_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.label29);
            this.groupBox8.Controls.Add(this.text_RX_SUltra_Valor);
            this.groupBox8.Controls.Add(this.text_RX_SUltra_ID_Sensor);
            this.groupBox8.Controls.Add(this.label28);
            this.groupBox8.Controls.Add(this.text_RX_SUltra_SND);
            this.groupBox8.Controls.Add(this.label27);
            this.groupBox8.Controls.Add(this.label26);
            this.groupBox8.Controls.Add(this.button_Send_SUltra);
            this.groupBox8.Controls.Add(this.text_TX_SUltra_ID_Sensor);
            this.groupBox8.Controls.Add(this.label25);
            this.groupBox8.Controls.Add(this.text_TX_SUltra_RCP);
            this.groupBox8.Controls.Add(this.label24);
            this.groupBox8.Location = new System.Drawing.Point(4, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(200, 550);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Sensor Ultrassônico";
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 378);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(83, 13);
            this.label29.TabIndex = 13;
            this.label29.Text = "Valor Recebido:";
            // 
            // text_RX_SUltra_Valor
            // 
            this.text_RX_SUltra_Valor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_RX_SUltra_Valor.BackColor = System.Drawing.Color.White;
            this.text_RX_SUltra_Valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_RX_SUltra_Valor.Location = new System.Drawing.Point(5, 394);
            this.text_RX_SUltra_Valor.Multiline = true;
            this.text_RX_SUltra_Valor.Name = "text_RX_SUltra_Valor";
            this.text_RX_SUltra_Valor.ReadOnly = true;
            this.text_RX_SUltra_Valor.Size = new System.Drawing.Size(187, 145);
            this.text_RX_SUltra_Valor.TabIndex = 12;
            this.text_RX_SUltra_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // text_RX_SUltra_ID_Sensor
            // 
            this.text_RX_SUltra_ID_Sensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_RX_SUltra_ID_Sensor.BackColor = System.Drawing.Color.White;
            this.text_RX_SUltra_ID_Sensor.Location = new System.Drawing.Point(6, 351);
            this.text_RX_SUltra_ID_Sensor.Name = "text_RX_SUltra_ID_Sensor";
            this.text_RX_SUltra_ID_Sensor.ReadOnly = true;
            this.text_RX_SUltra_ID_Sensor.Size = new System.Drawing.Size(187, 20);
            this.text_RX_SUltra_ID_Sensor.TabIndex = 11;
            this.text_RX_SUltra_ID_Sensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 334);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(72, 13);
            this.label28.TabIndex = 10;
            this.label28.Text = "ID do Sensor:";
            // 
            // text_RX_SUltra_SND
            // 
            this.text_RX_SUltra_SND.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_RX_SUltra_SND.BackColor = System.Drawing.Color.White;
            this.text_RX_SUltra_SND.Location = new System.Drawing.Point(6, 307);
            this.text_RX_SUltra_SND.Name = "text_RX_SUltra_SND";
            this.text_RX_SUltra_SND.ReadOnly = true;
            this.text_RX_SUltra_SND.Size = new System.Drawing.Size(187, 20);
            this.text_RX_SUltra_SND.TabIndex = 9;
            this.text_RX_SUltra_SND.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 290);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(95, 13);
            this.label27.TabIndex = 8;
            this.label27.Text = "ID do Transmissor:";
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 273);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(245, 13);
            this.label26.TabIndex = 7;
            this.label26.Text = "----------------Dados Recebidos-----------------------------------";
            // 
            // button_Send_SUltra
            // 
            this.button_Send_SUltra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Send_SUltra.Location = new System.Drawing.Point(7, 153);
            this.button_Send_SUltra.Name = "button_Send_SUltra";
            this.button_Send_SUltra.Size = new System.Drawing.Size(187, 66);
            this.button_Send_SUltra.TabIndex = 6;
            this.button_Send_SUltra.Text = "Enviar Comando";
            this.button_Send_SUltra.UseVisualStyleBackColor = true;
            this.button_Send_SUltra.Click += new System.EventHandler(this.button_Send_SUltra_Click);
            // 
            // text_TX_SUltra_ID_Sensor
            // 
            this.text_TX_SUltra_ID_Sensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_TX_SUltra_ID_Sensor.Location = new System.Drawing.Point(6, 126);
            this.text_TX_SUltra_ID_Sensor.Name = "text_TX_SUltra_ID_Sensor";
            this.text_TX_SUltra_ID_Sensor.Size = new System.Drawing.Size(187, 20);
            this.text_TX_SUltra_ID_Sensor.TabIndex = 5;
            this.text_TX_SUltra_ID_Sensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(3, 110);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(72, 13);
            this.label25.TabIndex = 4;
            this.label25.Text = "ID do Sensor:";
            // 
            // text_TX_SUltra_RCP
            // 
            this.text_TX_SUltra_RCP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_TX_SUltra_RCP.Location = new System.Drawing.Point(6, 82);
            this.text_TX_SUltra_RCP.Name = "text_TX_SUltra_RCP";
            this.text_TX_SUltra_RCP.Size = new System.Drawing.Size(187, 20);
            this.text_TX_SUltra_RCP.TabIndex = 3;
            this.text_TX_SUltra_RCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(1, 66);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(83, 13);
            this.label24.TabIndex = 2;
            this.label24.Text = "ID do Receptor:";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.button1);
            this.groupBox13.Controls.Add(this.check_JSON);
            this.groupBox13.Location = new System.Drawing.Point(313, 7);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(143, 165);
            this.groupBox13.TabIndex = 3;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Configurações";
            // 
            // check_JSON
            // 
            this.check_JSON.AutoSize = true;
            this.check_JSON.Location = new System.Drawing.Point(7, 34);
            this.check_JSON.Name = "check_JSON";
            this.check_JSON.Size = new System.Drawing.Size(121, 17);
            this.check_JSON.TabIndex = 0;
            this.check_JSON.Text = "Criar arquivos JSON";
            this.check_JSON.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Criar Tabelas Excel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ControlSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1308, 604);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControlSystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Supervisório";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ControlSystem_Load);
            this.groupBoxTCP.ResumeLayout(false);
            this.groupBoxTCP.PerformLayout();
            this.groupBoxSerial.ResumeLayout(false);
            this.groupBoxSerial.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tab_configuracao.ResumeLayout(false);
            this.tab_log.ResumeLayout(false);
            this.tab_Acelerometro.ResumeLayout(false);
            this.tab_Acelerometro.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupCmdAcelerometro.ResumeLayout(false);
            this.groupCmdAcelerometro.PerformLayout();
            this.tab_Temperatura.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tab_Corrente.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tab_Outros.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTCP;
        private System.Windows.Forms.Button button_tcp;
        private System.Windows.Forms.TextBox tcp_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tcp_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSerial;
        private System.Windows.Forms.Button button_com;
        private System.Windows.Forms.ComboBox com_baud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox com_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tab_configuracao;
        private System.Windows.Forms.TabPage tab_log;
        private System.Windows.Forms.Button buttonSaveLOG;
        private System.Windows.Forms.Button buttonCleanLOG;
        private System.Windows.Forms.RichTextBox textLOG;
        private System.Windows.Forms.TabPage tab_Acelerometro;
        private System.Windows.Forms.TabPage tab_Temperatura;
        private System.Windows.Forms.TabPage tab_Corrente;
        private System.Windows.Forms.TabPage tab_Outros;
        private System.Windows.Forms.GroupBox groupCmdAcelerometro;
        public System.Windows.Forms.Button button_Acelerometro_Enviar;
        private System.Windows.Forms.ComboBox combo_Acelerometro_Eixo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox text_Acelerometro_ID_Sensor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private LiveCharts.WinForms.SolidGauge gauge_Acelerometro_Z;
        private LiveCharts.WinForms.SolidGauge gauge_Acelerometro_Y;
        private LiveCharts.WinForms.SolidGauge gauge_Acelerometro_X;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_STemp_Enviar;
        private System.Windows.Forms.TextBox text_STemp_ID;
        private System.Windows.Forms.GroupBox groupBox3;
        private LiveCharts.WinForms.CartesianChart cartesian_STemp;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox text_Acelerometro_ID;
        private System.Windows.Forms.TextBox text_ID_Acelerometro;
        private System.Windows.Forms.TextBox text_TX_ID_Acelerometro;
        private System.Windows.Forms.TextBox text_ID_STemp;
        private System.Windows.Forms.TextBox text_TX_ID_STemp;
        private System.Windows.Forms.TextBox text_STemp_TX_ID;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox text_Temperatura_Inst;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox combo_Acelerometro_mode;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private LiveCharts.WinForms.CartesianChart cartesian_SCorrente;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox text_Corrente_Inst;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox text_ID_SCorrente;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox text_TX_ID_SCorrente;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox text_SCorrente_RCP_ID;
        private System.Windows.Forms.Button button_SCorrente_Enviar;
        private System.Windows.Forms.TextBox text_SCorrente_ID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox text_RX_SUltra_Valor;
        private System.Windows.Forms.TextBox text_RX_SUltra_ID_Sensor;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox text_RX_SUltra_SND;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button button_Send_SUltra;
        private System.Windows.Forms.TextBox text_TX_SUltra_ID_Sensor;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox text_TX_SUltra_RCP;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button button_Send_Analogico;
        private System.Windows.Forms.TextBox text_RX_Analogico_Valor;
        private System.Windows.Forms.TextBox text_RX_Analogico_ID_Sensor;
        private System.Windows.Forms.ComboBox combo_Analogico;
        private System.Windows.Forms.TextBox text_RX_Analogico_SND;
        private System.Windows.Forms.TextBox text_TX_Analogico_RCP;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox text_TX_Analogico_ID_Sensor;
        private System.Windows.Forms.ComboBox combo_GPIO;
        private System.Windows.Forms.TextBox text_RX_GPIO_Valor;
        private System.Windows.Forms.TextBox text_RX_GPIO_ID_Sensor;
        private System.Windows.Forms.TextBox text_TX_GPIO_RCP;
        private System.Windows.Forms.TextBox text_RX_GPIO_SND;
        private System.Windows.Forms.TextBox text_TX_GPIO_ID_Sensor;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Button button_Send_GPIO;
        private System.Windows.Forms.TextBox text_TX_RTC_RCP;
        private System.Windows.Forms.TextBox text_RX_RTC_Valor;
        private System.Windows.Forms.TextBox text_RX_RTC_ID_Sensor;
        private System.Windows.Forms.ComboBox combo_RTC;
        private System.Windows.Forms.TextBox text_RX_RTC_SND;
        private System.Windows.Forms.TextBox text_TX_RTC_ID_Sensor;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Button button_Send_RTC;
        private System.Windows.Forms.TextBox text_RX_Mag_Valor;
        private System.Windows.Forms.TextBox text_RX_Mag_ID_Sensor;
        private System.Windows.Forms.TextBox text_TX_Mag_RCP;
        private System.Windows.Forms.TextBox text_RX_Mag_SND;
        private System.Windows.Forms.TextBox text_TX_Mag_ID_Sensor;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button button_Send_Magnetometro;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox text_Analogico_value;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox check_JSON;
    }
}

