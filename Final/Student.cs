using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Final
{
    class Student : Character
    {
        private int Distance;
        private Inventory CurrentItem;
        

        public Student(string name, int health, ConsoleColor color, int chargeDistance)
            : base(name, health, color, Final.TextArt.Student)
        {
            Distance = chargeDistance;  
        }


        // RinoAttack: The student will charge and attack.
        public void RinoAttack(Character otherCharacter) 
        {
            BackgroundColor = Color;
            Write($"{Name}");
            ResetColor();
            WriteLine($" runs super sain, covering {Distance} meters. And does 6 Damage HeadButting!");
            otherCharacter.TakeDamage(6);

        }


        // Uses random numbers to determine which attack to use or not to use.
        public override void Fight(Character otherCharacter)
        {
            ForegroundColor = Color;

            int randPercent = RandGenerator.Next(1, 101);
            int randNum = RandGenerator.Next(1, 101);

            if (randPercent <= 60)
            {
                if (randNum <= 30)
                {
                    Stabs(otherCharacter);
                }

                else
                {
                    RinoAttack(otherCharacter);
                }
            }

            else
            {
                WriteLine($"{Name} missed their attack");
            }
            ResetColor();
        }



        // Stabs:This code will get the student to attack you and deal 4 pts of dama fro
        public void Stabs(Character otherCharacter)
        {

            ResetColor();
            Write($" {Name} ");
            BackgroundColor = Color;
            WriteLine($"Stabs you from behind in your stomach! And Does 4 Damage!");
            otherCharacter.TakeDamage(4);
        }

    }
}
