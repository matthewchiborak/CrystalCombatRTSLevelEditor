using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.IO;

namespace HCIDrawingAssignment
{
    public partial class Form1 : Form
    {
        Graphics canvasGraphic;
        Pen drawingPen;
        Color selectedColor;
        Point startPosition;
        bool isDrawing;
        string currentMode;
        Image prevImage;
        bool firstPolygonPoint;
        int selectedIndex;
        bool selectNotFound;

        Caretaker shapeCaretaker;
        
        List<ShapeGraphic> canvasGraphicList;
        List<LineShape> freehandLineList;

        ShapeGraphic copiedGraphic;

        //These are used for wrestling
        List<RectangleShape> solidWallList;
        List<RectangleShape> destroyWallList;
        List<CircleShape> upGuardList;
        List<CircleShape> downGuardList;
        List<CircleShape> leftGuardList;
        List<CircleShape> rightGuardList;

        CircleShape startPoint;
        CircleShape key;
        CircleShape goal;
        RectangleShape floor;

        int[,] tileValue = new int[115, 53];

        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

        public Form1()
        {
            InitializeComponent();
            selectedColor = Color.Black;
            drawingPen = new Pen(selectedColor);
            startPosition = new Point(0, 0);
            isDrawing = false;
            currentMode = "Freehand";
            canvasGraphicList = new List<ShapeGraphic>();
            freehandLineList = new List<LineShape>();
            prevImage = canvasBox.Image;
            firstPolygonPoint = true;
            shapeCaretaker = new Caretaker();
            selectedIndex = -1;
            selectNotFound = true;
            freehandButton.Enabled = false;
            lineButton.Enabled = false;
            rectangleButton.Enabled = false;
            squareButton.Enabled = false;
            polygonButton.Enabled = false;
            ellipseButton.Enabled = false;
            circleButton.Enabled = false;
            selectButton.Enabled = false;
            copyButton.Enabled = false;
            cutButton.Enabled = false;
            pasteButton.Enabled = false;
            pinButton.Enabled = false;
            unpinButton.Enabled = false;
            saveButton.Enabled = false;
            loadButton.Enabled = false;
            colourButton.Enabled = false;
            undoButton.Enabled = false;
            redoButton.Enabled = false;

            destroyWallButton.Enabled = false;
            leftGuardButton.Enabled = false;
            upGuardButton.Enabled = false;
            rightGuardButton.Enabled = false;
            downGuardButton.Enabled = false;
            startPointButton.Enabled = false;
            keyButton.Enabled = false;
            goalButton.Enabled = false;

            solidWallList = new List<RectangleShape>();
            destroyWallList = new List<RectangleShape>();
            upGuardList = new List<CircleShape>();
            downGuardList = new List<CircleShape>();
            leftGuardList = new List<CircleShape>();
            rightGuardList = new List<CircleShape>();
            startPoint = null;
            key = null;
            goal = null;
            floor = new RectangleShape(Color.Gray, new Point(0,0));

            currentMode = "Solid";
            modeLabel.Text = "Solid";

            //Read the legend file and add the options to the tile list
            // string[] lines = System.IO.File.ReadAllLines(@"..\backgroundLegend.txt");
            string[] lines = System.IO.File.ReadAllLines("Input/backgroundLegend.txt");
            int index = 0;

            foreach(string line in lines)
            {
                TileBox.Items.Add(new Item(line, index++));
            }

            for(int i = 0; i < 115; i++)
            {
                for(int j = 0; j < 53; j++)
                {
                    tileValue[i, j] = -1;
                }
            }

            //Check if theres already an output and resource working on it
            if(File.Exists("Output/background.txt"))
            {
                int xSize = 0;
                int ySize = 0;
                int i = 0;
                int j = 0;
                
                string[] loadedLines = System.IO.File.ReadAllLines("Output/background.txt");
                
                foreach (string line in loadedLines)
                {
                    

                    String[] substrings = line.Split('~');
                    foreach (string substring in substrings)
                    {
                        if(j == 0)
                        {
                            xSize++;
                        }

                        //Update the tiles
                        int theValue = Int32.Parse(substring);
                        tileValue[i, j] = theValue;
                        Point tempStart = new Point(i, j);
                        Point tempEnd = new Point((i + 1), (j + 1));

                        //outputBox.Text = outputBox.Text + tempStart.X + " " + tempEnd.X + "\r\n";

                        //Create the box
                        if (theValue == 0)
                        {
                           // solidWallList.Add(new RectangleShape(Color.Gray, tempStart, tempEnd));
                        }
                        else if (theValue == 1)
                        {
                            solidWallList.Add(new RectangleShape(Color.Red, tempStart, tempEnd));
                        }
                        else if (theValue == 2)
                        {
                            solidWallList.Add(new RectangleShape(Color.Orange, tempStart, tempEnd));
                        }
                        else if (theValue == 3)
                        {
                            solidWallList.Add(new RectangleShape(Color.Yellow, tempStart, tempEnd));
                        }
                        else if (theValue == 4)
                        {
                            solidWallList.Add(new RectangleShape(Color.Green, tempStart, tempEnd));
                        }
                        else if (theValue == 5)
                        {
                            solidWallList.Add(new RectangleShape(Color.Blue, tempStart, tempEnd));
                        }
                        else if (theValue == 6)
                        {
                            solidWallList.Add(new RectangleShape(Color.Purple, tempStart, tempEnd));
                        }
                        else if (theValue == 7)
                        {
                            solidWallList.Add(new RectangleShape(Color.Pink, tempStart, tempEnd));
                        }
                        else if (theValue == 8)
                        {
                            solidWallList.Add(new RectangleShape(Color.LightYellow, tempStart, tempEnd));
                        }
                        else if (theValue == 9)
                        {
                            solidWallList.Add(new RectangleShape(Color.LightGreen, tempStart, tempEnd));
                        }
                        else if (theValue == 10)
                        {
                            solidWallList.Add(new RectangleShape(Color.LightBlue, tempStart, tempEnd));
                        }
                        else if (theValue == 11)
                        {
                            solidWallList.Add(new RectangleShape(Color.DarkRed, tempStart, tempEnd));
                        }
                        else if (theValue == 12)
                        {
                            solidWallList.Add(new RectangleShape(Color.DarkOrange, tempStart, tempEnd));
                        }
                        else if (theValue == 13)
                        {
                            solidWallList.Add(new RectangleShape(Color.DarkGreen, tempStart, tempEnd));
                        }
                        else if (theValue == 14)
                        {
                            solidWallList.Add(new RectangleShape(Color.DarkBlue, tempStart, tempEnd));
                        }
                        else if (theValue == 15)
                        {
                            solidWallList.Add(new RectangleShape(Color.DarkViolet, tempStart, tempEnd));
                        }
                        else if (theValue == 16)
                        {
                            solidWallList.Add(new RectangleShape(Color.Brown, tempStart, tempEnd));
                        }
                        else if (theValue == 17)
                        {
                            solidWallList.Add(new RectangleShape(Color.Tan, tempStart, tempEnd));
                        }
                        else
                        {
                            solidWallList.Add(new RectangleShape(Color.Black, tempStart, tempEnd));
                        }

                        //Increament the index
                        i++;
                    }

                    i = 0;
                    j++;
                    ySize++;
                }

                xSizeBox.Value = xSize;
                ySizeBox.Value = ySize;
                redrawAllGraphics();
            }
        }

