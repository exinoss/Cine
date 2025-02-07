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
    public partial class CUPelicula : UserControl
    {
        private clsPelicula controlPelicula = new clsPelicula();
        private int idPeliculaSeleccionada = 0;
        public CUPelicula()
        {
            InitializeComponent();
        }

        private void CUPelicula_Load(object sender, EventArgs e)
        {

            CargarPeliculasEnGrid();
           
        }
        private void CargarPeliculasEnGrid()
        {
            try
            {
                var lista = controlPelicula.LeerDatos();
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
                var nuevaPelicula = new dtoPelicula
                {
                    Titulo = txtTitulo.Text,
                    Genero = cmbGenero.SelectedItem?.ToString() ?? "",
                    Duracion = int.Parse(txtDuracion.Text),
                    Clasificacion = txtClasificacion.Text
                };

                bool resultado = controlPelicula.Registrar(nuevaPelicula);
                if (resultado)
                {
                    MessageBox.Show("Pelicula registrada.");
                    LimpiarCampos();
                    CargarPeliculasEnGrid();
                }
                else
                {
                    MessageBox.Show("Error al registrar la pelicula.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idPeliculaSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una pelicula.");
                return;
            }

            try
            {
                var peliculaActualizada = new dtoPelicula
                {
                    IDPelicula = idPeliculaSeleccionada,
                    Titulo = txtTitulo.Text,
                    Genero = cmbGenero.SelectedItem?.ToString() ?? "",
                    Duracion = int.Parse(txtDuracion.Text),
                    Clasificacion = txtClasificacion.Text
                };

                bool resultado = controlPelicula.Actualizar(peliculaActualizada);
                if (resultado)
                {
                    MessageBox.Show("Pelicula actualizada.");
                    LimpiarCampos();
                    CargarPeliculasEnGrid();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la pelicula.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idPeliculaSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una pelicula.");
                return;
            }

            try
            {
                var confirmacion = MessageBox.Show(
                    "¿Deseas eliminar esta pelicula?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.Yes)
                {
                    bool resultado = controlPelicula.Eliminar(idPeliculaSeleccionada);
                    if (resultado)
                    {
                        MessageBox.Show("Pelicula eliminada.");
                        LimpiarCampos();
                        CargarPeliculasEnGrid();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la pelicula.");
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
            idPeliculaSeleccionada = 0;
            txtTitulo.Clear();
            cmbGenero.SelectedIndex = -1;
            txtDuracion.Clear();
            txtClasificacion.Clear();
        }
        private void dgvInformacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvInformacion.Rows[e.RowIndex];
                idPeliculaSeleccionada = Convert.ToInt32(fila.Cells["IDPelicula"].Value);
                txtTitulo.Text = fila.Cells["Titulo"].Value.ToString();
                cmbGenero.SelectedItem = fila.Cells["Genero"].Value.ToString();
                txtDuracion.Text = fila.Cells["Duracion"].Value.ToString();
                txtClasificacion.Text = fila.Cells["Clasificacion"].Value.ToString();
            }
        }
    }
}
