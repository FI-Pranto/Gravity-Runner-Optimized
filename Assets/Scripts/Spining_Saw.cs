using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spining_Saw : MonoBehaviour
{
    // Start is called before the first frame update
    private float spinSpeed = 350f;

    void Update()
    {
        transform.Rotate(0, 0, spinSpeed * Time.unscaledDeltaTime);
    }
}
//two more solution await at chat gpt
