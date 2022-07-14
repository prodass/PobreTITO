using Sistema.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion
{
    public partial class FrmNuevoReclamo : Form
    {
        public FrmNuevoReclamo()
        {
            InitializeComponent();
        }
        private void FrmNuevoReclamo_Load(object sender, EventArgs e)
        {
            lblNombre.Text = Variables.Nombre;
            lblMail.Text = Variables.Email;
            lblRol.Text = Variables.Rol;

            this.CargaMotivos();
            this.CargaCalles();
            this.Limpiar();
        }

        //Funcion para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void FrmNuevoReclamo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Botones
        private void pboxBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMenu frm = new FrmMenu();
            frm.ShowDialog();
            frm.Close();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("Esta seguro que desea cerrar sesión?", "Nuevo reclamo - PobreTITO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Opcion == DialogResult.Yes)
            {
                this.Hide();
                FrmLogin frm = new FrmLogin();
                frm.ShowDialog();
                this.Close();
            }
        }
        private void pboxMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void pboxLeave_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("Esta seguro que desea salir?", "Nuevo reclamo - PobreTITO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Opcion == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Desarrollado por: Pablo Rodas", "Menu - PobreTITO", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }
        private void pboxLeave_MouseEnter(object sender, EventArgs e)
        {
            pboxLeave.BackColor = Color.FromArgb(255, 80, 80);
        }
        private void pboxLeave_MouseLeave(object sender, EventArgs e)
        {
            pboxLeave.BackColor = Color.Transparent;
        }
        private void pboxMin_MouseEnter(object sender, EventArgs e)
        {
            pboxMin.BackColor = Color.FromArgb(174, 174, 174);
        }
        private void pboxMin_MouseLeave(object sender, EventArgs e)
        {
            pboxMin.BackColor = Color.Transparent;
        }
        private void btnNuevoReclamo_Click(object sender, EventArgs e)
        {
           
        }
        private void btnCuenta_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCuenta frm = new FrmCuenta();
            frm.ShowDialog();
            this.Close();
        }
        private void btnLista_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMisReclamos frm = new FrmMisReclamos();
            frm.ShowDialog();
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            errorIcono.Clear();
            bool error = false;
            if (cboxMotivo.SelectedIndex == -1)
            {
                error = true;
                errorIcono.SetError(cboxMotivo, "Seleccione correctamente el motivo!");
            }
            if (cboxIncidente.SelectedIndex == -1)
            {
                error = true;
                errorIcono.SetError(cboxIncidente, "Seleccione correctamente el incidente!");
            }
            if (cboxCalle.SelectedIndex == -1)
            {
                error = true;
                errorIcono.SetError(cboxCalle, "Seleccione correctamente la calle!");
            }
            if (!Regex.Match(tboxAltura.Text, @"^\d+$").Success)
            {
                error = true;
                errorIcono.SetError(tboxAltura, "Ingrese correctamente la altura!");
            }
            if (error)
            {
                MessageBox.Show("Se detectaron errores, serán remarcados!", "Nuevo reclamo - PobreTITO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                VReclamo.idIncidente = Convert.ToInt32(cboxIncidente.SelectedValue);
                VReclamo.idMotivo = Convert.ToInt32(cboxMotivo.SelectedValue);
                VReclamo.idCalle = Convert.ToInt32(cboxCalle.SelectedValue);
                VReclamo.motivo = cboxMotivo.Text.Trim();
                VReclamo.incidente = cboxIncidente.Text.Trim();
                VReclamo.calle = cboxCalle.Text.Trim();
                VReclamo.altura = tboxAltura.Text.Trim();
                VReclamo.foto = tboxFoto.Text.Trim();
                VReclamo.descripcion = tboxDescripcion.Text.Trim();
                this.Hide();
                FrmResumen frm = new FrmResumen();
                frm.ShowDialog();
                this.Close();
            }
        }

        //Cargas
        private void CargaMotivos()
        {
            try
            {
                cboxMotivo.DataSource = NReclamo.ListarMotivos();
                cboxMotivo.DisplayMember = "nombre";
                cboxMotivo.ValueMember = "idCategoria";
                cboxMotivo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void cboxMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboxIncidente.DataSource = NReclamo.ListarIncidentesCategorias(Convert.ToInt32(cboxMotivo.SelectedValue));
                cboxIncidente.ValueMember = "idIncidente";
                cboxIncidente.DisplayMember = "nombre";
                cboxIncidente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void CargaCalles()
        {
            try
            {
                cboxCalle.DataSource = NCalle.Listar();
                cboxCalle.ValueMember = "idCalle";
                cboxCalle.DisplayMember = "nombre";
                cboxCalle.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Limpiar
        public void Limpiar()
        {
            cboxMotivo.SelectedValue = -1;
            cboxIncidente.SelectedValue = -1;
            cboxCalle.SelectedValue = -1;
            tboxAltura.Clear();
            tboxFoto.Clear();
            tboxDescripcion.Clear();
        }
    }
}
