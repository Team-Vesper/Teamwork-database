using System;

namespace TeamVesper.Models
{
    public class DeveloperBugsInfo
    {
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

        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int BugsFixed { get; set; }
    }
}
