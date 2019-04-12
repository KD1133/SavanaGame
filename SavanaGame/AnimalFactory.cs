using SavanaGame.Animals;
using SavanaGameInterface;

namespace SavanaGame
{
    class AnimalFactory : IAnimalFactory
    {
        protected readonly IFieldVision _fieldReader;
        protected readonly IFieldChangesFacade _movementFacade;

        public AnimalFactory(IFieldVision fieldReader, IFieldChangesFacade movementFacade)
        {
            _fieldReader = fieldReader;
            _movementFacade = movementFacade;
        }

        public IAnimal SpawnAnimal(int animalId)
        {
            IAnimal animal = null;
            switch (animalId)
            {
                case 0:
                    animal = new Antelope(_fieldReader, _movementFacade);
                    break;
                case 1:
                    animal = new Lion(_fieldReader, _movementFacade);
                    break;
            }
            return animal;
        }
    }
}
