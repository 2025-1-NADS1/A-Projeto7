using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace RedeTCPChat
{
    class TCPLibrary:IDisposable
    {
        private TcpListener tcpServer;
        public string myIP;

        public TCPLibrary(String ip, int porta)
        {
            
            string myHost = System.Net.Dns.GetHostName();
            myIP = ip; 
            tcpServer = new TcpListener(IPAddress.Parse(myIP), porta);
            tcpServer.Start();
        }

         ~TCPLibrary()
        {
            tcpServer.Stop();
            tcpServer = null;
        }

         public void Dispose()
         {
             if (tcpServer != null)
             {
                 tcpServer.Stop();
                 tcpServer = null;
             }
         }
        public void finalizarTCP()
        {
            tcpServer.Stop();
            tcpServer = null;
        }
        public TcpClient acceptTCPClient(){

           TcpClient client = tcpServer.AcceptTcpClient();
           return client;
         }

        public string receiveTCPMessage(TcpClient tcpClient)
        {
            string TCPMsg="";
            int i;
            
            NetworkStream stream = tcpClient.GetStream();
            string ip = tcpClient.Client.RemoteEndPoint.ToString();
            ip = ip.Substring(0,ip.IndexOf(':'));
 
            Byte[] byteMsg =new Byte[tcpClient.ReceiveBufferSize];
            TCPMsg = ip + " falou:>>";
            int tentativa = 0;
            while (!stream.DataAvailable && tentativa < 10)
            {
                Thread.Sleep(50);
                tentativa++;
            }

             while(stream.DataAvailable) 
             {
                 i = stream.Read(byteMsg, 0, byteMsg.Length);
               TCPMsg = TCPMsg+ System.Text.Encoding.ASCII.GetString(byteMsg, 0, i);
             }

            return TCPMsg;
        }

        public static void sendTCPMessage(string IP, int porta, string TCPMsg)
        {

            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(IP, porta);
            tcpClient.LingerState = (new LingerOption(true, 0));
            NetworkStream stream = tcpClient.GetStream();
            Byte[] byteMsg = System.Text.Encoding.UTF8.GetBytes(TCPMsg);
            if (stream.CanWrite)
            {
                stream.Write(byteMsg, 0, byteMsg.Length);
                stream.Flush();
            }
            else
            {
                throw new Exception("Problema de Comunicação!!!.");
            }

            tcpClient.Close();
        }
       

    }
}
