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
        int Execute(string sqlQuery);
        int Execute(string sqlQuery, Dictionary<string, object> parameters);
        List<Dictionary<string, object>> Select(string sqlQuery);
        List<Dictionary<string, object>> Select(string sqlQuery, Dictionary<string, object> parameters);
    }
}
