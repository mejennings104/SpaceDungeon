using DungeonLibrary;

namespace MonsterLibrary
{
    public class Monster : Character
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

        public Monster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) : base(name, hitChance, block, maxLife, life)
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
        public static Monster GetMonster()
        {
            Monster spaceGoop = new Monster("Space Goop", 30, 30, 70, 8, 8, 12, "Not very scary but watch out, they bite!" );
            Monster giantSpaceAnts = new Monster("Giant Space Ants", 25, 25, 85, 6, 10, 14, "They're everywhere!");
            Monster floatingOrb = new Monster("Floating Orb", 28, 28, 60, 3, 16, 20, "The light before the light at the end of the tunnel!");

            List<Monster> monsters = new List<Monster>()
            {
                spaceGoop, spaceGoop,
                floatingOrb, floatingOrb,
                giantSpaceAnts, giantSpaceAnts
            };
            return monsters[new Random().Next(monsters.Count)]; 
        }
    }
}