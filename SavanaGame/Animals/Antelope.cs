namespace SavanaGame.Animals
{
    class Antelope : Animal , IAnimal
    {
        public Antelope()
        {
            VisionRange = 4;
            RunSpeed = 2;
            DisplayChar = 'A';
        }

        public bool LookAround(char[,] map)
        {
            return base.LookAround(map, 'L');
        }

        public int SpecialMove(char[,] map)
        {
            return base.SpecialMove(map, 'L', false);
        }
    }
}
