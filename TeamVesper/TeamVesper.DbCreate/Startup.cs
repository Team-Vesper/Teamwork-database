using MongoDB.Driver;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using TeamVesper.Importers;
using TeamVesper.Models;
using TeamVesper.SqlServerData;
using TeamVesper.SqlServerData.Migrations;
using TeamVesper.Utilities;

namespace TeamVesper.DbCreate
{
    public class Startup
    {
        public static void Main()
        {
            const string zipPath = "../../../Bugs.zip";


            //Database.SetInitializer(
            //    new DropCreateDatabaseAlways<SqlServerDbContext>());

            Database.SetInitializer(
                    new MigrateDatabaseToLatestVersion<SqlServerDbContext, Configuration>());

            // MongoDBCreate();

            // SqlServerDbCreate();

            //SQLiteDbCreate();

            PrioritiesDB.Add();
            SpecialitiesDB.Add();
            TeamsDB.Add();
            DevelopersActions.AddFromTest();

            //var bugList = ExcelImporter.ImportBugs(zipPath);            
            // BugsDB.Add(bugList);
            // BugActions.Assign();
        }

        private static void SqlServerDbCreate()
        {
            var sqlServerDbContext = new SqlServerDbContext();

            using (sqlServerDbContext)
            {
                sqlServerDbContext.Database.CreateIfNotExists();
            }
        }

        private static void MongoDBCreate()
        {
            var client = new MongoClient(@"mongodb://localhost");

            var dbContext = client.GetDatabase("TeamVesper");

            dbContext.DropCollection("Devs");
            var devs = dbContext.GetCollection<MongoDeveloper>("Devs");

            ICollection<MongoDeveloper> MongoDevs = new List<MongoDeveloper>();

            // Team Razors
            MongoDevs.Add(new MongoDeveloper("pesho", "Petar Petrov", 20, "UX Designer", "Razors", false));
            MongoDevs.Add(new MongoDeveloper("gosho", "Georgi Georgiev", 34, ".Net Developer", "Razors", true));
            MongoDevs.Add(new MongoDeveloper("tisho", "Tihomir Ivanov", 28, "QA Developer", "Razors", false));
            MongoDevs.Add(new MongoDeveloper("mani", "Mihail Trenchev", 25, ".Net Developer", "Razors", false));
            MongoDevs.Add(new MongoDeveloper("ghost", "Silviq Stoqnova", 24, ".Net Developer", "Razors", false));
            MongoDevs.Add(new MongoDeveloper("mina", "Milena Naydenova", 28, "Javascript Developer", "Razors", false));

            // Team Overpowered
            MongoDevs.Add(new MongoDeveloper("hope", "Vqra Dimitrova", 26, "System Administrator", "Overpowered", false));
            MongoDevs.Add(new MongoDeveloper("gri6o", "Georgi Jevel", 30, "System Administrator", "Overpowered", true));
            MongoDevs.Add(new MongoDeveloper("storm", "Simeon Vlajkov", 27, "C++ Developer", "Overpowered", false));
            MongoDevs.Add(new MongoDeveloper("TheHub", "Emil Minchev", 25, "Database Developer", "Overpowered", false));
            MongoDevs.Add(new MongoDeveloper("hardy", "Dimitar Kolev", 33, "Embedded Programer", "Overpowered", false));

            // Team Fire
            MongoDevs.Add(new MongoDeveloper("pixel", "Valeriq Angelova", 27, "UX Designer", "Fire", false));
            MongoDevs.Add(new MongoDeveloper("zyra", "Zornica Nikolova", 32, "Javascript Developer", "Fire", false));
            MongoDevs.Add(new MongoDeveloper("diana", "Diana Stefanova", 31, "UX Designer", "Fire", true));
            MongoDevs.Add(new MongoDeveloper("lori", "Lora Ivanova", 23, "Javascript Developer", "Fire", false));
            MongoDevs.Add(new MongoDeveloper("king", "Georgi Todorov", 28, "Javascript Developer", "Fire", false));
            MongoDevs.Add(new MongoDeveloper("cyclone", "Todor Georgiev", 30, "Javascript Developer", "Fire", false));

            // Team Extreme
            MongoDevs.Add(new MongoDeveloper("key", "Krasimir Velchev", 28, "C++ Developer", "Extreme", false));
            MongoDevs.Add(new MongoDeveloper("eagle", "Evgeni Mihaylov", 25, "C++ Developer", "Extreme", false));
            MongoDevs.Add(new MongoDeveloper("ermac", "Stefan Angelov", 30, "C++ Developer", "Extreme", true));
            MongoDevs.Add(new MongoDeveloper("stoneface", "Sinmeon Stoqnov", 28, "QA Developer", "Extreme", false));
            MongoDevs.Add(new MongoDeveloper("rocket", "Radostina Koleva", 23, "QA Developer", "Extreme", false));
            MongoDevs.Add(new MongoDeveloper("cable", "Boris Danailov", 25, "Embedded Programer", "Extreme", false));
            MongoDevs.Add(new MongoDeveloper("TLO", "Fani Hristova", 23, "Embedded Programer", "Extreme", false));

            // Team Core
            MongoDevs.Add(new MongoDeveloper("royal", "Daniel Qnkov", 35, "Software Architect", "Core", false));
            MongoDevs.Add(new MongoDeveloper("Gandalf", "Petar Veselinov", 37, "Software Architect", "Core", true));
            MongoDevs.Add(new MongoDeveloper("impact", "Gergana Jivkova", 32, "Software Architect", "Core", false));

            devs.InsertMany(MongoDevs);
            // System.Console.WriteLine(devs.Find(_ => true).ToList().Count);
        }

