using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Tienda
{

    public class Conexion
    {
        private static Conexion instancia;

        private Conexion() { }

        public static Conexion Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new Conexion();

                return instancia;
            }
            private set { }
        }

        private SqliteConnection conexion = new SqliteConnection("Data Source = tienda.db");

        public SqliteConnection ObtenerConexion()
        {
            return conexion;
        }
    }
}
