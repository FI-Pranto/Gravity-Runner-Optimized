using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioSource menuMusic;
    [SerializeField] private Toggle checkBox;

    // Start is called before the first frame update
    private int onOFF = 1;
    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();

        }
        else
        {
            SaveMusicVolume();
            SaveSFXVolume();
        }
        checkBox.onValueChanged.AddListener(OnToggleValueChanged);
    }

    public void SaveMusicVolume()
    {
        float music_volume = musicSlider.value;
        PlayerPrefs.SetFloat("musicVolume", music_volume);
        menuMusic.volume = music_volume;


    }
    public void SaveSFXVolume()
    {
        float sfx_volume = sfxSlider.value;
        PlayerPrefs.SetFloat("sfxVolume", sfx_volume);


    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        menuMusic.volume = musicSlider.value;


        //Mute load
        if (PlayerPrefs.HasKey("ON/OFF"))
        {
            onOFF = PlayerPrefs.GetInt("ON/OFF");
            if (onOFF == 1)
            {
                menuMusic.mute = false;
                checkBox.isOn = true;
            }
            else
            {
                menuMusic.mute = true;
                checkBox.isOn = false;
            }
        }

    }

    void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            menuMusic.mute = false;
            onOFF = 1;
        }
        else
        {
            menuMusic.mute = true;
            onOFF = 0;

        }
        PlayerPrefs.SetInt("ON/OFF", onOFF);
    }

}
