namespace UI
{
    partial class ComprasPendienteEnvioProv
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
            this.dtgPendientes = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAlta = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgPendientes
            // 
            this.dtgPendientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtgPendientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPendientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPendientes.GridColor = System.Drawing.Color.Black;
            this.dtgPendientes.Location = new System.Drawing.Point(22, 59);
            this.dtgPendientes.Name = "dtgPendientes";
            this.dtgPendientes.Size = new System.Drawing.Size(696, 142);
            this.dtgPendientes.TabIndex = 39;
            this.dtgPendientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPendientes_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(121, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(423, 36);
            this.label3.TabIndex = 40;
            this.label3.Tag = "Pendiente_Envio_Prov";
            this.label3.Text = "Pendientes Envio Proveedor";
            // 
            // btnAlta
            // 
            this.btnAlta.BackColor = System.Drawing.Color.Green;
            this.btnAlta.FlatAppearance.BorderSize = 0;
            this.btnAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlta.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAlta.Location = new System.Drawing.Point(326, 221);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(91, 47);
            this.btnAlta.TabIndex = 43;
            this.btnAlta.Tag = "Enviar";
            this.btnAlta.Text = "Enviar";
            this.btnAlta.UseVisualStyleBackColor = false;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(29, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 25);
            this.label5.TabIndex = 45;
            this.label5.Tag = "Comprobante_Nro";
            this.label5.Text = "Comprobante Nro:";
            // 
            // txtNro
            // 
            this.txtNro.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtNro.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtNro.Location = new System.Drawing.Point(208, 234);
            this.txtNro.Name = "txtNro";
            this.txtNro.ReadOnly = true;
            this.txtNro.Size = new System.Drawing.Size(44, 20);
            this.txtNro.TabIndex = 46;
            this.txtNro.Tag = "Alta Familia Patente";
            this.txtNro.Text = "0";
            // 
            // ComprasPendienteEnvioProv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(776, 300);
            this.Controls.Add(this.txtNro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtgPendientes);
            this.Name = "ComprasPendienteEnvioProv";
            this.Text = "ComprasPendienteEnvioProv";
            this.Load += new System.EventHandler(this.ComprasPendienteEnvioProv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPendientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgPendientes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNro;
    }
}