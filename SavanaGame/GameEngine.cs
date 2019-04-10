using SavanaGameInterface;
using System;

namespace SavanaGame
{
    public class GameEngine
    {
        private readonly IAnimalIterator _animalIterator;
        private readonly IReader _reader;
        private readonly IFieldChangesFacade _fieldChangesFacade;
        private static Random _Rnd = new Random();

        public GameEngine(
            IAnimalIterator animalIterator, 
            IReader reader,
            IFieldChangesFacade fieldChangesFacade
            )
        {
            _animalIterator = animalIterator;
            _reader = reader;
            _fieldChangesFacade = fieldChangesFacade;
        }
        
        public void Run()
        {
            System.Console.Read();
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
                    _fieldChangesFacade.Add(animalType, xPosition, yPosition);
                }
            } while (true);
        }
    }
}
