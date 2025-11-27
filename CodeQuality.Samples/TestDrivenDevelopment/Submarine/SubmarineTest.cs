using FluentAssertions;
using FluentAssertions.Equivalency;

namespace CodeQuality.Samples.TestDrivenDevelopment.Submarine;

public class SubmarineTest
{
    private readonly Submarine submarine = new Submarine();

    [Theory]
    [InlineData(2, 10)]
    [InlineData(3, 15)]
    public void Forward_ShouldIncreaseDepth(int aim, int depth)
    {
        this.submarine.ExecuteCommand($"down {aim}");
        this.submarine.ExecuteCommand("forward 5");
        this.submarine.Depth.Should().Be(depth);
    }
    
    [Fact]
    public void Forward_ShouldIncreaseHorizontalPosition()
    {
        this.submarine.ExecuteCommand("forward 5");
        this.submarine.ExecuteCommand("forward 5");
        this.submarine.HorizontalPosition.Should().Be(10);
    }
    
    [Fact]
    public void Up_ShouldDecreaseAim()
    {
        this.submarine.ExecuteCommand("up 2");
        this.submarine.ExecuteCommand("up 2");
        this.submarine.Aim.Should().Be(-4);
    }
    
     
    [Fact]
    public void Down_ShouldIncreaseAim()
    {
        this.submarine.ExecuteCommand("down 2");
        this.submarine.ExecuteCommand("down 2");
        this.submarine.Aim.Should().Be(4);
    }

    [Fact]
    public void FullScenario()
    {
        this.submarine.ExecuteCommand("forward 5");
        this.submarine.ExecuteCommand("down 5");
        this.submarine.ExecuteCommand("forward 8");
        this.submarine.ExecuteCommand("up 3");
        this.submarine.ExecuteCommand("down 8");
        this.submarine.ExecuteCommand("forward 2");
        this.submarine.HorizontalPosition.Should().Be(15);
        this.submarine.Depth.Should().Be(60);
    }

    [Fact]
    public void FullScenario_WithInput()
    {
        var commands = 
            File.ReadAllLines("TestDrivenDevelopment/Submarine/Input.txt");
        commands.ToList().ForEach(command => this.submarine.ExecuteCommand(command));
        var result = this.submarine.HorizontalPosition * this.submarine.Depth;
    }
}