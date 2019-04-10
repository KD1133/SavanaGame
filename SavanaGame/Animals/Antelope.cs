using SavanaGameInterface;

namespace SavanaGame.Animals
{
    class Antelope : Animal , IAnimal
    {
        public Antelope(IFieldReader fieldReader, IFieldChangesFacade movementFacade) : base(fieldReader, movementFacade)
        {
            VisionRange = 4;
            RunSpeed = 2;
            DisplayChar = 'A';
        }

        public override bool LookAround(char[,] map)
        {
            return base.LookAround(map, 'L');
        }

        public override int SpecialMove(char[,] map)
        {
            return base.SpecialMove(map, 'L', false);
        }
    }
}
