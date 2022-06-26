
namespace UI
{
    partial class Principal
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSesion = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambioDePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desbloquearUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignacionFamiliaPatenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignacionPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desasignarPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIdioma = new System.Windows.Forms.ToolStripMenuItem();
            this.compraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Gray;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripSesion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(65, 21);
            this.toolStripStatusLabel.Text = "Usuario";
            // 
            // toolStripSesion
            // 
            this.toolStripSesion.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.toolStripSesion.ForeColor = System.Drawing.Color.DarkRed;
            this.toolStripSesion.Name = "toolStripSesion";
            this.toolStripSesion.Size = new System.Drawing.Size(166, 21);
            this.toolStripSesion.Text = "[ Sesión no iniciada ]";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administracionToolStripMenuItem,
            this.aBMToolStripMenuItem,
            this.menuIdioma,
            this.compraToolStripMenuItem,
            this.ventaToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administracionToolStripMenuItem
            // 
            this.administracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.permisosToolStripMenuItem});
            this.administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            this.administracionToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administracionToolStripMenuItem.Tag = "Administracion";
            this.administracionToolStripMenuItem.Text = "Administracion";
            this.administracionToolStripMenuItem.Click += new System.EventHandler(this.administracionToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaUsuariosToolStripMenuItem,
            this.bajaUsuariosToolStripMenuItem,
            this.cambioDePasswordToolStripMenuItem,
            this.desbloquearUsuarioToolStripMenuItem});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuariosToolStripMenuItem.Tag = "Usuarios";
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // altaUsuariosToolStripMenuItem
            // 
            this.altaUsuariosToolStripMenuItem.Name = "altaUsuariosToolStripMenuItem";
            this.altaUsuariosToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.altaUsuariosToolStripMenuItem.Text = "Alta Usuarios";
            this.altaUsuariosToolStripMenuItem.Click += new System.EventHandler(this.altaUsuariosToolStripMenuItem_Click);
            // 
            // bajaUsuariosToolStripMenuItem
            // 
            this.bajaUsuariosToolStripMenuItem.Name = "bajaUsuariosToolStripMenuItem";
            this.bajaUsuariosToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.bajaUsuariosToolStripMenuItem.Text = "Baja Usuarios";
            // 
            // cambioDePasswordToolStripMenuItem
            // 
            this.cambioDePasswordToolStripMenuItem.Name = "cambioDePasswordToolStripMenuItem";
            this.cambioDePasswordToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cambioDePasswordToolStripMenuItem.Text = "Cambio de Password";
            // 
            // desbloquearUsuarioToolStripMenuItem
            // 
            this.desbloquearUsuarioToolStripMenuItem.Name = "desbloquearUsuarioToolStripMenuItem";
            this.desbloquearUsuarioToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.desbloquearUsuarioToolStripMenuItem.Text = "Desbloquear Usuario";
            // 
            // permisosToolStripMenuItem
            // 
            this.permisosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaPermisosToolStripMenuItem,
            this.asignacionFamiliaPatenteToolStripMenuItem,
            this.asignacionPermisosToolStripMenuItem,
            this.desasignarPermisosToolStripMenuItem});
            this.permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            this.permisosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.permisosToolStripMenuItem.Text = "Permisos";
            // 
            // altaPermisosToolStripMenuItem
            // 
            this.altaPermisosToolStripMenuItem.Name = "altaPermisosToolStripMenuItem";
            this.altaPermisosToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.altaPermisosToolStripMenuItem.Text = "Alta Permisos";
            this.altaPermisosToolStripMenuItem.Click += new System.EventHandler(this.altaPermisosToolStripMenuItem_Click);
            // 
            // asignacionFamiliaPatenteToolStripMenuItem
            // 
            this.asignacionFamiliaPatenteToolStripMenuItem.Name = "asignacionFamiliaPatenteToolStripMenuItem";
            this.asignacionFamiliaPatenteToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.asignacionFamiliaPatenteToolStripMenuItem.Text = "Asignacion Familia Patente";
            this.asignacionFamiliaPatenteToolStripMenuItem.Click += new System.EventHandler(this.asignacionFamiliaPatenteToolStripMenuItem_Click);
            // 
            // asignacionPermisosToolStripMenuItem
            // 
            this.asignacionPermisosToolStripMenuItem.Name = "asignacionPermisosToolStripMenuItem";
            this.asignacionPermisosToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.asignacionPermisosToolStripMenuItem.Text = "Asignacion Permisos Usuarios";
            this.asignacionPermisosToolStripMenuItem.Click += new System.EventHandler(this.asignacionPermisosToolStripMenuItem_Click);
            // 
            // desasignarPermisosToolStripMenuItem
            // 
            this.desasignarPermisosToolStripMenuItem.Name = "desasignarPermisosToolStripMenuItem";
            this.desasignarPermisosToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.desasignarPermisosToolStripMenuItem.Text = "Desasignar Permisos";
            this.desasignarPermisosToolStripMenuItem.Click += new System.EventHandler(this.desasignarPermisosToolStripMenuItem_Click);
            // 
            // aBMToolStripMenuItem
            // 
            this.aBMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem,
            this.proveedorToolStripMenuItem});
            this.aBMToolStripMenuItem.Name = "aBMToolStripMenuItem";
            this.aBMToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.aBMToolStripMenuItem.Text = "ABM";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.productosToolStripMenuItem.Tag = "Producto";
            this.productosToolStripMenuItem.Text = "Producto";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // proveedorToolStripMenuItem
            // 
            this.proveedorToolStripMenuItem.Name = "proveedorToolStripMenuItem";
            this.proveedorToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.proveedorToolStripMenuItem.Tag = "Proveedor";
            this.proveedorToolStripMenuItem.Text = "Proveedor";
            // 
            // menuIdioma
            // 
            this.menuIdioma.Name = "menuIdioma";
            this.menuIdioma.Size = new System.Drawing.Size(56, 20);
            this.menuIdioma.Tag = "menu_idioma";
            this.menuIdioma.Text = "Idioma";
            // 
            // compraToolStripMenuItem
            // 
            this.compraToolStripMenuItem.Name = "compraToolStripMenuItem";
            this.compraToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.compraToolStripMenuItem.Text = "Compra";
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ventaToolStripMenuItem.Text = "Venta";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.cerrarSesionToolStripMenuItem.Tag = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSesion;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambioDePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desbloquearUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuIdioma;
        private System.Windows.Forms.ToolStripMenuItem aBMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaPermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignacionPermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desasignarPermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignacionFamiliaPatenteToolStripMenuItem;
    }
}