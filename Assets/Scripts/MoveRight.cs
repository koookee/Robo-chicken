using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public GameObject trap;
   // public BossScript BossScript;
    public float speed = 5.0f;
    public PlayerController PlayerControllerScript;



    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
       // BossScript = GameObject.Find("Boss").GetComponent<BossScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerControllerScript.gameOver)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * PlayerControllerScript.gameSpeedMultiplier);
        }
        else
        {
            Destroy(gameObject);
        }
    }

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boss"))
        {
            BossScript.health -= 1;
            Destroy(gameObject);
        }
    } */
}
