using SavanaGameInterface;

namespace SavanaGame
{
    public class FieldVision : IFieldVision
    {
        private readonly IAnimal[,] _field;

        public FieldVision(IAnimal[,] field)
        {
            _field = field;
        }
        
        public IAnimal ReadCell(int xPosition, int yPosition)
        {
            if(NotOutOfBunds(xPosition,yPosition))
            {
                return _field[xPosition - 1, yPosition - 1];
            }

            return null;
        }

        public bool NotOutOfBunds(int xPosition, int yPosition)
        {
            if (xPosition > _field.GetLength(0) || yPosition > _field.GetLength(1) || xPosition - 1 < 0|| yPosition - 1 < 0)
            {
                return false;
            }
            return true;
        }

        public char[,] GetMap(int xPosition, int yPosition, int range)
        {
            char[,] map = new char[range*2 + 1, range * 2 + 1];
            int i = 0;
            for (int x = (xPosition + 1 - range); x < (xPosition + 1 + range + 1); x++)
            {
                int j = 0;
                for (int y = (yPosition + 1 - range); y < (yPosition + 1 + range + 1); y++)
                {
                    var animal = ReadCell(x, y);
                    if(animal != null)
                    {
                        if (animal.AnimalParams.IsHunter)
                        {
                            map[i, j] = 'C';
                        }
                        else
                        {
                            map[i, j] = 'H';
                        }
                    }
                    else
                    {
                        if (NotOutOfBunds(x, y))
                        {
                            map[i, j] = char.Parse("_");
                        }
                    }
                    j++;
                }
                i++;
            }
            return map;
        }
    }
}
