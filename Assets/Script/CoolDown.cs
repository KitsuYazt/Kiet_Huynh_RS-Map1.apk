using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : MonoBehaviour
{
    public float elapse;
    public float duration;
    public bool isCooling
    {
        get
        {
            return elapse < duration;
        }
    }

    public bool isFinished
    {
        get
        {
            return elapse > duration;
        }
    }


    public void Restart()
    {
        elapse = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        elapse += 1*Time.deltaTime;
    }
}
