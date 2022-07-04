using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Datos;
using Sistema.Entidades;

namespace Sistema.Negocio
{
    public class NUsuario
    {
        public static DataTable Listar()
        {
            DUsuario datos = new DUsuario();
            return datos.Listar();
        }
        public static DataTable Login(string email, string clave)
        {
            DUsuario datos = new DUsuario();
            return datos.Login(email, clave);
        }
        public static DataTable Buscar(string valor)
        {
            DUsuario datos = new DUsuario();
            return datos.Buscar(valor);
        }
        public static string Insertar(int idRol, string nombre, int idCalle, string altura, string telefono, string dni, string email, string clave)
        {
            DUsuario datos = new DUsuario();
            string existe = datos.Existe(email);
            
            if (existe.Equals("1")) //Basicamente lo que hacemos es validar si la categoria que nos ingresan existe o no.
            {
                return "Ya existe un usuario con ese email";
            }
            else
            {
                Usuario Obj = new Usuario();
                Obj.idRol = idRol;
                Obj.Nombre = nombre;
                Obj.idCalle = idCalle;
                Obj.Altura = altura;
                Obj.Telefono = telefono;
                Obj.Dni = dni;
                Obj.Email = email;
                Obj.Clave = clave;
                return datos.Insertar(Obj); //Como el metodo Insertar de la capa datos de categoria solo recibe objetos, primero cargamos el objeto con nuestros datos y luego lo enviamos.
            }
        }
        public static string Actualizar(int idUsuario, int idRol, string nombre, int idCalle, string altura, string telefono, string dni,string emailAnt, string email, string clave)
        {
            DUsuario datos = new DUsuario();
            Usuario Obj = new Usuario();

            if (emailAnt.Equals(email))
            {
                Obj.idUsuario = idUsuario;
                Obj.idRol = idRol;
                Obj.Nombre = nombre;
                Obj.idCalle = idCalle;
                Obj.Altura = altura;
                Obj.Telefono = telefono;
                Obj.Dni = dni;
                Obj.Email = email;
                Obj.Clave = clave;
                return datos.Actualizar(Obj);
            }
            else
            {
                string existe = datos.Existe(email);
                if (existe.Equals("1")) //Basicamente lo que hacemos es validar si la categoria que nos ingresan existe o no.
                {
                    return "Ya existe un usuario con ese email";
                }
                else
                {
                    Obj.idUsuario = idUsuario;
                    Obj.idRol = idRol;
                    Obj.Nombre = nombre;
                    Obj.idCalle = idCalle;
                    Obj.Altura = altura;
                    Obj.Telefono = telefono;
                    Obj.Dni = dni;
                    Obj.Email = email;
                    Obj.Clave = clave;
                    return datos.Actualizar(Obj);
                }
            }
        }
    }
}
