using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace DungeonExplorer
{
    class Room : GameMap
    {
        public string MonstersInRoom { get; set; }
        public Room(string roomName, bool roomEntered, bool roomLocked, string roomType, string roomDescription
            , string monstersInRoom) :
            base(roomName, roomEntered, roomLocked, roomType, roomDescription)
        {
            MonstersInRoom = monstersInRoom;
        }

        override public void EnterRoom()
        {
            if (RoomEntered == true)
            {
                Console.WriteLine("You have already entered this room");
            }

            else if (RoomEntered == false)
            {
                if (RoomLocked == false)
                {
                    Console.WriteLine($"Entering {RoomName}");
                    if (RoomType == "combat room" || RoomType == "boss room" || RoomType == "mini boss room")
                    {
                        Console.WriteLine($"{MonstersInRoom}");
                        Console.WriteLine("press x to attack");
                    }
                    RoomEntered = true;
                }

                else if (RoomLocked == true)
                {
                    Console.WriteLine($"{RoomName} is locked");
                    Console.WriteLine($"Please unlock {RoomName} to enter");
                    Console.WriteLine("Enter another room");
                }
            }
        }

        override public void UnlockRoom()
        {
            Console.WriteLine($"Unlocking {RoomName}");
            RoomLocked = false;
        }

        override public string GetDescription()
        {
            return RoomDescription;
        }
    }
}