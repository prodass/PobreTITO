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
    public partial class FrmRegistrarse : Form
    {
        public FrmRegistrarse(Point location)
        {
            InitializeComponent();
            this.Location = location;
        }
        private void FrmRegistrarse_Load(object sender, EventArgs e)
        {
            this.CargarRol();
            this.CargarCalles();
        }

        //Funcion para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void FrmRegistrarse_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Cargas cbox
        private void CargarRol()
        {
            try
            {
                cboxRol.DataSource = NRol.Listar();
                cboxRol.ValueMember = "idRol";
                cboxRol.DisplayMember = "nombre";
                cboxRol.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void CargarCalles()
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

        //Botones
        private void pboxLeave_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("Esta seguro que desea salir?", "PobreTITO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Opcion == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void pboxMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
        private void pboxBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin frm = new FrmLogin();
            frm.Show();
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Registro - PobreTITO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Registro - PobreTITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string rta = "";
                bool error = false;
                if (!Regex.Match(tboxNombre.Text, @"^[A-Za-z]{4,30}$|^[A-Za-z]{4,30}\s[A-Za-z]{4,20}$").Success)
                {
                    error = true;
                    errorIcono.SetError(tboxNombre, "Ingrese correctamente el nombre de la categoria!");
                }
                if (!Regex.Match(tboxDni.Text, @"^\d{8}$").Success)
                {
                    error = true;
                    errorIcono.SetError(tboxDni, "Ingrese correctamente el número de documento!");
                }
                if (tboxEmail.Text == String.Empty)
                {
                    error = true;
                    errorIcono.SetError(tboxEmail, "Ingrese correctamente el email!");
                }
                if (tboxClave.Text == String.Empty)
                {
                    error = true;
                    errorIcono.SetError(tboxClave, "Ingrese correctamente la contraseña!");
                }

                if (error)
                {
                    this.MensajeError("Se detectaron errores, serán remarcados");
                }
                else
                {
                    rta = NUsuario.Insertar(Convert.ToInt32(cboxRol.SelectedValue), tboxNombre.Text.Trim(), Convert.ToInt32(cboxCalle.SelectedValue), tboxAltura.Text.Trim(), tboxTelefono.Text.Trim(), tboxDni.Text.Trim(), tboxEmail.Text.Trim(), tboxClave.Text.Trim()); ;
                    if (rta.Equals("OK"))
                    {
                        this.MensajeOk("El nuevo usuario se registró correctamente, ya puede iniciar sesión!");
                        tboxNombre.Clear();
                        tboxTelefono.Clear();
                        tboxAltura.Clear();
                        tboxDni.Clear();
                        tboxEmail.Clear();
                        tboxClave.Clear();
                        cboxCalle.SelectedIndex = -1;
                        cboxRol.SelectedIndex = -1;
                        FrmLogin frm = new FrmLogin();
                        this.Hide();
                        frm.Show();
                    }
                    else
                    {
                        this.MensajeError(rta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Desarrollado por: Pablo Rodas", "Registro - PobreTITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
