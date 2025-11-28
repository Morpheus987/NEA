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

        Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>(); // This dictionary stores a visual element of the form from the control class as the key and it's size in the rectangle data type
        Size originalFormSize; // This variable stores the height and width of the form size in it's orignal form
        bool ready = false; // This variable is there to ensure that the first page resize function occurs before the first page load function

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

                if (double.TryParse(row.Cells["Independent"].Value?.ToString(), out double x) && double.TryParse(row.Cells["Dependent"].Value?.ToString(), out double y))
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
        }
    }
}
