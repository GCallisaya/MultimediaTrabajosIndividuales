namespace ImpleFiltroSuavizadoJG
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.CargarImagen = new System.Windows.Forms.Button();
            this.AplicarSuavizado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(28, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(271, 215);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(428, 37);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(246, 211);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // CargarImagen
            // 
            this.CargarImagen.Location = new System.Drawing.Point(107, 285);
            this.CargarImagen.Name = "CargarImagen";
            this.CargarImagen.Size = new System.Drawing.Size(100, 23);
            this.CargarImagen.TabIndex = 2;
            this.CargarImagen.Text = "CargaarImagen";
            this.CargarImagen.UseVisualStyleBackColor = true;
            this.CargarImagen.Click += new System.EventHandler(this.CargarImagen_Click);
            // 
            // AplicarSuavizado
            // 
            this.AplicarSuavizado.Location = new System.Drawing.Point(496, 285);
            this.AplicarSuavizado.Name = "AplicarSuavizado";
            this.AplicarSuavizado.Size = new System.Drawing.Size(104, 23);
            this.AplicarSuavizado.TabIndex = 3;
            this.AplicarSuavizado.Text = "AplicarSuavizado";
            this.AplicarSuavizado.UseVisualStyleBackColor = true;
            this.AplicarSuavizado.Click += new System.EventHandler(this.AplicarSuavizado_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 350);
            this.Controls.Add(this.AplicarSuavizado);
            this.Controls.Add(this.CargarImagen);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button CargarImagen;
        private System.Windows.Forms.Button AplicarSuavizado;
    }
}

