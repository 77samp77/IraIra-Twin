using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    float fs;
    GameObject gameManager;
    GameManagerScript gms;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gms = gameManager.GetComponent<GameManagerScript>();
        fs = gms.fs;
    }

    // Update is called once per frame
    void Update()
    {
        if(gms.isStop) return;
        if(transform.position.y > 0) transform.Translate(0, -fs, 0);
    }
}
