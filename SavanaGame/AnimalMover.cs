using SavanaGameInterface;

namespace SavanaGame
{


    public class AnimalMover : IAnimalMover
    {
        private IFields _fields { get; set; }
        private IPrinter _printer { get; set; }
        
        public AnimalMover(IFields fields, IPrinter printer)
        {
            _fields = fields;
            _printer = printer;
        }

        public void Move(int direction, int xPosition, int yPosition)
        {
            switch (direction)
            {
                case 1:
                    _fields.Curent[xPosition - 1, yPosition] = _fields.Curent[xPosition, yPosition];
                    _fields.Old[xPosition - 1, yPosition] = null;
                    break;
                case 2:
                    _fields.Curent[xPosition + 1, yPosition] = _fields.Curent[xPosition, yPosition];
                    _fields.Old[xPosition + 1, yPosition] = null;
                    break;
                case 3:
                    _fields.Curent[xPosition, yPosition - 1] = _fields.Curent[xPosition, yPosition];
                    _fields.Old[xPosition, yPosition - 1] = null;
                    break;
                case 4:
                    _fields.Curent[xPosition, yPosition + 1] = _fields.Curent[xPosition, yPosition];
                    _fields.Old[xPosition, yPosition + 1] = null;
                    break;
                default:
                    return;
            }
            //_printer.PrintMove(direction, xPosition, yPosition, _fields.Curent[xPosition, yPosition]);
            _fields.Curent[xPosition, yPosition] = null;
        }

        public void Add(IAnimal animal, int xPosition, int yPosition)
        {
            _fields.Curent[xPosition, yPosition] = animal;
            //_printer.PrintAdd(animal, xPosition, yPosition);
        }

        public void Remove(int xPosition, int yPosition)
        {
            //_printer.PrintRemove(xPosition, yPosition);
            _fields.Curent[xPosition, yPosition] = null;
        }
    }
}
