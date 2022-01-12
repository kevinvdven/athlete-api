namespace AthleteApi.Models;

public class Skill
{
    public int Id { get; set; }

    public string SkillName { get; set; }
    public string SupersetName { get; set; }

    public List<Athlete> Athletes { get; set; }
}
