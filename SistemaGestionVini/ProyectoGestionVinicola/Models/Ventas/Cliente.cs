using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestionVinicola.Models.clases.Ventas
{
    /// <summary>
    /// Representa un cliente dentro del sistema de ventas.
    /// Contiene información básica como nombre, NIT, dirección y teléfono.
    /// </summary>
    public class Cliente
    {
        //ATRIBUTOS

        /// <summary>
        /// Identificador único del cliente.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre completo del cliente.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Número de identificación tributaria del cliente (NIT).
        /// </summary>
        public string NIT { get; set; }

        /// <summary>
        /// Dirección física del cliente.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Número de teléfono del cliente.
        /// </summary>
        public string Telefono { get; set; }


        //CONSTRUCTOR

        /// <summary>
        /// Constructor para crear un nuevo cliente con todos sus datos.
        /// </summary>
        /// <param name="id">Identificador único.</param>
        /// <param name="nombre">Nombre completo del cliente.</param>
        /// <param name="nit">NIT del cliente.</param>
        /// <param name="direccion">Dirección física.</param>
        /// <param name="telefono">Número de teléfono.</param>
        public Cliente(int id, string nombre, string nit, string direccion, string telefono)
        {
            Id = id;
            Nombre = nombre;
            NIT = nit;
            Direccion = direccion;
            Telefono = telefono;
        }

        //MÉTODOS

        /// <summary>
        /// Representación en texto del cliente.
        /// Útil para mostrar información básica en reportes o consola.
        /// </summary>
        /// <returns>Nombre del cliente y su NIT.</returns>
        public override string ToString()
        {
            return $"{Nombre} - NIT: {NIT}";
        }
    }
}
