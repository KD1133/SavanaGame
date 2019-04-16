using SavanaGame;
using static Enums.Enums;

namespace SavanaGameInterface
{
    public interface IFieldChangesFacade
    {
        void Move(Direction direction, int xPosition, int yPosition, int healthPrecent);
        void Add(IAnimal animal, int xPosition, int yPosition);
        void Remove(int xPosition, int yPosition);

    }
}
