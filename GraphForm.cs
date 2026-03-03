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
        Size originalFormSize;//Properties used in the resize function
        bool ready = false;
        double slope, intercept; //Store gradient and intercept of line of best fit 
        

        public GraphForm(List<DataPointXY> points)
        {
            InitializeComponent();

            _points = points; // Stores the inputted values of the user in the new list
            _points = _points.OrderBy(p => p.X).ToList(); // These values are then ordered by size
            PlotQuadraticGraph(); // A graph is generated
            
            originalFormSize = this.Size;
            foreach (Control c in this.Controls)  // Resize function
            {
                controlBounds[c] = new Rectangle(c.Location, c.Size); 
            }
            ready = true;

        //    var (m, intercept) = LinearRegression(_points); // Applies the linear regression algorithm on the data
        //    labelEquation.Text = ($"y = {m:F3}x + {intercept:F3}"); //Displays the linear equation produced

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
            int n = points.Count; //Stores the length of the list
            double sumx = points.Sum(p => p.X); // Finds the sum of the x-values
            double sumy = points.Sum(p => p.Y); // Finds the sum of the y-values
            double sumxy = 0; // Stores the sum of x*y values
            double sumx2 = 0; //Stores the sum of the x * x values
            for (int i = 0; i < n; i++)
            {
                sumxy += points[i].X * points[i].Y;  // Finds the sum of x*y values
                sumx2 += points[i].X * points[i].X;  //Finds the sum of the x * x values
            }

            slope = (n * sumxy - sumx * sumy) / (n * sumx2 - sumx * sumx); // Determines the graident
            intercept = (sumy - slope * sumx) / n; // Determines the y-intercept
            return (slope, intercept); // Returns these values
            

        }

        private void GraphForm_Load(object sender, EventArgs e)
        {
            graph.Cursor = Cursors.Hand; //Changes the cursor to a cross so it is easier for the user to pinpoints parts of the graph
            graph.GetToolTipText += chart1_GetToolTipText; 
            //Adds all these graph editing options to the combo box
            comboEditOptions.Items.Add("Change X Axis Title"); 
            comboEditOptions.Items.Add("Change Y Axis Title");
            comboEditOptions.Items.Add("Change Background Colour");
            comboEditOptions.Items.Add("Change Regression Line Colour");
            comboEditOptions.Items.Add("Change Point Colour");

            comboEditOptions.SelectedIndex = 0; //Defaults to showing the first option

        }


        private void chart1_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            var hit = graph.HitTest(e.X, e.Y); //Determines if there is an element of the chart where the cursor is

            if (hit.PointIndex >= 0 && hit.Series != null)
            {
                double x = hit.Series.Points[hit.PointIndex].XValue; //Retrieves the x value of the point
                double y = hit.Series.Points[hit.PointIndex].YValues[0];//Retrieves the y value of the point

                e.Text = $"X = {x:F2}\nY = {y:F2}"; //Displays the x and y coordinate if the cursor is hovering above
            }
        }

        private void btnapplyedit_Click(object sender, EventArgs e) //When the apply edit button is pressed
        {
            string selectedOption = comboEditOptions.SelectedItem.ToString();

            int maxDegree = 3; // linear, quadratic, cubic

            double bestR2 = double.MinValue;
            double[] bestCoeffs = null;
            int bestDegree = 1;

            for (int d = 1; d <= maxDegree; d++)
            {
                var coeffs = PolynomialRegression(_points, d);
                double r2 = CalculateRSquared(_points, coeffs);

                if (r2 > bestR2)
                {
                    bestR2 = r2;
                    bestCoeffs = coeffs;
                    bestDegree = d;
                }
            }


            switch (selectedOption) // I used a switch case for each option in the combo box
            {
                case "Change X Axis Title":
                    graph.ChartAreas[0].AxisX.Title = txtAxisName.Text; // The name of the axis is changed to the text in the textbox
                    break; 

                case "Change Y Axis Title":
                    graph.ChartAreas[0].AxisY.Title = txtAxisName.Text; // The name of the axis is changed to the text in the textbox
                    break;

                case "Change Background Colour":
                    if (colorDialog1.ShowDialog() == DialogResult.OK)
                    {
                        graph.ChartAreas[0].BackColor = colorDialog1.Color; //Changes the background colour of the graph
                    }  // Opens a colour dialog which is just a selectiion of colours the user can select
                    break;

                case "Change Regression Line Colour":
                    if (colorDialog1.ShowDialog() == DialogResult.OK)
                    {
                        graph.Series[$"Degree {bestDegree}"].Color = colorDialog1.Color; //The regression line colour is changed
                    }
                    break;
                case "Change Point Colour":
                    if (colorDialog1.ShowDialog() == DialogResult.OK)
                    {
                        graph.Series["Data"].MarkerColor = colorDialog1.Color;
                    }
                    break;
            }
        }

        private void comboEditOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = comboEditOptions.SelectedItem.ToString();

            if (option.Contains("Axis"))
                txtAxisName.Visible = true; //Hides the textbox if is not related to the axis
            else
                txtAxisName.Visible = false;
        }

        private void PlotGraph()
        {
            

            int maxDegree = 3; // linear, quadratic, cubic

            double bestR2 = double.MinValue;
            double[] bestCoeffs = null;
            int bestDegree = 1;

            for (int d = 1; d <= maxDegree; d++)
            {
                var coeffs = PolynomialRegression(_points, d);
                double r2 = CalculateRSquared(_points, coeffs);

                if (r2 > bestR2)
                {
                    bestR2 = r2;
                    bestCoeffs = coeffs;
                    bestDegree = d;
                }
            }


            graph.Series.Clear(); //Clears the chart because it already loads with stuff

            var area = graph.ChartAreas[0];
            area.AxisX.Title = "X"; //Names the x-axis
            area.AxisY.Title = "Y"; //Names the y-axis
            area.AxisX.MajorGrid.Enabled = false; //Removes the x-axis gridline
            area.AxisY.MajorGrid.Enabled = false; //Removes the y-axis gridlines

            if (_points.Count >= 2)
            {
                var (m, c) = LinearRegression(_points); 

                Series dataSeries = new Series("Data"); //This is to display the points
                dataSeries.ChartType = SeriesChartType.Point;
                dataSeries.MarkerStyle = MarkerStyle.Circle; //Displayed as circles
                dataSeries.MarkerSize = 10; //Originally size 10
                dataSeries.MarkerColor = Color.Red; //Sets the colour as red

                foreach (var p in _points)
                {
                    int index = dataSeries.Points.AddXY(p.X, p.Y); //Adds each point to the series
                    dataSeries.Points[index].ToolTip = $"X = {p.X:F2}\nY = {p.Y:F2}"; //Adds the tool tip to each point
                }

                graph.Series.Add(dataSeries);


                //  Series regressionSeries = new Series("Regression"); 
                //  regressionSeries.ChartType = SeriesChartType.Line;
                //  regressionSeries.BorderWidth = 2; //Sets the width as 2
                //  regressionSeries.Color = Color.Blue; //Sets the colour as blue

                //  double minx = _points.Min(p => p.X); //Finds the minimum x value
                //  double maxx = _points.Max(p => p.X); //Finds the minimum y value

                //  regressionSeries.Points.AddXY(minx, m * minx + c);  //Adds the smallest point
                //  regressionSeries.Points.AddXY(maxx, m * maxx + c);  //Adds the largest point

                //  chart1.Series.Add(regressionSeries); //Plots the regression line

                //Plots a straight line between the points

                Series bestSeries = new Series($"Degree {bestDegree}");
                bestSeries.ChartType = SeriesChartType.Line;
                bestSeries.BorderWidth = 2;
                bestSeries.Color = Color.Black;

                double minX = _points.Min(p => p.X);
                double maxX = _points.Max(p => p.X);

                int steps = 150;
                double stepSize = (maxX - minX) / steps;

                for (double x = minX; x <= maxX; x += stepSize)
                {
                    double y = 0;
                    for (int i = 0; i < bestCoeffs.Length; i++)
                        y += bestCoeffs[i] * Math.Pow(x, i);

                    bestSeries.Points.AddXY(x, y);
                }

                graph.Series.Add(bestSeries);
                

                

                area.AxisX.Minimum = Math.Floor(_points.Min(p => p.X));
                area.AxisX.Maximum = Math.Ceiling(_points.Max(p => p.X));

              //  area.AxisX.Interval = 5;
               // area.AxisX.LabelStyle.Format = "0";

                MessageBox.Show($"Best model: Degree {bestDegree}\nR² = {bestR2:F4}");
            }
        }

        private void PlotQuadraticGraph()
        {
            graph.Series.Clear(); //Clears the chart because it already loads with stuff

            Series quadSeries = new Series("X vs Y");//Creates a new series instance of the series class which represents a quadratic curve
            quadSeries.ChartType = SeriesChartType.Line;//Creates a line graph instead of the default bar chart
            quadSeries.BorderWidth = 2;//Determines the width of the line generated
            quadSeries.Color = Color.Black;//Sets the colour of the line to black

            Series dataSeries = new Series("Data"); //This is to display the points
            dataSeries.ChartType = SeriesChartType.Point;
            dataSeries.MarkerStyle = MarkerStyle.Circle; //Displayed as circles
            dataSeries.MarkerSize = 10; //Originally size 10
            dataSeries.MarkerColor = Color.Red; //Sets the colour as red

            foreach (var p in _points)
            {
                int index = dataSeries.Points.AddXY(p.X, p.Y); //Adds each point to the series
            }


            var (a, b, c) = QuadraticRegression(_points); //Outputs the values for the coefficients of the curve

            double minX = _points.Min(p => p.X); //Stores the minimum x value in the inputted user data
            double maxX = _points.Max(p => p.X); //Stores the maximum x value in the inputted user data

            int steps = 1000; // smooth curve
            double stepSize = (maxX - minX) / steps; //The interval between each x-point

            for (double x = minX; x <= maxX; x += stepSize)
            {
                double y = a * x * x + b * x + c; //Calculated y value of the point
                quadSeries.Points.AddXY(x, y); //Adding each point to the quadratic series
            }

            graph.Series.Add(quadSeries);//Adds the quadratic curve to the graph
            graph.Series.Add(dataSeries); //Adds the data points to the graph

            var area = graph.ChartAreas[0]; //Stores the properties of the area of the graph
            area.AxisX.Title = "X"; //Names the x-axis
            area.AxisY.Title = "Y"; //Names the y-axis
            area.AxisX.MajorGrid.Enabled = false; //Removes the x-axis gridline
            area.AxisY.MajorGrid.Enabled = false; //Removes the y-axis gridlines

        }


        private (double a, double b, double c) Solve3x3(double[,] m, double[] c) //Method used Cramer's rule to output the coefficients of a quadratic curve
        {//The matrix is passed in as a 2d array and the constants a 1d array
            double det =
                m[0, 0] * (m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1]) - //Finds the determinant of the  normal matrix
                m[0, 1] * (m[1, 0] * m[2, 2] - m[1, 2] * m[2, 0]) + //This is then used to divide the determinants of the other matrix
                m[0, 2] * (m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0]);

            // if y = ax^2 +bx + c

            double detA =
               m[0, 0] * (m[1, 1] * c[2] - c[1] * m[2, 1]) -  //Finds the determinant of the matrix needed calculate the a coefficient
               m[0, 1] * (m[1, 0] * c[2] - c[1] * m[2, 0]) + //The first column of this matrix is swapped with the values of the constants
               c[0] * (m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0]);

            double detB =
                m[0, 0] * (c[1] * m[2, 2] - m[1, 2] * c[2]) - //Finds the determinant of the matrix needed calculate the b coefficient
                c[0] * (m[1, 0] * m[2, 2] - m[1, 2] * m[2, 0]) + //The second column of this matrix is swapped with the values of the constants
                m[0, 2] * (m[1, 0] * c[2] - c[1] * m[2, 0]);

            double detC =
                c[0] * (m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1]) - //Finds the determinant of the matrix needed to calculate the intercept 
                m[0, 1] * (c[1] * m[2, 2] - m[1, 2] * c[2]) + //The third column of this matrix is swapped with the values of the constants
                m[0, 2] * (c[1] * m[2, 1] - m[1, 1] * c[2]);

            return (detA / det, detB / det, detC / det);

            // returns a, b and c
        }

        private (double a, double b, double c) QuadraticRegression(List<DataPointXY> points)
        {

            int n = points.Count; //Stores the total number of points in the list
            double sumX = 0, sumX2 = 0, sumX3 = 0, sumX4 = 0;//Every summation needed to form the 3x3 matrix
            double sumY = 0, sumXY = 0, sumX2Y = 0; //all initially set to 0

            foreach (var p in points)
            {
                double x = p.X; //Stores the x value of the point
                double y = p.Y; //Stores the y values of the point
                double x2 = x * x; //Stores x squared value

                sumX += x; //Finds the sum of the x value
                sumX2 += x2;//Finds the sum of the x squared value
                sumX3 += x2 * x; //Finds the sum of the x cubed value
                sumX4 += x2 * x2;//Finds the sum of the x to the power of 4
                sumY += y; //Finds the sum of the y value
                sumXY += x * y;//Finds the sum of the x * y value
                sumX2Y += x2 * y;//Finds the sum of the x squared * y value
            }

            // 2d array is used to represent the matrix
            double[,] matrix =
            {{ n,     sumX,   sumX2 }, //Each value is put into the correct place to represent
             { sumX,  sumX2,  sumX3 }, // the system of 3 simultaneous equations
             { sumX2, sumX3,  sumX4 }};

            double[] constants = { sumY, sumXY, sumX2Y };//Created an array of constants needed for Cramer's rule

            return Solve3x3(matrix, constants); //Solve3x3 matrix uses Cramer's rule
        }

        private double[] PolynomialRegression(List<DataPointXY> points, int degree)
        {
            int n = degree + 1;
            double[,] matrix = new double[n, n];
            double[] constants = new double[n];

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = points.Sum(p => Math.Pow(p.X, row + col));
                }

                constants[row] = points.Sum(p => p.Y * Math.Pow(p.X, row));
            }

            return GaussianElimination(matrix, constants);
        }

        private double[] GaussianElimination(double[,] A, double[] b)
        {
            int n = b.Length;

            for (int i = 0; i < n; i++)
            {
                // Pivot
                double diag = A[i, i];
                for (int j = 0; j < n; j++)
                    A[i, j] /= diag;

                b[i] /= diag;

                // Eliminate
                for (int k = 0; k < n; k++)
                {
                    if (k == i) continue;

                    double factor = A[k, i];

                    for (int j = 0; j < n; j++)
                        A[k, j] -= factor * A[i, j];

                    b[k] -= factor * b[i];
                }
            }

            return b;
        }

        private double CalculateRSquared(List<DataPointXY> points, double[] coeffs)
        {
            double meanY = points.Average(p => p.Y);

            double ssTot = 0;
            double ssRes = 0;

            foreach (var p in points)
            {
                double predicted = 0;
                for (int i = 0; i < coeffs.Length; i++)
                    predicted += coeffs[i] * Math.Pow(p.X, i);

                ssTot += Math.Pow(p.Y - meanY, 2);
                ssRes += Math.Pow(p.Y - predicted, 2);
            }

            return 1 - (ssRes / ssTot);
        }



    }



}

