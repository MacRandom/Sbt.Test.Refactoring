using System;

namespace Sbt.Test.Refactoring
{
    /// <summary>
    /// The Tractor unit.
    /// </summary>
    public class Tractor : Unit
    {
        /// <summary>
        /// The constructor of the Tractor unit.
        /// </summary>
        /// <param name="x">The horizontal position of the unit.</param>
        /// <param name="y">The vertical position of the unit.</param>
        public Tractor(int x = 0, int y = 0) : base(x, y)
        {
        }

        public override void MoveForwards()
        {
            switch (OrientationType)
            {
                case OrientationType.North:
                    SetPositionY(GetPositionY + 1);
                    break;
                case OrientationType.East:
                    SetPositionX(GetPositionX + 1);
                    break;
                case OrientationType.South:
                    SetPositionY(GetPositionY - 1);
                    break;
                case OrientationType.West:
                    SetPositionX(GetPositionX - 1);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public override void MoveTurn()
        {
            switch (OrientationType)
            {
                case OrientationType.North:
                    SetOrientation(OrientationType.East);
                    break;
                case OrientationType.East:
                    SetOrientation(OrientationType.South);
                    break;
                case OrientationType.South:
                    SetOrientation(OrientationType.West);
                    break;
                case OrientationType.West:
                    SetOrientation(OrientationType.North);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
