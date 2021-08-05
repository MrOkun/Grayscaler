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
        int change = 4;
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
                case "Desaturation":
                    {
                        change = 6;
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
            this.Height = 330;
            this.Width = 354;
        }
    }
}
