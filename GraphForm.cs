using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA
{
    public partial class GraphForm : Form
    {
        private List<double> xValues;
        private List<double> yValues;
        private int w;
        private int h;
        
        double slope, intercept;

        public GraphForm(List<double> xValues, List<double> yValues)
        {
            InitializeComponent();

            Panel panelGraph = new Panel(); // Using the panel class to create a drawing surface
            panelGraph.Name = "panelGraph";
            panelGraph.Size = new Size(600, 400);
            panelGraph.Dock = DockStyle.Fill;
            panelGraph.Location = new Point(20, 20);
            panelGraph.BorderStyle = BorderStyle.FixedSingle;
            w = panelGraph.Width;
            h = panelGraph.Height;

            this.Controls.Add(panelGraph);

            this.xValues = xValues;
            this.yValues = yValues;

            panelGraph.Paint += PanelGraph_Paint;

            // Linear Regression

            int n = xValues.Count;
            double sumx = xValues.Sum();
            double sumy = yValues.Sum();
            double sumxy = 0;
            double sumx2 = 0;
            for (int i = 0; i < n; i++)
            {
                sumxy += xValues[i] * yValues[i];
                sumx2 += xValues[i] * xValues[i];

            }
            slope = (n * sumxy - (sumx * sumy)) / (n * sumx2 - (sumx * sumx));
            intercept = (sumy - slope * sumx) / n;

        }

        private void PanelGraph_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White); // Makes the background of the graph white

            Pen axisPen = new Pen(Color.Black, 2); // The colour of the axis will be black
            Pen pointPen = new Pen(Color.Blue, 2); // The colour of the points will be blue
            Pen linePen = new Pen(Color.Red, 2); // The colour of the lobf is red



            g.DrawLine(axisPen, 50, h - 50, w - 30, h - 50); // x-axis
            g.DrawLine(axisPen, 50, 30, 50, h - 30); // y-axis

            double maxX = xValues.Max();
            double maxY = yValues.Max();
            
            for (int i = 0; i < xValues.Count; i++)
            {
                int px = 50 + (int)(xValues[i] / maxX * (w - 100));
                int py = h - 50 - (int)(yValues[i] / maxY * (h - 100));
            }

            
            double y1 = intercept;

            int px1 = 50;
            int py1 = h - 50 - (int)(y1 / maxY * (h - 100));
            double x2 = maxX;
            double y2 = maxX * x2 + intercept;

            int px2 = 50 + (int)(x2 / maxX * (w - 100));
            int py2 = h - 50 - (int)(y2 / maxY * (h - 100));

            g.DrawLine(linePen, px1, py1, px2, py2);

        }

    }
}
