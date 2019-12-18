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
        private bool _isstunned = false;
        private bool _isdead = false;
        private Weapon _weapon = new Weapon();
        public int Health
        {
            get { return _health; }
            protected set { _health = value; }
        }
        public int ArmorThresh
        {
            get { return _armorthresh; }
            protected set { _armorthresh = value; }
        }
        public int NumberOfArms
        {
            get { return _numberofarms; }
            protected set { _numberofarms = value; }
        }
        public int NumberOfLegs
        {
            get { return _numberoflegs; }
            protected set { _numberoflegs = value; }
        }
        public string Name
        {
            get { return _name; }
            protected set { _name = value; } 
        }
        public bool IsStunned
        {
            get { return _isstunned; }
            internal set { _isstunned = value; }
        }
        public bool IsDead
        {
            get { return _isdead; }
            internal set { _isdead = value; }
        }
        public Weapon Weapon
        {
            get { return _weapon; }
            protected set { _weapon = value; }
        }
        public Enemy(int hp, int at, int noa, int nol, string nme)
        {
            Health = hp;
            ArmorThresh = at;
            NumberOfArms = noa;
            NumberOfLegs = nol;
            Name = nme;
        }
        public Enemy()
        {
        }
        public void Attack(Player player, int dam, int amt)
        {
            player.TakeDamage(dam, amt);
        }
        public void TakeDamage(int damage, int amt)
        {
            int realdam;
            realdam = amt * (damage - ArmorThresh);
            if (realdam <= 0)
                realdam = 1;
            Health -= realdam;
        }
        public void Die()
        {
            Name += "[IsDead]";
            IsDead = true;
        }
        public static Enemy GenerateEnemy()
        {
            int x = Globals.random.Next(1, 3);
            if (x == 1)
            {
                return new Humanoid();
            }
            else if (x == 2)
            {
                return new Animal();
            }
            else if (x == 3)
            {
                return new Plant();
            }
            else
            {
                return new Humanoid();
            }
        }
    }
}
