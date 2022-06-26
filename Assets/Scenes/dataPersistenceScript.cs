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

    public string nameofcurrentplayer;
    public int currentscore;

    public string highestscorename;
    public int highestscore;

    public string leaderboardP1name;
    public string leaderboardP2name;
    public string leaderboardP3name;
    public string leaderboardP4name;
    public string leaderboardP5name;

    public int leaderboardP1score;
    public int leaderboardP2score;
    public int leaderboardP3score;
    public int leaderboardP4score;
    public int leaderboardP5score;

    public int[] leaderboardP1thruP5ScoreArray = new int[5];
    public string[] leaderboardP1thruP5NameArray = new string[5];

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSaveData();
    }

    [System.Serializable]
    class SaveData
    {
        public int highestscore;
        public string highestscorename;

        public string leaderboardP1name;
        public string leaderboardP2name;
        public string leaderboardP3name;
        public string leaderboardP4name;
        public string leaderboardP5name;

        public int leaderboardP1score;
        public int leaderboardP2score;
        public int leaderboardP3score;
        public int leaderboardP4score;
        public int leaderboardP5score;

    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.highestscore = highestscore;
        data.highestscorename = highestscorename;

        //all leader board names and scores
        data.leaderboardP1name = leaderboardP1name;
        data.leaderboardP1score = leaderboardP1score;
        
        data.leaderboardP2name = leaderboardP2name;
        data.leaderboardP2score = leaderboardP2score;

        data.leaderboardP3name = leaderboardP3name;
        data.leaderboardP3score = leaderboardP3score;

        data.leaderboardP4name = leaderboardP4name;
        data.leaderboardP4score = leaderboardP4score;

        data.leaderboardP5name = leaderboardP5name;
        data.leaderboardP5score = leaderboardP5score;
        //end of leader board names and scores


        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadSaveData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highestscore = data.highestscore;
            highestscorename = data.highestscorename;

            leaderboardP1name = data.leaderboardP1name;
            leaderboardP1score = data.leaderboardP1score;
            leaderboardP2name = data.leaderboardP2name;
            leaderboardP2score = data.leaderboardP2score;
            leaderboardP3name = data.leaderboardP3name;
            leaderboardP3score = data.leaderboardP3score;
            leaderboardP4name = data.leaderboardP4name;
            leaderboardP4score = data.leaderboardP4score;
            leaderboardP5name = data.leaderboardP5name;
            leaderboardP5score = data.leaderboardP5score;

            //array of scores for leaderboard
            leaderboardP1thruP5ScoreArray[4] = leaderboardP1score;
            leaderboardP1thruP5ScoreArray[3] = leaderboardP2score;
            leaderboardP1thruP5ScoreArray[2] = leaderboardP3score;
            leaderboardP1thruP5ScoreArray[1] = leaderboardP4score;
            leaderboardP1thruP5ScoreArray[0] = leaderboardP5score;

            //array of names for leaderboard
            leaderboardP1thruP5NameArray[4] = leaderboardP1name;
            leaderboardP1thruP5NameArray[3] = leaderboardP2name;
            leaderboardP1thruP5NameArray[2] = leaderboardP3name;
            leaderboardP1thruP5NameArray[1] = leaderboardP4name;
            leaderboardP1thruP5NameArray[0] = leaderboardP5name;
        }
    }

    public void DeleteJsonFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        File.Delete(path);
    }
}
