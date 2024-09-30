using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    public bool line2 = false;

    private float yCamSet = 30f;
    private float zCamSet = -30f;
    private float xCamSet = 0;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        if (line2)
        {
            Line2();
        }
        else
        {
            Line1();
        }
    }

    public void Line1()
    {
        transform.position = new Vector3(player.position.x + xCamSet
            , 30f
            , player.position.z + zCamSet);

        transform.localRotation = Quaternion.Euler(35,0,0);
    }
    public void Line2()
    {
        transform.position = new Vector3(player.position.x + xCamSet
            , 30f
            , player.position.z - zCamSet);
        transform.localRotation = Quaternion.Euler(35, 180, 0);

    }

}
