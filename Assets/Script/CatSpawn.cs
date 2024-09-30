using System.Collections.Generic;
using UnityEngine;

public class CatSpawn : MonoBehaviour
{
    public GameObject cat;
    private float spawnHorizal;
    private float spawnVertical;
    private float offset = 40f; 
    public List<GameObject> cats;
    public List<GameObject> catsInhead; 
    public SpawnObstacle obstacleSpawner;
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            spawnHorizal = Random.Range(-24, 8);
            spawnVertical = Random.Range(0 + i * 60, 60 + i * 60);
            GameObject newCat = Instantiate(cat, new Vector3(spawnHorizal, 0, spawnVertical), 
                Quaternion.Euler(0, 0, 0));
            cats.Add(newCat);
        }

        for (int i = 0; i < catsInhead.Count; i++)
        {
            catsInhead[i].SetActive(false);
        }
    }

    void SpawnCats()
    {
        for (int i = 0; i < 5; i++) 
        {
            Vector3 spawnPosition = GetValidCatPosition();
            Instantiate(cat, spawnPosition, Quaternion.identity);
        }
    }
    Vector3 GetValidCatPosition()
    {
        Vector3 spawnPosition;
        bool isValidPosition = false;

        do
        {
            spawnPosition = GetRandomPosition();
            isValidPosition = true;

            foreach (Vector3 obstaclePos in obstacleSpawner.obstaclePositions)
            {
                if (Vector3.Distance(spawnPosition, obstaclePos) < 5.0f) 
                {
                    isValidPosition = false;
                    break;
                }
            }

        } while (!isValidPosition);

        return spawnPosition;
    }
    Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-24, 8), 0, Random.Range(-10, 10));
    }
    private void Update()
    {
        PickCat();
    }

    public void PickCat()
    {
        for (int i = 0; i < cats.Count; i++)
        {
            if (!cats[i].activeInHierarchy)
            {
                catsInhead[i].SetActive(true);
            }
        }
    }
}
