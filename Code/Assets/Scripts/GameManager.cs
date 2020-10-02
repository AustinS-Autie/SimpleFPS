using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager managerInstance;
    public int score;
    public int coinsRemaining;
    public int targetsRemaining;
    public string endingText;
    // Start is called before the first frame update
    void Start()
    {
        if (managerInstance == null)
        {
            managerInstance = this;
        }

        if (managerInstance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void OnCreate()
    {
        coinsRemaining = 0;
        targetsRemaining = 0;
        score = 0;

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void SetScore(int amount)
    {
        score = amount;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetCoinsRemaining()
    {
        return coinsRemaining;
    }

    public void AddCoinsRemaining(int amount)
    {
        coinsRemaining += amount;
    }

    public void ReduceTargetCount(int val)
    {
        targetsRemaining -= val;

        if (targetsRemaining <= 0)
        {
            endingText = "Congratulations, you win!\nClick to restart";
            targetsRemaining = 3;
            SceneManager.LoadScene(2);
            
        }
    }

    public int GetTargetsRemaining()
    {
        return targetsRemaining;
    }

    public string GetEndingText()
    {
        return endingText;
    }

    public void SetEndingText(string str)
    {
        endingText = str;
    }


}
