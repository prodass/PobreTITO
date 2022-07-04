using Sistema.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion
{
    public partial class FrmNewUser : Form
    {
        public FrmNewUser()
        {
            InitializeComponent();
        }
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
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Nuevos usuarios - PobreTITO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Nuevos usuarios - PobreTITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CargarRol()
        {
            try
            {
                cboxRol.DataSource = NRol.Listar();
                cboxRol.ValueMember = "idRol";
                cboxRol.DisplayMember = "nombre";
                cboxRol.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void CargarCalle()
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
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string rta = "";
                bool error = false;
                if (!Regex.Match(tboxNombre.Text,@"^[A-Za-z]{4,30}$|^[A-Za-z]{4,30}\s[A-Za-z]{4,20}$").Success)
                {
                    error = true;
                    errorIcono.SetError(tboxNombre, "Ingrese correctamente el nombre de la categoria!");
                }
                if (!Regex.Match(tboxTelefono.Text, @"^\d{10}$").Success)
                {
                    error = true;
                    errorIcono.SetError(tboxTelefono, "Ingrese correctamente el número telefónico!");
                }
                if (cboxRol.SelectedIndex == -1)
                {
                    error = true;
                    errorIcono.SetError(cboxRol, "Seleccione un rol!");
                }
                if (tboxAltura.Text == string.Empty)
                {
                    error = true;
                    errorIcono.SetError(tboxAltura, "Ingrese correctamente la altura!");
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
                if (cboxRol.SelectedIndex == -1)
                {
                    error = true;
                    errorIcono.SetError(cboxRol, "Seleccione un rol!");
                }

                if (error)
                {
                    this.MensajeError("Se detectaron errores, serán remarcados");
                }
                else
                {
                    rta = NUsuario.Insertar(Convert.ToInt32(cboxRol.SelectedValue), tboxNombre.Text.Trim(), Convert.ToInt32(cboxCalle.SelectedValue), tboxAltura.Text, tboxTelefono.Text.Trim(), tboxDni.Text.Trim(),tboxEmail.Text.Trim(),tboxClave.Text.Trim()); ;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmNewUser_Load(object sender, EventArgs e)
        {
            this.CargarRol();
            this.CargarCalle();
            lblNombre.Text = Variables.Nombre;
            lblMail.Text = Variables.Email;
            lblRol.Text = Variables.Rol;
        }

        private void pboxBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMenu frm = new FrmMenu();
            frm.Show();
        }
    }
}
