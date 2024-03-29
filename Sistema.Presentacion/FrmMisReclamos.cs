﻿using Sistema.Negocio;
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
    public partial class FrmMisReclamos : Form
    {
        public FrmMisReclamos()
        {
            InitializeComponent();
        }

        private void FrmMisReclamos_Load(object sender, EventArgs e)
        {
            this.Reclamos();
        }

        //Funcion para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void FrmMisReclamos_MouseDown(object sender, MouseEventArgs e)
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
            this.Close();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("Esta seguro que desea cerrar sesión?", "Mis reclamos - PobreTITO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            Opcion = MessageBox.Show("Esta seguro que desea salir?", "Mis reclamos - PobreTITO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Opcion == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Desarrollado por: Pablo Rodas", "Mis reclamos - PobreTITO", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
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
        private void btnNuevoReclamo_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmNuevoReclamo frm = new FrmNuevoReclamo();
            frm.ShowDialog();
            this.Close();
        }

        //Carga
        private void Reclamos()
        {
            try
            {
                dgvListado.DataSource = NReclamo.Listar();

                //Formato
                dgvListado.Columns[0].Width = 25;
                dgvListado.Columns[1].Width = 215;
                dgvListado.Columns[2].Width = 123;
                dgvListado.Columns[4].Width = 65;
                dgvListado.Columns[5].Width = 50;
                dgvListado.Columns[6].Width = 105;
                dgvListado.Columns[7].Width = 140;
                dgvListado.Columns[8].Width = 40;
                dgvListado.Columns[10].Width = 140;

                dgvListado.Columns[0].HeaderText = "ID";
                dgvListado.Columns[2].HeaderText = "Categoría";
                dgvListado.Columns[7].HeaderText = "Calle";

                dgvListado.Columns[3].Visible = false;
                dgvListado.Columns[9].Visible = false;

                dgvListado.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                lblTotalR.Text = $"Total de registros: {(dgvListado.Rows.Count).ToString()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        
    }
}
