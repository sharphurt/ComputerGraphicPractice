using System.ComponentModel;
using System.Drawing;

namespace ComputerGraphicPractice
{
    public class Line : IVectorObject
    {
        [Category("Позиция"), DisplayName("Начало"), DescriptionAttribute("Координаты точки начала")]  
        public Point Start { get; set; }
        
        [Category("Позиция"), DisplayName("Конец"), DescriptionAttribute("Координаты точки конца")]
        public Point End { get; set; }
        
        [Category("Внешний вид"), DisplayName("Толщина"), DescriptionAttribute("Толщина линии в пикселях")]
        public uint Width { get; set; }
        
        [Category("Внешний вид"), DisplayName("Цвет"), DescriptionAttribute("Цвет линии")]
        public Color Color { get; set;}
        
        public void Draw(Graphics g) => g.DrawLine(new Pen(Color, Width), Start, End);

        public bool IsPropertiesValid() => Start != End && Width != 0 && Color != Color.Empty;

        public override string ToString() => "Линия";
    }
}