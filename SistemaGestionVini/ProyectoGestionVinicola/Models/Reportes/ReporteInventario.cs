using ProyectoGestionVinicola.Models.clases.inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestionVinicola.Models.clases.Reportes
{
    /// <summary>
    /// Reporte específico del inventario.
    /// Muestra todos los productos registrados y genera alertas
    /// para aquellos cuyo stock esté por debajo del mínimo permitido.
    /// </summary>
    internal class ReporteInventario : Reporte
    {
        //ATRIBUTOS

        /// <summary>
        /// Referencia al inventario de productos.
        /// </summary>
        private Inventario inventario;

        /// <summary>
        /// Objeto encargado de verificar y generar alertas de stock.
        /// </summary>
        private AlertaStock alertaStock;


        //CONSTRUCTOR

        /// <summary>
        /// Crea un nuevo reporte de inventario.
        /// </summary>
        /// <param name="inventario">Inventario a partir del cual se genera el reporte.</param>
        public ReporteInventario(Inventario inventario)
            : base("Reporte de Inventario") // Se pasa el título al constructor de la clase base
        {
            this.inventario = inventario;
            this.alertaStock = new AlertaStock();
        }


        //MÉTODOS

        /// <summary>
        /// Genera el contenido del reporte de inventario.
        /// Incluye lista de productos y alertas de stock bajo.
        /// </summary>
        /// <returns>Cadena con todo el contenido del reporte.</returns>
        public override string Generar()
        {
            // Encabezado común definido en la clase base
            string texto = GenerarEncabezado();

            // Se obtiene la lista de productos del inventario
            List<Producto> productos = inventario.GenerarReporteStock();

            // Sección 1: Lista de productos
            texto += "📦 Lista de productos en inventario:\n";
            foreach (Producto p in productos)
            {
                texto += p.ToString() + "\n"; // Usa el ToString() del producto
            }

            // Sección 2: Alertas de stock bajo
            texto += "\n⚠️ Productos con stock bajo:\n";
            List<string> alertas = alertaStock.GenerarAlertas(productos);

            if (alertas.Count == 0)
                texto += "✅ No hay productos en alerta.\n";
            else
                foreach (string alerta in alertas)
                    texto += alerta + "\n";

            return texto;
        }
    }
}
