using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Model.Report;

namespace UniversityApiCollection.Interfaces
{
    public interface IUniversityReportApi
    {
        Task<List<UniversityReport>> GetUniversitiesReports(string jwtToken);

        Task<UniversityReport> GetUniversityReport(string reportId, string jwtToken);

        Task<string> AddUniversityReport(UniversityReport universityReport, string jwtToken);
    }
}
