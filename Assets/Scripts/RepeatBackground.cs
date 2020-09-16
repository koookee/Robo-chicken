using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public float BackgroundWidth;
    //public float speed = 20.0f;
    public Vector3 startPos;
    public Vector3 currentPos;


    // Start is called before the first frame update
    void Start()
    {

        BackgroundWidth = GetComponent<BoxCollider>().size.x / 2;
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - BackgroundWidth * 6)
        {
            transform.position = startPos;
        }


    }
}

