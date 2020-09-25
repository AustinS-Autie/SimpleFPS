using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour
{

    public Text buttonText;
    string showPlayer;
    // Start is called before the first frame update
    void Start()
    {
        buttonText.text = "TEST";
        //showPlayer = "High Score: " + GameManager.managerInstance.GetScore();

        //buttonText.text = showPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
