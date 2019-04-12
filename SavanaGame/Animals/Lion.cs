using SavanaGameInterface;
using static Enums.Enums;

namespace SavanaGame.Animals
{
    class Lion : Animal , IAnimal
    {
        private Direction WanderDirection { get; set; }
        
        public Lion(IFieldVision fieldReader, IFieldChangesFacade movementFacade) : base(fieldReader, movementFacade)
        {
            VisionRange = 6;
            RunSpeed = 3;
            DisplayChar = 'L';
            WanderDirection = Direction.None;
            IsHunter = true;
            SpecialTrigerAnimal = 'A';
            MoveTargetAnimal = 'A';
        }

        public override Direction Wander()
        {
            int rnd = Rnd.Next(1,5);
            if(rnd == 1)
            {
                rnd = Rnd.Next(1, 5);
                switch (rnd)
                {
                    case 1:
                        WanderDirection = Direction.Left;
                        WanderDirection = Direction.Right;
                        break;
                    case 2:
                        WanderDirection = Direction.Right;
                        WanderDirection = Direction.Left;
                        break;
                    case 3:
                        WanderDirection = Direction.Up;
                        WanderDirection = Direction.Down;
                        break;
                    case 4:
                        WanderDirection = Direction.Down;
                        break;
                }
                   
            }
            if (!ValidateMove(WanderDirection))
            {
                switch (WanderDirection)
                {
                    case Direction.Right:
                        WanderDirection = Direction.Left;
                        break;
                    case Direction.Left:
                        WanderDirection = Direction.Right;
                        break;
                    case Direction.Up:
                        WanderDirection = Direction.Down;
                        break;
                    case Direction.Down:
                        WanderDirection = Direction.Up;
                        break;
                }
            }
            return WanderDirection;
        }
    }
}
