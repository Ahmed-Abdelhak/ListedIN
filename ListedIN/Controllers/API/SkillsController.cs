using ListedIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ListedIN.Controllers.API
{
    public class SkillsController : ApiController
    {

        private ApplicationDbContext _context;

        public SkillsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Skill> GetSkills(string query = null)
        {
            var skillsQuery = _context.Skills.Where(s => s.Name.Contains(query)).ToList();

            if (!String.IsNullOrWhiteSpace(query))
                return skillsQuery;

            return null;
        }
    }
}
