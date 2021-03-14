using System;

namespace Sbt.Test.Refactoring
{
    public class Wind : Unit
    {
        public Wind(int x = 0, int y = 0) : base(x, y)
        {
        }

        public override void MoveTurn()
        {
            // moving logic for wind
        }
    }
}
