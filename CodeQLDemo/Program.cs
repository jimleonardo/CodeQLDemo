using System;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CodeQLDemo
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using SomeDbContext dbContext = new SomeDbContext();
            Console.WriteLine(dbContext.MyEntities.Find(1).Name);

            // let's try some sql injection, shall we?
            if (!args.Any()) return;
            Console.WriteLine(dbContext.Database.ExecuteSqlRaw($"select from UltraSecrets where Name like '{args.First()}'"));
            if (args.Length >= 2)
            {
                Console.WriteLine(String.Format(args[1], DateTime.Now.ToString(CultureInfo.InvariantCulture)));
            }

            BadDisposable.DoBadDisposeThingsOrLackThereof();

            var equalsProblem1 = new EqualsProblem();
            var equalsProblem2 = new EqualsProblem();
            if (equalsProblem2.Equals(equalsProblem1))
            {
                throw new Exception("Wah wah");
            }
        }
    }
}