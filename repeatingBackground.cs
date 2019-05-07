using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatingBackground : MonoBehaviour
{
    //private BoxCollider groundCollider;
    private float groundLength = 80; 
    // Start is called before the first frame update
    void Start()
    {
       // groundCollider = GetComponent<BoxCollider>();
        //groundLength = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < -(groundLength+20))
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector3 groundoffset = new Vector3(0, 0, groundLength * 4f);
        transform.position = (Vector3)transform.position + groundoffset;
    }
}
