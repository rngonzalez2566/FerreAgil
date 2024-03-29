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
        List<Familia> _familiaAComparar;
        List<Familia> listaUnica;

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
            cmbFamiliasAgregar.DataSource = permiso.GetFamilias();
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
            try
            {
                if (familia_Actual == null) return;

                Componente _familia = new Familia();
                Componente componente = new Familia();

                if (familia)
                {
                    _familia = permiso.GetTraerHijos(familia_Actual.id, componente, null);

                    foreach (var i in _familia.Hijos) familia_Actual.AgregarHijo(i);
                }
                else
                {
                    _familia = familia_Actual;
                }

                treePatenteFamilia.Nodes.Clear();
                TreeNode root = new TreeNode(familia_Actual.nombre);
                root.Tag = familia_Actual;
                treePatenteFamilia.Nodes.Add(root);

                foreach (var item in _familia.Hijos)
                {
                    MostrarEnTreePatenteFamilia(root, item);
                }
                treePatenteFamilia.ExpandAll();
            }
            catch(Exception)
            {
                MessageBox.Show("Error al cargar arbol de permisos");
            }
        }

        private void MostrarEnTreePatenteFamilia(TreeNode tn, Componente comp)
        {
            try
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
            catch (Exception)
            {
                MessageBox.Show("Error al cargar arbol de permisos");
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (familia_Actual != null)
                {

                    Familia familia = (Familia)cmbFamiliasAgregar.SelectedItem;
                    if (familia.id == familia_Actual.id) throw new Exception("No se puede agregar esta familia");
                    ValidacionFamilias();
               

                    Componente _familia = new Familia();
                    Componente componente = new Familia();

                    _familia = permiso.GetTraerHijos(familia.id, componente, null);

                    foreach (var item in _familia.Hijos)
                    {
                        familia.AgregarHijo(item);
                    }

                    if (familia != null)
                    {
                        bool existeComponente = permiso.existeComponente(familia_Actual, familia.id);

                        if (existeComponente)
                            MessageBox.Show("Patente ya cargada");

                        else
                        {
                            familia_Actual.AgregarHijo(familia);
                            CargarTreeFamilia(false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void ValidacionFamilias()
        {
            try
            {
             
                _familiaAComparar  = new List<Familia>();
                var _familia = familia_Actual;
                Familia f = (Familia)cmbFamiliasAgregar.SelectedItem;
                _familiaAComparar.AddRange(permiso.GetFamiliasValidacion(_familia.id));
                List<Familia> copiaFamilia = new List<Familia>(_familiaAComparar);
                copiaFamilia.ForEach(x => LlenarFamilia(x.id));
                unificarLista(_familiaAComparar);
                foreach(var item in _familiaAComparar)
                {
                    if(item.id == f.id) throw new Exception("No se puede agregar esta familia");
                }


            }
            catch(Exception e)
            {
                throw new Exception("No se puede agregar esta familia");
            }
        }

        private void LlenarFamilia(int familiaId)
        {
            try
            {
                List<Familia> familias = permiso.GetFamiliasValidacion(familiaId);

                if (familias.Count > 0)
                {
                    _familiaAComparar.AddRange(familias);

                    foreach (Familia familia in familias)
                    {
                        LlenarFamilia(familia.id);
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception("No se puede agregar esta familia" + e.Message);
            }
        }
        public void unificarLista(List<Familia> _familiaAComparar)
        {
            List<Familia> listaUnica = new List<Familia>();
            foreach (var li in _familiaAComparar)
            {
                if (!listaUnica.Where(x => x.id == li.id).Any())
                {
                    listaUnica.Add(li);
                }
            }
        }
    }
}
