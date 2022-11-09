using Gestion.Models;
using System.Data.SqlClient;
using System.Data;

namespace Gestion.Datos
{
    public class ClienteDatos
    {
        //lista de clientes
        public List<ClienteModel> Listar()
        {
            var oLista = new List<ClienteModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                //conexión al procedimiento almacenado Procedimiento de lista de clientes
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Lista_Clientes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var db = cmd.ExecuteReader())
                {
                    while (db.Read()) { // lectura del procedimiento almacenado
                      oLista.Add(new ClienteModel() { 
                          IdCliente = Convert.ToInt32(db["IdCliente"]),
                          Nombre = db["Nombre"].ToString(),
                          Domicilio = db["Domicilio"].ToString(),
                          Nif = db["Nif"].ToString(),
                          Cp = db["Cp"].ToString(),
                          Provincia = db["Provincia"].ToString(),
                          Fecha_Alta = Convert.ToDateTime(db["Fecha_Alta"]),
                          Pais = db["Pais"].ToString()                    

                      });               
                        
                    }
                }

            }
            return oLista;
        }

        //Obtenendo cliente
        public ClienteModel Obtener(int IdCliente)
        {
            var oCliente = new ClienteModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                //conexión al procedimiento almacenado Procedimiento de lista de clientes
                conexion.Open();
                SqlCommand cmd = new SqlCommand("[sp_Obtener_Cliente]", conexion);
                cmd.Parameters.AddWithValue("IdCliente", IdCliente);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var br = cmd.ExecuteReader())
                {
                    while (br.Read())
                    { // lectura del procedimiento almacenado

                        oCliente.IdCliente = Convert.ToInt32(br["IdCliente"]);
                        oCliente.Nombre = br["Nombre"].ToString();
                        oCliente.Domicilio = br["Domicilio"].ToString();
                        oCliente.Nif = br["Nif"].ToString();
                        oCliente.Cp = br["Cp"].ToString();
                        oCliente.Provincia = br["Provincia"].ToString();
                        oCliente.Fecha_Alta = Convert.ToDateTime(br["Fecha_Alta"]);
                        oCliente.Pais = br["Pais"].ToString();
                    }
                }

            }
            //retorna el objecto cliente
            return oCliente;
        }

        public bool Guardar(ClienteModel oCliente){
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Insert_Cliente", conexion);
                    cmd.Parameters.AddWithValue("Nombre", oCliente.Nombre);
                    cmd.Parameters.AddWithValue("Domicilio", oCliente.Domicilio);
                    cmd.Parameters.AddWithValue("Nif", oCliente.Nif);
                    cmd.Parameters.AddWithValue("Cp", oCliente.Cp);
                    cmd.Parameters.AddWithValue("Provincia", oCliente.Provincia);
                    cmd.Parameters.AddWithValue("Fecha_Alta", oCliente.Fecha_Alta);
                    cmd.Parameters.AddWithValue("Pais", oCliente.Pais);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();  
                }
               rpta = true;
            }
            catch(Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Editar(ClienteModel oCliente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Edit_Cliente", conexion);
                    cmd.Parameters.AddWithValue("IdCliente", oCliente.IdCliente);
                    cmd.Parameters.AddWithValue("Nombre", oCliente.Nombre);
                    cmd.Parameters.AddWithValue("Domicilio", oCliente.Domicilio);
                    cmd.Parameters.AddWithValue("Nif", oCliente.Nif);
                    cmd.Parameters.AddWithValue("Cp", oCliente.Cp);
                    cmd.Parameters.AddWithValue("Provincia", oCliente.Provincia);
                    cmd.Parameters.AddWithValue("Fecha_Alta", oCliente.Fecha_Alta);
                    cmd.Parameters.AddWithValue("Pais", oCliente.Pais);
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

        public bool Eliminar(int IdCliente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Delete_Cliente", conexion);
                    cmd.Parameters.AddWithValue("IdCliente",IdCliente );
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
