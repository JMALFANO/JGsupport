using Entidades;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
   public  class dalSolicitud : Conexion
    {

        /// <summary>
        /// Inserta un nuevo cliente en la tabla cliente
        /// </summary>
        /// <param name="solicitud">Entidad contenedora de los valores a insertar</param>
        public void Insertar(Solicitud solicitud)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "solicitud_ins";
                    cmd.CommandType = CommandType.StoredProcedure;                  
                    cmd.Parameters.AddWithValue("@fecha_inicio", solicitud.FechaInicio);
                    cmd.Parameters.AddWithValue("@fecha_fin", solicitud.FechaFin);
                    cmd.Parameters.AddWithValue("@tecnico_asignado", solicitud.TecnicoAsignado);
                    cmd.Parameters.AddWithValue("@id_cliente", solicitud.Cliente);
                    cmd.Parameters.AddWithValue("@descripcion_tarea", solicitud.DescripcionTarea);
                    cmd.Parameters.AddWithValue("@estado", solicitud.Estado);
                    cmd.Parameters.AddWithValue("@prioridad", solicitud.Prioridad);
                    cmd.Parameters.AddWithValue("@complejidad", solicitud.Complejidad);
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser insertada en la tabla.");
                }
            }

            this.SetID(solicitud);
        }

        /// <summary>
        /// Actualiza el cliente correspondiente al Id proporcionado
        /// </summary>
        /// <param name="cliente">Valores utilizados para hacer el Update al registro</param>
        public void Modificar(Solicitud solicitud)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = cnx;
                    cmd.CommandText = "solicitud_upd";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_solicitud", solicitud.SolicitudId);                              
                    cmd.Parameters.AddWithValue("@tecnico_asignado", solicitud.TecnicoAsignado);
                    cmd.Parameters.AddWithValue("@id_cliente", solicitud.Cliente);
                    cmd.Parameters.AddWithValue("@descripcion_tarea", solicitud.DescripcionTarea);
                    cmd.Parameters.AddWithValue("@estado", solicitud.Estado);
                    cmd.Parameters.AddWithValue("@prioridad", solicitud.Prioridad);
                    cmd.Parameters.AddWithValue("@complejidad", solicitud.Complejidad);
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser modificada en la tabla.");
                }
            }
        }

        /// <summary>
        /// Actualiza el cliente correspondiente al Id proporcionado
        /// </summary>
        /// <param name="cliente">Valores utilizados para hacer el Update al registro</param>
        public void Finalizar(Solicitud solicitud)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = cnx;
                    cmd.CommandText = "solicitud_finalizar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_solicitud", solicitud.SolicitudId);
                    cmd.Parameters.AddWithValue("@fecha_fin", solicitud.FechaFin);
                    cmd.Parameters.AddWithValue("@estado", solicitud.Estado);

                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser modificada en la tabla.");
                }
            }
        }

        /// <summary>
        /// Establece el valor de la propiedad Id de un Cliente.
        /// </summary>
        /// <param name="cliente"></param>
        private void SetID(Solicitud solicitud)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "solicitud_sel_max_id_solicitud";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0] != DBNull.Value)
                    {
                        solicitud.SolicitudId = Convert.ToInt32(dataTable.Rows[0][0]);
                    }
                }
            }
        }

        public List<Solicitud> ObtenerListaPorId(int id_cliente)
        {

            List<Solicitud> Lista = new List<Solicitud>();


            SQL = "SELECT id_solicitud, fecha_inicio, fecha_fin, M.nombre as tecnicoAsignado, id_cliente, descripcion_tarea, estado, prioridad, complejidad FROM Solicitud AS A ";
            SQL = SQL + "INNER JOIN Personal AS M ON M.id_personal = A.tecnico_asignado ";
            SQL = SQL + " INNER JOIN PERSONAL AS N on N.nombre = M.nombre where id_cliente = @id_cliente";

            objComando.CommandText = SQL;
            objComando.Parameters.AddWithValue("@id_cliente", id_cliente);

            try
            {
                objConexion.Open();
                SqlDataReader objReader = objComando.ExecuteReader();
                while (objReader.Read())
                {
                    Solicitud Item = new Solicitud();
                    Item.SolicitudId = Convert.ToInt32(objReader["id_solicitud"]);
                    Item.FechaInicio = Convert.ToDateTime(objReader["fecha_inicio"]);
                    //  if (objReader["fecha_fin"] == DBNull.Value) Item.FechaFin = default(DateTime);
                    // if (objReader["fecha_fin"] != DBNull.Value) Item.FechaFin = Convert.ToDateTime(objReader["fecha_fin"]);     
                    Item.FechaFin = Convert.ToDateTime(objReader["fecha_fin"]);
                    Item.nombreTecnico = Convert.ToString(objReader["tecnicoAsignado"]);
                    Item.Cliente = Convert.ToInt32(objReader["id_cliente"]);
                    Item.DescripcionTarea = Convert.ToString(objReader["descripcion_tarea"]);
                    Item.Estado = (EstadoSolicitudEnum)Convert.ToInt32(objReader["estado"]);
                    Item.Prioridad = (PrioridadSolicitudEnum)Convert.ToInt32(objReader["prioridad"]);
                    Item.Complejidad = (ComplejidadSolicitudEnum)Convert.ToInt32(objReader["complejidad"]);
               

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
        /// Busca un solicitud por su clave primaria.
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <returns></returns>
       public Solicitud ObtenerPorSolicitudId(int idSolicitud)
        {
            Solicitud solicitud = null;
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "solicitud_sel_by_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    if (table.Rows.Count != 0)
                    {
                        DataRow row = table.Rows[0];

                            solicitud = new Solicitud
                            {
                                SolicitudId = Convert.ToInt32(row["id_solicitud"]),
                                FechaInicio = Convert.ToDateTime(row["fecha_inicio"]),
                                FechaFin = Convert.ToDateTime(row["fecha_fin"]),
                                TecnicoAsignado = Convert.ToInt32(row["tecnico_asignado"]),
                                Cliente = Convert.ToInt32(row["id_cliente"]),
                                DescripcionTarea = Convert.ToString(row["descripcion_tarea"]),
                                Estado = (EstadoSolicitudEnum)Convert.ToInt32(row["estado"]),
                                Prioridad = (PrioridadSolicitudEnum)Convert.ToInt32(row["prioridad"]),
                                Complejidad = (ComplejidadSolicitudEnum)Convert.ToInt32(row["complejidad"])
                            };                      
                    }
                }
            }
            return solicitud;
        }




        public List<Solicitud> ObtenerPorFormulario(string fechaDesde, string fechaHasta, int cliente, int filtrado)
        {

            List<Solicitud> Lista = new List<Solicitud>();


            String CadenaSQL = "";

            switch (filtrado)
            {
                case 100: //SIN VER 
                    CadenaSQL = CadenaSQL + " AND ESTADO = 1";
                    break;

                case 110: //SIN VER + PENDIENTE
                    CadenaSQL = CadenaSQL + " AND ESTADO = 1 OR ESTADO = 2 ";
                    break;

                case 111: //SIN VER + PENDIENTE + FINALIZADO
                    CadenaSQL = CadenaSQL + " AND ESTADO = 1 OR ESTADO = 2 OR ESTADO = 3";
                    break;

                case 001: //FINALIZADO
                    CadenaSQL = CadenaSQL + " AND ESTADO = 3 ";
                    break;

                case 011: //PENDIENTE + FINALIZADO
                    CadenaSQL = CadenaSQL + " AND ESTADO = 2 OR ESTADO = 3";
                    break;

                case 010: //PENDIENTE
                    CadenaSQL = CadenaSQL + " AND ESTADO = 2";
                    break;

                case 101: //SIN VER + FINALIZADO
                    CadenaSQL = CadenaSQL + " AND ESTADO = 1 OR ESTADO = 3";
                    break;         
            }



            if (cliente != 0) //CLIENTE COMUN
            {

                
                                SQL = "SELECT id_solicitud, fecha_inicio, fecha_fin, M.nombre as tecnicoAsignado, (select nombre + ' ' + apellido from personal where id_personal = id_cliente) as nombreCliente, id_cliente, descripcion_tarea, estado, prioridad, complejidad FROM Solicitud AS A ";
                                SQL = SQL + "INNER JOIN Personal AS M ON M.id_personal = A.tecnico_asignado ";
                                SQL = SQL + " INNER JOIN PERSONAL AS N on N.nombre = M.nombre WHERE fecha_inicio >= @fecha_desde AND fecha_fin < dateadd(day, 1, @fecha_hasta) AND id_cliente = @id_cliente ";
                                SQL = SQL + CadenaSQL;

                /*SQL = "SELECT id_solicitud, fecha_inicio, fecha_fin, (select nombre from personal where id_personal = tecnico_asignado) as tecnicoAsignado, (select nombre + ' ' + apellido from personal where id_personal = id_cliente) as nombreCliente, id_cliente, descripcion_tarea, estado, prioridad, complejidad FROM Solicitud ";
                SQL = SQL + " WHERE fecha_inicio >= @fecha_desde AND fecha_fin < dateadd(day, 1, @fecha_hasta) AND id_cliente = @id_cliente ";
                */

            }
            else //TODOS LOS CLIENTES
            {
                SQL = "SELECT id_solicitud, fecha_inicio, fecha_fin, M.nombre as tecnicoAsignado, (select nombre + ' ' + apellido from personal where id_personal = id_cliente) as nombreCliente, descripcion_tarea, estado, prioridad, complejidad FROM Solicitud AS A ";
                SQL = SQL + "INNER JOIN Personal AS M ON M.id_personal = A.tecnico_asignado ";
                SQL = SQL + " INNER JOIN PERSONAL AS N on N.nombre = M.nombre WHERE fecha_inicio >= @fecha_desde AND fecha_fin < dateadd(day, 1, @fecha_hasta) ";
                SQL = SQL + CadenaSQL;
            }

           

            objComando.CommandText = SQL;
            objComando.Parameters.AddWithValue("@fecha_desde", fechaDesde);
            objComando.Parameters.AddWithValue("@fecha_hasta", fechaHasta);
            objComando.Parameters.AddWithValue("@id_cliente", cliente);



            try
            {
                objConexion.Open();
                SqlDataReader objReader = objComando.ExecuteReader();
                while (objReader.Read())
                {
                    Solicitud Item = new Solicitud();
                    Item.SolicitudId = Convert.ToInt32(objReader["id_solicitud"]);
                    Item.FechaInicio = Convert.ToDateTime(objReader["fecha_inicio"]);
                    Item.FechaFin = Convert.ToDateTime(objReader["fecha_fin"]);
                    Item.nombreTecnico = Convert.ToString(objReader["tecnicoAsignado"]);
                    Item.clienteNombre = Convert.ToString(objReader["nombreCliente"]);
                  //  Item.Cliente = Convert.ToInt32(objReader["id_cliente"]);
                    Item.DescripcionTarea = Convert.ToString(objReader["descripcion_tarea"]);
                    Item.Estado = (EstadoSolicitudEnum)Convert.ToInt32(objReader["estado"]);
                    Item.Prioridad = (PrioridadSolicitudEnum)Convert.ToInt32(objReader["prioridad"]);
                    Item.Complejidad = (ComplejidadSolicitudEnum)Convert.ToInt32(objReader["complejidad"]);


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

      /*  public Solicitud ObtenerPorFormulario(int idSolicitud, string fechaDesde, string fechaHasta)
        {

            Solicitud solicitud = null;
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "solicitud_sel_by_form";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fecha_desde", fechaDesde);
                    cmd.Parameters.AddWithValue("@fecha_hasta", fechaHasta);

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    if (table.Rows.Count != 0)
                    {
                        DataRow row = table.Rows[0];

                        solicitud = new Solicitud
                        {
                            SolicitudId = Convert.ToInt32(row["id_solicitud"]),
                            FechaInicio = Convert.ToDateTime(row["fecha_inicio"]),
                            FechaFin = Convert.ToDateTime(row["fecha_fin"]),
                            TecnicoAsignado = Convert.ToInt32(row["tecnico_asignado"]),
                            Cliente = Convert.ToInt32(row["id_cliente"]),
                            DescripcionTarea = Convert.ToString(row["descripcion_tarea"]),
                            Estado = (EstadoSolicitudEnum)Convert.ToInt32(row["estado"]),
                            Prioridad = (PrioridadSolicitudEnum)Convert.ToInt32(row["prioridad"]),
                            Complejidad = (ComplejidadSolicitudEnum)Convert.ToInt32(row["complejidad"])
                        };
                    }
                }
            }
            return solicitud;
        }*/


        public List<Solicitud> ListarPorCliente(int id_cliente)
        {

            List<Solicitud> Lista = new List<Solicitud>();
           // Solicitud Item;


            SQL = "SELECT id_solicitud, descripcion_tarea FROM Solicitud WHERE id_cliente = @id_cliente ORDER BY id_solicitud";


            objComando.CommandText = SQL;
            objComando.Parameters.AddWithValue("@id_cliente", id_cliente);

            try
            {
                objConexion.Open();
                SqlDataReader objReader = objComando.ExecuteReader();
                while (objReader.Read())
                {
                    Solicitud Item = new Solicitud();

                    Item.SolicitudId = Convert.ToInt32(objReader["id_solicitud"]);
                    Item.DescripcionTarea = Convert.ToString(objReader["descripcion_tarea"]);
                   

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
        public List<Solicitud> Listar()
        {
            List<Solicitud> solicituds = new List<Solicitud>();
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "solicitud_sel_all";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Solicitud solicitud = new Solicitud
                        {
                            SolicitudId = Convert.ToInt32(row["id_solicitud"]),
                            FechaInicio = Convert.ToDateTime(row["fecha_inicio"]),
                            FechaFin = Convert.ToDateTime(row["fecha_fin"]),
                            TecnicoAsignado = Convert.ToInt32(row["tecnico_asignado"]),
                            Cliente = Convert.ToInt32(row["id_cliente"]),
                            DescripcionTarea = Convert.ToString(row["descripcion_tarea"]),
                            Estado = (EstadoSolicitudEnum)Convert.ToInt32(row["estado"]),
                            Prioridad = (PrioridadSolicitudEnum)Convert.ToInt32(row["prioridad"]),
                            Complejidad = (ComplejidadSolicitudEnum)Convert.ToInt32(row["complejidad"])
                        };
                        solicituds.Add(solicitud);
                    }
                }
            }
            return solicituds;
        }

        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>        
        public void Delete(int SolicitudId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "solicitud_del";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_solicitd", SolicitudId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Solicitud Map(SqlDataReader objReader)
        {
            Solicitud Item = new Solicitud();
            Item.SolicitudId = (int)objReader["id_solicitud"];
            Item.FechaInicio = (DateTime)objReader["fecha_inicio"];
            //      if (objReader["fecha_fin"] == DBNull.Value) Item.FechaFin = default(DateTime);
            //        if (objReader["fecha_fin"] != DBNull.Value) Item.FechaFin = (DateTime)objReader["fecha_fin"]; 
            Item.FechaFin = (DateTime)objReader["fecha_fin"];
            Item.TecnicoAsignado = (int)objReader["tecnico_asignado"];
            Item.Prioridad = (PrioridadSolicitudEnum)(int)objReader["prioridad"];
            Item.Complejidad = (ComplejidadSolicitudEnum)(int)objReader["complejidad"];
            Item.Estado = (EstadoSolicitudEnum)(int)objReader["estado"];
            Item.DescripcionTarea = (string)objReader["descripcion_tarea"];
            Item.Cliente = (int)objReader["id_cliente"];
            return Item;
        }
    
    }
}
