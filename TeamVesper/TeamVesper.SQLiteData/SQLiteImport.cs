using System;
using System.Collections.Generic;

using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
using TeamVesper.Models;
using TeamVesper.Repositories.Contracts;

namespace TeamVesper.SQLiteData
{
    public class SQLiteImport : IReadableRepository<Company>
    {
        private const string defaultConnectionString = @"Data Source=TeamVesperSQLiteDb.sqlite;Version=3;";
        private string sqLiteDbConnectionString;
        
        public SQLiteImport(string connectionString = defaultConnectionString)
        {
            this.SQLiteDbConnectionString = connectionString;
        }

        public string SQLiteDbConnectionString
        {
            get
            {
                return this.sqLiteDbConnectionString;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Connection string cannot by null.");
                }

                this.sqLiteDbConnectionString = value;
            }
        }

        public IEnumerable<Company> All()
        {
            return this.ExtractCompaniesAndTheirAverageSalaries();
        }

        public IEnumerable<Company> All(Expression<Func<Company, bool>> filterExpresion)
        {
            var predicate = filterExpresion.Compile();

            return this.ExtractCompaniesAndTheirAverageSalaries().Where(predicate).ToList();
        }

        private IEnumerable<Company> ExtractCompaniesAndTheirAverageSalaries()
        {
            SQLiteConnection dbConnection = new SQLiteConnection(sqLiteDbConnectionString);
            dbConnection.Open();

            SQLiteCommand companiesAndTheirAverageSalariesQuery = new SQLiteCommand(@"SELECT Companies.Name, AVG(Salary) as AverageSalary
                                                                FROM Employees
                                                                INNER JOIN Companies
                                                                ON Companies.Id = Employees.CompanyId
                                                                GROUP BY Companies.Name
                                                                ORDER BY AverageSalary DESC", dbConnection);

            SQLiteDataReader reader = companiesAndTheirAverageSalariesQuery.ExecuteReader();

            var companyCollection = new List<Company>();

            using (reader)
            {
                while (reader.Read())
                {
                    var company = new Company(reader["Name"].ToString(), Convert.ToDecimal(reader["AverageSalary"]));

                    companyCollection.Add(company);
                }
            }

            dbConnection.Clone();

            return companyCollection;
        }
    }
}