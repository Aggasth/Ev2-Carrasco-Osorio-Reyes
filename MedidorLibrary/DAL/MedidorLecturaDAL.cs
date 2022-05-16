using MedidorLibrary.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorLibrary.DAL
{
    public class MedidorLecturaDAL : iMedidorDAL
    {
        private MedidorLecturaDAL()
        {

        }
        private static MedidorLecturaDAL instance;
        public static iMedidorDAL GetInstance()
        {
            if (instance == null)
            {
                instance = new MedidorLecturaDAL();
            }
            return instance;
        }

        private static string archivo = "lecturas.txt";
        private static string ruta = Directory.GetCurrentDirectory() + "/" + archivo;

        public void IngresarLectura(Medidor m)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ruta, true))
                {
                    string texto = m.Id + "|"
                        + m.Fecha + "|"
                        + m.Consumo + "|";
                    writer.WriteLine(texto);
                    writer.Flush();

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al escribir en archivo.txt" + ex.Message);
            }
            finally
            {

            }
        }

        public List<Medidor> ObtenerLecturas()
        {
            List<Medidor> medidores = new List<Medidor>();
            using (StreamReader reader = new StreamReader(ruta))
            {
                string texto;
                do
                {
                    //Leer desde el archivo hasta que no haya nada.
                    texto = reader.ReadLine();
                    if (texto != null)
                    {
                        string[] textoarr = texto.Trim().Split('|');
                        string idtxt = textoarr[0];
                        DateTime fechatxt = Convert.ToDateTime(textoarr[1]);
                        double consumotxt = Convert.ToDouble(textoarr[2]);
                        //Crear un medidor
                        Medidor m = new Medidor()
                        {
                            Id = idtxt,
                            Fecha = fechatxt,
                            Consumo = consumotxt
                        };
                        medidores.Add(m);
                    };
                } while (texto != null);
            }
            return medidores;
        }
    }
}
