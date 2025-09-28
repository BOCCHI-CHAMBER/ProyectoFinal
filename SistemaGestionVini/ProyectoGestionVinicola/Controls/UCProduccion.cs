using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using ProyectoGestionVinicola.Forms;
using ProyectoGestionVinicola.Models.clases.produccion;

namespace ProyectoGestionVinicola.Controls
{
    public partial class UCProduccion : UserControl
    {
        private ProduccionManager manager;

        public UCProduccion()
        {
            InitializeComponent();
            manager = new ProduccionManager();
            ConfigurarDataGrid();
            ActualizarDataGrid();
        }
        
        private void ConfigurarDataGrid()
        {
            dgvLotes.Columns.Add("IdLote", "ID Lote");
            dgvLotes.Columns.Add("TipoVino", "Tipo de Vino");
            dgvLotes.Columns.Add("CantidadLitros", "Cantidad (L)");
            dgvLotes.Columns.Add("FechaInicio", "Inicio");
            dgvLotes.Columns.Add("Finalizado", "Finalizado");
        }
        private void ActualizarDataGrid()
        {
            dgvLotes.Rows.Clear();
            foreach (var lote in manager.ObtenerLotes())
            {
                dgvLotes.Rows.Add(
                    lote.IdLote,
                    lote.TipoVino,
                    lote.CantidadLitros,
                    lote.FechaInicio.ToShortDateString(),
                    lote.Finalizado ? "Sí" : "No"
                );
            }
        }
        //private void Inicializar()
        //{
        //    // Configurar DataGridView con columnas
        //    dgvLotes.Columns.Add("idLote", "ID Lote");
        //    dgvLotes.Columns.Add("nombreVino", "Nombre Vino");
        //    dgvLotes.Columns.Add("cantidad", "Cantidad (L)");
        //}
        // Método para agregar un lote
        public void AgregarLote(string nombre, int cantidad)
        {
            int id = dgvLotes.Rows.Count + 1;
            dgvLotes.Rows.Add(id, nombre, cantidad);
        }
        private void UCProduccion_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregarLote_Click(object sender, EventArgs e)
        {
            using (FormAgregarLotes form = new FormAgregarLotes())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int id = manager.ObtenerLotes().Count + 1;
                    manager.CrearLote(id, form.TipoVino, form.Cantidad);
                    ActualizarDataGrid();
                }
            }
        }

        

        private void btnFinalizarLote_Click(object sender, EventArgs e)
        {
            if (dgvLotes.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvLotes.SelectedRows[0].Cells[0].Value);
                bool finalizado = manager.FinalizarLote(id);

                if (finalizado)
                {
                    MessageBox.Show($"Lote {id} finalizado correctamente.", "Éxito");
                    ActualizarDataGrid();
                }
                else
                {
                    MessageBox.Show("El lote ya está finalizado o no existe.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un lote para finalizar.", "Aviso");
            }
        }
    }
    
}
