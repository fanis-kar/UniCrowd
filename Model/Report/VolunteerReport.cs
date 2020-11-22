using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Report
{
    public class VolunteerReport
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        public int TaskId { get; set; }   // Task.API - Tasks[id]
    }
}
