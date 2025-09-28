using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestionVinicola.Models.clases.inventario
{
    /// <summary>
    /// Clase que representa un producto dentro del inventario.
    /// Contiene información básica como nombre, precio, stock y descripción.
    /// </summary>
    public class Producto
    {
        //ATRIBUTOS

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Identificador único del producto.
        /// </summary>
        public int IdProducto { get; set; }

        /// <summary>
        /// Precio unitario del producto (decimal para manejar dinero).
        /// </summary>
        public decimal PrecioUnitario { get; set; }

        /// <summary>
        /// Descripción breve del producto (ejemplo: tipo de vino, características).
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Cantidad disponible actualmente en el inventario.
        /// </summary>
        public int StockActual { get; set; }

        /// <summary>
        /// Cantidad mínima permitida antes de generar una alerta de stock.
        /// </summary>
        public int StockMinimo { get; set; }


        //MÉTODOS

        /// <summary>
        /// Actualiza el precio unitario del producto, siempre y cuando el nuevo precio sea mayor a 0.
        /// </summary>
        /// <param name="nuevoPrecio">Nuevo precio a establecer.</param>
        /// <returns>
        /// True si el precio se actualizó correctamente, False si el valor ingresado no es válido.
        /// </returns>
        public bool ActualizarPrecio(decimal nuevoPrecio)
        {
            if (nuevoPrecio > 0)
            {
                PrecioUnitario = nuevoPrecio;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Actualiza el stock del producto, ya sea agregando (entrada) o restando (salida).
        /// </summary>
        /// <param name="cantidad">Cantidad a modificar.</param>
        /// <param name="esEntrada">
        /// True si es una entrada (aumenta stock), False si es salida (disminuye stock).
        /// </param>
        /// <returns>
        /// True si la operación fue exitosa, False si la cantidad no es válida o si no hay suficiente stock para una salida.
        /// </returns>
        public bool ActualizarStock(int cantidad, bool esEntrada)
        {
            // La cantidad debe ser mayor que cero
            if (cantidad <= 0)
                return false;

            // Si es salida, se verifica que haya stock suficiente
            if (!esEntrada && StockActual < cantidad)
                return false;

            // Si es entrada, se suma; si es salida, se resta
            if (esEntrada)
                StockActual += cantidad;
            else
                StockActual -= cantidad;

            return true;
        }
    }
}
