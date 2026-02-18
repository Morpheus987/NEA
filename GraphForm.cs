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
        private List<DataPointXY> _points; // New list which stores the inputted values of the user
        
        Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>();
        Size originalFormSize;
        bool ready = false;
        double slope, intercept;
        

        public GraphForm(List<DataPointXY> points)
        {
            InitializeComponent();

            _points = points; // Stores the inputted values of the user in the new list
            _points = _points.OrderBy(p => p.X).ToList(); // These values are then ordered by size
            PlotGraph(); // The plotgraph function is called 
            
            originalFormSize = this.Size;
            foreach (Control c in this.Controls)  // Resize function
            {
                controlBounds[c] = new Rectangle(c.Location, c.Size); 
            }
            ready = true; 

        }

        private void GraphForm_Resize(object sender, EventArgs e) // Resize function used throughout the program
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

        private (double m, double c) LinearRegression(List<DataPointXY> points)
        {
            int n = points.Count;
            double sumx = points.Sum(p => p.X);
            double sumy = points.Sum(p => p.Y);
            double sumxy = 0;
            double sumx2 = 0;
            for (int i = 0; i < n; i++)
            {
                sumxy += points[i].X * points[i].Y;
                sumx2 += points[i].X * points[i].X;
            }

            slope = (n * sumxy - sumx * sumy) / (n * sumx2 - sumx * sumx);
            intercept = (sumy - slope * sumx) / n;
            return (slope, intercept);
            

        }



        private void PlotGraph() // This function generates a graph from the inputted data values
        {
            chart1.Series.Clear();// Clears what is already on the chart

            Series series = new Series("X vs Y"); // Creates a new instance of the series class
            series.ChartType = SeriesChartType.Line; // Line graph
            series.BorderWidth = 2; // Determines the width between points
            series.MarkerStyle = MarkerStyle.Circle; 
            series.MarkerSize = 8; // Adds red dots to signify where the dots are
            series.MarkerColor = System.Drawing.Color.Red;
            

            foreach (var p in _points)
            {
                
                series.Points.AddXY(p.X, p.Y);  // Adds each point in the list to the series
            }

            chart1.Series.Add(series); // Adds the series to chart which is a collection of series objects

            chart1.ChartAreas[0].AxisX.Title = "X";
            chart1.ChartAreas[0].AxisY.Title = "Y";
            chart1.ChartAreas[0].RecalculateAxesScale(); // Adjusts the scales if data is changed
            

            var area = chart1.ChartAreas[0];
            area.AxisX.MajorGrid.Enabled = false; // Gets rid of the gridlines of the x-axis
            area.AxisY.MajorGrid.Enabled = false; // Gets rid of the gridlines of the y-axis


        }



    }
}
