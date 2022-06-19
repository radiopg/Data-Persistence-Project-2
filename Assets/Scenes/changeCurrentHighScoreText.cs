using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class changeCurrentHighScoreText : MonoBehaviour
{
    public Text nameandscore;
    //public int score_here;

    // Start is called before the first frame update
    void Start()
    {
        //score_here = GameObject.Find("currentHighScore").GetComponent<int>();
        //nameandscore.text = "Best Score: " + dataPersistenceScript.Instance.nameofplayerToRetain + ": " + score_here;
    }

    // Update is called once per frame
    void Update()
    {
        nameandscore.text = "Best Score: " + dataPersistenceScript.Instance.nameofplayerToRetain + ": " + dataPersistenceScript.Instance.score;
    }


}
