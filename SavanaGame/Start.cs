using SavanaGameInterface;

namespace SavanaGame
{
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
            IAnimalMover animalMover = new AnimalMover(field);
            IFieldVision fieldReader = new FieldVision(field);
            IFieldChangesFacade fieldChangesFacade = new FieldChangesFacade(animalMover, printer, field);
            IAnimalFactory animalFactory = new AnimalFactory(fieldReader, fieldChangesFacade);
            IAnimalIterator animalIterator = new AnimalIterator(field);
            GameEngine gameEngine = new GameEngine(animalIterator, reader, fieldChangesFacade, animalFactory);
            gameEngine.Run();
        }
    }
}
