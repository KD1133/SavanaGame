using SavanaGameInterface;

namespace SavanaGame
{
    public enum Direction { Up, Down, Left, Right };

    public class Startup
    {
        public void Run()
        {
            IConsoleFacade consoleFacade = new CosoleFacade();
            IPrinter printer = new Printer(consoleFacade);
            IReader reader = new Reader(consoleFacade);
            IAnimal[,] field = new IAnimal[100, 50];
            IAnimal[,] oldField = new IAnimal[100, 50];
            IFields fields = new Fields(field, oldField);
            IAnimalFactory animalFactory = new AnimalFactory();
            IAnimalMover animalMover = new AnimalMover(fields, printer);
            IFieldReader fieldReader = new FieldReader(field);
            IAnimalBrain animalBrain = new AnimalBrain(animalMover,fieldReader);
            IAnimalIterator animalIterator = new AnimalIterator(fields, animalBrain);
            GameEngine gameEngine = new GameEngine(animalFactory, animalIterator, animalMover, reader);
            gameEngine.Run();
        }
    }
}
