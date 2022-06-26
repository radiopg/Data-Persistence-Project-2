using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    //added by  me
    public mainUIHandler otherScript;
    public bool sortdone = false;
    //end added by me

    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        //added by  me
        otherScript = GameObject.Find("MainUIHandlerObject").GetComponent<mainUIHandler>();
        //end added by me

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if ((dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray[0] < m_Points) && !sortdone)
            {
                dataPersistenceScript.Instance.leaderboardP1thruP5NameArray[0] = dataPersistenceScript.Instance.nameofcurrentplayer;
                dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray[0] = dataPersistenceScript.Instance.currentscore;
                SortLeaderBoard();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                sortdone = false;
                dataPersistenceScript.Instance.currentscore = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {

                dataPersistenceScript.Instance.nameofcurrentplayer = "";
                dataPersistenceScript.Instance.currentscore = 0;
                SceneManager.LoadScene(0);
            }
        }

        //code added by me
        dataPersistenceScript.Instance.currentscore = m_Points;
        otherScript.ChangeHighScoreText();

        if(m_Points > dataPersistenceScript.Instance.highestscore)
        {
            otherScript.SetHighestScoreWithName();
            
        }
        //end of code added by me
        
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);

        //code added by me
        
        dataPersistenceScript.Instance.Save();
        dataPersistenceScript.Instance.LoadSaveData();
        //end of code added by me
    }

    public void SortLeaderBoard()
    {
        int temp;
        string temp2;
        for (int j = 0; j < dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray.Length; j++)
        {
            for (int i = 0; i < dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray.Length - 1; i++)
            {
                if (dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray[i] > dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray[i + 1])
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

        dataPersistenceScript.Instance.leaderboardP1name = dataPersistenceScript.Instance.leaderboardP1thruP5NameArray[4];
        dataPersistenceScript.Instance.leaderboardP2name = dataPersistenceScript.Instance.leaderboardP1thruP5NameArray[3];
        dataPersistenceScript.Instance.leaderboardP3name = dataPersistenceScript.Instance.leaderboardP1thruP5NameArray[2];
        dataPersistenceScript.Instance.leaderboardP4name = dataPersistenceScript.Instance.leaderboardP1thruP5NameArray[1];
        dataPersistenceScript.Instance.leaderboardP5name = dataPersistenceScript.Instance.leaderboardP1thruP5NameArray[0];

        dataPersistenceScript.Instance.leaderboardP1score = dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray[4];
        dataPersistenceScript.Instance.leaderboardP2score = dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray[3];
        dataPersistenceScript.Instance.leaderboardP3score = dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray[2];
        dataPersistenceScript.Instance.leaderboardP4score = dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray[1];
        dataPersistenceScript.Instance.leaderboardP5score = dataPersistenceScript.Instance.leaderboardP1thruP5ScoreArray[0];

        sortdone = true;
    }


}
