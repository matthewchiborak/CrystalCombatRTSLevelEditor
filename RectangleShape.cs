using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HCIDrawingAssignment
{
    class RectangleShape : ShapeGraphic
    {
        public RectangleShape(Color selectedColour, Point selectedPosition)
        {
            shapeColour = selectedColour;
            canvasPosition = selectedPosition;
            type = "Rectangle";
        }

        public RectangleShape(Color selectedColour, Point passedStartPoint, Point passedEndPoint)
        {
            shapeColour = selectedColour;
            type = "Rectangle";
            startPoint = passedStartPoint;
            endPoint = passedEndPoint;

        }
    }
}
