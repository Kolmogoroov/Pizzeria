using System;
using System.Linq;
using System.Windows.Forms;
using PizzeriaLib;

namespace Pizzeria
{
    public partial class FormOrder : Form
    {
        public static double Сalculator = 0;
        public static string Order;

        public FormOrder()
        {
            InitializeComponent();
        }

        public void FormMain_Load(object sender, EventArgs e)
        {
            FormHello formHello = new FormHello();
            formHello.Show();
        }

        public void buttonСancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int cost = 140;
            string name = "Пицца Пепперони";
            Basket.Edit(labelСounter, ref Order, ref Сalculator, cost, name, checkBox1.Checked);
        }

        public void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            int cost = 210;
            string name = "Пицца Домашняя";
            Basket.Edit(labelСounter, ref Order, ref Сalculator, cost, name, checkBox2.Checked);
        }

        public void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            int cost = 599;
            string name = "Пицца Русская";
            Basket.Edit(labelСounter, ref Order, ref Сalculator, cost, name, checkBox3.Checked);
        }

        public void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            int cost = 549;
            string name = "Пицца Диабло";
            Basket.Edit(labelСounter, ref Order, ref Сalculator, cost, name, checkBox4.Checked);
        }

        public void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            int cost = 349;
            string name = "Пицца Сицилийская";
            Basket.Edit(labelСounter, ref Order, ref Сalculator, cost, name, checkBox5.Checked);

        }

        public void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            string name = "Пепси 0.5";
            int cost = 89;
            Basket.Edit(labelСounter, ref Order, ref Сalculator, cost, name, checkBox6.Checked);
        }

        public void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            string name = "Яблочный сок 0.5";
            int cost = 109;
            Basket.Edit(labelСounter, ref Order, ref Сalculator, cost, name, checkBox7.Checked);
        }

        public void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            string name = "Аква Минерале";
            int cost = 89;
            Basket.Edit(labelСounter, ref Order, ref Сalculator, cost, name, checkBox8.Checked);
        }

        public void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            string name = "Томатный сок";
            int cost = 39;
            Basket.Edit(labelСounter, ref Order, ref Сalculator, cost, name, checkBox9.Checked);

        }

        public void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            string name = "Сырный соус";
            int cost = 39;
            Basket.Edit(labelСounter, ref Order, ref Сalculator, cost, name, checkBox10.Checked);
        }

        public void labelСounter_TextChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked && checkBox6.Checked && checkBox9.Checked)
            {
                labelСounter.Text = $"{Сalculator = 399}₽ КОМБО";

                foreach (CheckBox cb in this.Controls.OfType<CheckBox>())
                {
                    cb.Enabled = false;
                    checkBox5.Enabled = true;
                    checkBox6.Enabled = true;
                    checkBox9.Enabled = true;
                }

            }
            else if ((checkBox5.Checked == false || checkBox6.Checked == false || checkBox9.Checked == false) &&
                     (Сalculator == 360 || Сalculator == 310 || Сalculator == 50))
            {
                foreach (CheckBox cb in this.Controls.OfType<CheckBox>())
                {
                    cb.Checked = false;
                }

                labelСounter.Text = $"{Сalculator = 0}₽ ";

                foreach (CheckBox cb in this.Controls.OfType<CheckBox>())
                {
                    cb.Enabled = true;
                }

            }

            if (checkBox3.Checked && checkBox7.Checked)
            {
                labelСounter.Text = $"{Сalculator = 499}₽ КОМБО";

                foreach (CheckBox cb in this.Controls.OfType<CheckBox>())
                {
                    cb.Enabled = false;
                    checkBox3.Enabled = true;
                    checkBox7.Enabled = true;
                }

            }
            else if ((checkBox3.Checked == false || checkBox7.Checked == false) && Сalculator == 390 ||
                     Сalculator == -100)
            {
                foreach (CheckBox cb in this.Controls.OfType<CheckBox>())
                {
                    cb.Checked = false;
                }

                labelСounter.Text = $"{Сalculator = 0}₽ ";

                foreach (CheckBox cb in this.Controls.OfType<CheckBox>())
                {
                    cb.Enabled = true;
                }
            }
        }

        public void buttonDelivery_Click(object sender, EventArgs e)
        {
            int basket = 0;

            foreach (CheckBox cb in this.Controls.OfType<CheckBox>())
            {
                if (cb.Checked == true)
                {
                    basket += 1;
                }
            }


            if (basket == 0)
            {
                MessageBox.Show("Вы ничего не выбрали!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FormDelivery f3 = new FormDelivery();
                f3.Show();
            }
        }
    }
}
