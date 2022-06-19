using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class dataPersistenceScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static dataPersistenceScript Instance;

    public string nameofplayerToRetain;
    public int score;

    public string nameofplayerHighest;
    public int scoreHighest;

    public string nameoflowestscore;
    public int lowestscore;


    //data to save for high scores for 5 players
    public string highScoreP1Name;
    public string highScoreP2Name;
    public string highScoreP3Name;
    public string highScoreP4Name;
    public string highScoreP5Name;

    public int p1HighScore;
    public int p2HighScore;
    public int p3HighScore;
    public int p4HighScore;
    public int p5HighScore;
    //end of data to save for high scores for 5 players

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSavedData();
    }

    [System.Serializable]
    class SaveData
    {
        public string nameofplayerHighest;
        public int scoreHighest;

        public string nameoflowestscore;
        public int lowestscore;

        public string highScoreP1Name;
        public string highScoreP2Name;
        public string highScoreP3Name;
        public string highScoreP4Name;
        public string highScoreP5Name;

        public int p1HighScore;
        public int p2HighScore;
        public int p3HighScore;
        public int p4HighScore;
        public int p5HighScore;
    }

    public void SaveHighestNameAndScore()
    {
        SaveData data = new SaveData();
        data.nameofplayerHighest = nameofplayerHighest;
        data.scoreHighest = scoreHighest;

        data.nameoflowestscore = nameoflowestscore;
        data.lowestscore = lowestscore;

        data.highScoreP1Name = highScoreP1Name;
        data.highScoreP2Name = highScoreP2Name;
        data.highScoreP3Name = highScoreP3Name;
        data.highScoreP4Name = highScoreP4Name;
        data.highScoreP5Name = highScoreP5Name;
        data.p1HighScore = p1HighScore;
        data.p2HighScore = p2HighScore;
        data.p3HighScore = p3HighScore;
        data.p4HighScore = p4HighScore;
        data.p5HighScore = p5HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadSavedData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nameofplayerHighest = data.nameofplayerHighest;
            scoreHighest = data.scoreHighest;

            nameoflowestscore = data.nameoflowestscore;
            lowestscore = data.lowestscore;

            highScoreP1Name = data.highScoreP1Name;
            highScoreP2Name = data.highScoreP2Name;
            highScoreP3Name = data.highScoreP3Name;
            highScoreP4Name = data.highScoreP4Name;
            highScoreP5Name = data.highScoreP5Name;
            p1HighScore = data.p1HighScore;
            p2HighScore = data.p2HighScore;
            p3HighScore = data.p3HighScore;
            p4HighScore = data.p4HighScore;
            p5HighScore = data.p5HighScore;
        }
        
    }

    public void DeleteJsonFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        File.Delete(path);
    }
}
