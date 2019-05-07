using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Rigidbody rbo;
    private scrollingBackground pl;
    private GameControl gc;
    // Update is called once per frame
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameControl>();
      //  Debug.Log("gc.name");
        pl = GameObject.Find("Plane").GetComponent<scrollingBackground>(); //Debug.Log("1");
        rbo = GetComponent<Rigidbody>();
        rbo.velocity = new Vector3(0, 0, pl.scrollSpeed);
    }

    void Update()
    {
        transform.Rotate(new Vector3(15, 45, 30) * Time.deltaTime);
        //Debug.Log("2");
        //if(pl.velocity == 0.0f)
         if (gc.hasLife == false || gc.pause)
         {
            rbo.velocity = Vector3.zero;
         }
         else
         {
            rbo.transform.position = (Vector3)transform.position + (pl.velocity * Vector3.back * Time.deltaTime);
            //rbo.transform.Translate(pl.rb.velocity.z * Vector3.back * Time.deltaTime);
            // rbo.transform.Translate(pl.scrollSpeed * Vector3.back * Time.deltaTime);
         //   Debug.Log((pl.velocity * Vector3.back * Time.deltaTime));
        }
        //   if (rb.position.z > 0)
        //     obj.SetActive(true);
    }
}
