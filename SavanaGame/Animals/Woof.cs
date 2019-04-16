using SavanaGameInterface;

namespace SavanaGame.Animals
{
    class Woof : IAnimalParams
    {
        public int VisionRange { get; set; } = 5;
        public int RunSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int AvarageDiretionDistance { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int WanderRestChance { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool IsHunter { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public char DisplayChar { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
