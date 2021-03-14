using System.Drawing;

namespace Sbt.Test.Refactoring
{
    /// <summary>
    /// Base abstract class of the unit.
    /// </summary>
    public abstract class Unit
    {
        private Size _field = new Size(Consts.FieldWidth, Consts.FieldHeight);
        private Point _position;
        private OrientationType _orientationType = OrientationType.North;

        /// <summary>
        /// The constructor of the unit.
        /// </summary>
        /// <param name="x">The horizontal position of the unit.</param>
        /// <param name="y">The vertical position of the unit.</param>
        protected Unit(int x, int y)
        {
            _position = new Point(0, 0);
        }

        public OrientationType OrientationType => _orientationType;

        /// <summary>
        /// Get the horizontal position of the unit.
        /// </summary>
        public int GetPositionX => _position.X;

        /// <summary>
        /// Get the vertical position of the unit.
        /// </summary>
        public int GetPositionY => _position.Y;

        public virtual void MoveForwards()
        {
        }

        public virtual void MoveTurn()
        {
        }

        protected void SetPositionX(int x)
        {
            this._position.X = x;
            CheckIsInDitch();
        }

        protected void SetPositionY(int y)
        {
            this._position.Y = y;
            CheckIsInDitch();
        }

        protected void SetOrientation(OrientationType orientationType)
        {
            this._orientationType = orientationType;
        }

        /// <summary>
        /// Check whether the unit is out of the field.
        /// </summary>
        private void CheckIsInDitch()
        {
            if (GetPositionX >= _field.Width || 
                GetPositionY >= _field.Height ||
                GetPositionX < 0 ||
                GetPositionY < 0)
            {
                throw new UnitInDitchException();
            }
        }
    }
}
