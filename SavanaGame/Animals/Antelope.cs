using SavanaGameInterface;

namespace SavanaGame.Animals
{
    class Antelope : Animal , IAnimal
    {
        public Antelope(IFieldVision fieldReader, IFieldChangesFacade movementFacade) : base(fieldReader, movementFacade)
        {
            VisionRange = 5;
            RunSpeed = 2;
            DisplayChar = 'A';
            IsHunter = false;
            SpecialTrigerAnimal = 'L';
            MoveTargetAnimal = 'L';
        }
    }
}
