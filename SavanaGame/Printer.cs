using SavanaGameInterface;
using System;

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
            _consoleFacade.SetCursorPosition(xPosition + xOffSet, yPosition + yOffSet);
            _consoleFacade.Write(animal.DisplayChar.ToString());
        }
        
        public void PrintMove(int direction, int xPosition, int yPosition, IAnimal animal)
        {
            _consoleFacade.SetCursorPosition(xPosition + xOffSet, yPosition + yOffSet);
            switch (direction)
            {
                case 1:
                    _consoleFacade.Write(" ");
                    _consoleFacade.SetCursorPosition(xPosition - 1 + xOffSet, yPosition + yOffSet);
                    break;
                case 2:
                    _consoleFacade.Write(" ");
                    _consoleFacade.SetCursorPosition(xPosition + 1 + xOffSet, yPosition + yOffSet);
                    break;
                case 3:
                    _consoleFacade.Write(" ");
                    _consoleFacade.SetCursorPosition(xPosition + xOffSet, yPosition - 1 + yOffSet);
                    break;
                case 4:
                    _consoleFacade.Write(" ");
                    _consoleFacade.SetCursorPosition(xPosition + xOffSet, yPosition + 1 + yOffSet);
                    break;
                default:
                    break;
            }
            _consoleFacade.Write(animal.DisplayChar.ToString());
        }

        public void PrintRemove(int xPosition, int yPosition)
        {
            _consoleFacade.SetCursorPosition(xPosition + xOffSet, yPosition + yOffSet);
            _consoleFacade.Write(" ");
        }
    }
}
