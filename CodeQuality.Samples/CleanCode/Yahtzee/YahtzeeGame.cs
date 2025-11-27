using System.Runtime.CompilerServices;
using FluentAssertions.Equivalency.Steps;

namespace CodeQuality.Samples.CleanCode.Yahtzee;

/// <summary>
///     Objectif N°1: Refactorer le code selon les principes/pratiques de Clean Code
///     Objectif N°2: Exposer une seule méthode Evaluate(...) qui retournera la liste des figures possibles, avec leur
///     score associés.
/// </summary>
public class YahtzeeGame
{
    public YahtzeeGame()
    {
    }

    public YahtzeeGame(int d1, int d2, int d3, int d4, int _5)
    {
        dice = new int[5];
        dice[0] = d1;
        dice[1] = d2;
        dice[2] = d3;
        dice[3] = d4;
        dice[4] = _5;
    }

    public static int Chance(int d1, int d2, int d3, int d4, int d5) =>
        d1 + d2 + d3 + d4 + d5;

    public int Fives() => this.AggregateDiceValue(5);

    public static int FourOfAKind(int _1, int _2, int d3, int d4, int d5) => 
        new Tallies(_1, _2, d3, d4, d5).CountSameDice(4);

    public int ThreeOfAKind() => new Tallies(this.dice).CountSameDice(3);

    public int Fours() => this.AggregateDiceValue(4);

    public static int FullHouse(int d1, int d2, int d3, int d4, int d5) => 
        new Tallies(d1, d2, d3, d4, d5).CountFullHouse();

    public static int LargeStraight(int d1, int d2, int d3, int d4, int d5)
    {
        return new Tallies(d1, d2, d3, d4, d5).LargeStraight();
    }

    public int Ones() => this.AggregateDiceValue(1);

    public int ScorePair(int d1, int d2, int d3, int d4, int d5)
    {
        return new Tallies(d1, d2, d3, d4, d5).Pair();
    }

    public int sixes()
    {
        var sum = 0;
        for (var at = 0; at < dice.Length; at++)
            if (dice[at] == 6)
                sum = sum + 6;
        return sum;
    }

    public static int SmallStraight(int d1, int d2, int d3, int d4, int d5)
    {
        int[] tallies;
        tallies = new int[6];
        tallies[d1 - 1] += 1;
        tallies[d2 - 1] += 1;
        tallies[d3 - 1] += 1;
        tallies[d4 - 1] += 1;
        tallies[d5 - 1] += 1;
        if (tallies[0] == 1 &&
            tallies[1] == 1 &&
            tallies[2] == 1 &&
            tallies[3] == 1 &&
            tallies[4] == 1)
            return 15;
        return 0;
    }



    public static int Threes(int d1, int d2, int d3, int d4, int d5)
    {
        int s;
        s = 0;
        if (d1 == 3) s += 3;
        if (d2 == 3) s += 3;
        if (d3 == 3) s += 3;
        if (d4 == 3) s += 3;
        if (d5 == 3) s += 3;
        return s;
    }

    public static int TwoPair(int d1, int d2, int d3, int d4, int d5)
    {
        var counts = new int[6];
        counts[d1 - 1]++;
        counts[d2 - 1]++;
        counts[d3 - 1]++;
        counts[d4 - 1]++;
        counts[d5 - 1]++;
        var n = 0;
        var score = 0;
        for (var i = 0; i < 6; i += 1)
            if (counts[6 - i - 1] >= 2)
            {
                n++;
                score += 6 - i;
            }

        if (n == 2)
            return score * 2;
        return 0;
    }

    public static int Twos(int d1, int d2, int d3, int d4, int d5)
    {
        var sum = 0;
        if (d1 == 2) sum += 2;
        if (d2 == 2) sum += 2;
        if (d3 == 2) sum += 2;
        if (d4 == 2) sum += 2;
        if (d5 == 2) sum += 2;
        return sum;
    }

    public static int Yahtzee(params int[] dice)
    {
        var counts = new int[6];
        foreach (var die in dice)
            counts[die - 1]++;
        for (var i = 0; i != 6; i++)
            if (counts[i] == 5)
                return 50;
        return 0;
    }

    private int AggregateDiceValue(int diceValue)
    {
        return this.dice.Where(d => d == diceValue).Sum();
    }

    protected int[] dice;
}

public class Tallies
{
    private record DiceIndex(int Value, int Count);
    private readonly int[] array;
    private readonly List<DiceIndex> dices;

    public Tallies(params int[] dice)
    {
        this.array = new int[6];
        foreach (var die in dice)
        {
            this.array[die - 1]++;
        }
    }
    
    public  int CountSameDice( int target)
    {
        for (var i = 0; i < 6; i++)
            if (this.array[i] >= target)
            {
                return (i + 1) * target;
            }

        return 0;
    }

    public int CountPair()
    {
        for (var i = 0; i < 6; i++)
            if (this.array[i] == 2)
            {
                return (i + 1) * 2;
            }

        return 0;

    }

    public int CountFullHouse()
    {
        var a =this.CountSameDice(3);
        var b = this.CountPair();
        if (a > 0 && b > 0)
        {
            return a + b;
        }

        return 0;
    }

    public int LargeStraight()
    {
        if (this.array[1] == 1 &&
            this.array[2] == 1 &&
            this.array[3] == 1 &&
            this.array[4] == 1
            && this.array[5] == 1)
            return 20;
        return 0;
    }

    public int Pair()
    {
        for (int at = 0; at != 6; at++)
            if (this.array[6 - at - 1] >= 2)
                return (6 - at) * 2;
        return 0;
    }
}