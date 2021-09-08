using System;
using System.Windows.Forms;
using System.IO;

namespace Pizzeria
{
    public partial class FormСhecklist : Form
    {
        public string AllText = FormDelivery.Initials + ", " + "вы заказали: " + FormOrder.Order + "." + "Адрес доставки: " + FormDelivery.Address + "." 
            + "Общая стоимость заказа: " + (Convert.ToInt32(FormOrder.Сalculator) + Convert.ToInt32(FormDelivery.CounterDelivery)) + " ₽";
        public FormСhecklist()
        {
            InitializeComponent();
            labelName.Text = "Спасибо за заказ, " + FormDelivery.Initials + "!";
            labelOrder.Text = "Вы заказали: " + FormOrder.Order;
            labelAddress.Text = "Адрес доставки: " + FormDelivery.Address;
            labelMoney.Text = "Общая стоимость заказа: " + (Convert.ToInt32(FormOrder.Сalculator) + Convert.ToInt32(FormDelivery.CounterDelivery)) + "₽";
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            File.WriteAllText(saveFileDialog1.FileName, AllText);
        }

        private void FormCheck_Load(object sender, EventArgs e)
        {

        }
    }
}
