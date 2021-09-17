using System.Collections.Generic;
using System.Drawing;

namespace ComputerGraphicPractice
{
    public class VectorDrawer
    {
        public Size Size { get; }
        public Color BackgroundColor { get; }
        
        public List<IVectorObject> Objects { get; }
        
        public delegate void ObjectAdded(IVectorObject vectorObject);

        public event ObjectAdded OnObjectAdded;
        
        public delegate void ObjectRemoved(IVectorObject vectorObject);

        public event ObjectAdded OnObjectRemoved;

        public VectorDrawer(Size size, Color backgroundColor)
        {
            Size = size;
            BackgroundColor = backgroundColor;
            
            Objects = new List<IVectorObject>();
        }

        public void AddObject(IVectorObject vectorObject)
        {
            Objects.Add(vectorObject);
            OnObjectAdded?.Invoke(vectorObject);
        }

        public void RemoveObject(IVectorObject vectorObject)
        {
            Objects.Remove(vectorObject);
            OnObjectRemoved?.Invoke(vectorObject);
        }

        public void DrawAll(Graphics g)
        {
            g.FillRectangle(new SolidBrush(BackgroundColor), 0, 0, Size.Width, Size.Height);
            
            foreach (var obj in Objects) 
                obj.Draw(g);
        }

        public void ClearAll(Graphics g)
        {
            Objects.Clear();
            OnObjectRemoved?.Invoke(null);
            DrawAll(g);
        }
    }
}