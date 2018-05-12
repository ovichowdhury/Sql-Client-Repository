using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SqlClientRepository
{
    public class SqlClientWrapper : ISqlClientWrapper
    {
        private string connectionString; // this variable is used as connection string with database

        public SqlClientWrapper(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                this.connectionString = value;
            }
        }

        public int Execute(string sqlQuery)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    conn.Open();
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int Execute(string sqlQuery, Dictionary<string, object> parameters)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    this.BindParameters(command, parameters);
                    conn.Open();
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void BindParameters(SqlCommand command, Dictionary<string, object> parameters)
        {
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                command.Parameters.Add(new SqlParameter(pair.Key, pair.Value));
            }
        }

        public List<Dictionary<string, object>> Select(string sqlQuery)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                        return this.FetchData(reader);
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private List<Dictionary<string, object>> FetchData(SqlDataReader reader)
        {
            var result = new List<Dictionary<string, object>>();
            var columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
            while (reader.Read())
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row.Add(columns[i], reader[i]);
                }
                result.Add(row);
            }
            return result;
        }

        public List<Dictionary<string, object>> Select(string sqlQuery, Dictionary<string, object> parameters)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    this.BindParameters(command, parameters);
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                        return this.FetchData(reader);
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


    }
}
