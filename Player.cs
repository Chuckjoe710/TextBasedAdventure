using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedAdventure
{
    class Player
    {
        #region fields
        private int _health;
        private int _armorthresh;
        private string _name;
        private int _amtweps;
        private bool _isstunned;
        private Weapon[] _weapons = new Weapon[5];
        public int Health
        {
            get { return _health; }
            internal set { _health = value; }
        }
        public int ArmorThresh
        {
            get { return _armorthresh; }
            internal set { _armorthresh = value; }
        }
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }
        public int AmountWeapons
        {
            get { return _amtweps; }
            private set { _amtweps = value; }
        }
        public bool IsStunned
        {
            get { return _isstunned; }
            internal set { _isstunned = value; }
        }
        public Weapon[] Weapons
        {
            get { return _weapons; }
            private set { _weapons = value; }
        }
        #endregion
        #region constructor
        public Player (string name, int hp, int at) 
        {
            this.Name = name;
            this.Health = hp;
            this.ArmorThresh = at;
        }
        #endregion constructor
        public void TakeDamage(int damage, int amount)
        {
            int realdam;
            realdam = amount * (damage - ArmorThresh);
            if(realdam <= 0)
                realdam = 1;
            Health -= realdam;
        }
        public void AddWeapon(Weapon weapon)
        {
            if(AmountWeapons == 5)
            {
                Console.WriteLine("You must replace one of your weapons");
                for(int k = 0; k < AmountWeapons; k++)
                {
                    Console.WriteLine("{0}. {1}", k+1, _weapons[k]);
                }
                int x = Convert.ToInt32(Console.ReadLine());
                if(x == 1)
                {
                    _weapons[0] = weapon;
                }
                else if (x == 2)
                {
                    _weapons[1] = weapon;
                }
                else if (x == 3)
                {
                    _weapons[2] = weapon;
                }
                else if (x == 4)
                {
                    _weapons[3] = weapon;
                }
                else
                {
                    _weapons[4] = weapon;
                }
            }
            else
            {
                int x = AmountWeapons;
                Weapons[x] = weapon;
                AmountWeapons++;
            }
        }
        public void Attack(Enemy enemy, int dam, int amt)
        {
            enemy.TakeDamage(dam, amt);
        }
    }
}
