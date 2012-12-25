using System.Windows.Forms;

namespace FileSystemMonitor.Common
{
    public class FormHelper
    {
        public static void ShowErrorMessage(string text)
        {
            ShowErrorMessage(text, "Error");
        }

        public static void ShowErrorMessage(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
