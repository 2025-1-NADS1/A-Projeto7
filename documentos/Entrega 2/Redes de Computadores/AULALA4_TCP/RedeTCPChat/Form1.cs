using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace RedeTCPChat
{
    public partial class frmChat : Form
    {
        private int porta = 32000;
        private Thread thr;
        TCPLibrary ouvidor;
        Boolean fim = false;
        delegate void escreverTCPMsg(string TCPMsg);
        escreverTCPMsg a ;
        String IP;
        public frmChat()
        {
            InitializeComponent();
            String myHost = System.Net.Dns.GetHostName();

            IPAddress[] listIP = System.Net.Dns.GetHostEntry(myHost).AddressList;

            cmbIPAddress.DataSource = listIP;
            //cmbIPAddress.DataSourceChanged=IPAddress.

        }

        public void escreverMensagem(string TCPMsg)
        {
            this.txtChat.AppendText("\r\n");
            this.txtChat.AppendText(TCPMsg);
        }

        private void iniciarChat()
        {

             
             ouvidor = new TCPLibrary(IP, this.porta);

             
            
            while (!fim)
            {
                TcpClient client = ouvidor.acceptTCPClient();
                
                String TCPMsg = ouvidor.receiveTCPMessage(client);

                if (txtChat.InvokeRequired)
                {
                    a = new escreverTCPMsg(escreverMensagem);
                    this.Invoke(a, new object[] { TCPMsg });
                }

            }
        }


        public void enviarMenssagem(string IP, int porta, string TCPMsg)
        {
            TCPLibrary.sendTCPMessage(IP, porta, TCPMsg);
        }


        private void btnIniciar_Click(object sender, EventArgs e)
        {

            if (this.thr == null)
            {
                this.thr = new Thread(new ThreadStart(iniciarChat));
                this.thr.Start();
                btnIniciar.Text = "Parar Chat";
                //Espera a Thread thr cria o ouvidor;
                while (ouvidor == null) ;
                lblIP.Text ="SEU IP:" + ouvidor.myIP;
            }
            else
            {
                this.thr.Abort();
                this.thr = null;
                ouvidor.finalizarTCP();
                ouvidor.Dispose();
                btnIniciar.Text = "Iniciar Chat";
            }


        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            this.enviarMenssagem(txtIPDestino.Text,porta,txtMensagem.Text);
            txtMensagem.Text = "";
        }

        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            fim = true;
            if ((this.thr!=null) && (this.thr.IsAlive))
            {
                this.thr.Abort();
                this.thr = null;
            }
        }

        private void cmbIPAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.IP = cmbIPAddress.SelectedValue.ToString();
        }

        private void txtChat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}