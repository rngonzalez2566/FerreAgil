using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Producto : Acceso
    {
        #region Consultas
        private const string alta_Producto = "INSERT INTO Producto (codigo, descripcion, Id_unidadMedida, StockMinimo," +
                                             " StockOptimo, LeadTimeCompra, ConsumoMensual, ConsumoTrimestral, ConsumoSemestral)" +
                                             " OUTPUT inserted.Id_producto VALUES (@codigo, @descripcion, @id_unidadMedida,"+
                                             " @stockMinimo, @stockOptimo, @LeadTimeCompra, @ConsumoMensual, @ConsumoTrimestral, @ConsumoSemestral)";

        private const string baja_Producto = "UPDATE PRODUCTO SET ESTADO = 'BAJA' OUTPUT inserted.ID_PRODUCTO WHERE ID_PRODUCTO = @id_Producto ";

        private const string modificacion_Producto = "UPDATE PRODUCTO SET CODIGO = @codigo, DESCRIPCION = @descripcion," +
                                                     " ID_UNIDADMEDIDA = @id_unidadMedida, STOCKMINIMO = @stockMinimo," +
                                                     " STOCKOPTIMO = @stockOptimo, PRECIOUNITARIO = @pu OUTPUT inserted.ID_PRODUCTO  WHERE ID_PRODUCTO = @id_Producto ";

        private const string get_Producto = "SELECT * FROM PRODUCTO WHERE ID_PRODUCTO = @id_Producto  AND ESTADO IS NULL";

        private const string get_Productos = "SELECT * FROM PRODUCTO WHERE ESTADO is null order by id_producto desc";
        #endregion

        #region ABM

        public int AltaProducto(BE.Producto producto)
        {
            try
            {
                xCommandText = alta_Producto;

                xParameters.Parameters.Clear();

                xParameters.Parameters.AddWithValue("@codigo", producto.codigo);
                xParameters.Parameters.AddWithValue("@descripcion", producto.descripcion);
                xParameters.Parameters.AddWithValue("@id_unidadMedida", producto.unidadMedida.id_UnidadMedida);
                xParameters.Parameters.AddWithValue("@stockMinimo", producto.stockMinimo);
                xParameters.Parameters.AddWithValue("@stockOptimo", producto.stockOptimo);
                xParameters.Parameters.AddWithValue("@LeadTimeCompra", producto.leadTimeCompra);
                xParameters.Parameters.AddWithValue("@ConsumoMensual", producto.consumoMensual);
                xParameters.Parameters.AddWithValue("@ConsumoTrimestral", producto.consumoTrimestral);
                xParameters.Parameters.AddWithValue("@ConsumoSemestral", producto.consumoSemestral);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int BajaProducto(BE.Producto producto)
        {
            try
            {
                xCommandText = baja_Producto;

                xParameters.Parameters.Clear();

                xParameters.Parameters.AddWithValue("@id_producto", producto.id_Producto);

                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public int ModificacionProducto(BE.Producto producto)
        {
            try
            {
                xCommandText = modificacion_Producto;

                xParameters.Parameters.Clear();

                xParameters.Parameters.AddWithValue("@id_producto", producto.id_Producto);
                xParameters.Parameters.AddWithValue("@codigo", producto.codigo);
                xParameters.Parameters.AddWithValue("@descripcion", producto.descripcion);
                xParameters.Parameters.AddWithValue("@id_unidadMedida", producto.unidadMedida.id_UnidadMedida);
                xParameters.Parameters.AddWithValue("@stockMinimo", producto.stockMinimo);
                xParameters.Parameters.AddWithValue("@stockOptimo", producto.stockOptimo);
                xParameters.Parameters.AddWithValue("@pu", producto.PrecioUnitario);


                return ExecuteNonEscalar();
            }
            catch
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        #endregion

        #region Gets

        public BE.Producto GetProducto(int productoId)
        {

            try
            {
                DataTable dt = new DataTable();
                BE.Producto Producto = new BE.Producto();

                xCommandText = get_Producto;
                xParameters.Parameters.Clear();
                xParameters.Parameters.AddWithValue("@id_producto", productoId);
                dt = ExecuteReader();


                if (dt.Rows.Count > 0)
                {

                        UnidadMedida um = new UnidadMedida();

                        Producto.id_Producto = int.Parse(dt.Rows[0]["id_producto"].ToString());
                        Producto.codigo = dt.Rows[0]["codigo"].ToString();
                        Producto.descripcion = dt.Rows[0]["descripcion"].ToString();
                        Producto.leadTimeCompra = int.Parse(dt.Rows[0]["leadTimeCompra"].ToString());
                        Producto.consumoMensual = float.Parse(dt.Rows[0]["consumoMensual"].ToString());
                        Producto.consumoTrimestral = float.Parse(dt.Rows[0]["consumoTrimestral"].ToString());
                        Producto.consumoSemestral = float.Parse(dt.Rows[0]["consumoSemestral"].ToString());
                        Producto.stockMinimo = float.Parse(dt.Rows[0]["stockMinimo"].ToString());
                        Producto.stockOptimo = float.Parse(dt.Rows[0]["stockOptimo"].ToString());
                        Producto.estado = dt.Rows[0]["estado"].ToString();
                        Producto.unidadMedida = um.GetUnidadMedida(int.Parse(dt.Rows[0]["id_unidadMedida"].ToString()));
                        Producto.PrecioUnitario = float.Parse(dt.Rows[0]["PrecioUnitario"].ToString());
                }

                return Producto;

    
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
        }

        public List<BE.Producto> GetProductos()
        {
            try
            {
                DataTable dt = new DataTable();
                List<BE.Producto> listaProductos = new List<BE.Producto>();

                xCommandText = get_Productos;
                xParameters.Parameters.Clear();
                dt = ExecuteReader();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {

                        UnidadMedida um = new UnidadMedida();
                        BE.Producto Producto = new BE.Producto();

                        Producto.id_Producto = int.Parse(fila[0].ToString());
                        Producto.codigo = fila[1].ToString();
                        Producto.descripcion = fila[2].ToString();
                        Producto.unidadMedida = um.GetUnidadMedida(int.Parse(fila[3].ToString()));
                        Producto.leadTimeCompra = int.Parse(fila[4].ToString());
                        Producto.consumoMensual = float.Parse(fila[5].ToString());
                        Producto.consumoTrimestral = float.Parse(fila[6].ToString());
                        Producto.consumoSemestral = float.Parse(fila[7].ToString());
                        Producto.stockMinimo = float.Parse(fila[8].ToString());
                        Producto.stockOptimo = float.Parse(fila[9].ToString());
                        Producto.estado = fila[10].ToString();
                        Producto.PrecioUnitario = float.Parse(fila[11].ToString());


                        listaProductos.Add(Producto);
                    }
                }


                return listaProductos;
            }
            catch (Exception)
            {
                throw new Exception("Error en la base de datos.");
            }
          

        }

        #endregion

    }
}
