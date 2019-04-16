using SavanaGameInterface;
using System;
using static Enums.Enums;

namespace SavanaGame
{
    public class Printer : IPrinter
    {
        private readonly IConsoleFacade _consoleFacade;
        private const int xOffSet = 1;
        private const int yOffSet = 1;

        public Printer(IConsoleFacade consoleFacade)
        {
            _consoleFacade = consoleFacade;
            DrawBoarder();
        }
        
        public void DrawBoarder()
        {
            _consoleFacade.SetCursorPosition(0, 0);
            _consoleFacade.Write("╔");
            for(int x = 1; x <= Start.Width; x++)
            {
                _consoleFacade.Write("═");
            }
            _consoleFacade.Write("╗");
            for (int y = 1; y <= Start.Height; y++)
            {
                _consoleFacade.SetCursorPosition(0, y);
                _consoleFacade.Write("║");
                _consoleFacade.SetCursorPosition(Start.Width + 1, y);
                _consoleFacade.Write("║");
            }
            _consoleFacade.SetCursorPosition(0, Start.Height + 1);
            _consoleFacade.Write("╚");
            for (int x = 1; x <= Start.Width; x++)
            {
                _consoleFacade.Write("═");
            }
            _consoleFacade.Write("╝");
        }

        public void PrintAdd(IAnimal animal, int xPosition, int yPosition)
        {
            _consoleFacade.SetForegroundColor(ConsoleColor.Green);
            _consoleFacade.SetCursorPosition(xPosition + xOffSet, yPosition + yOffSet);
            _consoleFacade.Write(animal.AnimalParams.DisplayChar.ToString());
            _consoleFacade.SetForegroundColor(ConsoleColor.White);
        }
        
        public void PrintMove(Direction direction, int xPosition, int yPosition, IAnimal animal, int healthPrecent)
        {
            if(healthPrecent > 50)
            {
                _consoleFacade.SetForegroundColor(ConsoleColor.DarkGreen);
            }
            else if(healthPrecent > 25)
            {
                _consoleFacade.SetForegroundColor(ConsoleColor.DarkYellow);
            }
            else
            {
                _consoleFacade.SetForegroundColor(ConsoleColor.DarkRed);
            }
            _consoleFacade.SetCursorPosition(xPosition + xOffSet, yPosition + yOffSet);
            switch (direction)
            {
                case Direction.Left:
                    _consoleFacade.Write(" ");
                    _consoleFacade.SetCursorPosition(xPosition - 1 + xOffSet, yPosition + yOffSet);
                    break;
                case Direction.Right:
                    _consoleFacade.Write(" ");
                    _consoleFacade.SetCursorPosition(xPosition + 1 + xOffSet, yPosition + yOffSet);
                    break;
                case Direction.Up:
                    _consoleFacade.Write(" ");
                    _consoleFacade.SetCursorPosition(xPosition + xOffSet, yPosition - 1 + yOffSet);
                    break;
                case Direction.Down:
                    _consoleFacade.Write(" ");
                    _consoleFacade.SetCursorPosition(xPosition + xOffSet, yPosition + 1 + yOffSet);
                    break;
                default:
                    break;
            }
            _consoleFacade.Write(animal.AnimalParams.DisplayChar.ToString());
            _consoleFacade.SetForegroundColor(ConsoleColor.White);
        }

        public void PrintRemove(int xPosition, int yPosition)
        {
            _consoleFacade.SetCursorPosition(xPosition + xOffSet, yPosition + yOffSet);
            _consoleFacade.Write(" ");
        }
    }
}
