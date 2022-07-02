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
    public partial class FrmCuenta : Form
    {
        public FrmCuenta()
        {
            InitializeComponent();
        }

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
            Opcion = MessageBox.Show("Esta seguro que desea salir?", "PobreTITO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(Opcion == DialogResult.Yes)
            {
                Application.Exit();
            }   
        }

        private void FrmCuenta_Load(object sender, EventArgs e)
        {

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
