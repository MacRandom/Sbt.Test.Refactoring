namespace Sbt.Test.Refactoring
{
    public class MoveTurnCommand : ICommand
    {
        private readonly Unit _unit;

        public MoveTurnCommand(Unit unit)
        {
            _unit = unit;
        }

        public void Execute()
        {
            _unit.MoveTurn();
        }
    }
}
