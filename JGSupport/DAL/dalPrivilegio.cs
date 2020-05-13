using Entidades;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class dalPrivilegio : Conexion
    {
        public List<Privilegio> Listar()
        {
            List<Privilegio> Lista = new List<Privilegio>();
            Privilegio Item;
            SQL = "SELECT id_privilegio, privilegio_desc FROM Privilegio";
            SQL = SQL + " ORDER BY id_privilegio";
            objComando.CommandText = SQL;
            try
            {
                objConexion.Open();
                SqlDataReader objReader = objComando.ExecuteReader();
                while (objReader.Read())
                {
                    Item = Map(objReader);
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

        public Privilegio Map(SqlDataReader objReader)
        {
            Privilegio Item = new Privilegio();
            Item.id_privilegio = (int)objReader["id_privilegio"];
           /// Item.Rol = (RolPersonalEnum)(int)objReader["CategoriaRol"];
            Item.privilegio_Desc = (string)objReader["privilegio_desc"];
            return Item;
        }
    }
}