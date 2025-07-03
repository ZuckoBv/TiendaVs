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
        frmMain formularioPadre;
        public Conexion(frmMain formPadre)   
        {
            formularioPadre = formPadre;
        }
        string strConexion = "Data Source=tienda.db";

        public void InsertarProducto(int idProducto, Producto prod)
        {
            using (SqliteConnection conexion = new SqliteConnection(strConexion))
            {

                conexion.Open();
                string consulta = "INSERT INTO Productos (nombre, descripcion, precio, categoria) " +
                    "VALUES (@nombre, @descripcion, @precio, @categoria )";

                SqliteCommand comando = new SqliteCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@nombre", prod.Nombre);
                comando.Parameters.AddWithValue("@descripcion", prod.Descripcion);
                comando.Parameters.AddWithValue("@precio", prod.Precio);
                comando.Parameters.AddWithValue("@categoria", prod.Tipo);
                comando.CommandType = System.Data.CommandType.Text;

                comando.ExecuteNonQuery();
            }
        }
        public void query(int idProducto, Producto prod, string consulta)
        {
            using (SqliteConnection conexion = new SqliteConnection(strConexion))
            {

                conexion.Open();
                string query = consulta;
                SqliteCommand comando = new SqliteCommand(query, conexion);
                SqliteDataReader lector = comando.ExecuteReader();
                lector.Read();
                conexion.Close();
                lector.Close();
            }
            return ;
        }
        public void Editar(int idProducto, Producto prod)
        {
            using (SqliteConnection conexion = new SqliteConnection(strConexion))
            {

                conexion.Open();
                string consulta = "Update Productos set nombre=@nombre, descripcion=@descripcion, precio=@precio, categoria=@categoria where IdProducto=@idProducto";

                SqliteCommand comando = new SqliteCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@idProducto", prod.IdProducto);
                comando.Parameters.AddWithValue("@nombre", prod.Nombre);
                comando.Parameters.AddWithValue("@descripcion", prod.Descripcion);
                comando.Parameters.AddWithValue("@precio", prod.Precio);
                comando.Parameters.AddWithValue("@categoria", prod.Tipo);
                comando.CommandType = System.Data.CommandType.Text;

                comando.ExecuteNonQuery();
            }
        }

        public List<Producto> lista()
        {
            List<Producto> mProducto = new List<Producto>();

            using (SqliteConnection conexion = new SqliteConnection(strConexion))
            {
                conexion.Open();
                string lista = "SELECT idProducto, nombre, descripcion, precio, categoria FROM Productos";
                SqliteCommand comando = new SqliteCommand(lista, conexion);
                comando.CommandType = System.Data.CommandType.Text;

                using (SqliteDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idProducto = int.Parse(reader["idProducto"].ToString());
                        string nombre = reader["nombre"].ToString();
                        string descripcion = reader["descripcion"].ToString();
                        float precio = float.Parse(reader["precio"].ToString());
                        Categoria catProducto;
                        switch (reader["categoria"].ToString())
                        {
                            case "Electronico":
                                catProducto = Categoria.Electronico;
                                break;
                            case "Ropa":
                                catProducto = Categoria.Ropa;
                                break;
                            case "Libreria":
                                catProducto = Categoria.Libreria;
                                break;
                            case "Accesorios":
                                catProducto = Categoria.Accesorios;
                                break;
                            case "Muebles":
                                catProducto = Categoria.Muebles;
                                break;
                            default:
                                catProducto = Categoria.Ropa;
                                break;
                        }
                        Producto p = new Producto(idProducto, nombre, descripcion, precio, catProducto);
                        formularioPadre.listaProductos.Add(p);
                        mProducto.Add(p);
                    }
                }
            }
            return mProducto;
        }
    }
}
