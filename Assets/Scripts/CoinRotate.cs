using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    private float rotationSpeed = 300f;
    //must be big value or else it will not be seen 

    void Update()
    {
        transform.Rotate(Vector2.up * rotationSpeed*Time.unscaledDeltaTime);

    }

}