        private void freehandButton_Click(object sender, EventArgs e)
        {
           
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {

        }

        private void squareButton_Click(object sender, EventArgs e)
        {
           
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            
        }

        private void polygonButton_Click(object sender, EventArgs e)
        {
           
        }

        private void colourButton_Click(object sender, EventArgs e)
        {
            
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
           
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
           
        }

        

        //Remove the currently selected shape from the drawing
        private void cutButton_Click(object sender, EventArgs e)
        {
            
        }

        

        //Create a copy of the currently copied object
        private void pasteButton_Click(object sender, EventArgs e)
        {
            
        }

        //Get the last momento and set the current shape listing to the momento's
        private void undoButton_Click(object sender, EventArgs e)
        {
           
        }

        //Set the current state of the canvas to a state that the user had undone
        private void redoButton_Click(object sender, EventArgs e)
        {
            
        }

        //Allow for the next shape clicked to be pinned to the currently selected shape
        private void pinButton_Click(object sender, EventArgs e)
        {
           
        }

        //Make it so the next clicked shape will be unpinned to any shapes it has been pinned to
        private void unpinButton_Click(object sender, EventArgs e)
        {
            
        }

        //Pop up the dialog to have the user name a save file for his or her picture
        private void saveButton_Click(object sender, EventArgs e)
        {
            //drawingSaveDialog.ShowDialog();
        }

        //Load a text file that was made from saving a drawing and create shapes based on the parsed information
        private void loadButton_Click(object sender, EventArgs e)
        {
            
        }

        private void canvasBox_Click(object sender, EventArgs e)
        {

        }

        //User has clicked on some part of the canvas
        private void canvasBox_MouseDown(object sender, MouseEventArgs e)
        {
           

            //Reset the know last location of the mouse
            startPosition = e.Location;

            //Allow the mouse move function to start drawing shapes
            if (e.Button == MouseButtons.Left)
            {
                //Make it so will only draw while moving if the mouse if clicked
                isDrawing = true;
            }

            //List<CircleShape> upGuardList;
            //List<CircleShape> downGuardList;
            //List<CircleShape> leftGuardList;
            //List<CircleShape> rightGuardList;

            //CircleShape startPoint;
            //CircleShape key;
            //CircleShape goal;

            Point gridPosition = new Point(e.Location.X / 10, e.Location.Y / 10);
            Point otherGridPosition = new Point((e.Location.X / 10) + 1, (e.Location.Y / 10) + 1);

            if (currentMode == "Up")
            {
                upGuardList.Add(new CircleShape(Color.Purple, gridPosition , otherGridPosition));
            }
            if (currentMode == "Down")
            {
                downGuardList.Add(new CircleShape(Color.Purple, gridPosition, otherGridPosition));
            }
            if (currentMode == "Left")
            {
                leftGuardList.Add(new CircleShape(Color.Purple, gridPosition, otherGridPosition));
            }
            if (currentMode == "Right")
            {
                rightGuardList.Add(new CircleShape(Color.Purple, gridPosition, otherGridPosition));
            }
            if (currentMode == "Start")
            {
                startPoint = new CircleShape(Color.Purple, gridPosition, otherGridPosition);
            }
            if (currentMode == "Key")
            {
                key = new CircleShape(Color.Purple, gridPosition, otherGridPosition);
            }
            if (currentMode == "Goal")
            {
                goal = new CircleShape(Color.Purple, gridPosition, otherGridPosition);
            }
            if (currentMode == "Remove")
            {
                foreach (var myGraphic in solidWallList)
                {
                    if(e.Location.X /10 > myGraphic.getStartPoint().X && e.Location.Y / 10 >= myGraphic.getStartPoint().Y && e.Location.X / 10 < myGraphic.getEndPoint().X && e.Location.Y / 10 < myGraphic.getEndPoint().Y)
                    {
                        for(int i = myGraphic.getStartPoint().X; i < myGraphic.getEndPoint().X; i++)
                        {
                            for (int j = myGraphic.getStartPoint().Y; j < myGraphic.getEndPoint().Y; j++)
                            {
                                tileValue[i, j] = -1;
                            }
                        }

                        solidWallList.Remove(myGraphic);
                        redrawAllGraphics();
                        return;
                    }
                }

                ////Destructable walls

                foreach (var myGraphic in destroyWallList)
                {
                    if (e.Location.X / 10 >= myGraphic.getStartPoint().X && e.Location.Y / 10 >= myGraphic.getStartPoint().Y && e.Location.X / 10 < myGraphic.getEndPoint().X && e.Location.Y / 10 < myGraphic.getEndPoint().Y)
                    {
                        destroyWallList.Remove(myGraphic);
                        redrawAllGraphics();
                        return;
                    }
                }

                ////Guards
                //tempBrush = new SolidBrush(Color.Purple);
                //Brush otherBrush = new SolidBrush(Color.Orange);
                foreach (var myGraphic in upGuardList)
                {
                    if (e.Location.X / 10 >= myGraphic.getStartPoint().X && e.Location.Y / 10 >= myGraphic.getStartPoint().Y && e.Location.X / 10 < myGraphic.getEndPoint().X && e.Location.Y / 10 < myGraphic.getEndPoint().Y)
                    {
                        upGuardList.Remove(myGraphic);
                        redrawAllGraphics();
                        return;
                    }
                }
                foreach (var myGraphic in leftGuardList)
                {
                    if (e.Location.X / 10 >= myGraphic.getStartPoint().X && e.Location.Y / 10 >= myGraphic.getStartPoint().Y && e.Location.X / 10 < myGraphic.getEndPoint().X && e.Location.Y / 10 < myGraphic.getEndPoint().Y)
                    {
                        leftGuardList.Remove(myGraphic);
                        redrawAllGraphics();
                        return;
                    }
                }
                foreach (var myGraphic in rightGuardList)
                {
                    if (e.Location.X / 10 >= myGraphic.getStartPoint().X && e.Location.Y / 10 >= myGraphic.getStartPoint().Y && e.Location.X / 10 < myGraphic.getEndPoint().X && e.Location.Y / 10 < myGraphic.getEndPoint().Y)
                    {
                        rightGuardList.Remove(myGraphic);
                        redrawAllGraphics();
                        return;
                    }
                }
                foreach (var myGraphic in downGuardList)
                {
                    if (e.Location.X / 10 >= myGraphic.getStartPoint().X && e.Location.Y / 10 >= myGraphic.getStartPoint().Y && e.Location.X / 10 < myGraphic.getEndPoint().X && e.Location.Y / 10 < myGraphic.getEndPoint().Y)
                    {
                        downGuardList.Remove(myGraphic);
                        redrawAllGraphics();
                        return;
                    }
                }

                ////CircleShape startPoint;
                if (startPoint != null)
                {
                    if (e.Location.X / 10 >= startPoint.getStartPoint().X && e.Location.Y / 10 >= startPoint.getStartPoint().Y && e.Location.X / 10 < startPoint.getEndPoint().X && e.Location.Y / 10 < startPoint.getEndPoint().Y)
                    {
                        startPoint = null;
                        redrawAllGraphics();
                        return;
                    }
                }
                ////CircleShape key;
                if (key != null)
                {
                    if (e.Location.X / 10 >= key.getStartPoint().X && e.Location.Y / 10 >= key.getStartPoint().Y && e.Location.X / 10 < key.getEndPoint().X && e.Location.Y / 10 < key.getEndPoint().Y)
                    {
                        key = null;
                        redrawAllGraphics();
                        return;
                    }
                }
                ////CircleShape goal;
                if (goal != null)
                {
                    if (e.Location.X / 10 >= goal.getStartPoint().X && e.Location.Y / 10 >= goal.getStartPoint().Y && e.Location.X / 10 < goal.getEndPoint().X && e.Location.Y / 10 < goal.getEndPoint().Y)
                    {
                        goal = null;
                        redrawAllGraphics();
                        return;
                    }
                }
            }

            redrawAllGraphics();
        }

        //User lets up on the mouse. Drawing mode turns off preventing further drawing and the shape that was drawn is commited to the canvas
        private void canvasBox_MouseUp(object sender, MouseEventArgs e)
        {
            
            isDrawing = false;
            
           
            if (currentMode == "Solid" || currentMode == "Destroy")
            {
                Point tempStart = startPosition;
                Point tempEnd = e.Location;
                if (startPosition.X <= tempEnd.X)
                {
                    if (startPosition.Y <= tempEnd.Y)
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

                    if (startPosition.Y <= tempEnd.Y)
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

                //Make the points line up with grid points
                tempStart.X = (tempStart.X / 10);
                tempStart.Y = (tempStart.Y / 10);
                tempEnd.X = ((tempEnd.X / 10) + 1);
                tempEnd.Y = ((tempEnd.Y / 10) + 1);

                if (currentMode == "Destroy")
                {
                    destroyWallList.Add(new RectangleShape(Color.Brown, tempStart, tempEnd));
                }
                else if(currentMode == "Solid")
                {
                    //solidWallList.Add(new RectangleShape(Color.Blue, tempStart, tempEnd));
                    if (TileBox.SelectedIndex == 0)
                    {
                        solidWallList.Add(new RectangleShape(Color.Gray, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 1)
                    {
                        solidWallList.Add(new RectangleShape(Color.Red, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 2)
                    {
                        solidWallList.Add(new RectangleShape(Color.Orange, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 3)
                    {
                        solidWallList.Add(new RectangleShape(Color.Yellow, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 4)
                    {
                        solidWallList.Add(new RectangleShape(Color.Green, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 5)
                    {
                        solidWallList.Add(new RectangleShape(Color.Blue, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 6)
                    {
                        solidWallList.Add(new RectangleShape(Color.Purple, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 7)
                    {
                        solidWallList.Add(new RectangleShape(Color.Pink, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 8)
                    {
                        solidWallList.Add(new RectangleShape(Color.LightYellow, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 9)
                    {
                        solidWallList.Add(new RectangleShape(Color.LightGreen, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 10)
                    {
                        solidWallList.Add(new RectangleShape(Color.LightBlue, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 11)
                    {
                        solidWallList.Add(new RectangleShape(Color.DarkRed, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 12)
                    {
                        solidWallList.Add(new RectangleShape(Color.DarkOrange, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 13)
                    {
                        solidWallList.Add(new RectangleShape(Color.DarkGreen, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 14)
                    {
                        solidWallList.Add(new RectangleShape(Color.DarkBlue, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 15)
                    {
                        solidWallList.Add(new RectangleShape(Color.DarkViolet, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 16)
                    {
                        solidWallList.Add(new RectangleShape(Color.Brown, tempStart, tempEnd));
                    }
                    else if (TileBox.SelectedIndex == 17)
                    {
                        solidWallList.Add(new RectangleShape(Color.Tan, tempStart, tempEnd));
                    }
                    else
                    {
                        solidWallList.Add(new RectangleShape(Color.Black, tempStart, tempEnd));
                    }

                    //Update the gridValues
                    for (int i = tempStart.X; i < tempEnd.X; i++)
                    {
                        for (int j = tempStart.Y; j < tempEnd.Y; j++)
                        {
                            tileValue[i,j] = TileBox.SelectedIndex;
                        }
                    }
                }

                redrawAllGraphics();
            }

            
            
        }

        //User moves the mouse. Most modes only actually activation if the mouse is down. Polygon mode draws lines from the last clicked point
        private void canvasBox_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (currentMode == "Destroy" || currentMode == "Solid")
            {
                if (isDrawing)
                {
                    //Refresh the canvas
                    redrawAllGraphics();

                    canvasGraphic = canvasBox.CreateGraphics();
                    Point tempStart = startPosition;
                    Point tempEnd = e.Location;
                    if (startPosition.X <= tempEnd.X)
                    {
                        if (startPosition.Y <= tempEnd.Y)
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

                        if (startPosition.Y <= tempEnd.Y)
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

                    //Make the points line up with grid points
                    tempStart.X = (tempStart.X / 10) * 10;
                    tempStart.Y = (tempStart.Y / 10) * 10;
                    tempEnd.X = ((tempEnd.X / 10) + 1) * 10;
                    tempEnd.Y = ((tempEnd.Y / 10) + 1) * 10;

                    //SolidBrush tempBrush = new SolidBrush(selectedColor);
                    if (currentMode == "Destroy")
                    {
                        SolidBrush tempBrush = new SolidBrush(Color.Brown);
                        canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                    }
                    else if(currentMode == "Solid")
                    {
                        if(TileBox.SelectedIndex == 0)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.Gray);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 1)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.Red);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 2)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.Orange);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 3)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.Yellow);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 4)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.Green);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 5)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.Blue);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 6)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.Purple);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 7)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.Pink);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 8)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.LightYellow);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 9)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.LightGreen);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 10)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.LightBlue);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 11)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.DarkRed);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 12)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.DarkOrange);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 13)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.DarkGreen);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 14)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.DarkBlue);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 15)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.DarkViolet);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 16)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.Brown);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else if (TileBox.SelectedIndex == 17)
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.Tan);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                        else
                        {
                            SolidBrush tempBrush = new SolidBrush(Color.Black);
                            canvasGraphic.FillRectangle(tempBrush, tempStart.X, tempStart.Y, tempEnd.X - tempStart.X, tempEnd.Y - tempStart.Y);
                        }
                    }
                }
            }
           

        }
        
