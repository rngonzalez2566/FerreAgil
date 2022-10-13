namespace UI
{
    partial class GestionDigitosVerificadores
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
            this.btnBaja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBaja
            // 
            this.btnBaja.BackColor = System.Drawing.Color.Red;
            this.btnBaja.FlatAppearance.BorderSize = 0;
            this.btnBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaja.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBaja.Location = new System.Drawing.Point(158, 28);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(148, 76);
            this.btnBaja.TabIndex = 25;
            this.btnBaja.Tag = "recalcular";
            this.btnBaja.Text = "Recalcular Digitos";
            this.btnBaja.UseVisualStyleBackColor = false;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // GestionDigitosVerificadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(471, 131);
            this.Controls.Add(this.btnBaja);
            this.Name = "GestionDigitosVerificadores";
            this.Text = "GestionDigitosVerificadores";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBaja;
    }
}