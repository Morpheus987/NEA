using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace NEA
{
    public partial class Graph : Form // Inherits from data input
    {
        private List<DataPointXY> _points;

        public Graph(List<DataPointXY> points)
        {
            InitializeComponent();
            _points = points;
             

            this.DoubleBuffered = true;

        }

        private void Graph_Load(object sender, EventArgs e)
        {
            
        }

        
        private void PlotGraph()
        {
            
        }
        


    }
}
