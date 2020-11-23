using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Model.Report;

namespace UniversityApiCollection.Interfaces
{
    public interface IVolunteerReportApi
    {
        Task<List<VolunteerReport>> GetVolunteersReports(string jwtToken);

        Task<VolunteerReport> GetVolunteerReport(string reportId, string jwtToken);

        Task<string> AddVolunteerReport(VolunteerReport volunteerReport, string jwtToken);
    }
}
