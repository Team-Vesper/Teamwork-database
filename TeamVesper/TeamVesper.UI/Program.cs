using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamVesper.SqlServerData;
using TeamVesper.SqlServerData.Migrations;
using TeamVesper.UI.Modules;

namespace TeamVesper.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Database.SetInitializer(
            //    new DropCreateDatabaseAlways<SqlServerDbContext>());

            Database.SetInitializer(
                    new MigrateDatabaseToLatestVersion<SqlServerDbContext, Configuration>());

            var kernel = new StandardKernel(new TeamVesperModule());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(kernel.Get<MainForm>());
        }
    }
}
