using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoGestionVinicola.Models.clases.inventario;

namespace ProyectoGestionVinicola.Controls
{
    public partial class UCInventario : UserControl
    {
        private Inventario inventario;
        private BindingSource bs = new BindingSource();
        public UCInventario()
        {
            InitializeComponent();
            dgvInventario.AutoGenerateColumns = true;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // Método público para inyectar la instancia de Inventario
        public void SetInventario(Inventario inv)
        {
            inventario = inv;
            InicializarBinding();
        }
        private void InicializarBinding()
        {
            bs.DataSource = inventario.GenerarReporteStock();
            dgvInventario.DataSource = bs;
            ActualizarComboProductos();
            VerificarAlertas();
        }

        private void CargarGrid()
        {
            // refrescar binding
            bs.DataSource = null;
            bs.DataSource = inventario.GenerarReporteStock();
            dgvInventario.Refresh();
            ActualizarComboProductos();
        }
        private void ActualizarComboProductos()
        {
            var list = inventario.GenerarReporteStock();
            cmbProducto.DataSource = null;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "IdProducto";
            cmbProducto.DataSource = list.ToList();
        }

        private void VerificarAlertas()
        {
            lblAlerta.Text = "";
            AlertaStock alerta = new AlertaStock();
            foreach (var p in inventario.GenerarReporteStock())
            {
                if (alerta.VerificarStockMinimo(p))
                    lblAlerta.Text += alerta.GenerarAlerta(p) + Environment.NewLine;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Id inválido");
                return;
            }

            var p = new Producto
            {
                IdProducto = id,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                PrecioUnitario = numPrecio.Value,
                StockActual = (int)numStockActual.Value,
                StockMinimo = (int)numStockMinimo.Value
            };

            bool ok = inventario.AgregarProducto(p);
            if (!ok)
            {
                MessageBox.Show("Ya existe un producto con ese Id.");
                return;
            }

            CargarGrid();
            VerificarAlertas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow == null) return;
            var seleccionado = dgvInventario.CurrentRow.DataBoundItem as Producto;
            if (seleccionado == null) return;

            // Actualiza propiedades
            seleccionado.Nombre = txtNombre.Text;
            seleccionado.Descripcion = txtDescripcion.Text;
            seleccionado.PrecioUnitario = numPrecio.Value;
            seleccionado.StockActual = (int)numStockActual.Value;
            seleccionado.StockMinimo = (int)numStockMinimo.Value;

            CargarGrid();
            VerificarAlertas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow == null) return;
            var seleccionado = dgvInventario.CurrentRow.DataBoundItem as Producto;
            if (seleccionado == null) return;

            inventario.EliminarProducto(seleccionado.IdProducto);
            CargarGrid();
            VerificarAlertas();
        }

        private void btnRegistrarMovimiento_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            int id = (int)cmbProducto.SelectedValue;
            int cantidad = (int)numCantidad.Value;

            if (rbEntrada.Checked)
                inventario.RegistrarEntrada(id, cantidad);
            else
                inventario.RegistrarSalida(id, cantidad);

            CargarGrid();
            VerificarAlertas();
        }

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var seleccionado = dgvInventario.Rows[e.RowIndex].DataBoundItem as Producto;
            if (seleccionado == null) return;

            txtId.Text = seleccionado.IdProducto.ToString();
            txtNombre.Text = seleccionado.Nombre;
            txtDescripcion.Text = seleccionado.Descripcion;
            numPrecio.Value = seleccionado.PrecioUnitario;
            numStockActual.Value = seleccionado.StockActual;
            numStockMinimo.Value = seleccionado.StockMinimo;
        }
    }
}
