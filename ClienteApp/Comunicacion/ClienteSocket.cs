using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClienteApp.Comunicacion
{
    public class ClienteSocket
    {
        private int puerto;
        private string ip;
        private Socket clienteSocket;
        private StreamReader reader;
        private StreamWriter writer;

        public ClienteSocket(string ip, int puerto)
        {
            this.ip = ip;
            this.puerto = puerto;
        }

        public bool Conectar()
        {
            try
            {
                this.clienteSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(this.ip), puerto);
                this.clienteSocket.Connect(endPoint);
                Stream stream = new NetworkStream(this.clienteSocket);
                this.reader = new StreamReader(stream);
                this.writer = new StreamWriter(stream);
                return true;
            }
            catch (SocketException ex)
            {

                return false;
            }
        }
        public string Leer()
        {
            try
            {
                return this.reader.ReadLine().Trim();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Escribir(string mensaje)
        {
            try
            {
                this.writer.WriteLine(mensaje);
                this.writer.Flush();

            }
            catch (Exception ex)
            {

            }
        }


        public void Desconectar()
        {
            try
            {
                this.clienteSocket.Close();
            }
            catch (Exception ex)
            {

            }
        }

    }
}
