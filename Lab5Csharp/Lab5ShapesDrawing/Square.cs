using System;
using System.Drawing;

namespace Lab5ShapesDrawing
{
    internal class Square : Figure
    {
        public readonly Form1 form1;

        public Square(int centerX, int centerY, int size, Form1 form1) : base(centerX, centerY)
        {
            SideLength = size;
            this.form1 = form1 ?? throw new ArgumentNullException("Form is null");
        }

        public Form1 Form1 { get => form1; }
        public int SideLength { get; }

        public override void DrawBlack()
        {
            Graphics graphics = form1.CreateGraphics();
            graphics.DrawPolygon(Pens.Black, GetCurrPoints());
        }

        public override void HideDrawingBackGround()
        {
            Graphics graphics = form1.CreateGraphics();
            graphics.DrawPolygon(new Pen(form1.BackColor), GetCurrPoints());
        }

        private Point[] GetCurrPoints()
        {
            return new Point[] {
                new Point(centerX - SideLength,  centerY - SideLength),
                new Point(centerX - SideLength,  centerY + SideLength),
                new Point(centerX + SideLength,  centerY + SideLength),
                new Point(centerX + SideLength,  centerY - SideLength),
            };
        }
    }
}