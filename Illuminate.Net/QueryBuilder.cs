using System;
using System.Collections.Generic;
using System.Text;

namespace Illuminate.Net
{
    public class QueryBuilder
    {
        private string TableName { get; set; }
        private List<string> Columns { get; set; } = new List<string>();
        private List<string> WhereClauses { get; set; } = new List<string>();
        public QueryBuilder(string _table) {
            this.TableName = _table;
        }
        public /*List<Dictionary<string, object>>*/ string Get() {
            string query = "";
            //initial query
            if (this.Columns.Count<1){
                query = $"SELECT * FROM {this.TableName} ";
            }
            else{
                string colQuery = "?";
                foreach(var col in this.Columns){
                    colQuery += $" ,{col} ";
                }
                colQuery = colQuery.Replace("?,",",");
                query = $"SELECT {colQuery} FROM {this.TableName} ";
            }
            //where clauses
            
            return query;
        }

        public QueryBuilder Where(string _columnName, string _operand, object _value){
            this.WhereClauses.Add($"{_columnName} {_operand} {_value.ToString()}");
            return this;
        }


    }
}
