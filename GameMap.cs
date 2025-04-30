using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    abstract class GameMap
    {
        public string RoomName { get; private set; }
        public bool RoomEntered { get; set; }
        public bool RoomLocked { get; set; }
        public string RoomType { get; private set; }
        public string RoomDescription { get; private set; }

        public GameMap(string roomName, bool roomEntered, bool roomLocked, string roomType, string roomDescription)
        {
            RoomName = roomName;
            RoomEntered = roomEntered;
            RoomLocked = roomLocked;
            RoomType = roomType;
            RoomDescription = roomDescription;
        }

        abstract public void EnterRoom();

        abstract public void UnlockRoom();

        abstract public string GetDescription();
    }
}
