﻿using BE.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Permiso
    {
        DAL.Permiso permiso = new DAL.Permiso();
        BLL.Bitacora bit = new BLL.Bitacora();

        #region ABM
        public void AltaPermiso(Componente cmp, bool esFamilia)
        {
            validarAlta(cmp, esFamilia);
            permiso.AltaPermiso(cmp, esFamilia);
            bit.RegistrarBitacora("SE DIO DE ALTA UN PERMISO", "ALTA");
        }
        public void CrearFamiliaPatente(Familia familia)
        {
            permiso.CrearFamiliaPatente(familia);
            bit.RegistrarBitacora("SE ASIGNO PERMISOS A FAMILIA", "ALTA");
        }

        public void GuardarPermisoUsuario(BE.Usuario user)
        {
            permiso.GuardarPermiso(user);
            bit.RegistrarBitacora("SE ASIGNO PERMISOS A USUARIO", "ALTA");
        }
        #endregion

        #region Gets
        public Array GetTipoPermiso()
        {
            return permiso.GetTipoPermiso();
        }
        public Componente GetTraerHijos(int familiaId, Componente componenteOriginal, Componente componenteAgregar)
        {
            return permiso.GetTraerHijos( familiaId,  componenteOriginal,  componenteAgregar);
        }

        public Componente GetPermisosUsuarios(int usuarioId, Componente componenteOriginal, Componente componenteAgregar)
        {
            return permiso.GetPermisosUsuarios( usuarioId,  componenteOriginal,  componenteAgregar);
        }

            public IList<Patente> GetPatentes()
        {
            return permiso.GetPatentes();
        }

        public IList<Familia> GetFamilias()
        {
            return permiso.GetFamilias();
        }

        public List<Familia> GetFamiliasValidacion(int id)
        {
            return permiso.GetFamiliasValidacion(id);
        }

        public IList<Componente> GetAll(int familia)
        {
            return permiso.GetAll(familia);
        }

        public bool existeComponente(Componente comp, int id)
        {
            return permiso.existeComponente(comp, id);
        }

        public void GetUsuarioPermiso(BE.Usuario user)
        {
            permiso.GetUsuarioPermiso(user);
        }

        public void LlenarComponenteFamilia(Familia familia)
        {
            permiso.LlenarComponenteFamilia(familia);
        }

        public bool VerificarPermiso(BE.Usuario user, string Permiso)
        {
            return permiso.VerificarPermiso(user, Permiso);
        }
        #endregion

        #region Validaciones
        public void validarAlta(Componente cmp, bool esFamilia)
        {
            if (string.IsNullOrEmpty(cmp.nombre)) throw new Exception("El nombre es Requerido");
            if (esFamilia == false && string.IsNullOrEmpty(cmp.Permiso.ToString())) throw new Exception("El Permiso es obligatorio");
            if (permiso.GetPermiso(cmp.nombre.ToUpper())) throw new Exception("El nombre del permiso ya existe");
        }

        #endregion
    }
}
