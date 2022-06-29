
namespace UI
{
    partial class AltaFamiliaPatente
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
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAltaPatente = new System.Windows.Forms.Button();
            this.cmbPermisos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAltaFamilia = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFamilia = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(180, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 36);
            this.label3.TabIndex = 34;
            this.label3.Tag = "Alta_Familia_Patente";
            this.label3.Text = "Alta Familia Patente";
            // 
            // txtPatente
            // 
            this.txtPatente.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtPatente.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtPatente.Location = new System.Drawing.Point(178, 36);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(159, 20);
            this.txtPatente.TabIndex = 33;
            this.txtPatente.Tag = "Alta Familia Patente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(19, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 25);
            this.label1.TabIndex = 32;
            this.label1.Tag = "Nombre_Patente";
            this.label1.Text = "Nombre Patente";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAltaPatente);
            this.groupBox1.Controls.Add(this.cmbPermisos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPatente);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkCyan;
            this.groupBox1.Location = new System.Drawing.Point(29, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 211);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "Patentes";
            this.groupBox1.Text = "Patentes";
            // 
            // btnAltaPatente
            // 
            this.btnAltaPatente.BackColor = System.Drawing.Color.Green;
            this.btnAltaPatente.FlatAppearance.BorderSize = 0;
            this.btnAltaPatente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltaPatente.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAltaPatente.Location = new System.Drawing.Point(246, 144);
            this.btnAltaPatente.Name = "btnAltaPatente";
            this.btnAltaPatente.Size = new System.Drawing.Size(91, 47);
            this.btnAltaPatente.TabIndex = 37;
            this.btnAltaPatente.Tag = "Alta";
            this.btnAltaPatente.Text = "Alta";
            this.btnAltaPatente.UseVisualStyleBackColor = false;
            this.btnAltaPatente.Click += new System.EventHandler(this.btnAltaPatente_Click);
            // 
            // cmbPermisos
            // 
            this.cmbPermisos.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cmbPermisos.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbPermisos.FormattingEnabled = true;
            this.cmbPermisos.Location = new System.Drawing.Point(178, 97);
            this.cmbPermisos.Name = "cmbPermisos";
            this.cmbPermisos.Size = new System.Drawing.Size(159, 21);
            this.cmbPermisos.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(19, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 25);
            this.label2.TabIndex = 34;
            this.label2.Tag = "Permiso";
            this.label2.Text = "Permiso";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAltaFamilia);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtFamilia);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkCyan;
            this.groupBox2.Location = new System.Drawing.Point(388, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 211);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "Familias";
            this.groupBox2.Text = "Familias";
            // 
            // btnAltaFamilia
            // 
            this.btnAltaFamilia.BackColor = System.Drawing.Color.Green;
            this.btnAltaFamilia.FlatAppearance.BorderSize = 0;
            this.btnAltaFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltaFamilia.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAltaFamilia.Location = new System.Drawing.Point(291, 158);
            this.btnAltaFamilia.Name = "btnAltaFamilia";
            this.btnAltaFamilia.Size = new System.Drawing.Size(91, 47);
            this.btnAltaFamilia.TabIndex = 38;
            this.btnAltaFamilia.Tag = "Alta";
            this.btnAltaFamilia.Text = "Alta";
            this.btnAltaFamilia.UseVisualStyleBackColor = false;
            this.btnAltaFamilia.Click += new System.EventHandler(this.btnAltaFamilia_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(19, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 25);
            this.label5.TabIndex = 32;
            this.label5.Tag = "Nombre_Familia";
            this.label5.Text = "Nombre Familia";
            // 
            // txtFamilia
            // 
            this.txtFamilia.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtFamilia.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtFamilia.Location = new System.Drawing.Point(178, 36);
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.Size = new System.Drawing.Size(159, 20);
            this.txtFamilia.TabIndex = 33;
            this.txtFamilia.Tag = "Alta Familia Patente";
            // 
            // AltaFamiliaPatente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(803, 314);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Name = "AltaFamiliaPatente";
            this.Text = "AltaFamiliaPatente";
            this.Load += new System.EventHandler(this.AltaFamiliaPatente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPermisos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFamilia;
        private System.Windows.Forms.Button btnAltaPatente;
        private System.Windows.Forms.Button btnAltaFamilia;
    }
}