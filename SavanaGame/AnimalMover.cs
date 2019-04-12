using static Enums.Enums;

namespace SavanaGame
{


    public class AnimalMover : IAnimalMover
    {

        private IAnimal[,] field { get; set; }

        public AnimalMover(IAnimal[,] field)
        {
            this.field = field;
        }

        public void Move(Direction direction, int xPosition, int yPosition)
        {
            switch (direction)
            {
                case Direction.Left:
                    field[xPosition - 1, yPosition] = field[xPosition, yPosition];
                    break;
                case Direction.Right:
                    field[xPosition + 1, yPosition] = field[xPosition, yPosition];
                    break;
                case Direction.Up:
                    field[xPosition, yPosition - 1] = field[xPosition, yPosition];
                    break;
                case Direction.Down:
                    field[xPosition, yPosition + 1] = field[xPosition, yPosition];
                    break;
                default:
                    return;
            }
             field[xPosition, yPosition] = null;
        }

        public void Add(IAnimal animal, int xPosition, int yPosition)
        {
            field[xPosition, yPosition] = animal;
        }

        public void Remove(int xPosition, int yPosition)
        {
            field[xPosition, yPosition] = null;
        }
    }
}
