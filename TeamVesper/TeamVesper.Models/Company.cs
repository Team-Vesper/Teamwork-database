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

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be null.");
                }

                this.name = value;
            }
        }

        public decimal AverageSalary
        {
            get
            {
                return this.averageSalary;
            }

            set
            {
                this.averageSalary = value;
            }
        }
    }

}
