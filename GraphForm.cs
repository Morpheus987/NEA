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
            PlotGraph(); // A graph is generated
            
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
            comboEditOptions.Items.Add("Change X Axis Title"); //Adds the ability to change the x-axis name
            comboEditOptions.Items.Add("Change Y Axis Title"); //Adds the ability to change the y-axis name
            comboEditOptions.Items.Add("Change Background Colour"); //Adds the ability to change the background colour
            comboEditOptions.Items.Add("Change Regression Line Colour"); //Adds the ability to change the line of best fit colour
            comboEditOptions.Items.Add("Change Point Colour"); //Adds the ability to change the colour of the point

            comboEditOptions.SelectedIndex = 0; //Defaults to showing the first option

        }


        private void chart1_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            var hit = graph.HitTest(e.X, e.Y); //Determines if there is an element of the chart where the cursor is

            if (hit.PointIndex >= 0 && hit.Series != null) //PointIndex represents the index of the datapoint
            {
                double x = hit.Series.Points[hit.PointIndex].XValue; //Retrieves the x value of the point
                double y = hit.Series.Points[hit.PointIndex].YValues[0];//Retrieves the y value of the point

                e.Text = $"X = {x:F2}\nY = {y:F2}"; //Displays the x and y coordinate if the cursor is hovering above
            }
        }

        private void btnapplyedit_Click(object sender, EventArgs e) //When the apply edit button is pressed
        {
            string selectedOption = comboEditOptions.SelectedItem.ToString(); //Stores the option of the combo box currently selected

            switch (selectedOption) // I used a switch case for each option in the combo box
            {
                case "Change X Axis Title":
                    graph.ChartAreas[0].AxisX.Title = txtAxisName.Text; // The name of the axis is changed to the text in the textbox
                    break; 

                case "Change Y Axis Title":
                    graph.ChartAreas[0].AxisY.Title = txtAxisName.Text; // The name of the axis is changed to the text in the textbox
                    break;

                case "Change Background Colour":
                    if (colourChange.ShowDialog() == DialogResult.OK)
                    {
                        graph.ChartAreas[0].BackColor = colourChange.Color; //Changes the background colour of the graph
                    }  // Opens a colour dialog which is just a selectiion of colours the user can select
                    break;

                case "Change Regression Line Colour":
                    if (colourChange.ShowDialog() == DialogResult.OK)
                    {
                        graph.Series["X vs Y"].Color = colourChange.Color; //The regression line colour is changed
                    }
                    break;
                case "Change Point Colour":
                    if (colourChange.ShowDialog() == DialogResult.OK)
                    {
                        graph.Series["Data"].MarkerColor = colourChange.Color;//The colours of the data points are changed
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
            int maxDegree = 4; // linear, quadratic, cubic and quartic

            double bestR2 = double.MinValue; //Initally the r squared value is set to the smallest value because nothing is smaller
            double[] bestCoeffs = null; //An array storing the coefficients of the model which are going to be used
            int bestDegree = 1; //Set the best degree to 1 a linear graph you can't go any lower

            for (int d = 1; d <= maxDegree; d++) //Iterates through each degree of polynomial until a quartic
            {
                var coeffs = PolynomialRegression(_points, d); //Evalues what the coefficients of the model for the line of best fit would be
                double r2 = CalculateRSquared(_points, coeffs); //Evalutes what the R Squared value is

                if (r2 > bestR2) //if R squared is greater than the best so far
                {
                    bestR2 = r2; //This R Squared value is updated for comparisons for other models
                    bestCoeffs = coeffs; //The coefficients for the most appropriate model for the line of best fit is stored
                    bestDegree = d; //Stores the value of the degree of polynomial for the most appropriate line of best fit
                }
            }

            graph.Series.Clear(); //Clears the chart because it already loads with stuff

            Series Series = new Series("X vs Y");//Creates a new instance of the series class called X vs Y 
            Series.ChartType = SeriesChartType.Line; //Creates a line graph instead of the default bar chart
            Series.BorderWidth = 2; //Sets the width of the line generated
            Series.Color = Color.Black;//Sets the intial colour of the line to black to differentiate from the points
            double minX = _points.Min(p => p.X); //Stores the minimum x value in the inputted user data
            double maxX = _points.Max(p => p.X); //Stores the maximum x value in the inputted user data

            Series dataSeries = new Series("Data"); //This is to display the points
            dataSeries.ChartType = SeriesChartType.Point;
            dataSeries.MarkerStyle = MarkerStyle.Circle; //Displayed as circles
            dataSeries.MarkerSize = 10; //Originally size 10
            dataSeries.MarkerColor = Color.Red; //Sets the colour as red

            int steps = 1000;// Generates a smooth curve
            double stepSize = (maxX - minX) / steps; //Stores the interval between each x point

            for (double x = minX; x <= maxX; x += stepSize) 
            {
                double y = 0; //Will store the value of the corresponding y value
                for (int i = 0; i < bestCoeffs.Length; i++)
                {
                    y += bestCoeffs[i] * Math.Pow(x, i);
                    //Calculates the y value of the point similar to the way used in the R Squared method
                }

                Series.Points.AddXY(x, y); //Adds the point to the series of the line of best fit
            }

            foreach (var p in _points) //Iterates through the user inputted data
            {
                int index = dataSeries.Points.AddXY(p.X, p.Y); //Adds each point to the series
                dataSeries.Points[index].ToolTip = $"X = {p.X:F2}\nY = {p.Y:F2}"; //Adds the tool tip to each point
            }

            graph.Series.Add(Series); //Adds the line to the chart
            graph.Series.Add(dataSeries);//Adds the points to the chart

            var area = graph.ChartAreas[0];//Stores the properties of the area of the graph
            area.AxisX.Title = "X"; //Names the x-axis
            area.AxisY.Title = "Y"; //Names the y-axis
            area.AxisX.MajorGrid.Enabled = false; //Removes the x-axis gridline
            area.AxisY.MajorGrid.Enabled = false; //Removes the y-axis gridlines

            MessageBox.Show($"Best model: Degree {bestDegree}\nR² = {bestR2:F4}"); 
            //Outputs a message box of the degree of polynomial of the lines of best fit and the R Squared value 

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
            int n = degree + 1; //Sets up the degree of the polynomial + 1 simultaneous equations
            double[,] matrix = new double[n, n]; //Uses a 2d array of type double to represent the matrix
            double[] constants = new double[n]; //Uses a normal array to set up the constants

            for (int row = 0; row < n; row++) //Iterates through each row of the matrix
            {
                for (int col = 0; col < n; col++) //Iterates through each column of the matrix
                {
                    matrix[row, col] = points.Sum(p => Math.Pow(p.X, row + col));  //Stores the sum of ∑x^row + column
                }// Adds the appropriate summation of the x values in the right place of the matrix
                //EG: The upper left corner will store the sum of ∑x^0 the position to the right will store ∑x^1


                constants[row] = points.Sum(p => p.Y * Math.Pow(p.X, row)); //Stores the sum of ∑y * x^row
                //Sets up the constants 
                //EF
            }

            return GaussianElimination(matrix, constants);
            //Sets up the matrix and array of constants needed for the Gauss-Jord elimination method
        }

        private double[] GaussianElimination(double[,] A, double[] b)
        {
            // A = coefficient matrix
            // b = constants vector
            // Solves Ax = b using Gauss-Jordan elimination
            int n = b.Length; // Number of unknowns (matrix size)

            for (int i = 0; i < n; i++)
            {
                // The diagonal element A[i,i] is the pivot.
                // We divide the entire row by the pivot value
                // so that the pivot becomes 1.
                double diag = A[i, i];
                for (int j = 0; j < n; j++)
                    A[i, j] /= diag; // Scale entire row

                b[i] /= diag; // Scale corresponding constant

                // Make all other values in column i equal to 0.
                // This transforms the matrix into reduced row echelon form.
                for (int k = 0; k < n; k++)
                {
                    if (k == i) continue;  // Skip the pivot row

                    double factor = A[k, i];
                    // Subtract factor × pivot row from current row
                    for (int j = 0; j < n; j++)
                        A[k, j] -= factor * A[i, j];
                    // Apply same transformation to constants vector
                    b[k] -= factor * b[i];
                }
            }
            // At this point:
            // Matrix A has become the identity matrix
            // Vector b now contains the solution

            return b; // These are the regression coefficients
        }


        private double CalculateRSquared(List<DataPointXY> points, double[] coeffs)
        {
            //the datapoints is passed as an argument
            //the array of coefficients of the predicted model is passed in as an argument
            double meanY = points.Average(p => p.Y); //Finds the mean of the y values

            double ssTot = 0; //Stores the total variation
            double ssRes = 0; //Stores the unexpected variation

            foreach (var p in points) //Iterates through every point in the user entered data
            {
                double predicted = 0; //Stores the model's y value
                for (int i = 0; i < coeffs.Length; i++)  
                {
                    // If y = ax^3 + bx^2 + cx + d the coeffs array would be {d, c, b, a}
                    predicted += coeffs[i] * Math.Pow(p.X, i);
                    //Raises the x value to the appropriate power and multiplies it by the correct coefficient
                }

                ssTot += Math.Pow(p.Y - meanY, 2); //Finds the difference between the actual y value and mean and squares it
                ssRes += Math.Pow(p.Y - predicted, 2);//Finds the difference between the actual y value and the models y value and squares it
            }

            return 1 - (ssRes / ssTot); //Finds and outputs the R Squared value
        }



    }



}

