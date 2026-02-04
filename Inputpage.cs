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
            var points = new List<DataPointXY>();

            foreach (System.Windows.Forms.DataGridViewRow row in dataInputGrid.Rows)
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

        private void DinputHbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            first_page Home_page = new first_page();
            Home_page.Show();
        }

        private void DataInput_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;

            foreach (Control c in this.Controls)
            {
                controlBounds[c] = new Rectangle(c.Location, c.Size);
            }

            ready = true;
            dataInputGrid.CausesValidation = false;

        }

        private void restartbtn_Click(object sender, EventArgs e) //When the user presses this all the values in the grid are deleted
        {
            dataInputGrid.CausesValidation = false;
            restartbtn.CausesValidation = false;


            is_clearing = true;
            dataInputGrid.EndEdit();
            dataInputGrid.Rows.Clear();
            is_clearing = false;
            
        }

        private void dataInputGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) //This function is a validation check to ensure numbers inputed are in exponential or normal form
        {
            

            string value = e.FormattedValue.ToString();

            if (is_clearing == true) { return; }

            if (string.IsNullOrEmpty(value)) { return; }

             
            if (!double.TryParse(e.FormattedValue.ToString(), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out _))
            {
                    MessageBox.Show("Please enter a valid number (including exponential notation)");
                    e.Cancel = true;
            }
            
        
        }

        private void genstatsButton_Click(object sender, EventArgs e)
        {
            var pts = GetPoints();
            if (pts.Count == 0) { MessageBox.Show("No Valid Points"); return; }
            double avgx = pts.Average(x => x.X);
            double avgy = pts.Average(y => y.Y);
            double maxx = pts.Max(x => x.X);
            double minx = pts.Min(x => x.X);
            double maxy = pts.Max(y => y.Y);
            double miny = pts.Min(y => y.Y);

            MessageBox.Show($"Average X = {avgx}\nAverage Y = {avgy}\nMax X = {maxx} Min X = {minx}\nMax Y = {maxy} Min Y = {miny}");

            // Standard deviation, Variance


        }

        private void GenGButton_Click(object sender, EventArgs e)
        {
            
            var points = GetPoints();
            if (points.Count == 0)
            {
                MessageBox.Show("No Valid points to generate a graph");   
                return; 
            
            }

            int n = points.Count;
            double[] xvalues = new double[n];
            double[] yvalues = new double[n];           
            double sumx = points.Sum(x => x.X);
            double sumy = points.Sum(y => y.Y);
            double sumxy = 0;
            double sumx2 = 0;
            for (int i = 0; i < n; i++)
            {
                sumx2 += points[i].X * points[i].X;
                sumxy += points[i].X * points[i].Y;

            }

            Console.WriteLine(sumxy + " " + sumx2);

        }
    }
    
}
