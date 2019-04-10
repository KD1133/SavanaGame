using SavanaGameInterface;
using System;

namespace SavanaGame
{
    // movement 1 = left 2 = right 3 = up 4 = down
    // looking 1 = ok 2 = OHSHIT

    public abstract class Animal
    {
        protected readonly IFieldReader _fieldReader;
        protected readonly IFieldChangesFacade _movementFacade;
        protected static Random Rnd = new Random();

        protected Animal(IFieldReader fieldReader, IFieldChangesFacade movementFacade)
        {
            _fieldReader = fieldReader;
            _movementFacade = movementFacade;
        }

        public int VisionRange { get; set; }
        public char DisplayChar { get; set; }
        public int RunSpeed { get; set; }
        public bool MoveMade { get; set; }

        public virtual int Wander(char[,] map)
        {
            if(Rnd.Next(2) == 1)
            {
                return 0;
            }
            var direction = Rnd.Next(1, 5);
            return direction;
        }

        public abstract int SpecialMove(char[,] map);

        public int SpecialMove(char[,] map, char animalThatTrigers, bool hunt)
        {
            int direction = 0;
            for(int i = 1; i <= VisionRange; i++)
            {
                for(int j = 0; j <= ((i * 2)); j++)
                {
                    // target right
                    if (map[VisionRange + i, VisionRange - i + j] == animalThatTrigers)
                    {
                        if (hunt)
                        {
                            direction = 2;
                        }
                        else
                        {
                            direction = 1;
                        }
                        break;
                    }
                    //target left
                    if (map[VisionRange - i, VisionRange - i + j] == animalThatTrigers)
                    {
                        if (hunt)
                        {
                            direction = 1;
                        }
                        else
                        {
                            direction = 2;
                        }
                        break;
                    } 
                    //target below
                    if (map[VisionRange - i + j, VisionRange + i] == animalThatTrigers)
                    {
                        if (hunt)
                        {
                            direction = 4;
                        }
                        else
                        {
                            direction = 3;
                        }
                        break;
                    }
                    //target above
                    if (map[VisionRange - i + j, VisionRange - i] == animalThatTrigers)
                    {
                        if (hunt)
                        {
                            direction = 3;
                        }
                        else
                        {
                            direction = 4;
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
                case 1:
                    if (map[VisionRange - 1, VisionRange] == animalThatTrigers && hunt == true)
                    {
                        this.Eat();
                    }
                    else if (map[VisionRange - 1, VisionRange] != char.Parse("_"))
                    {
                        direction = 0;
                    }
                    break;
                case 2:
                    if (map[VisionRange + 1, VisionRange] == animalThatTrigers && hunt == true)
                    {
                        this.Eat();
                    }
                    else if (map[VisionRange + 1, VisionRange] != char.Parse("_"))
                    {
                        direction = 0;
                    }
                    break;
                case 3:
                    if (map[VisionRange, VisionRange - 1] == animalThatTrigers && hunt == true)
                    {
                        this.Eat();
                    }
                    else if (map[VisionRange, VisionRange - 1] != char.Parse("_"))
                    {
                        direction = 0;
                    }
                    break;
                case 4:
                    if (map[VisionRange, VisionRange + 1] == animalThatTrigers && hunt == true)
                    {
                        this.Eat();
                    }
                    else if (map[VisionRange, VisionRange + 1] != char.Parse("_"))
                    {
                        direction = 0;
                    }
                    break;
            }
            return direction;
        }

        public virtual void Rest()
        {
            
        }
        
        public virtual void Die()
        {

        }

        public virtual void Eat()
        {
            
        }

        public abstract bool LookAround(char[,] map);

        public bool LookAround(char[,] map, char animalThatTrigers)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if(map[x,y] == animalThatTrigers)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Think(int xPosition, int yPosition)
        {
            char[,] map = _fieldReader.GetMap(xPosition, yPosition, VisionRange);
            bool SpecialActive = LookAround(map);
            if (SpecialActive)
            {
                int runXPosition = xPosition;
                int runYPosition = yPosition;
                for (int i = 0; i < RunSpeed; i++)
                {
                    var direction = SpecialMove(map);
                    _movementFacade.Move(direction, runXPosition, runYPosition);
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
                    map = _fieldReader.GetMap(runXPosition, runYPosition, VisionRange);
                }
            }
            else
            {
                var direction = Wander(map);
                switch (direction)
                {
                    case 1:
                        if (map[VisionRange - 1, VisionRange] != '_')
                        {
                            direction = 0;
                        }
                        break;
                    case 2:
                        if (map[VisionRange + 1, VisionRange] != char.Parse("_"))
                        {
                            direction = 0;
                        }
                        break;
                    case 3:
                        if (map[VisionRange, VisionRange - 1] != char.Parse("_"))
                        {
                            direction = 0;
                        }
                        break;
                    case 4:
                        if (map[VisionRange, VisionRange + 1] != char.Parse("_"))
                        {
                            direction = 0;
                        }
                        break;
                }
                _movementFacade.Move(direction, xPosition, yPosition);
            }
        }
    }
}