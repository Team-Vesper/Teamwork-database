using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamVesper.Mappers;
using TeamVesper.Models;
using TeamVesper.UI.Contracts;

namespace TeamVesper.UI
{
    public partial class ImportForm : Form
    {
        private IRepositoryFactory repoFactory;
        private IUnitOfWorkFactory unitOfWorkFactory;

        public ImportForm(IRepositoryFactory repoFactory, IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.repoFactory = repoFactory;
            this.unitOfWorkFactory = unitOfWorkFactory;
            InitializeComponent();
        }

        private void ImportMongoDB_Click(object sender, EventArgs e)
        {
            var task = new Task(() => ImportMongo());
            task.Start();
        }

        private void ImportXML_Click(object sender, EventArgs e)
        {

        }

        private void ImportExcel_Click(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            var parent = (MainForm)this.Tag;

            parent.Show();
            this.Close();
        }

        private async Task ImportMongo()
        {
            var source = this.repoFactory.GetMongoDeveloperReadableRepository<MongoDeveloper>();

            var devRepo = this.repoFactory.GetSqlServerRepository<Developer>();

            //using (var unitOfWork = unitOfWorkFactory.GetSqlServerUnitOFWork())
            {
                var devs = source.All();

                var mappedDevs = devs.Developers();

                devRepo.AddMany(mappedDevs);
                //var db = new SqlServerData.SqlServerDbContext();
                //db.Developers.Add(mappedDevs.FirstOrDefault());
                //db.SaveChanges();
                //  unitOfWork.Commit(); //  <= this just do not work! 
            }

            await Task.Delay(1);
        }
    }
}
