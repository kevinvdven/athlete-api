namespace AthleteApi.Models;

public class Championship
{
    public int Id { get; set; }

    public string Name { get; set; }
    public int Year { get; set; }

    public List<Athlete> Athletes { get; set; }
}
