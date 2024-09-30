using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    private float spawnHorizal;
    private float spawnVertical;
    private float randomRotation;
    [SerializeField] private DataHandler dataHandler;

    public List<GameObject> spawnList = new List<GameObject>(); 
    public List<Vector3> obstaclePositions = new List<Vector3>(); 

    void Start()
    {
        SpawnObstacles();
    }
    void SpawnObstacles()
    {
        for (int i = 0; i < 10 + dataHandler.mapLv*2 ; i++) 
        {
            spawnHorizal = Random.Range(-24, 8);
            spawnVertical = Random.Range(0 + i * 35, 35 + i * 35);
            randomRotation = Random.Range(0, 360);
            GameObject obstaclePrefab = spawnList[Random.Range(0, dataHandler.mapLv *4)];
            GameObject obstacle = Instantiate(obstaclePrefab
                , new Vector3(spawnHorizal, 0, spawnVertical)
                , Quaternion.Euler(0, randomRotation, 0));
            Vector3 spawnPosition = obstacle.transform.position;
            obstaclePositions.Add(spawnPosition);
        }
    }
}
