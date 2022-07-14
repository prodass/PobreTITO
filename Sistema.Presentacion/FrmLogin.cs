using Sistema.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace Sistema.Presentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        //Funcion para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
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
        private void btnIngresar_MouseEnter(object sender, EventArgs e)
        {
            if (tboxUsuario.Text == String.Empty && tboxContraseña.Text == String.Empty)
            {
                btnIngresar.Cursor = Cursors.No;
            }
            else
            {
                btnIngresar.Cursor = Cursors.Hand;
            }
        }
        private void linklblOlvido_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Por ahora no podes hacer nada, je", "Login - PobreTITO");
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegistrarse frm = new FrmRegistrarse(this.Location);
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        //Login
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tabla = new DataTable();
                tabla = NUsuario.Login(tboxUsuario.Text.Trim(), tboxContraseña.Text.Trim());
                if (tabla.Rows.Count <= 0)
                {
                    errorIcono.SetError(tboxUsuario,"Verifique los campos");
                    errorIcono.SetError(tboxContraseña, "Verifique los campos");

                    MessageBox.Show("Usuario y/o contraseña incorrectos!", "Login - PobreTITO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Variables.idUsuario = Convert.ToInt32(tabla.Rows[0][0]);
                    Variables.idRol = Convert.ToInt32(tabla.Rows[0][1]);
                    Variables.Rol = Convert.ToString(tabla.Rows[0][2]);
                    Variables.Nombre = Convert.ToString(tabla.Rows[0][3]);
                    Variables.idCalle = Convert.ToInt32(tabla.Rows[0][4]);
                    Variables.CalleNombre = Convert.ToString(tabla.Rows[0][5]);
                    Variables.Altura = Convert.ToString(tabla.Rows[0][6]);
                    Variables.Telefono = Convert.ToString(tabla.Rows[0][7]);
                    Variables.Dni = Convert.ToString(tabla.Rows[0][8]);
                    Variables.Email = Convert.ToString(tabla.Rows[0][9]);
                    MessageBox.Show($"{Variables.Nombre}, bienvenido al sistema!", "Login - PobreTITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmMenu frm = new FrmMenu();
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PobreTITO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        
    }
}
