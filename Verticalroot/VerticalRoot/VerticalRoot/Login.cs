﻿using System;
using MySql.Data.MySqlClient;

namespace VerticalRoot
{
    public class Login
    {
        public static int userId { get; set; }
        public int checkLogin(string usr, string pwd)
        {
            Db db = new Db();

            db.OpenConnection();
            System.Data.DataTable table = new System.Data.DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE name = @usn and password = @pass", db.GetConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = usr;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pwd;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            using (MySqlDataReader getUserId = adapter.SelectCommand.ExecuteReader())
            {
                if (getUserId.HasRows)
                {
                    while (getUserId.Read())
                    {
                        if (table.Rows.Count > 0)
                        {
                            userId = Convert.ToInt32(getUserId["id"]);
                            return userId;
                        }
                    }
                }
                return 0;
            }
        }
    }
}
