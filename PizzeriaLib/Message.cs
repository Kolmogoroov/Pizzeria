using System.Windows.Forms;

namespace PizzeriaLib
{
    public static class MessageExpansion
    {
        public static DialogResult WarningOk(string text)
        {
            return MessageBox.Show(text, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
