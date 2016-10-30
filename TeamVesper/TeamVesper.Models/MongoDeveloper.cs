using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

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
                                bool isTeamLeader)
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
        [JsonProperty("id")]
        public string Id { get; set; }

        [BsonElement("userName")]
        [JsonProperty("userName")]
        public string Username { get; set; }

        [BsonElement("fullName")]
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [BsonElement("age")]
        [JsonProperty("age")]
        public int Age { get; set; }

        [BsonElement("salary")]
        [JsonProperty("salary")]
        public int Salary { get; set; }

        [BsonElement("speciality")]
        [JsonProperty("speciality")]
        public string Speciality { get; set; }

        [BsonElement("team")]
        [JsonProperty("team")]
        public string Team { get; set; }

        [BsonElement("isTeamLeader")]
        [JsonProperty("isTeamLeader")]
        public bool isTeamLeader { get; set; }
    }
}
