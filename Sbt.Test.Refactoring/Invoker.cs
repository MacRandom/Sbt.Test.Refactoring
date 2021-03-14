using System;

namespace Sbt.Test.Refactoring
{
    public class Invoker
    {
        ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            if (command != null)
                command.Execute();
        }
    }
}
