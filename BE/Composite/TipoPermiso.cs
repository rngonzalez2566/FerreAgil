﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    public enum TipoPermiso 
    {
        primero,
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
        Gestion_Ventas,
        Alta_Idioma,
        Alta_Etiquetas,
        Compra_Materiales,
        Pendiente_Envio_Prov,
        Recepcion_Materiales,
        Pendiente_Envio_Almacen,
        Recepcion_Almacen,
        Analisis_Stock,
        Gestion_Backup,
        Bitacora,
        Control_Cambios,
        Recalcular_digitos
    }
}
