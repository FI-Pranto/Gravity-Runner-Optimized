using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private MyGenerator mg;//ok
    [SerializeField] private PlayerFallDeath pfd;//ok
   /* [SerializeField] private PauseMenu pm;*/
    [SerializeField] private ScoreCoinCount scc;
    [SerializeField] private Player_MoveMent pmm;

    //Button and panels
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject gameOverPanel;

    public GameObject stLv;

    public void RestartMyGame()
    {
        RestartGameCo();

    }
    private void RestartGameCo()
    {
        pmm.ReStartPlayer();

        mg.RestartScript();
       
        stLv.SetActive(true);//must give to set the start level active means there a function that set active false the gameobject 
        //all issue is with MyGenerator because the Dequeue is empty 
        
        scc.ReStartScore();
        pfd.MakeVisible();

        if (gameOverPanel.activeSelf)
        {
            gameOverPanel.SetActive(false);
            pauseButton.SetActive(true);
        }
        else if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            pauseButton.SetActive(true);
        }
        Time.timeScale = 1.0f;
        //isDead,on_off,onlyOne
        //gameoverpanel,pauseButton,PausePanel
        //Time.timeScale=1f;
        pfd.isDead = false;
        pmm.on_off = true;
        scc.onlyOne = true;
    }
}