        private static void SQLiteDbCreate()
        {
            const string SQLiteDbFilePath = @"../../../TeamVesperSQLiteDb.sqlite";

            const string SQLiteDbConnectionString = @"Data Source=TeamVesperSQLiteDb.sqlite;Version=3;";

            SQLiteConnection.CreateFile(SQLiteDbFilePath);

            SQLiteConnection connection = new SQLiteConnection(SQLiteDbConnectionString);

            connection.Open();

            string sqLiteDbCompanyTableCreationQuery = @"CREATE TABLE Companies(
                                                             Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
                                                             Name VARCHAR(50) NOT NULL)";
            SQLiteCommand createCompanies = new SQLiteCommand(sqLiteDbCompanyTableCreationQuery, connection);
            createCompanies.ExecuteNonQuery();

            string sqLiteDbEmployeesTableCreationQuery = @"CREATE TABLE Employees(
                                                               Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
                                                               FullName VARCHAR(30) NOT NULL,
                                                               Salary MONEY NOT NULL, 
                                                               CompanyId INTEGER NOT NULL,
                                                               FOREIGN KEY(CompanyId) REFERENCES Companies(Id))";
            SQLiteCommand createEmployees = new SQLiteCommand(sqLiteDbEmployeesTableCreationQuery, connection);
            createEmployees.ExecuteNonQuery();

            SQLiteCommand insertCompanies = new SQLiteCommand(
                                              @"INSERT INTO Companies (Name) VALUES('SolidDrive');
                                                    INSERT INTO Companies (Name) VALUES('ComplexitySoft');
                                                    INSERT INTO Companies (Name) VALUES('Zennheizer');
                                                    INSERT INTO Companies (Name) VALUES('Tele-rik');",
                                                connection);
            insertCompanies.ExecuteNonQuery();

            SQLiteCommand insertEmployees = new SQLiteCommand(
                                       @"INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Petar Petrov', 1500, 1);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Georgi Georgiev', 2500, 1);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Tihomir Ivanov', 2000, 1);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Mihail Trenchev', 1800, 1);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Silviq Stoqnova', 2000, 1);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Milena Naydenova', 1800, 1);

                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Vqra Dimitrova', 2000, 1);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Georgi Jevel', 2500, 1);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Simeon Vlajkov', 1700, 1);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Emil Minchev', 1600, 1);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Dimitar Kolev', 2000, 1);

                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Valeriq Angelova', 1800, 2);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Zornica Nikolova', 1600, 2);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Diana Stefanova', 2500, 2);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Lora Ivanova', 1400, 2);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Georgi Todorov', 2000, 2);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Todor Georgiev', 2100, 2);

                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Krasimir Velchev', 2200, 3);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Evgeni Mihaylov', 1700, 3);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Stefan Angelov', 2500, 3);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Sinmeon Stoqnov', 1900, 3);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Radostina Koleva', 2000, 3);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Boris Danailov', 1500, 3);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Fani Hristova', 1900, 3);

                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Daniel Qnkov', 3000, 4);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Petar Veselinov', 4000, 4);
                                            INSERT INTO Employees(FullName, Salary, CompanyId) VALUES('Gergana Jivkova', 3500, 4);",
                                        connection);
            insertEmployees.ExecuteNonQuery();

            connection.Clone();
        }

    }
}
