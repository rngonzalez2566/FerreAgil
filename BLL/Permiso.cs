using BE.Composite;
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

        #region ABM
        public void AltaPermiso(Componente cmp, bool esFamilia)
        {
            validarAlta(cmp, esFamilia);
            permiso.AltaPermiso(cmp, esFamilia);
        }
        public void CrearFamiliaPatente(Familia familia)
        {
            permiso.CrearFamiliaPatente(familia);
        }

        public void GuardarPermisoUsuario(BE.Usuario user)
        {
            permiso.GuardarPermiso(user);
        }
        #endregion

        #region Gets
        public Array GetTipoPermiso()
        {
            return permiso.GetTipoPermiso();
        }

        public IList<Patente> GetPatentes()
        {
            return permiso.GetPatentes();
        }

        public IList<Familia> GetFamilias()
        {
            return permiso.GetFamilias();
        }

        public IList<Familia> GetFamiliasValidacion(int id)
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
