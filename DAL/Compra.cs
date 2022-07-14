using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Compra :Acceso
    {
        #region Consultas
        private const string get_UltimoNro = "SELECT TOP 1 NRO FROM COMPRA order by NRO desc";
        private const string alta_Compra = "INSERT INTO COMPRA (NRO, FECHA, DETALLE, TOTAL," +
                                     " ESTADO, ID_PROVEEDOR)" +
                                     " OUTPUT inserted.ID_COMPRA VALUES (@nro, @fecha, @detalle," +
                                     " @total, @estado, @prov)";
        private const string alta_Detalle_Compra = "INSERT INTO DETALLE_COMPRA (ID_COMPRA, ID_PRODUCTO, " +
                             "CANTIDAD, PRECIOUNITARIO,TOTAL)" +
                             "OUTPUT inserted.ID_DETALLE_COMPRA VALUES (@id_compra, @id_producto, @cantidad," +
                             "@pu, @total)";

        private const string get_Pendientes = "SELECT c.id_Compra ,NRO, FECHA, Detalle, TOTAL, c.id_Proveedor FROM COMPRA C " +
                                                        "WHERE C.ESTADO = @pendiente";
        private const string envio_proveedor = "update compra set Estado = @estado OUTPUT inserted.ID_COMPRA where nro = @nro";
        private const string get_Compra = "Select * from Compra where nro = @nro";
        #endregion

        #region ABM
        public int AltaCompra(BE.Compra compra)
        {
            try
            {
                xCommandText = alta_Compra;

                xParameters.Parameters.Clear();

                xParameters.Parameters.AddWithValue("@nro", compra.Nro );
                xParameters.Parameters.AddWithValue("@fecha",compra.Fecha);
                xParameters.Parameters.AddWithValue("@detalle",compra.Detalle );
                xParameters.Parameters.AddWithValue("@total",compra.Total );
                xParameters.Parameters.AddWithValue("@estado", compra.Estado);
                xParameters.Parameters.AddWithValue("@prov",compra.Proveedor.id_Proveedor );


                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int AltaDetalleCompra(BE.Detalle_Compra detalle, int idCompra)
        {
            try
            {
                xCommandText = alta_Detalle_Compra;

                xParameters.Parameters.Clear();

                xParameters.Parameters.AddWithValue("@id_compra", idCompra);
                xParameters.Parameters.AddWithValue("@id_producto", detalle.Producto.id_Producto);
                xParameters.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                xParameters.Parameters.AddWithValue("@pu", detalle.PrecioUnitario);
                xParameters.Parameters.AddWithValue("@total", detalle.Total);

              
                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        public int CambioEstado(int nro, string estado)
        {
            try
            {
                xCommandText = envio_proveedor;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@nro", nro);
                xParameters.Parameters.AddWithValue("@estado", estado);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion
        #region Gets
        public int GetUltimoComprobante()
        {
            int xNro = 0;
            try
            {
                DataTable dt = new DataTable();

                xCommandText = get_UltimoNro;
                xParameters.Parameters.Clear();
                dt = ExecuteReader();


                if (dt.Rows.Count > 0)
                {
                    xNro = int.Parse(dt.Rows[0]["NRO"].ToString()) + 1;
                }
                else
                {
                    xNro = 1;
                }
                return xNro;


            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public List<BE.Compra> GetPendientes(string pendiente)
        {
       
            try
            {
                DataTable dt = new DataTable();
                List<BE.Compra> lista = new List<BE.Compra>();
                
                xCommandText = get_Pendientes;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@pendiente", pendiente);
                dt = ExecuteReader();


                if (dt.Rows.Count > 0)
                {
                    BE.Proveedor prov = new BE.Proveedor();
                    DAL.Proveedor provDAL = new DAL.Proveedor();

                    foreach (DataRow fila in dt.Rows)
                    {

                        BE.Compra compra = new BE.Compra();

                        compra.id = int.Parse(fila[0].ToString());
                        compra.Nro = int.Parse(fila[1].ToString());
                        compra.Fecha = DateTime.Parse(fila[2].ToString());
                        compra.Detalle = fila[3].ToString();
                        compra.Total = float.Parse(fila[4].ToString());
                        prov = provDAL.GetProveedor(int.Parse(fila[5].ToString()));
                        compra.Proveedor = prov;
                        lista.Add(compra);
                    }
                    
                }

                return lista;


            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public BE.Compra GetCompra(int nro)
        {

            try
            {
                DataTable dt = new DataTable();
                BE.Producto Producto = new BE.Producto();

                xCommandText = get_Compra;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@nro", nro);
                dt = ExecuteReader();

                BE.Compra compra = new BE.Compra();

                if (dt.Rows.Count > 0)
                {
                    DAL.Proveedor provDAL = new DAL.Proveedor();
                    

                    compra.id = int.Parse(dt.Rows[0]["id_Compra"].ToString());
                    compra.Nro = int.Parse(dt.Rows[0]["Nro"].ToString());
                    compra.Fecha = DateTime.Parse(dt.Rows[0]["fecha"].ToString());
                    compra.Detalle = dt.Rows[0]["detalle"].ToString();
                    compra.Total = float.Parse(dt.Rows[0]["total"].ToString());
                    compra.Estado = dt.Rows[0]["estado"].ToString();
                    int idProveedor = int.Parse(dt.Rows[0]["id_proveedor"].ToString());
                    compra.Proveedor = provDAL.GetProveedor(idProveedor);
                }

                return compra;


            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }
        #endregion
    }
}
