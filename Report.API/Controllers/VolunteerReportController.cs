using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Report;
using Report.API.Repositories;
using Report.API.Repositories.Interfaces;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Volunteer")]
    public class VolunteerReportController : ControllerBase
    {
        private readonly IVolunteerReportRepository _VolunteerReportRepository;

        public VolunteerReportController(IVolunteerReportRepository VolunteerReportRepository)
        {
            _VolunteerReportRepository = VolunteerReportRepository;
        }

        // GET ~/api/VolunteerReport
        [HttpGet]
        public ActionResult<IEnumerable<VolunteerReport>> GetUniversitiesReports()
        {
            return _VolunteerReportRepository.GetVolunteersReports().ToList();
        }

        // GET ~/api/VolunteerReport/{id}
        [HttpGet("{id:length(24)}")]
        public ActionResult<VolunteerReport> GetVolunteerReport(string id)
        {
            return _VolunteerReportRepository.GetVolunteerReport(id);
        }

        // POST ~/api/VolunteerReport
        [HttpPost]
        public ActionResult AddVolunteerReport([FromBody] VolunteerReport VolunteerReport)
        {
            _VolunteerReportRepository.AddVolunteerReport(VolunteerReport);

            return new OkResult();
        }
    }
}
