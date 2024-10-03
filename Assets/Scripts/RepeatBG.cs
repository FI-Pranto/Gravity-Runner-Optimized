using UnityEngine;

public class RepeatBG : MonoBehaviour
{

    [SerializeField] private float bgSpeed;
    [SerializeField] private float endX;
    [SerializeField] private float startX;

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * bgSpeed * Time.fixedDeltaTime);
        if (transform.position.x <= endX)
        {
            Vector2 pos = new Vector2(startX, transform.position.y);
            transform.position = pos;
        }
        
    }
}
