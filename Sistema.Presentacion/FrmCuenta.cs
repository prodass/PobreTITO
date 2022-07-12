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
    public partial class FrmCuenta : Form
    {
        public string nombreNuev;
        public string telefonoNuev;
        public int idCalleNuev;
        public string alturaNuev;
        public string dniNuev;
        public string emailNuev;
        public FrmCuenta()
        {
            InitializeComponent();
        }

        private void FrmCuenta_Load(object sender, EventArgs e)
        {
            this.Listar();

            if(Variables.idRol == 0) //Vecino
            {
                pboxVecino.Visible = true;
                pboxFuncionario.Visible = false;
                btnFuncionario.Enabled = false;

            }
            else
            {
                pboxVecino.Visible = false;
                pboxFuncionario.Visible = true;
                btnFuncionario.Enabled = true;
                btnLista.Enabled = false;
                btnNuevo.Enabled = false;
            }
        }

        //Funcion para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void FrmCuenta_MouseDown(object sender, MouseEventArgs e)
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMenu frm = new FrmMenu();
            frm.ShowDialog();
            this.Close();
        }
        private void pboxLeave_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("Esta seguro que desea salir?", "Cuenta - PobreTITO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(Opcion == DialogResult.Yes)
            {
                Application.Exit();
            }   
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Desarrollado por: Pablo Rodas", "Cuenta - PobreTITO", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
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
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Cuenta - PobreTITO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Cuenta - PobreTITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnLista_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMisReclamos frm = new FrmMisReclamos();
            frm.ShowDialog();
            this.Close();
        }
        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmFuncionario frm = new FrmFuncionario();
            frm.ShowDialog();
            this.Close();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmNuevoReclamo frm = new FrmNuevoReclamo();
            frm.ShowDialog();
            this.Close();
        }
        private void pboxLogOut_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("Esta seguro que desea cerrar sesión?", "Cuenta - PobreTITO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Opcion == DialogResult.Yes)
            {
                this.Hide();
                FrmLogin frm = new FrmLogin();
                frm.ShowDialog();
                this.Close();
            }

        }

        //Listar
        private void Listar()
        {
            tboxNombre.Text = Variables.Nombre;
            tboxTelefono.Text = Variables.Telefono;

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

            cboxCalle.SelectedIndex = Variables.idCalle;

            tboxAltura.Text = Variables.Altura;
            tboxDni.Text = Variables.Dni;

            try
            {
                cboxRol.DataSource = NRol.Listar();
                cboxRol.ValueMember = "idRol";
                cboxRol.DisplayMember = "nombre";
                cboxRol.SelectedIndex = Variables.idRol;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

            tboxEmail.Text = Variables.Email;

            
        }
        
        //Actualizar
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string rta = "";
                bool error = false;
                nombreNuev = tboxNombre.Text;
                telefonoNuev = tboxTelefono.Text;
                idCalleNuev = Convert.ToInt32(cboxCalle.SelectedValue);
                alturaNuev = tboxAltura.Text;
                dniNuev = tboxDni.Text;
                emailNuev = tboxEmail.Text;
                if (!Regex.Match(tboxNombre.Text, @"^[A-Za-z]{4,30}$|^[A-Za-z]{4,30}\s[A-Za-z]{4,20}$").Success)
                {
                    error = true;
                    errorIcono.SetError(tboxNombre, "Ingrese correctamente el nombre de la categoria!");
                }
                if (!Regex.Match(tboxTelefono.Text, @"^\d{10}$").Success)
                {
                    error = true;
                    errorIcono.SetError(tboxTelefono, "Ingrese correctamente el número telefónico!");
                }
                if (tboxAltura.Text == string.Empty)
                {
                    error = true;
                    errorIcono.SetError(tboxAltura, "Ingrese correctamente la dirección!");
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

                if (error)
                {
                    this.MensajeError("Se detectaron errores, serán remarcados");
                }
                else
                {
                    rta = NUsuario.Actualizar(Variables.idUsuario, Variables.idRol, tboxNombre.Text.Trim(), Convert.ToInt32(cboxCalle.SelectedValue), tboxAltura.Text.Trim(), tboxTelefono.Text.Trim(), tboxDni.Text.Trim(), Variables.Email.Trim(), tboxEmail.Text.Trim(), tboxClave.Text.Trim()); ;
                    if (rta.Equals("OK"))
                    {
                        this.MensajeOk("El usuario se actualizó correctamente!");
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
            finally
            {
                Variables.Nombre = nombreNuev;
                Variables.Telefono = telefonoNuev;
                Variables.idCalle = idCalleNuev;
                Variables.Altura = alturaNuev;
                Variables.Dni = dniNuev;
                Variables.Email = emailNuev;
            }
        }
    }
}
