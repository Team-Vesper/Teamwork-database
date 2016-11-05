using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamVesper.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void TeamVesper_Load(object sender, EventArgs e)
        {

        }

        private void CreateDB_Click(object sender, EventArgs e)
        {
            var form = new CreateDB();
            form.Tag = this;

            form.Show();
            this.Hide();
        }

        private void Import_Click(object sender, EventArgs e)
        {
            var form = new Import();
            form.Tag = this;

            form.Show();
            this.Hide();
        }

        private void Transfer_Click(object sender, EventArgs e)
        {
            var form = new Transfer();
            form.Tag = this;

            form.Show();
            this.Hide();
        }

        private void Export_Click(object sender, EventArgs e)
        {
            var form = new Export();
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
