using Model.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Repositories.Interfaces
{
    public interface IUniversityReportRepository
    {
        IEnumerable<UniversityReport> GetUniversitiesReports();

        UniversityReport GetUniversityReport(string reportId);

        void AddUniversityReport(UniversityReport universityReport);
    }
}
