using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //private Rigidbody rb;
   // private GameObject obj;
    // Update is called once per frame
    void start()
    {

    }

    void Update()
    {
        transform.Rotate(new Vector3(15, 45, 30) * Time.deltaTime);

     //   if (rb.position.z > 0)
       //     obj.SetActive(true);
    }
}