        //Clear the canvas and redraw all the shapes
        private void redrawAllGraphics()
        {
            //Clear the canvas
            if (canvasGraphic != null)
            {
                canvasGraphic.Clear(Color.White);
            }

            //Draw the floor
            SolidBrush tempBrush = new SolidBrush(Color.Gray);
            canvasGraphic = canvasBox.CreateGraphics();
            canvasGraphic.FillRectangle(tempBrush, 0, 0, 10 * (float)xSizeBox.Value, 10 * (float)ySizeBox.Value);

            tempBrush = new SolidBrush(Color.Blue);
            //Draw the walls, guards, and key points
            //Solid walls
            foreach (var myGraphic in solidWallList)
            {
                tempBrush = new SolidBrush(myGraphic.getShapeColor());
                canvasGraphic = canvasBox.CreateGraphics();
                canvasGraphic.FillRectangle(tempBrush, 10 * myGraphic.getStartPoint().X, 10 * myGraphic.getStartPoint().Y, 10 * myGraphic.getEndPoint().X - 10 * myGraphic.getStartPoint().X, 10 * myGraphic.getEndPoint().Y - 10 * myGraphic.getStartPoint().Y);
            }

            //Destructable walls
            tempBrush = new SolidBrush(Color.Brown);
            foreach (var myGraphic in destroyWallList)
            {
                canvasGraphic = canvasBox.CreateGraphics();
                canvasGraphic.FillRectangle(tempBrush, 10 * myGraphic.getStartPoint().X, 10 * myGraphic.getStartPoint().Y, 10 * myGraphic.getEndPoint().X - 10 * myGraphic.getStartPoint().X, 10 * myGraphic.getEndPoint().Y - 10 * myGraphic.getStartPoint().Y);
            }

            //Guards
            tempBrush = new SolidBrush(Color.Purple);
            Brush otherBrush = new SolidBrush(Color.Orange);
            foreach (var myGraphic in upGuardList)
            {
                canvasGraphic = canvasBox.CreateGraphics();
                canvasGraphic.FillEllipse(tempBrush, 10 * myGraphic.getStartPoint().X, 10 * myGraphic.getStartPoint().Y, 10 * myGraphic.getEndPoint().X - 10 * myGraphic.getStartPoint().X, 10 * myGraphic.getEndPoint().Y - 10 * myGraphic.getStartPoint().Y);
                canvasGraphic = canvasBox.CreateGraphics();
                canvasGraphic.FillEllipse(otherBrush, 10 * myGraphic.getStartPoint().X + 2, 10 * myGraphic.getStartPoint().Y, 6, 6);
               
            }
            foreach (var myGraphic in leftGuardList)
            {
                canvasGraphic = canvasBox.CreateGraphics();
                canvasGraphic.FillEllipse(tempBrush, 10 * myGraphic.getStartPoint().X, 10 * myGraphic.getStartPoint().Y, 10 * myGraphic.getEndPoint().X - 10 * myGraphic.getStartPoint().X, 10 * myGraphic.getEndPoint().Y - 10 * myGraphic.getStartPoint().Y);
                canvasGraphic = canvasBox.CreateGraphics();
                canvasGraphic.FillEllipse(otherBrush, 10 * myGraphic.getStartPoint().X, 10 * myGraphic.getStartPoint().Y + 2, 6,6);
            }
            foreach (var myGraphic in rightGuardList)
            {
                canvasGraphic = canvasBox.CreateGraphics();
                canvasGraphic.FillEllipse(tempBrush, 10 * myGraphic.getStartPoint().X, 10 * myGraphic.getStartPoint().Y, 10 * myGraphic.getEndPoint().X - 10 * myGraphic.getStartPoint().X, 10 * myGraphic.getEndPoint().Y - 10 * myGraphic.getStartPoint().Y);
                canvasGraphic = canvasBox.CreateGraphics();
                canvasGraphic.FillEllipse(otherBrush, 10 * myGraphic.getStartPoint().X + 4, 10 * myGraphic.getStartPoint().Y + 2, 6,6);
            }
            foreach (var myGraphic in downGuardList)
            {
                canvasGraphic = canvasBox.CreateGraphics();
                canvasGraphic.FillEllipse(tempBrush, 10 * myGraphic.getStartPoint().X, 10 * myGraphic.getStartPoint().Y, 10 * myGraphic.getEndPoint().X - 10 * myGraphic.getStartPoint().X, 10 * myGraphic.getEndPoint().Y - 10 * myGraphic.getStartPoint().Y);
                canvasGraphic = canvasBox.CreateGraphics();
                canvasGraphic.FillEllipse(otherBrush, 10 * myGraphic.getStartPoint().X + 2, 10 * myGraphic.getStartPoint().Y + 4, 6,6);
            }

            //CircleShape startPoint;
            if(startPoint != null)
            {
                tempBrush = new SolidBrush(Color.Green);
                canvasGraphic = canvasBox.CreateGraphics();
                canvasGraphic.FillEllipse(tempBrush, 10 * startPoint.getStartPoint().X, 10 * startPoint.getStartPoint().Y, 10 * startPoint.getEndPoint().X - 10 * startPoint.getStartPoint().X, 10 * startPoint.getEndPoint().Y - 10 * startPoint.getStartPoint().Y);
            }
            //CircleShape key;
            if (key != null)
            {
                tempBrush = new SolidBrush(Color.Yellow);
                canvasGraphic = canvasBox.CreateGraphics();
                canvasGraphic.FillEllipse(tempBrush, 10 * key.getStartPoint().X, 10 * key.getStartPoint().Y, 10 * key.getEndPoint().X - 10 * key.getStartPoint().X, 10 * key.getEndPoint().Y - 10 * key.getStartPoint().Y);
            }
            //CircleShape goal;
            if (goal != null)
            {
                tempBrush = new SolidBrush(Color.Red);
                canvasGraphic = canvasBox.CreateGraphics();
                canvasGraphic.FillEllipse(tempBrush, 10 * goal.getStartPoint().X, 10 * goal.getStartPoint().Y, 10 * goal.getEndPoint().X - 10 * goal.getStartPoint().X, 10 * goal.getEndPoint().Y - 10 * goal.getStartPoint().Y);
            }

            //Draw the grid lines
            Pen gridPen = new Pen(Color.Black);

            if (gridCheckBox.Checked)
            {
                for (int i = 0; i < 116; i++)
                {
                    canvasGraphic = canvasBox.CreateGraphics();
                    Point gridStart = new Point(i * 10, 0);
                    Point gridEnd = new Point(i * 10, 1150);
                    canvasGraphic.DrawLine(gridPen, gridStart, gridEnd);
                }
                for (int i = 0; i < 54; i++)
                {
                    canvasGraphic = canvasBox.CreateGraphics();
                    Point gridStart = new Point(0, i * 10);
                    Point gridEnd = new Point(1150, i * 10);
                    canvasGraphic.DrawLine(gridPen, gridStart, gridEnd);
                }
            }
        }

