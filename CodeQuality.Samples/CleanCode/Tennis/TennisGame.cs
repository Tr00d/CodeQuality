namespace CodeQuality.Samples.CleanCode.Tennis;

public class TennisGame
{
    public string GetScore(TennisPlayer player1, TennisPlayer player2)
    {
        if (player1.HasSameScoreThan(player2))
        {
            return this.FormatScoreForDraw(player1.GetScore());
        }

        if (player1.HasReachedFortyScore() || player2.HasReachedFortyScore())
        {
            return player1.HasHigherScoreThan(player2)
                ? this.FormatScore(player1, player2)
                : this.FormatScore(player2, player1);
        }

        return $"{player1.FormatScore()}-{player2.FormatScore()}";
    }

    private string FormatScore(TennisPlayer winner, TennisPlayer loser) =>
        winner.HasAdvantageOver(loser)
            ? "Advantage " + winner.GetName()
            : "Win for " + winner.GetName();

    private string FormatScoreForDraw(int score) => score switch
    {
        0 => "Love-All",
        1 => "Fifteen-All",
        2 => "Thirty-All",
        _ => "Deuce",
    };
}

public class TennisPlayer(string name)
{
    private int score;

    public string FormatScore() => this.score switch
    {
        0 => "Love",
        1 => "Fifteen",
        2 => "Thirty",
        _ => "Forty",
    };

    public string GetName() => name;

    public int GetScore() => this.score;
    public bool HasAdvantageOver(TennisPlayer otherPlayer) => this.score == otherPlayer.GetScore() + 1;

    public bool HasHigherScoreThan(TennisPlayer otherPlayer) => this.score > otherPlayer.GetScore();

    public bool HasReachedFortyScore() => this.score >= 4;

    public bool HasSameScoreThan(TennisPlayer otherPlayer) => this.score == otherPlayer.GetScore();

    public void WinPoint() => this.score++;


}