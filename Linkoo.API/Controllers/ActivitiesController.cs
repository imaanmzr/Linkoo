using Linkoo.Domain.Entities;
using Linkoo.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Linkoo.API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly LinkooDbContext _context;

        public ActivitiesController(LinkooDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }

    }
}
