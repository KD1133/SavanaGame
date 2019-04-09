using SavanaGame;

namespace SavanaGameInterface
{
    public interface IAnimalBrain
    {
        void Think(IAnimal animal, int xPosition, int yPosition);
    }
}
