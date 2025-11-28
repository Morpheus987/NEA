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
        public DataInput()
        {
            InitializeComponent();
        }

        public List<DataPointXY> GetPoints()
        {
            var points = new List<DataPointXY>();

            foreach (System.Windows.Forms.DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;


            }

        }
    }
}
