using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DignitaTask.Services
{
    public class DatabaseConnection
    {
        private static readonly DatabaseConnection _instancia = new DatabaseConnection();
        public static DatabaseConnection Instancia
        {
            get { return DatabaseConnection._instancia; }
        }

        public SqlConnection Conectar()
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=LAPTOP-BFK427HA\\SQL; Initial Catalog = DB_DIGNITA; Integrated Security=true";

            return cn;
        }
    }
}