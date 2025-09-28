using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoGestionVinicola.Models.clases.produccion
{
    /// <summary>
    /// Clase encargada de gestionar los lotes de producción de vino.
    /// Permite crear, finalizar y consultar lotes (activos o finalizados).
    /// </summary>
    public class ProduccionManager
    {
        //ATRIBUTOS

        /// <summary>
        /// Lista interna que almacena todos los lotes de producción.
        /// </summary>
        private List<LoteProduccion> lotes;


        //CONSTRUCTOR

        /// <summary>
        /// Inicializa el gestor de producción con una lista vacía de lotes.
        /// </summary>
        public ProduccionManager()
        {
            lotes = new List<LoteProduccion>();
        }


        //MÉTODOS

        /// <summary>
        /// Crea un nuevo lote de vino y lo agrega a la lista, 
        /// siempre que no exista otro con el mismo Id.
        /// </summary>
        /// <param name="id">Identificador único del lote.</param>
        /// <param name="tipoVino">Tipo de vino producido (Tinto, Blanco, Rosado, etc.).</param>
        /// <param name="cantidadLitros">Cantidad en litros del lote.</param>
        /// <returns>
        /// True si se creó correctamente, False si ya existía un lote con ese Id.
        /// </returns>
        public bool CrearLote(int id, string tipoVino, int cantidadLitros)
        {
            if (lotes.Any(l => l.IdLote == id))
                return false; // No se permite duplicado de Id

            var lote = new LoteProduccion(id, tipoVino, cantidadLitros);
            lotes.Add(lote);
            return true;
        }

        /// <summary>
        /// Finaliza un lote existente (marca la fecha de finalización).
        /// </summary>
        /// <param name="id">Id del lote a finalizar.</param>
        /// <returns>
        /// True si se finalizó correctamente, False si no existe o ya estaba finalizado.
        /// </returns>
        public bool FinalizarLote(int id)
        {
            var lote = lotes.FirstOrDefault(l => l.IdLote == id);

            if (lote != null && !lote.Finalizado)
            {
                lote.FinalizarLote();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Devuelve todos los lotes de producción (activos y finalizados).
        /// </summary>
        /// <returns>Lista completa de lotes.</returns>
        public List<LoteProduccion> ObtenerLotes()
        {
            return lotes;
        }

        /// <summary>
        /// Devuelve todos los lotes que aún están en producción (no finalizados).
        /// </summary>
        /// <returns>Lista de lotes activos.</returns>
        public List<LoteProduccion> LotesActivos()
        {
            return lotes.Where(l => !l.Finalizado).ToList();
        }

        /// <summary>
        /// Devuelve todos los lotes que ya fueron finalizados.
        /// </summary>
        /// <returns>Lista de lotes finalizados.</returns>
        public List<LoteProduccion> LotesFinalizados()
        {
            return lotes.Where(l => l.Finalizado).ToList();
        }
    }
}
