using SavanaGameInterface;
using System;
namespace SavanaGame
{
    public class CosoleFacade : IConsoleFacade
    {
        public void SetCursorPosition(int xPosition, int yPosition)
        {
            Console.SetCursorPosition(xPosition,yPosition);
        }

        public void Write(string strToWrite)
        {
            Console.Write(strToWrite);
        }

        public ConsoleKey ReadChar()
        {
            return Console.ReadKey(true).Key;
        }

        public bool KeyPresed()
        {
            return Console.KeyAvailable;
        }
    }
}
