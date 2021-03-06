﻿namespace SavanaGame
{
    public interface IAnimalController
    {
        void Move(int direction, int xPosition, int yPosition);
        void Add(IAnimal animal, int xPosition, int yPosition);
        void Remove(int xPosition, int yPosition);
    }
}