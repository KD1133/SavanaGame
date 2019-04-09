using SavanaGameInterface;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return char.Parse(Console.ReadKey().Key.ToString());
        }
    }
}
