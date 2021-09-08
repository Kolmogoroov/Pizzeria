using System;

namespace Pizzeria
{
    public partial class FormHello : System.Windows.Forms.Form
    {
        public FormHello()
        {
            InitializeComponent();
        }

        public void buttonOrder_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHello_Load(object sender, EventArgs e)
        {

        }
    }
}
