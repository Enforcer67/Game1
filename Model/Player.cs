using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RheinwerkAdventure.Model
{
    class Player :Character, IAttackable
    {

        public Player()
        {

        }

        public int Hitpoints => throw new NotImplementedException();
    }
}
