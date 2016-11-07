using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamVesper.Models;
using TeamVesper.UI.Contracts;

namespace TeamVesper.UI
{
    public partial class TransferForm : Form
    {
        private IRepositoryFactory repositoryFactory;
        private IMapperFactory mapperFactory;

        public TransferForm(IRepositoryFactory repositoryFactory,
                                IMapperFactory mapperFactory)
        {
            this.repositoryFactory = repositoryFactory;
            this.mapperFactory = mapperFactory;
            InitializeComponent();
        }

        private void SqlServerToMySQL_Click(object sender, EventArgs e)
        {
            var task = new Task(() => this.SqlServerToMySqlTransfer());
            task.Start();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            var parent = (MainForm)this.Tag;

            parent.Show();
            this.Close();
        }

        private async Task SqlServerToMySqlTransfer()
        {
            var sqlServerRepo = repositoryFactory.GetSqlServerRepository<Developer>();
            var mySqlRepo = repositoryFactory.GetMySqlRepository<DeveloperBugsInfo>();

            var devs = sqlServerRepo.All();

            var devsForAdd = devs
                            .Select(x => new DeveloperBugsInfo(x.Id,
                                                                x.UserName,
                                                                x.FirstName,
                                                                x.LastName,
                                                                x.WorkingOn.Count))
                            .ToList();

            // TODO fix this
            mySqlRepo.AddMany(devsForAdd);

            await Task.Delay(1);
        }
    }
}
