using Sistema.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Negocio
{
    public class NCalle
    {
        public static DataTable Listar()
        {
            DCalle datos = new DCalle();
            return datos.Listar();
        }
    }
}
