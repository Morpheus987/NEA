using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NEA
{
    public partial class first_page : Form
    {
        private List<PointF> dataPoints;
        private Random rand = new Random();
        public first_page()
        {
            InitializeComponent();
            this.Text = "Linear Analysis Graph";
            this.Width = 800;
            this.Height = 600;
            this.BackColor = Color.White;

            // Generate random test data
            GenerateRandomData();

            // Enable double buffering for smoother drawing
            this.DoubleBuffered = true;

            // Redraw on resize
            this.Resize += (s, e) => this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void GenerateRandomData()
        {
            dataPoints = new List<PointF>();
            for (int i = 0; i < 20; i++)
            {
                float x = i;
                float y = (float)(2.5 * x + rand.NextDouble() * 10 - 5); // y ≈ 2.5x + noise
                dataPoints.Add(new PointF(x, y));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Define margins
            int margin = 60;
            int width = ClientSize.Width - 2 * margin;
            int height = ClientSize.Height - 2 * margin;

            // Draw axes
            Pen axisPen = new Pen(Color.Black, 2);
            g.DrawLine(axisPen, margin, ClientSize.Height - margin, ClientSize.Width - margin, ClientSize.Height - margin); // X-axis
            g.DrawLine(axisPen, margin, margin, margin, ClientSize.Height - margin); // Y-axis

            if (dataPoints == null || dataPoints.Count == 0)
                return;

            // Compute data ranges
            float minX = dataPoints.Min(p => p.X);
            float maxX = dataPoints.Max(p => p.X);
            float minY = dataPoints.Min(p => p.Y);
            float maxY = dataPoints.Max(p => p.Y);

            // Add a bit of padding
            minY -= 5;
            maxY += 5;
            
            // Transform function from data to screen coordinates
            Func<float, float, PointF> toScreen = (x, y) =>
            {
                float sx = margin + (x - minX) / (maxX - minX) * width;
                float sy = ClientSize.Height - margin - (y - minY) / (maxY - minY) * height;
                return new PointF(sx, sy);
            };

            // Draw points
            foreach (var p in dataPoints)
            {
                PointF screenPoint = toScreen(p.X, p.Y);
                g.FillEllipse(Brushes.Blue, screenPoint.X - 4, screenPoint.Y - 4, 8, 8);
            }

            // Linear regression
            float meanX = dataPoints.Average(p => p.X);
            float meanY = dataPoints.Average(p => p.Y);
            float numerator = dataPoints.Sum(p => (p.X - meanX) * (p.Y - meanY));
            float denominator = dataPoints.Sum(p => (p.X - meanX) * (p.X - meanX));
            float slope = numerator / denominator;
            float intercept = meanY - slope * meanX;

            // Draw regression line
            PointF p1 = toScreen(minX, slope * minX + intercept);
            PointF p2 = toScreen(maxX, slope * maxX + intercept);
            g.DrawLine(new Pen(Color.Red, 2), p1, p2);

            // Draw labels
            g.DrawString($"y = {slope:F2}x + {intercept:F2}", new Font("Segoe UI", 10), Brushes.Black, margin, margin - 30);
        }
    }
}

