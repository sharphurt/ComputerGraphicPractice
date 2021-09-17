using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace ComputerGraphicPractice
{
    public class RegularPolygon : IVectorObject
    {
        [Category("Основные"), DisplayName("Количество вершин"),
         DescriptionAttribute("Количество вершин парвильного многоугольника")]
        public uint Count { get; set; }

        [Category("Позиция"), DisplayName("X"), DescriptionAttribute("Позиция многоугольника по Х")]
        public int X { get; set; }

        [Category("Позиция"), DisplayName("Y"), DescriptionAttribute("Позиция многоугольника по Y")]
        public int Y { get; set; }

        [Category("Размер"), DisplayName("Ширина"), DescriptionAttribute("Ширина многоугольника")]
        public uint Width { get; set; }

        [Category("Размер"), DisplayName("Высота"), DescriptionAttribute("Высота многоугольника")]
        public uint Height { get; set; }

        [Category("Внешний вид"), DisplayName("Цвет"), DescriptionAttribute("Цвет линии")]
        public Color Color { get; set; }

        [Category("Внешний вид"), DisplayName("Толщина обводки"), DescriptionAttribute("Толщина обводки в пикселях")]
        public uint StrokeWidth { get; set; }

        [Category("Внешний вид"), DisplayName("Заполнение"), DescriptionAttribute("Будет ли фигура запоняться")]
        public bool IsFilled { get; set; }

        public void Draw(Graphics g)
        {
            var points = CalculatePoints();
            if (IsFilled)
                g.FillPolygon(new SolidBrush(Color), points.ToArray());
            else 
                g.DrawPolygon(new Pen(Color, StrokeWidth), points);
        }

        private System.Drawing.Point[] CalculatePoints()
        {
            var tempX = -Width / 2;
            var tempY = -Height / 2;

            var points = new List<System.Drawing.Point>(new[] {new System.Drawing.Point(X, Y)});

            for (var i = 1; i < Count; i++)
            {
                var angle = 360 / Count * i * 0.0174533;
                var rX = Width / 2 + X + tempX * Math.Cos(angle) - tempY * Math.Sin(angle);
                var rY = Height / 2 + Y + tempX * Math.Sin(angle) + tempY * Math.Cos(angle);

                points.Add(new System.Drawing.Point((int) rX, (int) rY));
            }

            return points.ToArray();
        }

        public bool IsPropertiesValid() => Color != Color.Empty && (!IsFilled && StrokeWidth != 0 || IsFilled);

        public override string ToString() => "Многоугольник";
    }
}