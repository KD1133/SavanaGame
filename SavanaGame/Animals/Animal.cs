using SavanaGameInterface;
using System;
using static Enums.Enums;

namespace SavanaGame
{
    // movement 1 = left 2 = right 3 = up 4 = down
    // looking 1 = ok 2 = OHSHIT

    public abstract class Animal
    {
        protected readonly IFieldVision _fieldReader;
        protected readonly IFieldChangesFacade _movementFacade;
        protected static Random Rnd = new Random();

        protected Animal(IAnimalParams animalParams, IFieldVision fieldReader, IFieldChangesFacade movementFacade)
        {
            AnimalParams = animalParams; 
            _fieldReader = fieldReader;
            _movementFacade = movementFacade;
            maxHealth = AnimalParams.Health;
        }

        protected int maxHealth { get; set; }
        public IAnimalParams AnimalParams { get; set; }
        public Direction WanderDirection { get; set; }
        protected char[,] VisionMap { get; set; }
        protected int TimeToRest { get; set; }
        public Direction SpecialMoveDirection { get; set; }


        public virtual void Wander(int xPosition, int yPosition)
        {
            int rnd = Rnd.Next(1, AnimalParams.AvarageDiretionDistance);
            if (rnd == 1)
            {
                rnd = Rnd.Next(1, 5 + AnimalParams.WanderRestChance);
                switch (rnd)
                {
                    case 1:
                        WanderDirection = Direction.Left;
                        break;
                    case 2:
                        WanderDirection = Direction.Right;
                        break;
                    case 3:
                        WanderDirection = Direction.Up;
                        break;
                    case 4:
                        WanderDirection = Direction.Down;
                        break;
                    default:
                        WanderDirection = 0;
                        break;

                }

            }
            if (!ValidateMove(WanderDirection))
            {
                switch (WanderDirection)
                {
                    case Direction.Right:
                        WanderDirection = Direction.Left;
                        break;
                    case Direction.Left:
                        WanderDirection = Direction.Right;
                        break;
                    case Direction.Up:
                        WanderDirection = Direction.Down;
                        break;
                    case Direction.Down:
                        WanderDirection = Direction.Up;
                        break;
                }
            }
            if (!ValidateMove(WanderDirection))
            {
                WanderDirection = Direction.None;
            }

            int healthPrecent = (int)Math.Round((double)(100 * AnimalParams.Health) / maxHealth);
            _movementFacade.Move(WanderDirection, xPosition, yPosition, healthPrecent);
        }

        public abstract Direction SpecialMove(int xPosition, int yPosition);
        
        public bool LookAround()
        {
            char trigerAnimal = 'C';
            if (AnimalParams.IsHunter == true)
            {
                trigerAnimal = 'H';
            }
            for (int x = 0; x < VisionMap.GetLength(0); x++)
            {
                for (int y = 0; y < VisionMap.GetLength(1); y++)
                {
                    if(VisionMap[x,y] == trigerAnimal)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected bool ValidateMove(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    if (VisionMap[AnimalParams.VisionRange - 1, AnimalParams.VisionRange] != '_')
                    {
                        return false;
                    }
                    break;
                case Direction.Right:
                    if (VisionMap[AnimalParams.VisionRange + 1, AnimalParams.VisionRange] != '_')
                    {
                        return false;
                    }
                    break;
                case Direction.Up:
                    if (VisionMap[AnimalParams.VisionRange, AnimalParams.VisionRange - 1] != '_')
                    {
                        return false;
                    }
                    break;
                case Direction.Down:
                    if (VisionMap[AnimalParams.VisionRange, AnimalParams.VisionRange + 1] != '_')
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }

        public virtual void Rest()
        {
            AnimalParams.Health = AnimalParams.Health + 1;
            if (TimeToRest > 0)
            {
                TimeToRest--;
            }
        }

        public virtual void Die(int xPosition, int yPosition)
        {
            _movementFacade.Remove(xPosition, yPosition);
        }

        public virtual void Eat()
        {
            AnimalParams.Health = AnimalParams.Health + 100;
            if (AnimalParams.Health > maxHealth)
            {
                AnimalParams.Health = maxHealth;
            }
            TimeToRest = 10;
        }

        public void Think(int xPosition, int yPosition)
        {
            AnimalParams.Health = AnimalParams.Health - 1;
            if (AnimalParams.Health <= 0)
            {
                Die(xPosition, yPosition);
                return; //if animal died, die and do nothing;
            }
            if (TimeToRest > 0)
            {
                Rest();
                return; //if animal needs to rest, rest and do nothing;
            }
            VisionMap = _fieldReader.GetMap(xPosition, yPosition, AnimalParams.VisionRange);
            bool SpecialActive = LookAround();
            if (SpecialActive)
            {
                int runXPosition = xPosition;
                int runYPosition = yPosition;
                for (int i = 0; i < AnimalParams.RunSpeed && TimeToRest <= 0 ; i++)
                {
                    Direction direction = SpecialMove(runXPosition, runYPosition);
                    switch (direction)
                    {
                        case Direction.Left:
                            runXPosition--;
                            break;
                        case Direction.Right:
                            runXPosition++;
                            break;
                        case Direction.Up:
                            runYPosition--;
                            break;
                        case Direction.Down:
                            runYPosition++;
                            break;
                    }
                    VisionMap = _fieldReader.GetMap(runXPosition, runYPosition, AnimalParams.VisionRange);
                }
            }
            else
            {
                Wander(xPosition,yPosition);
            }
        }
    }
}