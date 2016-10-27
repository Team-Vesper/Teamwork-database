using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TeamVesper.MongoDB.Models
{
    public class MongoDeveloper
    {
        public MongoDeveloper()
        {

        }

        public MongoDeveloper(string username,
                                string fullName, 
                                int age, 
                                int salary, 
                                string speciality, 
                                string team, 
                                bool isTeamLeader )
        {
            this.Username = username;
            this.FullName = fullName;
            this.Age = age;
            this.Salary = salary;
            this.Speciality = speciality;
            this.Team = team;
            this.isTeamLeader = isTeamLeader;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public int Salary { get; set; }

        public string Speciality { get; set; }

        public string Team { get; set; }

        public bool isTeamLeader { get; set; }
    }
}
