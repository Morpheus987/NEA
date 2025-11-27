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

        Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>();
        Size originalFormSize;
        bool ready = false;

        private void hmbtn_ug_Click(object sender, EventArgs e)
        {
            this.Hide();
            first_page first_Page = new first_page();
            first_Page.Show();
        }

        private void UserGuide_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;

            foreach (Control c in this.Controls)
            {
                controlBounds[c] = new Rectangle(c.Location, c.Size);
            }

            ready = true;
        }

        private void UserGuide_Resize(object sender, EventArgs e)
        {
            if (!ready) return;

            float xRatio = (float)this.Width / originalFormSize.Width;
            float yRatio = (float)this.Height / originalFormSize.Height;

            foreach (Control c in this.Controls)
            {
                Rectangle r = controlBounds[c];
                c.Location = new Point((int)(r.X * xRatio), (int)(r.Y * yRatio));
                c.Size = new Size((int)(r.Width * xRatio), ( int)(r.Height * yRatio));
            }

        }
    }
}
