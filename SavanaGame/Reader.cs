using SavanaGameInterface;

namespace SavanaGame
{

    class Reader : IReader
    {
        private IConsoleFacade _consoleFacade { get; set; }

        public Reader(IConsoleFacade consoleFacade)
        {
            _consoleFacade = consoleFacade;
        }

        public char ReadChar()
        {
            return _consoleFacade.ReadChar();
        }
    }
}
