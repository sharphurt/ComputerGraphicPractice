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
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            var parametersForm = new ObjectParametersForm(new Line());
            if (parametersForm.ShowDialog() == DialogResult.OK)
            {
                _vectorDrawer.AddObject(parametersForm.ConfiguredObject);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            _vectorDrawer.DrawAll(_graphics);
            pictureBox1.Image = _bitmap;
        }
    }
}