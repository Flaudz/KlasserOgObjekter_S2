using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace KlasserOgObjekter
{
    public class db
    {
        private string connectionString = "Data Source=CV-BB-5992;Initial Catalog=TheWizzardsOfDodulu;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private DataSet Execute(string query)
        {
            DataSet resultSet = new DataSet();
            using(SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, new SqlConnection(connectionString))))
            {
                adapter.Fill(resultSet);
            }
            return resultSet;
        }

        public List<Wand> GetWands()
        {
            List<Wand> allWands = new List<Wand>(0);
            string allWandsQuery = "SELECT * FROM Wands";

            // Perform query  and save result in variable:
            DataSet resultSet = Execute(allWandsQuery);

            // Get the first table of the data set, and save in variable
            DataTable wandsTable = resultSet.Tables[0];


            // Iterate through the rows of the table, and extract the data,
            // and create a new wand object each tim, and add that to the list of wands.
            foreach (DataRow wandRow in wandsTable.Rows)
            {
                int id = (int)wandRow["id"];
                string name = (string)wandRow["name"];
                int damage = (int)wandRow["damage"];
                int cost = (int)wandRow["cost"];

                Wand wand = new Wand();
                wand.Id = id;
                wand.Name = name;
                wand.Cost = cost;
                wand.WandDamage = damage;
                allWands.Add(wand);
            }
            return allWands;
        }

        
        public void AddNewWand(Wand wand)
        {
            string addNewWandQuery =
                $"INSERT INTO Wands (Name, Cost)({wand.Name}, {wand.Cost})";
            Execute(addNewWandQuery);
        }

        // Players
        public Player GetPlayers()
        {
            Player player = new Player();
            string allPlayersQuery = "SELECT * FROM Players";

            // Perform query  and save result in variable:
            DataSet resultSet = Execute(allPlayersQuery);

            // Get the first table of the data set, and save in variable
            DataTable playersTable = resultSet.Tables[0];


            // Iterate through the rows of the table, and extract the data,
            // and create a new Person object each time.
            foreach (DataRow playerRow in playersTable.Rows)
            {
                int id = (int)playerRow["id"];
                string name = (string)playerRow["name"];
                int health = (int)playerRow["health"];
                int strength = (int)playerRow["strength"];
                int level = (int)playerRow["level"];
                int xp = (int)playerRow["xp"];
                int mana = (int)playerRow["mana"];
                int gold = (int)playerRow["gold"];

                player.Name = name;
                player.Health = health;
                player.Strength = strength;
                player.Level = level;
                player.Xp = xp;
                player.Mana = mana;
                player.Gold = gold;
            }
            return player;
        }
        public void SavePlayer(int strength, int level, int xp, int mana, int gold)
        {
            string SavePlayerQuery =
                $"UPDATE Players SET id = {1}, health = {100}, strength = {strength}, level = {level}, xp = {xp}, mana = {100}, gold = {gold}";
            Execute(SavePlayerQuery);
        }


        // Villains
        public List<Target> GetTargets()
        {
            List<Target> targetList = new List<Target>();
            string allTargetsQuery = "SELECT * FROM Targets";

            // Perform query  and save result in variable:
            DataSet resultSet = Execute(allTargetsQuery);

            // Get the first table of the data set, and save in variable
            DataTable targetsTable = resultSet.Tables[0];


            // Iterate through the rows of the table, and extract the data,
            // and create a new Person object each time.
            foreach (DataRow targetRow in targetsTable.Rows)
            {
                int id = (int)targetRow["id"];
                string name = (string)targetRow["name"];
                int health = (int)targetRow["health"];
                int strength = (int)targetRow["strenght"];
                int level = (int)targetRow["level"];
                Target target = new Target();
                target.Name = name;
                target.Health = health;
                target.Strength = strength;
                target.Level = level;
                targetList.Add(target);
            }
            return targetList;
        }
    }
}
