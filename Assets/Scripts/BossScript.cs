using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public PlayerController PlayerControllerScript;
    public GameManager GameManagerScript;
    public SpawnManager SpawnManagerScript;
    private float speed = 1f;
    private float superSpeed = 6f;
    public float health = 10;
    private bool isBossAlive = true;
    private float playerPos;
    Vector3 endPos = new Vector3(-219f, -8.35f, -0.9f);
    private AudioSource bossAudio;
    public AudioClip damageAudio;
    public AudioClip rocketAudio;

    // Start is called before the first frame update

    void Start()
    {
        bossAudio = GetComponent<AudioSource>();
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        SpawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        StartCoroutine(BossAttackCycle());
        GameManagerScript.bossHP.gameObject.SetActive(true);
    }



    // Update is called once per frame
    void Update()
    {
        GameManagerScript.bossHP.text = "Boss Health:" + health;
        if (transform.position.x > endPos.x)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManagerScript.endGame();
        }
    }

    IEnumerator BossAttackCycle()
    {
        while (isBossAlive == true)
        {
            Debug.Log("boss script");
            /* Can't place it before yield return new for some reason
            SpawnManagerScript.missileSpawner();*/
            yield return new WaitForSeconds(7);
            playerPos = PlayerControllerScript.transform.position.y;
            //While loop executes faster than Update()
            bossAudio.PlayOneShot(rocketAudio);
            SpawnManagerScript.missileSpawner();
            //Debug.Log("boss script");
            InvokeRepeating("slowlyMoving", 0.1f, 0.1f);
        }
    }
        void slowlyMoving()
        {
            if(!(playerPos - 0.5f < transform.position.y && transform.position.y < playerPos + 0.5f))
            {
                if (playerPos > transform.position.y)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * superSpeed);
                }
                else
                {
                    transform.Translate(Vector3.down * Time.deltaTime * superSpeed);
                }
            }
        }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            bossAudio.PlayOneShot(damageAudio);
            health--;
            Destroy(other.gameObject);
            //Debug.Log("Boss taking damage");
        }
    }
}

