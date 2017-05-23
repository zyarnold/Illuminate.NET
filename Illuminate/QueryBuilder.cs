using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlluminateDB {
    public class QueryBuilder {

      

        private string TableName { get; set; }
        private List<string> Columns { get; set; } = new List<string>();
        private String where { get; set; } = "WHERE!@#";

        public QueryBuilder(string _table) {
            this.TableName = _table;
        }
        public /*List<Dictionary<string, object>>*/ string Get() {
            string query = "";
            //initial query
            if (this.Columns.Count < 1) {
                query = $"SELECT * FROM {this.TableName}";
            }
            else {
                string colQuery = "!@#";
                foreach (var col in this.Columns) {
                    colQuery += $", {col}";
                }
                colQuery = colQuery.Replace("!@#,", "");
                query = $" SELECT{colQuery} FROM {this.TableName}";
            }
            query += $" {this.BuildWhere()}";
            return query;
        }

        public QueryBuilder Select(params string[] _columns) {
            foreach(var col in _columns) {
                this.Columns.Add(col);
            }
            return this;
        }

        public QueryBuilder Where(SqlCondition condition) {
            string whereClause = $"AND {condition.ColumnName} {condition.Operand} {condition.TargetValue} ";
            this.where += whereClause;
            return this;
        }

        public QueryBuilder Where(Action<QueryBuilder> makeQuery) {
            this.where += "AND (!@#";
            makeQuery(this);
            this.where += ") ";
            return this;
        }

        public QueryBuilder OrWhere(SqlCondition condition) {
            string whereClause = $"OR {condition.ColumnName} {condition.Operand} {condition.TargetValue} ";
            this.where += whereClause;
            return this;
        }

        public QueryBuilder OrWhere(Action<QueryBuilder> makeQuery) {
            this.where += "OR (!@#";
            makeQuery(this);
            this.where += ") ";
            return this;
        }
        private string BuildWhere() {
            if (this.where.Contains("!@#OR")) {
                throw new Exception("Syntax Error. Using OrWhere() Statement before Where()");
            }
            return this.where.Replace("!@#AND", "");
        }

    }
}
