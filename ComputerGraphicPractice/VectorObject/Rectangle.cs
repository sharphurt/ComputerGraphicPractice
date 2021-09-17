using System.ComponentModel;
using System.Drawing;

namespace ComputerGraphicPractice
{
    public class Rectangle : IVectorObject
    {
        [Category("Позиция"), DisplayName("X"), DescriptionAttribute("Позиция элиипса по X")]
        public uint X { get; set; }

        [Category("Позиция"), DisplayName("Y"), DescriptionAttribute("Позиция элиипса по Y")]
        public uint Y { get; set; }

        [Category("Размер"), DisplayName("Ширина"), DescriptionAttribute("Ширина эллипса в пикселях")]
        public uint Width { get; set; }

        [Category("Размер"), DisplayName("Высота"), DescriptionAttribute("Высота эллипса в пикселях")]
        public uint Height { get; set; }

        [Category("Внешний вид"), DisplayName("Цвет"), DescriptionAttribute("Цвет линии")]
        public Color Color { get; set; }

        [Category("Внешний вид"), DisplayName("Толщина обводки"), DescriptionAttribute("Толщина обводки в пикселях")]
        public uint StrokeWidth { get; set; }

        [Category("Внешний вид"), DisplayName("Заполнение"), DescriptionAttribute("Будет ли фигура запоняться")]
        public bool IsFilled { get; set; }

        public void Draw(Graphics g)
        {
            if (IsFilled)
                g.FillRectangle(new SolidBrush(Color), X, Y, Width, Height);
            else
                g.DrawRectangle(new Pen(Color, StrokeWidth), X, Y, Width, Height);
        }


        public bool IsPropertiesValid() =>
            Width != 0 && Height != 0 && Color != Color.Empty && (!IsFilled && StrokeWidth != 0 || IsFilled);

        public override string ToString() => Width == Height ? "Квадрат" : "Прямоуголььник";
    }
}