using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlluminateDB {
    public enum SqlCompare {
        EqualTo,
        NotEqualTo,
        GreaterThan,
        LessThan,
        GreaterOrEqual,
        LessOrEqual
    }
    public class SqlCondition {
        public string ColumnName { get; set; }
        public string Operand { get; set; }
        public string TargetValue { get; set; }
        public SqlCondition( string _column, SqlCompare _operand, object _targetValue) {
            this.ColumnName = _column;
            switch (_operand) {
                case SqlCompare.EqualTo:this.Operand = "="; break;
                case SqlCompare.NotEqualTo: this.Operand = "!="; break;
                case SqlCompare.GreaterThan: this.Operand = ">"; break;
                case SqlCompare.LessThan: this.Operand = "<"; break;
                case SqlCompare.GreaterOrEqual: this.Operand = ">="; break;
                case SqlCompare.LessOrEqual: this.Operand = "<="; break;
            }
            this.TargetValue = IsNumber(_targetValue)? _targetValue.ToString() : $"'{_targetValue}'";
        }
        private static bool IsNumber(object value) {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }
    }
}
