using System;

namespace TeamVesper.Models
{
    public class BugReport
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? AcceptedOn { get; set; }

        public DateTime? SolvedOn { get; set; }
    }
}
