using SavanaGameInterface;

namespace SavanaGame.Animals
{
    class Lion : Animal , IAnimal
    {
        private int WanderDirection { get; set; }
        
        public Lion(IFieldReader fieldReader, IFieldChangesFacade movementFacade) : base(fieldReader, movementFacade)
        {
            VisionRange = 5;
            RunSpeed = 3;
            DisplayChar = 'L';
            WanderDirection = 1;
        }

        public override int Wander(char[,] map)
        {
            int rnd = Rnd.Next(1,5);
            if(rnd == 1)
            {
                rnd = Rnd.Next(1, 5);
                switch (rnd)
                {
                    case 1:
                        WanderDirection = 1;
                        break;
                    case 2:
                        WanderDirection = 2;
                        break;
                    case 3:
                        WanderDirection = 3;
                        break;
                    case 4:
                        WanderDirection = 4;
                        break;
                }
                   
            }
            return WanderDirection;
        }

        public override bool LookAround(char[,] map)
        {
            return base.LookAround(map, 'A');
        }

        public override int SpecialMove(char[,] map)
        {
           return base.SpecialMove(map, 'A', true);
        }
    }
}
