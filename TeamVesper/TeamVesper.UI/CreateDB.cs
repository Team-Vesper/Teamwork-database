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
    public partial class CreateDB : Form
    {
        public CreateDB()
        {
            InitializeComponent();
        }

        private void CreateMongoDB_Click(object sender, EventArgs e)
        {

        }

        private void CreateSqlServer_Click(object sender, EventArgs e)
        {

        }

        private void CreateSQLite_Click(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            var parent = (MainForm)this.Tag;

            parent.Show();
            this.Close();
        }
    }
}
