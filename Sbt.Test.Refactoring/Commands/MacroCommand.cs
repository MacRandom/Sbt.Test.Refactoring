using System.Collections.Generic;

namespace Sbt.Test.Refactoring
{
    public class MacroCommand : ICommand
    {
        List<ICommand> commands;

        public MacroCommand(List<ICommand> commands)
        {
            this.commands = commands;
        }

        public void Execute()
        {
            foreach (ICommand command in commands)
            {
                command.Execute();
            }
        }
    }
}
