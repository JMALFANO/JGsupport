using Entidades;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
   public class dalTarea : Conexion
    {
        /// <summary>
        /// Inserta un nuevo cliente en la tabla cliente
        /// </summary>
        /// <param name="solicitud">Entidad contenedora de los valores a insertar</param>
        public void Insertar(Tarea tarea)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "tarea_ins";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_solicitud", tarea.SolicitudId);
                    cmd.Parameters.AddWithValue("@id_cliente", tarea.ClienteId);
                    cmd.Parameters.AddWithValue("@modo_solucion", tarea.ModoSolucion);
                    cmd.Parameters.AddWithValue("@reporte", tarea.Reporte);
                    cmd.Parameters.AddWithValue("@tecnico_asignado", tarea.TecnicoAsignado);
                    cmd.Parameters.AddWithValue("@fecha", tarea.Fecha);
                    cmd.Parameters.AddWithValue("@hora_inicio", tarea.HoraInicio);
                    cmd.Parameters.AddWithValue("@hora_fin", tarea.HoraFin);
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser insertada en la tabla.");
                }
            }

            this.SetID(tarea);
        }

        /// <summary>
        /// Actualiza el cliente correspondiente al Id proporcionado
        /// </summary>
        /// <param name="cliente">Valores utilizados para hacer el Update al registro</param>
        public void Modificar(Tarea tarea)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = cnx;
                    cmd.CommandText = "tarea_upd";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_tarea", tarea.TareaId);
                    cmd.Parameters.AddWithValue("@id_solicitud", tarea.SolicitudId);
                    cmd.Parameters.AddWithValue("@id_cliente", tarea.ClienteId);
                    cmd.Parameters.AddWithValue("@modo_solucion", tarea.ModoSolucion);
                    cmd.Parameters.AddWithValue("@reporte", tarea.Reporte);
                    cmd.Parameters.AddWithValue("@tecnico_asignado", tarea.TecnicoAsignado);
                    cmd.Parameters.AddWithValue("@fecha", tarea.Fecha);
                    cmd.Parameters.AddWithValue("@hora_inicio", tarea.HoraInicio);
                    cmd.Parameters.AddWithValue("@hora_fin", tarea.HoraFin);
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser modificada en la tabla.");
                }
            }
        }

        /// <summary>
        /// Establece el valor de la propiedad Id de un Cliente.
        /// </summary>
        /// <param name="cliente"></param>
        private void SetID(Tarea tarea)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "tarea_sel_max_id_tarea";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0] != DBNull.Value)
                    {
                        tarea.TareaId = Convert.ToInt32(dataTable.Rows[0][0]);
                    }
                }
            }
        }



        public List<Tarea> ObtenerPorSolicitudId(int id_solicitud)
        {

            List<Tarea> Lista = new List<Tarea>();


       /*     SQL = "SELECT id_solicitud, fecha_inicio, fecha_fin, M.nombre as tecnicoAsignado, id_cliente, descripcion_tarea, estado, prioridad, complejidad FROM Solicitud AS A ";
            SQL = SQL + "INNER JOIN Personal AS M ON M.id_personal = A.tecnico_asignado ";
            SQL = SQL + " INNER JOIN PERSONAL AS N on N.nombre = M.nombre where id_cliente = @id_cliente";
            */

              SQL = "SELECT id_tarea, id_solicitud, (select nombre + ' ' + apellido from personal where id_personal = id_cliente) as nombreCliente, modo_solucion, reporte, M.nombre as tecnicoAsignado, fecha, hora_inicio, hora_fin FROM Tarea AS A ";
              SQL = SQL + "INNER JOIN Personal AS M ON M.id_personal = A.tecnico_asignado ";
              SQL = SQL + " INNER JOIN PERSONAL AS N on N.nombre = M.nombre where id_solicitud = @id_solicitud";

            //  SQL = "SELECT id_tarea, id_solicitud, modo_solucion, reporte, tecnico_asignado, fecha, hora_inicio, hora_fin FROM Tarea WHERE id_solicitud = @id_solicitud ORDER BY id_tarea";

            objComando.CommandText = SQL;
            objComando.Parameters.AddWithValue("@id_solicitud", id_solicitud);

            try
            {
                objConexion.Open();
                SqlDataReader objReader = objComando.ExecuteReader();
                while (objReader.Read())
                {
                    Tarea Item = new Tarea();


                    Item.TareaId = Convert.ToInt32(objReader["id_tarea"]);
                    Item.SolicitudId = Convert.ToInt32(objReader["id_solicitud"]);
                   // Item.ClienteId = Convert.ToInt32(objReader["id_cliente"]);
                    Item.ModoSolucion = Convert.ToBoolean(objReader["modo_solucion"]);
                    Item.Reporte = Convert.ToString(objReader["reporte"]);
                    //  Item.TecnicoAsignado = Convert.ToInt32(objReader["tecnico_asignado"]);
                    Item.nombreTecnico = Convert.ToString(objReader["tecnicoAsignado"]);
                    Item.nombreCliente = Convert.ToString(objReader["nombreCliente"]);
                    Item.Fecha = Convert.ToDateTime(objReader["fecha"]);

                    string HoraInicio = objReader["hora_inicio"].ToString();
                    Item.HoraInicio = TimeSpan.Parse(HoraInicio);

                    string HoraFin = objReader["hora_fin"].ToString();
                    Item.HoraFin = TimeSpan.Parse(HoraFin);

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

        public Tarea ObtenerPorId(int idTarea)
        {
            Tarea tarea = null;
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "tarea_sel_by_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_tarea", idTarea);

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    if (table.Rows.Count != 0)
                    {
                        DataRow row = table.Rows[0];
                        tarea = new Tarea
                        {                          
                            TareaId = Convert.ToInt32(row["id_tarea"]),
                            SolicitudId = Convert.ToInt32(row["id_solicitud"]),
                            ClienteId = Convert.ToInt32(row["id_cliente"]),
                            ModoSolucion = Convert.ToBoolean(row["modo_solucion"]),
                            Reporte = Convert.ToString(row["reporte"]),
                            TecnicoAsignado = Convert.ToInt32(row["tecnico_asignado"]),
                            Fecha = Convert.ToDateTime(row["fecha"]),
                            HoraInicio = TimeSpan.Parse(row["hora_inicio"].ToString()),
                            HoraFin = TimeSpan.Parse(row["hora_fin"].ToString())
                        };
                    }
                }
            }
            return tarea;
        }

        /// <summary>
        /// Busca un solicitud por su clave primaria.
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <returns></returns>
    /*    public Solicitud ObtenerPorId(int idSolicitud)
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
                            Cliente= Convert.ToInt32(row["id_cliente"]),
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

        public List<Tarea> ListarPorTecnico(int id_tecnico)
        {

            List<Tarea> Lista = new List<Tarea>();
            // Solicitud Item;


            SQL = "SELECT id_tarea, reporte FROM Solicitud WHERE id_solicitud = @id_solicitud ORDER BY id_tarea";


            objComando.CommandText = SQL;
            objComando.Parameters.AddWithValue("@id_tecnico", id_tecnico);

            try
            {
                objConexion.Open();
                SqlDataReader objReader = objComando.ExecuteReader();
                while (objReader.Read())
                {
                    Tarea Item = new Tarea();

                    Item.TareaId = Convert.ToInt32(objReader["id_tarea"]);
                    Item.Reporte = Convert.ToString(objReader["reporte"]);


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
        public List<Tarea> Listar()
        {
            List<Tarea> tareas = new List<Tarea>();
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "tarea_sel_all";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Tarea tarea = new Tarea
                        {

                            TareaId = Convert.ToInt32(row["id_tarea"]),
                            SolicitudId = Convert.ToInt32(row["id_solicitud"]),
                            ClienteId = Convert.ToInt32(row["id_cliente"]),
                            ModoSolucion = Convert.ToBoolean(row["modo_solucion"]),
                            Reporte = Convert.ToString(row["reporte"]),
                            TecnicoAsignado = Convert.ToInt32(row["tecnico_asignado"]),
                            Fecha = Convert.ToDateTime(row["fecha"]),   
                            HoraInicio = TimeSpan.Parse(row["hora_inicio"].ToString()),
                            HoraFin = TimeSpan.Parse(row["hora_fin"].ToString())

                        };
                        tareas.Add(tarea);
                    }
                }
            }
            return tareas;
        }




        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>        
        public void Delete(int TareaId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["JGSupport"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "tarea_del";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_tarea", TareaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Tarea Map(SqlDataReader objReader)
        {
            Tarea Item = new Tarea();




            Item.TareaId = Convert.ToInt32(objReader["id_tarea"]);
            Item.SolicitudId = Convert.ToInt32(objReader["id_solicitud"]);
            Item.ClienteId = Convert.ToInt32(objReader["id_cliente"]);
            Item.ModoSolucion = Convert.ToBoolean(objReader["modo_solucion"]);
            Item.Reporte = Convert.ToString(objReader["reporte"]);
            Item.TecnicoAsignado = Convert.ToInt32(objReader["tecnico_asignado"]);
            Item.Fecha = Convert.ToDateTime(objReader["fecha"]);

            string HoraInicio = objReader["hora_inicio"].ToString();
            Item.HoraInicio = TimeSpan.Parse(HoraInicio);

            string HoraFin = objReader["hora_fin"].ToString();
            Item.HoraFin = TimeSpan.Parse(HoraFin);









        /*    Item.SolicitudId = (int)objReader["id_solicitud"];

            Item.FechaInicio = (DateTime)objReader["fecha_inicio"];

            if (objReader["fecha_fin"] != null)
            { Item.FechaFin = (DateTime)objReader["fecha_fin"]; }

            Item.TecnicoAsignado = (int)objReader["tecnico_asignado"];
            Item.Prioridad = (PrioridadSolicitudEnum)(int)objReader["prioridad"];
            Item.Complejidad = (ComplejidadSolicitudEnum)(int)objReader["complejidad"];
            Item.Estado = (EstadoSolicitudEnum)(int)objReader["estado"];
            Item.DescripcionTarea = (string)objReader["descripcion_tarea"];
            Item.Cliente = (int)objReader["id_cliente"];*/

            return Item;
        }
    }
}