        private void selectedColorBox_Click(object sender, EventArgs e)
        {
            
        }

        //Save info of the currently draw shapes to a text file to be able to be recreated later
        private void drawingSaveDialog_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void drawingOpenDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        //Check is two shapes in a pin mass are connected at any points
        private bool checkIfPinned(ShapeGraphic pinnee, ShapeGraphic pinner)
        {
            return false;
        }

        private void solidWallButton_Click(object sender, EventArgs e)
        {
            currentMode = "Solid";
            modeLabel.Text = "Solid";
            redrawAllGraphics();
        }

        private void destroyWallButton_Click(object sender, EventArgs e)
        {
            //currentMode = "Destroy";
            //modeLabel.Text = "Destroy";
        }

        private void leftGuardButton_Click(object sender, EventArgs e)
        {
            //currentMode = "Left";
            //modeLabel.Text = "Left";
        }

        private void rightGuardButton_Click(object sender, EventArgs e)
        {
            //currentMode = "Right";
            //modeLabel.Text = "Right";
        }

        private void upGuardButton_Click(object sender, EventArgs e)
        {
            //currentMode = "Up";
            //modeLabel.Text = "Up";
        }

        private void downGuardButton_Click(object sender, EventArgs e)
        {
            //currentMode = "Down";
            //modeLabel.Text = "Down";
        }

