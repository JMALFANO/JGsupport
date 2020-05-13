using Entidades;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class dalPersonal : Conexion
    {

        /// <summary>
        /// Inserta un nuevo cliente en la tabla cliente
        /// </summary>
        /// <param name="personal">Entidad contenedora de los valores a insertar</param>
        public void Insertar(Personal personal)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "personal_ins";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", personal.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", personal.Apellido);
                    cmd.Parameters.AddWithValue("@Mail", personal.Mail);
                    cmd.Parameters.AddWithValue("@Telefono", personal.Telefono);
                    cmd.Parameters.AddWithValue("@Contraseña", personal.Contraseña);
                    cmd.Parameters.AddWithValue("@Activo", personal.Activo);
                    cmd.Parameters.AddWithValue("@id_privilegio", personal.Privilegio.id_privilegio);
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser insertada en la tabla.");
                }
            }

            this.SetID(personal);
        }

        /// <summary>
        /// Actualiza el cliente correspondiente al Id proporcionado
        /// </summary>
        /// <param name="cliente">Valores utilizados para hacer el Update al registro</param>
        public void Modificar(Personal personal)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = cnx;
                    cmd.CommandText = "personal_upd";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_personal", personal.PersonalId);
                    cmd.Parameters.AddWithValue("@Nombre", personal.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", personal.Apellido);
                    cmd.Parameters.AddWithValue("@Mail", personal.Mail);
                    cmd.Parameters.AddWithValue("@Telefono", personal.Telefono);
                    cmd.Parameters.AddWithValue("@Contraseña", personal.Contraseña);
                    cmd.Parameters.AddWithValue("@Activo", personal.Activo);
                    cmd.Parameters.AddWithValue("@id_privilegio", personal.Privilegio.id_privilegio);
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser modificada en la tabla.");
                }
            }
        }

        /// <summary>
        /// Establece el valor de la propiedad Id de un Cliente.
        /// </summary>
        /// <param name="cliente"></param>
        private void SetID(Personal personal)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "personal_sel_max_id_personal";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0] != DBNull.Value)
                    {
                        personal.PersonalId = Convert.ToInt32(dataTable.Rows[0][0]);
                    }
                }
            }
        }

        /// <summary>
        /// Busca un personal por su clave primaria.
        /// </summary>
        /// <param name="idPersonal"></param>
        /// <returns></returns>
        /*
        public Personal ObtenerPorId(int idPersonal)
        {
            Personal personal = null;
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "personal_sel_by_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_personal", idPersonal);

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    if (table.Rows.Count != 0)
                    {
                        DataRow row = table.Rows[0];
                        personal = new Personal

                        {
                            PersonalId = Convert.ToInt32(row["id_personal"]),
                            Nombre = Convert.ToString(row["Nombre"]),
                            Apellido = Convert.ToString(row["Apellido"]),
                            Mail = Convert.ToString(row["Mail"]),
                            Telefono = Convert.ToString(row["Telefono"]),
                            Contraseña = Convert.ToString(row["Contraseña"]),
                            Activo = Convert.ToBoolean(row["Activo"]),
                        //    Privilegio = new dalPrivilegio().Map()
                    };
                    }
                }
            }
            return personal;
        }

            */ //ObtenerPorID CON STORE PROCEDURE. ¿Como parseo el (int) en obj(Privilegio)?

        public Personal ObtenerPorId(int idUsuario)
        {
            SQL = "SELECT id_personal, Nombre, Apellido, Mail, Telefono, Contraseña, Activo, P.id_privilegio, P.privilegio_desc from Personal AS A ";
            SQL = SQL + "INNER JOIN Privilegio AS P ON P.id_privilegio = A.id_privilegio ";
            SQL = SQL + "WHERE id_personal =@id_personal ";
            objComando.CommandText = SQL;
            objComando.Parameters.AddWithValue("@id_personal", idUsuario);
            Personal Item = null;
            try
            {
                objConexion.Open();
                SqlDataReader objReader = objComando.ExecuteReader();

                if (objReader.Read())
                {
                    Item = this.Map(objReader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objConexion.State == System.Data.ConnectionState.Open)
                {
                    objConexion.Close();
                }
            }
            return Item;
        }

























        public int ValidarUsuario(string mail, string contraseña)
        {
            int privilegio;
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("personal_login"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña);
                    cmd.Connection = con;
                    con.Open();
                    privilegio = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }

            }

            return privilegio;

        }



        public int ObtenerIdUsuario(string mail, string contraseña)
        {
            int id;
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("personal_id"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña);
                    cmd.Connection = con;
                    con.Open();
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }

            }

            return id;

        }








        public List<Personal> ListarPorCategoria(int id_privilegio)
        {

            List<Personal> Lista = new List<Personal>();
            Personal Item;

            
                        SQL = "SELECT id_personal, Nombre, Apellido, Mail, Telefono, Contraseña, Activo, S.id_privilegio, C.privilegio_desc FROM Personal AS S ";
                        SQL = SQL + "INNER JOIN Privilegio AS C ON C.id_privilegio = S.id_privilegio ";
                        SQL = SQL + "WHERE C.id_privilegio=@id_privilegio ";
                        SQL = SQL + " ORDER BY id_personal";

         //   SQL = "SELECT id_personal, Nombre, Apellido, Mail, Telefono, Contraseña, Activo FROM Personal WHERE id_privilegio = @id_privilegio ORDER BY id_personal";
           /* SQL = "SELECT id_personal, Nombre, Apellido, Mail, Telefono, Contraseña, Activo FROM Personal ";
            SQL = SQL + "WHERE id_privilegio = @id_privilegio ";
            SQL = SQL + " ORDER BY id_personal";
            */

            objComando.CommandText = SQL;
            objComando.Parameters.AddWithValue("@id_privilegio", id_privilegio);

            try
            {
                objConexion.Open();
                SqlDataReader objReader = objComando.ExecuteReader();
                while (objReader.Read())
                {         
                   Item = this.Map(objReader);

                    Lista.Add(Item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objConexion.State == System.Data.ConnectionState.Open)
                {
                    objConexion.Close();
                }
            }
            return Lista;
        }



        public List<Personal> ListarClientes()
        {

            List<Personal> Lista = new List<Personal>();
            SQL = "SELECT id_personal, Nombre, Apellido FROM Personal WHERE id_privilegio = 1 ORDER BY Nombre";
  
            objComando.CommandText = SQL;

            try
            {
                objConexion.Open();
                SqlDataReader objReader = objComando.ExecuteReader();
                while (objReader.Read())
                {
                    Personal Item = new Personal();
                    Item.PersonalId = (int)objReader["id_personal"];
                    Item.Nombre = (string)objReader["Nombre"];
                    Item.Apellido = (string)objReader["Apellido"];

                    Lista.Add(Item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objConexion.State == System.Data.ConnectionState.Open)
                {
                    objConexion.Close();
                }
            }
            return Lista;
        }

        public List<Personal> ListarTecnicos()
        {

            List<Personal> Lista = new List<Personal>();


              SQL = "SELECT id_personal, Nombre FROM Personal WHERE id_privilegio = 2 ORDER BY Nombre";

            //  SQL = "SELECT id_personal, Nombre + ' ' + Apellido FROM Personal WHERE id_privilegio = 2 ORDER BY Nombre";

            objComando.CommandText = SQL;

            try
            {
                objConexion.Open();
                SqlDataReader objReader = objComando.ExecuteReader();
                while (objReader.Read())
                {
                    Personal Item = new Personal();
                    Item.PersonalId = (int)objReader["id_personal"];
                    Item.Nombre = (string)objReader["Nombre"];
                  //  Item.Apellido = (string)objReader["Apellido"];

                    Lista.Add(Item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objConexion.State == System.Data.ConnectionState.Open)
                {
                    objConexion.Close();
                }
            }
            return Lista;
        }


        /// <summary>
        /// Devuelve una lista con todos los socios ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <remarks>
        /// Utiliza un SqlDataAdapter.
        /// </remarks>
        /// <returns>Lista de socios</returns>
        public List<Personal> Listar()
        {
            List<Personal> personals = new List<Personal>();
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "personal_sel_all";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Personal personal = new Personal
                        {
                            PersonalId = Convert.ToInt32(row["id_personal"]),
                            Nombre = Convert.ToString(row["Nombre"]),
                            Apellido = Convert.ToString(row["Apellido"]),
                            Mail = Convert.ToString(row["Mail"]),
                            Telefono = Convert.ToString(row["Telefono"]),
                            Contraseña = Convert.ToString(row["Contraseña"]),
                            Activo = Convert.ToBoolean(row["Activo"])
                        };
                        personals.Add(personal);
                    }
                }
            }
            return personals;
        }




        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>        
        public void Delete(int PersonalId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "personal_del";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_personal", PersonalId);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /*     public Socio ObtenerPorNroSocio(int nroSocio)
             {
                 SQL = "SELECT SocioId, Nombre, Apellido, NroSocio, Activo, S.CategoriaId, C.CategoriaDesc FROM tbl_Socio AS S ";
                 SQL = SQL + "INNER JOIN tbl_Categoria AS C ON C.CategoriaId = S.CategoriaId ";
                 SQL = SQL + "WHERE NroSocio=@NroSocio ";
                 objComando.CommandText = SQL;
                 objComando.Parameters.AddWithValue("@NroSocio", nroSocio);
                 Socio Item = null;
                 try
                 {
                     objConexion.Open();
                     SqlDataReader objReader = objComando.ExecuteReader();

                     if (objReader.Read())
                     {
                         Item = this.Map(objReader);
                     }
                 }
                 catch (Exception ex)
                 {
                     throw ex;
                 }
                 finally
                 {
                     if (objConexion.State == System.Data.ConnectionState.Open)
                     {
                         objConexion.Close();
                     }
                 }
                 return Item;
             }
             */
           
        public Personal Map(SqlDataReader objReader)

        {
            Personal Item = new Personal();
            Item.PersonalId = (int)objReader["id_personal"];
            Item.Nombre = (string)objReader["Nombre"];
            Item.Apellido = (string)objReader["Apellido"];
            Item.Mail = (string)objReader["Mail"];
            Item.Telefono = (string)objReader["Telefono"];
            Item.Contraseña = (string)objReader["Contraseña"];
            Item.Activo = (bool)objReader["Activo"];
            Item.Privilegio = new dalPrivilegio().Map(objReader);
            return Item;
        }

    }
}