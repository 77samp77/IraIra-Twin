using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public static int gameMode; // 0...クラシック    1...ランダム(ENDLESS)    2...チュートリアル
    public static int level;    // クラシックの時のレベル
    public float efs = 1;    // ランダムモードの相対落下速度

    public GameObject gameOverUIPrefab;
    public GameObject gameOverUIInstance;
    public bool isGameOver = false;

    public GameObject highScore;
    ScoreManager hss;

    public GameObject clearUIPrefab;

    public GameObject pauseUIPrefab;
    public GameObject pauseUIInstance;
    public bool isPaused = false;
    
    public float pfs, fs;

    public GameObject clearUIInstance;
    public bool isClear = false;

    public bool isStarted = false;
    
    public GameObject player1;
    public GameObject player2;
    public GameObject startPoint1;
    public GameObject startPoint2;

    GameObject timeObject;
    TextMeshProUGUI timeText;
    TimeManager tms;

    public bool isStop;

    public int lastMap;

    public int[][] map =
    {
        new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, -1},             // level1
        new[] {10, 11, 12, 13, 14, 15, 16, 17, 18, 19, -1},   // level2
        new[] {20, 21, 22, 23, 24, 25, 26, 27, 28, 29, -1},   // level3
        new[] {30, 31, 32, 33, 34, 35, 36, 37, 38, 39, -1},   // level4
        new[] {40, 41, 42, 43, 44, 45, 46, 47, 48, 49, -1}    // level5
    };
    public int mNum = 0;    // 通過したマップ数

    void Awake()
    {
        pfs = fs = 4;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject line = GameObject.Find("Line");
        line.transform.localScale = new Vector3(10, Screen.height, 1);

        if(gameMode == 1)
        {
            timeObject = GameObject.Find("Time");
            timeText = timeObject.GetComponent<TextMeshProUGUI>();
            tms = timeObject.GetComponent<TimeManager>();

            highScore = GameObject.Find("HighScore");
            hss = highScore.GetComponent<ScoreManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if(Input.GetKey(KeyCode.Escape) && (!isPaused && !isGameOver && !isClear)) Pause();
        }
    }

    public void Pause()
    {
        pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
        if(gameMode != 0) DeleteSLButton();
        isStop = true;
        isPaused = true;
    }

    GameObject time2Object;
    TextMeshProUGUI time2Text;
    GameObject highScore2;
    TextMeshProUGUI highScore2Text;

    public void GameOver()
    {
        if(gameMode == 1 && tms.sumTime > ScoreManager.hs) hss.SetHighScore();
        else InsGameOverPrefab();
        isStop = true;
        isGameOver = true;
    }

    public void InsGameOverPrefab()
    {
        gameOverUIInstance = GameObject.Instantiate(gameOverUIPrefab) as GameObject;
        if(gameMode != 0) DeleteSLButton();

        time2Object = GameObject.Find("Time2");
        highScore2 = GameObject.Find("HighScore2");
        if(gameMode != 1) DeleteScores();
        else
        {
            time2Text = time2Object.GetComponent<TextMeshProUGUI>();
            time2Text.text = timeText.text;

            highScore2Text = highScore2.GetComponent<TextMeshProUGUI>();
            highScore2Text.text = ScoreManager.hs.ToString("F2");
        }
    }

    void DeleteSLButton()
    {
        GameObject slButton = GameObject.Find("SelectLevelButton");
        Destroy(slButton);
        GameObject tButton = GameObject.Find("TitleButton");
        tButton.transform.Translate(0, 200, 0);
    }

    void DeleteScores()
    {
        Destroy(time2Object);
        Destroy(highScore2);

        GameObject rButton = GameObject.Find("RetryButton");
        rButton.transform.Translate(0, 150, 0);
        GameObject slButton = GameObject.Find("SelectLevelButton");
        slButton.transform.Translate(0, 150, 0);
        GameObject tButton = GameObject.Find("TitleButton");
        tButton.transform.Translate(0, 150, 0);
    }

    void DeleteRButton()
    {
        GameObject rButton = GameObject.Find("RetryButton");
        Destroy(rButton);
        if(gameMode != 2)
        {
            GameObject tButton = GameObject.Find("TitleButton");
            tButton.transform.Translate(0, 200, 0);
        }
    }

    public void Clear()
    {
        if(gameMode == 0)
        {
            LevelManager.isCleared[level - 1] = true;
            string strget = null;
            for(int n = 0; n < LevelManager.levelSize; n++) strget = strget + LevelManager.isCleared[n].ToString() + ",";
            PlayerPrefs.SetString("ClearData", strget);
        }

        clearUIInstance = GameObject.Instantiate(clearUIPrefab) as GameObject;
        if(gameMode == 2)
        {
            DeleteSLButton();
            DeleteRButton();
        }

        isStop = true;
        isClear = true;
    }

    public void Reset()
    {
        player1.GetComponent<PlayerController>().Reset();
        player2.GetComponent<PlayerController>().Reset();
        startPoint1.GetComponent<StartPointController>().Reset();
        startPoint2.GetComponent<StartPointController>().Reset();

        var obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach(var clone in obstacles) Destroy(clone);
        var borders = GameObject.FindGameObjectsWithTag("Border");
        foreach(var clone in borders) Destroy(clone);
        var goals = GameObject.FindGameObjectsWithTag("Goal");
        foreach(var clone in goals) Destroy(clone);

        isStarted = false;
        if(isPaused)
        {
            isPaused = false;
            Destroy(pauseUIInstance);
        }
        if(isClear)
        {
            isClear = false;
            Destroy(clearUIInstance);
        }
        if(isGameOver)
        {
            isGameOver = false;
            Destroy(gameOverUIInstance);
        }

        mNum = 0;

        if(gameMode == 1)
        {
            if(tms.sumTime > ScoreManager.hs) hss.SetHighScore();
            tms.sumTime = 0;
            timeText.text = tms.sumTime.ToString("F2");
        }

        isStop = false;
    }
}