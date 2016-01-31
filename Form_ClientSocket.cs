using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace ClientSocket_imageSlider
{

	//Summary description for Form1.

	public class ServerSocket : System.Windows.Forms.Form
	{
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private string [] folderFile = null;
		private int selected = 0;
        private int begin = 0;
		private int end = 0;
		private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox1;
        private Panel panel_controllers;
        private Button btn_Play;
        private TextBox TB_interval;
        private Button btn_openFolder;
        private Panel Panel_ImageHolder;
        private PictureBox Im_timer;
        private Label lbl_timeUnit;
        private Panel panel1;
        private Button button1;
        private Label label1;
        private Panel panel_start_Server;
        private Label lbl_start_server;
        private Button btn_connect_to_server;
        private System.ComponentModel.IContainer components;

		public ServerSocket()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();



            pictureBox1.Width = Panel_ImageHolder.Width;
            pictureBox1.Height = Panel_ImageHolder.Height;

            //opeque black in the controller panel
            panel_controllers.BackColor = Color.FromArgb(190, 0, 0, 0);

            btn_Play.FlatAppearance.MouseOverBackColor = btn_Play.BackColor;
            btn_Play.BackColorChanged += (s, e) => {
                btn_Play.FlatAppearance.MouseOverBackColor = btn_Play.BackColor;
            };

            var pos = this.PointToScreen(panel_controllers.Location);
            pos = pictureBox1.PointToClient(pos);
            panel_controllers.Parent = pictureBox1;
            panel_controllers.Location = pos;

            //*************** SOCKET CODES ************
           // tbAux.SelectionChanged += tbAux_SelectionChanged;

          

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Panel_ImageHolder = new System.Windows.Forms.Panel();
            this.panel_start_Server = new System.Windows.Forms.Panel();
            this.lbl_start_server = new System.Windows.Forms.Label();
            this.btn_connect_to_server = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_controllers = new System.Windows.Forms.Panel();
            this.lbl_timeUnit = new System.Windows.Forms.Label();
            this.Im_timer = new System.Windows.Forms.PictureBox();
            this.btn_Play = new System.Windows.Forms.Button();
            this.TB_interval = new System.Windows.Forms.TextBox();
            this.btn_openFolder = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Panel_ImageHolder.SuspendLayout();
            this.panel_start_Server.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_controllers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Im_timer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Panel_ImageHolder
            // 
            this.Panel_ImageHolder.AutoScroll = true;
            this.Panel_ImageHolder.AutoSize = true;
            this.Panel_ImageHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(5)))), ((int)(((byte)(21)))));
            this.Panel_ImageHolder.Controls.Add(this.panel_start_Server);
            this.Panel_ImageHolder.Controls.Add(this.panel1);
            this.Panel_ImageHolder.Controls.Add(this.panel_controllers);
            this.Panel_ImageHolder.Controls.Add(this.pictureBox1);
            this.Panel_ImageHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_ImageHolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Panel_ImageHolder.Location = new System.Drawing.Point(0, 0);
            this.Panel_ImageHolder.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_ImageHolder.Name = "Panel_ImageHolder";
            this.Panel_ImageHolder.Size = new System.Drawing.Size(687, 428);
            this.Panel_ImageHolder.TabIndex = 0;
            this.Panel_ImageHolder.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel_start_Server
            // 
            this.panel_start_Server.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_start_Server.Controls.Add(this.lbl_start_server);
            this.panel_start_Server.Controls.Add(this.btn_connect_to_server);
            this.panel_start_Server.Location = new System.Drawing.Point(100, 114);
            this.panel_start_Server.Margin = new System.Windows.Forms.Padding(0);
            this.panel_start_Server.Name = "panel_start_Server";
            this.panel_start_Server.Size = new System.Drawing.Size(200, 184);
            this.panel_start_Server.TabIndex = 9;
            // 
            // lbl_start_server
            // 
            this.lbl_start_server.AutoSize = true;
            this.lbl_start_server.BackColor = System.Drawing.Color.Transparent;
            this.lbl_start_server.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_start_server.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_start_server.ForeColor = System.Drawing.Color.White;
            this.lbl_start_server.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_start_server.Location = new System.Drawing.Point(14, 143);
            this.lbl_start_server.Name = "lbl_start_server";
            this.lbl_start_server.Size = new System.Drawing.Size(160, 21);
            this.lbl_start_server.TabIndex = 9;
            this.lbl_start_server.Text = "Connect to the Server";
            this.lbl_start_server.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_connect_to_server
            // 
            this.btn_connect_to_server.BackColor = System.Drawing.Color.Transparent;
            this.btn_connect_to_server.BackgroundImage = global::ClientSocket_imageSlider.Properties.Resources.server_icon;
            this.btn_connect_to_server.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_connect_to_server.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_connect_to_server.FlatAppearance.BorderSize = 0;
            this.btn_connect_to_server.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_connect_to_server.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_connect_to_server.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_connect_to_server.Location = new System.Drawing.Point(31, 30);
            this.btn_connect_to_server.Name = "btn_connect_to_server";
            this.btn_connect_to_server.Size = new System.Drawing.Size(127, 96);
            this.btn_connect_to_server.TabIndex = 2;
            this.btn_connect_to_server.UseVisualStyleBackColor = false;
            this.btn_connect_to_server.Click += new System.EventHandler(this.btn_conct_server_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(415, 114);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 184);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(23, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Locate an Image Folder";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::ClientSocket_imageSlider.Properties.Resources.open_folder;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(31, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 150);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_controllers
            // 
            this.panel_controllers.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel_controllers.AutoSize = true;
            this.panel_controllers.BackColor = System.Drawing.Color.Black;
            this.panel_controllers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_controllers.Controls.Add(this.lbl_timeUnit);
            this.panel_controllers.Controls.Add(this.Im_timer);
            this.panel_controllers.Controls.Add(this.btn_Play);
            this.panel_controllers.Controls.Add(this.TB_interval);
            this.panel_controllers.Controls.Add(this.btn_openFolder);
            this.panel_controllers.ForeColor = System.Drawing.Color.Ivory;
            this.panel_controllers.Location = new System.Drawing.Point(163, 298);
            this.panel_controllers.Margin = new System.Windows.Forms.Padding(0);
            this.panel_controllers.Name = "panel_controllers";
            this.panel_controllers.Size = new System.Drawing.Size(411, 65);
            this.panel_controllers.TabIndex = 7;
            this.panel_controllers.Visible = false;
            this.panel_controllers.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lbl_timeUnit
            // 
            this.lbl_timeUnit.AutoSize = true;
            this.lbl_timeUnit.BackColor = System.Drawing.Color.Transparent;
            this.lbl_timeUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_timeUnit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timeUnit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_timeUnit.Location = new System.Drawing.Point(378, 19);
            this.lbl_timeUnit.Name = "lbl_timeUnit";
            this.lbl_timeUnit.Size = new System.Drawing.Size(28, 19);
            this.lbl_timeUnit.TabIndex = 8;
            this.lbl_timeUnit.Text = "ms";
            this.lbl_timeUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_timeUnit.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Im_timer
            // 
            this.Im_timer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Im_timer.BackColor = System.Drawing.Color.Transparent;
            this.Im_timer.Image = global::ClientSocket_imageSlider.Properties.Resources.timer;
            this.Im_timer.Location = new System.Drawing.Point(308, 18);
            this.Im_timer.Margin = new System.Windows.Forms.Padding(0);
            this.Im_timer.Name = "Im_timer";
            this.Im_timer.Size = new System.Drawing.Size(25, 25);
            this.Im_timer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Im_timer.TabIndex = 7;
            this.Im_timer.TabStop = false;
            // 
            // btn_Play
            // 
            this.btn_Play.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Play.BackColor = System.Drawing.Color.Transparent;
            this.btn_Play.BackgroundImage = global::ClientSocket_imageSlider.Properties.Resources.play_button;
            this.btn_Play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Play.FlatAppearance.BorderSize = 0;
            this.btn_Play.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_Play.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Play.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Play.Location = new System.Drawing.Point(172, 8);
            this.btn_Play.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(45, 45);
            this.btn_Play.TabIndex = 2;
            this.btn_Play.UseVisualStyleBackColor = false;
            this.btn_Play.Click += new System.EventHandler(this.button4_Click);
            // 
            // TB_interval
            // 
            this.TB_interval.BackColor = System.Drawing.Color.Black;
            this.TB_interval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_interval.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_interval.ForeColor = System.Drawing.Color.White;
            this.TB_interval.Location = new System.Drawing.Point(336, 22);
            this.TB_interval.Margin = new System.Windows.Forms.Padding(0);
            this.TB_interval.MaxLength = 5;
            this.TB_interval.Name = "TB_interval";
            this.TB_interval.Size = new System.Drawing.Size(40, 20);
            this.TB_interval.TabIndex = 3;
            this.TB_interval.Text = "1000";
            this.TB_interval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_interval.TextChanged += new System.EventHandler(this.TB_interval_TextChanged);
            // 
            // btn_openFolder
            // 
            this.btn_openFolder.BackColor = System.Drawing.Color.Transparent;
            this.btn_openFolder.BackgroundImage = global::ClientSocket_imageSlider.Properties.Resources.open_folder;
            this.btn_openFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_openFolder.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_openFolder.FlatAppearance.BorderSize = 0;
            this.btn_openFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_openFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_openFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_openFolder.Location = new System.Drawing.Point(44, 13);
            this.btn_openFolder.Name = "btn_openFolder";
            this.btn_openFolder.Size = new System.Drawing.Size(35, 35);
            this.btn_openFolder.TabIndex = 1;
            this.btn_openFolder.UseVisualStyleBackColor = false;
            this.btn_openFolder.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // ServerSocket
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(687, 428);
            this.Controls.Add(this.Panel_ImageHolder);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ServerSocket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Socket";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panel_ImageHolder.ResumeLayout(false);
            this.Panel_ImageHolder.PerformLayout();
            this.panel_start_Server.ResumeLayout(false);
            this.panel_start_Server.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_controllers.ResumeLayout(false);
            this.panel_controllers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Im_timer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ServerSocket());
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				string [] part1=null, part2=null, part3=null;

				part1 = Directory.GetFiles(folderBrowserDialog1.SelectedPath,"*.jpg");
				part2 = Directory.GetFiles(folderBrowserDialog1.SelectedPath,"*.jpeg");
				part3 = Directory.GetFiles(folderBrowserDialog1.SelectedPath,"*.bmp");

				folderFile = new string[part1.Length + part2.Length + part3.Length];

				Array.Copy(part1,0,folderFile,0,part1.Length);
				Array.Copy(part2,0,folderFile,part1.Length,part2.Length);
				Array.Copy(part3,0,folderFile,part1.Length + part2.Length,part3.Length);

				selected = 0;
				begin = 0;
				end = folderFile.Length;

				showImage(folderFile[selected]);

				btn_Play.Enabled = true;
			}
		}

		private void showImage(string path)
		{
			Image imgtemp = Image.FromFile(path);
			pictureBox1.Width = Panel_ImageHolder.Width;
			pictureBox1.Height = Panel_ImageHolder.Height;
			pictureBox1.Image = imgtemp;
		}

		private void prevImage()
		{
			if(selected == 0)
			{
				selected = folderFile.Length - 1;
				showImage(folderFile[selected]);		
			}
			else
			{
				selected = selected - 1;                				
				showImage(folderFile[selected]);
			}
		}

		private void nextImage()
		{
			if(selected == folderFile.Length - 1)
			{
				selected = 0;				
				showImage(folderFile[selected]);
			}
			else
			{
				selected = selected + 1;                				
				showImage(folderFile[selected]);
			}
		}


        int count = 0;
        private void sendingDataToSOCKET()
        {
            try
            {
                // Sending message 
                //<Client Quit> is the sign for end of data 
                string theMessageToSend = count.ToString();
                byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend);

                // Sends data to a connected Socket. 
                int bytesSend = senderSock.Send(msg);

                //ReceiveDataFromServer();

                //bu.IsEnabled = false;
                //Disconnect_Button.IsEnabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            count++;
        }


        private void button3_Click(object sender, System.EventArgs e)
		{
			nextImage();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			nextImage();
            sendingDataToSOCKET();
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			if(timer1.Enabled == true)
			{
				timer1.Enabled = false;
				btn_Play.BackgroundImage = global::ClientSocket_imageSlider.Properties.Resources.play_button;
			}
			else
			{
				timer1.Enabled = true;
				btn_Play.BackgroundImage = global::ClientSocket_imageSlider.Properties.Resources.pause;
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			btn_Play.Enabled = false;

            
        }

        int transition_Interval = 1000; // in miliseconds
        private void button5_Click(object sender, EventArgs e)
        {
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_inner_Controllers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TB_interval_TextChanged(object sender, EventArgs e)
        {
            transition_Interval = int.Parse(TB_interval.Text);
            if (transition_Interval == 0 || transition_Interval == 00 || transition_Interval == 000 || transition_Interval == 0000)
            {

            }
            else
            {
                timer1.Interval = transition_Interval;
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] part1 = null, part2 = null, part3 = null;

                part1 = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.jpg");
                part2 = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.jpeg");
                part3 = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.bmp");

                folderFile = new string[part1.Length + part2.Length + part3.Length];

                Array.Copy(part1, 0, folderFile, 0, part1.Length);
                Array.Copy(part2, 0, folderFile, part1.Length, part2.Length);
                Array.Copy(part3, 0, folderFile, part1.Length + part2.Length, part3.Length);

                selected = 0;
                begin = 0;
                end = folderFile.Length;
                try {
                    showImage(folderFile[selected]);
                }
                catch(IOException error) {
                    MessageBox.Show("Please Select an Image folder");
                }

                btn_Play.Enabled = true;
            }
            else
            {
                
            }
            panel1.Visible = false;
            panel_start_Server.Visible = false;
            pictureBox1.Visible = true;
            panel_controllers.Visible = true;

        }




        // ******************* SOCKET CONNECTION ****************

        // Receiving byte array  
        byte[] bytes = new byte[1024];
        Socket senderSock;



        private void btn_conct_server_Click(object sender, EventArgs e)
        {
            try
            {
                // Create one SocketPermission for socket access restrictions 
                SocketPermission permission = new SocketPermission(
                    NetworkAccess.Connect,    // Connection permission 
                    TransportType.Tcp,        // Defines transport types 
                    "",                       // Gets the IP addresses 
                    SocketPermission.AllPorts // All ports 
                    );

                // Ensures the code to have permission to access a Socket 
                permission.Demand();

                // Resolves a host name to an IPHostEntry instance            
                IPHostEntry ipHost = Dns.GetHostEntry("");

                // Gets first IP address associated with a localhost 
                IPAddress ipAddr = ipHost.AddressList[0];

                // Creates a network endpoint 
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 4610);

                // Create one Socket object to setup Tcp connection 
                senderSock = new Socket(
                    ipAddr.AddressFamily,// Specifies the addressing scheme 
                    SocketType.Stream,   // The type of socket  
                    ProtocolType.Tcp     // Specifies the protocols  
                    );

                senderSock.NoDelay = false;   // Using the Nagle algorithm 

                // Establishes a connection to a remote host 
                senderSock.Connect(ipEndPoint);
                lbl_start_server.Text = "Socket connected to " + senderSock.RemoteEndPoint.ToString();

                btn_connect_to_server.Enabled = false;
                //Send_Button.IsEnabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

        }



        private void ReceiveDataFromServer()
        {
            try
            {
                // Receives data from a bound Socket. 
                int bytesRec = senderSock.Receive(bytes);

                // Converts byte array to string 
                String theMessageToReceive = Encoding.Unicode.GetString(bytes, 0, bytesRec);

                // Continues to read the data till data isn't available 
                while (senderSock.Available > 0)
                {
                    bytesRec = senderSock.Receive(bytes);
                    theMessageToReceive += Encoding.Unicode.GetString(bytes, 0, bytesRec);
                }

                lbl_start_server.Text = "The server reply: " + theMessageToReceive;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }





        }
    }
