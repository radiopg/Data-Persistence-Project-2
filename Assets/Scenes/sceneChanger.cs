using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class sceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ViewHighScores()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        dataPersistenceScript.Instance.nameofcurrentplayer = "";
        dataPersistenceScript.Instance.currentscore = 0;
        SceneManager.LoadScene(0);
    }

    public void ClearHighScores()
    {
        dataPersistenceScript.Instance.leaderboardP1name = "";
        dataPersistenceScript.Instance.leaderboardP1score = 0;
        dataPersistenceScript.Instance.leaderboardP2name = "";
        dataPersistenceScript.Instance.leaderboardP2score = 0;
        dataPersistenceScript.Instance.leaderboardP3name = "";
        dataPersistenceScript.Instance.leaderboardP3score = 0;
        dataPersistenceScript.Instance.leaderboardP4name = "";
        dataPersistenceScript.Instance.leaderboardP4score = 0;
        dataPersistenceScript.Instance.leaderboardP5name = "";
        dataPersistenceScript.Instance.leaderboardP5score = 0;

        dataPersistenceScript.Instance.DeleteJsonFile();
        dataPersistenceScript.Instance.highestscorename = "";
        dataPersistenceScript.Instance.highestscore = 0;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }
}
