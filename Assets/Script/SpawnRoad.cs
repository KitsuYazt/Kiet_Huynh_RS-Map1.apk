using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnRoad : MonoBehaviour
{
    public GameObject road;
    private float offset = 40f;
    void Start()
    {
        for (int i = 0; i < 70; i++)
        {
            road.transform.localPosition = new Vector3(0, 0, i*40);
            road.transform.localRotation = Quaternion.Euler(0, 0, 0);
            Instantiate(road);
        }
    }
}
