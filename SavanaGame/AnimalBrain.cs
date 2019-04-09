using SavanaGame.Animals;
using SavanaGameInterface;
using System;

namespace SavanaGame
{
    public class AnimalBrain : IAnimalBrain
    {
        private IAnimalMover _animalMover { get; set; }
        private IFieldReader _fieldReader { get; set; }
        private static Random _Rnd = new Random();

        public AnimalBrain(IAnimalMover animalMover, IFieldReader fieldReader)
        {
            _animalMover = animalMover;
            _fieldReader = fieldReader;
        }

        public void Think(IAnimal animal, int xPosition, int yPosition)
        {
            char[,] map = _fieldReader.GetMap(xPosition, yPosition, animal.VisionRange);
            bool SpecialActive = animal.LookAround(map);
            if (SpecialActive)
            {
                int runXPosition = xPosition;
                int runYPosition = yPosition;
                for (int i = 0; i < animal.RunSpeed; i++)
                {
                    var direction = animal.SpecialMove(map);
                    _animalMover.Move(direction, runXPosition, runYPosition);
                    switch (direction)
                    {
                        case 1:
                            runXPosition--;
                            break;
                        case 2:
                            runXPosition++;
                            break;
                        case 3:
                            runYPosition--;
                            break;
                        case 4:
                            runYPosition++;
                            break;
                    }
                    map = _fieldReader.GetMap(runXPosition, runYPosition, animal.VisionRange);
                }
            }
            else
            {
                int rnd = _Rnd.Next(1, 3);
                switch (rnd)
                {
                    case 1:
                        var direction = animal.Wander(map);
                        _animalMover.Move(direction, xPosition, yPosition);
                        break;
                    case 2:
                        animal.Rest();
                        break;
                }
            }
        }
    }
}
