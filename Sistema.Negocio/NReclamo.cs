using Sistema.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Negocio
{
    public class NReclamo
    {
        public static DataTable Listar()
        {
            DReclamo Datos = new DReclamo();
            return Datos.Listar();
        }
    }
}
