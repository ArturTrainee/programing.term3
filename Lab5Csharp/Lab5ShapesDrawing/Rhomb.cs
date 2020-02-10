using System;
using System.Drawing;

namespace Lab5ShapesDrawing
{
    internal class Rhombus : Figure
    {
        public readonly Form1 form1;

        public Rhombus(int centerX, int centerY, int horDiagLen, int vertDiagLen, Form1 form1) : base(centerX, centerY)
        {
            HorDiagLen = horDiagLen;
            VertDiagLen = vertDiagLen;
            this.form1 = form1 ?? throw new ArgumentNullException("Form is null");
        }

        public int HorDiagLen { get; }

        public int VertDiagLen { get; }

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

        private PointF[] GetCurrPoints()
        {
            return new PointF[] {
                new PointF(centerX - (VertDiagLen / 2), centerY),
                new PointF(centerX, centerY - (HorDiagLen / 2)),
                new PointF(centerX + (VertDiagLen / 2), centerY),
                new PointF(centerX, centerY + (HorDiagLen / 2))
            };
        }
    }
}