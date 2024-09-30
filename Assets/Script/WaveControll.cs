using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveControll : MonoBehaviour
{
    [SerializeField] private Transform wave;
    [SerializeField] private DataHandler dataHandler;
    [SerializeField] private Transform player;
    [SerializeField] GameObject gameObject;
    public bool endGame = false;

    private void Update()
    {
        checkPlayer();
        Run();
    }

    private void Start()
    {

    }

    public void Run()
    {
        if (endGame) return;
        if (wave.localPosition.z < 350)
        {
            wave.localPosition = new Vector3(0, 0, wave.localPosition.z + (10 + dataHandler.mapLv * 2) * Time.deltaTime);
        }
        else
        {
            wave.localPosition = new Vector3(0, 0, wave.localPosition.z + (40 + dataHandler.mapLv * 2) * Time.deltaTime);
        }
    }

    private void checkPlayer()
    {
        float distance = 0.5f;
        if (Mathf.Abs((wave.transform.position.z-0.5f) - player.transform.position.z) < distance)
        {
            gameObject.gameObject.SetActive(true);
            endGame = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.Equals(player))
        {
            gameObject.gameObject.SetActive(true);
            endGame = true;
        }
    }
}
