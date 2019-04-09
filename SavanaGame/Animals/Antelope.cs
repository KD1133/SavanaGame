namespace SavanaGame.Animals
{
    class Antelope : Animal , IAnimal
    {
        public Antelope()
        {
            VisionRange = 4;
            RunSpeed = 2;
            DisplayChar = char.Parse("A");
        }

        public bool LookAround(char[,] map)
        {
            return base.LookAround(map, char.Parse("L"));
        }

        public int SpecialMove(char[,] map)
        {
            return base.SpecialMove(map, char.Parse("L"), false);
        }
    }
}
