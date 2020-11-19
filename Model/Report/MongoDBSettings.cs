using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Report
{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string UniversitiesReportsCollectionName { get; set; }

        public string VolunteersReportsCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }

    public interface IMongoDBSettings
    {
        string UniversitiesReportsCollectionName { get; set; }

        string VolunteersReportsCollectionName { get; set; }

        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}
