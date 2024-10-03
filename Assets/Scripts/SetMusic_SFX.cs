using UnityEngine;
using UnityEngine.Audio;

public class SetMusic_SFX : MonoBehaviour
{

    [SerializeField] private AudioMixer myMixer;
    void Start()
    {
        SetVolume();
    }
    private void SetVolume()
    {
        float music_Volume = PlayerPrefs.GetFloat("musicVolume");
        float sfx_Volume = PlayerPrefs.GetFloat("sfxVolume");
        myMixer.SetFloat("music", Mathf.Log10(music_Volume) * 20);
        myMixer.SetFloat("sfx", Mathf.Log10(sfx_Volume) * 20);
    }


}
