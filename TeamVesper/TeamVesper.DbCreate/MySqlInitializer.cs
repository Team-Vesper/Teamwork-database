using MySql.Data.MySqlClient;
using TeamVesper.DbCreate.Contracts;

namespace TeamVesper.DbCreate
{
    public class MySqlInitializer : IDbInitializer
    {
        public void CreateDB()
        {
            var connection = new MySqlConnection(@"server=localhost;uid=root;pwd=pass");
            string magic = @"
                            CREATE DATABASE IF NOT EXISTS `TeamVesperMySql`;
                            USE `TeamVesperMySql`;
                            DROP TABLE IF EXISTS `DeveloperBugsInfo`;
                            
                            CREATE TABLE `DeveloperBugsInfo`(
                            `Id` int(10) NOT NULL AUTO_INCREMENT,
                            `Username` varchar(30) NOT NULL,
                            `FirstName` varchar(50) NOT NULL,
                            `LastName` varchar(50) NOT NULL,
                            `BugsFixed` int(5) NOT NULL,
                            PRIMARY KEY (`Id`),
                            UNIQUE KEY `Id_UNIQUE` (`Id`)
                            )ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
                            ";
            connection.Open();
            using (connection)
            {
                MySqlCommand command = new MySqlCommand(magic, connection);

                command.ExecuteScalar();
            }
        }
    }
}
