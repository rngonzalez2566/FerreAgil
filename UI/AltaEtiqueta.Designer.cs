namespace UI
{
    partial class AltaEtiqueta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.dtgTraducciones = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.txtTraduccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbIdioma = new System.Windows.Forms.ComboBox();
            this.cmbEtiquetas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTraducciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(253, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 36);
            this.label3.TabIndex = 37;
            this.label3.Tag = "Alta_Etiqueta";
            this.label3.Text = "Alta Etiquetas";
            // 
            // dtgTraducciones
            // 
            this.dtgTraducciones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtgTraducciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTraducciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgTraducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTraducciones.GridColor = System.Drawing.Color.Black;
            this.dtgTraducciones.Location = new System.Drawing.Point(380, 91);
            this.dtgTraducciones.Name = "dtgTraducciones";
            this.dtgTraducciones.Size = new System.Drawing.Size(393, 231);
            this.dtgTraducciones.TabIndex = 43;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Chocolate;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.Location = new System.Drawing.Point(244, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 47);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Tag = "Cancelar";
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnAlta
            // 
            this.btnAlta.BackColor = System.Drawing.Color.Green;
            this.btnAlta.FlatAppearance.BorderSize = 0;
            this.btnAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlta.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAlta.Location = new System.Drawing.Point(119, 275);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(91, 47);
            this.btnAlta.TabIndex = 41;
            this.btnAlta.Tag = "Alta";
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = false;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // txtTraduccion
            // 
            this.txtTraduccion.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtTraduccion.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtTraduccion.Location = new System.Drawing.Point(176, 220);
            this.txtTraduccion.Name = "txtTraduccion";
            this.txtTraduccion.Size = new System.Drawing.Size(159, 20);
            this.txtTraduccion.TabIndex = 40;
            this.txtTraduccion.Tag = "Alta Familia Patente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(46, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 25);
            this.label5.TabIndex = 39;
            this.label5.Tag = "Idioma";
            this.label5.Text = "Idioma";
            // 
            // cmbIdioma
            // 
            this.cmbIdioma.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cmbIdioma.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbIdioma.FormattingEnabled = true;
            this.cmbIdioma.Location = new System.Drawing.Point(176, 95);
            this.cmbIdioma.Name = "cmbIdioma";
            this.cmbIdioma.Size = new System.Drawing.Size(159, 21);
            this.cmbIdioma.TabIndex = 44;
            this.cmbIdioma.SelectedIndexChanged += new System.EventHandler(this.cmbIdioma_SelectedIndexChanged);
            // 
            // cmbEtiquetas
            // 
            this.cmbEtiquetas.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cmbEtiquetas.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbEtiquetas.FormattingEnabled = true;
            this.cmbEtiquetas.Location = new System.Drawing.Point(176, 162);
            this.cmbEtiquetas.Name = "cmbEtiquetas";
            this.cmbEtiquetas.Size = new System.Drawing.Size(159, 21);
            this.cmbEtiquetas.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(46, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 46;
            this.label1.Tag = "Etiqueta";
            this.label1.Text = "Etiqueta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(46, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 25);
            this.label2.TabIndex = 47;
            this.label2.Tag = "Traduccion";
            this.label2.Text = "Traduccion";
            // 
            // AltaEtiqueta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(793, 344);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEtiquetas);
            this.Controls.Add(this.cmbIdioma);
            this.Controls.Add(this.dtgTraducciones);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.txtTraduccion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Name = "AltaEtiqueta";
            this.Text = "AltaEtiqueta";
            this.Load += new System.EventHandler(this.AltaEtiqueta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTraducciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dtgTraducciones;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.TextBox txtTraduccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbIdioma;
        private System.Windows.Forms.ComboBox cmbEtiquetas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}