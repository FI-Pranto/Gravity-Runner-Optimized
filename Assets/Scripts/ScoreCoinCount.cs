using System;
using TMPro;
using UnityEngine;

public class ScoreCoinCount : MonoBehaviour
{
    // Start is called before the first frame update
    //Score System
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreForPanel;

    [SerializeField] private TextMeshProUGUI highscoreForPanel;
   // [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private PlayerFallDeath playerDeathScript;
    public int highScore=0;

    public int totalgamePlayed=0;

    public int highStar = 0;

    public int totalScore = 0;

    private int gameCount=1;

    public int totalCoinCount = 0;

    private int coinCount=0;

    [SerializeField] private TextMeshProUGUI coinText;

    AudioManager audioManager;


    private float myScore=0;
    private const float scoreInc = 10f;
    private int scoreIn;

    public bool onlyOne = true;


    void Awake()
    {
        // Find the AudioManager component using the tag "Audio"
        GameObject audioObject = GameObject.FindGameObjectWithTag("Audio");
        if (audioObject != null)
        {
            audioManager = audioObject.GetComponent<AudioManager>();
        }
    }

    void Start()
    {
        LoadPlayerData();
       
    }

    // Update is called once per frame
    void Update()
    {
        
         if (playerDeathScript.isDead && onlyOne)
           {
           if (scoreIn > highScore)
            {
                highScore = scoreIn;
            }
            if (coinCount > highStar)
            {
                highStar = coinCount;
            }
            totalScore += scoreIn;
          
            highscoreForPanel.text=highScore.ToString()+" m";
            scoreForPanel.text = scoreText.text;
            totalCoinCount += coinCount;
            totalgamePlayed += gameCount;
         

            onlyOne = false;
            SaveSystem.SavePlayer(this);
        

          }
         else if (playerDeathScript.isDead==false)
        {
            myScore += scoreInc * Time.deltaTime;
            scoreIn = Convert.ToInt32(myScore);
            scoreText.text = scoreIn.ToString() + " m";
        }
     
       
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount+=1;
            
            if (audioManager != null)
            {
                audioManager.PlaySFX(audioManager.collectSFX);
            }
            coinText.text = coinCount.ToString();
            other.gameObject.SetActive(false);
        }
      
    }

   
      
    
    public void LoadPlayerData()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            highScore = data.highDis;
            totalCoinCount = data.totalCoin;
            totalgamePlayed = data.totalPlayed;
            highStar = data.highStarCollected;
            totalScore = data.totaldisTravell;
           
           
        }
        else {

            highScore = 0;
            totalCoinCount = 0;
            totalgamePlayed = 0;
            highStar = 0;
            totalScore = 0;
         

        }
    }
    public void ReStartScore()
    {
        coinCount = 0;
        myScore = 0;
        LoadPlayerData();
        coinText.text = coinCount.ToString();
    }
}
