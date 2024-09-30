using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlantSpawnMenu : MonoBehaviour
{
    private float plantSize = 10f;
    private float xPosLeft = -37;
    private float centerZPos = 32;
    public List<GameObject> plants;
    private Transform player;
    [HideInInspector]public List<GameObject> plant;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        for (int i = 15; i > 0; i--)
        {
            GameObject plantLetf = plants[Random.Range(0, plants.Count)];
            float zPos = centerZPos - (i * plantSize);

            GameObject newPlants = Instantiate(plantLetf, new Vector3(xPosLeft, -0.1f, zPos)
                , plantLetf.transform.rotation);
            plant.Add(newPlants);
        }
        plant = plant.OrderBy(r => r.transform.position.z).ToList();
    }

    void Update()
    {
        SpawnPlant();
    }
    public void SpawnPlant()
    {
        if (plant[0].transform.position.z < player.transform.position.z - 140)
        {
            GameObject moveRoad = plant[0];
            plant.Remove(moveRoad);
            float newZ = plant[plant.Count - 1].transform.localPosition.z + plantSize;
            moveRoad.transform.localPosition = new Vector3(-37, -0.1f, newZ);
            plant.Add(moveRoad);
        }
    }


}
