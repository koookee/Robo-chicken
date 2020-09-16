using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class PlayerController2 : MonoBehaviour
{
    public SpawnManager SpawnManagerScript;
    public Rigidbody playerRb;
    public GameObject Player;
    public float gravityStrength;
    private bool inBoundary = false;
    public bool gameOver = false;
    public float score = 0;
    public GameManager GameManagerScript;
    public bool isGamePaused = false;
    public float gameSpeedMultiplier = 1.0f;
    public bool BossSpawned = false;
    private int ammo = 5;
    private int health = 3;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -1 * gravityStrength, 0);
        playerRb.AddForce(Vector3.up * 2, ForceMode.Impulse);
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        SpawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        StartCoroutine(boostSpawner());

    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        inBoundaryCondition();
        if (Input.GetKeyDown(KeyCode.J) && inBoundary)
        {
            playerRb.velocity = (Vector3.up * 5);

        }
        if (!inBoundary)
        {
            Debug.Log("Game Over");
            gameOver = true;
            Destroy(Player);
        }
        if (health == 0)
        {
            Destroy(gameObject);
            gameOver = true;
        }
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
            yield return new WaitForSeconds(4);
            GameManagerScript.OnScreen(i);

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
            yield return new WaitForSeconds(20);
            SpawnManagerScript.boostSpawner();
        }


    }
    void inBoundaryCondition()
    {

        //float moreThan = -90f;
        // float lessThan = 100;
        if (transform.position.y > -14.0f && transform.position.y < -3.3f)
        {
            inBoundary = true;
        }
        else
        {
            inBoundary = false;
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
        if (other.gameObject.CompareTag("Trap"))
        {
            Destroy(gameObject);
            health--;
            Destroy(other.gameObject);



        }
        if (other.gameObject.CompareTag("Score"))
        {
            score += 20;
            Debug.Log(score);
            if (score == 100)
            {
                isGamePaused = true;
                StartCoroutine(displayText(1));

            }
            if (score == 120)
            {
                StartCoroutine(startGameAgain());
            }
            if (score == 300)
            {
                isGamePaused = true;
                StartCoroutine(displayText(2));
            }
            if (score == 320)
            {
                StartCoroutine(startGameAgain());
            }
            if (score == 600)
            {
                isGamePaused = true;
                StartCoroutine(displayText(3));
            }
            if (score == 620)
            {
                StartCoroutine(startGameAgain());
            }
            if (score == 900)
            {
                isGamePaused = true;
                StartCoroutine(displayText(4));
                gameSpeedMultiplier = 1;
            }


        }


    }

    public void Fire()
    {
        if (ammo != 0 && Input.GetKeyDown(KeyCode.F))
        {
            ammo--;
            SpawnManagerScript.BulletSpawner();
        }
    }
}
*/
