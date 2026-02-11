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
    public partial class UserGuide : Form
    {
        public UserGuide()
        {
            InitializeComponent();
        }

        Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>(); // 
        Size originalFormSize; // Stores the size of the form
        bool ready = false;
        // This dictionary stores a visual element of the form
        // from the control class as the key and it's size in the rectangle data type

        private void hmbtn_ug_Click(object sender, EventArgs e) // This is the code to navigate back to the home page
        {
            this.Hide(); // It hides the form which is currently open
            first_page first_Page = new first_page(); // This creates a new instance of the first page
            first_Page.Show(); // This new instance is shown
        }

        private void UserGuide_Load(object sender, EventArgs e)  // Load event contains the same code as the home page
        {
            originalFormSize = this.Size;  // Variable stores the size of the form same as the first_page instance of the size

            foreach (Control c in this.Controls)
            {
                controlBounds[c] = new Rectangle(c.Location, c.Size); // Array stores the location and size in the Rectangle data type of each control in the form
            }

            ready = true; // Checker variable exactly the same as the first page 
        }

        private void UserGuide_Resize(object sender, EventArgs e)
        {
            if (!ready) return; // Makes sure the load event occurs before the resize event to prevent a stack overflow error

            float xRatio = (float)this.Width / originalFormSize.Width; // Stores the multiplier of the change in the width of the form
            float yRatio = (float)this.Height / originalFormSize.Height; // Stores the multiplier of the change in the height of the form

            foreach (Control c in this.Controls)   //Loops through all the components in the form
            {
                Rectangle r = controlBounds[c]; 
                c.Location = new Point((int)(r.X * xRatio), (int)(r.Y * yRatio)); // Changes the height and width of each component of the form proportional to the size of the form
                c.Size = new Size((int)(r.Width * xRatio), ( int)(r.Height * yRatio));
            }

        }
    }
}
