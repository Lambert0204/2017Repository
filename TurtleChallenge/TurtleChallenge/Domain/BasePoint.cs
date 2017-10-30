namespace TurtleChallenge.Domain
{
    public abstract class BasePoint : IPoint
    {
        protected int X { get; set; }
        protected int Y { get; set; }

        public void Move(int x, int y)
        {
            this.X += x;
            this.Y += y;
        }

        public void Set(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
