using SavanaGameInterface;
using System;

namespace SavanaGame
{
    public class GameEngine
    {
        private readonly IAnimalIterator _animalIterator;
        private readonly IReader _reader;
        private readonly IFieldChangesFacade _fieldChangesFacade;
        private readonly IAnimalFactory _animalFactory;
        private static Random _Rnd = new Random();

        public GameEngine(
            IAnimalIterator animalIterator, 
            IReader reader,
            IFieldChangesFacade fieldChangesFacade,
            IAnimalFactory animalFactory 
            )
        {
            _animalIterator = animalIterator;
            _reader = reader;
            _fieldChangesFacade = fieldChangesFacade;
            _animalFactory = animalFactory;
        }
        
        public void Run()
        {
            do {
                while (!_reader.KeyPresed())
                {
                    _animalIterator.Iterate();
                    System.Threading.Thread.Sleep(200);
                }
                char input = _reader.ReadChar();
                int xPosition = _Rnd.Next(1, Start.Width);
                int yPosition = _Rnd.Next(1, Start.Height);
                int animalType = -1;
                switch (input)
                {
                    case 'A':
                        animalType = 0;
                        break;
                    case 'L':
                        animalType = 1;
                        break;
                }
                if(animalType >= 0)
                {
                    IAnimal animal = _animalFactory.SpawnAnimal(animalType);
                    _fieldChangesFacade.Add(animal, xPosition, yPosition);
                }
            } while (true);
        }
    }
}
