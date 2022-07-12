using Sistema.Datos;
using Sistema.Entidades;
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
        public static DataTable ListarMotivos()
        {
            DReclamo Datos = new DReclamo();
            return Datos.ListarMotivos();
        }
        public static DataTable ListarIncidentes()
        {
            DReclamo Datos = new DReclamo();
            return Datos.ListarIncidentes();
        }
        public static DataTable ListarIncidentesCategorias(int valor)
        {
            DReclamo Datos = new DReclamo();
            return Datos.ListarIncidentesCategorias(valor);
        }
        public static string Insertar(int idUsuario, int idIncidente, int idMotivo, int idCalle, string altura, string estado, string descripcion, string foto, string fecha)
        {
            DReclamo datos = new DReclamo();
            Reclamo Obj = new Reclamo();
                
            Obj.idUsuario = idUsuario;
            Obj.idIncidente = idIncidente;
            Obj.idMotivo = idMotivo;
            Obj.idCalle = idCalle;
            Obj.Altura = altura;
            Obj.Estado = estado;
            Obj.Descripcion = descripcion;
            Obj.Foto = foto;
            Obj.Fecha = fecha;

            return datos.Insertar(Obj);
        }
    }
}
