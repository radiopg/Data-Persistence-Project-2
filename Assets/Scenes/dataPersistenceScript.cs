using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
