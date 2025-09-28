using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestionVinicola.Models.clases.Ventas
{
    /// <summary>
    /// Representa un detalle de la factura: un producto, la cantidad y el precio unitario.
    /// </summary>
    public class DetalleFactura
    {
        /// <summary>
        /// Nombre del producto vendido.
        /// </summary>
        public string Producto { get; set; }

        /// <summary>
        /// Cantidad de unidades vendidas.
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Precio unitario del producto.
        /// </summary>
        public decimal PrecioUnitario { get; set; }

        /// <summary>
        /// Subtotal de este detalle (Cantidad * PrecioUnitario).
        /// </summary>
        public decimal Subtotal => Cantidad * PrecioUnitario;

        /// <summary>
        /// Representación en texto del detalle de la factura.
        /// </summary>
        /// <returns>Producto x Cantidad = Subtotal</returns>
        public override string ToString()
        {
            return $"{Producto} x{Cantidad} = {Subtotal:C}";
        }
    }

    /// <summary>
    /// Representa una factura emitida a un cliente.
    /// Contiene la lista de detalles, fecha, cliente y cálculo del total.
    /// </summary>
    public class Factura
    {
        /// <summary>
        /// Número único de la factura.
        /// </summary>
        public int NumeroFactura { get; set; }

        /// <summary>
        /// Fecha de emisión de la factura.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Cliente al que se emite la factura.
        /// </summary>
        public Cliente Cliente { get; set; }

        /// <summary>
        /// Lista de detalles (productos vendidos) de la factura.
        /// </summary>
        public List<DetalleFactura> Detalles { get; set; }

        /// <summary>
        /// Total de la factura (suma de todos los subtotales).
        /// </summary>
        public decimal Total => CalcularTotal();

        /// <summary>
        /// Constructor de la factura. Inicializa la lista de detalles y asigna fecha actual.
        /// </summary>
        /// <param name="numeroFactura">Número único de la factura.</param>
        /// <param name="cliente">Cliente al que se emite la factura.</param>
        public Factura(int numeroFactura, Cliente cliente)
        {
            NumeroFactura = numeroFactura;
            Fecha = DateTime.Now;
            Cliente = cliente;
            Detalles = new List<DetalleFactura>();
        }

        /// <summary>
        /// Agrega un nuevo detalle de producto a la factura.
        /// </summary>
        /// <param name="producto">Nombre del producto.</param>
        /// <param name="cantidad">Cantidad vendida.</param>
        /// <param name="precioUnitario">Precio unitario del producto.</param>
        public void AgregarDetalle(string producto, int cantidad, decimal precioUnitario)
        {
            Detalles.Add(new DetalleFactura
            {
                Producto = producto,
                Cantidad = cantidad,
                PrecioUnitario = precioUnitario
            });
        }

        /// <summary>
        /// Calcula el total de la factura sumando todos los subtotales de los detalles.
        /// </summary>
        /// <returns>Total de la factura.</returns>
        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var detalle in Detalles)
            {
                total += detalle.Subtotal;
            }
            return total;
        }

        /// <summary>
        /// Representación en texto de la factura.
        /// Incluye número, cliente y total.
        /// </summary>
        /// <returns>Cadena resumida de la factura.</returns>
        public override string ToString()
        {
            return $"Factura N° {NumeroFactura} - Cliente: {Cliente.Nombre} - Total: {Total:C}";
        }
    }
}
