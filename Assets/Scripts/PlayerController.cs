using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   // public Animator anim;
    public SpawnManager SpawnManagerScript;
    public Rigidbody playerRb;
    public GameObject Player;
    public float gravityStrength;
    private bool inBoundary = false;
    public bool gameOver = false;
    public float score = 0;
    public GameManager GameManagerScript;
    public bool isGamePaused = true;
    public float gameSpeedMultiplier = 1.0f;
    public bool BossSpawned = false;
    public int ammo = 3;
    //change ammo back to 3
    //change to 50 for playtesting
    private int health = 3;
    private AudioSource playerAudio;
    public AudioClip bulletSound;
    public AudioClip scoreAudio;

    

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        //anim = GetComponent<Animator>();
        //anim.speed = 0;
        playerRb = GetComponent<Rigidbody>();
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        SpawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        
        StartCoroutine(StartGame());
        playerRb.useGravity = false;
        //Physics.gravity = new Vector3(0, -1 * gravityStrength, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isGamePaused);
        Fire();
        inBoundaryCondition();
        if (Input.GetKeyDown(KeyCode.Space) && inBoundary && GameManagerScript.gameHasStarted==true)
        {
            playerRb.velocity = (Vector3.up * 5);

        }
        if (!inBoundary)
        {
            Debug.Log("Game Over");
            gameOver = true;
            Destroy(Player);
        }
        if(health == 0)
        {
            Destroy(gameObject);
            gameOver = true;
        }
    }
    IEnumerator StartGame()
    {
        while (isGamePaused == true)
        {
            yield return new WaitForSeconds(0.1f);
        }
        GameManagerScript.startButton.gameObject.SetActive(false);
        playerRb.useGravity = true;
        //Physics.gravity = new Vector3(0, -1 * gravityStrength, 0);
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    //When player defeats Boss
    public void playerFlying()
    {
        
    }
    IEnumerator displayText(int i)
    {
        if (i < 4)
        {
            yield return new WaitForSeconds(9);
            GameManagerScript.OnScreen(i);
        }
        else
        {
            yield return new WaitForSeconds(5);
            GameManagerScript.OnScreen(i);
            gameSpeedMultiplier = 1;
            StartCoroutine(boostSpawner());

        }
         
    }
    IEnumerator startGameAgain()
    {
        yield return new WaitForSeconds(9);
        isGamePaused = false;
        gameSpeedMultiplier += 0.5f;

    }
    IEnumerator boostSpawner()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(7);
            SpawnManagerScript.boostSpawner();
        }
    }
    void inBoundaryCondition()
    {

        //float moreThan = -90f;
        // float lessThan = 100;
        if (GameManagerScript.gameWon == false)
        {
            if (transform.position.y > -14.0f && transform.position.y < -3.3f)
            {
                inBoundary = true;
            }
            else
            {
                inBoundary = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo") && (ammo < 3))
        {
            Destroy(other.gameObject);
            ammo++;
            Debug.Log("Passed");
        }
        if (other.gameObject.CompareTag("Health") && (health < 3))
        {
            Destroy(other.gameObject);
            health++;
        }
        if (other.gameObject.CompareTag("Trap") || other.gameObject.CompareTag("Missile"))
        {
            Debug.Log("Booom");
            Destroy(gameObject);
            health--;
            Destroy(other.gameObject);
            gameOver = true;
        }
        if (other.gameObject.CompareTag("Score"))
        {
            playerAudio.PlayOneShot(scoreAudio,7);
            //score was += 20
            //Score += 900 for playtesting
            score += 20;
            Debug.Log(score);
            if(score == 100)
            {
                isGamePaused = true;
                StartCoroutine(displayText(1));
               
            }
            if (score == 120)
            {
                StartCoroutine(startGameAgain());
            }
            if(score == 300)
            {
                isGamePaused = true;
                StartCoroutine(displayText(2));
               // Debug.Log("nine hundren");
            }
            if(score == 320)
            {
                StartCoroutine(startGameAgain());
            }
            if(score == 600)
            {
                isGamePaused = true;
                StartCoroutine(displayText(3));
            }
            if(score == 620)
            {
                StartCoroutine(startGameAgain());
            }
            if (score == 900)
            {
                isGamePaused = true;
                StartCoroutine(displayText(4));
                
                
            }


        }

       
    }

    public void Fire()
    {  
      if(ammo!=0 && Input.GetKeyDown(KeyCode.F) && GameManagerScript.gameHasStarted == true)
        {
            playerAudio.PlayOneShot(bulletSound);
            ammo--;
            SpawnManagerScript.BulletSpawner();
        }
    }
}
