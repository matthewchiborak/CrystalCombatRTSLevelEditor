using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HCIDrawingAssignment
{
    class FreehandShape : ShapeGraphic
    {
        public FreehandShape(Color selectedColour, List<LineShape> passedFreehandLineList)
        {
            shapeColour = selectedColour;
            freehandLineList = passedFreehandLineList;
            type = "Freehand";

            //Found the bounding rect of the shape
            bool isFirst = true;
            foreach(var myLine in passedFreehandLineList)
            {
                if (isFirst)
                {
                    startPoint.X = myLine.getStartPoint().X;
                    startPoint.Y = myLine.getStartPoint().Y;
                    endPoint.X = myLine.getStartPoint().X;
                    endPoint.Y = myLine.getStartPoint().Y;
                    isFirst = false;
                }
                else
                {
                    if(myLine.getStartPoint().X < startPoint.X)
                    {
                        startPoint.X = myLine.getStartPoint().X;
                    }
                    if (myLine.getStartPoint().Y < startPoint.Y)
                    {
                        startPoint.Y = myLine.getStartPoint().Y;
                    }
                    if (myLine.getEndPoint().X > endPoint.X)
                    {
                        endPoint.X = myLine.getEndPoint().X;
                    }
                    if (myLine.getEndPoint().Y > endPoint.Y)
                    {
                        endPoint.Y = myLine.getEndPoint().Y;
                    }
                }
            }
        }
    }
}
