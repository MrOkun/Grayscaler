using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Bitmap image1;
        int change = 0;
        int factor = 1;
        string path = @"C:\Users\User\source\repos\WindowsFormsApp2\WindowsFormsApp2\bin\Debug\Img\coffie.jpg";
        bool AlgorithmWarning = true;


        public Form1()
        {
            InitializeComponent();
            SimpleImageDownload();
            Render();
        }

        private void AllButton_Click(object sender, EventArgs e)
        {
            change = 0;
            Render();
            selectBox.Text = null;
        }

        private void selectBox_SelectedIndexChanged(object sender, EventArgs e) //Algorithm select.
        {
            switch (selectBox.Text)
            {
                default: //all (colored)
                    {
                        change = 0;
                        Render();
                        break;
                    }
                case "Red": //by red color (B%W)
                    {
                        change = 1;
                        Render();
                        break;
                    }
                case "Green": //by green color (B%W)
                    {
                        change = 2;
                        Render();
                        break;
                    }
                case "Blue": //by blue color (B%W)
                    {
                        change = 3;
                        Render();
                        break;
                    }
                case "Average": //by average of all colors.
                    {
                        change = 4;
                        Render();
                        break;
                    }
                case "Average (Human eye correcting)": //by average of all colors (human correction).
                    {
                        change = 5;
                        Render();
                        break;
                    }
                case "Desaturation": //by Desaturation colors
                    {
                        change = 6;
                        Render();
                        break;
                    }
                case "Dithering": //Dithering-Floyd Algorithm
                    {
                        change = 7;
                        Render();
                        break;
                    }
            }
        }

        private void Render()
        {
            image1 = new Bitmap(path, true);
            preImage.Image = new Bitmap(path, true);

            switch (change)
            {
                case 0: //all non-b&w
                    {
                        int x, y;

                        for (x = 0; x < image1.Width; x++)
                        {
                            for (y = 0; y < image1.Height; y++)
                            {
                                Color pixelColor = image1.GetPixel(x, y);
                                Color newColor = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                                image1.SetPixel(x, y, newColor);
                            }
                        }
                        break;
                    }
                case 1: //red b&w
                    {
                        startWarning();

                        int x, y;

                        for (x = 0; x < image1.Width; x++)
                        {
                            for (y = 0; y < image1.Height; y++)
                            {
                                Color pixelColor = image1.GetPixel(x, y);
                                Color newColor = Color.FromArgb(pixelColor.R, pixelColor.R, pixelColor.R);
                                image1.SetPixel(x, y, newColor);
                            }
                        }
                        break;
                    }
                case 2: //green b&w
                    {
                        startWarning();

                        int x, y;

                        for (x = 0; x < image1.Width; x++)
                        {
                            for (y = 0; y < image1.Height; y++)
                            {
                                Color pixelColor = image1.GetPixel(x, y);
                                Color newColor = Color.FromArgb(pixelColor.G, pixelColor.G, pixelColor.G);
                                image1.SetPixel(x, y, newColor);
                            }
                        }
                        break;
                    }
                case 3: //blue b&w
                    {
                        startWarning();

                        int x, y;

                        for (x = 0; x < image1.Width; x++)
                        {
                            for (y = 0; y < image1.Height; y++)
                            {
                                Color pixelColor = image1.GetPixel(x, y);
                                Color newColor = Color.FromArgb(pixelColor.B, pixelColor.B, pixelColor.B);
                                image1.SetPixel(x, y, newColor);
                            }
                        }
                        break;
                    }
                case 4: //average b&w
                    {
                        int x, y;

                        for (x = 0; x < image1.Width; x++)
                        {
                            for (y = 0; y < image1.Height; y++)
                            {
                                Color pixelColor = image1.GetPixel(x, y);
                                var grayscaleColor = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                                Color newColor = Color.FromArgb(grayscaleColor, grayscaleColor, grayscaleColor);
                                image1.SetPixel(x, y, newColor);
                            }
                        }
                        break;
                    }
                case 5: //average (human eye corection) b&w
                    {
                        int x, y;

                        for (x = 0; x < image1.Width; x++)
                        {
                            for (y = 0; y < image1.Height; y++)
                            {
                                Color pixelColor = image1.GetPixel(x, y);
                                var grayscaleColor = 0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B;
                                grayscaleColor = Math.Ceiling(grayscaleColor);

                                Color newColor = Color.FromArgb((int)grayscaleColor, (int)grayscaleColor, (int)grayscaleColor);
                                image1.SetPixel(x, y, newColor);
                                //Debug.WriteLine((int)grayscaleColor);
                            }
                        }
                        break;
                    }
                case 6: //Desaturation b&w
                    {
                        int x, y;

                        for (x = 0; x < image1.Width; x++)
                        {
                            for (y = 0; y < image1.Height; y++)
                            {
                                var nums = new NumManipulation();

                                Color pixelColor = image1.GetPixel(x, y);

                                var grayscaleColor = (nums.FindMax(pixelColor.R, pixelColor.G, pixelColor.B) + nums.FindMin(pixelColor.R, pixelColor.G, pixelColor.B)) / 2;

                                Color newColor = Color.FromArgb((int)grayscaleColor, (int)grayscaleColor, (int)grayscaleColor);
                                image1.SetPixel(x, y, newColor);
                                //Debug.WriteLine((int)grayscaleColor);
                            }
                        }
                        break;
                    }
                case 7: //dithering
                    {
                        int x, y;

                        for (x = 1; x < image1.Width - 1; x++)
                        {
                            for (y = 0; y < image1.Height - 1; y++)
                            {
                                Color pixelColor = image1.GetPixel(x, y);

                                float oldR = pixelColor.R;
                                float oldG = pixelColor.G;
                                float oldB = pixelColor.B;




                                int newR = (int)((float)Math.Round(factor * oldR / 255, 0) * (255 / factor));
                                int newG = (int)((float)Math.Round(factor * oldG / 255, 0) * (255 / factor));
                                int newB = (int)((float)Math.Round(factor * oldB / 255, 0) * (255 / factor));

                                Color newColor = Color.FromArgb(newR, newG, newB);

                                float errR = oldR - newR;
                                float errG = oldG - newG;
                                float errB = oldB - newB;

                                Color c = image1.GetPixel(x + 1, y); //1
                                float r = c.R;
                                float g = c.G;
                                float b = c.B;

                                r = r + errR * 7 / 16;
                                g = g + errG * 7 / 16;
                                b = b + errB * 7 / 16;

                                r = (float)Math.Round(r, 0);
                                g = (float)Math.Round(g, 0);
                                b = (float)Math.Round(b, 0);

                                if (r > 255)
                                {
                                    r = 255;
                                }
                                if (r < 0)
                                {
                                    r = 0;
                                }
                                if (g > 255)
                                {
                                    g = 255;
                                }
                                if (g < 0)
                                {
                                    g = 0;
                                }
                                if (b > 255)
                                {
                                    b = 255;
                                }
                                if (b < 0)
                                {
                                    b = 0;
                                }

                                Color ErrColor = Color.FromArgb((int)r, (int)g, (int)b);
                                image1.SetPixel(x + 1, y, ErrColor);


                                c = image1.GetPixel(x - 1, y + 1); //2
                                r = c.R;
                                g = c.G;
                                b = c.B;

                                r = r + errR * 3 / 16;
                                g = g + errG * 3 / 16;
                                b = b + errB * 3 / 16;

                                r = (float)Math.Round(r, 0);
                                g = (float)Math.Round(g, 0);
                                b = (float)Math.Round(b, 0);

                                if (r > 255)
                                {
                                    r = 255;
                                }
                                if (r < 0)
                                {
                                    r = 0;
                                }
                                if (g > 255)
                                {
                                    g = 255;
                                }
                                if (g < 0)
                                {
                                    g = 0;
                                }
                                if (b > 255)
                                {
                                    b = 255;
                                }
                                if (b < 0)
                                {
                                    b = 0;
                                }

                                ErrColor = Color.FromArgb((int)r, (int)g, (int)b);
                                image1.SetPixel(x - 1, y + 1, ErrColor);

                                c = image1.GetPixel(x, y + 1); //3
                                r = c.R;
                                g = c.G;
                                b = c.B;

                                r = r + errR * 5 / 16;
                                g = g + errG * 5 / 16;
                                b = b + errB * 5 / 16;

                                r = (float)Math.Round(r, 0);
                                g = (float)Math.Round(g, 0);
                                b = (float)Math.Round(b, 0);


                                if (r > 255)
                                {
                                    r = 255;
                                }
                                if (r < 0)
                                {
                                    r = 0;
                                }
                                if (g > 255)
                                {
                                    g = 255;
                                }
                                if (g < 0)
                                {
                                    g = 0;
                                }
                                if (b > 255)
                                {
                                    b = 255;
                                }
                                if (b < 0)
                                {
                                    b = 0;
                                }

                                ErrColor = Color.FromArgb((int)r, (int)g, (int)b);
                                image1.SetPixel(x, y + 1, ErrColor);


                                c = image1.GetPixel(x + 1, y + 1); //4
                                r = c.R;
                                g = c.G;
                                b = c.B;

                                r = r + errR * 1 / 16;
                                g = g + errG * 1 / 16;
                                b = b + errB * 1 / 16;

                                r = (float)Math.Round(r, 0);
                                g = (float)Math.Round(g, 0);
                                b = (float)Math.Round(b, 0);


                                if (r > 255)
                                {
                                    r = 255;
                                }
                                if (r < 0)
                                {
                                    r = 0;
                                }
                                if (g > 255)
                                {
                                    g = 255;
                                }
                                if (g < 0)
                                {
                                    g = 0;
                                }
                                if (b > 255)
                                {
                                    b = 255;
                                }
                                if (b < 0)
                                {
                                    b = 0;
                                }

                                ErrColor = Color.FromArgb((int)r, (int)g, (int)b);
                                image1.SetPixel(x + 1, y + 1, ErrColor);


                                /*
                                image1.SetPixel(x - 1, y, newColor);
                                image1.SetPixel(x - 1, y + 1, newColor);
                                image1.SetPixel(x, y + 1, newColor);
                                image1.SetPixel(x + 1, y + 1, newColor);
                                */
                            }
                        }

                        x = 0;
                        y = 0;

                        for (x = 0; x < image1.Width; x++)
                        {
                            for (y = 0; y < image1.Height; y++)
                            {
                                Color pixelColor = image1.GetPixel(x, y);
                                var grayscaleColor = 0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B;
                                grayscaleColor = Math.Ceiling(grayscaleColor);

                                Color newColor = Color.FromArgb((int)grayscaleColor, (int)grayscaleColor, (int)grayscaleColor);
                                image1.SetPixel(x, y, newColor);
                                //Debug.WriteLine((int)grayscaleColor);
                            }
                        }
                        break;
                    }
                default: //bruh moment...
                    {
                        int x, y;

                        for (x = 0; x < image1.Width; x++)
                        {
                            for (y = 0; y < image1.Height; y++)
                            {
                                Color pixelColor = image1.GetPixel(x, y);
                                Color newColor = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                                image1.SetPixel(x, y, newColor);
                            }
                        }
                        break;
                    }


            }

            postImage.Image = image1;
        }

        private void Load_Click(object sender, EventArgs e)
        {
            var OPF = new OpenFileDialog();
            OPF.Filter = "Файлы .png|*.png|Файлы .jpg|*.jpg";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                path = OPF.FileName;
                Render();
                LoadBox.Items.Add(OPF.FileName);
            }
            else
            {
                OPF.Dispose();
            }
        }

        private void LoadBox_Change(object sender, EventArgs e)
        {
            path = LoadBox.SelectedItem.ToString();
            Render();
        }

        private void SimpleImageDownload()
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

            webClient.DownloadFile(coffieUrl, coffiePath);
            webClient.DownloadFile(gamblUrl, gamblPath);


            LoadBox.Items.Add(coffiePath);
            LoadBox.Items.Add(gamblPath);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var standartFilePath = $"{Directory.GetCurrentDirectory()}/Img/PostImage.jpg";

            postImage.Image.Save(standartFilePath);
            MessageBox.Show($"Image saved in {standartFilePath}");
        }

        private void startWarning()
        {
            if (AlgorithmWarning)
            {
                AlgorithmWarning = false;
                MessageBox.Show("Red, Green, Blue algorithm can be rube and uncorrect!");
            }
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            this.Height = 407;
            this.Width = 354;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            DitheringFactor.Text = $"Dithering Factor : {factor}";
            factor = trackBar1.Value;
            Render();
        }
    }
}
