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

        protected Animal(IFieldVision fieldReader, IFieldChangesFacade movementFacade)
        {
            _fieldReader = fieldReader;
            _movementFacade = movementFacade;
        }

        public int VisionRange { get; set; }
        public char DisplayChar { get; set; }
        public int RunSpeed { get; set; }
        public bool IsHunter { get; set; }
        public char SpecialTrigerAnimal { get; set; }
        public char MoveTargetAnimal { get; set; }
        protected char[,] VisionMap { get; set; }
        protected int TimeToRest { get; set; }
        protected int DangerDirection { get; set; }


        public virtual Direction Wander()
        {
            if(Rnd.Next(2) == 1)
            {
                return 0;
            }
            int rnd = Rnd.Next(1, 5);
            Direction direction = (Direction)Enum.Parse(typeof(Direction), rnd.ToString());
            return direction;
        }

        public Direction SpecialMove()
        {
            Direction direction = Direction.None;
            for(int i = 1; i <= VisionRange; i++)
            {
                for(int j = 0; j <= ((i * 2)); j++)
                {
                    // target right
                    if (VisionMap[VisionRange + i, VisionRange - i + j] == MoveTargetAnimal)
                    {
                        if (IsHunter)
                        {
                            direction = Direction.Right;
                        }
                        else
                        {
                            direction = Direction.Left;
                        }
                        break;
                    }
                    //target left
                    if (VisionMap[VisionRange - i, VisionRange - i + j] == MoveTargetAnimal)
                    {
                        if (IsHunter)
                        {
                            direction = Direction.Left;
                        }
                        else
                        {
                            direction = Direction.Right;
                        }
                        break;
                    } 
                    //target below
                    if (VisionMap[VisionRange - i + j, VisionRange + i] == MoveTargetAnimal)
                    {
                        if (IsHunter)
                        {
                            direction = Direction.Down;
                        }
                        else
                        {
                            direction = Direction.Up;
                        }
                        break;
                    }
                    //target above
                    if (VisionMap[VisionRange - i + j, VisionRange - i] == MoveTargetAnimal)
                    {
                        if (IsHunter)
                        {
                            direction = Direction.Up;
                        }
                        else
                        {
                            direction = Direction.Down;
                        }
                        break;
                    }
                }
                if (direction != 0)
                {
                    break;
                }
            }
            switch (direction)
            {
                case Direction.Left:
                    if (VisionMap[VisionRange - 1, VisionRange] == MoveTargetAnimal && IsHunter == true)
                    {
                        this.Eat();
                    }
                    else if (VisionMap[VisionRange - 1, VisionRange] != char.Parse("_"))
                    {
                        direction = Direction.None;
                    }
                    break;
                case Direction.Right:
                    if (VisionMap[VisionRange + 1, VisionRange] == MoveTargetAnimal && IsHunter == true)
                    {
                        this.Eat();
                    }
                    else if (VisionMap[VisionRange + 1, VisionRange] != char.Parse("_"))
                    {
                        direction = Direction.None;
                    }
                    break;
                case Direction.Up:
                    if (VisionMap[VisionRange, VisionRange - 1] == MoveTargetAnimal && IsHunter == true)
                    {
                        this.Eat();
                    }
                    else if (VisionMap[VisionRange, VisionRange - 1] != char.Parse("_"))
                    {
                        direction = Direction.None;
                    }
                    break;
                case Direction.Down:
                    if (VisionMap[VisionRange, VisionRange + 1] == MoveTargetAnimal && IsHunter == true)
                    {
                        this.Eat();
                    }
                    else if (VisionMap[VisionRange, VisionRange + 1] != char.Parse("_"))
                    {
                        direction = Direction.None;
                    }
                    break;
            }
            return direction;
        }

        public virtual void Rest()
        {
            if(TimeToRest > 0)
            {
                TimeToRest--;
            }
        }
        
        public virtual void Die()
        {

        }

        public virtual void Eat()
        {
            TimeToRest = 10;
        }

        public bool LookAround()
        {
            for (int x = 0; x < VisionMap.GetLength(0); x++)
            {
                for (int y = 0; y < VisionMap.GetLength(1); y++)
                {
                    if(VisionMap[x,y] == SpecialTrigerAnimal)
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
                    if (VisionMap[VisionRange - 1, VisionRange] != '_')
                    {
                        return false;
                    }
                    break;
                case Direction.Right:
                    if (VisionMap[VisionRange + 1, VisionRange] != char.Parse("_"))
                    {
                        return false;
                    }
                    break;
                case Direction.Up:
                    if (VisionMap[VisionRange, VisionRange - 1] != char.Parse("_"))
                    {
                        return false;
                    }
                    break;
                case Direction.Down:
                    if (VisionMap[VisionRange, VisionRange + 1] != char.Parse("_"))
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }

        public void Think(int xPosition, int yPosition)
        {
            if(TimeToRest > 0)
            {
                Rest();
                return; //if animal needs to rest rest and do nothing;
            }
            VisionMap = _fieldReader.GetMap(xPosition, yPosition, VisionRange);
            bool SpecialActive = LookAround();
            if (SpecialActive)
            {
                int runXPosition = xPosition;
                int runYPosition = yPosition;
                for (int i = 0; i < RunSpeed; i++)
                {
                    var direction = SpecialMove();
                    _movementFacade.Move(direction, runXPosition, runYPosition);
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
                    VisionMap = _fieldReader.GetMap(runXPosition, runYPosition, VisionRange);
                }
            }
            else
            {
                var direction = Wander();
                if (!ValidateMove(direction))
                {
                    direction = Direction.None;
                }
                _movementFacade.Move(direction, xPosition, yPosition);
            }
        }
    }
}