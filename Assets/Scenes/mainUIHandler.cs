using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainUIHandler : MonoBehaviour
{
    public Text gameobjectofhighscoreandname;

    // Start is called before the first frame update
    void Start()
    {
        gameobjectofhighscoreandname = GameObject.Find("highestScore").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHighestScoreWithName()
    {
        dataPersistenceScript.Instance.highestscorename = dataPersistenceScript.Instance.nameofcurrentplayer;
        dataPersistenceScript.Instance.highestscore = dataPersistenceScript.Instance.currentscore;
    }

    public void ChangeHighScoreText()
    {
        gameobjectofhighscoreandname.text = "Best Score: " + dataPersistenceScript.Instance.highestscorename + ": " + dataPersistenceScript.Instance.highestscore;
    }
}
