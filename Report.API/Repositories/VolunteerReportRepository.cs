using Model.Report;
using MongoDB.Driver;
using Report.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Repositories
{
    public class VolunteerReportRepository : IVolunteerReportRepository
    {
        private readonly IMongoCollection<VolunteerReport> _reports;

        public VolunteerReportRepository(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _reports = database.GetCollection<VolunteerReport>(settings.VolunteersReportsCollectionName);
        }

        public IEnumerable<VolunteerReport> GetVolunteersReports()
        {
            return _reports.Find(report => true).ToList();
        }

        public VolunteerReport GetVolunteerReport(string reportId)
        {
            return _reports.Find<VolunteerReport>(report => report.Id == reportId).FirstOrDefault();
        }

        public void AddVolunteerReport(VolunteerReport volunteerReport)
        {
            _reports.InsertOne(volunteerReport);
        }
    }
}
