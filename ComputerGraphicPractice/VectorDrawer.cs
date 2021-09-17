using System.Collections.Generic;
using System.Drawing;

namespace ComputerGraphicPractice
{
    public class VectorDrawer
    {
        public Size Size { get; }
        public Color BackgroundColor { get; }
        
        private List<IVectorObject> _objects;

        public VectorDrawer(Size size, Color backgroundColor)
        {
            Size = size;
            BackgroundColor = backgroundColor;
            
            _objects = new List<IVectorObject>();
        }

        public void AddObject(IVectorObject vectorObject) => _objects.Add(vectorObject);

        public void RemoveObject(IVectorObject vectorObject) => _objects.Remove(vectorObject);

        public void DrawAll(Graphics g)
        {
            g.FillRectangle(new SolidBrush(BackgroundColor), 0, 0, Size.Width, Size.Height);
            
            foreach (var obj in _objects) 
                obj.Draw(g);
        }
    }
}