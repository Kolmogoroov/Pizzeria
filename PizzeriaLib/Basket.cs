using System.Windows.Forms;

namespace PizzeriaLib
{
    public static class Basket
    {
        public static void Edit(Label label, ref string order, ref double sum, int cost, string name, bool mode)
        {
            if (mode)
            {
                if(name == "Пицца Пепперони")
                {
                    label.Text = $"{sum += cost}₽ (скидка 30%) ";
                    order += name + ",";
                }
                else if (name == "Пицца Домашняя")
                {
                    label.Text = $"{sum += cost}₽ (скидка 30%) ";
                    order += name + ",";
                }
                else
                {
                    label.Text = $"{sum += cost}₽ ";
                    order += name + ",";
                }
            }
            else
            {
                label.Text = $"{sum -= cost}₽";
                order = "";
            }
        }
    }
}
