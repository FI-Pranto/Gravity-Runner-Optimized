using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private TextMeshProUGUI countdownText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf == false && gameOverPanel.activeSelf==false)//if pauseMenu is off
            {
                OnPause();
            }
        }
    }
    public void OnPause()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void OnResume()
    {
        StartCoroutine(CountdownCoroutine());
    }
  /*  public void OnRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("Level_1");

    }*/
    public void OnMenu()
    {

      
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("MainMenu");


    }

    IEnumerator CountdownCoroutine()
    {
         pauseMenu.SetActive(false);
        countdownText.gameObject.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1);//it works if the timescale is zero
        }

        countdownText.gameObject.SetActive(false);

        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }



}
