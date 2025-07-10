using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;

namespace Parcial2_POO
{
    public partial class Form1 : Form
    {
        private Administradora administradora = new Administradora();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarGrilla(dgvNegocios, administradora.Negocios);
            ActualizarGrilla(dgvProveedores, administradora.Proveedores);

            cmbMedioDePago.DataSource = Enum.GetValues(typeof(MedioDePago));
            cmbMedioDePago.SelectedIndex = -1;
        }

        // --------------------------
        // MÉTODOS GENÉRICOS
        // --------------------------

        private void ActualizarGrilla<T>(DataGridView grilla, List<T> datos)
        {
            grilla.DataSource = null;
            grilla.DataSource = new BindingSource { DataSource = datos };

            // Esperar a que se genere el DataBinding antes de seleccionar
            grilla.BindingContext[grilla.DataSource].CurrentChanged += (s, e) =>
            {
                SeleccionarUltimaFila(grilla);
            };
        }

        private void SeleccionarUltimaFila(DataGridView grilla)
        {
            if (grilla.InvokeRequired)
            {
                grilla.Invoke(() => SeleccionarUltimaFila(grilla));
                return;
            }

            if (grilla.Rows.Count == 0 || grilla.Rows[grilla.Rows.Count - 1].IsNewRow)
                return;

            int lastIndex = grilla.Rows.Count - 1;

            try
            {
                grilla.ClearSelection();
                grilla.Rows[lastIndex].Selected = true;
                grilla.CurrentCell = grilla.Rows[lastIndex].Cells[0];
            }
            catch
            {

            }
        }


        private void LimpiarCamposNegocio()
        {
            txtRazonSocial.Clear();
            txtTelefonoNegocio.Clear();
            txtDireccion.Clear();
        }

        private void ActualizarGrillaTodosLosPagos()
        {
            dgvTodosLosPagos.DataSource = null;
            dgvTodosLosPagos.DataSource = administradora.PagosCompletados.OrderBy(p => p.FechaPago).ToList();
        }

        private void ActualizarGrillaNegociosDelProveedor()
        {
            if (dgvProveedores.CurrentRow != null
                && dgvProveedores.CurrentRow.Index >= 0
                && dgvProveedores.CurrentRow.Index < dgvProveedores.Rows.Count - (dgvProveedores.AllowUserToAddRows ? 1 : 0)
                && dgvProveedores.CurrentRow.DataBoundItem is Proveedor proveedor)
            {
                dgvNegociosDelProveedor.DataSource = null;
                dgvNegociosDelProveedor.DataSource = proveedor.NegociosQueAtiende.ToList();

                if (dgvNegociosDelProveedor.Rows.Count > 0)
                    dgvNegociosDelProveedor.ClearSelection();
            }
            else
            {
                dgvNegociosDelProveedor.DataSource = null;
            }
        }


        private void ActualizarGrillaProveedoresDelNegocio()
        {
            if (dgvNegocios.CurrentRow != null
                && dgvNegocios.CurrentRow.Index >= 0
                && dgvNegocios.CurrentRow.Index < dgvNegocios.Rows.Count - (dgvNegocios.AllowUserToAddRows ? 1 : 0)
                && dgvNegocios.CurrentRow.DataBoundItem is Negocio negocio)
            {
                dgvProveedoresDelNegocio.DataSource = null;
                dgvProveedoresDelNegocio.DataSource = negocio.ProveedoresAsignados.ToList();

                if (dgvProveedoresDelNegocio.Rows.Count > 0)
                    dgvProveedoresDelNegocio.ClearSelection();
            }
            else
            {
                dgvProveedoresDelNegocio.DataSource = null;
            }
        }

