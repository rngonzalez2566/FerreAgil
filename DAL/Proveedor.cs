﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Proveedor : Acceso
    {
        #region Consultas
        private const string alta_Proveedor = "INSERT INTO Proveedor (razonSocial, Cuit, direccion, telefono," +
                                             " estado)" +
                                             " OUTPUT inserted.id_Proveedor VALUES (@razonSocial, @cuit, @direccion," +
                                             " @telefono, @estado)";

        private const string baja_Proveedor = "UPDATE Proveedor SET ESTADO = 'BAJA' OUTPUT inserted.id_Proveedor WHERE id_Proveedor = @id_Proveedor ";

        private const string modificacion_Proveedor = "UPDATE Proveedor SET RAZONSOCIAL = @razonSocial, SET CUIT = @cuit," +
                                                     " DIRECCION = @direccion, TELEFONO = @telefono," +
                                                     " ESTADO = @estado OUTPUT inserted.id_Proveedor  WHERE id_Proveedor = @id_Proveedor ";

        private const string get_Proveedor = "SELECT id_Proveedor, razonSocial, cuit, " +
                                             "isnull(direccion, '') direccion ,isnull(telefono,0) telefono "+
                                             ",isnull(estado,'') estado FROM Proveedor WHERE id_Proveedor = @id_Proveedor AND ESTADO is null ";

        private const string get_Proveedores = "SELECT id_Proveedor,razonSocial,cuit "+
                                               ",direccion,isnull(telefono,0),estado FROM Proveedor WHERE ESTADO is null ";
        #endregion

        #region ABM

        public int AltaProveedor(BE.Proveedor proveedor)
        {
            try
            {
                xCommandText = alta_Proveedor;

                xParameters.Parameters.Clear();

                xParameters.Parameters.AddWithValue("@razonSocial", proveedor.razonSocial);
                xParameters.Parameters.AddWithValue("@cuit", proveedor.cuit);
                xParameters.Parameters.AddWithValue("@direccion", proveedor.direccion);
                xParameters.Parameters.AddWithValue("@telefono", proveedor.telefono);
                xParameters.Parameters.AddWithValue("@estado", proveedor.estado);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int BajaProveedor(BE.Proveedor proveedor)
        {
            try
            {
                xCommandText = baja_Proveedor;

                xParameters.Parameters.Clear();

                xParameters.Parameters.AddWithValue("@id_proveedor", proveedor.id_Proveedor);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int ModificacionProveedor(BE.Proveedor proveedor)
        {
            try
            {
                xCommandText = modificacion_Proveedor;

                xParameters.Parameters.Clear();

                xParameters.Parameters.AddWithValue("@id_proveedor", proveedor.id_Proveedor);
                xParameters.Parameters.AddWithValue("@razonSocial", proveedor.razonSocial);
                xParameters.Parameters.AddWithValue("@cuit", proveedor.cuit);
                xParameters.Parameters.AddWithValue("@direccion", proveedor.direccion);
                xParameters.Parameters.AddWithValue("@telefono", proveedor.telefono);
                xParameters.Parameters.AddWithValue("@estado", proveedor.estado);


                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        #endregion

        #region Gets

        public BE.Proveedor GetProveedor(int proveedorId)
        {

            try
            {
                DataTable dt = new DataTable();
                BE.Proveedor Proveedor = new BE.Proveedor();

                xCommandText = get_Proveedor;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@id_proveedor", proveedorId);
                dt = ExecuteReader();


                if (dt.Rows.Count > 0)
                {

                    Proveedor.id_Proveedor = int.Parse(dt.Rows[0]["id_proveedor"].ToString());
                    Proveedor.razonSocial = dt.Rows[0]["razonSocial"].ToString();
                    Proveedor.cuit = int.Parse(dt.Rows[0]["cuit"].ToString());
                    Proveedor.direccion = dt.Rows[0]["direccion"].ToString();
                    Proveedor.telefono = int.Parse(dt.Rows[0]["telefono"].ToString());
                    Proveedor.estado = dt.Rows[0]["estado"].ToString();


                }
                else
                {
                    Proveedor = null;
                }
                return Proveedor;


            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public List<BE.Proveedor> GetProveedores()
        {
            try
            {
                DataTable dt = new DataTable();
                List<BE.Proveedor> listaProveedores = new List<BE.Proveedor>();

                xCommandText = get_Proveedores;
                xParameters.Parameters.Clear();
                dt = ExecuteReader();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        BE.Proveedor Proveedor = new BE.Proveedor();

                        Proveedor.id_Proveedor = int.Parse(fila[0].ToString());
                        Proveedor.razonSocial = fila[1].ToString();
                        Proveedor.cuit = int.Parse(fila[2].ToString());
                        Proveedor.direccion = fila[3].ToString();
                        Proveedor.telefono = int.Parse(fila[4].ToString());
                        Proveedor.estado = fila[5].ToString();

                        listaProveedores.Add(Proveedor);
                    }
                }


                return listaProveedores;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }


        }

        #endregion

    }
}
