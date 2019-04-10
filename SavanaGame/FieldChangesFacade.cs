using SavanaGameInterface;

namespace SavanaGame
{
    public class FieldChangesFacade : IFieldChangesFacade
    {
        private readonly IAnimalMover _animalMover;
        private readonly IPrinter _printer;
        private readonly IFields _fields;

        public FieldChangesFacade(IAnimalMover animalMover, 
            IPrinter printer, 
            IFields fields
            )
        {
            _animalMover = animalMover;
            _printer = printer;
            _fields = fields;
        }

        public void Move(int direction, int xPosition, int yPosition)
        {
            _printer.PrintMove(direction, xPosition, yPosition, _fields.Curent[xPosition, yPosition]);
            _animalMover.Move(direction, xPosition, yPosition);
        }

        public void Add(IAnimal animal, int xPosition, int yPosition)
        {
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
