using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedAdventure
{
    class Mythical : Enemy
    {
        private Weapon _special;
        public Weapon Special
        {
            get { return _special; }
            private set { _special = value; }
        }
        public Mythical(int which)
        {
            if (which == 1)
            {
                this.Minotaur();
            }
            else if(which == 2)
            {
                this.Giant();
            }
        }
        public void Minotaur()
        {
            Health = Globals.random.Next(100, 115);
            ArmorThresh = Globals.random.Next(3, 5);
            NumberOfArms = 2;
            NumberOfLegs = 2;
            Name = "Minotaur";
            Special = new Weapon();
            Special.GenerateDoubleLS();
        }
        public void Giant()
        {
            Health = Globals.random.Next(130, 150);
            ArmorThresh = 0;
            NumberOfArms = 2;
            NumberOfLegs = 2;
            Name = "Giant";
            Special = new Weapon();
            Special.GenerateClub();
        }
    }
}
