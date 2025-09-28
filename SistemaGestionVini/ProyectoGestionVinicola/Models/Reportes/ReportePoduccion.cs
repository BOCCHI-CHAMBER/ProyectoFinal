using ProyectoGestionVinicola.Models.clases.produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestionVinicola.Models.clases.Reportes
{
    /// <summary>
    /// Contenedor de reportes relacionados con la producción de vino.
    /// Actualmente, solo contiene un reporte interno de producción.
    /// </summary>
    public class ReportePoduccion
    {
        /// <summary>
        /// Clase interna que representa un reporte de producción.
        /// Lista los lotes existentes y su estado.
        /// Hereda de la clase abstracta Reporte.
        /// </summary>
        internal class ReporteProduccion : Reporte
        {
            // ------------------ ATRIBUTOS ------------------

            /// <summary>
            /// Lista de lotes que se incluirán en el reporte.
            /// </summary>
            private List<LoteProduccion> lotes;

            // ------------------ CONSTRUCTOR ------------------

            /// <summary>
            /// Constructor del reporte de producción.
            /// </summary>
            /// <param name="lotes">Lista de lotes a mostrar en el reporte.</param>
            public ReporteProduccion(List<LoteProduccion> lotes)
                : base("Reporte de Producción") // Se pasa el título al constructor de la clase base
            {
                this.lotes = lotes;
            }

            // ------------------ MÉTODOS ------------------

            /// <summary>
            /// Genera el contenido del reporte de producción.
            /// </summary>
            /// <returns>Cadena de texto con la información de los lotes.</returns>
            public override string Generar()
            {
                // Se genera el encabezado común (título y fecha)
                string texto = GenerarEncabezado();

                // Si no hay lotes registrados
                if (lotes.Count == 0)
                {
                    texto += "📦 No hay lotes de producción registrados.\n";
                }
                else
                {
                    // Listado de lotes
                    texto += "Lotes de producción:\n";
                    foreach (LoteProduccion lote in lotes)
                    {
                        // Se usa ToString() de LoteProduccion para mostrar cada lote
                        texto += lote.ToString() + "\n";
                    }
                }

                return texto;
            }
        }
    }
}
