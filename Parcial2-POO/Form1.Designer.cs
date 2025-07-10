namespace Parcial2_POO
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvNegocios = new DataGridView();
            dgvProveedores = new DataGridView();
            dgvProveedoresDelNegocio = new DataGridView();
            dgvNegociosDelProveedor = new DataGridView();
            dgvPagosGenerados = new DataGridView();
            btnAgregarNegocio = new Button();
            btnEliminarNegocio = new Button();
            btnAgregarProveedor = new Button();
            btnEliminarProveedor = new Button();
            btnAsignarProveedor = new Button();
            btnGenerarPago = new Button();
            btnPagar = new Button();
            btnEliminarPago = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtRazonSocial = new TextBox();
            txtTelefonoNegocio = new TextBox();
            txtDireccion = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            btnDesasignarProveedor = new Button();
            label10 = new Label();
            label11 = new Label();
            txtTelefonoProveedor = new TextBox();
            txtNombreProveedor = new TextBox();
            cmbMedioDePago = new ComboBox();
            txtImportePago = new TextBox();
            label9 = new Label();
            label12 = new Label();
            groupBox3 = new GroupBox();
            lblRecargoInfo = new Label();
            label14 = new Label();
            dgvTodosLosPagos = new DataGridView();
            label13 = new Label();
            dtpFechaVencimiento = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvNegocios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProveedoresDelNegocio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvNegociosDelProveedor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagosGenerados).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTodosLosPagos).BeginInit();
            SuspendLayout();
            // 
            // dgvNegocios
            // 
            dgvNegocios.AllowUserToAddRows = false;
            dgvNegocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNegocios.Location = new Point(160, 18);
            dgvNegocios.Name = "dgvNegocios";
            dgvNegocios.Size = new Size(345, 230);
            dgvNegocios.TabIndex = 0;
            dgvNegocios.CellEndEdit += dgvNegocios_CellEndEdit;
            dgvNegocios.SelectionChanged += dgvNegocios_SelectionChanged;
            // 
            // dgvProveedores
            // 
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Location = new Point(160, 15);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.Size = new Size(345, 233);
            dgvProveedores.TabIndex = 1;
            dgvProveedores.CellEndEdit += dgvProveedores_CellEndEdit;
            dgvProveedores.SelectionChanged += dgvProveedores_SelectionChanged;
            // 
            // dgvProveedoresDelNegocio
            // 
            dgvProveedoresDelNegocio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedoresDelNegocio.Location = new Point(511, 18);
            dgvProveedoresDelNegocio.Name = "dgvProveedoresDelNegocio";
            dgvProveedoresDelNegocio.Size = new Size(345, 230);
            dgvProveedoresDelNegocio.TabIndex = 2;
            // 
            // dgvNegociosDelProveedor
            // 
            dgvNegociosDelProveedor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNegociosDelProveedor.Location = new Point(511, 15);
            dgvNegociosDelProveedor.Name = "dgvNegociosDelProveedor";
            dgvNegociosDelProveedor.Size = new Size(345, 233);
            dgvNegociosDelProveedor.TabIndex = 3;
            // 
            // dgvPagosGenerados
            // 
            dgvPagosGenerados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagosGenerados.Location = new Point(6, 122);
            dgvPagosGenerados.Name = "dgvPagosGenerados";
            dgvPagosGenerados.ReadOnly = true;
            dgvPagosGenerados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagosGenerados.Size = new Size(354, 178);
            dgvPagosGenerados.TabIndex = 4;
            dgvPagosGenerados.SelectionChanged += dgvPagosGenerados_SelectionChanged;
            // 
            // btnAgregarNegocio
            // 
            btnAgregarNegocio.Location = new Point(12, 160);
            btnAgregarNegocio.Name = "btnAgregarNegocio";
            btnAgregarNegocio.Size = new Size(130, 23);
            btnAgregarNegocio.TabIndex = 5;
            btnAgregarNegocio.Text = "Agregar";
            btnAgregarNegocio.UseVisualStyleBackColor = true;
            btnAgregarNegocio.Click += btnAgregarNegocio_Click;
            // 
            // btnEliminarNegocio
            // 
            btnEliminarNegocio.Location = new Point(12, 189);
            btnEliminarNegocio.Name = "btnEliminarNegocio";
            btnEliminarNegocio.Size = new Size(130, 23);
            btnEliminarNegocio.TabIndex = 7;
            btnEliminarNegocio.Text = "Eliminar";
            btnEliminarNegocio.UseVisualStyleBackColor = true;
            btnEliminarNegocio.Click += btnEliminarNegocio_Click;
            // 
            // btnAgregarProveedor
            // 
            btnAgregarProveedor.Location = new Point(12, 116);
            btnAgregarProveedor.Name = "btnAgregarProveedor";
            btnAgregarProveedor.Size = new Size(130, 23);
            btnAgregarProveedor.TabIndex = 8;
            btnAgregarProveedor.Text = "Agregar";
            btnAgregarProveedor.UseVisualStyleBackColor = true;
            btnAgregarProveedor.Click += btnAgregarProveedor_Click;
            // 
            // btnEliminarProveedor
            // 
            btnEliminarProveedor.Location = new Point(12, 145);
            btnEliminarProveedor.Name = "btnEliminarProveedor";
            btnEliminarProveedor.Size = new Size(130, 23);
            btnEliminarProveedor.TabIndex = 10;
            btnEliminarProveedor.Text = "Eliminar";
            btnEliminarProveedor.UseVisualStyleBackColor = true;
            btnEliminarProveedor.Click += btnEliminarProveedor_Click;
            // 
            // btnAsignarProveedor
            // 
            btnAsignarProveedor.Location = new Point(12, 196);
            btnAsignarProveedor.Name = "btnAsignarProveedor";
            btnAsignarProveedor.Size = new Size(130, 23);
            btnAsignarProveedor.TabIndex = 11;
            btnAsignarProveedor.Text = "Asignar a Negocio";
            btnAsignarProveedor.UseVisualStyleBackColor = true;
            btnAsignarProveedor.Click += btnAsignarProveedor_Click;
            // 
            // btnGenerarPago
            // 
            btnGenerarPago.Location = new Point(224, 81);
            btnGenerarPago.Name = "btnGenerarPago";
            btnGenerarPago.Size = new Size(130, 23);
            btnGenerarPago.TabIndex = 12;
            btnGenerarPago.Text = "Generar Pago";
            btnGenerarPago.UseVisualStyleBackColor = true;
            btnGenerarPago.Click += btnGenerarPago_Click;
            // 
            // btnPagar
            // 
            btnPagar.Location = new Point(6, 306);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(130, 23);
            btnPagar.TabIndex = 13;
            btnPagar.Text = "Completar Pago";
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            // 
            // btnEliminarPago
            // 
            btnEliminarPago.Location = new Point(230, 306);
            btnEliminarPago.Name = "btnEliminarPago";
            btnEliminarPago.Size = new Size(130, 23);
            btnEliminarPago.TabIndex = 14;
            btnEliminarPago.Text = "Eliminar Pago";
            btnEliminarPago.UseVisualStyleBackColor = true;
            btnEliminarPago.Click += btnEliminarPago_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(160, 0);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 15;
            label1.Text = "Lista de Negocios:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(160, -3);
            label2.Name = "label2";
            label2.Size = new Size(121, 15);
            label2.TabIndex = 16;
            label2.Text = "Lista de Proveedores:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(511, 0);
            label3.Name = "label3";
            label3.Size = new Size(214, 15);
            label3.TabIndex = 17;
            label3.Text = "Proveedores del Negocio seleccionado:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(511, -3);
            label4.Name = "label4";
            label4.Size = new Size(208, 15);
            label4.TabIndex = 18;
            label4.Text = "Negocios del Proveedor seleccionado:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(6, 104);
            label5.Name = "label5";
            label5.Size = new Size(180, 15);
            label5.TabIndex = 19;
            label5.Text = "Pagos del Negocio seleccionado:";
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Location = new Point(12, 43);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(130, 23);
            txtRazonSocial.TabIndex = 20;
            // 
            // txtTelefonoNegocio
            // 
            txtTelefonoNegocio.Location = new Point(12, 87);
            txtTelefonoNegocio.Name = "txtTelefonoNegocio";
            txtTelefonoNegocio.Size = new Size(130, 23);
            txtTelefonoNegocio.TabIndex = 21;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(12, 131);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(130, 23);
            txtDireccion.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 25);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 23;
            label6.Text = "Razón Social:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 69);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 24;
            label7.Text = "Teléfono:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 113);
            label8.Name = "label8";
            label8.Size = new Size(60, 15);
            label8.TabIndex = 25;
            label8.Text = "Dirección:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtDireccion);
            groupBox1.Controls.Add(txtTelefonoNegocio);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtRazonSocial);
            groupBox1.Controls.Add(btnEliminarNegocio);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnAgregarNegocio);
            groupBox1.Controls.Add(dgvNegocios);
            groupBox1.Controls.Add(dgvProveedoresDelNegocio);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(868, 254);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "Negocios:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnDesasignarProveedor);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(txtTelefonoProveedor);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtNombreProveedor);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(btnAgregarProveedor);
            groupBox2.Controls.Add(btnEliminarProveedor);
            groupBox2.Controls.Add(dgvNegociosDelProveedor);
            groupBox2.Controls.Add(btnAsignarProveedor);
            groupBox2.Controls.Add(dgvProveedores);
            groupBox2.Location = new Point(12, 272);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(868, 254);
            groupBox2.TabIndex = 27;
            groupBox2.TabStop = false;
            groupBox2.Text = "Proveedores:";
            // 
            // btnDesasignarProveedor
            // 
            btnDesasignarProveedor.Location = new Point(12, 225);
            btnDesasignarProveedor.Name = "btnDesasignarProveedor";
            btnDesasignarProveedor.Size = new Size(130, 23);
            btnDesasignarProveedor.TabIndex = 25;
            btnDesasignarProveedor.Text = "Desasignar";
            btnDesasignarProveedor.UseVisualStyleBackColor = true;
            btnDesasignarProveedor.Click += btnDesasignarProveedor_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 69);
            label10.Name = "label10";
            label10.Size = new Size(55, 15);
            label10.TabIndex = 24;
            label10.Text = "Teléfono:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 25);
            label11.Name = "label11";
            label11.Size = new Size(54, 15);
            label11.TabIndex = 23;
            label11.Text = "Nombre:";
            // 
            // txtTelefonoProveedor
            // 
            txtTelefonoProveedor.Location = new Point(12, 87);
            txtTelefonoProveedor.Name = "txtTelefonoProveedor";
            txtTelefonoProveedor.Size = new Size(130, 23);
            txtTelefonoProveedor.TabIndex = 21;
            // 
            // txtNombreProveedor
            // 
            txtNombreProveedor.Location = new Point(12, 43);
            txtNombreProveedor.Name = "txtNombreProveedor";
            txtNombreProveedor.Size = new Size(130, 23);
            txtNombreProveedor.TabIndex = 20;
            // 
            // cmbMedioDePago
            // 
            cmbMedioDePago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedioDePago.FormattingEnabled = true;
            cmbMedioDePago.Location = new Point(142, 37);
            cmbMedioDePago.Name = "cmbMedioDePago";
            cmbMedioDePago.Size = new Size(130, 23);
            cmbMedioDePago.TabIndex = 28;
            cmbMedioDePago.SelectedIndexChanged += cmbMedioDePago_SelectedIndexChanged;
            // 
            // txtImportePago
            // 
            txtImportePago.Location = new Point(6, 37);
            txtImportePago.Name = "txtImportePago";
            txtImportePago.Size = new Size(130, 23);
            txtImportePago.TabIndex = 29;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 19);
            label9.Name = "label9";
            label9.Size = new Size(52, 15);
            label9.TabIndex = 30;
            label9.Text = "Importe:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(142, 19);
            label12.Name = "label12";
            label12.Size = new Size(90, 15);
            label12.TabIndex = 31;
            label12.Text = "Medio de Pago:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblRecargoInfo);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(dgvTodosLosPagos);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(dtpFechaVencimiento);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(txtImportePago);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(cmbMedioDePago);
            groupBox3.Controls.Add(dgvPagosGenerados);
            groupBox3.Controls.Add(btnEliminarPago);
            groupBox3.Controls.Add(btnGenerarPago);
            groupBox3.Controls.Add(btnPagar);
            groupBox3.Location = new Point(886, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(372, 514);
            groupBox3.TabIndex = 32;
            groupBox3.TabStop = false;
            groupBox3.Text = "Pagos:";
            groupBox3.Enter += groupBox3_Enter;
            // 
            // lblRecargoInfo
            // 
            lblRecargoInfo.AutoSize = true;
            lblRecargoInfo.Location = new Point(136, 310);
            lblRecargoInfo.Name = "lblRecargoInfo";
            lblRecargoInfo.Size = new Size(46, 15);
            lblRecargoInfo.TabIndex = 36;
            lblRecargoInfo.Text = "             ";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label14.Location = new Point(6, 332);
            label14.Name = "label14";
            label14.Size = new Size(163, 15);
            label14.TabIndex = 35;
            label14.Text = "Todos los Pagos Registrados:";
            // 
            // dgvTodosLosPagos
            // 
            dgvTodosLosPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTodosLosPagos.Location = new Point(6, 350);
            dgvTodosLosPagos.Name = "dgvTodosLosPagos";
            dgvTodosLosPagos.ReadOnly = true;
            dgvTodosLosPagos.Size = new Size(354, 158);
            dgvTodosLosPagos.TabIndex = 34;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 63);
            label13.Name = "label13";
            label13.Size = new Size(126, 15);
            label13.TabIndex = 33;
            label13.Text = "Fecha de Vencimiento:";
            // 
            // dtpFechaVencimiento
            // 
            dtpFechaVencimiento.Location = new Point(6, 81);
            dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            dtpFechaVencimiento.Size = new Size(212, 23);
            dtpFechaVencimiento.TabIndex = 32;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 532);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Segundo Parcial - Sebastián Rodríguez";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNegocios).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProveedoresDelNegocio).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvNegociosDelProveedor).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagosGenerados).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTodosLosPagos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvNegocios;
        private DataGridView dgvProveedores;
        private DataGridView dgvProveedoresDelNegocio;
        private DataGridView dgvNegociosDelProveedor;
        private DataGridView dgvPagosGenerados;
        private Button btnAgregarNegocio;
        private Button btnEliminarNegocio;
        private Button btnAgregarProveedor;
        private Button btnEliminarProveedor;
        private Button btnAsignarProveedor;
        private Button btnGenerarPago;
        private Button btnPagar;
        private Button btnEliminarPago;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtRazonSocial;
        private TextBox txtTelefonoNegocio;
        private TextBox txtDireccion;
        private Label label6;
        private Label label7;
        private Label label8;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label10;
        private Label label11;
        private TextBox txtTelefonoProveedor;
        private TextBox txtNombreProveedor;
        private Button btnDesasignarProveedor;
        private ComboBox cmbMedioDePago;
        private TextBox txtImportePago;
        private Label label9;
        private Label label12;
        private GroupBox groupBox3;
        private Label label13;
        private DateTimePicker dtpFechaVencimiento;
        private Label label14;
        private DataGridView dgvTodosLosPagos;
        private Label lblRecargoInfo;
    }
}