        private void startPointButton_Click(object sender, EventArgs e)
        {
            //currentMode = "Start";
            //modeLabel.Text = "Start";
        }

        private void keyButton_Click(object sender, EventArgs e)
        {
            //currentMode = "Key";
            //modeLabel.Text = "Key";
        }

        private void goalButton_Click(object sender, EventArgs e)
        {
            //currentMode = "Goal";
            //modeLabel.Text = "Goal";
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            string generation = "";

            for (int j = 0; j < ySizeBox.Value; j++)
            {
                for (int i = 0; i < xSizeBox.Value; i++)
                {
                    if (tileValue[i, j] < 0)
                    {
                        generation = generation + '0';
                    }
                    else
                    {
                        generation = generation + tileValue[i, j].ToString();
                    }

                    if(i + 1 != xSizeBox.Value)
                    {
                        generation = generation +'~';
                    }
                }

                generation = generation + "\r\n";
            }

            //generation = generation + keyNameBox.Text + ",";
            ////CircleShape key;
            //if (key != null)
            //{
            //    generation = generation + key.getStartPoint().X + "," + key.getStartPoint().Y + ",";
            //}

            //generation = generation + goalNameBox.Text + ",";
            ////CircleShape goal;
            //if (goal != null)
            //{
            //    generation = generation + goal.getStartPoint().X + "," + goal.getStartPoint().Y + ",";
            //}

            ////CircleShape startPoint;
            //if (startPoint != null)
            //{
            //    generation = generation + startPoint.getStartPoint().X + "," + startPoint.getStartPoint().Y + ",";
            //}

            //generation = generation + xSizeBox.Value + "," + ySizeBox.Value + "%";

            //int arrayLength = downGuardList.Count + upGuardList.Count + leftGuardList.Count + rightGuardList.Count;
            //int currentCount = 0;
            ////Guards
            //foreach (var myGraphic in upGuardList)
            //{
            //    currentCount++;
            //    generation = generation + myGraphic.getStartPoint().X + "," + myGraphic.getStartPoint().Y + "," + "u";
            //    if (currentCount >= arrayLength)
            //    {
            //        generation = generation + "%";
            //    }
            //    else
            //    {
            //        generation = generation + "~";
            //    }
            //}
            //foreach (var myGraphic in leftGuardList)
            //{
            //    currentCount++;

            //    generation = generation + myGraphic.getStartPoint().X + "," + myGraphic.getStartPoint().Y + "," + "l";
            //    if (currentCount >= arrayLength)
            //    {
            //        generation = generation + "%";
            //    }
            //    else
            //    {
            //        generation = generation + "~";
            //    }
            //}
            //foreach (var myGraphic in rightGuardList)
            //{
            //    currentCount++;

            //    generation = generation + myGraphic.getStartPoint().X + "," + myGraphic.getStartPoint().Y + "," + "r";
            //    if (currentCount >= arrayLength)
            //    {
            //        generation = generation + "%";
            //    }
            //    else
            //    {
            //        generation = generation + "~";
            //    }
            //}
            
            //foreach (var myGraphic in downGuardList)
            //{
            //    currentCount++;
            //    generation = generation + myGraphic.getStartPoint().X + "," + myGraphic.getStartPoint().Y + "," + "d";
            //    if(currentCount >= arrayLength)
            //    {
            //        generation = generation + "%";
            //    }
            //    else
            //    {
            //        generation = generation + "~";
            //    }
            //}

            //arrayLength = destroyWallList.Count + solidWallList.Count;
            //currentCount = 0;
            //foreach (var myGraphic in solidWallList)
            //{
            //    currentCount++;
            //    int xlen = myGraphic.getEndPoint().X - myGraphic.getStartPoint().X;
            //    int ylen = myGraphic.getEndPoint().Y - myGraphic.getStartPoint().Y;
            //    generation = generation + xlen + "," + ylen + "," + myGraphic.getStartPoint().X + "," + myGraphic.getStartPoint().Y + "," + "n";
            //    if (currentCount >= arrayLength)
            //    {
            //        generation = generation + "%";
            //    }
            //    else
            //    {
            //        generation = generation + "~";
            //    }
            //}
            
            ////Destructable walls
            //foreach (var myGraphic in destroyWallList)
            //{
            //    currentCount++;
            //    int xlen = myGraphic.getEndPoint().X - myGraphic.getStartPoint().X;
            //    int ylen = myGraphic.getEndPoint().Y - myGraphic.getStartPoint().Y;
            //    generation = generation + xlen + "," + ylen + "," + myGraphic.getStartPoint().X + "," + myGraphic.getStartPoint().Y + "," + "d";

            //    if (currentCount >= arrayLength)
            //    {
            //        generation = generation + "%";
            //    }
            //    else
            //    {
            //        generation = generation + "~";
            //    }
            //}


            outputBox.Text = generation;

            //Output to a file
            System.IO.File.WriteAllText("Output/background.txt", generation);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            currentMode = "Remove";
            modeLabel.Text = "Remove";
        }

