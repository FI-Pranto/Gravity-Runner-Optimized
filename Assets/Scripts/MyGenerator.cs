
using System.Collections.Generic;

using UnityEngine;

public class MyGenerator : MonoBehaviour
{

    [SerializeField] private Transform player;

    [SerializeField] private Transform startLv;
    public List<Transform> lvs;
    List<Transform> objectPool=new List<Transform>(6); 
    Queue<Transform> activeInTheScene = new Queue<Transform>();
    private const float Boundary = 19.43f;//perfact
    private Transform activeLevel;

    [SerializeField] private PlayerFallDeath playerDeathScript;

    private Vector3 startLvPos;
    private Vector3 lastSpawnPosition;

    private void Awake()
    {
        foreach(Transform k in lvs)
        {
            objectPool.Add(k);
        }

        startLvPos = startLv.position;
        lastSpawnPosition = startLv.Find("EndPos").position;
        activeLevel = startLv;
       

    }

    void Update()
    {
        if (playerDeathScript.isDead)
        {
            return;
        }
        
            if (Vector3.Distance(player.position, lastSpawnPosition) < Boundary)
            {
                activeLevel = SpawnPlatform();

            }
            if (activeLevel != null)
            {
                lastSpawnPosition = activeLevel.Find("EndPos").position;
            }
        
  
    }

    Transform SpawnPlatform()
    {
        if (objectPool.Count>0)
        {


            int randomIndex = Random.Range(0, objectPool.Count);
            /*Transform platform = lvs[randomIndex];*/


            /*Transform newLevel = Instantiate(platform, transform.position, Quaternion.identity);*/
            Transform newLevel = objectPool[randomIndex];


            int lastIndex = objectPool.Count - 1;
            objectPool[randomIndex] = objectPool[lastIndex];


            objectPool.RemoveAt(lastIndex);//O(1) because removing the last index always
            newLevel.transform.position= new Vector2(transform.position.x,transform.position.y);
            newLevel.gameObject.SetActive(true);
            lastSpawnPosition = newLevel.Find("EndPos").position;
            activeInTheScene.Enqueue(newLevel);
            return newLevel;
        }
        else
        {
            Debug.Log("Pool is empty");
            return null;
        }
    }

    public void PoolPush(Transform t)
    {
        if(playerDeathScript.isDead) { return; }//or else OnBecomeInvisible call this when game restart
        if (activeInTheScene.Count > 0)
        {
            /*Debug.Log(t.name);*/
            activeInTheScene.Dequeue();
          /*  foreach (Transform k in activeInTheScene)
                Debug.Log(k.name);*/
        }
        else
        {
            Debug.Log("Queue is empty");
        }
        t.gameObject.SetActive(false);
        
        objectPool.Add(t); 
    }
    public void RestartScript()
    {
        startLv.position = startLvPos;
        startLv.gameObject.SetActive(true);
        
       /* Debug.Log(startLv.gameObject.activeSelf);*/



        lastSpawnPosition = startLv.Find("EndPos").position;
        activeLevel = startLv;
       /* Debug.Log(activeInTheScene.Count);*/
        while (activeInTheScene.Count > 0)
        {
            Transform dequeuedElement = activeInTheScene.Dequeue();
            /*Debug.Log(dequeuedElement.name);*/
            dequeuedElement.gameObject.SetActive(false);
            objectPool.Add(dequeuedElement);

        }

    }
}