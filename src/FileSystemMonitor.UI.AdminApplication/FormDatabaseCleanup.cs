using System;
using System.Windows.Forms;

namespace FileSystemMonitor.UI.AdminApplication
{
    public partial class FormDatabaseCleanup : Form
    {
        public enum TimeUnitType
        {
            Year = 0,
            Month = 1,
            Day = 2,
            Hour = 3,
            Minute = 4,
            Second = 5
        }

        public int UnitCount
        {
            get { return (int)udUnitCount.Value; }
            set { udUnitCount.Value = value; }
        }

        public TimeUnitType TimeUnit
        {
            get { return (TimeUnitType)cbUnitType.SelectedIndex; }
            set { cbUnitType.SelectedIndex = (int)value; }
        }

        public FormDatabaseCleanup()
        {
            InitializeComponent();
            cbUnitType.SelectedIndex = 2;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure?", "Shrink database", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}