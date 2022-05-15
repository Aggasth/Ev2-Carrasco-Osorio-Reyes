using ServidorSocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServidorApp.Comunicacion
{
    public class HebraServidor
    {

        public void Ejecutar()
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            ServerSocket serverSocket = new ServerSocket(puerto);
            if (serverSocket.Iniciar())
            {
                while (true)
                {
                    Console.WriteLine("Esperando cliente...");
                    Socket socketCliente = serverSocket.ObtenerCliente();
                    Console.WriteLine("Cliente conectado.");

                    ClienteCom cliente = new ClienteCom(socketCliente);
                    HebraCliente hebraCliente = new HebraCliente(cliente);
                    Thread t = new Thread(new ThreadStart(hebraCliente.Menu));
                    t.IsBackground = true;
                    t.Start();
                }
            }
            else
            {
                Console.WriteLine("Error con el puerto {0}", puerto);
            }
        }
    }
}
