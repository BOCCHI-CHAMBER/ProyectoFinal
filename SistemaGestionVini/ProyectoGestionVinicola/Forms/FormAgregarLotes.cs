using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoGestionVinicola.Forms
{
    public partial class FormAgregarLotes : Form
    {
        public string TipoVino { get; private set; }
        public int Cantidad { get; private set; }
        public FormAgregarLotes()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            TipoVino = txtTipoVino.Text.Trim();
            if (int.TryParse(numCantidad.Text.Trim(), out int cantidad))
            {
                Cantidad = cantidad;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Ingrese un número válido para la cantidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
