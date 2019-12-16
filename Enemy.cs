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
        private bool _isstunned;
        private Weapon _weapon;
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
        public bool IsStunned
        {
            get { return _isstunned; }
            internal set { _isstunned = value; }
        }
        public Weapon Weapon
        {
            get { return _weapon; }
            private set { _weapon = value; }
        }
        public Enemy(int hp, int at, int noa, int nol, string nme)
        {
            Health = hp;
            ArmorThresh = at;
            NumberOfArms = noa;
            NumberofLegs = nol;
            Name = nme;
        }
        public virtual void Attack(Player player, int dam, int amt)
        {
            player.TakeDamage(dam, amt);
        }
        public virtual void EquipWeapon(Weapon stabby)
        {
            Weapon = stabby;
        }
        public virtual void TakeDamage(int damage, int amt)
        {
            int realdam;
            realdam = amt * (damage - ArmorThresh);
            if (realdam <= 0)
                realdam = 1;
            Health = Health - realdam;
        }
    }
}
