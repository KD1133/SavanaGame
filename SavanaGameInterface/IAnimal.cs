using static Enums.Enums;

namespace SavanaGame
{
    public interface IAnimal
    {
        int VisionRange { get; set; }
        int RunSpeed { get; set; }
        char DisplayChar { get; set; }
        bool IsHunter { get; set; }
        char SpecialTrigerAnimal { get; set; }
        char MoveTargetAnimal { get; set; }

        Direction Wander();
        Direction SpecialMove();
        bool LookAround();
        void Rest();
        void Die();
        void Eat();
        void Think(int xPosition, int yPosition);
    }
}