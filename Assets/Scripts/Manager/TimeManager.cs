using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    TextMeshProUGUI timeText;
    public float sumTime;
    float pTime, lastTime;
    bool canCount;

    public static float hs;
    bool changeColor;

    public GameObject gameManager;
    GameManagerScript gms;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        hs = PlayerPrefs.GetFloat("HIGHSCORE", 0);

        gms = gameManager.GetComponent<GameManagerScript>();
        if(GameManagerScript.gameMode != 1)
        {
            gameObject.SetActive(false);
            return;
        }

        sumTime = 0;
        canCount = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gms.isStarted && changeColor)
        {
            timeText.color = Color.white;
            changeColor = false;
            hs = PlayerPrefs.GetFloat("HIGHSCORE", 0);
        }
        pTime = Time.time;
        if(gms.isStarted && canCount && !gms.isStop)
        {
            sumTime += pTime - lastTime;
            if(!changeColor && sumTime > hs)
            {
                timeText.color = Color.yellow;
                changeColor = true;
            }
            timeText.text = sumTime.ToString("F2");
        }
        lastTime = pTime;
        if(!canCount) canCount = true;
    }
}
