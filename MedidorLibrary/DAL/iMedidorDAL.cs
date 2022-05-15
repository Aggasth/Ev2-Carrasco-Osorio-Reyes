using MedidorLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorLibrary.DAL
{
    public interface iMedidorDAL
    {
        void IngresarLectura(Medidor mensaje);

        List<Medidor> ObtenerLecturas();
    }
}
