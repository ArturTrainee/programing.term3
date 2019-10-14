using System;

/* Task
 * Створити клас TTriangle для подання трикутника. 
 * Поля (protected) повинні містити дані про довжини сторін (для кожної з трьох сторін своє поле). 
 * Потрібно реалізувати:
 * конструктор, який заповнює всі три довжини (перевіряючи можливість існування такого трикутника);
 * отримання (get) довжини сторони (три окремі методи, для кожної сторони свій);
 * задання (set) довжини сторони (три окремі методи, для кожної сторони свій; перевіряти можливість існування такого трикутника, де ця одна сторона змінена, а решта дві лишаються, які були);
 * отримання периметру трикутника
 * отримання площі трикутника (через формулу Герона)
 */

namespace Lab1Csharp
{
    public class TTriangle
    {
        protected int side1 = 1, side2 = 1, side3 = 1;

        public int Side1
        {
            get { return side1; }
            set
            {
                if (IsTriangleExists(value, side2, side3))
                {
                    side1 = value;
                }
                else throw new ArgumentException($"Triangle with first side: {value} doesn't exist");
            }
        }
        public int Side2
        {
            get { return side2; }
            set
            {
                if (IsTriangleExists(side1, value, side3))
                {
                    side2 = value;
                }
                else throw new ArgumentException($"Triangle with second side: {value} doesn't exist");
            }
        }
        public int Side3
        {
            get { return side3; }
            set
            {
                if (IsTriangleExists(side1, side2, value))
                {
                    side3 = value;
                }
                else throw new ArgumentException($"Triangle with third side: {value} doesn't exist");
            }
        }

        public TTriangle(int side1, int side2, int side3) 
        {
            if (IsTriangleExists(side1, side2, side3))
            {
                this.side1 = side1;
                this.side2 = side2;
                this.side3 = side3;
            }
            else throw new ArgumentException($"Triangle with sides: {side1} {side2} {side3} doesn't exist");
        }

        public TTriangle(int value1, int value2) : this(value1, value2, 1) { }
        
        public TTriangle(int value, byte sidePosition)
        {
            switch (sidePosition)
            {
                case 1:
                    side1 = value; Side2 = 1; side3 = 1;
                    break;
                case 2:
                    side1 = 1; Side2 = value; side3 = 1;
                    break;
                case 3:
                    side1 = 1; side2 = 1; Side3 = value;
                    break;
            }
        }

        public TTriangle() : this(1, 1, 1) { }
        
        private static bool IsTriangleExists(int a, int b, int c)
        {
            bool hasAllSidesPositive = a > 0 & b > 0 & c > 0;
            bool hasCorrectSidesEquations = !(a + b <= c || a + c <= b || b + c <= a);

            return hasAllSidesPositive & hasCorrectSidesEquations;
        }

        public int GetPerimeter(int side1, int side2, int side3) => side1 + side2 + side3;

        public double GetArea(int side1, int side2, int side3)
        {
            double halfP = (side1 + side2 + side3) / 2.0;
            return Math.Sqrt(halfP * (halfP - side1) * (halfP - side2) * (halfP - side3));
        }
    }
}
