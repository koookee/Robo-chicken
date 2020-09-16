using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public GameObject trap;
    public float speed = 3.0f;
    public PlayerController PlayerControllerScript;



    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.Translate(Vector3.forward * Time.deltaTime * speed * PlayerControllerScript.gameSpeedMultiplier);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            Destroy(trap.gameObject);
        }
    }
}
