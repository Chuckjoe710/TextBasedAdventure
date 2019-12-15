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
        public int Health
        {
            get
            {
                return _health;
            }
            private set
            {
                _health = value;
            }
        }
        public int ArmorThresh
        {
            get
            {
                return _armorthresh;
            }
            private set
            {
                _armorthresh = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
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
        public void TakeDamage(int damage)
        {
            int realdam;
            realdam = damage - this.ArmorThresh;
            if(realdam <= 0)
                realdam = 1;
            this.Health -= realdam;
        }
    }
}
