using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UseButton : MonoBehaviour
{

    public Text buttonText;
    public Button myButton;
    // Start is called before the first frame update
    void Start()
    {
     if(SceneManager.GetActiveScene().buildIndex==2)
        {
        Cursor.lockState = CursorLockMode.None;
        buttonText.text = GameManager.managerInstance.GetEndingText();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        GameManager.managerInstance.SetEndingText("Game over\nClick to restart");
    }

    public void ToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
