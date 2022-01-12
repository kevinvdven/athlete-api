using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Linq;

namespace AthleteApi.Tests;

[TestClass]
public class AthleteApiTests
{
    [TestMethod]
    public async Task TestGetAllAthletes()
    {
        var athletes = await GetAsync("api/v1/athletes");

        Assert.IsNotNull(athletes);
        Assert.AreEqual(3, athletes.Count());
    }

    [TestMethod]
    public async Task TestNameFilter()
    {
        var athletes = await GetAsync("api/v1/athletes?name=Anna");

        Assert.IsNotNull(athletes);
        Assert.AreEqual(1, athletes.Count());
        Assert.IsTrue(athletes.First().Name.StartsWith("Anna"));
    }

    [TestMethod]
    public async Task TestSkillFilter()
    {
        var athletes = await GetAsync("api/v1/athletes?skill=cycling");

        Assert.IsNotNull(athletes);
        Assert.AreEqual(1, athletes.Count());
        Assert.IsTrue(athletes.First().Id == 3);
    }

    [TestMethod]
    public async Task TestSkillFilterWithSupersetSkill()
    {
        var athletes = await GetAsync("api/v1/athletes?skill=winter sports");

        Assert.IsNotNull(athletes);
        Assert.AreEqual(2, athletes.Count());
        Assert.IsTrue(!athletes.Any(a => a.Id == 3));
    }

    [TestMethod]
    public async Task TestMinAgeFilter()
    {
        var athletes = await GetAsync("api/v1/athletes?minAge=31");

        Assert.IsNotNull(athletes);
        Assert.AreEqual(1, athletes.Count());
        Assert.IsTrue(athletes.First().Id == 3);
    }

    [TestMethod]
    public async Task TestMaxAgeFilter()
    {
        var athletes = await GetAsync("api/v1/athletes?maxAge=25");

        Assert.IsNotNull(athletes);
        Assert.AreEqual(1, athletes.Count());
        Assert.IsTrue(athletes.First().Id == 2);
    }

    [TestMethod]
    public async Task TestMinYearsOfExperience()
    {
        var athletes = await GetAsync("api/v1/athletes?minYearsOfExperience=11");

        Assert.IsNotNull(athletes);
        Assert.AreEqual(1, athletes.Count());
        Assert.IsTrue(athletes.First().Id == 1);
    }

    [TestMethod]
    public async Task TestMultipleFilters()
    {
        var athletes = await GetAsync("api/v1/athletes?minAge=40&name=anna");

        Assert.IsNotNull(athletes);
        Assert.AreEqual(0, athletes.Count());
    }

    private async Task<IEnumerable<AthleteDto>> GetAsync(string url)
    {
        IEnumerable<AthleteDto> athletes;

        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync($"http://localhost:5274/{url}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            athletes = JsonConvert.DeserializeObject<IEnumerable<AthleteDto>>(json) ?? new List<AthleteDto>();
        }

        return athletes;
    }
}
