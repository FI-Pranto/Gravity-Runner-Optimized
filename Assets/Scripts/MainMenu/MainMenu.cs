using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject helpPanel;

    [SerializeField] private GameObject helpPanel2;

    [SerializeField] private GameObject progressPanel;

    [SerializeField] private GameObject settingsPanel;

    [SerializeField] private GameObject creditsPanel;

    [SerializeField] private GameObject exitPanel;

    //butoon array
    [SerializeField] private Button[] allButtons;

    public Animator transaction;

    public float transactionTime = 1f;

    //scroll text
    private float scrollSpeed = 100f;
    private float beginTextPos = -170f;
    private float endTextPos = 498f;

    [SerializeField] private RectTransform thisobjectRectTran;
    [SerializeField] private TextMeshProUGUI text;

    private Coroutine scrollCoroutine;

    public void Play()
    {
        //StartCoroutine(LoadMyScene());
        SceneManager.LoadSceneAsync("Level_1");
    } 

   /* IEnumerator LoadMyScene()
    {
        transaction.SetTrigger("Start");
        yield return new WaitForSeconds(transactionTime);
        SceneManager.LoadScene("Level_1");
    }*/
    public void Quit()
    {
        Application.Quit();
    }
    public void Cancel()
    {
        exitPanel.SetActive(false);
    }
    public void Help()
    {
        helpPanel.SetActive(true);
        SetButtonsInteractable(false);
    }

    public void Progress()
    {
        progressPanel.SetActive(true);
        SetButtonsInteractable(false);

    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
        SetButtonsInteractable(false);

    }

    public void Credits()
    {
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(true);
       

        scrollCoroutine = StartCoroutine(AutoScrollText());
    }


    public void ExitHelp()
    {
        helpPanel.SetActive(false);
        SetButtonsInteractable(true);
    }
    public void ExitHelp2()
    {
        helpPanel2.SetActive(false);
        SetButtonsInteractable(true);
    }
    public void ExitCredits()
    {
        if (scrollCoroutine != null)
        {
            StopCoroutine(scrollCoroutine);
            scrollCoroutine = null;
            thisobjectRectTran.localPosition = new Vector3(thisobjectRectTran.localPosition.x, beginTextPos, thisobjectRectTran.localPosition.z);
        }
         creditsPanel.SetActive(false);
        SetButtonsInteractable(true);
    }
    public void ExitSettings()
    {
        settingsPanel.SetActive(false);
        SetButtonsInteractable(true);
    }
    public void ExitProgress()
    {
        progressPanel.SetActive(false);
        SetButtonsInteractable(true);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitPanel.SetActive(true);
        }
    }

    public void Next()
    {

        helpPanel.SetActive(false);
        helpPanel2.SetActive(true);

    }

    public void BackButton()
    {
        helpPanel2.SetActive(false);
        helpPanel.SetActive(true);
       
    }

    IEnumerator AutoScrollText()
    {
        while (true)
        {
            thisobjectRectTran.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
            if (thisobjectRectTran.localPosition.y > endTextPos)
            {
                thisobjectRectTran.localPosition = new Vector3(thisobjectRectTran.localPosition.x, beginTextPos, thisobjectRectTran.localPosition.z);

            }
            yield return null;
        }



    }
    private void SetButtonsInteractable(bool activeButton)
    {
        foreach (Button button in allButtons)
        {
            button.interactable = activeButton;
        }
    }

}
