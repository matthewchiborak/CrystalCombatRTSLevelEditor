using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HCIDrawingAssignment
{
    class EllipseShape : ShapeGraphic
    {
        public EllipseShape(Color selectedColour, Point selectedPosition)
        {
            shapeColour = selectedColour;
            canvasPosition = selectedPosition;
            type = "Ellipse";
        }

        public EllipseShape(Color selectedColour, Point passedStartPoint, Point passedEndPoint)
        {
            shapeColour = selectedColour;
            type = "Ellipse";
            startPoint = passedStartPoint;
            endPoint = passedEndPoint;
        }
    }
}
