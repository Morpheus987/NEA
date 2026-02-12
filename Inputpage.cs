using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA
{
    public partial class DataInput : Form
    {
        private bool is_clearing = false;
        Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>(); // This dictionary stores a visual element of the form from the control class as the key and it's size in the rectangle data type
        Size originalFormSize; // This variable stores the height and width of the form size in it's orignal form
        bool ready = true; // This variable is there to ensure that the first page resize function occurs before the first page load function
        
        public DataInput()
        {
            InitializeComponent();
        }

        public List<DataPointXY> GetPoints()  //Retrieves the data from the datagrid in the input page
        {
            var points = new List<DataPointXY>(); // Creates a list which stores type 'DataPointXY' a created class

            foreach (System.Windows.Forms.DataGridViewRow row in dataInputGrid.Rows) //For loops iterates through every row
            {
                if (row.IsNewRow) continue; //If the row has nothing in it this if statement ignores it

                if (double.TryParse(row.Cells["Independent"].Value?.ToString(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture,  out double x)
                    && double.TryParse(row.Cells["Dependent"].Value?.ToString(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double y))
                {// Converts the string input value by the user into the double data type
                    points.Add(new DataPointXY { X = x, Y = y });
                    
                    // Stores it the DataPointXY type so it can be analysed
                }

            }

            return points;

        }

        private void DataInput_Resize(object sender, EventArgs e)
        {
            if (!ready) return; //This fixes the error caused by the order being wrong permanently 

            float xRatio = (float)this.Width / originalFormSize.Width; // Find the ratio of how much the width of the form has changed
            float yRatio = (float)this.Height / originalFormSize.Height; // Finds the ratio on how much the height of the form has changed

            foreach (Control c in this.Controls) //Gets all the features of the form
            {
                Rectangle r = controlBounds[c];
                c.Location = new Point((int)(r.X * xRatio), (int)(r.Y * yRatio)); // Changes the upper left corner of a tool/features of the form relative to how much the upper left corner has changed
                c.Size = new Size((int)(r.Width * xRatio), (int)(r.Height * yRatio)); //Changes the width and height relative to how much the form has changed
            }
        }

        private void DinputHbutton_Click(object sender, EventArgs e) // Home navigation button
        {
            this.Hide(); // Hides the form which is currently open
            first_page Home_page = new first_page(); // Creates a new instance of the first page
            Home_page.Show(); // Shows this new instance
        }

        private void DataInput_Load(object sender, EventArgs e) 
        {
            originalFormSize = this.Size;

            foreach (Control c in this.Controls)
            {
                controlBounds[c] = new Rectangle(c.Location, c.Size);
            }

            ready = true;
            dataInputGrid.CausesValidation = false; //Ensures that the validation event doesn't occur as the page is loaded so a stack overflow error doesn't occur
            var testdata = new List<DataPointXY>();
            for (int i = 1; i < 5; i++)
            {
                int y = 2 * i;
                testdata.Add(new DataPointXY {X = i, Y = y});
            }
            foreach (var p in testdata)
            {
                dataInputGrid.Rows.Add(p.X, p.Y);
            }
            
            

        }

        private void restartbtn_Click(object sender, EventArgs e) //When the user presses this all the values in the grid are deleted
        {
            dataInputGrid.CausesValidation = false; // Stops this validation from happening
            restartbtn.CausesValidation = false; // Stops this also


            is_clearing = true; // Checker variable used with the validation event to ensure it doesn't happen when the restart button is clicked
            dataInputGrid.EndEdit(); // Ends any other operation happening on the grid
            dataInputGrid.Rows.Clear(); // Clears all the rows in the grid after the button is pressed
            is_clearing = false; // Once the restart button clears the contents of the grid validation can continue
            
        }

        private void dataInputGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) //This function is a validation check to ensure numbers inputed are in exponential or normal form
        {
            

            string value = e.FormattedValue.ToString(); // Stores the value that needs to be validated in this variable

            if (is_clearing == true) { return; } //If the restart button occurs the event doesn't

            if (string.IsNullOrEmpty(value)) { return; } // If there is nothing in the grpah return

             
            if (!double.TryParse(e.FormattedValue.ToString(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out _))
            {
                    MessageBox.Show("Please enter a valid number (including exponential notation)"); // If numbers are not inputted into exponential format then this message appears
                    e.Cancel = true; // Cancels the cell validating event after the message is produced
            }
            
        
        }

        private void genstatsButton_Click(object sender, EventArgs e)
        {
            var pts = GetPoints(); // Uses the get points method to read the data
            if (pts.Count == 0) { MessageBox.Show("No Valid Points"); return; } // If no points are entered than the message appears
            double avgx = pts.Average(x => x.X); //Finds the mean of the x values
            double avgy = pts.Average(y => y.Y); //Finds the mean of the y values
            double maxx = pts.Max(x => x.X); // Finds the maximum x value
            double minx = pts.Min(x => x.X); // Finds the minimum x value
            double maxy = pts.Max(y => y.Y); // Finds the maximum y value
            double miny = pts.Min(y => y.Y); // Finds the minimum y value

            MessageBox.Show($"Average X = {avgx}\nAverage Y = {avgy}\nMax X = {maxx} Min X = {minx}\nMax Y = {maxy} Min Y = {miny}");

            // Displays all the results


        }

        private void GenGButton_Click(object sender, EventArgs e)
        {
            var pts = GetPoints();
            List<double> xValues = new List<double>(); // Creates a list of x values
            List<double> yValues = new List<double>(); // Crreates a list of y values

            // if (pts.Count == 0) { MessageBox.Show("Can't Generate Graph no Valid Points"); return; }

            foreach (DataPointXY point in pts)
            {
                xValues.Add(point.X); // Adds each x point to the list
                yValues.Add(point.Y); // Adds each y point to the list
            }


            if (xValues.Count >= 2) // If there is a sufficent amount of points a graph is generated 
            {
                GraphForm graphForm = new GraphForm(xValues, yValues); // A new instance of the graph form is created
                graphForm.Show(); // It is then shown 
            }

            else
            {
                MessageBox.Show("Please enter at least 2 datapoints"); // Must enter at least 2 datapoints for the graph to be generated
            }




        }

        
    }
    
}
