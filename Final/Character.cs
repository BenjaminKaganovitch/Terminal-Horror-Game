using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Final
{
    class Character
    {

        // Encapsulation
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int MaxHealth { get; protected set; }
        public string TextArt {  get; protected set; }
        public ConsoleColor Color { get; protected set; }
        public Random RandGenerator {  get; protected set; }
        public bool IsDead { get => Health <= 0; } // Source: https://stackoverflow.com/questions/21339589/inlined-setter-and-getter-functions-in-c
        public bool IsAlive { get => Health > 0; }


        public Character(string name, int health, ConsoleColor color, string textArt) 
        { 
            Name = name;
            Health = health;
            MaxHealth = health;
            Color = color;
            TextArt = textArt;
            RandGenerator = new Random();
        }

        public void DisplayInfo()
        {
            ForegroundColor = Color;
            WriteLine($"Enemy: {Name}");
            WriteLine($"\n{TextArt}\n");
            WriteLine($"Health: {Health}");
            ResetColor();
        }


        // Virtual is needed because I need overide
        public virtual void Fight(Character otherCharacter)
        {
            WriteLine("Enemy is fighting!");
        }

        public void TakeDamage(int damageAmount)
        {
            Health -= damageAmount;
            if (Health < 0)
            {
                Health = 0;
            }
        }

        public void DisplayHealthBar()
        {
            ForegroundColor = Color;
            WriteLine($"{Name}'s Health:");
            Write("[");
            // Draw health bits/pts that are filled in
            BackgroundColor = ConsoleColor.Green;
            for (int i = 0; i < Health; i++)
            {
                Write(" ");
            }

            // Draw the rest as not filled in
            BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < (MaxHealth - Health); i++)
            {
                Write(" ");
            }
            ResetColor();
            WriteLine($"] ({Health}/{MaxHealth})");
            
        }
    }
}
