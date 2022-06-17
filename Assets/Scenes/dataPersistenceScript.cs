using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataPersistenceScript : MonoBehaviour
{
    public static dataPersistenceScript Instance;

    public string playername;
    public int score;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


}
