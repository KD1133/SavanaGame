namespace SavanaGame
{
    public interface IPrinter
    {
        void PrintMove(int direction, int xPosition, int yPosition, IAnimal animal);
        void PrintAdd(IAnimal animal, int xPosition, int yPosition);
        void PrintRemove(int xPosition, int yPosition);
    }
}
