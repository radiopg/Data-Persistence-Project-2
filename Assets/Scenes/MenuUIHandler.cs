using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{

    public string playername;
    public int scor_e;

    public TextMeshProUGUI nameofplayer;

    // Start is called before the first frame update
    void Start()
    {
        nameofplayer = GameObject.Find("PlayerNameText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void SetName()
    {
        dataPersistenceScript.Instance.nameofplayerToRetain = nameofplayer.text;
    }

    public void SetScore()
    {
        dataPersistenceScript.Instance.score = scor_e;
    }
}
