using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    [SerializeField] AudioSource sfxSource;

    public AudioClip background;

    public AudioClip collectSFX;

    public AudioClip deathSFX;

    private int levelmute = 0;

    [SerializeField] private Sprite offImage;
    [SerializeField] private Sprite onImage;
    [SerializeField] private Button muteButton;



    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        if (PlayerPrefs.HasKey("Mute"))
        {
            levelmute = PlayerPrefs.GetInt("Mute");
            if (levelmute == 1)
            {
                musicSource.mute = true;
                muteButton.image.sprite = offImage;
            }
            else
            {
                musicSource.mute = false;
                muteButton.image.sprite = onImage;
            }
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void Pause_Mute()
    {
        if (musicSource.mute == false)
        {
            musicSource.mute = true;
            levelmute = 1;
            muteButton.image.sprite = offImage;

        }
        else
        {
            musicSource.mute = false;
            levelmute= 0;
            muteButton.image.sprite = onImage;
        }
        PlayerPrefs.SetInt("Mute", levelmute);
    }
}
