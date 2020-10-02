using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{
    bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<PlayerMovement>()!=null && !activated)
        {
            GameManager.managerInstance.SetEndingText("Game over\nClick to restart");
            SceneManager.LoadScene(2);
            activated = true;
        }

    }
}
