namespace Efephant.Tests;

[TestClass]
public class PostParkShould : Test
{
    [TestMethod]
    public async Task SavePortAventuraPark()
    {
        await this.Client.PostPark(new ("Port Aventura"));
        var saved = await this.Client.GetParks();

        var park = saved.Single();

        park.Name.Should().Be("Port Aventura");
    }

    [TestMethod]
    public async Task SaveFerrariWorldPark()
    {
        await this.Client.PostPark(new ("Ferrari World"));
        var saved = await this.Client.GetParks();

        var park = saved.Single();

        park.Name.Should().Be("Ferrari World");
    }
}
