using System;
using IlluminateDB;

namespace AppTest
{
    class Program
    {
        static void Main(string[] args)
        {   
            string asdf = null;
            string test = DB.Table("Users")
                .Select("username", "password", "birthDate")
                .Where("username", "=", asdf)
                .OrWhere("username", "=", "fffffffffff")
                .Where((QueryBuilder qb)=>{
                    qb.Where("password", "=", "kurapikx")
                    .OrWhere((QueryBuilder qb2)=> {
                        qb2.Where("age", ">", 1)
                        .Where("age", "<", 99);
                    });
                })
                .Get();
            Console.Write(test);
            Console.Write("asdf");
        }
    }
}
