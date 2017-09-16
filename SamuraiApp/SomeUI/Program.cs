using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using SamuraiApp.Data;

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
            QueryAndUpdateSamuraiDisconnected();

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
