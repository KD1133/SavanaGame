using SavanaGameInterface;
using System;

namespace SavanaGame
{
    public class Printer : IPrinter
    {
        private IConsoleFacade _consoleFacade { get; set; }

        public Printer(IConsoleFacade consoleFacade)
        {
            _consoleFacade = consoleFacade;
        }
        
        public void PrintAdd(IAnimal animal, int xPosition, int yPosition)
        {
            Console.SetCursorPosition(xPosition, yPosition);
            Console.Write(animal.DisplayChar.ToString());
        }

        public void PrintField(IAnimal[,] animals)
        {
            for(int y = animals.GetLength(1) - 1; y >= 0; y--)
            {
                for(int x = 0; x < animals.GetLength(0); x++)
                {
                    Console.SetCursorPosition(x,y);
                    if(animals[x, y] != null)
                    {
                        Console.Write(animals[x, y].DisplayChar.ToString());
                    }
                }
            }
        }

        public void PrintMove(int direction, int xPosition, int yPosition, IAnimal animal)
        {
            Console.SetCursorPosition(xPosition, yPosition);
            Console.Write(" ");
            switch (direction)
            {
                case 1:
                    Console.SetCursorPosition(xPosition - 1, yPosition);
                    break;
                case 2:
                    Console.SetCursorPosition(xPosition + 1, yPosition);
                    break;
                case 3:
                    Console.SetCursorPosition(xPosition, yPosition - 1);
                    break;
                case 4:
                    Console.SetCursorPosition(xPosition, yPosition + 1);
                    break;
                default:
                    break;
            }
            Console.Write(animal.DisplayChar.ToString());
        }

        public void PrintRemove(int xPosition, int yPosition)
        {
            Console.SetCursorPosition(xPosition, yPosition);
            Console.Write(" ");
        }
    }
}
