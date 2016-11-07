using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamVesper.Mappers;
using TeamVesper.Models;
using TeamVesper.UI.Contracts;

namespace TeamVesper.UI
{
    public partial class ExportForm : Form
    {
        private IRepositoryFactory repositoryFactory;
        private IReporterFactory reporterFactory;
        private IMapperFactory mapperfactory;

        public ExportForm(IRepositoryFactory repositoryFactory,
                                IReporterFactory reporterFactory,
                                IMapperFactory mapperfactory)
        {
            this.repositoryFactory = repositoryFactory;
            this.reporterFactory = reporterFactory;
            this.mapperfactory = mapperfactory;
            InitializeComponent();
        }

        private void ReportJSON_Click(object sender, EventArgs e)
        {
            var task = new Task(() => this.ExportToJson());
            task.Start();
        }

        private void ReportPDF_Click(object sender, EventArgs e)
        {
            var task = new Task(() => this.ExportToPdf());
            task.Start();
        }

        private void ReportXML_Click(object sender, EventArgs e)
        {
            var task = new Task(() => ExportToXML());
            task.Start();
        }

        private void ReportExcel_Click(object sender, EventArgs e)
        {
            var task = new Task(() => ExportToExcel());
            task.Start();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            var parent = (MainForm)this.Tag;

            parent.Show();
            this.Close();
        }

        private async Task ExportToJson()
        {
            var reporter = this.reporterFactory.GetJsonReporter<MongoDeveloper>();
            var mapper = this.mapperfactory.GetStarndartModelsToMongoModelMapper();

            var devs = mapper.ExtractMongoDevelopers();

            reporter.ReportMany(devs);

            await Task.Delay(1);
        }

        private async Task ExportToPdf()
        {
            var reporter = this.reporterFactory.GetPdfReporter<BugInfo>();
            var mapper = this.mapperfactory.GetBugToBugInfoMapper();

            var buginfos = mapper.ExtractBugInfo();

            reporter.ReportMany(buginfos);

            await Task.Delay(1);
        }

        private async Task ExportToXML()
        {
            var reporter = this.reporterFactory.GetXmlReporter<BugReport>();

            var mapper = this.mapperfactory.GetBugToBugReportMapper();

            var reports = mapper.ExtractBugInfo();

            reporter.ReportMany(reports);

            await Task.Delay(1);
        }

        private async Task ExportToExcel()
        {
            var SqlServerRepo = this.repositoryFactory.GetSqlServerRepository<Developer>();

            var reporter = this.reporterFactory.GetExcelReporter<CompanyOverview>();

            var result = SqlServerRepo.All().ToList();

            var grouped = result.GroupBy(x => x.Team.Name)
                                .Select(gr => new
                                {
                                    Team = gr.Key,
                                    NumberOfDevelopers = gr.Count(),
                                    BugsSolved = gr.Sum(dev => dev.WorkingOn.Count)
                                })
                                .ToList();

            // TODO ask how to use that !


            await Task.Delay(1);
        }
    }
}
