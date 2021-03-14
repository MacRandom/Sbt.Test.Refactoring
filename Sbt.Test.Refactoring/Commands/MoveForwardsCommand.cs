namespace Sbt.Test.Refactoring
{
    public class MoveForwardsCommand : ICommand
    {
        private readonly Unit _unit;

        public MoveForwardsCommand(Unit unit)
        {
            _unit = unit;
        }

        public void Execute()
        {
            _unit.MoveForwards();
        }
    }
}
