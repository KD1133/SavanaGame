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
            return _consoleFacade.ReadChar();
        }

        public bool KeyPresed()
        {
            return _consoleFacade.KeyPresed();
        }
    }
}
