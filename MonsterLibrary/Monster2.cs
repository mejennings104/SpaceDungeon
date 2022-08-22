using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLibrary
{
    public class Monster2 : Character
    {
        public int MaxDamage { get; set; }

        private int _minDamage;

        public string Description { get; set; }

        private string _description;

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > MaxDamage || value < 1)
                {
                    _minDamage = 1;
                }

                else
                {
                    _minDamage = value;
                }
            }
        }

        public Monster2(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) : base(name, hitChance, block, maxLife, life)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;

        }
        public override string ToString()
        {
            return $@"
**--**-- MONSTER --**--**
{Name}
Life: {Life} of {MaxLife}
Damage: {MinDamage} to {MaxDamage}
Block: {Block}
Description:
{Description}
";

        }

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }
        public static Monster2 GetMonster()
        {
            Monster2 spacePirate = new Monster2("Space Pirate", 45, 45, 80, 9, 15, 18, "Arrrggghh!");
            Monster2 spaceDino = new Monster2("Space Dino", 50, 50, 70, 5, 20, 24, "You thought they were extinct...");

            List<Monster2> monsters = new List<Monster2>()
            {
                spacePirate, spaceDino
            };
            return monsters[new Random().Next(monsters.Count)];

        }

    }
}
