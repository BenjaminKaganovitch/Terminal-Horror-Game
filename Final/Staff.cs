using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Final
{
    class Staff : Character
    {
        private bool HasSharpNails;
        
        public Staff( string name, int health, ConsoleColor color)
            :base(name, health, color, Final.TextArt.Staff)
        {
            RandGenerator = new Random();
        }
        // An attack that has stages and deals damage over a longer period of time
        public void InflictAneurysm(Character otherCharacter)
        {
            BackgroundColor = Color;
            Write($"{Name} ");
            ResetColor();
            WriteLine($"{Name} puts his fingers on his head, does aneurysm on you");

            otherCharacter.TakeDamage(1);
            AneurysmSound();

            Thread.Sleep(1000);
            otherCharacter.TakeDamage(2);

            AneurysmSound();
            Thread.Sleep(1000);
            otherCharacter.TakeDamage(3);
         
        }

        // Onomatopoeia for the Aneurysm, to spook user
        public void AneurysmSound()
        {
            WriteLine("Pew, da, da, pew");
        }

        // Overide
        //Just lke in student. This uses random chance to determine which attack to use
        public override void Fight(Character otherCharacter)
        {

            ForegroundColor = Color;
            WriteLine($" {Name} is fighting {otherCharacter.Name}!");
            ResetColor();
            int randNum = RandGenerator.Next(1, 101);
            if (randNum < 50)
            {
                if (randNum > 15)
                {
                    InflictAneurysm(otherCharacter);
                }

                else
                {
                    KeySlash(otherCharacter);
                }
            }
            else
            {
                WriteLine($"{Name} missed their attack");
            }
            ResetColor();
        }
        public void KeySlash(Character otherCharacter)
        {
            BackgroundColor = Color;
            Write($"{Name}");
            ResetColor();
            WriteLine($"{Name} pulls out their keys, and does slashing");
            otherCharacter.TakeDamage(4);
        }

        
    }
}
