using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestionVinicola.Models.clases.produccion
{
    /// <summary>
    /// Representa un lote de producción de vino dentro del sistema.
    /// Almacena datos como tipo de vino, cantidad producida y fechas de inicio/fin.
    /// </summary>
    public class LoteProduccion
    {
        //ATRIBUTOS

        /// <summary>
        /// Identificador único del lote.
        /// </summary>
        public int IdLote { get; set; }

        /// <summary>
        /// Tipo de vino producido en este lote (ejemplo: Tinto, Blanco, Rosado).
        /// </summary>
        public string TipoVino { get; set; }

        /// <summary>
        /// Cantidad total producida en litros.
        /// </summary>
        public int CantidadLitros { get; set; }

        /// <summary>
        /// Fecha en que se inició la producción del lote.
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha en que se finalizó la producción. 
        /// Solo se asigna cuando el lote se marca como finalizado.
        /// </summary>
        public DateTime FechaFin { get; private set; }

        /// <summary>
        /// Indica si el lote ya fue finalizado.
        /// </summary>
        public bool Finalizado { get; private set; }


        //CONSTRUCTOR

        /// <summary>
        /// Crea un nuevo lote de producción.
        /// </summary>
        /// <param name="idLote">Identificador único del lote.</param>
        /// <param name="tipoVino">Tipo de vino producido.</param>
        /// <param name="cantidadLitros">Cantidad en litros del lote.</param>
        public LoteProduccion(int idLote, string tipoVino, int cantidadLitros)
        {
            IdLote = idLote;
            TipoVino = tipoVino;
            CantidadLitros = cantidadLitros;
            FechaInicio = DateTime.Now; // El lote empieza al momento de crearse
            Finalizado = false; // Inicialmente no está finalizado
        }


        //MÉTODOS

        /// <summary>
        /// Marca el lote como finalizado, asignando la fecha de finalización.
        /// </summary>
        /// <returns>
        /// True si se finalizó correctamente, False si ya estaba finalizado.
        /// </returns>
        public bool FinalizarLote()
        {
            if (!Finalizado)
            {
                FechaFin = DateTime.Now;
                Finalizado = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Representación en texto del lote (para mostrar en reportes o consola).
        /// </summary>
        /// <returns>Cadena con los datos básicos del lote.</returns>
        public override string ToString()
        {
            return $"Lote {IdLote} | {TipoVino} | {CantidadLitros} L | " +
                   $"Iniciado: {FechaInicio.ToShortDateString()} | Finalizado: {Finalizado}";
        }
    }
}
