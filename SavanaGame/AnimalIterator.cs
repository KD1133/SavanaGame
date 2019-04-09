using SavanaGameInterface;
using System;

namespace SavanaGame
{
    public class AnimalIterator : IAnimalIterator
    {
        private IFields _fields { get; set; }
        private IAnimalBrain _animalBrain { get; set; }

        public AnimalIterator(IFields fields, IAnimalBrain animalBrain)
        {
            _fields = fields;
            _animalBrain = animalBrain;
        }

        public void Iterate()
        {
            _fields.Old = _fields.Curent.Clone() as IAnimal[,];
            for(int x = 0; x < _fields.Curent.GetLength(0); x++)
            {
                for (int y = 0; y < _fields.Curent.GetLength(1); y++)
                {
                    if (_fields.Old[x,y] != null)
                    {
                        _animalBrain.Think(_fields.Curent[x, y], x, y);
                    }
                }
            }
        }
    }
}
