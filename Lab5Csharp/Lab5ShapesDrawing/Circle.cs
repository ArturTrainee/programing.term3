using System;
using System.Drawing;

namespace Lab5ShapesDrawing
{
    internal class Circle : Figure
    {
        public readonly Form1 form1;

        public Circle(int centerX, int centerY, int radius, Form1 form1) : base(centerX, centerY)
        {
            Radius = radius;
            this.form1 = form1 ?? throw new ArgumentNullException("Form is null");
        }

        public int Radius { get; }

        public override void DrawBlack()
        {
            Graphics graphics = form1.CreateGraphics();
            graphics.DrawEllipse(Pens.Black, new Rectangle(centerX, centerY, Radius, Radius));
        }

        public override void HideDrawingBackGround()
        {
            Graphics graphics = form1.CreateGraphics();
            graphics.DrawEllipse(new Pen(form1.BackColor), new Rectangle(centerX, centerY, Radius, Radius));
        }
    }
}