using System;
using System.Windows.Forms;

namespace ComputerGraphicPractice
{
    public partial class ObjectParametersForm : Form
    {
        private readonly IVectorObject _vectorObject;

        public IVectorObject ConfiguredObject { get; private set; }

        public ObjectParametersForm(IVectorObject vectorObject)
        {
            InitializeComponent();
            _vectorObject = vectorObject;
            propertyGrid1.SelectedObject = _vectorObject;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (_vectorObject.IsPropertiesValid())
            {
                ConfiguredObject = _vectorObject;
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}