        private void ActualizarGrillaPagosGenerados()
        {
            if (dgvNegocios.CurrentRow == null || dgvProveedoresDelNegocio.CurrentRow == null)
                return;

            var negocio = dgvNegocios.CurrentRow.DataBoundItem as Negocio;
            var proveedor = dgvProveedoresDelNegocio.CurrentRow.DataBoundItem as Proveedor;

            if (negocio == null || proveedor == null)
                return;

            var pagos = administradora.Pagos
                .Where(p => p.Negocio == negocio && p.Proveedor == proveedor && !p.Cancelado)  // Solo pendientes
                .OrderBy(p => p.FechaVencimiento)
                .ToList();

            dgvPagosGenerados.DataSource = null;
            dgvPagosGenerados.DataSource = pagos;

            // Ocultar columnas innecesarias
            if (dgvPagosGenerados.Columns["FechaPago"] != null)
                dgvPagosGenerados.Columns["FechaPago"].Visible = false;

            if (dgvPagosGenerados.Columns["Cancelado"] != null)
                dgvPagosGenerados.Columns["Cancelado"].Visible = false;

            if (dgvPagosGenerados.Columns["Negocio"] != null)
                dgvPagosGenerados.Columns["Negocio"].Visible = false;

            if (dgvPagosGenerados.Columns["Proveedor"] != null)
                dgvPagosGenerados.Columns["Proveedor"].Visible = false;

            if (dgvPagosGenerados.Columns["Recargo"] != null)
                dgvPagosGenerados.Columns["Recargo"].Visible = false;

            // Ajustar posición de columnas visibles
            if (dgvPagosGenerados.Columns["NombreNegocio"] != null)
            {
                dgvPagosGenerados.Columns["NombreNegocio"].HeaderText = "Negocio";
                dgvPagosGenerados.Columns["NombreNegocio"].DisplayIndex = 0;
                dgvPagosGenerados.Columns["NombreNegocio"].ReadOnly = true;
            }

            if (dgvPagosGenerados.Columns["NombreProveedor"] != null)
            {
                dgvPagosGenerados.Columns["NombreProveedor"].HeaderText = "Proveedor";
                dgvPagosGenerados.Columns["NombreProveedor"].DisplayIndex = 1;
                dgvPagosGenerados.Columns["NombreProveedor"].ReadOnly = true;
            }

            if (dgvPagosGenerados.Columns["Id"] != null)
            {
                dgvPagosGenerados.Columns["Id"].HeaderText = "Codigo";
                dgvPagosGenerados.Columns["Id"].DisplayIndex = dgvPagosGenerados.Columns.Count - 1;
                dgvPagosGenerados.Columns["Id"].ReadOnly = true;
            }
        }

        // --------------------------
        // CONTROLES DE NEGOCIOS
        // --------------------------

