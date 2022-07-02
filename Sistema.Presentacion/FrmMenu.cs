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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("Esta seguro que desea cerrar sesión?", "PobreTITO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
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
            Opcion = MessageBox.Show("Esta seguro que desea salir?", "PobreTITO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Opcion == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCuenta frm = new FrmCuenta();
            frm.ShowDialog();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Desarrollado por: Pablo Rodas", "PobreTITO", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
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
    }
}
