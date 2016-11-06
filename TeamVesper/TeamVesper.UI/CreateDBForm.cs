using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamVesper.UI.Contracts;

namespace TeamVesper.UI
{
    public partial class CreateDBForm : Form
    {
        private IDbInitializerFactory factory;

        public CreateDBForm(IDbInitializerFactory factory)
        {
            this.factory = factory;
            InitializeComponent();
        }

        private void CreateMongoDB_Click(object sender, EventArgs e)
        {
            Task task = new Task(() => this.InitMongoDb());
            task.Start();
        }

        private void CreateSqlServer_Click(object sender, EventArgs e)
        {
            Task task = new Task(() => this.InitSqlServer());
            task.Start();
        }

        private void CreateSQLite_Click(object sender, EventArgs e)
        {
            Task task = new Task(() => this.InitSQLite());
            task.Start();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            var parent = (MainForm)this.Tag;

            parent.Show();
            this.Close();
        }

        private async Task InitMongoDb()
        {
            var init = factory.GetMongoDbInitializer();
            init.CreateDB();
            await Task.Delay(1);
        }

        private async Task InitSqlServer()
        {
            var init = factory.GetSqlServerInitializer();
            init.CreateDB();
            await Task.Delay(1);
        }

        private async Task InitSQLite()
        {
            var init = factory.GetSQLiteInitializer();
            init.CreateDB();
            await Task.Delay(1);
        }
    }
}
