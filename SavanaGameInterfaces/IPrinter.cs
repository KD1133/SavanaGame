
namespace SavanaGame
{
    public interface IPrinter
    {
        void PrintField(IAnimal[,] animals);
        void PrintMove(int direction, int xPosition, int yPosition, IAnimal animal);
    }
}
