using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private PlayerControlller playerControlller;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private DataHandler dataHandler;
    [HideInInspector]public bool winGame = false;
    private void OnTriggerEnter(Collider other)
    {
        if (cameraController.line2)
        {
            Debug.Log("run");
            winGame = true;
            dataHandler.Save();
            dataHandler.dollar += 1000;
            gameObject.gameObject.SetActive(true);
        }
        if (other.CompareTag("Player"))
        {
            playerControlller.isJoystick = false;
            cameraController.line2 = true;
            transform.position = new Vector3(transform.position.x,
                transform.position.y,
                transform.position.z + 200);
        }
        playerControlller.cd.Restart();
    }
}
