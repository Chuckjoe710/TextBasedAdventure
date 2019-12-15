using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedAdventure
{
    abstract class Enemy
    {
        private int _health;
        private int _armorthresh;
        private int _numberofarms;
        private int _numberoflegs;
        private string _name;
        private Weapon weapon;
        public int Health
        {
            get { return _health; }
            private set { _health = value; }
        }
        public int ArmorThresh
        {
            get { return _armorthresh; }
            private set { _armorthresh = value; }
        }
        public int NumberOfArms
        {
            get { return _numberofarms; }
            private set { _numberofarms = value; }
        }
        public int NumberofLegs
        {
            get { return _numberoflegs; }
            private set { _numberoflegs = value; }
        }
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }
        public Enemy(int hp, int at, int noa, int nol, string nme)
        {
            Health = hp;
            ArmorThresh = at;
            NumberOfArms = noa;
            NumberofLegs = nol;
            Name = nme;
        }
        public void Attack(Player player, int dam, int amt)
        {
            player.TakeDamage(dam * amt);
        }
        public void EquipWeapon(Weapon stabby)
        {
            weapon = stabby;
        }
    }
}
