using System;

namespace Sbt.Test.Refactoring
{
    public class MoveTurnCommand : ICommand
    {
        Unit unit;

        public MoveTurnCommand(Unit unit)
        {
            this.unit = unit;
        }

        public void Execute()
        {
            unit.MoveTurn();
        }
    }
}
