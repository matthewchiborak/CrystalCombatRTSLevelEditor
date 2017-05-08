using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HCIDrawingAssignment
{
    class CircleShape : ShapeGraphic
    {
        public CircleShape(Color selectedColour, Point selectedPosition)
        {
            shapeColour = selectedColour;
            canvasPosition = selectedPosition;
            type = "Circle";
        }

        public CircleShape(Color selectedColour, Point passedStartPoint, Point passedEndPoint)
        {
            shapeColour = selectedColour;
            type = "Circle";
            startPoint = passedStartPoint;
            endPoint = passedEndPoint;
        }
    }
}
