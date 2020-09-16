using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Prefabs;
    public BossScript Boss;
    public PlayerController PlayerControllerScript;
    public GameManager GameManagerScript;
    public BoxCollider boxCollider;
    private float spawnerTime = 5.0f;
    
    
   
    // Start is called before the first frame update
    void Start()
    {

        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        
        //boxCollider = GetComponent<BoxCollider>();
        StartCoroutine(SpawnRate());

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnRate()
    {
        while (!PlayerControllerScript.gameOver)
        {
            if (!PlayerControllerScript.isGamePaused)
            {
                //Debug.Log("game isnt paused");
                Spawner();
                yield return new WaitForSeconds(spawnerTime / PlayerControllerScript.gameSpeedMultiplier);
            }
            else
            {
               yield return new WaitForSeconds(1);
            }
            /*if (PlayerControllerScript.BossSpawned)
            /{
                BossSpawner();
            }*/
        }
    }

    public void Spawner()
    {
        
        
           // int randomInt = Random.Range(0, 4);
            float randomPipeHeight = Random.Range(0, 5.1f);
            float randomX = Random.Range(-212, -208);
            float randomY = Random.Range(-18, -3.7f);
          //  Vector3 randomPos = new Vector3(randomX, randomY, -0.6f);
            Vector3 randomPosPipe1 = new Vector3(randomX, -17.8f + randomPipeHeight, -0.6f);
            Vector3 randomPosPipe2 = new Vector3(randomX, -4f + randomPipeHeight, -0.6f);
            transform.Rotate(randomPosPipe1 * 90);
           // Vector3 boxPos = new Vector3(randomX, -8f, -0.6f);
          //  if (randomInt == 2) 
            {
                Instantiate(Prefabs[2], randomPosPipe1, Prefabs[2].transform.rotation);
                Instantiate(Prefabs[2], randomPosPipe2 , Prefabs[2].transform.rotation);
              //  Instantiate(boxCollider,boxPos, boxCollider.transform.rotation);
            }
            //else
                //Instantiate(Prefabs[randomInt], randomPos, Prefabs[randomInt].transform.rotation);


        
       
    }
    public void BossSpawner()
    {
        Vector3 bossPos = new Vector3(-213,-8.35f,-0.6f);
        Instantiate(Prefabs[3], bossPos, Prefabs[3].transform.rotation);
        //GameManagerScript.Boss.SetActive(true);
        //Debug.Log("boss spawner");

    }
    public void BulletSpawner()
    {
        Vector3 bulletPos = new Vector3(PlayerControllerScript.transform.position.x+1.5f, PlayerControllerScript.transform.position.y, -0.9f);
        Instantiate(Prefabs[4],bulletPos, Prefabs[4].transform.rotation);
    }

    
    //Ammo spawner
    public void boostSpawner()
    {
        if (GameManagerScript.gameWon == false)
        {
            //Boosts include: Ammo & Health 
            //int randomNum = Random.Range(0, 2);
            float randomY = Random.Range(-11, -6);
            float randomX = Random.Range(-208, -205);
            Vector3 boostPos = new Vector3(randomX, randomY, -0.6f);
            Instantiate(Prefabs[0], boostPos, Prefabs[0].transform.rotation);
        }
    }
    public void missileSpawner()
    {
        Debug.Log("Missile spawner");
        //Do I even need "Boss = GameObject.Find("Boss").GetComponent<BossScript>();"??. Cant i just assign it from unity 
        //I WAS RIGHT! YOU DON'T NEED TO INCLUDE IT. Assign "Boss" in the SpawnManager script to Boss.
        //Boss = GameObject.Find("Boss").GetComponent<BossScript>();
        Vector3 bossPos = new Vector3(Boss.transform.position.x-3, Boss.transform.position.y,Boss.transform.position.z);
        Vector3 aboveBoss1 = new Vector3(Boss.transform.position.x-2, Boss.transform.position.y+1, -0.6f);
        Vector3 aboveBoss2 = new Vector3(Boss.transform.position.x-3, Boss.transform.position.y+2, -0.6f);
        Vector3 playerPos = new Vector3(Boss.transform.position.x-1, PlayerControllerScript.transform.position.y-1, -0.6f);
        Instantiate(Prefabs[5], bossPos, Prefabs[5].transform.rotation);
        Instantiate(Prefabs[5], aboveBoss1, Prefabs[5].transform.rotation);
        Instantiate(Prefabs[5], aboveBoss2, Prefabs[5].transform.rotation);
        Instantiate(Prefabs[5], playerPos, Prefabs[5].transform.rotation);
    }

    
}
