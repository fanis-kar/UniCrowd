using Model.Report;
using MongoDB.Driver;
using Report.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Repositories
{
    public class UniversityReportRepository : IUniversityReportRepository
    {
        private readonly IMongoCollection<UniversityReport> _reports;

        public UniversityReportRepository(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _reports = database.GetCollection<UniversityReport>(settings.UniversitiesReportsCollectionName);
        }

        public IEnumerable<UniversityReport> GetUniversitiesReports()
        {
            return _reports.Find(report => true).ToList();
        }

        public UniversityReport GetUniversityReport(string reportId)
        {
            return _reports.Find<UniversityReport>(report => report.Id == reportId).FirstOrDefault();
        }

        public void AddUniversityReport(UniversityReport universityReport)
        {
            _reports.InsertOne(universityReport);
        }
    }
}
