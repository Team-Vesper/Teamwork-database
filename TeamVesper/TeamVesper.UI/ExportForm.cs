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
        private StarndartModelsToMongoModelMapper mapper;

        public ExportForm(IRepositoryFactory repositoryFactory,
                                IReporterFactory reporterFactory,
                                StarndartModelsToMongoModelMapper mapper)
        {
            this.repositoryFactory = repositoryFactory;
            this.reporterFactory = reporterFactory;
            this.mapper = mapper;
            InitializeComponent();
        }

        private void ReportJSON_Click(object sender, EventArgs e)
        {
            var task = new Task(() => this.ExportToJson());
            task.Start();
        }

        private void ReportPDF_Click(object sender, EventArgs e)
        {

        }

        private void ReportXML_Click(object sender, EventArgs e)
        {

        }

        private void ReportExcel_Click(object sender, EventArgs e)
        {

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
            var mapper = this.mapper;

            var devs = mapper.ExtractMongoDevelopers();

            reporter.ReportMany(devs);

            Task.Delay(1);
        }
    }
}
