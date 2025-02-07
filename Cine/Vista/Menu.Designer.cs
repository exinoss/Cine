namespace Cine
{
    partial class Menu
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.pnlHijo = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBoleto = new System.Windows.Forms.Button();
            this.btnFuncion = new System.Windows.Forms.Button();
            this.btnPelicula = new System.Windows.Forms.Button();
            this.btnSala = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHijo
            // 
            this.pnlHijo.BackColor = System.Drawing.Color.SkyBlue;
            this.pnlHijo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlHijo.Location = new System.Drawing.Point(126, 36);
            this.pnlHijo.Name = "pnlHijo";
            this.pnlHijo.Size = new System.Drawing.Size(577, 384);
            this.pnlHijo.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 36);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "SISTEMA DE GESTIÓN DE CINE";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnBoleto);
            this.panel3.Controls.Add(this.btnFuncion);
            this.panel3.Controls.Add(this.btnPelicula);
            this.panel3.Controls.Add(this.btnSala);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(120, 384);
            this.panel3.TabIndex = 1;
            // 
            // btnBoleto
            // 
            this.btnBoleto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBoleto.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoleto.Image = ((System.Drawing.Image)(resources.GetObject("btnBoleto.Image")));
            this.btnBoleto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBoleto.Location = new System.Drawing.Point(0, 224);
            this.btnBoleto.Name = "btnBoleto";
            this.btnBoleto.Size = new System.Drawing.Size(120, 62);
            this.btnBoleto.TabIndex = 3;
            this.btnBoleto.Text = "Boleto";
            this.btnBoleto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBoleto.UseVisualStyleBackColor = true;
            this.btnBoleto.Click += new System.EventHandler(this.btnBoleto_Click);
            // 
            // btnFuncion
            // 
            this.btnFuncion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFuncion.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFuncion.Image = ((System.Drawing.Image)(resources.GetObject("btnFuncion.Image")));
            this.btnFuncion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFuncion.Location = new System.Drawing.Point(0, 153);
            this.btnFuncion.Name = "btnFuncion";
            this.btnFuncion.Size = new System.Drawing.Size(120, 71);
            this.btnFuncion.TabIndex = 2;
            this.btnFuncion.Text = "Funcion";
            this.btnFuncion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFuncion.UseVisualStyleBackColor = true;
            this.btnFuncion.Click += new System.EventHandler(this.btnFuncion_Click);
            // 
            // btnPelicula
            // 
            this.btnPelicula.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPelicula.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPelicula.Image = ((System.Drawing.Image)(resources.GetObject("btnPelicula.Image")));
            this.btnPelicula.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPelicula.Location = new System.Drawing.Point(0, 77);
            this.btnPelicula.Name = "btnPelicula";
            this.btnPelicula.Size = new System.Drawing.Size(120, 76);
            this.btnPelicula.TabIndex = 1;
            this.btnPelicula.Text = "Pelicula";
            this.btnPelicula.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPelicula.UseVisualStyleBackColor = true;
            this.btnPelicula.Click += new System.EventHandler(this.btnPelicula_Click);
            // 
            // btnSala
            // 
            this.btnSala.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSala.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSala.Image = ((System.Drawing.Image)(resources.GetObject("btnSala.Image")));
            this.btnSala.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSala.Location = new System.Drawing.Point(0, 0);
            this.btnSala.Name = "btnSala";
            this.btnSala.Size = new System.Drawing.Size(120, 77);
            this.btnSala.TabIndex = 0;
            this.btnSala.Text = "Sala";
            this.btnSala.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSala.UseVisualStyleBackColor = true;
            this.btnSala.Click += new System.EventHandler(this.btnSala_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 420);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlHijo);
            this.Controls.Add(this.panel2);
            this.MaximumSize = new System.Drawing.Size(719, 459);
            this.MinimumSize = new System.Drawing.Size(719, 459);
            this.Name = "Menu";
            this.Text = "Menu";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHijo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFuncion;
        private System.Windows.Forms.Button btnPelicula;
        private System.Windows.Forms.Button btnSala;
        private System.Windows.Forms.Button btnBoleto;
    }
}

