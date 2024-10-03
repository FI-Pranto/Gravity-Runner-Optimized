using System.Collections;
using UnityEngine;

public class MyObjectDestroy : MonoBehaviour
{

 
    private Transform myRoot;
    private MyGenerator mg;
    
    private void Start()
    {
       mg = GameObject.FindWithTag("GM").GetComponent<MyGenerator>();

    }

    void OnBecameInvisible()
    {
        
        if (transform.root != null)
        {
            myRoot = transform.root;


            if (myRoot.gameObject.name.Equals("Start_Lv") )
            {
               
                    /*myRoot.gameObject.SetActive(false);*/
            }
            else
            {
                mg.PoolPush(myRoot);
            }
        }
        
       // root.SetActive(false);
    }
 
  

}
