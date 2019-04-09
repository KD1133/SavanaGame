namespace SavanaGame.Animals
{
    class Lion : Animal , IAnimal
    {
        public Lion()
        {
            VisionRange = 5;
            RunSpeed = 3;
            DisplayChar = char.Parse("L");
        }

        public bool LookAround(char[,] map)
        {
            return base.LookAround(map, char.Parse("A"));
        }

        public int SpecialMove(char[,] map)
        {
           return base.SpecialMove(map, char.Parse("A"), true);
        }
    }
}