        private void gridCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            redrawAllGraphics();
        }

        private void xSizeBox_ValueChanged(object sender, EventArgs e)
        {
            redrawAllGraphics();
        }

        private void ySizeBox_ValueChanged(object sender, EventArgs e)
        {
            redrawAllGraphics();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            solidWallList.Clear();
            //List<RectangleShape> 
            destroyWallList.Clear();
            //List<CircleShape> 
            upGuardList.Clear();
            //List<CircleShape> 
            downGuardList.Clear();
            //List<CircleShape>
            leftGuardList.Clear();
            //List<CircleShape> 
            rightGuardList.Clear();

            //CircleShape 
            startPoint = null;
            //CircleShape 
            key = null;
            //CircleShape
            goal = null;

            for(int i = 0; i < 115; i++)
            {
                for (int j = 0; j < 53; j++)
                {
                    tileValue[i, j] = -1;
                }
            }

            redrawAllGraphics();
        }

        private void TileBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentMode = "Solid";
            modeLabel.Text = "Solid";
            redrawAllGraphics();

            if (TileBox.SelectedIndex == 0)
            {
                selectedColorBox.BackColor = Color.Gray;
            }
            else if (TileBox.SelectedIndex == 1)
            {
                selectedColorBox.BackColor = (Color.Red);
            }
            else if (TileBox.SelectedIndex == 2)
            {
                selectedColorBox.BackColor = (Color.Orange);
            }
            else if (TileBox.SelectedIndex == 3)
            {
                selectedColorBox.BackColor = (Color.Yellow);
            }
            else if (TileBox.SelectedIndex == 4)
            {
                selectedColorBox.BackColor = (Color.Green);
            }
            else if (TileBox.SelectedIndex == 5)
            {
                selectedColorBox.BackColor = (Color.Blue);
            }
            else if (TileBox.SelectedIndex == 6)
            {
                selectedColorBox.BackColor = (Color.Purple);
            }
            else if (TileBox.SelectedIndex == 7)
            {
                selectedColorBox.BackColor = (Color.Pink);
            }
            else if (TileBox.SelectedIndex == 8)
            {
                selectedColorBox.BackColor = (Color.LightYellow);
            }
            else if (TileBox.SelectedIndex == 9)
            {
                selectedColorBox.BackColor = (Color.LightGreen);
            }
            else if (TileBox.SelectedIndex == 10)
            {
                selectedColorBox.BackColor = (Color.LightBlue);
            }
            else if (TileBox.SelectedIndex == 11)
            {
                selectedColorBox.BackColor = (Color.DarkRed);
            }
            else if (TileBox.SelectedIndex == 12)
            {
                selectedColorBox.BackColor = (Color.DarkOrange);
            }
            else if (TileBox.SelectedIndex == 13)
            {
                selectedColorBox.BackColor = (Color.DarkGreen);
            }
            else if (TileBox.SelectedIndex == 14)
            {
                selectedColorBox.BackColor = (Color.DarkBlue);
            }
            else if (TileBox.SelectedIndex == 15)
            {
                selectedColorBox.BackColor = (Color.DarkViolet);
            }
            else if (TileBox.SelectedIndex == 16)
            {
                selectedColorBox.BackColor = (Color.Brown);
            }
            else if (TileBox.SelectedIndex == 17)
            {
                selectedColorBox.BackColor = (Color.Tan);
            }
            else
            {
                selectedColorBox.BackColor = (Color.Black);
            }
        }
    }
}
