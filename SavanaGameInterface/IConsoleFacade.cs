namespace SavanaGameInterface
{
    public interface IConsoleFacade
    {
        void SetCursorPosition(int xPosition, int yPosition);
        void Write(string strToWrite);
        char ReadChar();
        bool KeyPresed();
    }
}
