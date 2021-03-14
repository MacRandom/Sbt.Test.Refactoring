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
                new MoveForwardsCommand(tractor),
                new MoveForwardsCommand(stone),
                new MoveForwardsCommand(wind)
            };

            Invoker invoker = new Invoker();
            invoker.SetCommand(new MacroCommand(commands));
            invoker.ExecuteCommand();

            Assert.AreEqual(0, tractor.GetPositionX);
            Assert.AreEqual(2, tractor.GetPositionY);
            Assert.AreEqual(2, stone.GetPositionX);
            Assert.AreEqual(2, stone.GetPositionY);
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
            Tractor tractor = new Tractor(3, 3);

            List<ICommand> commands = new List<ICommand>
            {
                new MoveTurnCommand(tractor),
                new MoveForwardsCommand(tractor)
            };

            Invoker invoker = new Invoker();
            invoker.SetCommand(new MacroCommand(commands));

            invoker.ExecuteCommand();
            Assert.AreEqual(4, tractor.GetPositionX);
            Assert.AreEqual(3, tractor.GetPositionY);

            invoker.ExecuteCommand();
            Assert.AreEqual(4, tractor.GetPositionX);
            Assert.AreEqual(2, tractor.GetPositionY);

            invoker.ExecuteCommand();
            Assert.AreEqual(3, tractor.GetPositionX);
            Assert.AreEqual(2, tractor.GetPositionY);

            invoker.ExecuteCommand();
            Assert.AreEqual(3, tractor.GetPositionX);
            Assert.AreEqual(3, tractor.GetPositionY);
        }

        [Test]
        [TestCase(OrientationType.North)]
        [TestCase(OrientationType.East)]
        [TestCase(OrientationType.West)]
        [TestCase(OrientationType.South)]
        public void TestShouldThrowExceptionIfFallsOffPlateau(OrientationType orientationType)
        {
            Tractor tractor = new Tractor();
            Invoker invoker = new Invoker();

            invoker.SetCommand(new MoveTurnCommand(tractor));
            while (tractor.OrientationType != orientationType)
                invoker.ExecuteCommand();

            try
            {
                int moveCount = Consts.FieldHeight > Consts.FieldWidth ? Consts.FieldHeight : Consts.FieldWidth;
                moveCount++;

                invoker.SetCommand(new MoveForwardsCommand(tractor));

                for (int i = 0; i < moveCount; i++)
                    invoker.ExecuteCommand();
            }
            catch (UnitInDitchException exc)
            {
                return;
            }

            Assert.Fail("Tractor is expected to fall off the plateau");
        }
    }
}