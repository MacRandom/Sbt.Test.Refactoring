using System.Collections.Generic;
using NUnit.Framework;

namespace Sbt.Test.Refactoring.Tests
{
    public class TractorTest
    {
        [Test]
        public void TestMacroMoveForwardsCommand()
        {
            Tractor tractor = new Tractor();
            Stone stone = new Stone(2, 2);
            Wind wind = new Wind();

            List<ICommand> commands = new List<ICommand>
            {
                new MoveForwardsCommand(tractor),
                new MoveForwardsCommand(stone),
                new MoveForwardsCommand(wind)
            };

            Invoker invoker = new Invoker();
            invoker.SetCommand(new MacroCommand(commands));
            invoker.ExecuteCommand();

            Assert.AreEqual(0, tractor.GetPositionX);
            Assert.AreEqual(1, tractor.GetPositionY);
            Assert.AreEqual(0, stone.GetPositionX);
            Assert.AreEqual(0, stone.GetPositionY);
        }


        [Test]
        public void TestShouldMoveForward()
        {
            Tractor tractor = new Tractor();
            Invoker invoker = new Invoker();

            invoker.SetCommand(new MoveForwardsCommand(tractor));
            invoker.ExecuteCommand();

            Assert.AreEqual(0, tractor.GetPositionX);
            Assert.AreEqual(1, tractor.GetPositionY);
        }

        [Test]
        public void TestShouldTurn()
        {
            Tractor tractor = new Tractor();
            Invoker invoker = new Invoker();

            invoker.SetCommand(new MoveTurnCommand(tractor));
            invoker.ExecuteCommand();

            Assert.AreEqual(OrientationType.East, tractor.OrientationType);

            invoker.ExecuteCommand();
            Assert.AreEqual(OrientationType.South, tractor.OrientationType);

            invoker.ExecuteCommand();
            Assert.AreEqual(OrientationType.West, tractor.OrientationType);

            invoker.ExecuteCommand();
            Assert.AreEqual(OrientationType.North, tractor.OrientationType);
        }

        [Test]
        public void TestShouldTurnAndMoveInTheRightDirection()
        {
            Tractor tractor = new Tractor();

            List<ICommand> commands = new List<ICommand>
            {
                new MoveTurnCommand(tractor),
                new MoveForwardsCommand(tractor)
            };

            Invoker invoker = new Invoker();
            invoker.SetCommand(new MacroCommand(commands));

            invoker.ExecuteCommand();
            Assert.AreEqual(1, tractor.GetPositionX);
            Assert.AreEqual(0, tractor.GetPositionY);

            invoker.ExecuteCommand();
            Assert.AreEqual(1, tractor.GetPositionX);
            Assert.AreEqual(-1, tractor.GetPositionY);

            invoker.ExecuteCommand();
            Assert.AreEqual(0, tractor.GetPositionX);
            Assert.AreEqual(-1, tractor.GetPositionY);

            invoker.ExecuteCommand();
            Assert.AreEqual(0, tractor.GetPositionX);
            Assert.AreEqual(0, tractor.GetPositionY);
        }

        [Test]
        public void TestShouldThrowExceptionIfFallsOffPlateau()
        {
            Tractor tractor = new Tractor();
            Invoker invoker = new Invoker();

            invoker.SetCommand(new MoveForwardsCommand(tractor));

            invoker.ExecuteCommand();
            invoker.ExecuteCommand();
            invoker.ExecuteCommand();
            invoker.ExecuteCommand();
            invoker.ExecuteCommand();

            try
            {
                invoker.ExecuteCommand();
                Assert.Fail("Tractor is expected to fall off the plateau");
            }
            catch (UnitInDitchException ex)
            {
            }
        }
    }
}