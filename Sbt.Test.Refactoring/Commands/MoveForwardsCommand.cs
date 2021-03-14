using System;

namespace Sbt.Test.Refactoring
{
    public class MoveForwardsCommand : ICommand
    {
        Unit unit;

        public MoveForwardsCommand(Unit unit)
        {
            this.unit = unit;
        }

        public void Execute()
        {
            unit.MoveForwards();
        }
    }
}
