namespace CodeQuality.Samples.CleanCode.Yahtzee;

public class YahtzeeGameTest
{
    [Fact]
    public void Chance_scores_sum_of_all_dice()
    {
        var expected = 15;
        var actual = YahtzeeGame.Chance(2, 3, 4, 5, 1);
        Assert.Equal(expected, actual);
        Assert.Equal(16, YahtzeeGame.Chance(3, 3, 4, 5, 1));
    }

    [Fact]
    public void Fact_1s()
    {
        Assert.True(new YahtzeeGame(1, 2, 3, 4, 5).Ones() == 1);
        Assert.Equal(2, new YahtzeeGame(1, 2, 1, 4, 5).Ones());
        Assert.Equal(0, new YahtzeeGame(6, 2, 2, 4, 5).Ones());
        Assert.Equal(4, new YahtzeeGame(1, 2, 1, 1, 1).Ones());
    }

    [Fact]
    public void Fact_2s()
    {
        Assert.Equal(4, YahtzeeGame.Twos(1, 2, 3, 2, 6));
        Assert.Equal(10, YahtzeeGame.Twos(2, 2, 2, 2, 2));
    }

    [Fact]
    public void Fact_threes()
    {
        Assert.Equal(6, YahtzeeGame.Threes(1, 2, 3, 2, 3));
        Assert.Equal(12, YahtzeeGame.Threes(2, 3, 3, 3, 3));
    }

    [Fact]
    public void fives()
    {
        Assert.Equal(10, new YahtzeeGame(4, 4, 4, 5, 5).Fives());
        Assert.Equal(15, new YahtzeeGame(4, 4, 5, 5, 5).Fives());
        Assert.Equal(20, new YahtzeeGame(4, 5, 5, 5, 5).Fives());
    }

    [Fact]
    public void four_of_a_knd()
    {
        Assert.Equal(12, YahtzeeGame.FourOfAKind(3, 3, 3, 3, 5));
        Assert.Equal(20, YahtzeeGame.FourOfAKind(5, 5, 5, 4, 5));
        Assert.Equal(12, YahtzeeGame.FourOfAKind(3, 3, 3, 3, 3));
    }

    [Fact]
    public void fours_Fact()
    {
        Assert.Equal(12, new YahtzeeGame(4, 4, 4, 5, 5).Fours());
        Assert.Equal(8, new YahtzeeGame(4, 4, 5, 5, 5).Fours());
        Assert.Equal(4, new YahtzeeGame(4, 5, 5, 5, 5).Fours());
    }

    [Fact]
    public void fullHouse()
    {
        Assert.Equal(18, YahtzeeGame.FullHouse(6, 2, 2, 2, 6));
        Assert.Equal(0, YahtzeeGame.FullHouse(2, 3, 4, 5, 6));
    }

    [Fact]
    public void largeStraight()
    {
        Assert.Equal(20, YahtzeeGame.LargeStraight(6, 2, 3, 4, 5));
        Assert.Equal(20, YahtzeeGame.LargeStraight(2, 3, 4, 5, 6));
        Assert.Equal(0, YahtzeeGame.LargeStraight(1, 2, 2, 4, 5));
    }

    [Fact]
    public void one_pair()
    {
        Assert.Equal(6, new YahtzeeGame().ScorePair(3, 4, 3, 5, 6));
        Assert.Equal(10, new YahtzeeGame().ScorePair(5, 3, 3, 3, 5));
        Assert.Equal(12, new YahtzeeGame().ScorePair(5, 3, 6, 6, 5));
    }

    [Fact]
    public void sixes_Fact()
    {
        Assert.Equal(0, new YahtzeeGame(4, 4, 4, 5, 5).sixes());
        Assert.Equal(6, new YahtzeeGame(4, 4, 6, 5, 5).sixes());
        Assert.Equal(18, new YahtzeeGame(6, 5, 6, 6, 5).sixes());
    }

    [Fact]
    public void smallStraight()
    {
        Assert.Equal(15, YahtzeeGame.SmallStraight(1, 2, 3, 4, 5));
        Assert.Equal(15, YahtzeeGame.SmallStraight(2, 3, 4, 5, 1));
        Assert.Equal(0, YahtzeeGame.SmallStraight(1, 2, 2, 4, 5));
    }

    [Fact]
    public void three_of_a_kind()
    {
        Assert.Equal(9, new YahtzeeGame(3, 3, 3, 4, 5).ThreeOfAKind());
        Assert.Equal(15,  new YahtzeeGame(5, 3, 5, 4, 5).ThreeOfAKind());
        Assert.Equal(9,  new YahtzeeGame(3, 3, 3, 3, 5).ThreeOfAKind());
    }

    [Fact]
    public void two_Pair()
    {
        Assert.Equal(16, YahtzeeGame.TwoPair(3, 3, 5, 4, 5));
        Assert.Equal(16, YahtzeeGame.TwoPair(3, 3, 5, 5, 5));
    }

    [Fact]
    public void Yatzy_scores_50()
    {
        var expected = 50;
        var actual = YahtzeeGame.Yahtzee(4, 4, 4, 4, 4);
        Assert.Equal(expected, actual);
        Assert.Equal(50, YahtzeeGame.Yahtzee(6, 6, 6, 6, 6));
        Assert.Equal(0, YahtzeeGame.Yahtzee(6, 6, 6, 6, 3));
    }
}