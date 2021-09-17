using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphicPractice
{
    public partial class Form1 : Form
    {
        private Bitmap _bitmap;
        private Graphics _graphics;

        private VectorDrawer _vectorDrawer = new VectorDrawer(new Size(480, 360), Color.Black);

        public Form1()
        {
            InitializeComponent();
            
            _bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _graphics = Graphics.FromImage(_bitmap);
            
            _vectorDrawer.OnObjectAdded += vectorObject =>
            {
                Draw();
                UpdateTreeView();
            };
            _vectorDrawer.OnObjectRemoved += vectorObject =>
            {
                Draw();
                UpdateTreeView();
            };
        }

        private void LineButton_Click(object sender, EventArgs e) => CreateNewObject(new Line());

        private void EllipseButton_Click(object sender, EventArgs e) => CreateNewObject(new Ellipse());

        private void RectangleButton_Click(object sender, EventArgs e) => CreateNewObject(new Rectangle());

        private void PolygonButton_Click(object sender, EventArgs e) => CreateNewObject(new Polygon());
        
        private void RegularPolygonButton_Click(object sender, EventArgs e) => CreateNewObject(new RegularPolygon());

        private void UpdateTreeView()
        {
            treeView1.BeginUpdate();

            treeView1.Nodes.Clear();
            treeView1.Nodes.Add("Vector Frame 1");
            
            foreach (var obj in _vectorDrawer.Objects) 
                treeView1.Nodes[0].Nodes.Add(new ExtendedTreeNode(obj));

            Cursor.Current = Cursors.Default;
            
            treeView1.EndUpdate();
            
            treeView1.ExpandAll();
        }

        private void Draw()
        {
            _vectorDrawer.DrawAll(_graphics);
            pictureBox1.Image = _bitmap;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _vectorDrawer.ClearAll(_graphics);
        }
        
        private void CreateNewObject(IVectorObject obj)
        {
            var parametersForm = new ObjectParametersForm(obj);
            if (parametersForm.ShowDialog() == DialogResult.OK)
                _vectorDrawer.AddObject(parametersForm.ConfiguredObject);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            
            var filename = saveFileDialog1.FileName;
            _bitmap.Save(filename);
        }
    }
}