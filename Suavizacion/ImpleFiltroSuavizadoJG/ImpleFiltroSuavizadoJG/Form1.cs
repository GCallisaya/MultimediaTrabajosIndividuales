using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpleFiltroSuavizadoJG
{
    public partial class Form1 : Form
    {
        Bitmap imagen;
        Bitmap imagenProcesada;
        public Form1()
        {
            InitializeComponent();
        }

        private void CargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();

            abrir.Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.bmp";

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                imagen = new Bitmap(abrir.FileName);
                pictureBox1.Image = imagen;
            }
        }

        private void AplicarSuavizado_Click(object sender, EventArgs e)
        {
           if (imagen == null)
            {
                MessageBox.Show("Primero debes cargar una imagen original.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cambiar el cursor a modo de espera mientras procesa
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents(); 


            int ancho = imagen.Width;
            int alto = imagen.Height;
            imagenProcesada = new Bitmap(ancho, alto);

            // Algoritmo de procesamiento a nivel de píxel (Ventana de 3x3)
            for (int x = 1; x < ancho - 1; x++)
            {
                for (int y = 1; y < alto - 1; y++)
                {
                    int acumuladorR = 0;
                    int acumuladorG = 0;
                    int acumuladorB = 0;

                    // Recorrido de la ventana de vecindad 3x3
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixelVecino = imagen.GetPixel(x + i, y + j);

                            acumuladorR += pixelVecino.R;
                            acumuladorG += pixelVecino.G;
                            acumuladorB += pixelVecino.B;
                        }
                    }

                    // Calcular el promedio matemático de la matriz de 3x3
                    int nuevoR = acumuladorR / 9;
                    int nuevoG = acumuladorG / 9;
                    int nuevoB = acumuladorB / 9;

                    // Asignar el nuevo color suavizado al píxel destino
                    imagenProcesada.SetPixel(x, y, Color.FromArgb(nuevoR, nuevoG, nuevoB));
                }
            }

            // Transferir los bordes exteriores para evitar un marco vacío
            ClonarBordes(imagen, imagenProcesada);

           // sw.Stop();

            // Desplegar resultado en pantalla y restaurar el cursor
            pictureBox2.Image = imagenProcesada;
            this.Cursor = Cursors.Default;

            // Notificación flotante de finalización
            //MessageBox.Show("Filtro aplicado con éxito.\nTiempo de ejecución: {sw.ElapsedMilliseconds} ms.", "Proceso Terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==========================================
        // MÉTODO AUXILIAR: TRANSFERENCIA DE BORDES
        // ==========================================
        private void ClonarBordes(Bitmap origen, Bitmap destino)
        {
            int ancho = origen.Width;
            int alto = origen.Height;

            // Columnas laterales (Izquierda y Derecha)
            for (int y = 0; y < alto; y++)
            {
                destino.SetPixel(0, y, origen.GetPixel(0, y));
                destino.SetPixel(ancho - 1, y, origen.GetPixel(ancho - 1, y));
            }

            // Filas horizontales (Arriba y Abajo)
            for (int x = 0; x < ancho; x++)
            {
                destino.SetPixel(x, 0, origen.GetPixel(x, 0));
                destino.SetPixel(x, alto - 1, origen.GetPixel(x, alto - 1));
            }
        }
    }
}
