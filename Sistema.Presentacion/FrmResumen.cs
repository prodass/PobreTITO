using Sistema.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion
{
    public partial class FrmResumen : Form
    {
        int numero = 0;
        DateTime fecha = DateTime.Now;
        public static bool estado = false;

        public FrmResumen()
        {
            InitializeComponent();
        }

        //Funcion para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void FrmResumen_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Nuevo reclamo - PobreTITO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Nuevo reclamo - PobreTITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Botones
        private void pboxBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMenu frm = new FrmMenu();
            frm.ShowDialog();
            frm.Close();
        }

        private void FrmResumen_Load(object sender, EventArgs e)
        {
            string Fecha = fecha.ToString("dd/MM/yyyy - hh:mm");

            lblNro.Text = numero.ToString();
            lblHora.Text = Fecha;
            lblMotivo.Text = VReclamo.motivo;
            lblIncidente.Text = VReclamo.incidente;
            lblCalle.Text = VReclamo.calle;
            lblAltura.Text = VReclamo.altura;
            lblDescripción.Text = VReclamo.descripcion;
            VReclamo.fecha = Fecha; 

            numero++;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("Está seguro que desea cancelar el reclamo?", "Nuevo reclamo - PobreTITO", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (Opcion == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rta = "";
            estado = true;
            DialogResult Opcion;
            Opcion = MessageBox.Show("Está seguro que los datos estan correctos?","Resumen - PobreTITO",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if(Opcion == DialogResult.OK)
            {
                rta = NReclamo.Insertar(Variables.idUsuario,VReclamo.idIncidente,VReclamo.idMotivo,VReclamo.idCalle,VReclamo.altura,"En revisión",VReclamo.descripcion,VReclamo.foto,VReclamo.fecha);
                this.Close();
                if (rta.Equals("OK"))
                {
                    this.MensajeOk("La nueva categoria se insertó correctamente!");
                }
                else
                {
                    this.MensajeError(rta);
                }
            }
        }
    }
}
