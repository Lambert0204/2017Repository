using TurtleChallenge.Enum;

namespace TurtleChallenge.Domain.Interface
{
    public abstract class BasePoint : IPoint, IDirection
    {
        protected BasePoint() { }

        public int X { get; set; }

        public int Y { get; set; }

        public bool IgnoreDirection { get; set; }

        public Direction Direction { get; set; }

        #region Point
        protected abstract void Set(int x, int y);
        protected abstract void Step(int x, int y);
        protected abstract bool IsEqual(int x, int y);
        #endregion Point

        #region Direction
        protected abstract void Set(Direction direction);
        protected abstract void Rotate(Rotation rotate);
        #endregion Direction

    }
}
