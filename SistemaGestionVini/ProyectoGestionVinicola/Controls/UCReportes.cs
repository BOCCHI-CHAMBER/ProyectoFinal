using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoGestionVinicola.Models.clases.Reportes;
using ProyectoGestionVinicola.Models.clases.Ventas;
using ProyectoGestionVinicola.Models.clases.inventario;
using ProyectoGestionVinicola.Models.clases.produccion;
using static ProyectoGestionVinicola.Models.clases.Reportes.ReportePoduccion;

namespace ProyectoGestionVinicola.Controls
{
    public partial class UCReportes : UserControl
    {
        private List<LoteProduccion> lotesProduccion;
        private List<Factura> facturas;
        private Inventario inventario;

        public UCReportes(List<LoteProduccion> lotesProduccion, List<Factura> facturas, Inventario inventario)
        {
            InitializeComponent();

            this.lotesProduccion = lotesProduccion;
            this.facturas = facturas;
            this.inventario = inventario;

            cmbTipoReporte.Items.Add("Inventario");
            cmbTipoReporte.Items.Add("Producción");
            cmbTipoReporte.Items.Add("Ventas");
            cmbTipoReporte.SelectedIndex = 0;
        }
        

        private void UCReportes_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Reporte reporte = null;

            switch (cmbTipoReporte.SelectedItem.ToString())
            {
                case "Inventario":
                    reporte = new ReporteInventario(inventario);
                    break;
                case "Producción":
                    reporte = new ReporteProduccion(lotesProduccion);
                    break;
                case "Ventas":
                    reporte = new ReporteVentas(facturas);
                    break;
            }

            if (reporte != null)
            {
                txtReporte.Text = reporte.Generar();
            }
        }
    }
}
