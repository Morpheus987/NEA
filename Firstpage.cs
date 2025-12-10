using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NEA
{
    public partial class first_page : Form
    {

        Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>(); 
        // This dictionary stores a visual element of the form
       // from the control class as the key and it's size in the rectangle data type
        Size originalFormSize; 
        // This variable stores the height and width of the form size in it's orignal form
        bool ready = false; 
        // This variable is there to ensure that the first page resize function occurs before the first page load function


        public first_page()
        {
            InitializeComponent();
   
            
        }


        private void helpbutton_Click(object sender, EventArgs e)
        {
            this.Hide();  //When the help button is clicked in the first page this line hides the help form from the user
            UserGuide guide = new UserGuide(); // A new instance of the userguide is created
            guide.Show(); // this new instance is then displayed to the user
        }

        private void first_page_Load(object sender, EventArgs e) // When the load function occurs the size of each element within the form is resized proportional to it
        {
            originalFormSize = this.Size; 

            foreach (Control c in this.Controls) // Loops through each element in the form 
            {
                controlBounds[c] = new Rectangle(c.Location, c.Size); // Each element is then resized proportional to the form
            }

            ready = true; // This is a checker variable to ensure that the load function occurs before the resize function so a stack overflow error doesn't occur
        }

        private void first_page_Resize(object sender, EventArgs e) // This function resizes all the features of the form relative to it when it is maximised by the user
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

        private void Welcm_btn_Click(object sender, EventArgs e) // This button takes the user to the data input page
        {
            this.Hide(); // When the button is clicked this instance of the form is hidden
            DataInput dataInput = new DataInput(); // A new instance of the data input form is created
            dataInput.Show(); // This new instance is then shown to the user
        }
    }
}

