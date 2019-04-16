namespace SavanaGameInterface
{
    public interface IAnimalParams
    {
        int VisionRange { get; set; }
        int RunSpeed { get; set; }
        int AvarageDiretionDistance { get; set; }
        int WanderRestChance { get; set; }
        bool IsHunter { get; set; }
        char DisplayChar { get; set; }
        int Health { get; set; }
    }
}
