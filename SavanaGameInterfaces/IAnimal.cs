
namespace SavanaGame
{
    public interface IAnimal
    {
        int VisionRange { get; set; }
        char DisplayChar { get; set; }

        int Move();
        void LookAround();
        void Rest();
        void Die();
        void Eat();
    }
}