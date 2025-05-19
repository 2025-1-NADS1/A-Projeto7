using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace EXEMPLO_02_SERVER
{
    class Program
    {
        static TcpListener tcpServer;
        static string myIP = "127.0.0.1";
        static bool fim = false;
        static Dictionary<string, bool> luzes = new Dictionary<string, bool>()
        {
            { "QUARTO1", false },
            { "QUARTO2", false },
            { "COZINHA", false },
            { "SALA", false },
            { "PISCINA", false }
        };

        static void Main(string[] args)
        {
            tcpServer = new TcpListener(IPAddress.Parse(myIP), 30000);
            tcpServer.Start();
            Console.WriteLine("Servidor iniciado...");

            Thread threadServer = new Thread(() => serverListener());
            threadServer.Start();

            Console.WriteLine("Pressione [ENTER] para finalizar...");
            Console.ReadLine();
            fim = true;
        }

        public static void serverListener()
        {
            while (!fim)
            {
                TcpClient client = tcpServer.AcceptTcpClient();
                Thread thread = new Thread(() => responseMessage(client));
                thread.Start();
            }
        }

        public static void responseMessage(TcpClient client)
        {
            string msg = receiveTCPMessage(client);
            Console.WriteLine("Recebido: " + msg);
            string resposta = parseMsg(msg);
            sendTCPMessage(client, resposta);
        }

        private static string parseMsg(string msg)
        {
            string[] partes = msg.Trim().ToUpper().Split(' ');
            if (partes.Length == 0) return "Comando inválido.";

            if (partes[0] == "GET" && partes.Length == 2 && partes[1] == "LIGHTS")
            {
                StringBuilder status = new StringBuilder();
                foreach (var item in luzes)
                {
                    status.AppendLine($"{item.Key}: {(item.Value ? "ON" : "OFF")}");
                }
                return status.ToString();
            }

            if (partes[0] == "SET" && partes.Length == 4 && partes[1] == "LIGHT")
            {
                string comodo = partes[2];
                string estado = partes[3];

                if (luzes.ContainsKey(comodo))
                {
                    luzes[comodo] = (estado == "ON");
                    return $"Luz de {comodo} {(luzes[comodo] ? "ligada" : "desligada")}.";
                }
                else
                {
                    return $"Cômodo {comodo} não encontrado.";
                }
            }

            return "Comando desconhecido.";
        }

        public static string receiveTCPMessage(TcpClient tcpClient)
        {
            NetworkStream stream = tcpClient.GetStream();
            byte[] byteMsg = new byte[tcpClient.ReceiveBufferSize];
            int tentativa = 0;
            while (!stream.DataAvailable && tentativa < 10)
            {
                Thread.Sleep(50);
                tentativa++;
            }

            string TCPMsg = "";
            while (stream.DataAvailable)
            {
                int i = stream.Read(byteMsg, 0, byteMsg.Length);
                TCPMsg += Encoding.ASCII.GetString(byteMsg, 0, i);
            }

            return TCPMsg;
        }

        public static void sendTCPMessage(TcpClient tcpClient, string msg)
        {
            NetworkStream stream = tcpClient.GetStream();
            byte[] byteMsg = Encoding.UTF8.GetBytes(msg);
            if (stream.CanWrite)
            {
                stream.Write(byteMsg, 0, byteMsg.Length);
                stream.Flush();
            }
            tcpClient.Close();
        }
    }
}
