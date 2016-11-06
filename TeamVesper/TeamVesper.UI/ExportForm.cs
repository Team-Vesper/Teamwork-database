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
    public partial class ExportForm : Form
    {
        public ExportForm()
        {
            InitializeComponent();
        }
        
        private void ReportJSON_Click(object sender, EventArgs e)
        {

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
    }
}
