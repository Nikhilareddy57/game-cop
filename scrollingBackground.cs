using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingBackground : MonoBehaviour
{
    public Rigidbody rb;
    public float scrollSpeed = 5f;
    private GameControl gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameControl>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, scrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.instance.hasLife == false || GameControl.instance.pause)
        //if (gc.hasLife == false || gc.pause)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {  
            rb.transform.Translate(scrollSpeed * Vector3.back * Time.deltaTime);
        }
    }
}
