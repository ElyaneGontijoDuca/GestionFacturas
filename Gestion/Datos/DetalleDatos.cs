
using Gestion.Models;
using System.Data.SqlClient;
using System.Data;

namespace Gestion.Datos
{
    public class DetalleDatos
    {

      //lista de Factura
        public List<DetalleModel> Listar(int IdFactura)
        {
            var oLista = new List<DetalleModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                //conexión al procedimiento almacenado Procedimiento de lista de Factura
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Lista_Detalle", conexion);
                cmd.Parameters.AddWithValue("IdFactura", IdFactura);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var db = cmd.ExecuteReader())
                {
                    while (db.Read())
                    { // lectura del procedimiento almacenado
                        oLista.Add(new DetalleModel()
                        {
                            IdDetalle = Convert.ToInt32(db["IdFactura"]),
                            IdFactura = Convert.ToInt32(db["IdFactura"]),
                            Concepto = db["Concepto"].ToString(),
                            Unidades = Convert.ToInt32(db["Unidades"]),
                            Importe = Convert.ToInt32(db["Importe"]),
                            Precio = Convert.ToInt32(db["Precio"])

                        });

                    }
                }

            }
            return oLista;
        }

       


        public bool Guardar(DetalleModel oDetalle)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Insert_DetalleFactura", conexion);
                    cmd.Parameters.AddWithValue("IdFactura", oDetalle.IdFactura);
                    cmd.Parameters.AddWithValue("Concepto", oDetalle.Concepto);
                    cmd.Parameters.AddWithValue("Importe", oDetalle.Importe);
                    cmd.Parameters.AddWithValue("Precio", oDetalle.Precio);
                    cmd.Parameters.AddWithValue("Unidades", oDetalle.Unidades);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Editar(DetalleModel oDetalle)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Edit_DetalleFactura", conexion);
                    cmd.Parameters.AddWithValue("IdDetalle", oDetalle.IdDetalle);
                    cmd.Parameters.AddWithValue("IdFactura", oDetalle.IdFactura);
                    cmd.Parameters.AddWithValue("Concepto", oDetalle.Concepto);
                    cmd.Parameters.AddWithValue("Importe", oDetalle.Importe);
                    cmd.Parameters.AddWithValue("Unidades", oDetalle.Unidades);
                    cmd.Parameters.AddWithValue("Precio", oDetalle.Unidades);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Eliminar(int IdDetalle)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Delete_Detalle", conexion);
                    cmd.Parameters.AddWithValue("IdDetalle", IdDetalle);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
    }
}
