using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public float speed = 0.00000000000001f;

    private Rigidbody player;
    private bool right = false, left = false, pst = true;//pst checks if player is in middle of lane 
    private int laneInt = 0, newLane = 0, score =0;
    private Vector3 offset = Vector3.zero ;
    public Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        score = 0;
        setScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        int laneCurrent = lane(player.position.x);
      
            if (!(right || left)) //both are not true
            {   
                if(pst)
                {
                    if (Input.GetKey("right"))
                        right = true;
                    else if (Input.GetKey("left"))
                        left = true;
                }
                
            }
            else if (right && left)
            {
                right = false; left = false;
            }
            else
            {
                if(right)
                {
                    if((laneInt == -1) && (newLane != 0))
                    {
                        newLane = 0; pst = false;
                    }
                    else if ((laneInt == 0) && (newLane != 1))
                    {
                        newLane = 1; pst = false;
                    }
                }
                else if(left)
                {
                    if ((laneInt == 0) && (newLane != -1))
                    {
                       newLane = -1; pst = false;
                    }
                    if ((laneInt == 1) && (newLane != 0))
                    {
                        newLane = 0; pst = false;
                    }
                }

                if (laneCurrent != newLane)
                {
                    if (newLane < laneInt)
                        offset = Vector3.left * Time.deltaTime * speed;
                    else if (newLane > laneInt)
                        offset = Vector3.right * Time.deltaTime * speed;

                }
                else if ((laneCurrent == newLane))
                {
                    if (pst)
                    {
                        right = false; left = false;
                        laneInt = newLane;
                    }
                    if (!pst)
                    {
                        if ((laneCurrent == -1) && (player.position.x <= -3.039) )
                        {
                            pst = true; offset = Vector3.zero;
                            right = false; left = false;
                            laneInt = newLane;
                        }
                        else if ((laneCurrent == 1) &&  (player.position.x >= 3.039))
                        {
                            pst = true; offset = Vector3.zero;
                            right = false; left = false;
                            laneInt = newLane;
                        }
                        else if ((laneCurrent == 0) && (player.position.x < 0.1) && (player.position.x > -0.1))
                        {
                            pst = true; offset = Vector3.zero;
                            right = false; left = false;
                            laneInt = newLane;
                        }
                }

                }

             Vector3 temp = player.position + offset;

                if(temp.x > 3.04)
                    temp = new Vector3(3.04f, 0.0f, 0.0f);
                else if (temp.x < -3.04)
                    temp = new Vector3(-3.04f, 0.0f, 0.0f);
                if((newLane == 0)&& (player.position.x < 0.1) && (temp.x > 0.1))
                    temp = new Vector3(0.0f, 0.0f, 0.0f);
                if ((newLane == 0) && (player.position.x > -0.1) && (temp.x < -0.1))
                    temp = new Vector3(0.0f, 0.0f, 0.0f);

            player.position = temp;

           // Debug.Log("right:" + right + " left:" + left + " pst:" + pst + " lane: " + laneCurrent + " newLane:" +newLane + " laneInt:"+laneInt+" X:" +  player.position.x + ((player.position.x < -1) && (player.position.x > 1)));

            // }
        }

    }

    int lane(float x)
    {
        if (-1.5 <= x && x <= 1.5)
            return 0;
        else if (-3.06 <= x && x <= -1.5)
            return -1;
        else if (1.5 <= x && x <= 3.06)
            return 1;
        else
            return 10;
    }

    void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.CompareTag("Bio"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            setScoreText();
        }
            
    }

    void setScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
