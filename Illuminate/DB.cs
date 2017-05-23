using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlluminateDB
{
    public class DB
    {
        public static QueryBuilder Table(string _tableName) {
            var qb = new QueryBuilder(_tableName);
            return qb;
        }
    }
}
