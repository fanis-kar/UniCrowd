using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Report;
using Report.API.Repositories.Interfaces;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "University")]
    public class UniversityReportController : ControllerBase
    {
        private readonly IUniversityReportRepository _universityReportRepository;

        public UniversityReportController(IUniversityReportRepository universityReportRepository)
        {
            _universityReportRepository = universityReportRepository;
        }

        // GET ~/api/UniversityReport
        [HttpGet]
        public ActionResult<IEnumerable<UniversityReport>> GetUniversitiesReports()
        {
            return _universityReportRepository.GetUniversitiesReports().ToList();
        }

        // GET ~/api/UniversityReport/{id}
        [HttpGet("{id:int}")]
        public ActionResult<UniversityReport> GetUniversityReport(string id)
        {
            return _universityReportRepository.GetUniversityReport(id);
        }

        // POST ~/api/UniversityReport
        [HttpPost]
        public ActionResult AddUniversityReport([FromBody] UniversityReport universityReport)
        {
            _universityReportRepository.AddUniversityReport(universityReport);

            return new OkResult();
        }
    }
}
