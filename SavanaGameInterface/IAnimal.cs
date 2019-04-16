using SavanaGameInterface;
using static Enums.Enums;

namespace SavanaGame
{
    public interface IAnimal
    {
        IAnimalParams AnimalParams { get; set; }

        void Wander(int xPosition, int yPosition);
        Direction SpecialMove(int xPosition, int yPosition);
        bool LookAround();
        void Rest();
        void Die(int xPosition, int yPosition);
        void Eat();
        void Think(int xPosition, int yPosition);
    }
}