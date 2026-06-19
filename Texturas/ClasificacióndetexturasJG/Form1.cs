using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClasificacióndetexturasJG
{
    public partial class Form1 : Form
    {
        Bitmap imagen;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            if (imagen == null)
                return;

            string clase;
            int r, g, b;

            ObtenerInformacionPunto(
                imagen,
                e.X,
                e.Y,
                out clase,
                out r,
                out g,
                out b);

            Bitmap copia = new Bitmap(imagen);

            using (Graphics grafico = Graphics.FromImage(copia))
            {
                grafico.DrawRectangle(
                    Pens.Red,
                    e.X - 10,
                    e.Y - 10,
                    20,
                    20);
            }

            pictureBox2.Image = copia;

            Resultado.Text =
                "X=" + e.X +
                " Y=" + e.Y +
                " RGB(" + r + "," + g + "," + b + ")" +
                " -> " + clase;
        
        }

        private void cargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();

            abrir.Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.bmp";

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                imagen = new Bitmap(abrir.FileName);
                pictureBox1.Image = imagen;
            }
        }
        private Bitmap ClasificarPorVentanas(Bitmap bmp)
        {
            Bitmap salida = new Bitmap(bmp.Width, bmp.Height);

            int radio = 2;

            for (int y = radio; y < bmp.Height - radio; y++)
            {
                for (int x = radio; x < bmp.Width - radio; x++)
                {
                    long sumaR = 0;
                    long sumaG = 0;
                    long sumaB = 0;

                    int contador = 0;

                    for (int j = -radio; j <= radio; j++)
                    {
                        for (int i = -radio; i <= radio; i++)
                        {
                            Color c = bmp.GetPixel(x + i, y + j);

                            sumaR += c.R;
                            sumaG += c.G;
                            sumaB += c.B;

                            contador++;
                        }
                    }

                    int promR = (int)(sumaR / contador);
                    int promG = (int)(sumaG / contador);
                    int promB = (int)(sumaB / contador);

                    Color colorClase;

                    if (promG > promR && promG > promB)
                    {
                        colorClase = Color.Lime;
                    }
                    else if (promR > promG && promR > promB)
                    {
                        colorClase = Color.SaddleBrown;
                    }
                    else if ((promR + promG + promB) / 3 > 140)
                    {
                        colorClase = Color.LightGray;
                    }
                    else
                    {
                        colorClase = Color.Black;
                    }

                    salida.SetPixel(x, y, colorClase);
                }
            }

            return salida;
        }
        private void ObtenerInformacionPunto(
            Bitmap bmp,
            int xCentro,
            int yCentro,
            out string clase,
            out int promR,
            out int promG,
            out int promB)
        {
            int radio = 5;

            long sumaR = 0;
            long sumaG = 0;
            long sumaB = 0;

            int contador = 0;

            for (int y = yCentro - radio; y <= yCentro + radio; y++)
            {
                for (int x = xCentro - radio; x <= xCentro + radio; x++)
                {
                    if (x >= 0 &&
                        x < bmp.Width &&
                        y >= 0 &&
                        y < bmp.Height)
                    {
                        Color c = bmp.GetPixel(x, y);

                        sumaR += c.R;
                        sumaG += c.G;
                        sumaB += c.B;

                        contador++;
                    }
                }
            }

            promR = (int)(sumaR / contador);
            promG = (int)(sumaG / contador);
            promB = (int)(sumaB / contador);

            if (promG > promR + 25 && promG > promB + 25)
            {
                clase = "CESPED";
            }
            else if (promR > promB + 10)
            {
                clase = "TIERRA";
            }
            else if (Math.Abs(promR - promG) < 15 && Math.Abs(promG - promB) < 15)
            {
                int gris = (promR + promG + promB) / 3;

                if (gris >= 150 && gris <= 210)
                    clase = "CEMENTO";

                else if (gris >= 80 && gris <= 130)
                    clase = "ASFALTO";

                else
                    clase = "DESCONOCIDO";
            }
            else
            {
                clase = "DESCONOCIDO";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
