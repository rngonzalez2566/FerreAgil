﻿using BE.Composite;
using Interfaces;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class AsignacionFamiliaPatente : Form, IIdiomaObserver
    {
        BLL.Idioma idiomaBLL = new BLL.Idioma();
        BLL.Permiso permiso = new BLL.Permiso();
        Familia familia_Actual;

        public AsignacionFamiliaPatente()
        {
            InitializeComponent();
        }

        private void AsignacionFamiliaPatente_Load(object sender, EventArgs e)
        {
            SingletonSesion.SuscribirObservador(this);
            UpdateLanguage(SingletonSesion.GetUsuario().Idioma);
            cmbPatentes.DataSource = permiso.GetPatentes();
            cmbFamilias.DataSource = permiso.GetFamilias();
        }
        public void UpdateLanguage(IIdioma idioma)
        {
            Services.Idioma.Traductor.Traducir(idiomaBLL, idioma, this.Controls);

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            Familia tmp = (Familia)cmbFamilias.SelectedItem;
            familia_Actual = new Familia();
            familia_Actual.id = tmp.id;
            familia_Actual.nombre = tmp.nombre;

            CargarTreeFamilia(true);
        }

        private void CargarTreeFamilia(bool familia)
        {
            if (familia_Actual == null) return;

            IList<Componente> _familia = null;
            if (familia)
            {
                _familia = permiso.GetAll(familia_Actual.id);
                foreach (var i in _familia) familia_Actual.AgregarHijo(i);
            }
            else
            {
                _familia = familia_Actual.Hijos;
            }
            treePatenteFamilia.Nodes.Clear();
            TreeNode root = new TreeNode(familia_Actual.nombre);
            root.Tag = familia_Actual;
            treePatenteFamilia.Nodes.Add(root);

            foreach (var item in _familia)
            {
                MostrarEnTreePatenteFamilia(root, item);
            }
            treePatenteFamilia.ExpandAll();
        }

        private void MostrarEnTreePatenteFamilia(TreeNode tn, Componente comp)
        {
            TreeNode nodo = new TreeNode(comp.nombre);
            tn.Tag = comp;
            tn.Nodes.Add(nodo);
            if (comp.Hijos != null)
            {
                foreach (var item in comp.Hijos)
                {
                    MostrarEnTreePatenteFamilia(nodo, item);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (familia_Actual != null)
            {
                var patente = (Patente)cmbPatentes.SelectedItem;
                if (patente != null)
                {
                    var existeComp = permiso.existeComponente(familia_Actual, patente.id);
                    if (existeComp)
                    {
                        string Mensaje = "Patente ya cargada";
                        MessageBox.Show(Mensaje);
                    }
                    else
                    {
                        familia_Actual.AgregarHijo(patente);
                        CargarTreeFamilia(false);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (treePatenteFamilia.SelectedNode != null)
            {
                IList<Componente> familia = null;
                familia = familia_Actual.Hijos;
                foreach (var item in familia)
                {
                    if (treePatenteFamilia.SelectedNode.Text == item.nombre)
                    {
                        familia_Actual.BorrarHijo(item);
                    }
                }
                CargarTreeFamilia(false);
            }
        }

        private void btnAltaFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                permiso.CrearFamiliaPatente(familia_Actual);
                string Mensaje = "Familia Creada exitosamente";
                treePatenteFamilia.Nodes.Clear();
                MessageBox.Show(Mensaje);
            }
            catch
            {
                string Mensaje = "Error al guardar la Familia";
                MessageBox.Show(Mensaje);
            }
        }
    }
}