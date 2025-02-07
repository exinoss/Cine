using Cine.Controlador;
using Cine.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cine.Vista
{
    public partial class CUBoleto : UserControl
    {
        private clsBoleto controlBoleto = new clsBoleto();
        private clsFuncion controlFuncion = new clsFuncion();
        private int idBoletoSeleccionado = 0;
        public CUBoleto()
        {
            InitializeComponent();
        }

        private void CUBoleto_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarBoletosEnGrid();
        }
        private void CargarCombos()
        {
            var listaFunciones = controlFuncion.LeerDatos();
            cmbFuncion.DataSource = listaFunciones;
            cmbFuncion.DisplayMember = "IDFuncion";
            cmbFuncion.ValueMember = "IDFuncion";
            cmbFuncion.SelectedIndex = -1;

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Vendido");
            cmbEstado.Items.Add("Reservado");
            cmbEstado.Items.Add("Disponible");
        }

        private void CargarBoletosEnGrid()
        {
            try
            {
                var lista = controlBoleto.LeerDatos();
                dgvInformacion.DataSource = null;
                dgvInformacion.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevoBoleto = new dtoBoleto
                {
                    IDFuncion = Convert.ToInt32(cmbFuncion.SelectedValue),
                    Precio = decimal.Parse(txtPrecio.Text),
                    Estado = cmbEstado.SelectedItem?.ToString() ?? ""
                };

                bool resultado = controlBoleto.Registrar(nuevoBoleto);
                if (resultado)
                {
                    MessageBox.Show("Boleto registrado.");
                    LimpiarCampos();
                    CargarBoletosEnGrid();
                }
                else
                {
                    MessageBox.Show("Error al registrar el boleto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idBoletoSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un boleto.");
                return;
            }

            try
            {
                var boletoActualizado = new dtoBoleto
                {
                    IDBoleto = idBoletoSeleccionado,
                    IDFuncion = Convert.ToInt32(cmbFuncion.SelectedValue),
                    Precio = decimal.Parse(txtPrecio.Text),
                    Estado = cmbEstado.SelectedItem?.ToString() ?? ""
                };

                bool resultado = controlBoleto.Actualizar(boletoActualizado);
                if (resultado)
                {
                    MessageBox.Show("Boleto actualizado.");
                    LimpiarCampos();
                    CargarBoletosEnGrid();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el boleto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idBoletoSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un boleto.");
                return;
            }

            try
            {
                var confirmacion = MessageBox.Show(
                    "¿Deseas eliminar este boleto?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.Yes)
                {
                    bool resultado = controlBoleto.Eliminar(idBoletoSeleccionado);
                    if (resultado)
                    {
                        MessageBox.Show("Boleto eliminado.");
                        LimpiarCampos();
                        CargarBoletosEnGrid();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el boleto.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void LimpiarCampos()
        {
            idBoletoSeleccionado = 0;
            cmbFuncion.SelectedIndex = -1;
            txtPrecio.Clear();
            cmbEstado.SelectedIndex = -1;
        }
        private void dgvInformacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvInformacion.Rows[e.RowIndex];
                idBoletoSeleccionado = Convert.ToInt32(fila.Cells["IDBoleto"].Value);
                cmbFuncion.SelectedValue = Convert.ToInt32(fila.Cells["IDFuncion"].Value);
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                cmbEstado.Text = fila.Cells["Estado"].Value.ToString();
            }
        }
    }
}
