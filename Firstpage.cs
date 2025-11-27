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
        Size originalFormSize;
        bool ready = false;


        public first_page()
        {
            InitializeComponent();
   
            
        }


        private void helpbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserGuide guide = new UserGuide();
            guide.Show();
        }

        private void first_page_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;

            foreach (Control c in this.Controls)
            {
                controlBounds[c] = new Rectangle(c.Location, c.Size);
            }

            ready = true;
        }

        private void first_page_Resize(object sender, EventArgs e)
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

