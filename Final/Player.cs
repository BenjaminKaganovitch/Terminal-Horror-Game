using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console; 

namespace Final
{
    class Player : Character
    {
        public Inventory CurrentItem;

        public Player(string name, int health, ConsoleColor color) 
            : base(name, health, color, Final.TextArt.Player)
        {

        }
        public void PickUpItem(Inventory item)
        {
            CurrentItem = item;
        }


        // Wind Pipe attack will attack, and hit the wind pipe of any enemy getting in the way
        private void WindPipeAttack(Character otherCharacter)
        {
            Write($"Break Teeth Attak");
            int randPercent = RandGenerator.Next(1, 101);
            if (randPercent > 50)
            {
                WriteLine($" You use your fist and break {otherCharacter.Name}'s windpipe in their throat.");
                otherCharacter.TakeDamage(4);
            }

            else
            {
                WriteLine("You miss because your arms are too shivery");
            }
        }

        // Throw Item attack is only for the player, hence why in player class
        // Throw Item attack will use the current item that we have saved, to throw, the user wont know if landed untill the end
        private void ThrowItem(Character otherCharacter)
        {
            int randPercent = RandGenerator.Next(1, 101);
            if (randPercent <= 50)
            {
                WriteLine($"You throw your {CurrentItem.WeaponName} at {otherCharacter.Name}");
                Thread.Sleep(500);
                WriteLine("Its in the air!");
                Thread.Sleep(600);
                WriteLine("Almost there!");
                Thread.Sleep(500);
                WriteLine("It lands");
                otherCharacter.TakeDamage(CurrentItem.PowerLevel);
            }

            else
            {
                WriteLine($"You throw the {CurrentItem.WeaponName} at {otherCharacter.Name}");
                Thread.Sleep(500);
                WriteLine("Its in the air!");
                Thread.Sleep(600);
                WriteLine("Almost there!");
                Thread.Sleep(500);
                WriteLine($"{otherCharacter.Name} Blocked the shot!");
            }
        }


        // Same fight method as for Student and Staff, but this one is for the defensive party. 
        // Will use Key numbers on keybourd, to select attacks, just like PC gaming
        public override void Fight(Character otherCharacter)
        {
            ForegroundColor = Color;
            WriteLine($@"You are facing {otherCharacter.Name}. What would you like to do?
                        1) Break Teeth Attack.
                        2) Throw Item Attack.");

            ConsoleKeyInfo keyInfo = ReadKey(true);
            if (keyInfo.Key == ConsoleKey.D1)
            {
                WindPipeAttack(otherCharacter);
            }

            else if (keyInfo.Key == ConsoleKey.D2)
            {
                ThrowItem(otherCharacter);
            }
            else
            {
                WriteLine("Thats not a vaild move. Try again");
                Fight(otherCharacter);
                return; 
            }
            ResetColor();
        }

    }
}
