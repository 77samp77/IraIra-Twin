using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    TextMeshProUGUI hsText;
    public static float hs;

    public GameObject timeObject;
    TimeManager tms;

    public GameObject gameManager;
    GameManagerScript gms;

    // Start is called before the first frame update
    void Start()
    {
        hsText = GetComponent<TextMeshProUGUI>();
        hs = PlayerPrefs.GetFloat("HIGHSCORE", 0);
        gms = gameManager.GetComponent<GameManagerScript>(); 
        hsText.text = hs.ToString("F2");
        if(GameManagerScript.gameMode != 1)
        {
            gameObject.SetActive(false);
            return;
        }

        tms = timeObject.GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHighScore()
    {
        hs = tms.sumTime;
        PlayerPrefs.SetFloat("HIGHSCORE", hs);
        hsText.text = hs.ToString("F2");
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (hs);
    }
}
