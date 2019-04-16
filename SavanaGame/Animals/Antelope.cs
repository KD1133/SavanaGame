using SavanaGameInterface;

namespace SavanaGame.Animals
{
    public class Antelope : IAnimalParams
    {
        public int VisionRange { get; set; } = 5;
        public int RunSpeed { get; set; } = 2;
        public char DisplayChar { get; set; } = 'A';
        public int AvarageDiretionDistance { get; set; }  = 1;
        public int WanderRestChance { get; set; }  = 4;
        public bool IsHunter { get; set; } = false;
        public int Health { get; set; } = 200;
    }
}
