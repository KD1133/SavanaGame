namespace SavanaGame
{
    public interface IAnimalFactory
    {
        IAnimal SpawnAnimal(int animalId);
    }
}