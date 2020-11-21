using Model.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Repositories.Interfaces
{
    public interface IVolunteerReportRepository
    {
        IEnumerable<VolunteerReport> GetVolunteersReports();

        VolunteerReport GetVolunteerReport(string reportId);

        void AddVolunteerReport(VolunteerReport volunteerReport);
    }
}
