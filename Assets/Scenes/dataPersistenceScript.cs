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

    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.highestscore = highestscore;
        data.highestscorename = highestscorename;

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
        }
    }

    public void DeleteJsonFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        File.Delete(path);
    }
}
