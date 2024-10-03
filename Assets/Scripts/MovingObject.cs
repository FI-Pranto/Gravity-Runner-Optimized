using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private float platformSpeed=5f;

    void Update()
    {
   
            transform.Translate(Vector2.left * platformSpeed * Time.deltaTime);
    
    }
  

}
