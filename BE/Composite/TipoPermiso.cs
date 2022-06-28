using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    public enum TipoPermiso 
    {
        Administracion,
        Alta_Usuario,
        Baja_Usuario,
        Desbloquear_Usuario,
        Cambio_Password,
        Crear_Familia_Patentes,
        Asignar_Familia_Patentes,
        Asignar_Permisos_Usuarios,
        Desasignar_Permisos,
        Abm_Producto,
        Abm_Proveedor,
        Gestion_Compras,
        Gestion_Ventas
    }
}
