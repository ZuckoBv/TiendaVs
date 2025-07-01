using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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
        protected string nombre;
        protected string descripcion;
        protected float precio;
        protected Categoria categoria;
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
        public Producto(string nombr, string descr, float prec, Categoria cat)
        {
            // Guarda los valores de las variables de la funcion set y los guarda en variables dentro de Alumno
            nombre = nombr;
            descripcion = descr;
            precio = prec;
            categoria = cat;
        }

    }
}
