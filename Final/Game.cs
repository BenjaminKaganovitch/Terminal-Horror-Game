using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Media;


namespace Final
{

    // This enum has each item that you can choose from. The weapon is then used to throw. The int will determine the health taken off.
    // We use the switch statment below to turn the contents within this enum into a object. 
    public enum Weapons { Laptop = 3, WaterBottle = 2, Monitor = 5 }

    // Game class
    internal class Game
    {
        // Important objects that are used often.
        private List<Character> Enemies { get; set; }
        private Inventory PlayerWeapon { get; set; }
        private Player CurrentPlayer { get; set; }
        private Character CurrentEnemy { get; set; }

        private int OptionSelect { get; set; } = 0;


        // Creating the objects, and their properties: Health, Text Colour, Name, and RinoCharge Distance
        public Game() 
        {
            Student abtin = new Student("Abtin",5, ConsoleColor.Red, 3);
            Student zack = new Student("Zack", 10, ConsoleColor.DarkBlue, 6);
            Staff andre = new Staff("Andre", 20, ConsoleColor.Magenta);
            Enemies = new List<Character>() { abtin, andre, zack };
        }

        // Prints the options for the menu
        public void MenuPrint()
        {
            WriteLine("1. Play Game");
            WriteLine("2. About Game");
        }

        // Based on your input, the code will either direct you to the about page or the play page.
        // Will also record the user's input on what section in the menu they want. 
        public int GetMenuOption()
        {
            bool condition = false;
            MenuPrint();
            while (!condition)
            {
                int menuNum = Int32.Parse(ReadLine());
                switch (menuNum)
                {
                    case 1:
                        condition = true;
                        Run();
                        break;
                    case 2:
                        condition = true;
                        AboutGameAndAuthor();
                        break;
                    defualt:
                        Console.WriteLine("Error, enter 1 or 2");
                        break;
                }
            }
            Clear();
            return OptionSelect;
        }


        // Prints the backstory to this project
        public void AboutGameAndAuthor()
        {
            Console.WriteLine(@"The game was developed, using c# Console app,in 2022 by a stressed out 17-year old, on 4 days,  who initially had fun with the project but then began to panic as the deadline approuch. The boy at first intended the game to be base versus base setting during the 2nd Word War, where you choose a country and fought another, with a style similar to Clash Royal. 
Added in with some fantasy where say the Nazies where zombies, infected by the accidental lab break out. 
One could argue that Nazies  Zobeing portrayed by Zombies doesnt seem that Fantastical, because the real Fantasy lied with boy thinking he could program that in 4 days, with a heavy school work loud. 
The boy came up with a similar idea. One that involved a battle ship type scenario with 2d arrays, but that ship sailed as well. 
The boy settled on Horror game that exploits people’s fear of creepy music, to hide any design flaws. 
The music however needs to be configured within the code. See c# says that music files need to be stated with their most file location. So any file location held by one person is enterlly different to where another person downloaded the project to. 
At first the game is a typical horror game, where you have no choice over where you go. And the game speaks on its own, and pretends to speak for you as well. 
You get stuck in at MITT and get attacked by students and teachers. Your job is to get out alive, so you defend yourself using things you find on the ground.
If  you win, you escaped, and reach safety! 
");
            GetMenuOption();
        }

        // Carries the game forward, when you defeat one enemy, this code will find the next one for you.
        // While also telling you wether or not you beat your last enemy.
        public void Run()
        {
            PrintBanner();
            RunIntro();
            RunWeaponsMenu();

            for (int i = 0; i < Enemies.Count; i+= 1)
            {
                RunWalking();
                CurrentEnemy = Enemies[i];
                IntroCurrentEnemy();
                BattleCurrentEnemy();

                if (CurrentPlayer.IsDead)
                {
                    WriteLine("You were Deafeated...");
                    WaitForKey();
                    break;
                }
                else
                {
                    WriteLine($"You Defeated {CurrentEnemy.Name}!");
                    WaitForKey();
                }
            }
            RunGameOver();
            WaitForKey();
        }

        // Betwene fights we will walk the halls looking for an escape. 
        // Sound effect for creepy walking.
        private void RunWalking()
        {
            WriteLine("I see some light over there, so Ill just walk that way");
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer spookyPlayer = new SoundPlayer("C:\\Users\\Benjamin\\source\\repos\\Final\\Walking.wav");
                spookyPlayer.Load();
                spookyPlayer.PlayLooping();
            }
            Thread.Sleep(8000);
        }

        // Will Battle the currentEenmy, but first will print out its health bar and ours, then will invoke the Fight method.
        // The code will either gave you a loosing screen or progress you a step furthur depending on if you beat the previouse enemy.
        private void BattleCurrentEnemy()
        {
            while (CurrentPlayer.IsAlive && CurrentEnemy.IsAlive)
            {

                Clear();
                CurrentPlayer.DisplayHealthBar();
                CurrentEnemy.DisplayHealthBar();
                WriteLine();

                CurrentPlayer.Fight(CurrentEnemy);

                WriteLine();
                WaitForKey();

                if (CurrentPlayer.IsDead || CurrentEnemy.IsDead)
                {
                    break;
                }

                Clear();
                CurrentPlayer.DisplayHealthBar();
                CurrentEnemy.DisplayHealthBar();
                WriteLine();

                CurrentEnemy.Fight(CurrentPlayer);
                WaitForKey();
            }
        }

