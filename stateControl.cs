using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateControl : MonoBehaviour
{
    static Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("up"))
        {
            anim.SetTrigger("jumping");
        }
        if (GameControl.instance.pause)
        {
            anim.SetBool("isIdle", true);//anim.SetBrigger("isIdle");anim.SetTrigger("isIdle");/
           // anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isIdle", false);
          //  anim.SetBool("isRunning", true);
        }
           // anim.SetTrigger("isRunning");//SetBool("isRunning");//setTrigger("isRunning");
    }
}
//Input.GetButtonDown("Jump")