using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingBackground : MonoBehaviour
{
    public static scrollingBackground plane;
    public Rigidbody rb;
    public float scrollSpeed = 5f, accelaration = 0.1f, velocity = 0f;//timeDuration = 10f,;
    private GameControl gc;
 //   private float timeSinceLastFlag = 0f;
    
    void Start()
    {
        if (plane == null)
        {
            plane = (scrollingBackground)Instantiate(this);
        }
        
        gc = GameObject.Find("GameController").GetComponent<GameControl>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, scrollSpeed);
        //velocity = rb.velocity.z;
    }

    void Update()
    {
        /*  timeSinceLastFlag += Time.deltaTime;
          if(timeSinceLastFlag > timeDuration)
          {

          }*/
       // scrollSpeed += accelaration * Time.deltaTime;
       // if(scrollSpeed > 40)
       // if (GameControl.instance.hasLife == false || GameControl.instance.pause)
        if (gc.hasLife == false || gc.pause)
        {
            rb.velocity = Vector3.zero;
            velocity = 0f;
        }
        else
        {  
            rb.transform.Translate(scrollSpeed * Vector3.back * Time.deltaTime);
            velocity = scrollSpeed;
        }
        //velocity = rb.velocity.z;
    }
}
