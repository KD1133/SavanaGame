using SavanaGameInterface;
using System;
using static Enums.Enums;

namespace SavanaGame.Animals
{
    public class Herbavore : Animal , IAnimal
    {
        public Herbavore(IAnimalParams animalParams, IFieldVision fieldReader, IFieldChangesFacade movementFacade) : base(animalParams, fieldReader, movementFacade)
        {
        }

        public override Direction SpecialMove(int xPosition, int yPosition)
        {
            int noDanger = AnimalParams.VisionRange * 2 + 1;
            int dangerLeft = noDanger;
            int dangerRight = noDanger;
            int dangerUp = noDanger;
            int dangerDown = noDanger;


            for (int i = 1; i <= AnimalParams.VisionRange; i++)
            {
                for (int j = 0; j <= ((i * 2)); j++)
                {
                    // target right
                    if (VisionMap[AnimalParams.VisionRange + i, AnimalParams.VisionRange - i + j] == 'C' || VisionMap[AnimalParams.VisionRange + i, AnimalParams.VisionRange - i + j] == '\0')
                    {
                        if(dangerRight == noDanger)
                        {
                            dangerRight = i + (Math.Abs(j - i));
                        }
                    }
                    //target left
                    if (VisionMap[AnimalParams.VisionRange - i, AnimalParams.VisionRange - i + j] == 'C' || VisionMap[AnimalParams.VisionRange - i, AnimalParams.VisionRange - i + j] == '\0')
                    {
                        if (dangerLeft == noDanger)
                        {
                           dangerLeft = i + (Math.Abs(j - i));
                        }
                    }
                    //target below
                    if (VisionMap[AnimalParams.VisionRange - i + j, AnimalParams.VisionRange + i] == 'C' || VisionMap[AnimalParams.VisionRange - i + j, AnimalParams.VisionRange + i] == '\0')
                    {
                        if (dangerDown == noDanger)
                        {
                            dangerDown = i + (Math.Abs(j - i));
                        }
                    }
                    //target above
                    if (VisionMap[AnimalParams.VisionRange - i + j, AnimalParams.VisionRange - i] == 'C' || VisionMap[AnimalParams.VisionRange - i + j, AnimalParams.VisionRange - i] == '\0')
                    {
                        if (dangerUp == noDanger)
                        {
                            dangerUp = i + (Math.Abs(j - i));
                        }
                    }
                }
            }

            if(dangerLeft != noDanger ||
               dangerRight != noDanger ||
               dangerUp != noDanger ||
               dangerDown != noDanger)
            {
                if (dangerRight <= dangerLeft &&
                   dangerRight <= dangerUp &&
                   dangerRight <= dangerDown)
                {
                    SpecialMoveDirection = Direction.Left;
                }
                
                if (dangerLeft <= dangerRight &&
                   dangerLeft <= dangerUp &&
                   dangerLeft <= dangerDown)
                {
                    SpecialMoveDirection = Direction.Right;
                }
                
                if (dangerUp <= dangerDown &&
                   dangerUp <= dangerRight &&
                   dangerUp <= dangerLeft)
                {
                    SpecialMoveDirection = Direction.Down;
                }
                
                if (dangerDown <= dangerUp &&
                   dangerDown <= dangerRight &&
                   dangerDown <= dangerLeft)
                {
                    SpecialMoveDirection = Direction.Up;
                }

            }
            if (!ValidateMove(SpecialMoveDirection))
            {
                SpecialMoveDirection = Direction.None;
            }
            int healthPrecent = (int)Math.Round((double)(100 * AnimalParams.Health) / maxHealth);
            _movementFacade.Move(SpecialMoveDirection, xPosition, yPosition, healthPrecent);
            return SpecialMoveDirection;
        }

        
    }
}
