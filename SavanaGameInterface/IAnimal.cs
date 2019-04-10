namespace SavanaGame
{
    public interface IAnimal
    {
        int VisionRange { get; set; }
        int RunSpeed { get; set; }
        char DisplayChar { get; set; }
        bool MoveMade { get; set; }

        int Wander(char[,] map);
        int SpecialMove(char[,] map);
        bool LookAround(char[,] map);
        void Rest();
        void Die();
        void Eat();
    }
}