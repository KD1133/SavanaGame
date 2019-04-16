using SavanaGameInterface;
using static Enums.Enums;

namespace SavanaGame
{
    public class FieldChangesFacade : IFieldChangesFacade
    {
        private readonly IAnimalMover _animalMover;
        private readonly IPrinter _printer;

        private IAnimal[,] field { get; set; }

        public FieldChangesFacade(IAnimalMover animalMover, 
            IPrinter printer,
            IAnimal[,] field
            )
        {
            _animalMover = animalMover;
            _printer = printer;
            this.field = field;
        }

        public void Move(Direction direction, int xPosition, int yPosition, int healthPrecent)
        {
            _printer.PrintMove(direction, xPosition, yPosition, field[xPosition, yPosition], healthPrecent);
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
