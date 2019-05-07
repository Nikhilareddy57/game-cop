using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingCars : MonoBehaviour
{
    public GameObject[] cars;
    //public int objectsNumber;
    //public Vector3 spawnValues;
    public float spawnZMin, spawnZMax;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    private GameControl gc;
   // private int i = 1;
    public float length;

    int randObject;

    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameControl>();
        StartCoroutine(waitSpawner());
    }

    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
           // Debug.Log("hi");
            //spawnZMin = i * length; spawnZMax = (i + 1) * length;
            randObject = Random.Range(0, cars.Length);
            Vector3 spawnPosition = new Vector3((float)(3.04 * Random.Range(-1, 2)), 0.9f, Random.Range(spawnZMin, spawnZMax));
            Vector3 rotation = new Vector3 (0f, 180f, 0f);
            if (!gc.pause && gc.hasLife)
            {
               // Debug.Log("hello");
                Instantiate(cars[randObject], spawnPosition + transform.TransformPoint(0, 0, 0) , cars[randObject].transform.rotation );
                //tranform.Rotate(0, 180, 0, Space.self);
                // i++; flag = true;
                //if (i > 3) i = 1;
            }
            yield return new WaitForSeconds(spawnWait);
        }
    }

} 