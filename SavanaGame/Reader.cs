using SavanaGameInterface;

namespace SavanaGame
{

    class Reader : IReader
    {
        private readonly IConsoleFacade _consoleFacade;

        public Reader(IConsoleFacade consoleFacade)
        {
            _consoleFacade = consoleFacade;
        }

        public char ReadChar()
        {
            try
            {
                return _consoleFacade.ReadChar();
            }
            catch
            {
                return ' ';
            }
        }

        public bool KeyPresed()
        {
            return _consoleFacade.KeyPresed();
        }
    }
}
