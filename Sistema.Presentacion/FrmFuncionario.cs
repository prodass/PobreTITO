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

namespace Sistema.Presentacion
{
    public partial class FrmFuncionario : Form
    {
        public FrmFuncionario()
        {
            InitializeComponent();
        }

        //Botones
        private void pboxBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMenu frm = new FrmMenu();
            frm.ShowDialog();
            this.Close();
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
        private void btnNUsuarios_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmNewUser frm = new FrmNewUser();
            frm.ShowDialog();
            frm.Close();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Desarrollado por: Pablo Rodas", "Menu - PobreTITO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void tboxSearchU_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        //Proceso
        private void Buscar()
        {
            try
            {
                dgvUsuario.DataSource = NUsuario.Buscar(tboxSearchU.Text);

                lblTotalU.Text = $"Total registros: {(dgvUsuario.Rows.Count).ToString()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //ListBox
        private void Usuarios()
        {
            try
            {
                dgvUsuario.DataSource = NUsuario.Listar();

                //Formato
                dgvUsuario.Columns[0].Width = 30;
                dgvUsuario.Columns[0].HeaderText = "ID";
                dgvUsuario.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUsuario.Columns[1].Visible = false;
                dgvUsuario.Columns[2].Width = 70;
                dgvUsuario.Columns[3].Width = 110;
                dgvUsuario.Columns[4].Visible = false;
                dgvUsuario.Columns[5].Width = 153;
                dgvUsuario.Columns[6].Width = 70;
                dgvUsuario.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUsuario.Columns[7].Width = 70;
                dgvUsuario.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUsuario.Columns[8].Width = 70;
                dgvUsuario.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUsuario.Columns[9].Width = 140;

                lblTotalU.Text = $"Total registros: {(dgvUsuario.Rows.Count).ToString()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Reclamos()
        {
            try
            {
                dgvReclamo.DataSource = NReclamo.Listar();

                //Formato
                dgvReclamo.Columns[0].Width = 25;
                dgvReclamo.Columns[1].Width = 215;
                dgvReclamo.Columns[2].Width = 123;
                dgvReclamo.Columns[4].Width = 65;
                dgvReclamo.Columns[5].Width = 50;
                dgvReclamo.Columns[6].Width = 105;
                dgvReclamo.Columns[7].Width = 140;
                dgvReclamo.Columns[8].Width = 40;
                dgvReclamo.Columns[10].Width = 140;
                   
                dgvReclamo.Columns[0].HeaderText = "ID";
                dgvReclamo.Columns[2].HeaderText = "Categoría";
                dgvReclamo.Columns[7].HeaderText = "Calle";
                   
                dgvReclamo.Columns[3].Visible = false;
                dgvReclamo.Columns[9].Visible = false;
                   
                dgvReclamo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                lblTotalR.Text = $"Total registros: {(dgvReclamo.Rows.Count).ToString()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Roles()
        {
            try
            {
                dgvRol.DataSource = NRol.Listar();
                //Formato
                dgvRol.Columns[0].Width = 30;
                dgvRol.Columns[0].HeaderText = "ID";
                dgvRol.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRol.Columns[1].Width = 300;
                dgvRol.Columns[1].HeaderText = "Nombre";

                lblTotalRol.Text = $"Total registros: {(dgvRol.Rows.Count).ToString()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Load
        private void FrmFuncionario_Load(object sender, EventArgs e)
        {
            this.Usuarios();
            this.Reclamos();
            this.Roles();
            lblNombre.Text = Variables.Nombre;
            lblMail.Text = Variables.Email;
            lblRol.Text = Variables.Rol;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
