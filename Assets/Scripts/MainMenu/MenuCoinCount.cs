using TMPro;
using UnityEngine;

public class MenuCoinCount : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI starMenuPanel;

    [SerializeField] private TextMeshProUGUI maxStarMenuPanelText;

    [SerializeField] private TextMeshProUGUI bestScoreMenuPanelText;

    [SerializeField] private TextMeshProUGUI gameCountMenuPanelText;

    [SerializeField] private TextMeshProUGUI myTotalScoreMenuPanelText;

    [SerializeField] private TextMeshProUGUI myJumpCountMenuPanelText;

    [SerializeField] private GameObject helpPanel;

    private int starCount=0;
    private int bestScore = 0;
    private int gameCount = 0;
    private int maxStar = 0;
    private int myTotalScore = 0;
    private int myJumpCount = 0;
    void Start()
    {
        PlayerData mydata=SaveSystem.LoadPlayer();
        if (mydata != null)
        {
            bestScore = mydata.highDis;
            starCount = mydata.totalCoin;
            gameCount= mydata.totalPlayed;
            maxStar = mydata.highStarCollected;
            myTotalScore = mydata.totaldisTravell;
                 
        }
        else
        {
            bestScore = 0;
            starCount = 0;
            gameCount = 0;
            maxStar = 0;
            myTotalScore = 0;
            

        }

        if (PlayerPrefs.HasKey("JumpCount"))
        {
            myJumpCount = PlayerPrefs.GetInt("JumpCount");
        }
        else
        {
            myJumpCount = 0;
        }
        starMenuPanel.text = starCount.ToString();
        maxStarMenuPanelText.text = maxStar.ToString();
        bestScoreMenuPanelText.text = bestScore.ToString();
        gameCountMenuPanelText.text = gameCount.ToString();
        myTotalScoreMenuPanelText.text = myTotalScore.ToString();
        myJumpCountMenuPanelText.text = myJumpCount.ToString();

        if (gameCount == 0)
        {
            helpPanel.SetActive(true);
        }

    }

   
}
