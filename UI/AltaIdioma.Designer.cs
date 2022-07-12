namespace UI
{
    partial class AltaIdioma
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdioma = new System.Windows.Forms.TextBox();
            this.btnAlta = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtgIdiomas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIdiomas)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(21, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 25);
            this.label5.TabIndex = 33;
            this.label5.Tag = "Nombre_Idioma";
            this.label5.Text = "Nombre Idioma";
            // 
            // txtIdioma
            // 
            this.txtIdioma.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtIdioma.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtIdioma.Location = new System.Drawing.Point(183, 92);
            this.txtIdioma.Name = "txtIdioma";
            this.txtIdioma.Size = new System.Drawing.Size(159, 20);
            this.txtIdioma.TabIndex = 34;
            this.txtIdioma.Tag = "Alta Familia Patente";
            // 
            // btnAlta
            // 
            this.btnAlta.BackColor = System.Drawing.Color.Green;
            this.btnAlta.FlatAppearance.BorderSize = 0;
            this.btnAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlta.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAlta.Location = new System.Drawing.Point(385, 217);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(91, 47);
            this.btnAlta.TabIndex = 35;
            this.btnAlta.Tag = "Alta";
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = false;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(151, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 36);
            this.label3.TabIndex = 36;
            this.label3.Tag = "Alta_Idioma";
            this.label3.Text = "Alta Idioma";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Chocolate;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.Location = new System.Drawing.Point(503, 217);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 47);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Tag = "Cancelar";
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtgIdiomas
            // 
            this.dtgIdiomas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtgIdiomas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgIdiomas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgIdiomas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIdiomas.GridColor = System.Drawing.Color.Black;
            this.dtgIdiomas.Location = new System.Drawing.Point(26, 131);
            this.dtgIdiomas.Name = "dtgIdiomas";
            this.dtgIdiomas.Size = new System.Drawing.Size(316, 133);
            this.dtgIdiomas.TabIndex = 38;
            this.dtgIdiomas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIdiomas_CellContentClick);
            // 
            // AltaIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(624, 282);
            this.Controls.Add(this.dtgIdiomas);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.txtIdioma);
            this.Controls.Add(this.label5);
            this.Name = "AltaIdioma";
            this.Text = "AltaIdioma";
            this.Load += new System.EventHandler(this.AltaIdioma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIdiomas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdioma;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dtgIdiomas;
    }
}