using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HCIDrawingAssignment
{
    class SquareShape : ShapeGraphic
    {
        public SquareShape(Color selectedColour, Point selectedPosition)
        {
            shapeColour = selectedColour;
            canvasPosition = selectedPosition;
            type = "Square";
        }

        public SquareShape(Color selectedColour, Point passedStartPoint, Point passedEndPoint)
        {
            shapeColour = selectedColour;
            type = "Square";
            startPoint = passedStartPoint;
            endPoint = passedEndPoint;
            childShapeGraphic = null;
            parentShapeGraphic = null;
            copyId = -1;
        }
    }
}
