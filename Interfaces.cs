using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public interface IDamagable
    {
        void Damaged(int damageTaken);
    }

    public interface ICollectible 
    {
        void Collected();
    }

}
