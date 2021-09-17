using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace ComputerGraphicPractice
{
    public class Polygon : IVectorObject
    {
        [Category("Точки"), DisplayName("Точки"), DescriptionAttribute("Список точек для создания многоугольника")]
        public Point[] Points { get; set; }

        [Category("Внешний вид"), DisplayName("Цвет"), DescriptionAttribute("Цвет линии")]
        public Color Color { get; set; }

        [Category("Внешний вид"), DisplayName("Толщина обводки"), DescriptionAttribute("Толщина обводки в пикселях")]
        public uint StrokeWidth { get; set; }

        [Category("Внешний вид"), DisplayName("Заполнение"), DescriptionAttribute("Будет ли фигура запоняться")]
        public bool IsFilled { get; set; }

        public void Draw(Graphics g)
        {
            if (IsFilled)
                g.FillPolygon(new SolidBrush(Color), Points.Select(p => new System.Drawing.Point(p.X, p.Y)).ToArray());
            else
                g.DrawPolygon(new Pen(Color, StrokeWidth), Points.Select(p => new System.Drawing.Point(p.X, p.Y)).ToArray());
        }


        public bool IsPropertiesValid() => Color != Color.Empty && (!IsFilled && StrokeWidth != 0 || IsFilled);

        public override string ToString() => "Многоугольник";
    }
}