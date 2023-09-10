using System.Runtime.CompilerServices;

namespace SpaceInvader;

public class ScoreManager
{
    public static int score;
    public static int highscore;

    public static void UpdateScore()
    {
        if (score > highscore)
        {
            highscore = score;
        }
    }
}