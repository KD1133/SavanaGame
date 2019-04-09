using SavanaGameInterface;

namespace SavanaGame
{
    public class Fields : IFields
    {
        public IAnimal[,] Curent { get; set; }
        public IAnimal[,] Old { get; set; }

        public Fields(IAnimal[,] curent, IAnimal[,] old)
        {
            Curent = curent;
            Old = old;
        }
    }
}
