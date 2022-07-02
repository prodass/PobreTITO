namespace Sistema.Entidades
{
    public class Reclamo
    {
        public int idReclamo { get; set; }
        public int idUsuario { get; set; }
        public int idIncidente { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string Foto { get; set; }
        public string Fecha { get; set; }
        public string Ubicacion { get; set; }
    }
}
