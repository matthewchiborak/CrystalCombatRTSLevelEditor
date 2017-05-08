using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HCIDrawingAssignment
{
    class ShapeGraphic
    {
        protected Color shapeColour;
        protected Point canvasPosition;
        protected ShapeGraphic childShapeGraphic;
        protected ShapeGraphic parentShapeGraphic;
        protected string type;
        public Point startPoint;
        public Point endPoint;
        public List<LineShape> freehandLineList;
        protected int copyId;
        protected int id;

        public ShapeGraphic()
        {
            childShapeGraphic = null;
            parentShapeGraphic = null;
            copyId = -1;
        }

        public ShapeGraphic(Color selectedColour, Point selectedPosition)
        {
            shapeColour = selectedColour;
            canvasPosition = selectedPosition;
            childShapeGraphic = null;
            parentShapeGraphic = null;
            copyId = -1;
        }

        public void setType(int index)
        {
            id = index;
        }

        public int getType()
        {
            return id;
        }

        public void assignId(int givenId)
        {
            copyId = givenId;
        }
        public int getId()
        {
            return copyId;
        }

        public List<LineShape> getFreehandLineList()
        {
            return freehandLineList;
        }
        public string getShapeType()
        {
            return type;
        }

        public Point getStartPoint()
        {
            return startPoint;
        }
        public Point getEndPoint()
        {
            return endPoint;
        }
        public Color getShapeColor()
        {
            return shapeColour;
        }

        //Move the shape to the specified location
        public void moveToHere(Point location)
        {
            Point displacement = new Point(location.X - startPoint.X, location.Y - startPoint.Y);
            endPoint.X = (endPoint.X - startPoint.X) + location.X;
            endPoint.Y = (endPoint.Y - startPoint.Y) + location.Y;
            startPoint.X = location.X;
            startPoint.Y = location.Y;
            if (childShapeGraphic != null)
            {
                childShapeGraphic.moveChild(displacement);
            }
            if (parentShapeGraphic != null)
            {
                parentShapeGraphic.moveParent(displacement);
            }
        }

        //Recursively move all the children in a chain based on a current displacement
        public void moveChild(Point displacement)
        {
            if (type == "Polygon" || type == "Freehand")
            {
                foreach (var myLine in freehandLineList)
                {
                    myLine.translate(displacement);
                }
                startPoint.X = startPoint.X + displacement.X;
                startPoint.Y = startPoint.Y + displacement.Y;
                endPoint.X = endPoint.X + displacement.X;
                endPoint.Y = endPoint.Y + displacement.Y;
            }
            else
            {
                translate(displacement);
            }
            if(childShapeGraphic != null)
            {
                childShapeGraphic.moveChild(displacement);
            }
        }
        //Do the same for the parents as did the children above
        public void moveParent(Point displacement)
        {
            if (type == "Polygon" || type == "Freehand")
            {
                foreach (var myLine in freehandLineList)
                {
                    myLine.translate(displacement);
                }
                startPoint.X = startPoint.X + displacement.X;
                startPoint.Y = startPoint.Y + displacement.Y;
                endPoint.X = endPoint.X + displacement.X;
                endPoint.Y = endPoint.Y + displacement.Y;
            }
            else
            {
                translate(displacement);
            }
            if (parentShapeGraphic != null)
            {
                parentShapeGraphic.moveParent(displacement);
            }
        }
        //Translate a shape a specified amount
        public void translate(Point displacement)
        {
            startPoint.X = startPoint.X + displacement.X; 
            startPoint.Y = startPoint.Y + displacement.Y;
            endPoint.X = endPoint.X + displacement.X;
            endPoint.Y = endPoint.Y + displacement.Y;
        }

        //Move a polygon or freehand shape to a specified location
        public void movePolygonOrFreehandToHere(Point location)
        {
            Point displacement = new Point(location.X - startPoint.X, location.Y - startPoint.Y);

            //Move all the lines that make up the shape
            foreach(var myLine in freehandLineList)
            {
                myLine.translate(displacement);
            }
            startPoint.X = location.X ;
            startPoint.Y = location.Y;
            endPoint.X = endPoint.X + displacement.X;
            endPoint.Y = endPoint.Y + displacement.Y;
            
            //Recursively move the shape's children and parents
            if (childShapeGraphic != null)
            {
                childShapeGraphic.moveChild(displacement);
            }
            if (parentShapeGraphic != null)
            {
                parentShapeGraphic.moveParent(displacement);
            }
        }

        //Check if a specified location is inside bounding rectangle of the shape
        public bool checkIfCursorOn(Point location)
        {
            Point tempStart = startPoint;
            Point tempEnd = endPoint;
            if (startPoint.X <= tempEnd.X)
            {
                if (startPoint.Y <= tempEnd.Y)
                {
                    //Everything is fine
                }
                else //start is lower on screen than the end
                {
                    //Flip the y's
                    int tempY = tempStart.Y;
                    tempStart.Y = tempEnd.Y;
                    tempEnd.Y = tempY;
                }
            }
            else //start x > end x
            {
                //Flip the x's
                int tempX = tempStart.X;
                tempStart.X = tempEnd.X;
                tempEnd.X = tempX;

                if (startPoint.Y <= tempEnd.Y)
                {
                    //Its good
                }
                else
                {
                    //Flip the y's
                    int tempY = tempStart.Y;
                    tempStart.Y = tempEnd.Y;
                    tempEnd.Y = tempY;
                }
            }

            if (location.X > tempStart.X && location.X < tempEnd.X && location.Y > tempStart.Y && location.Y < tempEnd.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Returns true if a passed shape is pinned to the shape in any way
        public bool checkIfAlreadyPinned(ShapeGraphic childToPin)
        {
            bool result = false;

            if(childToPin == this)
            {
                return true;
            }
            if(childShapeGraphic!=null)
            {
                result = childShapeGraphic.checkIfAlreadyPinned(childToPin);
                if(result == true)
                {
                    return true;
                }
            }
            if(parentShapeGraphic!=null)
            {
                result = parentShapeGraphic.checkIfAlreadyPinned(childToPin);
                if (result == true)
                {
                    return true;
                }
            }

            //CHeck all the childToPin's children and parents
            if(childToPin.hasChild())
            {
                if (childShapeGraphic != null)
                {
                    result = childShapeGraphic.checkIfAlreadyPinned(childToPin.getChild());
                    if (result == true)
                    {
                        return true;
                    }
                }
                if (parentShapeGraphic != null)
                {
                    result = parentShapeGraphic.checkIfAlreadyPinned(childToPin.getChild());
                    if (result == true)
                    {
                        return true;
                    }
                }
            }
            if (childToPin.hasParent())
            {
                if (childShapeGraphic != null)
                {
                    result = childShapeGraphic.checkIfAlreadyPinned(childToPin.getParent());
                    if (result == true)
                    {
                        return true;
                    }
                }
                if (parentShapeGraphic != null)
                {
                    result = parentShapeGraphic.checkIfAlreadyPinned(childToPin.getParent());
                    if (result == true)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //Recursively find the child who doesn't have a child yet
        public void Pin(ShapeGraphic childToPin)
        {
            if (childShapeGraphic == null)
            {
                //Find the highest parent in the child graphic
                while(true)
                {
                    if(childToPin.hasParent())
                    {
                        childToPin = childToPin.getParent();
                    }
                    else
                    {
                        break;
                    }
                }
                childShapeGraphic = childToPin;
                childToPin.giveParent(this);
            }
            else
            {
                childShapeGraphic.Pin(childToPin);
            }
        }
        public void giveParent(ShapeGraphic parent)
        {
             parentShapeGraphic = parent;
        }
        public void giveChild(ShapeGraphic child)
        {
            childShapeGraphic = child;
        }
        public ShapeGraphic getParent()
        {
            return parentShapeGraphic;
        }
        public ShapeGraphic getChild()
        {
            return childShapeGraphic;
        }

        //Check to see if child has a child
        public bool hasChild()
        {
            if(childShapeGraphic==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool hasParent()
        {
            if (parentShapeGraphic == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Recursively find the last child and separate it
        public void Unpin()
        {
            ShapeGraphic tempChild = childShapeGraphic;
            ShapeGraphic tempParent = parentShapeGraphic;

            childShapeGraphic = new ShapeGraphic();
            parentShapeGraphic = new ShapeGraphic();
            childShapeGraphic = null;
            parentShapeGraphic = null;

            if (tempChild != null)
            {
                if (tempParent == null)
                {
                    tempChild.removeParent();
                }
                else
                {
                    tempChild.giveParent(tempParent);
                }
            }
            if (tempParent != null)
            {
                if (tempChild == null)
                {
                    tempParent.removeChild();
                }
                else
                {
                    tempParent.giveChild(tempChild);
                }
            }
        }

        public void removeParent()
        {
            parentShapeGraphic = null;
        }
        public void removeChild()
        {
            childShapeGraphic = null;
        }

        
    }
}
