using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestionVinicola.Models.clases.inventario
{
    /// <summary>
    /// Clase encargada de verificar los niveles de stock de los productos
    /// y generar alertas en caso de que estén por debajo del mínimo permitido.
    /// </summary>
    public class AlertaStock
    {
        /// <summary>
        /// Verifica si el stock actual de un producto está por debajo o igual al mínimo permitido.
        /// </summary>
        /// <param name="p">Producto a evaluar.</param>
        /// <returns>True si el stock actual es menor o igual al mínimo, False en caso contrario.</returns>
        public bool VerificarStockMinimo(Producto p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p), "El producto no puede ser nulo.");
            return p.StockActual <= p.StockMinimo;
        }

        /// <summary>
        /// Genera un mensaje de alerta en caso de que el producto tenga poco stock.
        /// </summary>
        /// <param name="p">Producto que se quiere analizar.</param>
        /// <returns>Mensaje con detalles de la alerta.</returns>
        public string GenerarAlerta(Producto p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p), "El producto no puede ser nulo.");
            return $"⚠️ El producto {p.Nombre} tiene {p.StockActual} unidades, por debajo del mínimo de {p.StockMinimo}.";
        }

        /// <summary>
        /// Genera una lista de alertas para todos los productos que estén bajo el stock mínimo.
        /// </summary>
        /// <param name="productos">Lista de productos a evaluar.</param>
        /// <returns>Lista de mensajes de alerta para cada producto en riesgo.</returns>
        public List<string> GenerarAlertas(List<Producto> productos)
        {
            if (productos == null)
                throw new ArgumentNullException(nameof(productos), "La lista de productos no puede ser nula.");

            var alertas = new List<string>();
            foreach (var producto in productos)
            {
                if (VerificarStockMinimo(producto))
                {
                    alertas.Add(GenerarAlerta(producto));
                }
            }
            return alertas;
        }
    }
}

