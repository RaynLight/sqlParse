using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace sqlParse
{
    internal class Scan
    {
        private SqlConnection conn;

        public Scan(SqlConnection connection)
        {
            conn = connection;
        }

        public string ScanQuery(string input)
        {
            input = input.Trim().ToLower();
            if (input == "scan")
                return ScanAll();

            if (input.StartsWith("scan "))
                return ScanDatabase(input.Substring(5));

            return "[!] Invalid scan command.";
        }

        public string ScanAll()
        {
            StringBuilder result = new StringBuilder();
            try
            {
                List<string> dbs = new List<string>();
                SqlCommand cmd = new SqlCommand("SELECT name FROM sys.databases WHERE database_id > 4", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    dbs.Add(reader.GetString(0));
                reader.Close();

                foreach (string db in dbs)
                {
                    result.AppendLine("[+] Scanning database: " + db);
                    result.AppendLine(ScanDatabase(db));
                    result.AppendLine("------------------------------------");
                }
            }
            catch (Exception ex)
            {
                result.AppendLine("[!] Failed: " + ex.Message);
                Logger.Error("ScanAll failed: " + ex.Message);
            }

            return result.ToString();
        }

        public string ScanDatabase(string dbName)
        {
            StringBuilder result = new StringBuilder();
            Queue<string> queue = new Queue<string>();

            try
            {
                List<KeyValuePair<string, string>> tables = new List<KeyValuePair<string, string>>();
                SqlCommand cmd = new SqlCommand(
                    "USE [" + dbName + "]; SELECT TABLE_SCHEMA, TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE';",
                    conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string schema = reader.GetString(0);
                    string table = reader.GetString(1);
                    tables.Add(new KeyValuePair<string, string>(schema, table));
                }
                reader.Close();

                foreach (var table in tables)
                {
                    string fullTable = "[" + dbName + "].[" + table.Key + "].[" + table.Value + "]";
                    result.AppendLine("[*] Table: " + fullTable);

                    try
                    {

                        SqlCommand selectCmd = new SqlCommand("SELECT TOP 50 * FROM " + fullTable + ";", conn);
                        SqlDataReader tblReader = selectCmd.ExecuteReader();
                        while (tblReader.Read())
                        {
                            StringBuilder line = new StringBuilder();
                            for (int i = 0; i < tblReader.FieldCount; i++)
                            {
                                object val = tblReader[i];
                                line.Append((val != null ? val.ToString() : "") + "\t");
                            }
                            queue.Enqueue(line.ToString());
                        }
                        tblReader.Close();
                    }
                    catch
                    {
                        result.AppendLine("[-] Skipped table: " + table.Key + "." + table.Value);
                    }
                }

                List<string> hits = RegexScanner.BatchScan(queue);
                foreach (string hit in hits)
                    result.AppendLine(hit);

                return result.ToString();
            }
            catch (Exception ex)
            {
                return "[!] Scan error in " + dbName + ": " + ex.Message;
            }
        }
    }
}
