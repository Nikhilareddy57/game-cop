using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPool : MonoBehaviour
{
    public GameObject[] objects;
    //public int objectsNumber;
    //public Vector3 spawnValues;
    public float spawnZMin, spawnZMax;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    private GameControl gc;

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

          while(!stop)
          {
                randObject = Random.Range(0, objects.Length);
                Vector3 spawnPosition = new Vector3((float)(3.04 * Random.Range(-1, 2)), 0.9f, Random.Range(spawnZMin, spawnZMax));
              if(!gc.pause&& gc.hasLife)
              {                  
                  Instantiate(objects[randObject], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                }
              yield return new WaitForSeconds(spawnWait);
          }
      }

}

