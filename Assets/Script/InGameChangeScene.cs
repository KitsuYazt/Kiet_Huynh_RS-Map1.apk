using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameChangeScene : MonoBehaviour
{
    [SerializeField] Button btnMenu;
    void Start()
    {
        if (btnMenu != null)
        {
            btnMenu.onClick.AddListener(Menu);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Menu()
    {
        Debug.Log("Menu button clicked");
        SceneManager.LoadScene("MenuScene");
    }
}
