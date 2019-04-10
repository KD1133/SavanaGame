using SavanaGameInterface;
using System;

namespace SavanaGame
{
    public class AnimalBrain : IAnimalBrain
    {
        private readonly IFieldReader _fieldReader;
        private readonly IFieldChangesFacade _movementFacade;
        private static Random _Rnd = new Random();

        public AnimalBrain(
            IFieldReader fieldReader,
            IFieldChangesFacade movementFacade
            )
        {
            _fieldReader = fieldReader;
            _movementFacade = movementFacade;
        }

        public void Think(IAnimal animal, int xPosition, int yPosition)
        {
        }
    }
}
