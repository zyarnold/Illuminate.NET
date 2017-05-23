using System;

namespace Illuminate.Net
{
    public class DB
    {
        public static QueryBuilder Table(string _tableName) {
            var qb = new QueryBuilder(_tableName);
            return qb;
        }
    }
}
