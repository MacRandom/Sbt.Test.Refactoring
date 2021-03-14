using System;

namespace Sbt.Test.Refactoring.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            TractorTest test = new TractorTest();

            test.TestMacroMoveForwardsCommand();

            test.TestShouldMoveForward();
            test.TestShouldThrowExceptionIfFallsOffPlateau();
            test.TestShouldTurn();
            test.TestShouldTurnAndMoveInTheRightDirection();
        }
    }
}
