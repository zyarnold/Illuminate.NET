using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IlluminateDB;

namespace appTest {
    class Program {
        static void Main(string[] args) {
            string test = DB.Table("Users")
                .Select("username", "password", "birthDate")
                .Where(new SqlCondition("username", SqlCompare.EqualTo, "arnold.naval99"))
                .OrWhere(new SqlCondition("username", SqlCompare.EqualTo, "iamronajane21"))
                .Where((QueryBuilder qb)=>{
                    qb.Where(new SqlCondition("password", SqlCompare.EqualTo, "kurapikx"))
                    .OrWhere((QueryBuilder qb2)=> {
                        qb2.Where(new SqlCondition("age", SqlCompare.GreaterThan, 1))
                        .Where(new SqlCondition("age", SqlCompare.LessThan, 99));
                    });
                })
                .Get();
            System.Diagnostics.Debug.Print(test);
            Console.Write(test);
            Console.ReadLine();
        }
    }
}
