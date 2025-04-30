using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Statistics 
    {
        public int PlayerCoins { get; set; }

        public Statistics(int playerCoins)
        {
            PlayerCoins = playerCoins;
        }

        public void CalculateAverageCoins(int goblinCoins, int skeletonCoins, int ogreCoins,
            int dragonCoins, int playerCoins)
        {
            int totalCoins = goblinCoins + skeletonCoins + ogreCoins + dragonCoins;
            int averageCoins = totalCoins / 4;
            Console.WriteLine($"The average of coins are {averageCoins}");
            Console.WriteLine($"You had {playerCoins}");
        }
    }
}
