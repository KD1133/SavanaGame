using static Enums.Enums;

namespace SavanaGame
{
    public interface IPrinter
    {
        void PrintMove(Direction direction, int xPosition, int yPosition, IAnimal animal, int healthPrecent);
        void PrintAdd(IAnimal animal, int xPosition, int yPosition);
        void PrintRemove(int xPosition, int yPosition);
    }
}
