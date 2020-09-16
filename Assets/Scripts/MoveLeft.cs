using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public GameObject trap;
    public float speed = 3.0f;
    public PlayerController PlayerControllerScript;
    public GameManager GameManagerScript;
    public GameObject block;



    // Start is called before the first frame update
    void Start()
    {
        block = GameObject.Find("Starting platform");
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * PlayerControllerScript.gameSpeedMultiplier); 
        }
        if (GameManagerScript.gameHasStarted && block.activeSelf==true)
        {
            block.transform.Translate(Vector3.left * Time.deltaTime * speed/2 * PlayerControllerScript.gameSpeedMultiplier);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            if (gameObject.CompareTag("Block"))
            {
                Debug.Log("testing");
                gameObject.SetActive(false);
            }
            else if (!gameObject.CompareTag("Background"))
            {
                Destroy(gameObject);
            }
            
        }
    }
}
