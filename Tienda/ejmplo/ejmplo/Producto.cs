using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Tienda
{

    public enum Categoria
    {
        Electronico,
        Ropa,
        Libreria,
        Accesorios,
        Muebles
    }
    public class Producto
    {
        protected int idProducto;
        protected string nombre;
        protected string descripcion;
        protected float precio;
        protected Categoria categoria;
        public int IdProducto { get { return idProducto; } set { idProducto = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Descripcion { get { return descripcion; } set { descripcion = value; } }
        public float Precio { get { return precio; } set { precio = value; } }
        public string Tipo
        {
            get
            {
                switch (categoria)
                {
                    case Categoria.Electronico:
                        return "Electronico";
                    case Categoria.Ropa:
                        return "Ropa";
                    case Categoria.Libreria:
                        return "Libreria";
                    case Categoria.Accesorios:
                        return "Accesorios";
                    case Categoria.Muebles:
                        return "Muebles";
                    default:
                        return "Otros";
                }
            }
            private set
            {

            }
        }
        public Producto( string nombr, string descr, float prec, Categoria cat)
        {
            // Guarda los valores de las variables de la funcion set y los guarda en variables dentro de Alumno
            nombre = nombr;
            descripcion = descr;
            precio = prec;
            categoria = cat;
        }
        public Producto(int id, string nombr, string descr, float prec, Categoria cat)
        {
            // Guarda los valores de las variables de la funcion set y los guarda en variables dentro de Alumno
            idProducto = id;
            nombre = nombr;
            descripcion = descr;
            precio = prec;
            categoria = cat;
        }

        public static List<Producto> ObtenerTodosLosProductos()
        {
            List<Producto> lista = new List<Producto>();
            SqliteConnection conexion = Conexion.Instancia.ObtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM Productos";
            SqliteCommand comando = new SqliteCommand(consulta, conexion);
            SqliteDataReader lector = comando.ExecuteReader();
            
            while (lector.Read())
            {
                Categoria cat;
                switch (lector["categoria"].ToString())
                {
                    case "Electronico":
                        cat = Categoria.Electronico;
                        break;
                    case "Ropa":
                        cat = Categoria.Ropa;
                        break;
                    case "Libreria":
                        cat = Categoria.Libreria;
                        break;
                    case "Accesorios":
                        cat = Categoria.Accesorios;
                        break;
                    case "Muebles":
                        cat = Categoria.Muebles;
                        break;
                    default:
                        cat = Categoria.Ropa;
                        break;
                }
                Producto pro = new Producto(int.Parse(lector["idProducto"].ToString()),
                                            lector["nombre"].ToString(),
                                            lector["descripcion"].ToString(),
                                            float.Parse(lector["precio"].ToString()),
                                            cat);

                lista.Add(pro);
            }
            conexion.Close();
            return lista;
        }

        public static Producto ObtenerUno(int id)
        {
            SqliteConnection conexion = Conexion.Instancia.ObtenerConexion();
            conexion.Open();
            string consulta = "SELECT * FROM Productos WHERE idProducto = @id";
            SqliteCommand comando = new SqliteCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@id", id);
            SqliteDataReader lector = comando.ExecuteReader();
            lector.Read();
            if (lector == null)
                return null;

            Categoria cat;
            switch (lector["categoria"].ToString())
            {
                case "Electronico":
                    cat = Categoria.Electronico;
                    break;
                case "Ropa":
                    cat = Categoria.Ropa;
                    break;
                case "Libreria":
                    cat = Categoria.Libreria;
                    break;
                case "Accesorios":
                    cat = Categoria.Accesorios;
                    break;
                case "Muebles":
                    cat = Categoria.Muebles;
                    break;
                default:
                    cat = Categoria.Ropa;
                    break;
            }
            Producto pro = new Producto(int.Parse(lector["idProducto"].ToString()),
                                        lector["nombre"].ToString(),
                                        lector["descripcion"].ToString(),
                                        float.Parse(lector["precio"].ToString()),
            cat);
            conexion.Close();
            return pro;
        }

        public void AgregarABaseDeDatos()
        {
            SqliteConnection conexion = Conexion.Instancia.ObtenerConexion();
            conexion.Open();
            string consulta = "INSERT INTO Productos (nombre,descripcion,precio,categoria) VALUES (@nombre,@descripcion,@precio,@categoria)";
            SqliteCommand comando = new SqliteCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@categoria", categoria);
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public static void EliminarProducto(int id)
        {
            SqliteConnection conexion = Conexion.Instancia.ObtenerConexion();
            conexion.Open();
            string consulta = "DELETE FROM Productos WHERE idProducto = @id";
            SqliteCommand comando = new SqliteCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
