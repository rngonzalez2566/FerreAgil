﻿
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
            this.altaPermisosStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignacionFamiliaPatenteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.asignacionPermisosUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desasignarPermisosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambioDePasswordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.desbloquearUsuarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIdioma = new System.Windows.Forms.ToolStripMenuItem();
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
            this.administracionUsuariosToolStripMenuItem,
            this.aBMToolStripMenuItem,
            this.compraToolStripMenuItem,
            this.ventaToolStripMenuItem,
            this.menuIdioma,
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
            this.altaPermisosStripMenuItem,
            this.asignacionFamiliaPatenteToolStripMenuItem1,
            this.asignacionPermisosUsuariosToolStripMenuItem,
            this.desasignarPermisosToolStripMenuItem1});
            this.administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            this.administracionToolStripMenuItem.Size = new System.Drawing.Size(151, 20);
            this.administracionToolStripMenuItem.Tag = "Administracion";
            this.administracionToolStripMenuItem.Text = "Administracion Permisos";
            // 
            // altaPermisosStripMenuItem
            // 
            this.altaPermisosStripMenuItem.Name = "altaPermisosStripMenuItem";
            this.altaPermisosStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.altaPermisosStripMenuItem.Text = "Alta Permisos";
            this.altaPermisosStripMenuItem.Click += new System.EventHandler(this.altaToolStripMenuItem_Click);
            // 
            // asignacionFamiliaPatenteToolStripMenuItem1
            // 
            this.asignacionFamiliaPatenteToolStripMenuItem1.Name = "asignacionFamiliaPatenteToolStripMenuItem1";
            this.asignacionFamiliaPatenteToolStripMenuItem1.Size = new System.Drawing.Size(232, 22);
            this.asignacionFamiliaPatenteToolStripMenuItem1.Text = "Asignacion Familia Patente";
            this.asignacionFamiliaPatenteToolStripMenuItem1.Click += new System.EventHandler(this.asignacionFamiliaPatenteToolStripMenuItem1_Click);
            // 
            // asignacionPermisosUsuariosToolStripMenuItem
            // 
            this.asignacionPermisosUsuariosToolStripMenuItem.Name = "asignacionPermisosUsuariosToolStripMenuItem";
            this.asignacionPermisosUsuariosToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.asignacionPermisosUsuariosToolStripMenuItem.Text = "Asignacion Permisos Usuarios";
            this.asignacionPermisosUsuariosToolStripMenuItem.Click += new System.EventHandler(this.asignacionPermisosUsuariosToolStripMenuItem_Click);
            // 
            // desasignarPermisosToolStripMenuItem1
            // 
            this.desasignarPermisosToolStripMenuItem1.Name = "desasignarPermisosToolStripMenuItem1";
            this.desasignarPermisosToolStripMenuItem1.Size = new System.Drawing.Size(232, 22);
            this.desasignarPermisosToolStripMenuItem1.Text = "Desasignar Permisos";
            this.desasignarPermisosToolStripMenuItem1.Click += new System.EventHandler(this.desasignarPermisosToolStripMenuItem1_Click);
            // 
            // administracionUsuariosToolStripMenuItem
            // 
            this.administracionUsuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaUsuarioToolStripMenuItem,
            this.bajaUsuarioToolStripMenuItem,
            this.cambioDePasswordToolStripMenuItem1,
            this.desbloquearUsuarioToolStripMenuItem1});
            this.administracionUsuariosToolStripMenuItem.Name = "administracionUsuariosToolStripMenuItem";
            this.administracionUsuariosToolStripMenuItem.Size = new System.Drawing.Size(148, 20);
            this.administracionUsuariosToolStripMenuItem.Text = "Administracion Usuarios";
            // 
            // altaUsuarioToolStripMenuItem
            // 
            this.altaUsuarioToolStripMenuItem.Name = "altaUsuarioToolStripMenuItem";
            this.altaUsuarioToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.altaUsuarioToolStripMenuItem.Text = "Alta Usuario";
            this.altaUsuarioToolStripMenuItem.Click += new System.EventHandler(this.altaUsuarioToolStripMenuItem_Click);
            // 
            // bajaUsuarioToolStripMenuItem
            // 
            this.bajaUsuarioToolStripMenuItem.Name = "bajaUsuarioToolStripMenuItem";
            this.bajaUsuarioToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.bajaUsuarioToolStripMenuItem.Text = "Baja Usuario";
            this.bajaUsuarioToolStripMenuItem.Click += new System.EventHandler(this.bajaUsuarioToolStripMenuItem_Click);
            // 
            // cambioDePasswordToolStripMenuItem1
            // 
            this.cambioDePasswordToolStripMenuItem1.Name = "cambioDePasswordToolStripMenuItem1";
            this.cambioDePasswordToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.cambioDePasswordToolStripMenuItem1.Text = "Cambio de Password";
            this.cambioDePasswordToolStripMenuItem1.Click += new System.EventHandler(this.cambioDePasswordToolStripMenuItem1_Click);
            // 
            // desbloquearUsuarioToolStripMenuItem1
            // 
            this.desbloquearUsuarioToolStripMenuItem1.Name = "desbloquearUsuarioToolStripMenuItem1";
            this.desbloquearUsuarioToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.desbloquearUsuarioToolStripMenuItem1.Text = "Desbloquear Usuario";
            this.desbloquearUsuarioToolStripMenuItem1.Click += new System.EventHandler(this.desbloquearUsuarioToolStripMenuItem1_Click);
            // 
            // aBMToolStripMenuItem
            // 
            this.aBMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem,
            this.proveedorToolStripMenuItem});
            this.aBMToolStripMenuItem.Name = "aBMToolStripMenuItem";
            this.aBMToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.aBMToolStripMenuItem.Text = "ABM Negocio";
            this.aBMToolStripMenuItem.Click += new System.EventHandler(this.aBMToolStripMenuItem_Click);
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
            // menuIdioma
            // 
            this.menuIdioma.Name = "menuIdioma";
            this.menuIdioma.Size = new System.Drawing.Size(56, 20);
            this.menuIdioma.Tag = "menu_idioma";
            this.menuIdioma.Text = "Idioma";
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
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuIdioma;
        private System.Windows.Forms.ToolStripMenuItem aBMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaPermisosStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracionUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambioDePasswordToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem desbloquearUsuarioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem asignacionFamiliaPatenteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem asignacionPermisosUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desasignarPermisosToolStripMenuItem1;
    }
}