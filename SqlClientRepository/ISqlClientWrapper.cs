using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlClientRepository
{
    public interface ISqlClientWrapper
    {
        string ConnectionString { get; set; }
        int Execute(string sqlQuery); // for executing query in the database
        int Execute(string sqlQuery, Dictionary<string, object> parameters); // for executing query in the database
        List<Dictionary<string, object>> Select(string sqlQuery); // for retrieving value from database 
        List<Dictionary<string, object>> Select(string sqlQuery, Dictionary<string, object> parameters); // for retrieving value from database
    }
}
