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
    public partial class CUSala : UserControl
    {
        private clsSala controlSala = new clsSala();
        private int idSalaSeleccionada = 0;
        public CUSala()
        {
            InitializeComponent();
        }

        private void CUSala_Load(object sender, EventArgs e)
        {
            CargarSalasEnGrid();
        }
        private void CargarSalasEnGrid()
        {
            try
            {
                var lista = controlSala.LeerDatos();
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
                var nuevaSala = new dtoSala
                {
                    Numero = int.Parse(txtNumero.Text),
                    Capacidad = int.Parse(txtCapacidad.Text),
                    Tipo = txtTipo.Text
                };

                bool resultado = controlSala.Registrar(nuevaSala);
                if (resultado)
                {
                    MessageBox.Show("Sala registrada.");
                    LimpiarCampos();
                    CargarSalasEnGrid();
                }
                else
                {
                    MessageBox.Show("Error al registrar la sala.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSalaSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una sala.");
                return;
            }

            try
            {
                var salaActualizada = new dtoSala
                {
                    IDSala = idSalaSeleccionada,
                    Numero = int.Parse(txtNumero.Text),
                    Capacidad = int.Parse(txtCapacidad.Text),
                    Tipo = txtTipo.Text
                };

                bool resultado = controlSala.Actualizar(salaActualizada);
                if (resultado)
                {
                    MessageBox.Show("Sala actualizada.");
                    LimpiarCampos();
                    CargarSalasEnGrid();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la sala.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSalaSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una sala.");
                return;
            }

            try
            {
                var confirmacion = MessageBox.Show(
                    "¿Deseas eliminar esta sala?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.Yes)
                {
                    bool resultado = controlSala.Eliminar(idSalaSeleccionada);
                    if (resultado)
                    {
                        MessageBox.Show("Sala eliminada.");
                        LimpiarCampos();
                        CargarSalasEnGrid();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la sala.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dgvInformacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvInformacion.Rows[e.RowIndex];
                idSalaSeleccionada = Convert.ToInt32(fila.Cells["IDSala"].Value);
                txtNumero.Text = fila.Cells["Numero"].Value.ToString();
                txtCapacidad.Text = fila.Cells["Capacidad"].Value.ToString();
                txtTipo.Text = fila.Cells["Tipo"].Value.ToString();
            }
        }
        private void LimpiarCampos()
        {
            idSalaSeleccionada = 0;
            txtNumero.Clear();
            txtCapacidad.Clear();
            txtTipo.Clear();
        }
    }
}
