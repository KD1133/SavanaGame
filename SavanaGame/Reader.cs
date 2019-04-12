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
                return char.Parse(_consoleFacade.ReadChar().ToString());
            }
            catch
            {
                return ' ';
            }
        }

        public bool KeyPresed()
        {
            if (_consoleFacade.KeyPresed())
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
