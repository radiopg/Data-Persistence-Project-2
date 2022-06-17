using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSavedName(string nameofplayer)
    {
        dataPersistenceScript.Instance.playername = nameofplayer;
    }

    public void SetScore(int scorehere)
    {
        dataPersistenceScript.Instance.score = scorehere;
    }

}
