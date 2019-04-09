using SavanaGame;

namespace SavanaGameInterface
{
    public interface IFields
    {
        IAnimal[,] Curent { get; set; }
        IAnimal[,] Old { get; set; }
    }
}
