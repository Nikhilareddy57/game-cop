using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cars : MonoBehaviour
{
    public float Speed = 40f, accelaration = 0.1f, velocity = 0f;//timeDuration = 10f,;
    private GameControl gc;
    private Rigidbody rb;

    //   private float timeSinceLastFlag = 0f;

    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameControl>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, Speed);
        //velocity = rb.velocity.z;
    }

    void Update()
    {
        if (gc.hasLife == false || gc.pause)
        {
            rb.velocity = Vector3.zero;
            velocity = 0f;
        }
        else
        {
            rb.transform.Translate(Speed * Vector3.forward * Time.deltaTime);
            velocity = Speed;
        }
        //velocity = rb.velocity.z;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bio")|| other.gameObject.CompareTag("NonBio")|| other.gameObject.CompareTag("Harmful"))
        {
           // other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }
}
