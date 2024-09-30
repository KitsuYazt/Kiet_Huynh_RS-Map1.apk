using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawn : MonoBehaviour
{
    private float plantSize = 40f;
    private float xPosLeft=-48;
    private float xPosRight=32;
    private float centerZPos = -12;
    public List<GameObject> plants;
    void Start()
    {

        for (int i = 0; i < 50; i++)
        {
            GameObject plantLetf = plants[Random.Range(0, plants.Count)];
            GameObject plantRight = plants[Random.Range(0, plants.Count)];
            float zPos =  (i*  plantSize)+ centerZPos ;

            Instantiate(plantLetf, new Vector3(xPosLeft, -0.1f, zPos)
                , plantLetf.transform.rotation);
            Instantiate(plantRight, new Vector3(xPosRight, -0.1f, zPos)
                , new Quaternion(0, 180, 0, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlant()
    {
    
    }
}
