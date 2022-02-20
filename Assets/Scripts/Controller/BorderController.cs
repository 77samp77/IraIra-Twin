using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : MonoBehaviour
{
    GameObject wallGenerator;
    WallGenerator wgScript;

    float fs;
    GameObject gameManager;
    GameManagerScript gms;

    GameObject tutorialManager;
    TutorialManager tms;

    int gameMode, level;

    // Start is called before the first frame update
    void Start()
    {
        wallGenerator = GameObject.Find("WallGenerator");
        wgScript = wallGenerator.GetComponent<WallGenerator>();

        gameManager = GameObject.Find("GameManager");
        gms = gameManager.GetComponent<GameManagerScript>();
        fs = gms.fs;

        gameMode = GameManagerScript.gameMode;
        level = GameManagerScript.level;

        if(gameMode == 2)
        {
            tutorialManager = GameObject.Find("TutorialManager");
            tms = tutorialManager.GetComponent<TutorialManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gms.isStop) return;

        transform.Translate(0, -fs, 0);
        if(transform.position.y < Screen.height / 2)
        {
            switch(gameMode)
            {
                case 0:
                    wgScript.GenMap(gms.map[level - 1][gms.mNum]);
                    break;
                case 1:
                    int map = Random.Range(0, wgScript.mapSize);
                    while(map == gms.lastMap) map = Random.Range(0, wgScript.mapSize);
                    wgScript.GenMap(map);
                    gms.lastMap = map;
                    gms.efs = (float)gms.mNum / 50 + 1;
                    gms.fs = gms.pfs * gms.efs;
                    Debug.Log(gms.fs);
                    break;
                case 2:
                    if(tms.progress == 3) wgScript.GenMap(-1);
                    else wgScript.GenMap(0);
                    break;
            }
            gms.mNum++;

            Destroy(gameObject);
        }
    }
}