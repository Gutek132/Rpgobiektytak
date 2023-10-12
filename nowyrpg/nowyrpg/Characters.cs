using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nowyrpg
{
    public class Creature
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
        public int Gold { get; set; }

        public void Suicide()
        {
            Health = 0;
        }
        public void TakeDamage(int damage)
        {
            Health -= Math.Max(damage - Defense, 0);
        }
        public virtual void Attack1(Creature enemy)
        {
            enemy.TakeDamage(Attack);
        }
    }

    public class Character : Creature
    {
        public string Class { get; set; }
        public int NumAttacks { get; set; }
        public int MaxHp { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }
        public Inventory Inventory { get; set; }


        public Character(string class_, int numAttacks, int maxhp, int health, int attackPower, int defense)
        {
            Class = class_;
            NumAttacks = numAttacks;
            MaxHp = maxhp;
            Health = health;
            Attack = attackPower;
            Defense = defense;
            Level = 1;
            XP = 0;
            Inventory = new Inventory();
        }
        public void ShowStats()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("Health: {0}", Health);
            Console.WriteLine("Defense: {0}", Defense);
            Console.WriteLine("Attack Power: {0}", Attack);
            Console.WriteLine("Gold {0}", Gold);
            Console.WriteLine("Level {0}", Level);
            Console.WriteLine("XP {0}/100", XP);
            Console.WriteLine("==========================");
        }
        public static void GainXP(Character character, Monster monster)
        {
            character.XP += monster.Xp;
            if (character.XP >= 100)
            {
                LevelUp(character);
            }
        }
        private static void LevelUp(Character character)
        {
            character.Level++;
            character.XP = 0;
            character.Attack += 10;
            character.Defense += 5;
            character.MaxHp += 20;
            character.Health += 20;
        }
        public static void Heal(Character character)
        {
            character.Health = character.MaxHp;
            Console.WriteLine("Now you have max hp");
        }

        public override void Attack1(Creature enemy)
        {
            for (int i = 0; i < NumAttacks; i++)
            {
                enemy.TakeDamage(Attack);
                Console.WriteLine("===========================");
                Console.WriteLine("You dealt {0} damage to the {1}.", Attack, enemy.Name);
                Console.WriteLine("The {1} has {0} health remaining.", enemy.Health, enemy.Name);
                Console.WriteLine("===========================");
            }
        }

    }

    public class Warrior : Character
    {
        public Warrior() : base("Warrior", 2, 100, 100, 10, 5)
        {
        }
    }

    public class Mage : Character
    {
        public Mage() : base("Mage", 1, 100, 100, 20, 0)
        {
        }
    }

    public class Monster : Creature
    {
        public int MonAttackPower { get; set; }
        public int MonDefensePower { get; set; }
        public int Xp { get; set; }


        public Monster(string name)
        {
            Name = name;
            Health = 40;
            MonAttackPower = 5;
            MonDefensePower = 0;
            Xp = 20;
            Gold = 20;
        }
        public override void Attack1(Creature enemy)
        {
                enemy.TakeDamage(MonAttackPower);
        }
    }

}
