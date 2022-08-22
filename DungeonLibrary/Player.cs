using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {
        private Race _characterRace;

        public Race CharacterRace
        {
            get { return _characterRace; }
            set { _characterRace = value; }
        }

        private Weapon _equippedWeapon;

        public Weapon EquippedWeapon
        {
            get { return _equippedWeapon; }
            set { _equippedWeapon = value; }
        }



        public Player(string name,
              int hitChance,
              int block,
              int maxLife,
              int life,              
              Race characterRace,
              Weapon equippedWeapon) : base(name, hitChance, block, maxLife, life)
        {
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;

            switch (CharacterRace)
            {

                case Race.ZenithWarrior:
                    MaxLife += 100;
                    Life += 100;
                    break;
                case Race.PlinianAssassin:
                    MaxLife += 80;
                    Life += 80;
                    
                    break;
                case Race.OyvindClone:
                    break;
                case Race.CyborgOctopus:
                    break;
                    
            }   


        }
        public override string ToString()
        {
            string description = "";
            switch (CharacterRace)
            {
                case Race.ZenithWarrior:
                    description = "Zenith Warrior";
                    break;
                case Race.PlinianAssassin:
                    description = "Plinian Gasser";
                    break;
                case Race.OyvindClone:
                    description = "Oyvind Absorber";
                    break;
                case Race.CyborgOctopus:
                    description = "Cyborg Octopus";
                    break;
                default:
                    break;
            }
            return base.ToString() + $"\nWeapon: {EquippedWeapon.Name}\n";
        }
        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }

        public override int CalcDamage()
        {
            Random rand = new Random();

            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);

            return damage;

        }
        public override int CalcMaxLife()
        {
            return base.MaxLife + 20;
        }

    }
}
