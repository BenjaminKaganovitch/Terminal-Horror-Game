using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    class Inventory
    {

        // This recives the int and string, from the enum that stores the name of the attack and its strength
        // We later use this strength, to take off health from the player in the player class
        // Note: this only stores the strength and name from the weapon we choose on the weapon menu. 

        public int PowerLevel { get; private set; }
        public string WeaponName {get;private set; }
        

        public Inventory(Weapons w)
        {
            WeaponName = w.ToString();
            PowerLevel = (int)w;
        }
    }
}
