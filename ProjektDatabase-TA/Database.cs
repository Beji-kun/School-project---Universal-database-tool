using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ProjektDatabase_TA
{
    public class Database
    {
        private SqlConnection con;
        List<Tables> TablesList;
        string server = ConfigurationSettings.AppSettings["SERVER"];
        string Databnames = ConfigurationSettings.AppSettings["DATABASENAME"];
        public Database()
        {
            TablesList = new List<Tables>();
        }

        public Database(string conn_string)
        {
            TablesList = new List<Tables>();
            try
            {
                con = new SqlConnection(conn_string);
            }
            catch
            {

            }
        }

        public Database(string server, string database, string uid, string password)
        {
            TablesList = new List<Tables>();
            try
            {
                con = new SqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + password + ";");
            }
            catch
            {

            }
        }
        public Database(string uid, string password)
        {
            TablesList = new List<Tables>();
            try
            {
                con = new SqlConnection(@"SERVER=" + server + ";DATABASE=" + Databnames + ";UID=" + uid + ";PASSWORD=" + password + ";");
            }
            catch
            {

            }
        }


        public bool OpenConnection()
        {
            try
            {
                con.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Tables AddTable(Tables t)
        {
            TablesList.Add(t);
            return t;
        }

        public void CloseConnection()
        {
            try
            {
                con.Close();
            }
            catch
            {

            }
        }

        public int TableCount
        {
            get { return TablesList.Count; }
        }

        public string[] Atributtes_DataT(int Tables)
        {
            return TablesList.ElementAt(Tables).DataT();
        }
        public string[] Atributtes_names(int Tables)
        {
            return TablesList.ElementAt(Tables).Names();
        }
        public string[] Atributtes_NameD(int Tables)
        {
            return TablesList.ElementAt(Tables).NamesD();
        }

        public string[] TableNames()
        {
            string[] array = new string[TablesList.Count];
            int i = 0;
            foreach (Tables t in TablesList)
            {
                array[i] = t.Get_Name;
                i++;
            }
            return array;
        }
        public string[] TableNamesD()
        {
            string[] array = new string[TablesList.Count];
            int i = 0;
            foreach (Tables t in TablesList)
            {
                array[i] = t.Get_NameD;
                i++;
            }
            return array;
        }
        public int AtributtesCount(int Tables)
        {
            return TablesList.ElementAt(Tables).AtributtesCount;
        }

        public Tables Get_Tables(int Tables)
        {
            return TablesList.ElementAt(Tables);
        }

        public bool Insert(string[] values, int Tables)
        {

            string[] NameD = TablesList.ElementAt(Tables).NamesD();
            int count = TablesList.ElementAt(Tables).AtributtesCount;

            string command = "INSERT INTO " + TablesList.ElementAt(Tables).Get_NameD + " (";

            for (int i = 1; i < count; i++)
            {
                command += "[" + TablesList.ElementAt(Tables).Get_NameD + "].[" + NameD[i] + "]" + (i + 1 < NameD.Length ? "," : "");
            }

            command += ") VALUES (";

            for (int i = 0; i < values.Length; i++)
            {
                command += "'" + values[i] + (i + 1 < values.Length ? "'," : "'");
            }
            command += ");";

            return Transaction(command);
        }
        public bool Update(string[] values, int Tables)
        {
            string[] NameD = TablesList.ElementAt(Tables).NamesD();
            int count = TablesList.ElementAt(Tables).AtributtesCount;

            string command = "UPDATE " + TablesList.ElementAt(Tables).Get_NameD + " SET ";

            for (int i = 1; i < count; i++)
            {
                command += "[" + TablesList.ElementAt(Tables).Get_NameD + "].[" + NameD[i] + "]" + " = '" + values[i] + (i + 1 < count ? "'," : "'");
            }

            command += " WHERE " + NameD[0] + " = " + values[0] + ";";

            return Transaction(command);
        }
        public bool Delete(int Tables, int id)
        {
            string command = "DELETE FROM " + TablesList.ElementAt(Tables).Get_NameD + " WHERE " + "[" + TablesList.ElementAt(Tables).Get_NameD + "].[" + TablesList.ElementAt(Tables).NamesD()[0] + "]" + " = " + id;

            return Transaction(command);
        }
        public string Selects(int Tables)
        {
            string command = "SELECT * FROM " + TablesList.ElementAt(Tables).Get_NameD + ";";
            int count = TablesList.ElementAt(Tables).AtributtesCount;
            string[] NameD = TablesList.ElementAt(Tables).NamesD();
            string[] names = TablesList.ElementAt(Tables).Names();
            string text = "";

            try
            {
                SqlCommand cmd = new SqlCommand(command, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < count; i++)
                    {
                        text += names[i] + " : " + reader[NameD[i]].ToString() + "\n";
                    }
                    text += "\n";
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(command);
                Console.WriteLine(e.ToString());
                return command + "\nIt is not done.\n" + e.ToString();
            }
            return text;
        }

        public List<object> DataGridViews(Tables Tables)
        {
            string command = "SELECT * FROM " + Tables.Get_NameD + ";";
            int count = Tables.AtributtesCount;
            string[] NameD = Tables.NamesD();

            List<object> f = new List<object>();

            try
            {
                SqlCommand cmd = new SqlCommand(command, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < count; i++)
                    {
                        f.Add(reader[NameD[i]].ToString());
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(command);
                Console.WriteLine(e.ToString());
                return new List<object>();
            }
            return f;
        }

        public object[] SelectTableValue(Tables Tables, int id)
        {
            string command = "SELECT * FROM " + Tables.Get_NameD + ";";
            int count = Tables.AtributtesCount;
            string[] NameD = Tables.NamesD();
            object[] values = new object[Tables.AtributtesCount];

            List<object> f = new List<object>();

            try
            {
                SqlCommand cmd = new SqlCommand(command, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < count; i++)
                    {
                        f.Add(reader[NameD[i]].ToString());
                    }
                }
                reader.Close();
                for (int i = 0; i < f.Count; i += Tables.AtributtesCount)
                {
                    if (Convert.ToInt32(f[i]) == id)
                    {
                        for (int j = i; j < i + Tables.AtributtesCount; j++)
                        {
                            values[j - i] = f[j];
                        }
                        break;
                    }
                }
                return values;
            }
            catch
            {
                Console.WriteLine(command);
                return values;
            }
        }

        public bool Transaction(string command)
        {
            SqlTransaction tran = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Transaction = tran;

            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(command);
                Console.WriteLine(e.ToString());
                try
                {
                    tran.Rollback();
                }
                catch (Exception f)
                {
                    Console.WriteLine(f.ToString());
                    return false;
                }
                return false;
            }
        }
        public string BTransaction()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("exec base_info @result = @result output", con);
                SqlParameter par = cmd.Parameters.Add("@result", SqlDbType.NVarChar, 50);
                par.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return (string)par.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "Transaction failed";
            }
        }
    }
}
