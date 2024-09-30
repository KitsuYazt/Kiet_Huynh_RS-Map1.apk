using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : MonoBehaviour
{
    private Transform player;

    private float yCamSet = 8f;
    private float zCamSet = 20f;
    private float xCamSet = 17f;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x + xCamSet, player.position.y + yCamSet, player.position.z + zCamSet);
    }
}
