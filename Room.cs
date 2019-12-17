using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedAdventure
{
    class Room
    {
        #region Constructor/Helper
        public Room(Player player, int choice)
        {
            if (choice == 1)
            {
                GenerateRoom(player);
            }
            else if (choice == 2)
            {
                Mythical mythical = new Mythical(2);
                SpecialRoom(player, mythical);
            }
            else if (choice == 3)
            {
                Mythical mythical = new Mythical(1);
                SpecialRoom(player, mythical);
            }
        }
        public void GenerateRoom(Player player)
        {
            int x;
            x = Globals.random.Next(1, 9);
            if(x == 10)
            {
            
            }
            else
            {
                x = Globals.random.Next(1, 3);
                if(x == 1)
                {
                    StartEncounter(player, 1);
                }
                else if(x == 2)
                {
                    StartEncounter(player, 2);
                }
                else
                {
                    StartEncounter(player, 3);
                }
            }
        }
        #endregion
        public void SpecialRoom(Player player, Mythical enemy)
        {
            int k, wepIndex, specialAttk;
            Console.WriteLine("This room seems different, but by now you know the drill and figure that you should prepare to fight.");
            Console.WriteLine("You recognize your mistake the second that the {0} appears", enemy.Name);
            while (player.Health > 0 && enemy.Health > 0)
            {
                Console.WriteLine("Which weapon shall you use?");
                for (k = 0; k < player.AmountWeapons; k++)
                {
                    Console.WriteLine("{0}. {1}", k + 1, player.Weapons[k].Name);
                }
                wepIndex = Convert.ToInt32(Console.ReadLine());
                wepIndex--;
                if (wepIndex >= k || wepIndex < 0)
                {
                    Console.WriteLine("Invalid Weapon");
                }
                else
                {
                    Console.WriteLine("Would you like to special attack with your weapon?");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");
                    specialAttk = Convert.ToInt32(Console.ReadLine());
                    if (specialAttk == 1)
                    {
                        if (player.Weapons[wepIndex].Speed > enemy.Weapon.Speed)
                        {
                            player.Weapons[wepIndex].SpecialAttack(player, enemy);
                            if (enemy.Health > 0)
                            {
                                enemy.Attack(player, enemy.Special.Damage, enemy.Special.Amount);
                                if (enemy.Special.Damage - player.ArmorThresh > 0)
                                    Console.WriteLine("You are attacked by {0} for {1} damage you have {2} health remaining", enemy.Name, (enemy.Special.Amount * (enemy.Special.Damage - player.ArmorThresh)), player.Health);
                                else
                                    Console.WriteLine("You are attacked by {0} for 1 damage you {1} health remaining", enemy.Name, player.Health);
                            }
                        }
                        else
                        {
                            enemy.Attack(player, enemy.Special.Damage, enemy.Special.Amount);
                            if (enemy.Special.Damage - player.ArmorThresh > 0)
                                Console.WriteLine("You are attacked by {0} for {1} damage you have {2} health remaining", enemy.Name, (enemy.Special.Amount * (enemy.Special.Damage - player.ArmorThresh)), player.Health);
                            else
                                Console.WriteLine("You are attacked by {0} for 1 damage you {1} health remaining", enemy.Name, player.Health);
                            if (player.Health > 0)
                            {
                                player.Weapons[wepIndex].SpecialAttack(player, enemy);
                            }
                        }
                    }
                    else if (specialAttk == 2)
                    {
                        if (player.Weapons[wepIndex].Speed > enemy.Weapon.Speed)
                        {
                            player.Weapons[wepIndex].BasicAttack(player, enemy);
                            if (enemy.Health > 0)
                            {
                                enemy.Attack(player, enemy.Special.Damage, enemy.Special.Amount);
                                if (enemy.Special.Damage - player.ArmorThresh > 0)
                                    Console.WriteLine("You are attacked by {0} for {1} damage you have {2} health remaining", enemy.Name, (enemy.Special.Amount * (enemy.Special.Damage - player.ArmorThresh)), player.Health);
                                else
                                    Console.WriteLine("You are attacked by {0} for 1 damage you {1} health remaining", enemy.Name, player.Health);
                            }
                        }
                        else
                        {
                            enemy.Attack(player, enemy.Special.Damage, enemy.Special.Amount);
                            if (enemy.Special.Damage - player.ArmorThresh > 0)
                                Console.WriteLine("You are attacked by {0} for {1} damage you have {2} health remaining", enemy.Name, (enemy.Special.Amount * (enemy.Special.Damage - player.ArmorThresh)), player.Health);
                            else
                                Console.WriteLine("You are attacked by {0} for 1 damage you {1} health remaining", enemy.Name, player.Health);
                            if (player.Health > 0)
                            {
                                player.Weapons[wepIndex].BasicAttack(player, enemy);
                            }
                        }
                    }
                }
            }
        }
        private void StartEncounter(Player player, int amtEne)
        {
            int k, i, j, totalhealth = 0, wepIndex, eneIndex, specialAttk, prevHealth, postHealth;
            Enemy[] enemies = new Enemy[amtEne];
            Console.WriteLine("You Enter the room and the door shuts behind you, cliche I know.");
            Console.WriteLine("Soon after {0} shady looking figure(s) enters. You prepare to fight.", amtEne);
            for(k = 0; k < amtEne; k++)
            {
                enemies[k] = Enemy.GenerateEnemy();
                totalhealth += enemies[k].Health;
            }
            while (player.Health > 0 && totalhealth > 0)
            {
                Console.WriteLine("Which weapon shall you use?");
                for(k = 0; k < player.AmountWeapons; k++)
                {
                    Console.WriteLine("{0}. {1}", k + 1, player.Weapons[k].Name);
                }
                wepIndex = Convert.ToInt32(Console.ReadLine());
                wepIndex--;
                if (wepIndex >= k || wepIndex < 0)
                {
                    Console.WriteLine("Invalid Weapon");
                }
                else
                {
                    Console.WriteLine("And which enemy shall you attack?");
                    for (i = 0; i < amtEne; i++)
                    {
                        if(enemies[i].IsDead == false)
                            Console.WriteLine("{0}. {1}", i + 1, enemies[i].Name);
                    }
                    eneIndex = Convert.ToInt32(Console.ReadLine());
                    eneIndex--;
                    if(eneIndex >= i || i < 0 || enemies[eneIndex].IsDead == true)
                    {
                        Console.WriteLine("Invalid Enemy");
                    }
                    else
                    {
                        Console.WriteLine("Would you like to special attack with your weapon?");
                        Console.WriteLine("1. Yes");
                        Console.WriteLine("2. No");
                        specialAttk = Convert.ToInt32(Console.ReadLine());
                        if (specialAttk == 1)
                        {
                            if (player.Weapons[wepIndex].Speed > enemies[eneIndex].Weapon.Speed)
                            {
                                prevHealth = enemies[eneIndex].Health;
                                player.Weapons[wepIndex].SpecialAttack(player, enemies[eneIndex]);
                                postHealth = enemies[eneIndex].Health;
                                if (postHealth < 0)
                                    postHealth = 0;
                                totalhealth -= (prevHealth - postHealth);
                                if (enemies[eneIndex].Health <= 0)
                                {
                                    enemies[eneIndex].Die();
                                }
                                else
                                {
                                    for (j = 0; j < amtEne; j++)
                                    {
                                        if (enemies[j].IsDead == false)
                                        {
                                            enemies[j].Attack(player, enemies[j].Weapon.Damage, enemies[j].Weapon.Amount);
                                            if (enemies[j].Weapon.Damage - player.ArmorThresh > 0)
                                                Console.WriteLine("You are attacked by {0} for {1} damage you have {2} health remaining", enemies[j].Name, (enemies[j].Weapon.Amount * (enemies[j].Weapon.Damage - player.ArmorThresh)), player.Health);
                                            else
                                                Console.WriteLine("You are attacked by {0} for 1 damage you {1} health remaining", enemies[j].Name, player.Health);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (j = 0; j < amtEne; j++)
                                {
                                    if (enemies[j].IsDead == false)
                                    {
                                        enemies[j].Attack(player, enemies[j].Weapon.Damage, enemies[j].Weapon.Amount);
                                        if (enemies[j].Weapon.Damage - player.ArmorThresh > 0)
                                            Console.WriteLine("You are attacked by {0} for {1} damage you have {2} health remaining", enemies[j].Name, (enemies[j].Weapon.Amount * (enemies[j].Weapon.Damage - player.ArmorThresh)), player.Health);
                                        else
                                            Console.WriteLine("You are attacked by {0} for 1 damage you {1} health remaining", enemies[j].Name, player.Health);
                                    }
                                }

                                prevHealth = enemies[eneIndex].Health;
                                player.Weapons[wepIndex].SpecialAttack(player, enemies[eneIndex]);
                                postHealth = enemies[eneIndex].Health;
                                if (postHealth < 0)
                                    postHealth = 0;
                                totalhealth -= (prevHealth - postHealth);
                                if (enemies[eneIndex].Health <= 0)
                                {
                                    enemies[eneIndex].Die();
                                }
                            }
                        }
                        else if (specialAttk == 2)
                        {
                            if (player.Weapons[wepIndex].Speed > enemies[eneIndex].Weapon.Speed)
                            {
                                prevHealth = enemies[eneIndex].Health;
                                player.Weapons[wepIndex].BasicAttack(player, enemies[eneIndex]);
                                postHealth = enemies[eneIndex].Health;
                                if (postHealth < 0)
                                    postHealth = 0;
                                totalhealth -= (prevHealth - postHealth);
                                if (enemies[eneIndex].Health <= 0)
                                {
                                    enemies[eneIndex].Die();
                                }
                                else
                                {
                                    for (j = 0; j < amtEne; j++)
                                    {
                                        if (enemies[j].IsDead == false)
                                        {
                                            enemies[j].Attack(player, enemies[j].Weapon.Damage, enemies[j].Weapon.Amount);
                                            if (enemies[j].Weapon.Damage - player.ArmorThresh > 0)
                                                Console.WriteLine("You are attacked by {0} for {1} damage you have {2} health remaining", enemies[j].Name, (enemies[j].Weapon.Amount * (enemies[j].Weapon.Damage - player.ArmorThresh)), player.Health);
                                            else
                                                Console.WriteLine("You are attacked by {0} for 1 damage you {1} health remaining", enemies[j].Name, player.Health);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (j = 0; j < amtEne; j++)
                                {
                                    if (enemies[j].IsDead == false)
                                    {
                                        enemies[j].Attack(player, enemies[j].Weapon.Damage, enemies[j].Weapon.Amount);
                                        if (enemies[j].Weapon.Damage - player.ArmorThresh > 0)
                                            Console.WriteLine("You are attacked by {0} for {1} damage you have {2} health remaining", enemies[j].Name, (enemies[j].Weapon.Amount * (enemies[j].Weapon.Damage - player.ArmorThresh)), player.Health);
                                        else
                                            Console.WriteLine("You are attacked by {0} for 1 damage you {1} health remaining", enemies[j].Name, player.Health);
                                    }
                                }

                                prevHealth = enemies[eneIndex].Health;
                                player.Weapons[wepIndex].BasicAttack(player, enemies[eneIndex]);
                                postHealth = enemies[eneIndex].Health;
                                if (postHealth < 0)
                                    postHealth = 0;
                                totalhealth -= (prevHealth - postHealth);
                                if (enemies[eneIndex].Health <= 0)
                                {
                                    enemies[eneIndex].Die();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid option");
                        }
                    }
                }
            }
            Console.WriteLine("You slew everything in the room YOUR AMAZING GAURDI... wrong game");
        }
    }
}
