using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedAdventure
{
    class LongSword : Weapon
    {
        public LongSword(double y)
        {
            Random random = new Random();
            Damage = random.Next(12, 16);
            Length = y;
            Durability = random.Next(30, 50);
            Name = "Long Sword";
            Speed = random.Next(8, 12);
            Amount = 1;
        }
        public void BasicAttack
    }
}
