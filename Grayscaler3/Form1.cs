using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Grayscaler3
{
    public partial class Form1 : Form
    {
        private string _path = $@"{Directory.GetCurrentDirectory()}\Img\coffie.jpg";
        private string _standartFilePath;
        private Bitmap _modifiedImage;

        public Form1()
        {
            InitializeComponent();
            ImageDownload();
            Render();
            Iteration_box.SelectedIndex = 0;
            Iteration_box.Visible = false;
        }

        private void Image_Selector_Changed(object sender, EventArgs e)
        {
            _path = Image_Selector.SelectedItem.ToString();
            Render();
        }

        private void Method_Selector_Changed(object sender, EventArgs e)
        {
            Render();
        }

        private void Render()
        {
            _modifiedImage = new Bitmap(_path, true);
            Original_Image.Image = new Bitmap(_path, true);

            int x, y;

            for (x = 0; x < _modifiedImage.Width; x++)
            {
                for (y = 0; y < _modifiedImage.Height; y++)
                {
                    Color pixelColor = _modifiedImage.GetPixel(x, y);

                    Color newColor = Algarithm(Method_Selector.SelectedIndex, pixelColor, Iteration_box.SelectedIndex + 1);
                    _modifiedImage.SetPixel(x, y, newColor);
                }
            }

            Modified_Image.Image = _modifiedImage;
        }

        private Color Algarithm(int way, Color pixelColor, int iterations)
        {
            switch (way) 
            {
                default: //All channels.
                    {
                        return Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                    }
                case 0: //All channels.
                    {
                        Iteration_box.Visible = false;

                        return Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                    }
                case 1: //By Red channel.
                    {
                        Iteration_box.Visible = false;

                        return Color.FromArgb(pixelColor.R, pixelColor.R, pixelColor.R);
                    }
                case 2: //By Green channel.
                    {
                        Iteration_box.Visible = false;

                        return Color.FromArgb(pixelColor.G, pixelColor.G, pixelColor.G);
                    }
                case 3: //By Blue channel.
                    {
                        Iteration_box.Visible = false;

                        return Color.FromArgb(pixelColor.B, pixelColor.B, pixelColor.B);
                    }
                case 4: //Average
                    {
                        Iteration_box.Visible = false;

                        var grayscaleColor = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                        return Color.FromArgb(grayscaleColor, grayscaleColor, grayscaleColor);
                    }
                case 5: //Luminance (Photoshop)
                    {
                        Iteration_box.Visible = false;

                        var grayscaleColor = 0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B;
                        grayscaleColor = Math.Ceiling(grayscaleColor);

                        return Color.FromArgb((int)grayscaleColor, (int)grayscaleColor, (int)grayscaleColor);
                    }
                case 6: //Desaturation
                    {
                        Iteration_box.Visible = false;

                        int Max = Math.Max(Math.Max(pixelColor.R, pixelColor.G), pixelColor.B);
                        int Min = Math.Min(Math.Min(pixelColor.R, pixelColor.G), pixelColor.B);

                        var grayscaleColor = (Max + Min) / 2;

                        return Color.FromArgb(grayscaleColor, grayscaleColor, grayscaleColor);
                    }
                case 7: //Pasteurization
                    {
                        Iteration_box.Visible = true;

                        double r = pixelColor.R;
                        double g = pixelColor.G;
                        double b = pixelColor.B;

                        r = Math.Round(iterations * r / 255) * (255 / iterations);
                        g = Math.Round(iterations * g / 255) * (255 / iterations);
                        b = Math.Round(iterations * b / 255) * (255 / iterations);

                        return Color.FromArgb((int)r, (int)g, (int)b);
                    }
                case 8: //Pasteurization (b&w)
                    {
                        Iteration_box.Visible = true;

                        double r = pixelColor.R;
                        double g = pixelColor.G;
                        double b = pixelColor.B;

                        r = Math.Round(iterations * r / 255) * (255 / iterations);
                        g = Math.Round(iterations * g / 255) * (255 / iterations);
                        b = Math.Round(iterations * b / 255) * (255 / iterations);

                        int grayscale = (int)Math.Round((r + g + b) / 3);

                        return Color.FromArgb(grayscale, grayscale, grayscale);
                    }
            }

        }

        private void ImageDownload()
        {
            WebClient webClient = new WebClient();

            var coffieUrl = "https://raw.githubusercontent.com/MrOkun/files/main/coffie.jpg";
            var gamblUrl = "https://raw.githubusercontent.com/MrOkun/files/main/gambl.jpg";
            var coffiePath = $"{Directory.GetCurrentDirectory()}/Img/coffie.jpg";
            var gamblPath = $"{Directory.GetCurrentDirectory()}/Img/gambl.jpg";

            if (!Directory.Exists("Img"))
            {
                Directory.CreateDirectory("Img");
            }
            if (!File.Exists($@"{Directory.GetCurrentDirectory()}\Img\gambl.jpg"))
            {
                webClient.DownloadFile(gamblUrl, gamblPath);
            }
            if (!File.Exists($@"{Directory.GetCurrentDirectory()}\Img\coffie.jpg"))
            {
                webClient.DownloadFile(coffieUrl, coffiePath);
            }

            Image_Selector.Items.Add(coffiePath);
            Image_Selector.Items.Add(gamblPath);
        }

        private void Form_Sized(object sender, EventArgs e)
        {
            this.Height = 350;
            this.Width = 380;
        }

        private void Load_Image_Click(object sender, EventArgs e)
        {
            var OPF = new OpenFileDialog();
            OPF.Filter = "Файлы .png|*.png|Файлы .jpg|*.jpg";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                _path = OPF.FileName;
                Render();
                Image_Selector.Items.Add(OPF.FileName);
            }
            else
            {
                OPF.Dispose();
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            _standartFilePath = $"{Directory.GetCurrentDirectory()}\\Img\\ModifiedImage.png";

            cheak:
            if (File.Exists(_standartFilePath))
            {
                _standartFilePath = _standartFilePath.Replace(".png", null);
                _standartFilePath = _standartFilePath + "New" + ".png";
                goto cheak;
            }

            Modified_Image.Image.Save(_standartFilePath);
            MessageBox.Show($"Image saved in {_standartFilePath}");
        }

        private void Iteration_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Render();
        }
    }
}
