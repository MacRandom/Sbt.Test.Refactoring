namespace Sbt.Test.Refactoring
{
    public class Invoker
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            if (_command != null)
                _command.Execute();
        }
    }
}
