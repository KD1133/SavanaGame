using SavanaGame;

namespace SavanaGameInterface
{
    public interface IFieldChangesFacade
    {
        void Move(int direction, int xPosition, int yPosition);
        void Add(int animalType, int xPosition, int yPosition);
        void Remove(int xPosition, int yPosition);

    }
}
