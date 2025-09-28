using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestionVinicola.Models.clases.Reportes
{
    /// <summary>
    /// Clase abstracta que sirve como base para todos los tipos de reportes del sistema.
    /// Define propiedades comunes y métodos que deben implementarse en clases derivadas.
    /// </summary>
    public abstract class Reporte
    {
        //ATRIBUTOS

        /// <summary>
        /// Fecha y hora exacta en la que se generó el reporte.
        /// Se establece automáticamente en el constructor.
        /// </summary>
        public DateTime FechaGeneracion { get; private set; }

        /// <summary>
        /// Título del reporte. Puede definirse desde las clases derivadas.
        /// </summary>
        public string Titulo { get; protected set; }


        //CONSTRUCTOR

        /// <summary>
        /// Constructor que inicializa el reporte con un título y asigna la fecha de generación.
        /// </summary>
        /// <param name="titulo">Título del reporte.</param>
        protected Reporte(string titulo)
        {
            FechaGeneracion = DateTime.Now;
            Titulo = titulo;
        }


        //MÉTODOS

        /// <summary>
        /// Método abstracto que obliga a las clases derivadas a implementar
        /// la lógica específica para generar su contenido.
        /// </summary>
        /// <returns>Cadena de texto con el contenido del reporte.</returns>
        public abstract string Generar();

        /// <summary>
        /// Genera un encabezado común para todos los reportes,
        /// que incluye el título y la fecha de generación.
        /// </summary>
        /// <returns>Cadena con el encabezado del reporte.</returns>
        protected string GenerarEncabezado()
        {
            string texto = "";
            texto += "📄 " + Titulo + " | \n";
            texto += "🕒 Generado: " + FechaGeneracion + " | \n";
            return texto;
        }
    }
}
