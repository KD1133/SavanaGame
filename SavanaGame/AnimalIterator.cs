using SavanaGameInterface;

namespace SavanaGame
{
    public class AnimalIterator : IAnimalIterator
    {
        private readonly IFields _fields;

        public AnimalIterator(IFields fields)
        {
            _fields = fields;
        }

        public void Iterate()
        {
            _fields.Old = _fields.Curent.Clone() as IAnimal[,];
            for(int x = 0; x < _fields.Curent.GetLength(0); x++)
            {
                for (int y = 0; y < _fields.Curent.GetLength(1); y++)
                {
                    if (_fields.Old[x,y] != null && _fields.Old[x, y].DisplayChar == 'A')
                    {
                        _fields.Curent[x, y].Think(x, y);
                    }
                }
            }
            for (int x = 0; x < _fields.Curent.GetLength(0); x++)
            {
                for (int y = 0; y < _fields.Curent.GetLength(1); y++)
                {
                    if (_fields.Old[x, y] != null && _fields.Old[x, y].DisplayChar == 'L')
                    {
                        _fields.Curent[x, y].Think(x, y);
                    }
                }
            }
        }
    }
}
