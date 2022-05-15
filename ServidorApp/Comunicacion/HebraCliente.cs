using MedidorLibrary.DAL;
using MedidorLibrary.DTO;
using ServidorSocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorApp.Comunicacion
{
    public class HebraCliente
    {
        private static iMedidorDAL medidorDAL = MedidorLecturaDAL.GetInstance();
        private ClienteCom clienteCOM;

        public HebraCliente(ClienteCom clienteCom)
        {
            this.clienteCOM = clienteCom;
        }

        public void Menu()
        {
            clienteCOM.Escribir("Seleccione una Opción: ");
            clienteCOM.Escribir("1. Ingresar Medidor");
            clienteCOM.Escribir("2. Mostrar Datos");
            clienteCOM.Escribir("0. Salir");
            string opcion = clienteCOM.Leer();
            switch (opcion)
            {
                case "1": Ingresar();
                    break;
                case "2": Mostrar();
                    break ;
                case "0": clienteCOM.Desconectar();
                    break;
                default: clienteCOM.Escribir("Selecciona una opción correcta");
                    break;
            }
        }

        public void Ingresar()
        {
            DateTime fecha = DateTime.Now;
            clienteCOM.Escribir("Ingrese la id del medidor: ");
            string idTemp = clienteCOM.Leer();
            clienteCOM.Escribir("Ingrese el consumo: ");
            double consumoTemp = Convert.ToDouble(clienteCOM.Leer());

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
            clienteCOM.Desconectar();
        }

        public void Mostrar()
        {
            List<Medidor> lista = null;
            lock (medidorDAL)
            {
                lista = medidorDAL.ObtenerLecturas();
            }
            for (int i = 0; i < lista.Count; i++)
            {
                Medidor actual = lista[i];
                clienteCOM.Escribir("Id: "+actual.Id+" Fecha: "+actual.Fecha+" Consumo: "+actual.Consumo);
            }

        }
    }
}
