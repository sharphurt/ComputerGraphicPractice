using System.ComponentModel;
using System.Drawing;

namespace ComputerGraphicPractice
{
    public class Line : IVectorObject
    {
        [Category("Начало"), DescriptionAttribute("Координаты точки начала")]  
        public Point Start { get; set; }
        
        [Category("Конец"), DescriptionAttribute("Координаты точки конца")]
        public Point End { get; set; }
        
        [Category("Толщина"), DescriptionAttribute("Толщина линии в пикселях")]
        public uint Width { get; set; }
        
        [Category("Цвет"), DescriptionAttribute("Цвет линии")]
        public Color Color { get; set;}

        public void Draw(Graphics g) => g.DrawLine(new Pen(Color, Width), Start, End);

        public bool IsPropertiesValid() => Start != End && Width != 0;
    }
}