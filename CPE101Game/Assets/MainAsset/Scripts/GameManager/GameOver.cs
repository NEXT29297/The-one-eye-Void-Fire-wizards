using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject WaveSpawner;
    public GameObject Gamestart;


    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(0);
        }
        
        if (Input.GetKeyDown("g"))
        {

            WaveSpawner.SetActive(true);
            Gamestart.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
