using Cine.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cine
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnSala_Click(object sender, EventArgs e)
        {
            CUSala frm = new CUSala();
            pnlHijo.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            pnlHijo.Controls.Add(frm);
        }

        private void btnPelicula_Click(object sender, EventArgs e)
        {
            CUPelicula frm = new CUPelicula();
            pnlHijo.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            pnlHijo.Controls.Add(frm);
        }

        private void btnFuncion_Click(object sender, EventArgs e)
        {

            CUFuncion frm = new CUFuncion();
            pnlHijo.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            pnlHijo.Controls.Add(frm);
        }

        private void btnBoleto_Click(object sender, EventArgs e)
        {
            CUBoleto frm = new CUBoleto();
            pnlHijo.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            pnlHijo.Controls.Add(frm);
        }
    }
}
