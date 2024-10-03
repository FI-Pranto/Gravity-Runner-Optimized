

[System.Serializable]
public class PlayerData 
{
    public int highDis;
    public int totalCoin;
    public int totalPlayed;
    public int highStarCollected;
    public int totaldisTravell;
   
    public PlayerData(ScoreCoinCount scoreCoinCount)
    {
        highDis = scoreCoinCount.highScore;
        totalCoin = scoreCoinCount.totalCoinCount;
        totalPlayed= scoreCoinCount.totalgamePlayed;
        highStarCollected = scoreCoinCount.highStar;
        totaldisTravell = scoreCoinCount.totalScore;
   
    }
   
}
