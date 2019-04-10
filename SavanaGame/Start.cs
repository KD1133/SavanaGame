using SavanaGameInterface;

namespace SavanaGame
{
    public enum Direction { Up, Down, Left, Right };

    public class Start
    {
        public static int Width = 60;
        public static int Height = 30;

        public void Run()
        {
            IConsoleFacade consoleFacade = new CosoleFacade();
            IPrinter printer = new Printer(consoleFacade);
            IReader reader = new Reader(consoleFacade);
            IAnimal[,] field = new IAnimal[Width, Height];
            IAnimal[,] oldField = new IAnimal[Width, Height];
            IFields fields = new Fields(field, oldField);
            IAnimalMover animalMover = new AnimalMover(fields);
            IFieldReader fieldReader = new FieldReader(field);
            IFieldChangesFacade fieldChangesFacade = new FieldChangesFacade(animalMover, printer, fields);
            IAnimalFactory animalFactory = new AnimalFactory(fieldReader, fieldChangesFacade);
            IAnimalIterator animalIterator = new AnimalIterator(fields);
            GameEngine gameEngine = new GameEngine(animalIterator, reader, fieldChangesFacade, animalFactory);
            gameEngine.Run();
        }
    }
}
