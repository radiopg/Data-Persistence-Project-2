using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoardScript : MonoBehaviour
{
    public TextMeshProUGUI p1name;
    public TextMeshProUGUI p2name;
    public TextMeshProUGUI p3name;
    public TextMeshProUGUI p4name;
    public TextMeshProUGUI p5name;

    public int p1score;
    public int p2score;
    public int p3score;
    public int p4score;
    public int p5score;

    public TextMeshProUGUI p1scoreText;
    public TextMeshProUGUI p2scoreText;
    public TextMeshProUGUI p3scoreText;
    public TextMeshProUGUI p4scoreText;
    public TextMeshProUGUI p5scoreText;

    public string[] listofplayernames = new string[5];
    public int[] listofplayerscores = new int[5];

    // Start is called before the first frame update
    void Awake()
    {
        p1name = GameObject.Find("P1Name").GetComponent<TextMeshProUGUI>();
        p2name = GameObject.Find("P2Name").GetComponent<TextMeshProUGUI>();
        p3name = GameObject.Find("P3Name").GetComponent<TextMeshProUGUI>();
        p4name = GameObject.Find("P4Name").GetComponent<TextMeshProUGUI>();
        p5name = GameObject.Find("P5Name").GetComponent<TextMeshProUGUI>();

        p1score = dataPersistenceScript.Instance.p1HighScore;
        p2score = dataPersistenceScript.Instance.p2HighScore;
        p3score = dataPersistenceScript.Instance.p3HighScore;
        p4score = dataPersistenceScript.Instance.p4HighScore;
        p5score = dataPersistenceScript.Instance.p5HighScore;

        p1scoreText = GameObject.Find("P1Score").GetComponent<TextMeshProUGUI>();
        p2scoreText = GameObject.Find("P2Score").GetComponent<TextMeshProUGUI>();
        p3scoreText = GameObject.Find("P3Score").GetComponent<TextMeshProUGUI>();
        p4scoreText = GameObject.Find("P4Score").GetComponent<TextMeshProUGUI>();
        p5scoreText = GameObject.Find("P5Score").GetComponent<TextMeshProUGUI>();


        SetLeaderBoardArrays();
        ChangeLeaderBoard();
        ShowLeaderBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLeaderBoard()
    {
        Debug.Log("SHOW LEADER BOARD METHOD ENTERED");
        dataPersistenceScript.Instance.LoadSavedData();
        Sort();

        p1name.text = dataPersistenceScript.Instance.highScoreP1Name;
        p2name.text = dataPersistenceScript.Instance.highScoreP2Name;
        p3name.text = dataPersistenceScript.Instance.highScoreP3Name;
        p4name.text = dataPersistenceScript.Instance.highScoreP4Name;
        p5name.text = dataPersistenceScript.Instance.highScoreP5Name;

        p1score = dataPersistenceScript.Instance.p1HighScore;
        p2score = dataPersistenceScript.Instance.p2HighScore;
        p3score = dataPersistenceScript.Instance.p3HighScore;
        p4score = dataPersistenceScript.Instance.p4HighScore;
        p5score = dataPersistenceScript.Instance.p5HighScore;

        p1scoreText.text = dataPersistenceScript.Instance.p1HighScore.ToString();
        p2scoreText.text = dataPersistenceScript.Instance.p2HighScore.ToString();
        p3scoreText.text = dataPersistenceScript.Instance.p3HighScore.ToString();
        p4scoreText.text = dataPersistenceScript.Instance.p4HighScore.ToString();
        p5scoreText.text = dataPersistenceScript.Instance.p5HighScore.ToString();
    }

    public void ChangeLeaderBoard()
    {
        Debug.Log("CHANGE LEADER BOARD METHOD ENTERED");
        Debug.Log("This is the current score: " + dataPersistenceScript.Instance.score + " This is the lowest score: " + dataPersistenceScript.Instance.lowestscore);
        Sort();
        

        dataPersistenceScript.Instance.SaveHighestNameAndScore();
    }

    public void Sort()
    {
        Debug.Log("SORT METHOD ENTERED");


        for(int i = 0; i < listofplayerscores.Length; i++)
        {
            int minPos = minimumPosition(i);
            swap(minPos, i);
        }



        p1name.text = listofplayernames[4];
        p1score = listofplayerscores[4];
        p2name.text = listofplayernames[3];
        p2score = listofplayerscores[3];
        p3name.text = listofplayernames[2];
        p3score = listofplayerscores[2];
        p4name.text = listofplayernames[1];
        p4score = listofplayerscores[1];
        p5name.text = listofplayernames[0];
        p5score = listofplayerscores[0];
    }

    private int minimumPosition(int from)
    {
        int minPos = from;
        for(int i = from+1; i < listofplayerscores.Length; i++)
        {
            if (listofplayerscores[i] < listofplayerscores[minPos])
            {
                minPos = i;
            }
        }
        return minPos;
    }

    private void swap(int i, int j)
    {
        int temp = listofplayerscores[i];
        listofplayerscores[i] = listofplayerscores[j];
        listofplayerscores[j] = temp;

        string temp2 = listofplayernames[i];
        listofplayernames[i] = listofplayernames[j];
        listofplayernames[j] = temp2;
    }

    public void SetLeaderBoardArrays()
    {
        Debug.Log("LEADER BOARD ARRAYS SET METHOD ENTERED");
        listofplayernames[4] = "Bill";
        listofplayernames[3] = "Joe";
        listofplayernames[2] = "Scott";
        listofplayernames[1] = "Rodney";
        listofplayernames[0] = "William";

        listofplayerscores[4] = 5;
        listofplayerscores[3] = 4;
        listofplayerscores[2] = 3;
        listofplayerscores[1] = 2;
        listofplayerscores[0] = 1;
    }
}
