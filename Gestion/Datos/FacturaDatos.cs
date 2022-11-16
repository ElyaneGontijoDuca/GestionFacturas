using Gestion.Models;
using System.Data.SqlClient;
using System.Data;

namespace Gestion.Datos
{
    public class FacturaDatos
    {
        //lista de Factura
        public List<FacturaModel> Listar()
        {
            var oLista = new List<FacturaModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                //conexión al procedimiento almacenado Procedimiento de lista de Factura
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Lista_Facturas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var db = cmd.ExecuteReader())
                {
                    while (db.Read())
                    { // lectura del procedimiento almacenado
                        oLista.Add(new FacturaModel()
                        {
                            IdFactura = Convert.ToInt32(db["IdFactura"]),
                            IdCliente = Convert.ToInt32(db["IdCliente"]),                         
                            Fecha = Convert.ToDateTime(db["Fecha"]),                          

                        });

                    }
                }

            }
            return oLista;
        }

        //Obtenendo Factura
        public FacturaModel Obtener(int IdFactura)
        {
            var oFactura = new FacturaModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                //conexión al procedimiento almacenado Procedimiento de lista de Factura
                conexion.Open();
                SqlCommand cmd = new SqlCommand("[sp_Obtener_Factura]", conexion);
                cmd.Parameters.AddWithValue("IdFactura", IdFactura);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var br = cmd.ExecuteReader())
                {
                    while (br.Read())
                    { // lectura del procedimiento almacenado

                        oFactura.IdFactura = Convert.ToInt32(br["IdFactura"]);
                        oFactura.IdCliente = Convert.ToInt32(br["IdCliente"]);
                        oFactura.Fecha = Convert.ToDateTime(br["Fecha"]);
                     }
                }

            }
            //retorna el objecto Factura
            return oFactura;
        }

        //Obtenendo Factura
        public FacturaModel ConsultaFactura(int factura)
        {
            var oFactura = new FacturaModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                //conexión al procedimiento almacenado Procedimiento de lista de Factura
                conexion.Open();
                SqlCommand cmd = new SqlCommand("[sp_Consulta_Factura]", conexion);
                cmd.Parameters.AddWithValue("IdFactura", factura);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var br = cmd.ExecuteReader())
                {
                    while (br.Read())
                    { // lectura del procedimiento almacenado

                        oFactura.IdFactura = Convert.ToInt32(br["IdFactura"]);
                        oFactura.IdCliente = Convert.ToInt32(br["IdCliente"]);
                        oFactura.Fecha = Convert.ToDateTime(br["Fecha"]);
                       
                    }
                }

            }
            //retorna la consulta de Factura
            return oFactura;
        }


        public bool Guardar(FacturaModel oFactura)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Insert_Factura", conexion);
                    cmd.Parameters.AddWithValue("IdCliente", oFactura.IdCliente);              
                    cmd.Parameters.AddWithValue("Fecha", oFactura.Fecha);                  
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

        public bool Editar(FacturaModel oFactura)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Edit_Factura", conexion);
                    cmd.Parameters.AddWithValue("IdFactura", oFactura.IdFactura);
                    cmd.Parameters.AddWithValue("IdCliente", oFactura.IdCliente);
                    cmd.Parameters.AddWithValue("Fecha", oFactura.Fecha);                   
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

        public bool Eliminar(int IdFactura)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Delete_Factura", conexion);
                    cmd.Parameters.AddWithValue("IdFactura", IdFactura);
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
