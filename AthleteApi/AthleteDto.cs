namespace AthleteApi;

public class AthleteDto
{
    public int Id { get; set; }

    public string Name { get; set; }
    public DateTime BirthDate { get; set; }

    public IEnumerable<string> Championships { get; set; }
    public IEnumerable<string> Skills { get; set; }
}