        // Prints the members within the enum Weapons, and adds number for selection process later. 
        private void RunWeaponsMenu()
        {
            int i = 1;
            foreach (string name in Enum.GetNames(typeof(Weapons)))
            {
                Write($"{i++}.");
                WriteLine($"{name}");
            }
            WriteLine();
            SelectWeapon();
        }

        private int GetWeaponChoice()
        {
            ChangeToGameColor("You walked in on a few objects on the ground. You are only strong enough to carry one.");
            OptionSelect = Int32.Parse(ReadLine());
            while (OptionSelect < 0 && OptionSelect > 4)
            {
                OptionSelect = Int32.Parse(ReadLine());
            }
            return OptionSelect;
        }

        // A switch statment and while loop combo, that records which Weapon you want.
        // Then creates an object using the member names and their asssociated values.
        private void SelectWeapon()
        {
            bool isValid = true;
            while (isValid)
            {
                switch (GetWeaponChoice())
                {
                    case 2:
                        WriteLine("Self: Maybe I can power this on somehow and escape.");
                        PlayerWeapon = new Inventory(Weapons.Laptop);
                        isValid = false;
                        break;
                    case 1:
                        WriteLine("Self: I need to stay hydrated. And maybe begin growing my own trees");
                        PlayerWeapon = new Inventory(Weapons.WaterBottle);
                        isValid = false;
                        break;
                    case 3:
                        WriteLine("Self: MITT has too much many on these type of things.");
                        Thread.Sleep(2000);
                        WriteLine("If anything im taking one as my moral compensation");
                        PlayerWeapon = new Inventory(Weapons.Monitor);
                        isValid = false;
                        break;
                    default:
                        WriteLine("Invalid Option");
                        break;

                }
                CurrentPlayer.CurrentItem = PlayerWeapon;
            }
            WaitForKey();
        }

        // This prints the banner for the game, that is a property of TextArt
        private void PrintBanner()
        {
            WriteLine(TextArt.BannerText);
        }
        
        // This is the intro code, that is why its so long
        private void RunIntro()
        {
            SleepTimeForStory(2000);
            WriteLine("911. What is your name?");
            string name = ReadLine();
            CurrentPlayer = new Player(name, 20, ConsoleColor.Green);

            SleepTimeForStory(4000);

            WriteLine($"What is your emergency. {name}, type below:");
            WaitForKey();
            
            WriteLine("We cant help you.");
            SleepTimeForStory(1000);

            WriteLine("The electricity is cut off, besides this remote signal there is no connection. Also the people at MITT are super scary without Wifi. So your on your own.");
            //SleepTimeForStory(1000);

            WriteLine("Within the bag of this emergency kit, there are night googles and a escape map. They dont work well, but its better than nothing.");
            //SleepTimeForStory(1000);

            WriteLine("What building are you in? Type Below");
            GlitchingWaitKey();

            Write("Just rem░░ber one imp░░░ant thi░░░░");
            SleepTimeForStory(1000);

            WriteLine("░░ont w░lk in ░n ░░...");
            SleepTimeForStory(3000);

            ChangeToGameColor("Game: The Connection Broke! Try and find a way out!");
            WaitForKey();
        }

        // Pauses the code excutation to add for dramatic depth
        public void SleepTimeForStory(int microSeconds)
        {
            Thread.Sleep(microSeconds);
            WriteLine();
        }

        // End the game and starts it over again
        private void RunGameOver()
        {
            if (CurrentPlayer.IsDead)
            {
                WriteLine("You Lose!");
            }
            else
            {
                WriteLine("You Win!");
            }
            GetMenuOption();
        }

        // Prints info on the enemy, we will be fighting next, as well as plays the music.
        private void IntroCurrentEnemy()
        {
            // Music files will only run a) if the OS is Windows 
            // b) if you have the set the correct absolute location of the sound files, example below: 

            if (OperatingSystem.IsWindows())
            {                   
                SoundPlayer spookyPlayer = new SoundPlayer("C:\\Users\\Benjamin\\source\\repos\\Final\\Spooky.wav"); 
                spookyPlayer.Load();
                spookyPlayer.Play();
            }
            Clear();
            ForegroundColor = CurrentEnemy.Color;
            WriteLine($"You are about to face {CurrentEnemy.Name}.");
            CurrentEnemy.DisplayInfo();

            ResetColor();
            SleepTimeForStory(2000);
        }

        private void WaitForKey()
        {
            Console.ReadKey(true);
            WriteLine();
        }

        private void GlitchingWaitKey()
        {
            Thread.Sleep(7000);
            Console.ReadKey(true);
        }

        // Yellow text for when the game or the "Player" begins to speak, other than that its just cop
        private void ChangeToGameColor(string text)
        {
            ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
        }
    }
}
