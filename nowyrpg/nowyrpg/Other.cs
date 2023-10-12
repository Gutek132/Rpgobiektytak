using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nowyrpg;

namespace nowyrpg
{
    public class Info
    {
        public static void ShowCharacterStats(Character character)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("Class: {0}", character.Class);
            Console.WriteLine("Health: {0}", character.Health);
            Console.WriteLine("Defense: {0}", character.Defense);
            Console.WriteLine("Gold: {0}", character.Gold);
            Console.WriteLine("Attack Power: {0}", character.Attack);
            Console.WriteLine("Num Attacks: {0}", character.NumAttacks);
            Console.WriteLine("==========================");
        }
    }
}