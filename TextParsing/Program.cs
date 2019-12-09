using System;
using System.IO;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TextParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
            var database = dbClient.GetDatabase("Orxe");
            var collection = database.GetCollection<Region>("Region");

            string fileLocation = "C:/Users/rarai/source/repos/TextParsing/TextParsing/PointOfInterestCoordinatesList.txt";

            using (StreamReader SR = new StreamReader(fileLocation))
            {
                SR.ReadLine();
                string[] lines = SR.ReadToEnd().Split('\n');
                foreach (string line in lines)
                {
                    string[] tokens = line.Split('|');
                    Region region = new Region(tokens);
                    try
                    {
                        collection.InsertOne(region);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                        continue;
                    }
                }

            };
            
        }
    }
}
