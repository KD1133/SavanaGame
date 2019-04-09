using SavanaGameInterface;

namespace SavanaGame
{
    public class GameEngine
    {
        private IAnimalFactory _animalFactory { get; set; }
        private IAnimalIterator _animalIterator { get; set; }
        private IAnimalMover _animalMover { get; set; }
        private IReader _reader { get; set; }

        public GameEngine(
            IAnimalFactory animalFactory, 
            IAnimalIterator animalIterator, 
            IAnimalMover animalMover, 
            IReader reader)
        {
            _animalFactory = animalFactory;
            _animalIterator = animalIterator;
            _animalMover = animalMover;
            _reader = reader;
        }
        
        public void Run()
        {
            IAnimal animal = _animalFactory.SpawnAnimal(1);
            _animalMover.Add(animal, 20, 20);
            animal = _animalFactory.SpawnAnimal(0);
            _animalMover.Add(animal, 22, 20);
            animal = _animalFactory.SpawnAnimal(0);
            _animalMover.Add(animal, 18, 20);
            animal = _animalFactory.SpawnAnimal(0);
            _animalMover.Add(animal, 20, 22);
            animal = _animalFactory.SpawnAnimal(0);
            _animalMover.Add(animal, 20, 18);
            System.Console.Read();
            do {
                _animalIterator.Iterate();
                System.Threading.Thread.Sleep(1000);
            } while (true);
        }
    }
}
