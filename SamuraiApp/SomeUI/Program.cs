using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using SamuraiApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;

namespace SomeUI
{
   
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        static void Main(string[] args)
        {
            _context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
            //InsertSamurai();
            //InsertMultipleSamurais();
            //SimpleSamuraiQuery();
            //MoreQueries();
            //RetrieveAndUpdateSamurai();
            //RetrieveAndUpdateMultipleSamurais();
            //QueryAndUpdateSamuraiDisconnected(); 
            //DeleteWhileTracked();                                  
            //DeleteWhileNotTracked();                                     
            // DeleteMany();
            //RawSqlQuery();
            //RawSqlStoredProcedure();
            RawSqlCommand();
        }



        private static void RawSqlCommand()
        {
            var affected = _context.Database.ExecuteSqlCommand(
              "update samurais set Name=REPLACE(Name,'Wu','Amber')");  //return the number of rows affected.
            Console.WriteLine($"Affected rows {affected}");
        }



        private static void RawSqlStoredProcedure()
        {
            var namePart = "Kevin";
            var samurais = _context.Samurais
              .FromSql("EXEC FilterSamuraiByNamePart {0}", namePart)
              .OrderByDescending(s => s.Name).ToList();  //does not add to the stored procedure code. processed in memory.

            samurais.ForEach(s => Console.WriteLine(s.Name));
            Console.WriteLine();
        }

        private static void RawSqlQuery()
        {
            var samurais = _context.Samurais.FromSql("Select * from Samurais")
                          .OrderByDescending(s => s.Name)   //will add to the query directly
                          .Where(s => s.Name.Contains("Kang")).ToList();  //will add to the query directly
            
            samurais.ForEach(s => Console.WriteLine(s.Name));
            Console.WriteLine();
        }


        


        private static void RawSqlCommandWithOutput()
        {
            var procResult = new SqlParameter
            {
                ParameterName = "@procResult",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Output,
                Size = 50
            };
            _context.Database.ExecuteSqlCommand(
              "exec FindLongestName @procResult OUT", procResult);
            Console.WriteLine($"Longest name: {procResult.Value}");
        }




        private static void DeleteWhileTracked()
        {
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == "Kambei Shimada");
            _context.Samurais.Remove(samurai);
            //alternates:
            // _context.Remove(samurai);
            // _context.Entry(samurai).State=EntityState.Deleted;
            // _context.Samurais.Remove(_context.Samurais.Find(1));
            _context.SaveChanges();
        }

        private static void DeleteMany()
        {
            var samurais = _context.Samurais.Where(s => s.Name.Contains("ō"));
            _context.Samurais.RemoveRange(samurais);
            //alternate: _context.RemoveRange(samurais);
            _context.SaveChanges();
        }

        private static void DeleteWhileNotTracked()
        {
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == "Heihachi Hayashida");
            using (var contextNewAppInstance = new SamuraiContext())
            {
                contextNewAppInstance.Samurais.Remove(samurai);
                //contextNewAppInstance.Entry(samurai).State=EntityState.Deleted;
                contextNewAppInstance.SaveChanges();
            }

        }

        private static void QueryAndUpdateSamuraiDisconnected()
        {
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == "PeterWu");
            samurai.Name += "Kang";
            using(var toBeUpdatedInstance=new SamuraiContext() )
            {
                toBeUpdatedInstance.Samurais.Update(samurai);
                toBeUpdatedInstance.SaveChanges();
            }
                
        }

        private static void RetrieveAndUpdateMultipleSamurais()
        {
            var samurais = _context.Samurais.ToList();
            samurais.ForEach(s => s.Name += "Wu");
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "Kang";
            _context.SaveChanges();
        }

        private static void MoreQueries()
        {

            //var samurais = _context.Samurais.Where(s => s.Name == "Kevin").FirstOrDefault();//return null if not exist
            var name = "Kevin";
            var samurais = _context.Samurais.FirstOrDefault(s => s.Name == name);//return null if not exist

        }

        private static void SimpleSamuraiQuery()
        {
            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais.ToList(); // better than the code below.
                //another way, make dbconnections open is not good.
                var query = context.Samurais;
                foreach(var samurai in query)
                {
                    Console.WriteLine(samurai.Name);
                }
            }
        }

        private static void InsertMultipleSamurais()
        {
            var samurai = new Samurai { Name = "Peter" };
            var samuraiKevin = new Samurai { Name = "Kevin" };
            using (var context = new SamuraiContext())
            {
                context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
                context.Samurais.AddRange(new List<Samurai> { samurai, samuraiKevin });
                context.SaveChanges();
            }
        }

        private static void InsertSamurai()
        {
            var samurai = new Samurai { Name = "Julie" };
            using (var context=new SamuraiContext())
            {
                context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }
    }
}
