using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    public WaveSpawner waveSpawner;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI score;
    public TextMeshProUGUI currWave;
    int currScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currScore = waveSpawner.currWave;
        currWave.text = currScore.ToString();
        score.text = currScore.ToString();

        if(currScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", currScore);
            highScore.text = currScore.ToString();
        }
        //if (Input.GetKeyDown("k"))
        //{

        //    PlayerPrefs.DeleteAll();
        //}
    }
}
