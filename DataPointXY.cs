using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NEA
{
    public class DataPointXY
    {
        public double X { get; set; } // Getters and setters for the x values
        public double Y { get; set; } // Getters and setters for the y values

        public List<PointF> datapoints; // point F types represents a pair of floating point
                                        // x and y corrdinates 

    }   

}
