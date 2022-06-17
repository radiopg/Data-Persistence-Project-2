using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bestScoreScript : MonoBehaviour
{
    public string nameofplayer;
    public int score;

    public Text highscoreinfo;

    // Start is called before the first frame update
    void Start()
    {
        highscoreinfo = GameObject.Find("HighestScore").GetComponent<Text>();

        if(dataPersistenceScript.Instance != null)
        {
            nameofplayer = dataPersistenceScript.Instance.playername;
            score = dataPersistenceScript.Instance.score;
        }

        ChangeHighestScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeHighestScoreText()
    {
        highscoreinfo.text = "Best Score: " + nameofplayer + ": " + score;
    }
}
