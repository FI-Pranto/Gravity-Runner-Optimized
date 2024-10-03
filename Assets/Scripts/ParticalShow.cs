using UnityEngine;

public class ParticalShow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ParticleSystem effect;


    [SerializeField] private Transform p1;//down
    [SerializeField] private Transform p2;//up

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && effect!=null)
        {
            if (rb.gravityScale > 0)
            {
                effect.transform.position = new Vector2(p1.position.x, p1.position.y);
            }

            else
            {
                effect.transform.position = new Vector2(p2.position.x, p2.position.y);
            }
                effect.Play();
       
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && effect != null)
        { 
                effect.Stop();
        }
    }
}
