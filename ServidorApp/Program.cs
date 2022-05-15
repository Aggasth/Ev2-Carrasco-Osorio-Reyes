using MedidorLibrary.DAL;
using MedidorLibrary.DTO;
using ServidorApp.Comunicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServidorApp
{
    
    public class Program
    {
        private static iMedidorDAL medidorDAL = MedidorLecturaDAL.GetInstance();

        static void Main(string[] args)
        {
            HebraServidor hebra = new HebraServidor();
            Thread thread = new Thread(new ThreadStart(hebra.Ejecutar));
            thread.Start();

        }

        //static bool Menu()
        //{
        //    bool continuar = true;
        //    Console.WriteLine("Seleccione una opción: ");
        //    Console.WriteLine("1. Ingresar \n2. Mostrar \n0. Salir");
        //    switch (Console.ReadLine().Trim())
        //    {
        //        case "1":
        //            Ingresar();
        //            break;
        //        case "2":
        //            Mostrar();
        //            break;
        //        case "0":
        //            continuar = false;
        //            break;
        //        default:
        //            Console.WriteLine("Ingrese una opción nuevamente");
        //            break;
        //    }
        //    return continuar;
        //}

        //static void Ingresar()
        //{
        //    string idTemp;
        //    DateTime fecha = DateTime.Now;
        //    double consumoTemp;

        //    Medidor medidor = new Medidor()
        //    {

        //    };

        //}
    }

    
}
