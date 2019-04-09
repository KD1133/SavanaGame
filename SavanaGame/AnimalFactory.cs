using SavanaGame.Animals;

namespace SavanaGame
{
    class AnimalFactory : IAnimalFactory
    {
        public IAnimal SpawnAnimal(int animalId)
        {
            IAnimal animal = null;
            switch (animalId)
            {
                case 0:
                    animal = new Antelope();
                    break;
                case 1:
                    animal = new Lion();
                    break;
            }
            return animal;
        }
    }
}
