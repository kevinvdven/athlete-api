using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AthleteApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AthletesController : ControllerBase
{
    private readonly AthleteContext _context;

    public AthletesController(AthleteContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<AthleteDto>> GetAthletesAsync([FromQuery] string name, [FromQuery] string skill, [FromQuery] int? minAge, [FromQuery] int? maxAge, int? minYearsOfExperience)
    {
        var athletes =  _context.Athletes
            .Include(i => i.Skills)
            .Include(i => i.Championships)
            .AsSplitQuery()
            .AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            athletes = athletes.Where(w => w.Name.ToLower().Contains(name.ToLower()));
        }

        if (!string.IsNullOrEmpty(skill))
        {
            athletes = athletes.Where(w => w.Skills.Any(a => a.SkillName.ToLower() == skill.ToLower() || a.SupersetName.ToLower() == skill.ToLower()));
        }

        if (minAge != null)
        {
            athletes = athletes.Where(w => w.BirthDate.AddYears(((int) minAge)) <= DateTime.UtcNow);
        }

        if (maxAge != null)
        {
            athletes = athletes.Where(w => w.BirthDate.AddYears(((int) maxAge)) >= DateTime.UtcNow);
        }

        if (minYearsOfExperience != null)
        {
            athletes = athletes.Where(w => w.Championships.Min(m => m.Year) <= DateTime.Now.Year - minYearsOfExperience);
        }
        
        return await athletes
            .Select(s => new AthleteDto
            {
                Id = s.Id,
                Name = s.Name,
                BirthDate = s.BirthDate,
                Skills = s.Skills.Select(m => m.SkillName),
                Championships = s.Championships.Select(m => $"{m.Name} {m.Year}")
            })
            .ToListAsync();
    }
}
