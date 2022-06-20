using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class menuUIHandler : MonoBehaviour
{

    public TextMeshProUGUI input;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentPlayerName()
    {
        dataPersistenceScript.Instance.nameofcurrentplayer = input.text;
    }

    //maybe remove this later
    public void KeepNameInTextInput()
    {
        input.text = dataPersistenceScript.Instance.nameofcurrentplayer;
    }
}
