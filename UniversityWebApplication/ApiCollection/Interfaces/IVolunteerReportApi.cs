using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Model.Report;

namespace UniversityWebApplication.ApiCollection.Interfaces
{
    public interface IVolunteerReportApi
    {
        Task<List<VolunteerReport>> GetVolunteersReports(string jwtToken);

        Task<VolunteerReport> GetVolunteerReport(int reportId, string jwtToken);

        Task<string> AddVolunteerReport(VolunteerReport volunteerReport, string jwtToken);
    }
}
