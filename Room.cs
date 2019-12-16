using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedAdventure
{
    class Room
    {
        public Room(Player player)
        {
            GenerateRoom(player);
        }
        public void GenerateRoom(Player player)
        {
            Random random = new Random();
            int x;
            //x = random.Next(1, 10);
            x = 1;
            if(x == 10)
            {
            
            }
            else
            {
                x = random.Next(1, 3);
                if(x == 1)
                {
                    Enemy enemy1 = new Enemy
                    StartEncounter(player, enemy1);
                }
                else if(x == 2)
                {
                    
                }
                else
                {

                }
            }
        }
        private void StartEncounter(Player player, Enemy enemy1)
        {
            int k;
            Console.WriteLine("You Enter the room and the door shuts behind you, cliche I know, soon after a shady looking figure enters. You prepare to fight.");
            while (player.Health > 0 && enemy1.Health > 0)
            {
                Console.WriteLine("Which weapon will you choose? Health Values: {0} {1}", player.Health, enemy1.Health);
                for(k = 0; k < player.AmountWeapons; k++)
                {
                    Console.WriteLine("{0}. {1}", k + 1, player.Weapons[k].Name);
                }
                int y = Convert.ToInt32(Console.ReadLine());
                y--;
                if (y >= k)
                {
                    Console.WriteLine("Invalid Weapon");
                }
                else
                {
                    if (player.Weapons[y].Speed < enemy1.Weapon.Speed)
                    {
                        enemy1.Attack(player, enemy1.Weapon.Damage, enemy1.Weapon.Amount);
                        if(player.Health <= 0)
                        {
                            Console.WriteLine("You Died");
                        }
                        else
                        {
                            player.Attack(enemy1, player.Weapons[y].Damage, player.Weapons[y].Amount);
                            if(enemy1.Health <= 0)
                            {
                                Console.WriteLine("You killed the enemy!");
                            }
                        }
                    }
                    else
                    {
                        player.Attack(enemy1, player.Weapons[y].Damage, player.Weapons[y].Amount);
                        if (enemy1.Health <= 0)
                        {
                            Console.WriteLine("You killed the enemy!");
                        }
                        else
                        {
                            enemy1.Attack(player, enemy1.Weapon.Damage, enemy1.Weapon.Amount);
                            if (player.Health <= 0)
                            {
                                Console.WriteLine("You Died");
                            }
                        }
                    }
                }
            }
        }
    }
}
