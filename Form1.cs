using System;
using System.Drawing;
using System.Windows.Forms;

namespace RgbToXyzConverter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            trackBarRed.Scroll += (s, e) => UpdateXyzValues();
            trackBarGreen.Scroll += (s, e) => UpdateXyzValues();
            trackBarBlue.Scroll += (s, e) => UpdateXyzValues();
            UpdateXyzValues();
        }

        private void UpdateXyzValues()
        {
            int r = trackBarRed.Value;
            int g = trackBarGreen.Value;
            int b = trackBarBlue.Value;

            // Convert RGB to XYZW (RGBA)
            var xyzw = RgbToXyz(r, g, b);
            label1.Text = $"RGB ({r}, {g}, {b}) -> XYZW ({xyzw.X:F2}, {xyzw.Y:F2}, {xyzw.Z:F2}, {xyzw.W:F2})";

            // Update color preview based on RGB values
            colorPreview.BackColor = Color.FromArgb(r, g, b);
        }

        private (double X, double Y, double Z, double W) RgbToXyz(int r, int g, int b, int alpha = 255)
        {
            // Normalize the RGB values to the range [0, 1]
            double x = r / 255.0;  // X is Red
            double y = g / 255.0;  // Y is Green
            double z = b / 255.0;  // Z is Blue
            double w = alpha / 255.0;  // W is Alpha (transparency)

            return (X: x, Y: y, Z: z, W: w);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}