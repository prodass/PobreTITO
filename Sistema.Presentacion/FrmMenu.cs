using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion
{
    public partial class FrmMenu : Form
    {
        public int idUsuario;
        public int idRol;
        public string nombre;
        public string email;
        public string rol;

        public FrmMenu()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmMenu_Load(object sender, EventArgs e)
        {
            if (Variables.idRol == 0) //Es un vecino
            {
                this.btnFuncionario.Enabled = false;
                this.btnFuncionario.Cursor = Cursors.No;
            }
            else
            {
                this.btnFuncionario.Enabled = true;
                this.btnNuevoReclamo.Enabled = false;
                this.btnLista.Enabled = false;
                this.pboxFuncionario.Visible = true;
            }


            lblNombre.Text = Variables.Nombre;
            lblMail.Text = Variables.Email;
            lblRol.Text = Variables.Rol;
        }

        //Funcion para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void FrmMenu_MouseDown(object sender, MouseEventArgs e)
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
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("Esta seguro que desea cerrar sesión?", "Menu - PobreTITO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            Opcion = MessageBox.Show("Esta seguro que desea salir?", "Menu - PobreTITO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Opcion == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Desarrollado por: Pablo Rodas", "Menu - PobreTITO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        private void btnCuenta_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCuenta frm = new FrmCuenta();
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
        private void btnLista_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMisReclamos frm = new FrmMisReclamos();
            frm.ShowDialog();
            this.Close();
        }

        private void btnNuevoReclamo_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmNuevoReclamo frm = new FrmNuevoReclamo();
            frm.ShowDialog();
            this.Close();
        }
    }
}
