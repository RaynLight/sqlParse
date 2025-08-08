using System;
using System.Data.SqlClient;

namespace sqlParse
{
    internal class Connection
    {
        private SqlConnection conn;

        public bool Connect(string ip, string username, string password, out string message)
        {
            try
            {
                string connStr = $"Server={ip};Database=master;User ID={username};Password={password};";
                conn = new SqlConnection(connStr);
                conn.Open();
                message = "[+] Connected successfully.";
                Logger.Connection(username, ip, true, "Connected to master");
                return true;
            }
            catch (Exception ex)
            {
                message = $"[!] Connection failed: {ex.Message}";
                Logger.Connection(username, ip, false, ex.Message);
                return false;
            }
        }


        public string RunQuery(string query)
        {
            if (conn == null || conn.State != System.Data.ConnectionState.Open)
                return "[!] Not connected.";

            try
            {
                Logger.Query(query);
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                System.Text.StringBuilder output = new System.Text.StringBuilder();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        output.Append(reader[i].ToString() + "\t");

                    output.AppendLine();
                }

                reader.Close();
                return output.ToString();
            }
            catch (Exception ex)
            {
                return $"[!] Query failed: {ex.Message}";
            }
        }
        public SqlConnection GetConnection()
        {
            return conn;
        }

    }
}
