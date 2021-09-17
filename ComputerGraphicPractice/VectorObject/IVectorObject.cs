using System.Drawing;

namespace ComputerGraphicPractice
{
    public interface IVectorObject
    {
        void Draw(Graphics g);

        bool IsPropertiesValid();
    }
}