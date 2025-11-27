namespace CodeQuality.Samples.Legacy.GildedRose;

public class GildedRoseTest
{
    [Fact]
    public Task TestRunSimulation()
    {
        var result = Program.RunSimulation();
        return Verify(result);
    }
    
    [Fact]
    public Task TestRunSimulation_10()
    {
        var result = Program.RunSimulation(10);
        return Verify(result);
    }
    
    [Fact]
    public Task TestRunSimulation_30()
    {
        var result = Program.RunSimulation(30);
        return Verify(result);
    }
    
    [Fact]
    public Task TestRunSimulation_50()
    {
        var result = Program.RunSimulation(50);
        return Verify(result);
    }
}