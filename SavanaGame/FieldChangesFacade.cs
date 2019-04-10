using SavanaGameInterface;

namespace SavanaGame
{
    public class FieldChangesFacade : IFieldChangesFacade
    {
        private readonly IAnimalMover _animalMover;
        private readonly IAnimalFactory _animalFactory;
        private readonly IPrinter _printer;
        private readonly IFields _fields;

        public FieldChangesFacade(IAnimalMover animalMover,IAnimalFactory animalFactory , IPrinter printer, IFields fields)
        {
            _animalMover = animalMover;
            _printer = printer;
            _fields = fields;
            _animalFactory = animalFactory;
        }

        public void Move(int direction, int xPosition, int yPosition)
        {
            _printer.PrintMove(direction, xPosition, yPosition, _fields.Curent[xPosition, yPosition]);
            _animalMover.Move(direction, xPosition, yPosition);
        }

        public void Add(int animalType, int xPosition, int yPosition)
        {
            IAnimal animal = _animalFactory.SpawnAnimal(animalType);
            _animalMover.Add(animal, xPosition, yPosition);
            _printer.PrintAdd(animal, xPosition, yPosition);
        }

        public void Remove(int xPosition, int yPosition)
        {
            _printer.PrintRemove(xPosition, yPosition);
            _animalMover.Remove(xPosition, yPosition);
        }
    }
}
