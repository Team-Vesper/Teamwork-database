namespace TeamVesper.DbCreate
{
    using System.Linq;
    using Models;
    using SqlServerData;

    class AddSpecialities
    {
        public static void Add()
        {
            var sqlSever = new SqlServerDbContext();
            string[] specialities = new string[9];
            specialities[0] = "UX Designer";
            specialities[1] = "Javascript Developer";
            specialities[2] = ".Net Developer";
            specialities[3] = "QA Developer";
            specialities[4] = "System Administrator";
            specialities[5] = "C++ Developer";
            specialities[6] = "Database Developer";
            specialities[7] = "Embedded Programer";
            specialities[8] = "Software Architect";

            foreach (var sp in specialities)
            {
                if (sqlSever.Specialities.Any(s => s.Name == sp))
                {
                }
                else
                {
                    Speciality speciality = new Speciality(sp);
                    sqlSever.Specialities.Add(speciality);
                }
            }

            sqlSever.SaveChanges();
        }
    }
}
