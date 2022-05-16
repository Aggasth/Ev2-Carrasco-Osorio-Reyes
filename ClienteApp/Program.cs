using ClienteApp.Comunicacion;
using MedidorLibrary.DAL;
using MedidorLibrary.DTO;
using ServidorApp.Comunicacion;
using ServidorSocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClienteApp
{
    public class Program
    {
        private static iMedidorDAL medidorDAL = MedidorLecturaDAL.GetInstance();
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            string ip = ConfigurationManager.AppSettings["ip"];
            Console.WriteLine("Conectado en el servidor ip '{0}' puerto '{1}'",ip,puerto);
            ClienteSocket clienteSocket = new ClienteSocket(ip, puerto);
            if (clienteSocket.Conectar())
            {
                Console.WriteLine("Seleccione una opción: ");
                Console.WriteLine("1. Ingresar \n2. Mostrar \n0. Salir");
                switch (Console.ReadLine().Trim())
                {
                    case "1":
                        Ingresar(clienteSocket);
                        break;
                    case "2":
                        Mostrar(clienteSocket);
                        break;
                    case "0": clienteSocket.Desconectar();
                        break;
                    default:
                        Console.WriteLine("Ingrese una opción nuevamente");
                        break;
                }

            }
        }

        public static void Ingresar(ClienteSocket clienteSocket)
        {
            DateTime fecha = DateTime.Now;
            Console.WriteLine("Ingrese la id del medidor: ");
            string idTemp = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese el consumo: ");
            double consumoTemp = Convert.ToDouble(Console.ReadLine().Trim());

            Medidor medidor = new Medidor()
            {
                Id = idTemp,
                Fecha = fecha,
                Consumo = consumoTemp
            };
            lock (medidorDAL)
            {
                medidorDAL.IngresarLectura(medidor);
            }
            clienteSocket.Desconectar();
        }

        public static void Mostrar(ClienteSocket clienteSocket)
        {
            List<Medidor> lista = null;
            lock (medidorDAL)
            {
                lista = medidorDAL.ObtenerLecturas();
            }
            for (int i = 0; i < lista.Count; i++)
            {
                Medidor actual = lista[i];
                Console.WriteLine("Id: " + actual.Id + " Fecha: " + actual.Fecha + " Consumo: " + actual.Consumo);
            }
            Console.WriteLine("Ok");
            Console.ReadKey();
        }
    }
}
