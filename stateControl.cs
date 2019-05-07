using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateControl : MonoBehaviour
{
    static Animator anim;
    private GameControl gc;

    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameControl>();
        anim = GetComponent<Animator>();//Debug.Log("3");
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetBool("isIdle", true);
       if(Input.GetKey("up"))
       {
          anim.SetTrigger("jumping");
       }
       if (gc.pause)
       {
          anim.SetBool("isIdle", true);//anim.SetBrigger("isIdle");anim.SetTrigger("isIdle");/
       // anim.SetBool("isRunning", false);
       }
       else
       {
          anim.SetBool("isIdle", false);
       //  anim.SetBool("isRunning", true);
       }
       if(gc.accident)
        {
            anim.SetBool("accident", true);
        }
                                         // anim.SetTrigger("isRunning");//SetBool("isRunning");//setTrigger("isRunning");
    }
}
//Input.GetButtonDown("Jump")