using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    GameObject gameManager;
    GameManagerScript gms;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gms = gameManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        gms.isStop = false;
        gms.isPaused = false;
        Destroy(gms.pauseUIInstance);
    }
}
