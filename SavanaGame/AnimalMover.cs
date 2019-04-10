using SavanaGameInterface;

namespace SavanaGame
{


    public class AnimalMover : IAnimalMover
    {
        private readonly IFields _fields;
        
        public AnimalMover(IFields fields)
        {
            _fields = fields;
        }

        public void Move(int direction, int xPosition, int yPosition)
        {
            switch (direction)
            {
                case 1:
                    _fields.Curent[xPosition - 1, yPosition] = _fields.Curent[xPosition, yPosition];
                    break;
                case 2:
                    _fields.Curent[xPosition + 1, yPosition] = _fields.Curent[xPosition, yPosition];
                    break;
                case 3:
                    _fields.Curent[xPosition, yPosition - 1] = _fields.Curent[xPosition, yPosition];
                    break;
                case 4:
                    _fields.Curent[xPosition, yPosition + 1] = _fields.Curent[xPosition, yPosition];
                    break;
                default:
                    return;
            }
            _fields.Curent[xPosition, yPosition] = null;
        }

        public void Add(IAnimal animal, int xPosition, int yPosition)
        {
            _fields.Curent[xPosition, yPosition] = animal;
        }

        public void Remove(int xPosition, int yPosition)
        {
            _fields.Curent[xPosition, yPosition] = null;
        }
    }
}
