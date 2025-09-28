using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestionVinicola.Models.clases.Ventas
{
    /// <summary>
    /// Clase que gestiona todas las operaciones relacionadas con las ventas.
    /// Permite crear facturas, obtener la lista de facturas y calcular el total vendido.
    /// </summary>
    public class VentasManager
    {
        //ATRIBUTOS

        /// <summary>
        /// Lista de todas las facturas generadas.
        /// </summary>
        private List<Factura> facturas;

        /// <summary>
        /// Contador automático para asignar números consecutivos a las facturas.
        /// </summary>
        private int contadorFacturas;

        //CONSTRUCTOR

        /// <summary>
        /// Inicializa la lista de facturas y el contador.
        /// </summary>
        public VentasManager()
        {
            facturas = new List<Factura>();
            contadorFacturas = 1; // La primera factura comienza con número 1
        }

        //MÉTODOS

        /// <summary>
        /// Crea una nueva factura para un cliente.
        /// </summary>
        /// <param name="cliente">Cliente al que se emite la factura.</param>
        /// <returns>La nueva factura creada.</returns>
        public Factura CrearFactura(Cliente cliente)
        {
            var nuevaFactura = new Factura(contadorFacturas++, cliente);
            facturas.Add(nuevaFactura);
            return nuevaFactura;
        }

        /// <summary>
        /// Obtiene todas las facturas generadas.
        /// </summary>
        /// <returns>Lista de facturas.</returns>
        public List<Factura> ObtenerFacturas()
        {
            return facturas;
        }

        /// <summary>
        /// Calcula el total de todas las ventas realizadas.
        /// </summary>
        /// <returns>Total de ventas.</returns>
        public decimal ObtenerTotalVentas()
        {
            return facturas.Sum(f => f.Total);
        }
    }
}
