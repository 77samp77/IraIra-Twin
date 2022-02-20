using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    GameObject gameManager;
    GameManagerScript gms;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if(Input.GetKey(KeyCode.Escape)) SceneManager.LoadScene("Title");
        }
    }

    public void OnClick()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            gameManager = GameObject.Find("GameManager");
            gms = gameManager.GetComponent<GameManagerScript>();
            gms.Reset();
        }

        SceneManager.LoadScene("Title");
    }
}
