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
using System.Windows.Forms.DataVisualization.Charting;

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
            Rectangle formbounds = this.Bounds;

            int left = formbounds.Left;
            int top = formbounds.Top;
            int right = formbounds.Right;
            int bottom = formbounds.Bottom;
            // The panel class is used as it you can group and control all the variables as a single unit

            this.xValues = xValues;
            this.yValues = yValues;  

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

        

    }
}
