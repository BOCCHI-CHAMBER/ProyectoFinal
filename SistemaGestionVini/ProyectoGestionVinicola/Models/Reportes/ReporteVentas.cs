using ProyectoGestionVinicola.Models.clases.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestionVinicola.Models.clases.Reportes
{
    /// <summary>
    /// Reporte de ventas que lista todas las facturas registradas
    /// y calcula el total vendido.
    /// </summary>
    public class ReporteVentas : Reporte
    {
        //ATRIBUTOS

        /// <summary>
        /// Lista de facturas que serán incluidas en el reporte.
        /// </summary>
        private List<Factura> facturas;

        //CONSTRUCTOR

        /// <summary>
        /// Constructor del reporte de ventas.
        /// </summary>
        /// <param name="facturas">Lista de facturas a mostrar en el reporte.</param>
        public ReporteVentas(List<Factura> facturas)
            : base("Reporte de Ventas") // Se pasa el título a la clase base
        {
            this.facturas = facturas;
        }

        //MÉTODOS

        /// <summary>
        /// Genera el contenido del reporte de ventas.
        /// </summary>
        /// <returns>Cadena con las facturas y el total vendido.</returns>
        public override string Generar()
        {
            // Encabezado común
            string texto = GenerarEncabezado();

            if (facturas.Count == 0)
            {
                texto += "💸 No hay ventas registradas.\n";
            }
            else
            {
                decimal totalVentas = 0;
                texto += "🧾 Facturas registradas:\n";

                // Se recorren todas las facturas
                foreach (Factura factura in facturas)
                {
                    texto += factura.ToString() + "\n"; // Usa ToString() de Factura
                    totalVentas += factura.Total; // Suma el total de cada factura
                }

                // Muestra el total vendido
                texto += "\n💰 Total vendido: " + totalVentas + "\n";
            }

            return texto;
        }
    }
}
