using System;

namespace TeamVesper.Models
{
    public class DeveloperBugsInfo
    {
        private int id;
        private string userName;
        private string firstName;
        private string lastName;
        private int bugsFixed;

        public DeveloperBugsInfo()
        {
                
        }

        public DeveloperBugsInfo( int id,
                                     string userName,
                                     string firstName,
                                     string lastName,
                                     int bugsFixed)
        {
            this.Id = id;
            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BugsFixed = bugsFixed;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id cannot be negative!");
                }

                this.id = value;
            }
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("UserName");
                }

                if (value.Length < 2 || 30 < value.Length)
                {
                    throw new ArgumentException("UserName lenght should be in range 2-30 symbols!");
                }

                this.userName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("FirstName");
                }

                if (value.Length < 2 || 50 < value.Length)
                {
                    throw new ArgumentException("FirstName lenght should be in range 2-50 symbols!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("LastName");
                }

                if (value.Length < 2 || 50 < value.Length)
                {
                    throw new ArgumentException("LastName lenght should be in range 2-50 symbols!");
                }

                this.lastName = value;
            }
        }

        public int BugsFixed
        {
            get
            {
                return this.bugsFixed;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Developer cannot fix negative number of bugs!");
                }

                this.bugsFixed = value;
            }
        }
    }
}
