using System;

namespace SavanaGameInterface
{
    public interface IConsoleFacade
    {
        void SetCursorPosition(int xPosition, int yPosition);
        void Write(string strToWrite);
        ConsoleKey ReadChar();
        bool KeyPresed();
        void SetForegroundColor(ConsoleColor color);
    }
}
