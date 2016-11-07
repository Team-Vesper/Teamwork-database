using System;

namespace TeamVesper.Models
{
    public class Company
    {
        // no DataAnnotations - hand made class until we find another solution :)

        private string name;
        private decimal averageSalary;

        public Company()
        {

        }

        public Company(string name, decimal averageSalary)
        {
            this.Name = name;
            this.AverageSalary = averageSalary;
        }

        public string Name { get; set; }

        public decimal AverageSalary { get; set; }
    }

}
