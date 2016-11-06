using System;
using System.Windows.Forms;
using TeamVesper.UI.Contracts;

namespace TeamVesper.UI
{
    public partial class MainForm : Form
    {
        private IFormFactory factory;

        public MainForm(IFormFactory factory)
        {
            this.factory = factory;
            InitializeComponent();
        }

        private void TeamVesper_Load(object sender, EventArgs e)
        {

        }

        private void CreateDB_Click(object sender, EventArgs e)
        {
            var form = factory.GetCreateDbForm();
            form.Tag = this;

            form.Show();
            this.Hide();
        }

        private void Import_Click(object sender, EventArgs e)
        {
            var form = factory.GetImportForm();
            form.Tag = this;

            form.Show();
            this.Hide();
        }

        private void Transfer_Click(object sender, EventArgs e)
        {
            var form = factory.GetTransferForm();
            form.Tag = this;

            form.Show();
            this.Hide();
        }

        private void Export_Click(object sender, EventArgs e)
        {
            var form = factory.GetExportForm();
            form.Tag = this;

            form.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
