namespace Sistema.Presentacion
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.pboxLeave = new System.Windows.Forms.PictureBox();
            this.pboxMin = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tboxUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tboxContraseña = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linklblOlvido = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnIngresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLeave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMin)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // pboxLeave
            // 
            this.pboxLeave.BackColor = System.Drawing.Color.Transparent;
            this.pboxLeave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pboxLeave.BackgroundImage")));
            this.pboxLeave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pboxLeave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pboxLeave.Location = new System.Drawing.Point(764, 6);
            this.pboxLeave.Name = "pboxLeave";
            this.pboxLeave.Size = new System.Drawing.Size(30, 25);
            this.pboxLeave.TabIndex = 0;
            this.pboxLeave.TabStop = false;
            this.pboxLeave.Click += new System.EventHandler(this.pboxLeave_Click);
            this.pboxLeave.MouseEnter += new System.EventHandler(this.pboxLeave_MouseEnter);
            this.pboxLeave.MouseLeave += new System.EventHandler(this.pboxLeave_MouseLeave);
            // 
            // pboxMin
            // 
            this.pboxMin.BackColor = System.Drawing.Color.Transparent;
            this.pboxMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pboxMin.BackgroundImage")));
            this.pboxMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pboxMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pboxMin.Location = new System.Drawing.Point(734, 6);
            this.pboxMin.Name = "pboxMin";
            this.pboxMin.Size = new System.Drawing.Size(30, 25);
            this.pboxMin.TabIndex = 1;
            this.pboxMin.TabStop = false;
            this.pboxMin.Click += new System.EventHandler(this.pboxMin_Click);
            this.pboxMin.MouseEnter += new System.EventHandler(this.pboxMin_MouseEnter);
            this.pboxMin.MouseLeave += new System.EventHandler(this.pboxMin_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(92)))), ((int)(((byte)(133)))));
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 390);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Silver;
            this.linkLabel1.Location = new System.Drawing.Point(34, 359);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(122, 16);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "¿Desea registrarse?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(3, -46);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(178, 173);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // tboxUsuario
            // 
            this.tboxUsuario.BackColor = System.Drawing.Color.White;
            this.tboxUsuario.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxUsuario.ForeColor = System.Drawing.Color.Black;
            this.tboxUsuario.Location = new System.Drawing.Point(335, 136);
            this.tboxUsuario.Name = "tboxUsuario";
            this.tboxUsuario.Size = new System.Drawing.Size(327, 28);
            this.tboxUsuario.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Contraseña:";
            // 
            // tboxContraseña
            // 
            this.tboxContraseña.BackColor = System.Drawing.Color.White;
            this.tboxContraseña.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxContraseña.ForeColor = System.Drawing.Color.Black;
            this.tboxContraseña.Location = new System.Drawing.Point(335, 186);
            this.tboxContraseña.Name = "tboxContraseña";
            this.tboxContraseña.PasswordChar = '*';
            this.tboxContraseña.Size = new System.Drawing.Size(327, 28);
            this.tboxContraseña.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(421, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 26);
            this.label3.TabIndex = 8;
            this.label3.Text = "Iniciar sesión";
            // 
            // linklblOlvido
            // 
            this.linklblOlvido.AutoSize = true;
            this.linklblOlvido.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblOlvido.Location = new System.Drawing.Point(424, 359);
            this.linklblOlvido.Name = "linklblOlvido";
            this.linklblOlvido.Size = new System.Drawing.Size(142, 16);
            this.linklblOlvido.TabIndex = 5;
            this.linklblOlvido.TabStop = true;
            this.linklblOlvido.Text = "¿Olvido su contraseña?";
            this.linklblOlvido.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblOlvido_LinkClicked);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(320, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(350, 1);
            this.label4.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(320, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(350, 1);
            this.label5.TabIndex = 12;
            // 
            // errorIcono
            // 
            this.errorIcono.BlinkRate = 450;
            this.errorIcono.ContainerControl = this;
            this.errorIcono.Icon = ((System.Drawing.Icon)(resources.GetObject("errorIcono.Icon")));
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(414, 271);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(126, 30);
            this.btnIngresar.TabIndex = 13;
            this.btnIngresar.Text = "button1";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            this.btnIngresar.MouseEnter += new System.EventHandler(this.btnIngresar_MouseEnter);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(208)))), ((int)(((byte)(220)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(799, 390);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linklblOlvido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tboxContraseña);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxUsuario);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pboxMin);
            this.Controls.Add(this.pboxLeave);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TransparencyKey = System.Drawing.Color.Gainsboro;
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pboxLeave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMin)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxLeave;
        private System.Windows.Forms.PictureBox pboxMin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tboxUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tboxContraseña;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linklblOlvido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.Button btnIngresar;
    }
}