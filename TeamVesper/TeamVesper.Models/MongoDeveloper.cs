using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TeamVesper.Models
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

        [BsonElement("userName")]
        public string Username { get; set; }

        [BsonElement("fullName")]
        public string FullName { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("salary")]
        public int Salary { get; set; }

        [BsonElement("speciality")]
        public string Speciality { get; set; }

        [BsonElement("team")]
        public string Team { get; set; }

        [BsonElement("isTeamLeader")]
        public bool isTeamLeader { get; set; }
    }
}
