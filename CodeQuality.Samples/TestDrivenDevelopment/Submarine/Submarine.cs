namespace CodeQuality.Samples.TestDrivenDevelopment.Submarine;

/// <summary>
///     The submarine has an ExecuteCommand, which can receive a command (string).
///     * "down X" increases your aim by X units.
///     * "up X" decreases your aim by X units.
///     * "forward X" does two things:
///     - It increases your horizontal position by X units
///     - It increases your depth by your aim multiplied by X
///     (Note: that since you're on a submarine, down and up do the opposite of what you might expect: "down" means aiming
///     in the positive direction.)
///     Here's an example
///     * forward 5 adds 5 to your horizontal position, a total of 5. Because your aim is 0, your depth does not change.
///     * down 5 adds 5 to your aim, resulting in a value of 5.
///     * forward 8 adds 8 to your horizontal position, a total of 13. Because your aim is 5, your depth increases by
///     8*5=40.
///     * up 3 decreases your aim by 3, resulting in a value of 2.
///     * down 8 adds 8 to your aim, resulting in a value of 10.
///     * forward 2 adds 2 to your horizontal position, a total of 15. Because your aim is 10, your depth increases by
///     2*10=20 to a total of 60.
///     After following these new instructions, you would have a horizontal position of 15 and a depth of 60.
///     Bonus: Load Input.txt and take your submarine to its course.
///     What result do you get if you multiply your final horizontal position by your final depth?
///     Source: https://adventofcode.com/2021/day/2
/// </summary>
public class Submarine
{
    public int Aim { get; private set; }
    public int HorizontalPosition { get; private set; }
    public int Depth { get; private set; }

    public void ExecuteCommand(string command)
    {
        var submarineCommand = Command.Parse(command);
        switch (submarineCommand.Type)
        {
            case CommandType.Forward:
                this.MoveForward(submarineCommand);
                break;
            case CommandType.Up:
                this.MoveUp(submarineCommand);
                break;
            case CommandType.Down:
                this.MoveDown(submarineCommand);
                break;
        }
    }

    private void MoveDown(Command submarineCommand) => this.Aim += submarineCommand.Value;

    private void MoveUp(Command submarineCommand) => this.Aim -= submarineCommand.Value;

    private void MoveForward(Command submarineCommand)
    {
        this.HorizontalPosition += submarineCommand.Value;
        this.Depth += this.Aim * submarineCommand.Value;
    }

    private record Command(CommandType Type, int Value)
    {
        public static Command Parse(string command)
        {
            var parameters = command.Split(' ');
            return new Command(Enum.Parse<CommandType>(parameters[0], true), int.Parse(parameters[1]));
        }
    }

    private enum CommandType
    {
        Forward,
        Up,
        Down,
    }
}