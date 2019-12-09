using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace TextParsing
{
    public class Region
    {
        [BsonId]
        long RegionID { get; set; }

        [BsonElement("RegionName")]
        string RegionName { get; set; }

        [BsonElement("RegionNameLong")]
        string RegionNameLong { get; set; }

        [BsonElement("Latitude")]
        double Latitude { get; set; }

        [BsonElement("Longitude")]
        double Longitude { get; set; }

        [BsonElement("SubClassification")]
        string SubClassification { get; set; }

        public Region(string[] tokens)
        {
            this.RegionID = long.Parse(tokens[0]);
            this.RegionName = tokens[1];
            this.RegionNameLong = tokens[2];
            this.Latitude = double.Parse(tokens[3]);
            this.Longitude = double.Parse(tokens[4]);
            this.SubClassification = tokens[5];
        }
    }
}
