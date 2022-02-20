using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassicButton : MonoBehaviour
{
    GameObject gameManager;
    GameManagerScript gms;
    AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        AS = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            gameManager = GameObject.Find("GameManager");
            gms = gameManager.GetComponent<GameManagerScript>();
            gms.Reset();
        }
        GameManagerScript.gameMode = 0;
        SceneManager.LoadScene("SelectLevel");
    }
}
