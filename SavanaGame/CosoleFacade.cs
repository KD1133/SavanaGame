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

        public char ReadChar()
        {
            return char.Parse(Console.ReadKey(true).Key.ToString());
        }

        public bool KeyPresed()
        {
            if (Console.KeyAvailable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
