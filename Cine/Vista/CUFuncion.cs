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
    public partial class CUFuncion : UserControl
    {
        private clsFuncion controlFuncion = new clsFuncion();
        private clsPelicula controlPelicula = new clsPelicula();
        private clsSala controlSala = new clsSala();
        private int idFuncionSeleccionada = 0;
        public CUFuncion()
        {
            InitializeComponent();
        }

        private void CUFuncion_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarFuncionesEnGrid();
        }
        private void CargarCombos()
        {
            var listaPeliculas = controlPelicula.LeerDatos();
            cmbPelicula.DataSource = listaPeliculas;
            cmbPelicula.DisplayMember = "Titulo";
            cmbPelicula.ValueMember = "IDPelicula";
            cmbPelicula.SelectedIndex = -1;

            var listaSalas = controlSala.LeerDatos();
            cmbSala.DataSource = listaSalas;
            cmbSala.DisplayMember = "Numero";
            cmbSala.ValueMember = "IDSala";
            cmbSala.SelectedIndex = -1;
        }

        private void CargarFuncionesEnGrid()
        {
            try
            {
                var lista = controlFuncion.LeerDatos();
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
                var nuevaFuncion = new dtoFuncion
                {
                    IDPelicula = Convert.ToInt32(cmbPelicula.SelectedValue),
                    IDSala = Convert.ToInt32(cmbSala.SelectedValue),
                    Fecha = dtpFecha.Value,
                    Hora = int.Parse(txtHora.Text)
                };

                bool resultado = controlFuncion.Registrar(nuevaFuncion);
                if (resultado)
                {
                    MessageBox.Show("Función registrada.");
                    LimpiarCampos();
                    CargarFuncionesEnGrid();
                }
                else
                {
                    MessageBox.Show("Error al registrar la función.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idFuncionSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una función.");
                return;
            }

            try
            {
                var funcionActualizada = new dtoFuncion
                {
                    IDFuncion = idFuncionSeleccionada,
                    IDPelicula = Convert.ToInt32(cmbPelicula.SelectedValue),
                    IDSala = Convert.ToInt32(cmbSala.SelectedValue),
                    Fecha = dtpFecha.Value,
                    Hora = int.Parse(txtHora.Text)
                };

                bool resultado = controlFuncion.Actualizar(funcionActualizada);
                if (resultado)
                {
                    MessageBox.Show("Función actualizada.");
                    LimpiarCampos();
                    CargarFuncionesEnGrid();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la función.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idFuncionSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una función.");
                return;
            }

            try
            {
                var confirmacion = MessageBox.Show(
                    "¿Deseas eliminar esta función?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.Yes)
                {
                    bool resultado = controlFuncion.Eliminar(idFuncionSeleccionada);
                    if (resultado)
                    {
                        MessageBox.Show("Función eliminada.");
                        LimpiarCampos();
                        CargarFuncionesEnGrid();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la función.");
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
            idFuncionSeleccionada = 0;
            cmbPelicula.SelectedIndex = -1;
            cmbSala.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            txtHora.Clear();
        }
        private void dgvInformacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvInformacion.Rows[e.RowIndex];
                idFuncionSeleccionada = Convert.ToInt32(fila.Cells["IDFuncion"].Value);
                cmbPelicula.SelectedValue = Convert.ToInt32(fila.Cells["IDPelicula"].Value);
                cmbSala.SelectedValue = Convert.ToInt32(fila.Cells["IDSala"].Value);
                dtpFecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value);
                txtHora.Text = fila.Cells["Hora"].Value.ToString();
            }
        }
    }
}
