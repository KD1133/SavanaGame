using SavanaGameInterface;

namespace SavanaGame.Animals
{
    public class Lion : IAnimalParams
    {
        public int VisionRange { get; set; } = 6;
        public int RunSpeed { get; set; } = 3;
        public char DisplayChar { get; set; } = 'L';
        public int AvarageDiretionDistance { get; set; } = 7;
        public int WanderRestChance { get; set; } = 0;
        public bool IsHunter { get; set; } = true;
        public int Health { get; set; } = 200;
    }
}