        private void btnAgregarNegocio_Click(object sender, EventArgs e)
        {
            try
            {
                string razonSocial = txtRazonSocial.Text.Trim();
                string telefono = txtTelefonoNegocio.Text.Trim();
                string direccion = txtDireccion.Text.Trim();

                if (string.IsNullOrWhiteSpace(razonSocial) || string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(direccion))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevo = new Negocio
                {
                    RazonSocial = razonSocial,
                    Telefono = telefono,
                    Direccion = direccion
                };

                administradora.Negocios.Add(nuevo);

                ActualizarGrilla(dgvNegocios, administradora.Negocios);
                LimpiarCamposNegocio();

                MessageBox.Show("Negocio agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar negocio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminarNegocio_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNegocios.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un negocio para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var negocioSeleccionado = dgvNegocios.CurrentRow.DataBoundItem as Negocio;
                if (negocioSeleccionado == null) return;

                // Validar pagos pendientes
                bool tienePagosPendientes = administradora.Pagos.Any(p =>
                    p.Negocio.Codigo == negocioSeleccionado.Codigo && !p.Cancelado);

                if (tienePagosPendientes)
                {
                    MessageBox.Show("No se puede eliminar un negocio con pagos pendientes.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmación del usuario
                DialogResult confirmacion = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el negocio '{negocioSeleccionado.RazonSocial}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                // Eliminar referencias cruzadas
                foreach (var proveedor in administradora.Proveedores)
                {
                    proveedor.NegociosQueAtiende.RemoveAll(n => n.Codigo == negocioSeleccionado.Codigo);
                }

                administradora.Negocios.Remove(negocioSeleccionado);

                ActualizarGrilla(dgvNegocios, administradora.Negocios);
                ActualizarGrillaNegociosDelProveedor();
                ActualizarGrillaTodosLosPagos();

                MessageBox.Show("Negocio eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar negocio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // --------------------------
        // EVENTO DE EDICIÓN
        // --------------------------

        private void dgvNegocios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvNegocios.Rows.Count - (dgvNegocios.AllowUserToAddRows ? 1 : 0))
                    return;

                var negocioEditado = dgvNegocios.Rows[e.RowIndex].DataBoundItem as Negocio;

                if (negocioEditado != null)
                {
                    DialogResult respuesta = MessageBox.Show(
                        "¿Desea guardar los cambios realizados en este negocio?",
                        "Confirmar modificación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (respuesta != DialogResult.Yes)
                    {
                        ActualizarGrilla(dgvNegocios, administradora.Negocios);
                        return;
                    }

                    var original = administradora.Negocios.FirstOrDefault(n => n.Codigo == negocioEditado.Codigo);
                    if (original != null)
                    {
                        original.RazonSocial = negocioEditado.RazonSocial.Trim();
                        original.Telefono = negocioEditado.Telefono.Trim();
                        original.Direccion = negocioEditado.Direccion.Trim();

                        ActualizarGrillaProveedoresDelNegocio();
                        ActualizarGrillaTodosLosPagos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar negocio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNegocios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNegocios.CurrentRow != null &&
                dgvNegocios.CurrentRow.Index >= 0 &&
                dgvNegocios.CurrentRow.Index < dgvNegocios.Rows.Count &&
                !dgvNegocios.Rows[dgvNegocios.CurrentRow.Index].IsNewRow)
            {
                ActualizarGrillaProveedoresDelNegocio();
            }
            else
            {
                dgvProveedoresDelNegocio.DataSource = null;
            }
        }




        // --------------------------
        // CONTROLES DE PROVEEDORES
        // --------------------------
        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombreProveedor.Text.Trim();
                string telefono = txtTelefonoProveedor.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(telefono))
                {
                    MessageBox.Show("Todos los campos del proveedor son obligatorios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevo = new Proveedor
                {
                    Nombre = nombre,
                    Telefono = telefono
                };

                administradora.Proveedores.Add(nuevo);

                ActualizarGrilla(dgvProveedores, administradora.Proveedores);
                txtNombreProveedor.Clear();
                txtTelefonoProveedor.Clear();

                MessageBox.Show("Proveedor agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProveedores.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un proveedor para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var proveedorSeleccionado = dgvProveedores.CurrentRow.DataBoundItem as Proveedor;
                if (proveedorSeleccionado == null) return;

                // Validar si está asignado a algún negocio
                if (proveedorSeleccionado.NegociosQueAtiende.Any())
                {
                    MessageBox.Show("No se puede eliminar un proveedor que atiende negocios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el proveedor '{proveedorSeleccionado.Nombre}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                // Eliminar de los negocios a los que esté asignado (por seguridad)
                foreach (var negocio in administradora.Negocios)
                {
                    negocio.ProveedoresAsignados.RemoveAll(p => p.Codigo == proveedorSeleccionado.Codigo);
                }

                administradora.Proveedores.Remove(proveedorSeleccionado);

                ActualizarGrilla(dgvProveedores, administradora.Proveedores);
                ActualizarGrillaProveedoresDelNegocio();
                ActualizarGrillaTodosLosPagos();

                MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAsignarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProveedores.CurrentRow == null || dgvNegocios.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un proveedor y un negocio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var proveedor = dgvProveedores.CurrentRow.DataBoundItem as Proveedor;
                var negocio = dgvNegocios.CurrentRow.DataBoundItem as Negocio;

                if (proveedor == null || negocio == null) return;

                // Verificar si ya está asignado
                if (negocio.ProveedoresAsignados.Any(p => p.Codigo == proveedor.Codigo))
                {
                    MessageBox.Show("Este proveedor ya está asignado a este negocio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                negocio.ProveedoresAsignados.Add(proveedor);
                proveedor.NegociosQueAtiende.Add(negocio);

                ActualizarGrillaProveedoresDelNegocio();
                ActualizarGrillaNegociosDelProveedor();

                MessageBox.Show("Proveedor asignado correctamente al negocio.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesasignarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNegocios.CurrentRow == null || dgvProveedoresDelNegocio.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un negocio y un proveedor asignado a ese negocio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var negocio = dgvNegocios.CurrentRow.DataBoundItem as Negocio;
                var proveedor = dgvProveedoresDelNegocio.CurrentRow.DataBoundItem as Proveedor;

                if (negocio == null || proveedor == null)
                    return;

                // Validar si hay pagos pendientes entre este proveedor y este negocio
                bool tienePagosPendientes = administradora.Pagos.Any(p =>
                    p.Negocio.Codigo == negocio.Codigo &&
                    p.Proveedor.Codigo == proveedor.Codigo &&
                    !p.Cancelado);

                if (tienePagosPendientes)
                {
                    MessageBox.Show("No se puede desasignar el proveedor porque tiene pagos pendientes con este negocio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar desasignación
                DialogResult confirmacion = MessageBox.Show(
                    $"¿Está seguro que desea desasignar al proveedor '{proveedor.Nombre}' del negocio '{negocio.RazonSocial}'?",
                    "Confirmar desasignación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                // Remover relación en ambas direcciones
                negocio.ProveedoresAsignados.RemoveAll(p => p.Codigo == proveedor.Codigo);
                proveedor.NegociosQueAtiende.RemoveAll(n => n.Codigo == negocio.Codigo);

                // Actualizar grillas
                ActualizarGrillaProveedoresDelNegocio();
                ActualizarGrillaNegociosDelProveedor();
                ActualizarGrillaTodosLosPagos();

                MessageBox.Show("Proveedor desasignado correctamente del negocio.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desasignar proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProveedores_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvProveedores.Rows.Count - (dgvProveedores.AllowUserToAddRows ? 1 : 0))
                    return;

                var proveedorEditado = dgvProveedores.Rows[e.RowIndex].DataBoundItem as Proveedor;

                if (proveedorEditado != null)
                {
                    DialogResult respuesta = MessageBox.Show(
                        "¿Desea guardar los cambios realizados en este proveedor?",
                        "Confirmar modificación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (respuesta != DialogResult.Yes)
                    {
                        ActualizarGrilla(dgvProveedores, administradora.Proveedores);
                        return;
                    }

                    var original = administradora.Proveedores.FirstOrDefault(p => p.Codigo == proveedorEditado.Codigo);
                    if (original != null)
                    {
                        original.Nombre = proveedorEditado.Nombre.Trim();
                        original.Telefono = proveedorEditado.Telefono.Trim();

                        ActualizarGrillaNegociosDelProveedor();
                        ActualizarGrillaTodosLosPagos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow != null && dgvProveedores.CurrentRow.Index >= 0)
                ActualizarGrillaNegociosDelProveedor();
            else
                dgvNegociosDelProveedor.DataSource = null;
        }


        // --------------------------
        // CONTROLES DE PAGOS
        // --------------------------

        private void btnGenerarPago_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar selección de negocio y proveedor
                if (dgvNegocios.CurrentRow == null || dgvProveedoresDelNegocio.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un negocio y un proveedor asignado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var negocio = dgvNegocios.CurrentRow.DataBoundItem as Negocio;
                var proveedor = dgvProveedoresDelNegocio.CurrentRow.DataBoundItem as Proveedor;

                if (negocio == null || proveedor == null)
                    return;

                // Validar importe
                if (!decimal.TryParse(txtImportePago.Text.Trim().Replace(',', '.'), out decimal importe) || importe <= 0)
                {
                    MessageBox.Show("Ingrese un importe válido mayor a cero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar medio de pago
                if (cmbMedioDePago.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un medio de pago.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MedioDePago medio = (MedioDePago)cmbMedioDePago.SelectedItem;

                // Crear y registrar el pago
                Pago nuevoPago = new Pago
                {
                    Id = administradora.Pagos.Any() ? administradora.Pagos.Max(p => p.Id) + 1 : 1,
                    Negocio = negocio,
                    Proveedor = proveedor,
                    Importe = importe,
                    Recargo = 0, // Se calculará al pagar
                    MedioDePago = medio,
                    FechaVencimiento = dtpFechaVencimiento.Value,
                    FechaPago = null
                };

                administradora.Pagos.Add(nuevoPago);

                ActualizarGrillaPagosGenerados();

                // Limpieza de controles
                txtImportePago.Clear();
                cmbMedioDePago.SelectedIndex = -1;

                MessageBox.Show("Pago generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPagosGenerados.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione al menos un pago pendiente para cancelar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fechaActual = DateTime.Now;

                foreach (DataGridViewRow fila in dgvPagosGenerados.SelectedRows)
                {
                    if (fila.DataBoundItem is not Pago pago || pago.Cancelado)
                        continue;

                    // Calcular recargo si el pago está vencido
                    decimal recargo = 0;
                    if (fechaActual > pago.FechaVencimiento)
                    {
                        recargo = pago.MedioDePago switch
                        {
                            MedioDePago.Efectivo => pago.Importe * 0.01m,
                            MedioDePago.Tarjeta => pago.Importe * 0.10m,
                            _ => 0
                        };
                    }

                    pago.Recargo = recargo;
                    pago.FechaPago = fechaActual;

                    // Advertencia por montos altos
                    if (pago.Total > 10000)
                    {
                        MessageBox.Show($"Atención: El pago con código {pago.Id} supera los $10.000.\nTotal: {pago.Total:C}", "Alerta de Monto Elevado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Agregar al listado de pagos completados
                    administradora.PagosCompletados.Add(new PagoCompletado
                    {
                        Codigo = pago.Id,
                        FechaVencimiento = pago.FechaVencimiento,
                        FechaPago = pago.FechaPago.Value,
                        Importe = pago.Importe,
                        Recargo = pago.Recargo,
                        MedioDePago = pago.MedioDePago,
                        Negocio = pago.Negocio.RazonSocial,
                        Proveedor = pago.Proveedor.Nombre,
                    });
                }

                // Refrescar grilla 5 (solo pagos pendientes)
                ActualizarGrillaPagosGenerados();

                // Refrescar grilla 6 (solo pagos completados)
                ActualizarGrillaTodosLosPagos();

                MessageBox.Show("Pago/s cancelado/s correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar pagos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnEliminarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPagosGenerados.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un pago para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var pagoSeleccionado = dgvPagosGenerados.CurrentRow.DataBoundItem as Pago;

                if (pagoSeleccionado == null)
                    return;

                if (pagoSeleccionado.Cancelado)
                {
                    MessageBox.Show("No se puede eliminar un pago que ya ha sido cancelado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmacion = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el pago con código {pagoSeleccionado.Id}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                    return;

                administradora.Pagos.Remove(pagoSeleccionado);

                ActualizarGrillaPagosGenerados();
                MessageBox.Show("Pago eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPagosGenerados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPagosGenerados.SelectedRows.Count == 1)
            {
                lblRecargoInfo.ForeColor = Color.Red;
                var fila = dgvPagosGenerados.SelectedRows[0];
                if (fila.DataBoundItem is Pago pago)
                {
                    if (pago.Cancelado)
                    {
                        lblRecargoInfo.Text = " ";
                        return;
                    }

                    if (DateTime.Now > pago.FechaVencimiento)
                    {
                        string mensaje = pago.MedioDePago switch
                        {
                            MedioDePago.Efectivo => "1% de Recargo",
                            MedioDePago.Tarjeta => "10% de Recargo",
                            _ => " "
                        };

                        lblRecargoInfo.Text = mensaje;
                    }
                    else
                    {
                        lblRecargoInfo.Text = " ";
                    }
                }
            }
            else
            {
                lblRecargoInfo.Text = " ";
            }
        }


        private void cmbMedioDePago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
