using System;

namespace SavanaGame
{
    // movement 1 = left 2 = right 3 = up 4 = down
    // looking 1 = ok 2 = OHSHIT

    public abstract class Animal
    {
        private static Random _Rnd = new Random();
        
        public int VisionRange { get; set; }
        public char DisplayChar { get; set; }
        public int RunSpeed { get; set; }
        
        public int Wander(char[,] map)
        {
            var direction = _Rnd.Next(1, 5);
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
            return direction;
        }

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

        public void Rest()
        {
            
        }
        
        public void Die()
        {

        }

        public void Eat()
        {
            
        }

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
    }
}