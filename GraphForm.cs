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
        Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>();
        Size originalFormSize;
        bool ready = false;

        double slope, intercept;

        public GraphForm(List<double> xValues, List<double> yValues)
        {
            InitializeComponent();

            // The panel class is used as it you can group and control all the variables as a single unit

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
            DoubleBuffered = true;

            panelGraph.Paint += PanelGraph_Paint;

            // These variables are all taken for linear regression

            int n = xValues.Count; // Stores the number of data points in this variable
            double sumx = xValues.Sum(); // Finds the sum of the x values
            double sumy = yValues.Sum(); // Finds the sum of the y values
            double sumxy = 0; // Stores the sum of (x*y) for all datapoints
            double sumx2 = 0; // Stores the sum of x**2 
            for (int i = 0; i < n; i++)  // Loops through all the data points
            {
                sumxy += xValues[i] * yValues[i];  // Finds the sum of (x*y) for all datapoints
                sumx2 += xValues[i] * xValues[i];  // Finds the sum of x**2

            }
            // Linear regression
            // LOBF (Line of best fit)
            slope = (n * sumxy - (sumx * sumy)) / (n * sumx2 - (sumx * sumx)); //Gradient of LOBF formula used to calculate from linear regression
            intercept = (sumy - slope * sumx) / n; // Intercept of the LOBF
            // Resizing event I implemented in each form it doesn't do much in this form as the panel isn't part of the controls
            originalFormSize = this.Size;
            foreach (Control c in this.Controls) 
            {
                controlBounds[c] = new Rectangle(c.Location, c.Size); 
            }
            ready = true;

        }

        private void GraphForm_Resize(object sender, EventArgs e)
        {
            if (!ready) return;
            float xRatio = (float)this.Width / originalFormSize.Width;
            float yRatio = (float)this.Height / originalFormSize.Height;
            foreach (Control c in this.Controls)
            {
                Rectangle r = controlBounds[c];
                c.Location = new Point((int)(r.X * xRatio), (int)(r.Y * yRatio)); 
                c.Size = new Size((int)(r.Width * xRatio), (int)(r.Height * yRatio)); 
            }
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

            double maxX = xValues.Max(); // Stores the maximum x value
            double maxY = yValues.Max(); // Store the maximum y value
            
            for (int i = 0; i < xValues.Count; i++)
            {
                int px = 50 + (int)(xValues[i] / maxX * (w - 100));
                int py = h - 50 - (int)(yValues[i] / maxY * (h - 100));

                g.DrawEllipse(pointPen, px, py, 2, 2);
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
