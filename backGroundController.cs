using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backGroundController : MonoBehaviour
{
    private GameControl gc;
    public int life = 5;
    public Text LifeText;
    void Start()
    {
        setLifeText();
        gc = GameObject.Find("GameController").GetComponent<GameControl>();
    }

    void Update()
    {
        Debug.Log(gc.hasLife);
        if (life <= 0)
        {
            gc.hasLife = false;
            gc.LifeOver();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Harmful"))
        {
            life -= 1;
            setLifeText();
            other.gameObject.SetActive(false);
            //        pc.score += 2;
            //      pc.setScoreText();
        }
        // else if (other.gameObject.CompareTag("Bio") || other.gameObject.CompareTag("NonBio"))

    }

    void setLifeText()
    {
        LifeText.text = "Life: " + life.ToString();
    }
}
