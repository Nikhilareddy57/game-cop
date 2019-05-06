using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPool : MonoBehaviour
{
    public int objectPoolSize = 10;
    public GameObject obj;
   // public int objectsNumber = 100;
   // public GameObject obj0, obj1, obj2, obj3, obj4, obj5, obj6, obj7, obj8, obj9, obj10, obj11, obj12;
    public float spawnRate = 4f;
    public int laneMin = -1, laneMax = 2;//max is exclusive for rand function
    
    private GameObject[] objects, ObjectPrefab;
    private Vector3 objectPoolPosition = new Vector3 (0.0f, 0.0f,-200.0f);
    private float timeSinceLastSpawned, spawnZposition = 10f, zPosition = 0;
    private int currentObject = 0, objectSelect;
    
    // Start is called before the first frame update
    void Start()
    {
        ObjectPrefab = new GameObject[objectsNumber];
        objects = new GameObject[objectPoolSize];
        setObjectPrefab();
        for(int i=0; i< objectPoolSize; i++)
        {
            objectSelect = Random.Range(0, objectsNumber);
            objects[i] = (GameObject)Instantiate(ObjectPrefab[objectSelect], objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if(GameControl.instance.hasLife == true && timeSinceLastSpawned >= spawnRate)
        //if (hasLife == true && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;

            for(int i=0; i<objectPoolSize; i++)
            {
                int lane = Random.Range(-1, 1);
                objects[i].transform.position = new Vector3((float)(3.04 * lane), 0f, zPosition + (i* spawnZposition));
                objects[i].SetActive(true);
            }
            currentObject++;

            if(currentObject >= objectPoolSize)
            {
                currentObject = 0;
            }
        }
    }

   /* void setObjectPrefab()
    {
        ObjectPrefab[0] = (GameObject)Instantiate(obj0);
        ObjectPrefab[1] = (GameObject)Instantiate(obj1);
        ObjectPrefab[2] = (GameObject)Instantiate(obj2);
        ObjectPrefab[3] = (GameObject)Instantiate(obj3);
        ObjectPrefab[4] = (GameObject)Instantiate(obj4);
        ObjectPrefab[5] = (GameObject)Instantiate(obj5);
        ObjectPrefab[6] = (GameObject)Instantiate(obj6);
        ObjectPrefab[7] = (GameObject)Instantiate(obj7);
        ObjectPrefab[8] = (GameObject)Instantiate(obj8);
        ObjectPrefab[9] = (GameObject)Instantiate(obj9);
        ObjectPrefab[10] = (GameObject)Instantiate(obj10);
        ObjectPrefab[11] = (GameObject)Instantiate(obj11);
        ObjectPrefab[12] = (GameObject)Instantiate(obj12);
        //ObjectPrefab[] = obj;
    }*/
}
