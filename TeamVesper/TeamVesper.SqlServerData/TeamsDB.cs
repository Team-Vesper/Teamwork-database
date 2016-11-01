namespace TeamVesper.SqlServerData
{
    using System.Linq;
    using Models;

    public static class TeamsDB
    {
        public static void Add()
        {
            var sqlSever = new SqlServerDbContext();
            string[] teams = new string[5];
            teams[0] = "Razors";
            teams[1] = "Overpowered";
            teams[2] = "Fire";
            teams[3] = "Extreme";
            teams[4] = "Core";

            foreach (var team in teams)
            {
                if (sqlSever.Teams.Any(t => t.Name == team))
                {
                }
                else
                {
                    Team teamToAdd = new Team(team);
                    sqlSever.Teams.Add(teamToAdd);
                }
            }

            sqlSever.SaveChanges();
        }
    }
}
