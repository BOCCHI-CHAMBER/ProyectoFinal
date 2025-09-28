using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProyectoGestionVinicola.Models.clases.inventario;
using ProyectoGestionVinicola.Models.clases.produccion;


using ProyectoGestionVinicola.Models.clases.Ventas;
using ProyectoGestionVinicola.Models.clases.Reportes;
using ProyectoGestionVinicola.clases.Usuarios;
using ProyectoGestionVinicola.Controls;
using MaterialSkin.Controls;

namespace ProyectoGestionVinicola
{
    public partial class FormPrincipal : MaterialForm
    {
        private ProduccionManager produccionManager = new ProduccionManager();
        private List<Factura> listaFacturas = new List<Factura>();
        private Inventario inventarioManager = new Inventario();

        // Mantener una sola instancia de Inventario para toda la app
        private Inventario inventario = new Inventario();
       
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void AbrirModulo(UserControl modulo)
        {
            panelContenedor.Controls.Clear();
            modulo.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(modulo);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            // Crear UserControl del inventario e inyectarle la instancia de Inventario
            Controls.UCInventario uc = new Controls.UCInventario();
            uc.SetInventario(inventario);   // método público en UCInventario
            AbrirModulo(uc);
        }
        

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

     

        private void btnProduccion_Click(object sender, EventArgs e)
        {

            panelContenedor.Controls.Clear();
            UCProduccion ucProduccion = new UCProduccion();
            ucProduccion.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(ucProduccion);
        
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();
            UCReportes ucReportes = new UCReportes(
                produccionManager.ObtenerLotes(),
                listaFacturas,
                inventarioManager
            );
            ucReportes.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(ucReportes);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            UCVentas ucVentas = new UCVentas();
            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(ucVentas);
            ucVentas.Dock = DockStyle.Fill;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
