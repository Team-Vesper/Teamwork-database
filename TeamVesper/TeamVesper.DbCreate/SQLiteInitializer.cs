using System.Data.SQLite;
using TeamVesper.DbCreate.Contracts;

namespace TeamVesper.DbCreate
{
    public class SQLiteInitializer : IDbInitializer
    {
        public void CreateDB()
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
