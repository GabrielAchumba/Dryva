using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Helpers
{
    public class ConnectionUtil
    {
        public static DbConnection GetConnection(string connectionString)
        {
           return new SqlConnection(connectionString);
        }
    }
}
