using SavanaGameInterface;

namespace SavanaGame
{
    public class AnimalIterator : IAnimalIterator
    {
        private IAnimal[,] field { get; set; }

        public AnimalIterator(IAnimal[,] field)
        {
            this.field = field;
        }

        public void Iterate()
        {
            var oldField = field.Clone() as IAnimal[,];
            for(int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    if (oldField[x,y] != null && oldField[x, y].AnimalParams.DisplayChar == 'A')
                    {
                        field[x, y].Think(x, y);
                    }
                }
            }
            for (int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    if (oldField[x, y] != null && oldField[x, y].AnimalParams.DisplayChar == 'L')
                    {
                        field[x, y].Think(x, y);
                    }
                }
            }
        }
    }
}
