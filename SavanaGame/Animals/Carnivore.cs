using SavanaGameInterface;
using System;
using static Enums.Enums;

namespace SavanaGame.Animals
{
    public class Carnivore : Animal, IAnimal
    {
        public Carnivore(IAnimalParams animalParams, IFieldVision fieldReader, IFieldChangesFacade movementFacade) : base(animalParams, fieldReader, movementFacade)
        {
        }

        public override Direction SpecialMove(int xPosition, int yPosition)
        {
            int distanceToTarget = base.AnimalParams.VisionRange * 2;
            Direction direction = Direction.None;
            for (int i = 1; i <= base.AnimalParams.VisionRange; i++)
            {
                for (int j = 0; j <= ((i * 2)); j++)
                {
                    int distaceToCurentTarget;
                    distaceToCurentTarget = i + (Math.Abs(j - i));
                    // target right
                    if (VisionMap[base.AnimalParams.VisionRange + i, base.AnimalParams.VisionRange - i + j] == 'H')
                    {
                        if(distaceToCurentTarget < distanceToTarget)
                        {
                            distanceToTarget = distaceToCurentTarget;
                            direction = Direction.Right;
                        }
                    }
                    //target left
                    if (VisionMap[AnimalParams.VisionRange - i, AnimalParams.VisionRange - i + j] == 'H')
                    {
                        if (distaceToCurentTarget < distanceToTarget)
                        {
                            distanceToTarget = distaceToCurentTarget;
                            direction = Direction.Left;
                        }
                    }
                    //target below
                    if (VisionMap[AnimalParams.VisionRange - i + j, AnimalParams.VisionRange + i] == 'H')
                    {
                        if (distaceToCurentTarget < distanceToTarget)
                        {
                            distanceToTarget = distaceToCurentTarget;
                            direction = Direction.Down;
                        }
                    }
                    //target above
                    if (VisionMap[AnimalParams.VisionRange - i + j, AnimalParams.VisionRange - i] == 'H')
                    {
                        if (distaceToCurentTarget < distanceToTarget)
                        {
                            distanceToTarget = distaceToCurentTarget;
                            direction = Direction.Up;
                        }
                    }
                }
                if (direction != Direction.None)
                {
                    break;
                }
            }
            switch (direction)
            {
                case Direction.Left:
                    if (VisionMap[AnimalParams.VisionRange - 1, AnimalParams.VisionRange] == 'H')
                    {
                        this.Eat();
                    }
                    else if (!ValidateMove(direction))
                    {
                        direction = Direction.None;
                    }
                    break;
                case Direction.Right:
                    if (VisionMap[AnimalParams.VisionRange + 1, AnimalParams.VisionRange] == 'H')
                    {
                        this.Eat();
                    }
                    else if (!ValidateMove(direction))
                    {
                        direction = Direction.None;
                    }
                    break;
                case Direction.Up:
                    if (VisionMap[AnimalParams.VisionRange, AnimalParams.VisionRange - 1] == 'H')
                    {
                        this.Eat();
                    }
                    else if (!ValidateMove(direction))
                    {
                        direction = Direction.None;
                    }
                    break;
                case Direction.Down:

                    if (VisionMap[AnimalParams.VisionRange, AnimalParams.VisionRange + 1] == 'H')
                    {
                        this.Eat();
                    }
                    else if (!ValidateMove(direction))
                    {
                        direction = Direction.None;
                    }
                    break;
            }
            int healthPrecent = (int)Math.Round((double)(100 * AnimalParams.Health) / maxHealth);
            _movementFacade.Move(direction, xPosition, yPosition, healthPrecent);
            return direction;
        }
    }
}
