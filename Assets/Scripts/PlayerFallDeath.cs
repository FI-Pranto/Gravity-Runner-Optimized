using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerFallDeath : MonoBehaviour
{
  

    [SerializeField] private ParticleSystem deathEffect;

    [SerializeField] private ParticleSystem moveEffect;

    [SerializeField] private SpriteRenderer sr;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseButton;//this is to disable the pause button so that user can not play with it and lead game to error.
  

    AudioManager audioManager;

    public bool isDead = false;


    void Awake()
    {
        // Find the AudioManager component using the tag "Audio"
        GameObject audioObject = GameObject.FindGameObjectWithTag("Audio");
        if (audioObject != null)
        {
            audioManager = audioObject.GetComponent<AudioManager>();
        }
    }

    private void OnBecameInvisible()
    {
        rb.gravityScale = 12.5f;
        
        GameOver();
    }

    void GameOver()
    {
        if (isDead) return;
        isDead = true;
       
        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.deathSFX);
        }
        if (deathEffect != null)
        {
            deathEffect.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            deathEffect.Play();
        }
        if (moveEffect != null)
        {
            moveEffect.gameObject.SetActive(false);
        }
      
        MakeInvisible();
        Invoke("MyFunction", 0.2f);
        
       
       
    }
    void MyFunction()
    {
        gameOverMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }
    void MakeInvisible()
    {
        Color color = sr.color;
        color.a = 0f; // Set alpha to 0 to make it invisible
        sr.color = color;
    }
    public void MakeVisible()
    {
        Color color = sr.color;
        color.a = 1f; // Set alpha to 1 to make it visible
        sr.color = color;
        if (moveEffect != null)
        {
            moveEffect.gameObject.SetActive(true);
        }

    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Traps"))
        {
            GameOver();
        }
    }


}
