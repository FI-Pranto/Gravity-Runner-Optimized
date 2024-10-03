
using System.Collections;

using UnityEngine;
using UnityEngine.EventSystems;


public class Player_MoveMent : MonoBehaviour
{

    private float jumpForce = 8.1f;

    [SerializeField] private Rigidbody2D rb;


    private float normalGravityScale = 5f; // Increase gravity scale for faster fall
    private float jumpGravityScale = 1.5f; // Gravity scale during jump

    // For gravity switch
     float gravityMultiplier = 1.5f; // Multiplier for increased gravity during switch
     float revertDelay = 0.2f; // Delay before reverting gravity scale during switch

    //groundcheck variables:-
    public LayerMask groundLayer; // Layer to define what counts as ground
    [SerializeField] private BoxCollider2D boxCollider2D;
    public float boxCastDistance = 1f; // Distance to cast the box

    private int jumpCount = 0;

    private int totalJump = 0;

    public bool on_off = true;

    [SerializeField] private GameObject gameOverPanel;

    Vector3 playerPos;

    [SerializeField] private PlayerFallDeath playerDeathScript;


    void Start()
    {

        playerPos=transform.position;
        
        rb.gravityScale = normalGravityScale; 

        if (PlayerPrefs.HasKey("JumpCount"))
        {
            totalJump = PlayerPrefs.GetInt("JumpCount");
        }



    }

    void Update()
    {
        if (playerDeathScript.isDead) return;


        if (gameOverPanel.activeSelf && on_off)
        {
            totalJump += jumpCount;

            PlayerPrefs.SetInt("JumpCount", totalJump);
            on_off = false;
        }



        //Uncomment this when building game
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
               // Debug.Log("UI");

            }
            else if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x > Screen.width / 2)
                {
                    Jumping();
                }
                else if (touch.position.x < Screen.width / 2)
                {
                    SwitchGravity();
                }

            }

        }


        //for development test only 
        /*  if (Input.GetMouseButtonDown(0))
          {
              if (Input.mousePosition.x > Screen.width / 2)
              {
                  Jumping();
              }
              else if (Input.mousePosition.x < Screen.width / 2)
              {
                  SwitchGravity();
              }
          }*/
    }

    public void SwitchGravity()
    {
        // Toggle gravity direction by flipping the gravityScale
        rb.gravityScale = -rb.gravityScale;

        // Start coroutine to temporarily increase gravity and then revert it
        StartCoroutine(IncreaseAndRevertGravity());
    }

    private IEnumerator IncreaseAndRevertGravity()
    {
        // Temporarily increase gravity scale
        float temporaryGravityScale = rb.gravityScale * gravityMultiplier;
        rb.gravityScale = temporaryGravityScale;

        // Wait for the specified delay
        yield return new WaitForSeconds(revertDelay);

        // Revert gravity scale back to normal
        rb.gravityScale = rb.gravityScale > 0 ? normalGravityScale : -normalGravityScale;
    }

    public void Jumping()
    {

        if (IsGrounded())
        {


            if (rb.gravityScale > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                rb.gravityScale = jumpGravityScale;
                StartCoroutine(ResetGravityScale());
                //  Debug.Log("Positive jumping");
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
                rb.gravityScale = -jumpGravityScale;
                StartCoroutine(ResetGravityScale());
                //Debug.Log("Negative jumping");
            }
            jumpCount++;

        }


    }

    private IEnumerator ResetGravityScale()
    {
        // Wait for a short duration before resetting the gravity scale
        yield return new WaitForSeconds(0.2f);
        rb.gravityScale = rb.gravityScale > 0 ? normalGravityScale : -normalGravityScale;
    }
    private bool IsGrounded()
    {
        RaycastHit2D hit;
        if (rb.gravityScale > 0)
        {
            hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, boxCastDistance, groundLayer);
        }
        else
        {
            hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.up, boxCastDistance, groundLayer);
        }

        // Return true if the box cast hits something in the ground layer
        return hit.collider != null;
    }
    public void ReStartPlayer()
    {

        transform.position = playerPos;
        rb.gravityScale = normalGravityScale;
       // Debug.Log()
        jumpCount = 0;

        if (PlayerPrefs.HasKey("JumpCount"))
        {
            totalJump = PlayerPrefs.GetInt("JumpCount");
        }

    }

}
