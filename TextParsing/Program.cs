using System;
using System.IO;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

namespace TextParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
            var database = dbClient.GetDatabase("Orxe1");
            var collection = database.GetCollection<Region>("Region");

            string fileLocation = "C:/Users/rarai/source/repos/TextParsing/TextParsing/PointOfInterestCoordinatesList.txt";

            using (StreamReader SR = new StreamReader(fileLocation))
            {
                SR.ReadLine();
                string[] lines = SR.ReadToEnd().Split('\n');
                List<Region> record = new List<Region>() { };
                watch.Start();
                foreach (string line in lines)
                {
                    string[] tokens = { "", "", "", "", "", "" };
                    tokens = line.Split('|');

                    if (tokens[0] == "")
                    {
                        continue;
                    }


                    Region region = new Region(tokens);
                    record.Add(region);

                }
                try
                {
                    collection.InsertMany(record);
                    watch.Stop();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                }

            };
                Console.WriteLine(watch.ElapsedMilliseconds);

            
            
        }
    }
}
