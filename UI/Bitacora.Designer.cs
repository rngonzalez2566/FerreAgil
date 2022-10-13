namespace UI
{
    partial class Bitacora
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCriticidad = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dpd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dph = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAltaFamilia = new System.Windows.Forms.Button();
            this.ftfecha = new System.Windows.Forms.CheckBox();
            this.ftUsuario = new System.Windows.Forms.CheckBox();
            this.ftCriticidad = new System.Windows.Forms.CheckBox();
            this.dtgBitacora = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(380, 107);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 50;
            this.label2.Tag = "Criticidad";
            this.label2.Text = "Criticidad";
            // 
            // cmbCriticidad
            // 
            this.cmbCriticidad.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cmbCriticidad.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbCriticidad.FormattingEnabled = true;
            this.cmbCriticidad.Location = new System.Drawing.Point(479, 110);
            this.cmbCriticidad.Name = "cmbCriticidad";
            this.cmbCriticidad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbCriticidad.Size = new System.Drawing.Size(159, 21);
            this.cmbCriticidad.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(380, 160);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 52;
            this.label1.Tag = "Usuario";
            this.label1.Text = "Usuario";
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cmbUsuario.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(479, 164);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbUsuario.Size = new System.Drawing.Size(159, 21);
            this.cmbUsuario.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(207, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 36);
            this.label3.TabIndex = 53;
            this.label3.Tag = "Bitacora";
            this.label3.Text = "Bitacora";
            // 
            // dpd
            // 
            this.dpd.Location = new System.Drawing.Point(163, 107);
            this.dpd.Name = "dpd";
            this.dpd.Size = new System.Drawing.Size(200, 20);
            this.dpd.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(28, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 25);
            this.label4.TabIndex = 54;
            this.label4.Tag = "FechaDesde";
            this.label4.Text = "Fecha Desde";
            // 
            // dph
            // 
            this.dph.Location = new System.Drawing.Point(163, 160);
            this.dph.Name = "dph";
            this.dph.Size = new System.Drawing.Size(200, 20);
            this.dph.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(28, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 25);
            this.label5.TabIndex = 56;
            this.label5.Tag = "FechaHasta";
            this.label5.Text = "Fecha Hasta";
            // 
            // btnAltaFamilia
            // 
            this.btnAltaFamilia.BackColor = System.Drawing.Color.Green;
            this.btnAltaFamilia.FlatAppearance.BorderSize = 0;
            this.btnAltaFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltaFamilia.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAltaFamilia.Location = new System.Drawing.Point(534, 214);
            this.btnAltaFamilia.Name = "btnAltaFamilia";
            this.btnAltaFamilia.Size = new System.Drawing.Size(104, 53);
            this.btnAltaFamilia.TabIndex = 58;
            this.btnAltaFamilia.Tag = "Buscar";
            this.btnAltaFamilia.Text = "Buscar";
            this.btnAltaFamilia.UseVisualStyleBackColor = false;
            this.btnAltaFamilia.Click += new System.EventHandler(this.btnAltaFamilia_Click);
            // 
            // ftfecha
            // 
            this.ftfecha.AutoSize = true;
            this.ftfecha.ForeColor = System.Drawing.Color.DarkCyan;
            this.ftfecha.Location = new System.Drawing.Point(72, 214);
            this.ftfecha.Name = "ftfecha";
            this.ftfecha.Size = new System.Drawing.Size(99, 17);
            this.ftfecha.TabIndex = 59;
            this.ftfecha.Tag = "FiltroFecha";
            this.ftfecha.Text = "Filtro por Fecha";
            this.ftfecha.UseVisualStyleBackColor = true;
            // 
            // ftUsuario
            // 
            this.ftUsuario.AutoSize = true;
            this.ftUsuario.ForeColor = System.Drawing.Color.DarkCyan;
            this.ftUsuario.Location = new System.Drawing.Point(213, 214);
            this.ftUsuario.Name = "ftUsuario";
            this.ftUsuario.Size = new System.Drawing.Size(105, 17);
            this.ftUsuario.TabIndex = 60;
            this.ftUsuario.Tag = "FiltroUsuario";
            this.ftUsuario.Text = "Filtro por Usuario";
            this.ftUsuario.UseVisualStyleBackColor = true;
            // 
            // ftCriticidad
            // 
            this.ftCriticidad.AutoSize = true;
            this.ftCriticidad.ForeColor = System.Drawing.Color.DarkCyan;
            this.ftCriticidad.Location = new System.Drawing.Point(338, 214);
            this.ftCriticidad.Name = "ftCriticidad";
            this.ftCriticidad.Size = new System.Drawing.Size(112, 17);
            this.ftCriticidad.TabIndex = 61;
            this.ftCriticidad.Tag = "FiltroCriticidad";
            this.ftCriticidad.Text = "Filtro por Criticidad";
            this.ftCriticidad.UseVisualStyleBackColor = true;
            // 
            // dtgBitacora
            // 
            this.dtgBitacora.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtgBitacora.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgBitacora.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBitacora.GridColor = System.Drawing.Color.Black;
            this.dtgBitacora.Location = new System.Drawing.Point(21, 321);
            this.dtgBitacora.Name = "dtgBitacora";
            this.dtgBitacora.Size = new System.Drawing.Size(639, 336);
            this.dtgBitacora.TabIndex = 62;
            // 
            // Bitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(672, 669);
            this.Controls.Add(this.dtgBitacora);
            this.Controls.Add(this.ftCriticidad);
            this.Controls.Add(this.ftUsuario);
            this.Controls.Add(this.ftfecha);
            this.Controls.Add(this.btnAltaFamilia);
            this.Controls.Add(this.dph);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dpd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCriticidad);
            this.Name = "Bitacora";
            this.Text = "Bitacora";
            this.Load += new System.EventHandler(this.Bitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCriticidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dph;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAltaFamilia;
        private System.Windows.Forms.CheckBox ftfecha;
        private System.Windows.Forms.CheckBox ftUsuario;
        private System.Windows.Forms.CheckBox ftCriticidad;
        private System.Windows.Forms.DataGridView dtgBitacora;
    }
}