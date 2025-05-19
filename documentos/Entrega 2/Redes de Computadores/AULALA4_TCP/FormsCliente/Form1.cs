using System.IO;
using System.Net.Sockets;

namespace FormsCliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            String IPServer = "127.0.0.1";

            TcpClient client = new TcpClient();
            client.Connect(IPServer, 30000);
            txtResposta.Text += "CONECTOU....\r\n";

            String msg = txtComando.Text.ToUpper();

            Byte[] dados = System.Text.Encoding.UTF8.GetBytes(msg);
            NetworkStream stream = client.GetStream();
            stream.Write(dados, 0, dados.Length);
            Byte[] dadosLidos = new Byte[client.ReceiveBufferSize];
            int tentativas = 0;
            while (!stream.DataAvailable && tentativas < 5) { tentativas++; Thread.Sleep(10); }
            int numBytes = stream.Read(dadosLidos, 0, dadosLidos.Length);
            String resposta = "";
            tentativas = 0;
            while (numBytes > 0)
            {

                resposta = resposta + System.Text.Encoding.UTF8.GetString(dadosLidos, 0, numBytes);
                tentativas = 0;
                numBytes = 0;
                while (!stream.DataAvailable && tentativas < 5) { tentativas++; }
                if (stream.DataAvailable)
                {
                    numBytes = stream.Read(dadosLidos, 0, dadosLidos.Length);
                }

                txtResposta.Text += resposta + "\r\n";
            }
        }

        private void txtResposta_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtResposta.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtComando_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
