using System.Windows.Forms;

namespace ComputerGraphicPractice
{
    public class ExtendedTreeNode : TreeNode
    {
        public IVectorObject VectorObject { get; }
        
        public ExtendedTreeNode(IVectorObject vectorObject)
        {
            VectorObject = vectorObject;
            Text = vectorObject.ToString();
        }
    }
}