namespace ProyectoGestionVinicola.Controls
{
    partial class UCProduccion
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLotes = new System.Windows.Forms.DataGridView();
            this.btnAgregarLote = new System.Windows.Forms.Button();
            this.btnFinalizarLote = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestion De Produccion";
            // 
            // dgvLotes
            // 
            this.dgvLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLotes.Location = new System.Drawing.Point(16, 27);
            this.dgvLotes.Name = "dgvLotes";
            this.dgvLotes.Size = new System.Drawing.Size(536, 150);
            this.dgvLotes.TabIndex = 1;
            // 
            // btnAgregarLote
            // 
            this.btnAgregarLote.Location = new System.Drawing.Point(16, 194);
            this.btnAgregarLote.Name = "btnAgregarLote";
            this.btnAgregarLote.Size = new System.Drawing.Size(268, 23);
            this.btnAgregarLote.TabIndex = 2;
            this.btnAgregarLote.Text = "Agregar Lote";
            this.btnAgregarLote.UseVisualStyleBackColor = true;
            this.btnAgregarLote.Click += new System.EventHandler(this.btnAgregarLote_Click);
            // 
            // btnFinalizarLote
            // 
            this.btnFinalizarLote.Location = new System.Drawing.Point(285, 194);
            this.btnFinalizarLote.Name = "btnFinalizarLote";
            this.btnFinalizarLote.Size = new System.Drawing.Size(267, 23);
            this.btnFinalizarLote.TabIndex = 4;
            this.btnFinalizarLote.Text = "Finalizar Lote";
            this.btnFinalizarLote.UseVisualStyleBackColor = true;
            this.btnFinalizarLote.Click += new System.EventHandler(this.btnFinalizarLote_Click);
            // 
            // UCProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFinalizarLote);
            this.Controls.Add(this.btnAgregarLote);
            this.Controls.Add(this.dgvLotes);
            this.Controls.Add(this.label1);
            this.Name = "UCProduccion";
            this.Size = new System.Drawing.Size(562, 228);
            this.Load += new System.EventHandler(this.UCProduccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLotes;
        private System.Windows.Forms.Button btnAgregarLote;
        private System.Windows.Forms.Button btnFinalizarLote;
    }
}
