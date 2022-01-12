namespace AthleteApi.Models;

public class Athlete
{
    public int Id { get; set; }

    public string Name { get; set; }
    public DateTime BirthDate { get; set; }

    public List<Skill> Skills { get; set; }
    public List<Championship> Championships { get; set; }
}
