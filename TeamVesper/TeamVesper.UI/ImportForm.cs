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
        private IMapperFactory mapperFactory;

        public ImportForm(IRepositoryFactory repoFactory,
                            IUnitOfWorkFactory unitOfWorkFactory,
                            IMapperFactory mapperFactory)
        {
            this.repoFactory = repoFactory;
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.mapperFactory = mapperFactory;
            InitializeComponent();
        }

        private void ImportMongoDB_Click(object sender, EventArgs e)
        {
            var task = new Task(() => ImportFromMongo());
            task.Start();
        }

        private void ImportXML_Click(object sender, EventArgs e)
        {
            var task = new Task(() => ImportFromXML());
            task.Start();
        }

        private void ImportExcel_Click(object sender, EventArgs e)
        {
            var task = new Task(() => ImportFromExcel());
            task.Start();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            var parent = (MainForm)this.Tag;

            parent.Show();
            this.Close();
        }

        private async Task ImportFromMongo()
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

        private async Task ImportFromXML()
        {
            var xmlRepo = repoFactory.GetXmlReadableRepository<DTOEducation>();
            var xmls = xmlRepo.All();

            var sqlRepo = repoFactory.GetSqlServerRepository<Education>();

            var mapper = mapperFactory.GetDTOEducationToDbEducationMapper();

            var result = mapper.GetAllEducations(xmls);

            sqlRepo.AddMany(result);

            await Task.Delay(1);
        }

        private async Task ImportFromExcel()
        {
            var sourseRepo = this.repoFactory.GetExcelReadableRepository<Bug>();

            var destRepo = this.repoFactory.GetSqlServerRepository<Bug>();

            var bugs = sourseRepo.All();

            destRepo.AddMany(bugs);

            await Task.Delay(1);
        }
    }
}
