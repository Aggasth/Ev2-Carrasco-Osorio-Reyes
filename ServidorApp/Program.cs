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

        
    }
    
}
