using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestionVinicola.Models.clases.inventario
{
    /// <summary>
    /// Clase que administra los productos en el inventario de la bodega/vinicola.
    /// Permite agregar, eliminar, buscar productos, registrar entradas y salidas,
    /// mostrar el inventario y generar reportes de stock.
    /// </summary>
    public class Inventario
    {
        // ------------------ ATRIBUTOS ------------------

        /// <summary>
        /// Lista interna que contiene todos los productos registrados en el inventario.
        /// </summary>
        private List<Producto> ListaProductos = new List<Producto>();


        // ------------------ MÉTODOS ------------------

        /// <summary>
        /// Agrega un producto al inventario, siempre y cuando no exista otro con el mismo ID.
        /// </summary>
        /// <param name="producto">Producto a agregar.</param>
        /// <returns>
        /// True si se agregó correctamente, False si ya existía un producto con ese mismo ID.
        /// </returns>
        public bool AgregarProducto(Producto producto)
        {
            Producto existente = BuscarProducto(producto.IdProducto);

            if (existente != null)
                return false; // No se agrega porque ya existe

            ListaProductos.Add(producto);
            return true; // Se agregó con éxito
        }

        /// <summary>
        /// Elimina un producto del inventario según su ID.
        /// </summary>
        /// <param name="id">ID del producto a eliminar.</param>
        /// <returns>
        /// True si se eliminó correctamente, False si no se encontró el producto.
        /// </returns>
        public bool EliminarProducto(int id)
        {
            Producto existente = BuscarProducto(id);

            if (existente == null)
                return false; // No existe el producto

            // Se eliminan todos los productos con ese ID (en teoría debería ser único).
            ListaProductos.RemoveAll(p => p.IdProducto == id);
            return true;
        }

        /// <summary>
        /// Busca un producto en el inventario por su ID.
        /// </summary>
        /// <param name="id">ID del producto a buscar.</param>
        /// <returns>
        /// El producto encontrado, o null si no existe.
        /// </returns>
        public Producto BuscarProducto(int id)
        {
            return ListaProductos.Find(p => p.IdProducto == id);
        }

        /// <summary>
        /// Registra una entrada de stock para un producto (se incrementa su cantidad).
        /// </summary>
        /// <param name="id">ID del producto.</param>
        /// <param name="cantidad">Cantidad a agregar.</param>
        /// <returns>
        /// True si la operación fue exitosa, False si el producto no existe.
        /// </returns>
        public bool RegistrarEntrada(int id, int cantidad)
        {
            Producto p = BuscarProducto(id);

            if (p == null)
                return false;

            // ActualizarStock recibe cantidad y un booleano indicando si es entrada (true).
            return p.ActualizarStock(cantidad, true);
        }

        /// <summary>
        /// Registra una salida de stock para un producto (se reduce su cantidad).
        /// </summary>
        /// <param name="id">ID del producto.</param>
        /// <param name="cantidad">Cantidad a restar.</param>
        /// <returns>
        /// True si la operación fue exitosa, False si el producto no existe o no hay suficiente stock.
        /// </returns>
        public bool RegistrarSalida(int id, int cantidad)
        {
            Producto p = BuscarProducto(id);

            if (p == null)
                return false;

            // ActualizarStock recibe cantidad y false porque es una salida.
            return p.ActualizarStock(cantidad, false);
        }

        /// <summary>
        /// Muestra en consola todos los productos del inventario con sus detalles.
        /// </summary>
        public void MostrarInventario()
        {
            foreach (Producto producto in ListaProductos)
            {
                Console.WriteLine($"Nombre: {producto.Nombre} | Precio Unitario: {producto.PrecioUnitario} |  " +
                    $"ID del producto {producto.IdProducto} | Descripcion: {producto.Descripcion} | " +
                    $"Stock Actual: {producto.StockActual} | Stock mínimo permitido: {producto.StockMinimo}\n");
            }
        }

        /// <summary>
        /// Genera un reporte con la lista completa de productos del inventario.
        /// </summary>
        /// <returns>Lista de productos actuales.</returns>
        public List<Producto> GenerarReporteStock()
        {
            return ListaProductos;
        }
    }
}
