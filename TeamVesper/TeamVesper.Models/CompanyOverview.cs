namespace TeamVesper.Models
{
    public class CompanyOverview : Company
    {
        public CompanyOverview()
        {

        }

        public CompanyOverview(string name, decimal averageSalary, int NumberOfDevelopers, int NumberOfFixedBugs)
            : base(name, averageSalary)
        {
        }

        // TODO: join name + salary from sqlite with employees, bugs, etc from mysql here

        public int NumberOfDevelopers { get; set; }

        public int NumberOfFixedBugs { get; set; }
    }
}
