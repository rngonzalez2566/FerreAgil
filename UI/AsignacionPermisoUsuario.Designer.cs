
namespace UI
{
    partial class AsignacionPermisoUsuario
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregarPatente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPatentes = new System.Windows.Forms.ComboBox();
            this.btnAgregarFamilia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFamilias = new System.Windows.Forms.ComboBox();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.treePermisoUsuario = new System.Windows.Forms.TreeView();
            this.btnAltaFamilia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(142, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(428, 36);
            this.label3.TabIndex = 39;
            this.label3.Tag = "Asignacion Permiso Usuario";
            this.label3.Text = "Asignacion Permiso Usuario";
            // 
            // btnAgregarPatente
            // 
            this.btnAgregarPatente.BackColor = System.Drawing.Color.Green;
            this.btnAgregarPatente.FlatAppearance.BorderSize = 0;
            this.btnAgregarPatente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPatente.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAgregarPatente.Location = new System.Drawing.Point(310, 246);
            this.btnAgregarPatente.Name = "btnAgregarPatente";
            this.btnAgregarPatente.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAgregarPatente.Size = new System.Drawing.Size(56, 21);
            this.btnAgregarPatente.TabIndex = 49;
            this.btnAgregarPatente.Tag = "Agregar";
            this.btnAgregarPatente.Text = "Agregar";
            this.btnAgregarPatente.UseVisualStyleBackColor = false;
            this.btnAgregarPatente.Click += new System.EventHandler(this.btnAgregarPatente_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(40, 242);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(89, 25);
            this.label2.TabIndex = 48;
            this.label2.Tag = "nombrePatente";
            this.label2.Text = "Patentes";
            // 
            // cmbPatentes
            // 
            this.cmbPatentes.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cmbPatentes.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbPatentes.FormattingEnabled = true;
            this.cmbPatentes.Location = new System.Drawing.Point(135, 246);
            this.cmbPatentes.Name = "cmbPatentes";
            this.cmbPatentes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbPatentes.Size = new System.Drawing.Size(159, 21);
            this.cmbPatentes.TabIndex = 47;
            // 
            // btnAgregarFamilia
            // 
            this.btnAgregarFamilia.BackColor = System.Drawing.Color.Green;
            this.btnAgregarFamilia.FlatAppearance.BorderSize = 0;
            this.btnAgregarFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarFamilia.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAgregarFamilia.Location = new System.Drawing.Point(310, 189);
            this.btnAgregarFamilia.Name = "btnAgregarFamilia";
            this.btnAgregarFamilia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAgregarFamilia.Size = new System.Drawing.Size(56, 21);
            this.btnAgregarFamilia.TabIndex = 46;
            this.btnAgregarFamilia.Tag = "Agregar";
            this.btnAgregarFamilia.Text = "Agregar";
            this.btnAgregarFamilia.UseVisualStyleBackColor = false;
            this.btnAgregarFamilia.Click += new System.EventHandler(this.btnAgregarFamilia_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(40, 185);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(84, 25);
            this.label1.TabIndex = 45;
            this.label1.Tag = "nombrePatente";
            this.label1.Text = "Familias";
            // 
            // cmbFamilias
            // 
            this.cmbFamilias.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cmbFamilias.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbFamilias.FormattingEnabled = true;
            this.cmbFamilias.Location = new System.Drawing.Point(135, 189);
            this.cmbFamilias.Name = "cmbFamilias";
            this.cmbFamilias.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbFamilias.Size = new System.Drawing.Size(159, 21);
            this.cmbFamilias.TabIndex = 44;
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cmbUsuario.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(135, 125);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbUsuario.Size = new System.Drawing.Size(159, 21);
            this.cmbUsuario.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(40, 121);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(79, 25);
            this.label4.TabIndex = 51;
            this.label4.Tag = "Usuario";
            this.label4.Text = "Usuario";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Location = new System.Drawing.Point(310, 126);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(56, 21);
            this.button1.TabIndex = 52;
            this.button1.Tag = "Mostrar";
            this.button1.Text = "Mostrar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treePermisoUsuario
            // 
            this.treePermisoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.treePermisoUsuario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treePermisoUsuario.ForeColor = System.Drawing.SystemColors.Window;
            this.treePermisoUsuario.Indent = 10;
            this.treePermisoUsuario.Location = new System.Drawing.Point(403, 66);
            this.treePermisoUsuario.Name = "treePermisoUsuario";
            this.treePermisoUsuario.Size = new System.Drawing.Size(353, 277);
            this.treePermisoUsuario.TabIndex = 53;
            // 
            // btnAltaFamilia
            // 
            this.btnAltaFamilia.BackColor = System.Drawing.Color.Green;
            this.btnAltaFamilia.FlatAppearance.BorderSize = 0;
            this.btnAltaFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltaFamilia.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAltaFamilia.Location = new System.Drawing.Point(546, 367);
            this.btnAltaFamilia.Name = "btnAltaFamilia";
            this.btnAltaFamilia.Size = new System.Drawing.Size(91, 47);
            this.btnAltaFamilia.TabIndex = 54;
            this.btnAltaFamilia.Tag = "Guardar Permiso";
            this.btnAltaFamilia.Text = "Guardar Permiso";
            this.btnAltaFamilia.UseVisualStyleBackColor = false;
            this.btnAltaFamilia.Click += new System.EventHandler(this.btnAltaFamilia_Click);
            // 
            // AsignacionPermisoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAltaFamilia);
            this.Controls.Add(this.treePermisoUsuario);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbUsuario);
            this.Controls.Add(this.btnAgregarPatente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPatentes);
            this.Controls.Add(this.btnAgregarFamilia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFamilias);
            this.Controls.Add(this.label3);
            this.Name = "AsignacionPermisoUsuario";
            this.Text = "AsignacionPermisoUsuario";
            this.Load += new System.EventHandler(this.AsignacionPermisoUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAgregarPatente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPatentes;
        private System.Windows.Forms.Button btnAgregarFamilia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFamilias;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView treePermisoUsuario;
        private System.Windows.Forms.Button btnAltaFamilia;
    }
}