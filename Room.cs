using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace DungeonExplorer
{
    /// <summary>
    /// the main coding logic for a room class
    /// </summary>
    public class Room
    {
        /// <remarks>
        /// a string called description is created so that it can be used
        /// </remarks>
        private string description;
        public string GoldenSword { get; private set; }
        public string BowAndArrow { get; private set; }
        public string Axe { get; private set; }



        /// <param name="description">
        /// the description of the room
        /// </param>
        public Room(string description, string item1, string item2, string item3)
        {
            ///<remarks>
            ///the current string description will be whatever the parameter for the
            ///initialization of the class is
            /// </remarks>
            this.description = description;
            GoldenSword = item1;
            BowAndArrow = item2;
            Axe = item3;
        }

        /// <summary>
        /// This function returns the description and can be called by other filed
        /// </summary>

        /// <returns>
        /// the description definded in the code above
        /// </returns>
        public string GetDescription()
        {
            return description;
        }

    }
}