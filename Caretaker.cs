using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIDrawingAssignment
{
    class Caretaker
    {
        List<Momento> actionList;
        List<Momento> undoneList;
        int firstUndo;

        public Caretaker()
        {
            actionList = new List<Momento>();
            undoneList = new List<Momento>();
            firstUndo = 0;
        }

        public void add(Momento action)
        {
            if (firstUndo == 1)
            {
                firstUndo = 0;
            }
            else
            {
                actionList.Add(action);
            }
            undoneList.Clear();
        }



        public Momento undo(Momento currentScreen)
        {
            Momento tempMomento = actionList.Last();
            //undoneList.Add(tempMomento);
            if (firstUndo == 0)
            {
                undoneList.Clear();
                undoneList.Add(new Momento(currentScreen.getCanvasGraphicList()));
                firstUndo = 1;
                return new Momento(tempMomento.getCanvasGraphicList());
            }
            else
            {
                actionList.Remove(tempMomento);
                undoneList.Add(new Momento(tempMomento.getCanvasGraphicList()));
                if (actionList.Any())
                {
                    return new Momento(actionList.Last().getCanvasGraphicList());
                }
                else
                {
                    return new Momento(tempMomento.getCanvasGraphicList());
                }
            }
        }

        public Momento redo()
        {
            Momento tempMomento = undoneList.Last();
            actionList.Add(new Momento(tempMomento.getCanvasGraphicList()));
            undoneList.Remove(tempMomento);
            return new Momento(tempMomento.getCanvasGraphicList());
        }

        public bool checkIfCanUndo()
        {
            return actionList.Any();
        }
        public bool checkIfCanRedo()
        {
            return undoneList.Any();
        }
    }
}
