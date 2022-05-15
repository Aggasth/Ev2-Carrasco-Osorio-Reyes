using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorLibrary.DTO
{
    public class Medidor
    {
        private string id;
        private DateTime fecha;
        private double consumo;

        public string Id { get => id; set => id = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public double Consumo { get => consumo; set => consumo = value; }
    }
}
