namespace DungeonLibrary
{
    public class Character
    {
        private int _life;
        private string _name;
        private int _hitChance;
        private int _block;
        private int _maxLife;
        private string _description;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }
        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        public int Life
        {
            get { return _life; }
            set
            {
                _life = value <= MaxLife ? value : MaxLife;
            }
        }
        public Character(string name, int hitChance, int block, int maxLife, int life)
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = life;
        }
        public Character()
        {

        }
        public override string ToString()
        {
            return string.Format("----- {0} -----\n" +
                "Life: {1} of {2}" +
                "\nHit Chance: {3}%\n" +
                "Block: {4}" +
                Name,
                Life,
                MaxLife,
                CalcHitChance(),
                Block);
        }//end ToString() override

        public virtual int CalcBlock()
        {
            return Block;
        }//end CalcBlock

        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end CalcHitChance

        public virtual int CalcDamage()
        {
            return CalcDamage();
        }
        public virtual int CalcMaxLife()
        {
            return MaxLife;
        }

    }
}