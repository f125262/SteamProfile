using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace SteamProfile
{
    public partial class Form1 : Form
    {
        private string selectedVideoPath = "";

        private void SplitFrameInto5Bands(string inputImage, string outputFolder)
        {

            if (!File.Exists(inputImage))
                return;

            using (var img = Image.FromFile(inputImage))
            {
                int partWidth = img.Width / 5;

                for (int i = 0; i < 5; i++)
                {
                    Rectangle crop = new Rectangle(
                        partWidth * i,
                        0,
                        partWidth,
                        img.Height
                    );

                    using (Bitmap bmp = new Bitmap(crop.Width, crop.Height))
                    {
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), crop, GraphicsUnit.Pixel);
                        }

                        string path = Path.Combine(outputFolder, $"part_{i + 1}.png");
                        bmp.Save(path);
                    }
                }
            }
        }
        private void SplitAllFrames(string framesFolder, string projectFolder)
        {
            string[] frames = Directory.GetFiles(framesFolder, "*.png");

            for (int frameIndex = 0; frameIndex < frames.Length; frameIndex++)
            {
                string frame = frames[frameIndex];

                using (var img = Image.FromFile(frame))
                {
                    int partWidth = img.Width / 5;

                    for (int part = 0; part < 5; part++)
                    {
                        string partFolder = Path.Combine(
                            projectFolder,
                            $"part{part + 1}"
                        );

                        Directory.CreateDirectory(partFolder);

                        Rectangle crop = new Rectangle(
                            partWidth * part,
                            0,
                            partWidth,
                            img.Height
                        );

                        using (Bitmap bmp = new Bitmap(crop.Width, crop.Height))
                        {
                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                g.DrawImage(
                                    img,
                                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                                    crop,
                                    GraphicsUnit.Pixel
                                );
                            }

                            string outputFile = Path.Combine(
                                partFolder,
                                Path.GetFileName(frame)
                            );

                            bmp.Save(outputFile);
                        }
                    }
                }
            }
        }
        private void CreateGifFromFolder(
    string folder,
    string outputGif,
    string ffmpegPath
)

        {
            string framePattern = Path.Combine(
                folder,
                "frame_%04d.png"
            );

            string args =
                $"-framerate {Fps.Value} " +
                $"-i \"{framePattern}\" " +
                $"\"{outputGif}\"";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = ffmpegPath,
                Arguments = args,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process.Start(psi).WaitForExit();
        }
        private void PatchGif(string gifPath)
        {
            byte[] data = File.ReadAllBytes(gifPath);

            if (data.Length > 0)
            {
                data[data.Length - 1] = 0x21;
            }

            File.WriteAllBytes(gifPath, data);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Video files|*.mp4|PNG files|*.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectedVideoPath = dialog.FileName;

                lblFile.Text = Path.GetFileName(selectedVideoPath);
            }
        }

        private void btnShowPath_Click(object sender, EventArgs e)
        {
            MessageBox.Show(selectedVideoPath);
        }

        private void Fps_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Pfps_Click(object sender, EventArgs e)
        {
            int fps = (int)Fps.Value;
            int scale = (int)scaleValue.Value;
            MessageBox.Show($"FPS: {fps},\nScale: {scale}");
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(selectedVideoPath))
            {
                MessageBox.Show("Выбери сначала видео");
                return;
            }
            if (Workshop.Checked)
            {
                string projectFolder = Path.Combine(
                Path.GetDirectoryName(selectedVideoPath),
                Path.GetFileNameWithoutExtension(selectedVideoPath)
                );

                Directory.CreateDirectory(projectFolder);

                string framesFolder = Path.Combine(projectFolder, "frames");

                Directory.CreateDirectory(framesFolder);
                string ffmpegPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ffmpeg.exe"
                );

                string framePattern = Path.Combine(
                    framesFolder,
                    "frame_%04d.png"
                );

                string args =
                    $"-i \"{selectedVideoPath}\" " + $"-vf fps={Fps.Value},scale={scaleValue.Value}:-1 " + $"\"{framePattern}\"";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = ffmpegPath,
                    Arguments = args,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process.Start(psi).WaitForExit();

                int frameCount = Directory.GetFiles(
                    framesFolder,
                    "*.png"
                ).Length;

                MessageBox.Show($"Кадров извлечено: {frameCount}");

                SplitAllFrames(framesFolder, projectFolder);

                MessageBox.Show("Кадры разложены по 5 папкам");
                for (int i = 1; i <= 5; i++)
                {
                    string partFolder = Path.Combine(
                        projectFolder,
                        $"part{i}"
                    );

                    string outputGif = Path.Combine(
                        projectFolder,
                        $"part{i}.gif"
                    );

                    CreateGifFromFolder(
                        partFolder,
                        outputGif,
                        ffmpegPath
                    );


                    PatchGif(outputGif);
                }

                MessageBox.Show("Все GIF собраны");
            }

            else
            {
                string ffmpegPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ffmpeg.exe"
            );

                string outputPath = Path.Combine(
                Path.GetDirectoryName(selectedVideoPath),
                "output.gif"
            );

                string args = $"-i \"{selectedVideoPath}\" " + $"-vf fps={Fps.Value},scale={scaleValue.Value}:-1 " + $"\"{outputPath}\"";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = ffmpegPath,
                    Arguments = args,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process.Start(psi).WaitForExit();

                MessageBox.Show("Готово: " + outputPath);
            }

        }

        private void scaleValue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Workshop_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
