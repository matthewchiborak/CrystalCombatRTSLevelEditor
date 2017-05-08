using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HCIDrawingAssignment
{
    class LineShape : ShapeGraphic
    {

        public LineShape(Color selectedColour, Point passedStartPoint, Point passedEndPoint)
        {
            shapeColour = selectedColour;
            type = "Line";
            startPoint = passedStartPoint;
            endPoint = passedEndPoint;
        }
    }
}
