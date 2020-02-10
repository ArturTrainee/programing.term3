namespace Lab5ShapesDrawing
{
    internal abstract class Figure
    {
        protected int centerX;
        protected int centerY;

        protected Figure(int centerX, int centerY)
        {
            this.centerX = centerX;
            this.centerY = centerY;
        }

        public double CenterX => centerX;

        public double CenterY => centerY;

        public abstract void DrawBlack();

        public override bool Equals(object obj)
        {
            return obj is Figure figure &&
                   centerX == figure.centerX &&
                   centerY == figure.centerY &&
                   CenterX == figure.CenterX &&
                   CenterY == figure.CenterY;
        }

        public override int GetHashCode()
        {
            var hashCode = -105565786;
            hashCode = (hashCode * -1521134295) + centerX.GetHashCode();
            hashCode = (hashCode * -1521134295) + centerY.GetHashCode();
            hashCode = (hashCode * -1521134295) + CenterX.GetHashCode();
            hashCode = (hashCode * -1521134295) + CenterY.GetHashCode();
            return hashCode;
        }

        public abstract void HideDrawingBackGround();

        public void MoveRight(int distance)
        {
            for (int i = 0; i < distance; i++)
            {
                DrawBlack();
                System.Threading.Thread.Sleep(100);
                HideDrawingBackGround();
                centerX++;
            }
        }

        public override string ToString() => $"Figure centerX = {centerX}, centerY = {centerX}";
    }
}