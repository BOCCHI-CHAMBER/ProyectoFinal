using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoGestionVinicola.Models.clases.Ventas;

namespace ProyectoGestionVinicola.Controls
{
    public partial class UCVentas : UserControl
    {
        private VentasManager ventasManager;
        private Factura facturaActual;
        public UCVentas()
        {
            InitializeComponent();
            ventasManager = new VentasManager();
            RefrescarFacturas();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCrearFactura_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente(
                id: ventasManager.ObtenerFacturas().Count + 1,
                nombre: txtNombre.Text,
                nit: txtNIT.Text,
                direccion: txtDireccion.Text,
                telefono: txtTelefono.Text
            );

            facturaActual = ventasManager.CrearFactura(cliente);

            MessageBox.Show($"Factura creada para {cliente.Nombre}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefrescarFacturas();
        }

        private void btnAgregarDetalles_Click(object sender, EventArgs e)
        {
            if (facturaActual == null)
            {
                MessageBox.Show("Primero crea una factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            facturaActual.AgregarDetalle(
                producto: txtProducto.Text,
                cantidad: (int)numCantidad.Value,
                precioUnitario: decimal.Parse(numPrecio.Text)
            );

            RefrescarFacturas();
        }
        private void RefrescarFacturas()
        {
            dgvFacturas.DataSource = null;
            dgvFacturas.DataSource = ventasManager.ObtenerFacturas()
                .Select(f => new { f.NumeroFactura, Cliente = f.Cliente.Nombre, f.Total })
                .ToList();

            lblTotalVentas.Text = $"💰 Total de Ventas: {ventasManager.ObtenerTotalVentas():C}";
        }

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int numeroFactura = (int)dgvFacturas.Rows[e.RowIndex].Cells["NumeroFactura"].Value;
                facturaActual = ventasManager.ObtenerFacturas().FirstOrDefault(f => f.NumeroFactura == numeroFactura);

                if (facturaActual != null)
                {
                    dgvDetalles.DataSource = null;
                    dgvDetalles.DataSource = facturaActual.Detalles
                        .Select(d => new { d.Producto, d.Cantidad, d.PrecioUnitario, d.Subtotal })
                        .ToList();
                }
            }
        }
    }
}
