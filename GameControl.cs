using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    //public float scrollSpeed = -5f;
    public bool pause = true;
    public bool hasLife = true;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        { 
            instance = (GameControl)Instantiate(this);
        }
        else if (instance != this)
        {
            Destroy(gameObject); 
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            pause = !pause;
        }
        //Debug.Log(pause);
    }

    public void LifeOver()
    {
        gameOverText.SetActive(true);
        hasLife = false;
    }
}
