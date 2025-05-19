using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace EXEMPLO_02_CLIENT
{
    class Program
    {
        static void Main(string[] args)
        {
            string ipServer = "127.0.0.1";

            while (true)
            {
                Console.WriteLine("Digite o comando (ex: SET LIGHT SALA ON / GET LIGHTS), ou SAIR para encerrar:");
                string comando = Console.ReadLine();

                if (comando.Trim().ToUpper() == "SAIR")
                    break;

                try
                {
                    TcpClient client = new TcpClient();
                    client.Connect(ipServer, 30000);

                    byte[] dados = Encoding.UTF8.GetBytes(comando);
                    NetworkStream stream = client.GetStream();
                    stream.Write(dados, 0, dados.Length);

                    byte[] dadosLidos = new byte[client.ReceiveBufferSize];
                    int tentativas = 0;
                    while (!stream.DataAvailable && tentativas < 5) { tentativas++; Thread.Sleep(10); }

                    int numBytes = stream.Read(dadosLidos, 0, dadosLidos.Length);
                    string resposta = "";
                    while (numBytes > 0)
                    {
                        resposta += Encoding.UTF8.GetString(dadosLidos, 0, numBytes);
                        numBytes = 0;
                        while (!stream.DataAvailable && tentativas < 5) { tentativas++; }
                        if (stream.DataAvailable)
                        {
                            numBytes = stream.Read(dadosLidos, 0, dadosLidos.Length);
                        }
                    }

                    Console.WriteLine("Resposta do servidor:");
                    Console.WriteLine(resposta);
                    client.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }
    }
}
