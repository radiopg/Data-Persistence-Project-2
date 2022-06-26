using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class highscoresUIHandler : MonoBehaviour
{
    public TextMeshProUGUI p1name;
    public TextMeshProUGUI p2name;
    public TextMeshProUGUI p3name;
    public TextMeshProUGUI p4name;
    public TextMeshProUGUI p5name;

    public TextMeshProUGUI p1score;
    public TextMeshProUGUI p2score;
    public TextMeshProUGUI p3score;
    public TextMeshProUGUI p4score;
    public TextMeshProUGUI p5score;

    // Start is called before the first frame update
    void Start()
    {
        p1name = GameObject.Find("highScoreName1").GetComponent<TextMeshProUGUI>();
        p2name = GameObject.Find("highScoreName2").GetComponent<TextMeshProUGUI>();
        p3name = GameObject.Find("highScoreName3").GetComponent<TextMeshProUGUI>();
        p4name = GameObject.Find("highScoreName4").GetComponent<TextMeshProUGUI>();
        p5name = GameObject.Find("highScoreName5").GetComponent<TextMeshProUGUI>();

        p1score = GameObject.Find("highScoreScore1").GetComponent<TextMeshProUGUI>();
        p2score = GameObject.Find("highScoreScore2").GetComponent<TextMeshProUGUI>();
        p3score = GameObject.Find("highScoreScore3").GetComponent<TextMeshProUGUI>();
        p4score = GameObject.Find("highScoreScore4").GetComponent<TextMeshProUGUI>();
        p5score = GameObject.Find("highScoreScore5").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        SetLeaderBoard();
    }

    public void SetLeaderBoard()
    {
        //SortLeaderBoard();
        
        p1name.text = dataPersistenceScript.Instance.leaderboardP1name;
        p1score.text = dataPersistenceScript.Instance.leaderboardP1score.ToString();

        p2name.text = dataPersistenceScript.Instance.leaderboardP2name;
        p2score.text = dataPersistenceScript.Instance.leaderboardP2score.ToString();

        p3name.text = dataPersistenceScript.Instance.leaderboardP3name;
        p3score.text = dataPersistenceScript.Instance.leaderboardP3score.ToString();

        p4name.text = dataPersistenceScript.Instance.leaderboardP4name;
        p4score.text = dataPersistenceScript.Instance.leaderboardP4score.ToString();

        p5name.text = dataPersistenceScript.Instance.leaderboardP5name;
        p5score.text = dataPersistenceScript.Instance.leaderboardP5score.ToString();
    }

    /*
    public void SortLeaderBoard()
    {
        int temp;
        string temp2;
        for(int j = 0; j < dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray.Length; j++)
        {
            for(int i = 0; i < dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray.Length-1; i++)
            {
                if(dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray[i] > dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray[i + 1])
                {
                    temp = dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray[i + 1];
                    dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray[i + 1] = dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray[i];
                    dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray[i] = temp;

                    temp2 = dataPersistenceScript.Instance.leaderboardP1thruP5NameArray[i + 1];
                    dataPersistenceScript.Instance.leaderboardP1thruP5NameArray[i + 1] = dataPersistenceScript.Instance.leaderboardP1thruP5NameArray[i];
                    dataPersistenceScript.Instance.leaderboardP1thruP5NameArray[i] = temp2;
                }
            }
        }
    }
    */
}
