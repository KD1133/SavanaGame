﻿using SavanaGame;

namespace SavanaGameInterface
{
    public interface IFieldReader
    {
        IAnimal ReadCell(int xPosition, int yPosition);

        bool NotOutOfBunds(int xPosition, int yPosition);

        char[,] GetMap(int xPosition, int yPosition, int range);
    }
}
