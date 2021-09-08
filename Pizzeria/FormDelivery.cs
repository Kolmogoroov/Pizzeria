using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using PizzeriaLib;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace Pizzeria
{
    public partial class FormDelivery : Form
    {
        public static double CounterDelivery = 0;
        public static string Initials;
        public static string Address;

        private string[] neighbourhood;


        public FormDelivery()
        {
            InitializeComponent();
            textBoxStreet.Text = "1 Мая";
            textBoxHome.Text = "160";
            textBoxEntrance.Text = "  ";
            textBoxApartment.Text = " ";
            comboBoxArea.Text = "Вблизи центра";
            comboBoxArea.Enabled = false;
            textBoxNumber.MaxLength = 11;

            neighbourhood = File.ReadAllLines(@"Files\Neighbourhood.txt");

            foreach (var n in neighbourhood)
            {
                comboBoxArea.Items.Add(n);
            }



        }

        public void checkBoxOut_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOut.Checked == true)
            {
                textBoxStreet.Text = "";
                textBoxHome.Text = "";
                textBoxEntrance.Text = "";
                textBoxApartment.Text = "";
                checkBoxIn.Checked = false;
                textBoxStreet.ReadOnly = false;
                textBoxHome.ReadOnly = false;
                textBoxApartment.ReadOnly = false;
                textBoxEntrance.ReadOnly = false;
                comboBoxArea.Enabled = true;
                comboBoxArea.Text = "";
            }
        }

        public void checkBoxIn_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIn.Checked == true)
            {
                textBoxStreet.Text = "1 Мая";
                textBoxHome.Text = "160";
                textBoxEntrance.Text = "  --- ";
                textBoxApartment.Text = "  --- ";
                comboBoxArea.Text = "Вблизи центра";
                checkBoxOut.Checked = false;
                textBoxStreet.ReadOnly = true;
                textBoxHome.ReadOnly = true;
                textBoxApartment.ReadOnly = true;
                textBoxEntrance.ReadOnly = true;
                comboBoxArea.Enabled = false;
            }
        }

        public void buttonOrder_Click(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "" && textBoxName.Text == "" && textBoxPatronymiс.Text == "" && textBoxNumber.Text == "")
            {
                MessageExpansion.WarningOk("Не все данные внесены!");
                textBoxSurname.BackColor = Color.Red;
            }
            else if (textBoxSurname.Text == "")
            {
                MessageExpansion.WarningOk("Введите свою фамилию!");
                textBoxSurname.BackColor = Color.Red;
            }
            else if (textBoxName.Text == "")
                MessageExpansion.WarningOk("Введите свое имя!");
            else if (textBoxPatronymiс.Text == "")
                MessageExpansion.WarningOk("Введите свое отчество!");
            else if (comboBoxArea.Text == "")
                MessageExpansion.WarningOk("Выберите район доставки!");
            else if (textBoxStreet.Text == "")
                MessageExpansion.WarningOk("Введите улицу!");
            else if (textBoxHome.Text == "")
                MessageExpansion.WarningOk("Введите номер дома");
            else if (textBoxApartment.Text == "")
                MessageExpansion.WarningOk("Введите номер квартиры");
            else if (textBoxEntrance.Text == "")
                MessageExpansion.WarningOk("Введите подъезд");
            else if (textBoxNumber.Text == "")
                MessageExpansion.WarningOk("Введите свой номер телефона!");
            else if (CharExpansion.ValidCharFound(textBoxSurname.Text) || CharExpansion.ValidCharFound(textBoxName.Text) || CharExpansion.ValidCharFound(textBoxPatronymiс.Text))
                MessageExpansion.WarningOk("Неверно заполнено поле ФИО");
            else if (CharExpansion.ValidCharFound(textBoxNumber.Text))
            {
                Address = "Краснодар" + ", " + textBoxStreet.Text + ", " + textBoxHome.Text + "," + " подъезд " + textBoxEntrance.Text + ", " + textBoxApartment.Text + " кв.";
                Initials = textBoxSurname.Text + " " + textBoxName.Text + " " + textBoxPatronymiс.Text;
                var f4 = new FormСhecklist();
                f4.Show();
            }
            else MessageExpansion.WarningOk("Укажите числовые значения!");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void comboBoxArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxArea.SelectedIndex)
            {
                case 0: labelСounter.Text = $"{CounterDelivery = 50}₽"; break;
                case 1: labelСounter.Text = $"{CounterDelivery = 100}₽"; break;
                case 2: labelСounter.Text = $"{CounterDelivery = 50}₽"; break;
                case 3: labelСounter.Text = $"{CounterDelivery = 150}₽"; break;
                case 4: labelСounter.Text = $"{CounterDelivery = 100}₽"; break;
            }
            if (checkBoxIn.Checked)
            {
                labelСounter.Text = $"{CounterDelivery = 0}₽";
            }
        }

        private void textBoxSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                return;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
