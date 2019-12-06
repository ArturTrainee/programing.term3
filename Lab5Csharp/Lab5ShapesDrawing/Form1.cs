using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab5ShapesDrawing
{
    public partial class Form1 : Form
    {
        private IDictionary<string, Figure> figures = new Dictionary<string, Figure>();
        private bool isFigureSelected;
        private int distance;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            figures.Add("Square", new Square(100, 100, 100, this));
            figures.Add("Circle", new Circle(100, 100, 200, this));
            figures.Add("Rhomb", new Rhombus(100, 200, 200, 200, this));
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out distance))
            {
                MessageBox.Show("Invalid integer entered");
                distance = 0;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            isFigureSelected = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (isFigureSelected)
            {
                figures.TryGetValue(comboBox1.Text, out Figure selectedFigure);
                selectedFigure.MoveRight(distance);
            }
            else
            {
                MessageBox.Show("Something went wrong...");
            }
        }

    }
}
