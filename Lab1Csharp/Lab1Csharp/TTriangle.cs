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
        public TTriangle(int side1, int side2, int side3)
        {
            if (IsTriangleExists(side1, side2, side3))
            {
                Side1 = side1;
                Side2 = side2;
                Side3 = side3;
            }
            else
            {
                throw new ArgumentException($"Triangle with sides: {side1} {side2} {side3} doesn't exist");
            }
        }

        public TTriangle(int value1, int value2) : this(value1, value2, 1)
        {
        }

        public TTriangle(int value, byte sidePosition)
        {
            switch (sidePosition)
            {
                case 1:
                    Side1 = value; Side2 = 1; Side3 = 1;
                    break;

                case 2:
                    Side1 = 1; Side2 = value; Side3 = 1;
                    break;

                case 3:
                    Side1 = 1; Side2 = 1; Side3 = value;
                    break;
            }
        }

        public TTriangle() : this(1, 1, 1)
        {
        }

        public int Side1
        {
            get { return Side1; }
            set
            {
                if (IsTriangleExists(value, Side2, Side3))
                {
                    Side1 = value;
                }
                else
                {
                    throw new ArgumentException($"triangle with first side: {value} doesn't exist");
                }
            }
        }

        public int Side2
        {
            get { return Side2; }
            set
            {
                if (IsTriangleExists(Side1, value, Side3))
                {
                    Side2 = value;
                }
                else
                {
                    throw new ArgumentException($"Triangle with second side: {value} doesn't exist");
                }
            }
        }

        public int Side3
        {
            get { return Side3; }
            set
            {
                if (IsTriangleExists(Side1, Side2, value))
                {
                    Side3 = value;
                }
                else
                {
                    throw new ArgumentException($"Triangle with third side: {value} doesn't exist");
                }
            }
        }

        public double GetArea(int side1, int side2, int side3)
        {
            double halfP = (side1 + side2 + side3) / 2.0;
            return Math.Sqrt(halfP * (halfP - side1) * (halfP - side2) * (halfP - side3));
        }

        public int GetPerimeter(int side1, int side2, int side3) => side1 + side2 + side3;

        private static bool IsTriangleExists(int a, int b, int c)
        {
            return a > 0 && b > 0 && c > 0 && (a + b > c && a + c > b && b + c > a);
        }
    }
}