using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnRoadManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject road;
    [HideInInspector]
    public List<GameObject> roads;
    private Transform player;
    private float offset = 40f;
    PlantSpawn plantSpawn;
    void Start()
    {
        plantSpawn = GetComponent<PlantSpawn>(); 
        player = GameObject.Find("Player").transform;
        for (int i = 0; i < 10; i++)
        {
            road.transform.localPosition = new Vector3(-10, 0, 80 - i * 40);
            road.transform.localRotation = Quaternion.Euler(0, 180, 0);
            GameObject newRoad = Instantiate(road);
            roads.Add(newRoad);
        }
        roads = roads.OrderBy(r => r.transform.position.z).ToList();
    }

    // Update is called once per frame
    void Update()
    {
       SpawnRoad();
    }
    public void SpawnRoad()
    {
            if (roads[0].transform.position.z < player.transform.position.z - 140)
            {
            GameObject moveRoad = roads[0];
            roads.Remove(moveRoad);
            float newZ = roads[roads.Count - 1].transform.localPosition.z + offset;
            moveRoad.transform.localPosition = new Vector3(-10, 0, newZ);
            roads.Add(moveRoad);
        }
    }
}
