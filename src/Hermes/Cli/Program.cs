using DatabaseAccessLayer;
using System;

namespace Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new HRContext())
            {
                var locations = db.Locations;

                foreach (var location in locations)
                {
                    Console.WriteLine(location);
                }
            }

            Console.ReadKey(true);
        }
    }
}
