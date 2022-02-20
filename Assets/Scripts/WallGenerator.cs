using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject borderPrefab;
    public GameObject wallPrefab;
    public GameObject circlePrefab;
    public GameObject goalPrefab;

    int gameMode;

    // Start is called before the first frame update
    void Start()
    {
        mapSize = 58;
        gameMode = GameManagerScript.gameMode;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void GenBorder(int y)
    {
        y += Screen.height / 2;
        Instantiate(borderPrefab, new Vector3(0, y, 0), Quaternion.identity);
    }

    void GenGoal(int y)
    {
        y += Screen.height / 2;
        Instantiate(goalPrefab, new Vector3(0, y, 0), Quaternion.identity);
    }


    int LR;
    bool isLeft;

    void GenWall(int x, int y, int w, int h, int angle, int pLR)
    {
        if(gameMode == 1)
        {
            LR = Random.Range(0, 5);
            if(LR <= 1) LR = 0;
            else if(LR <= 3) LR = 1;
            else LR = 2;
        }
        else LR = pLR;
        y += Screen.height / 2;

        isLeft = false;
        if(LR == 0)
        {
            x -= 540;
            isLeft = true;
        }
        GameObject obj = Instantiate(wallPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
        obj.transform.localScale = new Vector3(w, h, 1);
        obj.GetComponent<WallController>().FixedInst(angle, isLeft);

        if(LR == 2)
        {
            x -= 540;
            isLeft = true;
            GameObject obj2 = Instantiate(wallPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
            obj2.transform.localScale = new Vector3(w, h, 1);
            obj2.GetComponent<WallController>().FixedInst(angle, isLeft);
        }
    }

    void GenMoveWall(int x, int y, int w, int h, int angle, float vx, float tspeed, int pLR)
    {
        if(gameMode == 1)
        {
            LR = Random.Range(0, 5);
            if(LR <= 1) LR = 0;
            else if(LR <= 3) LR = 1;
            else LR = 2;
        }
        else LR = pLR;
        y += Screen.height / 2;

        isLeft = false;
        if(LR == 0)
        {
            x -= 540;
            isLeft = true;
        }
        GameObject obj = Instantiate(wallPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
        obj.transform.localScale = new Vector3(w, h, 1);
        obj.GetComponent<WallController>().MoveInst(vx, tspeed, angle, isLeft);

        if(LR == 2)
        {
            x -= 540;
            isLeft = true;
            GameObject obj2 = Instantiate(wallPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
            obj2.transform.localScale = new Vector3(w, h, 1);
            obj2.GetComponent<WallController>().MoveInst(vx, tspeed, angle, isLeft);
        }
    }

    void GenCircle(float cx, float cy, int d, int angle, int tr, float tspeed, int pLR)    // angle...最初の角度,　tr...回転半径,　tspeed...回転速度
    {
        if(gameMode == 1)
        {
            LR = Random.Range(0, 5);
            if(LR <= 1) LR = 0;
            else if(LR <= 3) LR = 1;
            else LR = 2;
        }
        else LR = pLR;
        cy += Screen.height / 2;

        if(LR == 0) cx -= 540;
        GameObject obj = Instantiate(circlePrefab, new Vector3(cx, cy, 0), Quaternion.identity) as GameObject;
        obj.transform.localScale = new Vector3(d, d, 1);
        obj.GetComponent<CircleController>().Inst(angle, tr, tspeed);

        if(LR == 2)
        {
            cx -= 540;
            GameObject obj2 = Instantiate(circlePrefab, new Vector3(cx, cy, 0), Quaternion.identity) as GameObject;
            obj2.transform.localScale = new Vector3(d, d, 1);
            obj2.GetComponent<CircleController>().Inst(angle, tr, tspeed);
        }
    }
    

    public int mapSize;

    public void GenMap(int map)
    {
        switch(map)
        {
            case -1:
                GenGoal(100);
                break;
            case 0:
                GenWall(130, 50, 260, 100, 0, 0);
                GenWall(450, 50, 180, 100,  0, 1);
                GenWall(310, 350, 200, 100, 0, 1);
                GenWall(130, 650, 200, 120, 0, 0);
                GenWall(270, 950, 300, 100, 0, 2);
                GenWall(110, 1350, 220, 150, 0, 1);
                GenWall(430, 1350, 220, 150, 0, 0);
                GenBorder(1625);
                break;
            case 1:
                GenWall(110, 50, 220, 100, 0, 1);
                GenWall(330, 50, 220, 100, 0, 0);
                GenWall(80, 650, 160, 100, 0, 0);
                GenWall(320, 550, 100, 300, 0, 1);
                GenWall(490, 550, 100, 300, 0, 1);
                GenWall(405, 550, 120, 100, 0, 0);
                GenWall(180, 925, 200, 150, 0, 2);
                GenWall(200, 1300, 200, 100, 0, 0);
                GenWall(340, 1300, 200, 100, 0, 1);
                GenBorder(1550);
                break;
            case 2:
                GenWall(270, 50, 200, 100, 0, 1);
                GenCircle(270, 400, 120, 0, 190, 1, 0);
                GenWall(270, 750, 200, 100, 0, 1);
                GenBorder(1000);
                break;
            case 3:
                GenWall(130, 50, 260, 100, 0, 0);
                GenWall(450, 100, 180, 200, 0, 1);
                GenWall(130, 200, 260, 200, 0, 1);
                GenWall(450, 250, 180, 100, 0, 0);
                GenWall(400, 500, 280, 100, 0, 0);
                GenWall(70, 580, 140, 260, 0, 0);
                GenWall(450, 750, 180, 400, 0, 1);
                GenWall(120, 830, 240, 240, 0, 1);
                GenBorder(1150);
                break;
            case 4:
                GenWall(350, 50, 200, 100, 0, 2);
                GenWall(200, 300, 200, 100, 0, 1);
                GenWall(470, 300, 140, 100, 0, 0);
                GenWall(60, 600, 120, 100, 0, 0);
                GenWall(360, 730, 120, 80, 0, 0);
                GenWall(160, 910, 100, 100, 0, 0);
                GenWall(480, 1100, 120, 100, 0, 0);
                GenWall(60, 1200, 120, 100, 0, 0);
                GenWall(270, 900, 80, 700, 0, 1);
                GenWall(270, 1500, 300, 100, 0, 1);
                GenBorder(1750);
                break;
            case 5:
                GenWall(135, 150, 270, 300, 0, 0);
                GenWall(335, 100, 130, 200, 0, 1);
                GenWall(60, 650, 120, 700, 0, 1);
                GenWall(405, 650, 270, 200, 0, 0);
                GenWall(470, 825, 140, 150, 0, 1);
                GenWall(135, 1200, 270, 400, 0, 0);
                GenWall(340, 1300, 140, 200, 0, 2);
                GenBorder(1600);
                break;
            case 6:
                GenWall(370, 100, 340, 200, 0, 1);
                GenWall(470, 250, 140, 100, 0, 0);
                GenWall(135, 850, 270, 700, 0, 1);
                GenWall(320, 800, 100, 400, 0, 0);
                GenWall(405, 1450, 270, 100, 0, 1);
                GenBorder(1700);
                break;
            case 7:
                GenWall(270, 200, 100, 400, 0, 1);
                GenWall(490, 200, 100, 200, 0, 0);
                GenWall(160, 900, 100, 600, 0, 1);
                GenWall(55, 1100, 110, 200, 0, 0);
                GenWall(490, 900, 100, 600, 0, 1);
                GenWall(390, 1100, 100, 200, 0, 0);
                GenWall(80, 1550, 160, 300, 0, 2);
                GenWall(490, 1550, 100, 300, 0, 0);
                GenBorder(1900);
                break;
            case 8:
                GenWall(200, 150, 400, 300, 0, 1);
                GenWall(350, 400, 100, 200, 0, 0);
                GenWall(190, 800, 100, 200, 0, 0);
                GenWall(340, 1050, 400, 300, 0, 1);
                GenWall(135, 1450, 270, 100, 0, 1);
                GenBorder(1700);
                break;
            case 9:
                GenWall(130, 50, 100, 100, 0, 0);
                GenWall(410, 170, 100, 100, 0, 1);
                GenWall(190, 320, 100, 100, 0, 0);
                GenWall(460, 480, 100, 100, 0, 1);
                GenWall(80, 570, 100, 100, 0, 0);
                GenWall(290, 800, 100, 100, 0, 1);
                GenWall(130, 1000, 100, 100, 0, 0);
                GenWall(470, 1000, 100, 100, 0, 1);
                GenWall(130, 1160, 100, 100, 0, 0);
                GenWall(340, 1370, 100, 100, 0, 1);
                GenWall(50, 1430, 100, 100, 0, 0);
                GenBorder(1680);
                break;
            case 10:
                GenWall(68, 50, 136, 100, 0, 0);
                GenWall(338, 50, 136, 100, 0, 1);
                GenWall(68, 350, 136, 100, 0, 0);
                GenWall(203, 350, 134, 100, 0, 1);
                GenWall(473, 350, 134, 100, 0, 0);
                GenWall(68, 650, 136, 100, 0, 1);
                GenWall(338, 650, 136, 100, 0, 0);
                GenWall(473, 650, 134, 100, 0, 1);
                GenWall(68, 950, 136, 100, 0, 0);
                GenWall(203, 950, 134, 100, 0, 1);
                GenWall(338, 950, 136, 100, 0, 0);
                GenWall(68, 1250, 136, 100, 0, 1);
                GenWall(338, 1250, 136, 100, 0, 0);
                GenWall(473, 1250, 134, 100, 0, 2);
                GenBorder(1500);
                break;
            case 11:
                GenMoveWall(270, 50, 200, 100, 0, 5, 0, 0);
                GenBorder(300);
                break;
            case 12:
                GenMoveWall(270, 200, 500, 100, 0, 0, 1, 1);
                GenBorder(550);
                break;
            case 13:
                GenWall(100, 50, 200, 100, 0, 1);
                GenWall(440, 50, 200, 100, 0, 1);
                GenCircle(270, 370, 150, 180, 195, 1, 0);
                GenWall(270, 690, 200, 100, 0, 1);
                GenCircle(270, 1010, 150, 0, 195, -2, 0);
                GenWall(100, 1330, 200, 100, 0, 1);
                GenWall(440, 1330, 200, 100, 0, 1);
                GenBorder(1580);
                break;
            case 14:
                GenWall(270, 160, 350, 100, 45, 2);
                GenWall(135, 500, 270, 100, 0, 1);
                GenWall(335, 850, 480, 100, -45, 0);
                GenWall(335, 1125, 480, 100, 45, 1);
                GenWall(210, 1400, 480, 100, 45, 0);
                GenBorder(1810);
                break;
            case 15:
                GenMoveWall(270, 220, 500, 50, 0, 0, 1, 2);
                GenMoveWall(270, 220, 50, 500, 0, 0, 1, 2);
                GenMoveWall(270, 720, 500, 50, 0, 0, -1, 0);
                GenMoveWall(270, 720, 50, 500, 0, 0, -1, 1);
                GenBorder(1200);
                break;
            case 16:
                GenWall(68, 50, 136, 100, 0, 0);
                GenWall(473, 50, 134, 100, 0, 2);
                GenWall(68, 350, 136, 100, 0, 0);
                GenWall(338, 350, 136, 100, 0, 1);
                GenWall(473, 350, 134, 100, 0, 0);
                GenWall(203, 650, 134, 100, 0, 1);
                GenWall(338, 650, 136, 100, 0, 1);
                GenWall(473, 650, 134, 100, 0, 0);
                GenWall(338, 950, 136, 100, 0, 1);
                GenWall(473, 950, 134, 100, 0, 1);
                GenWall(338, 1050, 136, 100, 0, 0);
                GenWall(473, 1050, 134, 100, 0, 0);
                GenWall(68, 1150, 136, 100, 0, 1);
                GenWall(473, 1150, 134, 100, 0, 0);
                GenWall(68, 1250, 136, 100, 0, 0);
                GenWall(473, 1250, 134, 100, 0, 0);
                GenWall(68, 1350, 136, 100, 0, 0);
                GenWall(203, 1350, 134, 100, 0, 1);
                GenWall(68, 1450, 136, 100, 0, 0);
                GenWall(203, 1450, 134, 100, 0, 1);
                GenBorder(1700);
                break;
            case 17:
                GenWall(203, 50, 134, 100, 0, 1);
                GenWall(473, 50, 134, 100, 0, 1);
                GenWall(68, 350, 136, 100, 0, 0);
                GenWall(338, 350, 136, 100, 0, 1);
                GenWall(473, 350, 134, 100, 0, 1);
                GenWall(68, 650, 136, 100, 0, 0);
                GenWall(203, 650, 134, 100, 0, 2);
                GenWall(338, 650, 136, 100, 0, 1);
                GenWall(68, 950, 136, 100, 0, 1);
                GenWall(338, 950, 136, 100, 0, 0);
                GenWall(473, 950, 134, 100, 0, 1);
                GenWall(68, 1250, 136, 100, 0, 1);
                GenWall(203, 1250, 134, 100, 0, 0);
                GenWall(473, 1250, 134, 100, 0, 0);
                GenBorder(1500);
                break;
            case 18:
                GenWall(370, 50, 100, 100, 0, 0);
                GenWall(110, 160, 100, 100, 0, 1);
                GenWall(490, 300, 100, 100, 0, 1);
                GenWall(290, 370, 100, 100, 0, 0);
                GenWall(50, 570, 100, 100, 0, 0);
                GenWall(150, 570, 100, 100, 0, 1);
                GenWall(490, 650, 100, 100, 0, 0);
                GenWall(270, 790, 100, 100, 0, 1);
                GenWall(110, 990, 100, 100, 0, 1);
                GenWall(430, 990, 100, 100, 0, 0);
                GenWall(270, 1200, 100, 100, 0, 1);
                GenWall(490, 1330, 100, 100, 0, 2);
                GenWall(50, 1450, 100, 100, 0, 0);
                GenWall(320, 1450, 100, 100, 0, 1);
                GenBorder(1700);
                break;
            case 19:
                GenWall(490, 50, 100, 100, 0, 0);
                GenWall(50, 150, 100, 100, 0, 1);
                GenWall(390, 250, 100, 100, 0, 0);
                GenWall(150, 350, 100, 100, 0, 0);
                GenWall(270, 550, 100, 100, 0, 1);
                GenWall(50, 750, 100, 100, 0, 1);
                GenWall(490, 850, 100, 100, 0, 0);
                GenWall(150, 950, 100, 100, 0, 1);
                GenWall(390, 1050, 100, 100, 0, 0);
                GenWall(270, 1250, 100, 100, 0, 1);
                GenWall(50, 1450, 100, 100, 0, 0);
                GenWall(490, 1450, 100, 100, 0, 1);
                GenBorder(1700);
                break;
            case 20:
                GenWall(50, 50, 100, 100, 0, 0);
                GenWall(320, 50, 100, 100, 0, 1);
                GenWall(250, 190, 100, 100, 0, 0);
                GenWall(490, 350, 100, 100, 0, 1);
                GenWall(50, 450, 100, 100, 0, 2);
                GenWall(270, 510, 100, 100, 0, 0);
                GenWall(490, 640, 100, 100, 0, 1);
                GenWall(170, 810, 100, 100, 0, 0);
                GenWall(420, 1000, 100, 100, 0, 1);
                GenWall(120, 1100, 100, 100, 0, 2);
                GenWall(370, 1290, 100, 100, 0, 0);
                GenWall(50, 1450, 100, 100, 0, 1);
                GenWall(220, 1450, 100, 100, 0, 0);
                GenBorder(1700);
                break;
            case 21:
                GenWall(50, 50, 100, 100, 0, 0);
                GenWall(150, 50, 100, 100, 0, 1);
                GenWall(250, 150, 100, 100, 0, 1);
                GenWall(350, 150, 100, 100, 0, 0);
                GenWall(490, 350, 100, 100, 0, 1);
                GenWall(390, 450, 100, 100, 0, 0);
                GenWall(150, 550, 100, 100, 0, 0);
                GenWall(250, 650, 100, 100, 0, 1);
                GenWall(50, 850, 100, 100, 0, 1);
                GenWall(390, 850, 100, 100, 0, 0);
                GenWall(490, 950, 100, 100, 0, 1);
                GenWall(250, 1050, 100, 100, 0, 0);
                GenWall(150, 1250, 100, 100, 0, 2);
                GenWall(400, 1250, 100, 100, 0, 0);
                GenWall(270, 1450, 100, 100, 0, 1);
                GenBorder(1700);
                break;
            case 22:
                GenWall(390, 50, 100, 100, 0, 0);
                GenWall(150, 150, 100, 100, 0, 1);
                GenWall(490, 150, 100, 100, 0, 0);
                GenWall(270, 350, 100, 100, 0, 1);
                GenWall(50, 450, 100, 100, 0, 0);
                GenWall(220, 650, 100, 100, 0, 0);
                GenWall(450, 650, 100, 100, 0, 1);
                GenWall(150, 800, 100, 100, 0, 1);
                GenWall(340, 950, 100, 100, 0, 0);
                GenWall(50, 1050, 100, 100, 0, 1);
                GenWall(220, 1250, 100, 100, 0, 0);
                GenWall(490, 1250, 100, 100, 0, 2);
                GenWall(50, 1450, 100, 100, 0, 1);
                GenWall(390, 1450, 100, 100, 0, 0);
                GenWall(490, 1450, 100, 100, 0, 2);
                GenBorder(1700);
                break;
            case 23:
                GenWall(68, 50, 136, 100, 0, 1);
                GenWall(203, 50, 134, 100, 0, 1);
                GenWall(68, 150, 136, 100, 0, 1);
                GenWall(203, 150, 134, 100, 0, 0);
                GenWall(68, 250, 136, 100, 0, 0);
                GenWall(473, 250, 134, 100, 0, 1);
                GenWall(68, 350, 136, 100, 0, 0);
                GenWall(473, 350, 134, 100, 0, 1);
                GenWall(338, 450, 136, 100, 0, 1);
                GenWall(473, 450, 134, 100, 0, 1);
                GenWall(338, 550, 136, 100, 0, 0);
                GenWall(473, 550, 134, 100, 0, 0);
                GenWall(68, 650, 136, 100, 0, 2);
                GenWall(473, 650, 134, 100, 0, 0);
                GenWall(68, 750, 136, 100, 0, 2);
                GenWall(473, 750, 134, 100, 0, 0);
                GenWall(68, 850, 136, 100, 0, 1);
                GenWall(203, 850, 134, 100, 0, 1);
                GenWall(68, 950, 136, 100, 0, 0);
                GenWall(203, 950, 134, 100, 0, 0);
                GenWall(68, 1050, 136, 100, 0, 0);
                GenWall(473, 1050, 134, 100, 0, 1);
                GenWall(68, 1150, 136, 100, 0, 1);
                GenWall(473, 1150, 134, 100, 0, 2);
                GenWall(338, 1250, 136, 100, 0, 1);
                GenWall(473, 1250, 134, 100, 0, 1);
                GenWall(338, 1350, 136, 100, 0, 0);
                GenWall(473, 1350, 134, 100, 0, 0);
                GenBorder(1600);
                break;
            case 24:
                GenWall(68, 50, 136, 100, 0, 0);
                GenWall(338, 50, 136, 100, 0, 0);
                GenMoveWall(100, 250, 200, 100, 0, 5, 0, 1);
                GenWall(203, 450, 134, 100, 0, 0);
                GenMoveWall(270, 650, 200, 100, 0, 5, 0, 1);
                GenWall(68, 850, 136, 100, 0, 0);
                GenWall(473, 850, 134, 100, 0, 0);
                GenMoveWall(440, 1050, 200, 100, 0, 5, 0, 1);
                GenWall(203, 1250, 134, 100, 0, 0);
                GenWall(338, 1250, 136, 100, 0, 0);
                GenBorder(1500);
                break;
            case 25:
                GenWall(68, 50, 136, 100, 0, 1);
                GenWall(473, 50, 134, 100, 0, 1);
                GenMoveWall(100, 350, 200, 100, 0, 5, 0, 0);
                GenMoveWall(440, 650, 200, 100, 0, -5, 0, 0);
                GenWall(270, 850, 270, 100, 0, 1);
                GenMoveWall(65, 1150, 130, 100, 0, 4, 0, 0);
                GenMoveWall(475, 1150, 130, 100, 0, -4, 0, 1);
                GenWall(100, 1450, 200, 100, 0, 1);
                GenWall(440, 1450, 200, 100, 0, 0);
                GenBorder(1700);
                break;
            case 26:
                GenWall(100, 350, 200, 300, 0, 0);
                GenWall(440, 350, 200, 300, 0, 0);
                GenWall(270, 800, 340, 200, 0, 0);
                GenMoveWall(25, 650, 50, 1100, 0, 1.5f, 0, 1);
                GenMoveWall(270, 1350, 200, 100, 0, 5, 0, 1);
                GenBorder(1600);
                break;
            case 27:
                GenMoveWall(270, 320, 50, 450, 0, 0, 1, 2);
                GenCircle(270, 320, 150, 270, 190, 1, 2);
                GenMoveWall(270, 960, 50, 450, 90, 0, -1, 0);
                GenCircle(270, 960, 150, 0, 190, -1, 1);
                GenCircle(270, 960, 150, 180, 190, -1, 1);
                GenMoveWall(270, 1600, 50, 500, 0, 0, 1, 0);
                GenMoveWall(270, 1600, 50, 450, 90, 0, 1, 0);
                GenCircle(270, 1600, 150, 90, 190, 1, 1);
                GenCircle(270, 1600, 150, 270, 190, 1, 1);
                GenBorder(2120);
                break;
            case 28:
                GenCircle(270, 320, 150, 0, 190, 1, 2);
                GenCircle(270, 320, 150, 180, 190, 1, 2);
                GenCircle(270, 960, 150, 90, 190, -1, 1);
                GenCircle(270, 960, 150, 270, 190, -1, 0);
                GenCircle(270, 1600, 150, 0, 190, 1, 1);
                GenCircle(270, 1600, 150, 120, 190, 1, 0);
                GenCircle(270, 1600, 150, 240, 190, 1, 0);
                GenBorder(2120);
                break;
            case 29:
                GenWall(68, 100, 136, 100, 0, 0);
                GenWall(473, 100, 134, 100, 0, 0);
                GenMoveWall(186, 100, 100, 150, 0, 4, 0, 1);
                GenWall(338, 500, 136, 100, 0, 0);
                GenWall(473, 500, 134, 100, 0, 0);
                GenMoveWall(50, 500, 100, 150, 0, 4, 0, 1);
                GenWall(68, 900, 136, 100, 0, 0);
                GenWall(473, 900, 134, 100, 0, 0);
                GenMoveWall(186, 900, 100, 150, 0, 4, 0, 1);
                GenWall(68, 1300, 136, 100, 0, 0);
                GenWall(203, 1300, 134, 100, 0, 0);
                GenMoveWall(320, 1300, 100, 150, 0, 4, 0, 1);
                GenWall(68, 1700, 136, 100, 0, 0);
                GenWall(473, 1700, 134, 100, 0, 0);
                GenMoveWall(186, 1700, 100, 150, 0, 4, 0, 1);
                GenBorder(2000);
                break;
            case 30:
                GenMoveWall(270, 270, 440, 50, 0, 0, 1, 2);
                GenCircle(270, 270, 100, 270, 220, -1, 2);
                GenMoveWall(270, 810, 440, 50, 90, 0, -1, 0);
                GenCircle(270, 810, 100, 0, 220, 1, 1);
                GenCircle(270, 810, 100, 180, 220, 1, 1);
                GenMoveWall(270, 1350, 440, 50, 0, 0, 1, 0);
                GenMoveWall(270, 1350, 440, 50, 90, 0, 1, 0);
                GenCircle(270, 1350, 100, 90, 220, -1, 1);
                GenBorder(1850);
                break;
            case 31:
                GenWall(330, 120, 450, 50, 30, 0);
                GenWall(210, 400, 450, 50, 30, 1);
                GenWall(195, 618, 420, 50, -30, 0);
                GenWall(330, 870, 450, 50, -30, 0);
                GenWall(345, 1088, 420, 50, 30, 1);
                GenWall(210, 1350, 450, 50, 30, 0);
                GenWall(195, 1568, 420, 50, -30, 1);
                GenBorder(1900);
                break;
            case 32:
                GenWall(60, 400, 120, 400, 0, 1);
                GenWall(480, 400, 120, 400, 0, 1);
                GenMoveWall(25, 350, 50, 700, 0, 2, 0, 0);
                GenMoveWall(515, 350, 50, 700, 0, -2, 0, 0);
                GenWall(105, 1200, 210, 200, 0, 1);
                GenWall(435, 1200, 210, 200, 0, 1);
                GenWall(60, 1400, 120, 200, 0, 1);
                GenWall(480, 1400, 120, 200, 0, 1);
                GenWall(270, 1650, 140, 100, 0, 1);
                GenMoveWall(25, 1300, 50, 600, 0, 1, 0, 0);
                GenMoveWall(515, 1300, 50, 600, 0, -1, 0, 0);
                GenBorder(2000);
                break;
            case 33:
                GenWall(270, 270, 230, 100, 0, 0);
                GenCircle(270, 270, 270, 0, 135, 1, 1);
                GenWall(270, 850, 230, 100, 0, 0);
                GenWall(75, 1250, 150, 100, 0, 0);
                GenWall(465, 1250, 150, 100, 0, 0);
                GenCircle(270, 1250, 270, 0, 135, -1, 1);
                GenWall(270, 1650, 230, 100, 0, 0);
                GenBorder(1900);
                break;
            case 34:
                GenCircle(270, 270, 150, 0, 195, 1, 2);
                GenCircle(270, 270, 150, 180, 195, -1, 2);
                GenWall(75, 750, 150, 100, 0, 1);
                GenWall(465, 750, 150, 100, 0, 1);
                GenCircle(270, 1230, 150, 0, 195, -1, 0);
                GenCircle(270, 1230, 150, 180, 195, 1, 1);
                GenWall(270, 1700, 200, 100, 0, 0);
                GenBorder(1950);
                break;
            case 35:
                GenCircle(270, 270, 400, 0, 70, -1, 1);
                GenWall(320, 650, 440, 100, 0, 0);
                GenCircle(170, 870, 100, 0, 120, -1, 1);
                GenCircle(370, 1170, 100, 0, 120, 1, 1);
                GenWall(100, 1160, 200, 100, 0, 0);
                GenCircle(200, 1480, 100, 0, 150, -1, 1);
                GenWall(440, 1750, 200, 100, 0, 0);
                GenBorder(2100);
                break;
            case 36:
                GenCircle(370, 170, 100, 0, 120, -1, 1);
                GenCircle(210, 510, 160, 270, 130, 1, 0);
                GenCircle(330, 510, 160, 90, 130, -1, 1);
                GenCircle(190, 880, 100, 180, 120, -1, 1);
                GenCircle(390, 910, 100, 0, 100, 1, 0);
                GenCircle(390, 1050, 100, 0, 100, -1, 1);
                GenCircle(190, 1240, 120, 0, 130, 1, 2);
                GenCircle(370, 1520, 120, 0, 100, -1, 0);
                GenBorder(1950);
                break;
            case 37:
                GenCircle(270, 330, 180, 0, 180, 1, 1);
                GenCircle(220, 530, 100, 90, 105, -1, 0);
                GenCircle(380, 600, 100, 0, 110, -1, 1);
                GenCircle(270, 895, 190, 180, 175, 1, 1);
                GenCircle(270, 1160, 190, 0, 175, -1, 0);
                GenCircle(150, 1350, 100, 225, 100, 1, 0);
                GenCircle(340, 1490, 200, 0, 100, -1, 1);
                GenBorder(1900);
                break;
            case 38:
                GenWall(270, 800, 50, 1600, 0, 1);
                GenMoveWall(68, 50, 136, 100, 0, 4, 0, 0);
                GenMoveWall(473, 250, 134, 100, 0, -4, 0, 0);
                GenMoveWall(203, 450, 134, 100, 0, 4, 0, 0);
                GenMoveWall(68, 550, 136, 100, 0, 4, 0, 0);
                GenMoveWall(473, 750, 134, 100, 0, -4, 0, 0);
                GenMoveWall(338, 850, 136, 100, 0, -4, 0, 0);
                GenMoveWall(203, 950, 134, 100, 0, -4, 0, 0);
                GenMoveWall(68, 1050, 136, 100, 0, -4, 0, 0);
                GenMoveWall(203, 1150, 134, 100, 0, -4, 0, 0);
                GenMoveWall(68, 1450, 136, 100, 0, 4, 0, 0);
                GenMoveWall(473, 1450, 134, 100, 0, 4, 0, 0);
                GenBorder(1800);
                break;
            case 39:
                GenWall(270, 800, 50, 1600, 0, 0);
                GenMoveWall(473, 50, 134, 100, 0, 4, 0, 1);
                GenMoveWall(203, 350, 134, 100, 0, -4, 0, 1);
                GenMoveWall(338, 550, 136, 100, 0, -4, 0, 1);
                GenMoveWall(473, 850, 134, 100, 0, 4, 0, 0);
                GenMoveWall(473, 950, 134, 100, 0, 4, 0, 1);
                GenMoveWall(68, 1250, 136, 100, 0, 4, 0, 1);
                GenMoveWall(68, 1350, 136, 100, 0, 4, 0, 0);
                GenMoveWall(68, 1450, 136, 100, 0, 4, 0, 1);
                GenBorder(1800);
                break;
            case 40:
                GenWall(270, 350, 50, 700, 0, 2);
                GenMoveWall(405, 250, 270, 100, 0, 5, 0, 0);
                GenMoveWall(135, 550, 270, 100, 0, 5, 0, 0);
                GenWall(170, 1250, 50, 700, 0, 1);
                GenWall(370, 1250, 50, 700, 0, 1);
                GenMoveWall(270, 1050, 270, 100, 0, 5, 0, 0);
                GenMoveWall(405, 1450, 270, 100, 0, 5, 0, 0);
                GenBorder(1800);
                break;
            case 41:
                GenWall(25, 350, 50, 700, 0, 0);
                GenWall(270, 350, 50, 700, 0, 0);
                GenWall(515, 350, 50, 700, 0, 0);
                GenMoveWall(405, 250, 270, 100, 0, 5, 0, 1);
                GenMoveWall(135, 550, 270, 100, 0, 5, 0, 1);
                GenWall(270, 1250, 50, 700, 0, 0);
                GenMoveWall(200, 1050, 400, 100, 0, 4, 0, 1);
                GenMoveWall(340, 1450, 400, 100, 0, 4, 0, 1);
                GenBorder(1800);
                break;
            case 42:
                GenWall(200, 50, 400, 100, 0, 0);
                GenWall(375, 450, 50, 700, 0, 1);
                GenWall(165, 850, 50, 700, 0, 1);
                GenWall(340, 1250, 400, 100, 0, 0);
                GenMoveWall(470, 450, 140, 100, 0, 4, 0, 1);
                GenMoveWall(70, 850, 140, 100, 0, 4, 0, 1);
                GenWall(70, 1550, 140, 100, 0, 0);
                GenWall(470, 1550, 140, 100, 0, 0);
                GenBorder(1800);
                break;
            case 43:
                GenWall(370, 800, 340, 1600, 0, 1);
                GenMoveWall(100, 350, 200, 100, 0, 4, 0, 0);
                GenMoveWall(100, 750, 200, 100, 0, 4, 0, 0);
                GenMoveWall(100, 1150, 200, 100, 0, 4, 0, 0);
                GenMoveWall(100, 1550, 200, 100, 0, 4, 0, 0);
                GenWall(70, 1850, 140, 100, 0, 1);
                GenWall(470, 1850, 140, 100, 0, 1);
                GenBorder(2100);
                break;
            case 44:
                GenWall(170, 800, 340, 1600, 0, 0);
                GenMoveWall(100, 350, 200, 100, 0, 4, 0, 1);
                GenMoveWall(270, 750, 200, 100, 0, 4, 0, 1);
                GenMoveWall(170, 1150, 200, 100, 0, 4, 0, 1);
                GenMoveWall(440, 1550, 200, 100, 0, 4, 0, 1);
                GenWall(70, 1850, 140, 100, 0, 0);
                GenWall(470, 1850, 140, 100, 0, 0);
                GenBorder(2100);
                break;
            case 45:
                GenCircle(270, 330, 180, 0, 180, 1, 1);
                GenMoveWall(100, 250, 100, 100, 0, 5, 0, 0);
                GenMoveWall(490, 550, 100, 100, 0, 5, 0, 0);
                GenMoveWall(270, 850, 100, 100, 0, 5, 0, 0);
                GenCircle(270, 895, 190, 180, 175, 1, 1);
                GenCircle(270, 1160, 190, 0, 175, -1, 1);
                GenMoveWall(400, 1150, 100, 100, 0, 5, 0, 0);
                GenMoveWall(50, 1350, 100, 100, 0, 5, 0, 0);
                GenCircle(340, 1490, 200, 0, 100, -1, 1);
                GenBorder(1900);
                break;
            case 46:
                GenWall(68, 100, 136, 100, 0, 0);
                GenWall(338, 100, 136, 100, 0, 0);
                GenWall(473, 100, 134, 100, 0, 0);
                GenMoveWall(186, 100, 100, 150, 0, 4, 0, 1);
                GenWall(68, 500, 136, 100, 0, 0);
                GenWall(203, 500, 134, 100, 0, 0);
                GenWall(338, 500, 136, 100, 0, 0);
                GenMoveWall(50, 500, 100, 150, 0, 4, 0, 1);
                GenWall(68, 900, 136, 100, 0, 0);
                GenWall(338, 900, 136, 100, 0, 0);
                GenWall(473, 900, 134, 100, 0, 0);
                GenMoveWall(186, 900, 100, 150, 0, 4, 0, 1);
                GenWall(203, 1300, 134, 100, 0, 0);
                GenWall(338, 1300, 136, 100, 0, 0);
                GenWall(473, 1300, 134, 100, 0, 0);
                GenMoveWall(320, 1300, 100, 150, 0, 4, 0, 1);
                GenWall(68, 1700, 136, 100, 0, 0);
                GenWall(203, 1700, 134, 100, 0, 0);
                GenWall(473, 1700, 134, 100, 0, 0);
                GenMoveWall(186, 1700, 100, 150, 0, 4, 0, 1);
                GenBorder(2000);
                break;
            case 47:
                GenCircle(270, 330, 180, 0, 180, 1, 0);
                GenWall(60, 400, 120, 400, 0, 1);
                GenWall(480, 400, 120, 400, 0, 1);
                GenCircle(270, 830, 180, 180, 180, -1, 0);
                GenWall(105, 1200, 210, 200, 0, 1);
                GenWall(435, 1200, 210, 200, 0, 1);
                GenWall(60, 1400, 120, 200, 0, 1);
                GenWall(480, 1400, 120, 200, 0, 1);
                GenCircle(270, 1500, 180, 0, 180, 1, 0);
                GenWall(270, 1750, 140, 100, 0, 1);
                GenBorder(2000);
                break;
            case 48:
                GenCircle(270, 270, 340, 0, 0, 0, 1);
                GenCircle(270, 270, 100, 0, 220, -1, 1);
                GenCircle(340, 700, 200, 0, 0, 0, 0);
                GenCircle(340, 700, 100, 180, 150, 2, 0);
                GenCircle(200, 1070, 200, 0, 0, 0, 1);
                GenCircle(200, 1070, 100, 270, 150, -1, 1);
                GenCircle(310, 1430, 80, 0, 0, 0, 0);
                GenCircle(310, 1430, 190, 90, 135, 1, 0);
                GenBorder(1900);
                break;
            case 49:
                GenWall(100, 150, 200, 300, 0, 0);
                GenWall(440, 150, 200, 300, 0, 0);
                GenCircle(270, 480, 100, 0, 130, 2, 1);
                GenCircle(170, 800, 100, 90, 120, -2, 1);
                GenWall(440, 850, 200, 300, 0, 0);
                GenWall(370, 1100, 340, 200, 0, 0);
                GenCircle(150, 1350, 100, 180, 100, -2, 1);
                GenCircle(420, 1370, 100, 0, 75, 2, 1);
                GenWall(170, 1650, 340, 200, 0, 2);
                GenBorder(1900);
                break;
            case 50:
                GenCircle(270, 250, 190, 180, 175, 1, 0);
                GenCircle(270, 500, 190, 0, 175, -1, 1);
                GenCircle(270, 750, 190, 180, 175, 1, 0);
                GenCircle(270, 1000, 190, 0, 175, -1, 1);
                GenCircle(270, 1250, 190, 180, 175, 1, 1);
                GenCircle(270, 1500, 190, 0, 175, -1, 0);
                GenCircle(270, 1750, 190, 180, 175, 1, 0);
                GenCircle(270, 2000, 190, 0, 175, -1, 1);
                GenCircle(270, 2250, 190, 180, 175, 1, 1);
                GenCircle(270, 2500, 190, 0, 175, -1, 0);
                GenBorder(2900);
                break;
            case 51:
                GenCircle(360, 180, 100, 0, 130, 1, 0);
                GenCircle(270, 310, 100, 90, 130, 1, 1);
                GenCircle(180, 440, 100, 180, 130, 1, 2);
                GenCircle(270, 570, 100, 270, 130, 1, 0);
                GenCircle(360, 700, 100, 0, 130, 1, 0);
                GenCircle(270, 830, 100, 90, 130, 1, 1);
                GenCircle(180, 960, 100, 180, 130, 1, 1);
                GenCircle(270, 1090, 100, 270, 130, 1, 0);
                GenCircle(360, 1220, 100, 0, 130, 1, 2);
                GenCircle(270, 1350, 100, 90, 130, 1, 0);
                GenCircle(180, 1480, 100, 180, 130, 1, 1);
                GenCircle(270, 1610, 100, 270, 130, 1, 0);
                GenBorder(1900);
                break;
            case 52:
                GenCircle(270, 270, 180, 0, 180, 1, 0);
                GenCircle(270, 270, 180, 180, 180, 1, 0);
                GenCircle(270, 630, 180, 0, 180, -1, 0);
                GenCircle(270, 630, 180, 180, 180, -1, 0);
                GenCircle(270, 990, 180, 0, 180, 1, 0);
                GenCircle(270, 990, 180, 180, 180, 1, 0);
                GenCircle(270, 1350, 180, 0, 180, -1, 0);
                GenCircle(270, 1350, 180, 180, 180, -1, 0);
                GenBorder(1600);
                break;
            case 53:
                GenCircle(270, 270, 100, 0, 220, 1, 0);
                GenCircle(270, 270, 100, 26, 220, 1, 0);
                GenCircle(270, 270, 100, 52, 220, 1, 0);
                GenCircle(270, 270, 100, 78, 220, 1, 0);
                GenCircle(270, 710, 100, 180, 220, 1, 1);
                GenCircle(270, 710, 100, 206, 220, 1, 0);
                GenCircle(270, 710, 100, 232, 220, 1, 1);
                GenCircle(270, 710, 100, 258, 220, 1, 0);
                GenCircle(270, 1150, 100, -106, 220, 1, 0);
                GenCircle(270, 1150, 100, -78, 220, 1, 0);
                GenCircle(270, 1150, 100, -52, 220, 1, 1);
                GenCircle(270, 1150, 100, -26, 220, 1, 1);
                GenCircle(270, 1150, 100, 0, 220, 1, 0);
                GenCircle(270, 1150, 100, 26, 220, 1, 0);
                GenCircle(270, 1150, 100, 52, 220, 1, 1);
                GenCircle(270, 1150, 100, 78, 220, 1, 1);
                GenBorder(1400);
                break;
            case 54:
                GenCircle(270, 270, 100, 0, 220, 1, 0);
                GenCircle(270, 270, 100, 26, 220, 1, 0);
                GenCircle(270, 270, 100, 52, 220, 1, 0);
                GenCircle(270, 270, 100, 78, 220, 1, 0);
                GenCircle(270, 710, 100, 0, 220, 1, 0);
                GenCircle(270, 710, 100, 26, 220, 1, 0);
                GenCircle(270, 710, 100, 52, 220, 1, 0);
                GenCircle(270, 710, 100, 78, 220, 1, 0);
                GenCircle(270, 710, 100, 180, 220, 1, 1);
                GenCircle(270, 710, 100, 206, 220, 1, 1);
                GenCircle(270, 710, 100, 232, 220, 1, 1);
                GenCircle(270, 710, 100, 258, 220, 1, 1);
                GenCircle(270, 1150, 100, 0, 220, 1, 1);
                GenCircle(270, 1150, 100, 26, 220, 1, 1);
                GenCircle(270, 1150, 100, 52, 220, 1, 1);
                GenCircle(270, 1150, 100, 78, 220, 1, 1);
                GenCircle(270, 1150, 100, 180, 220, 1, 0);
                GenCircle(270, 1150, 100, 206, 220, 1, 0);
                GenCircle(270, 1150, 100, 232, 220, 1, 0);
                GenCircle(270, 1150, 100, 258, 220, 1, 0);
                GenBorder(1400);
                break;
            case 55:
                GenCircle(270, 270, 100, 0, 220, 1, 0);
                GenCircle(270, 270, 100, 26, 220, 1, 0);
                GenCircle(270, 270, 100, 180, 220, 1, 1);
                GenCircle(270, 270, 100, 206, 220, 1, 1);
                GenCircle(270, 710, 100, 0, 220, -1, 1);
                GenCircle(270, 710, 100, 26, 220, -1, 1);
                GenCircle(270, 710, 100, 180, 220, -1, 0);
                GenCircle(270, 710, 100, 206, 220, -1, 0);
                GenCircle(270, 1150, 100, 0, 220, 1, 0);
                GenCircle(270, 1150, 100, 26, 220, 1, 0);
                GenCircle(270, 1150, 100, 120, 220, 1, 2);
                GenCircle(270, 1150, 100, 146, 220, 1, 2);
                GenCircle(270, 1150, 100, 240, 220, 1, 1);
                GenCircle(270, 1150, 100, 266, 220, 1, 1);
                GenCircle(270, 1590, 100, 0, 220, -1, 0);
                GenCircle(270, 1590, 100, 26, 220, -1, 0);
                GenCircle(270, 1590, 100, 120, 220, -1, 1);
                GenCircle(270, 1590, 100, 146, 220, -1, 1);
                GenCircle(270, 1590, 100, 240, 220, -1, 2);
                GenCircle(270, 1590, 100, 266, 220, -1, 2);
                GenBorder(1850);
                break;
            case 56:
                GenCircle(380, 160, 100, 0, 110, 1, 0);
                GenCircle(160, 380, 100, 180, 110, -1, 1);
                GenCircle(380, 600, 100, 0, 110, 1, 0);
                GenCircle(160, 820, 100, 180, 110, -1, 1);
                GenCircle(380, 1040, 100, 0, 110, 1, 0);
                GenCircle(160, 1260, 100, 180, 110, -1, 1);
                GenCircle(380, 1480, 100, 0, 110, 1, 0);
                GenCircle(160, 1700, 100, 180, 110, -1, 1);
                GenBorder(2000);
                break;
            case 57:
                GenCircle(380, 160, 100, 0, 110, 1, 0);
                GenCircle(380, 160, 100, 180, 110, 1, 2);
                GenCircle(160, 380, 100, 0, 110, -1, 1);
                GenCircle(160, 380, 100, 180, 110, -1, 2);
                GenCircle(380, 600, 100, 0, 110, 1, 0);
                GenCircle(380, 600, 100, 180, 110, 1, 2);
                GenCircle(160, 820, 100, 0, 110, -1, 1);
                GenCircle(160, 820, 100, 180, 110, -1, 2);
                GenCircle(380, 1040, 100, 0, 110, 1, 0);
                GenCircle(380, 1040, 100, 180, 110, 1, 2);
                GenCircle(160, 1260, 100, 0, 110, -1, 1);
                GenCircle(160, 1260, 100, 180, 110, -1, 2);
                GenCircle(380, 1480, 100, 0, 110, 1, 0);
                GenCircle(380, 1480, 100, 180, 110, 1, 2);
                GenCircle(160, 1700, 100, 0, 110, -1, 1);
                GenCircle(160, 1700, 100, 180, 110, -1, 2);
                GenBorder(2000);
                break;
            case 58:
                break;
            case 1000:
                GenWall(270, 300, 50, 600, 0, 0);
                GenWall(270, 1200, 50, 600, 0, 0);
                GenWall(270, 2100, 50, 600, 0, 0);
                GenCircle(270, 250, 190, 180, 175, 1, 1);
                GenCircle(270, 500, 190, 0, 175, -1, 1);
                GenCircle(270, 750, 190, 180, 175, 1, 1);
                GenCircle(270, 1000, 190, 0, 175, -1, 1);
                GenCircle(270, 1250, 190, 180, 175, 1, 1);
                GenCircle(270, 1500, 190, 0, 175, -1, 1);
                GenCircle(270, 1750, 190, 180, 175, 1, 1);
                GenCircle(270, 2000, 190, 0, 175, -1, 1);
                GenCircle(270, 2250, 190, 180, 175, 1, 1);
                GenCircle(270, 2500, 190, 0, 175, -1, 1);
                GenBorder(2900);
                break;
            case 1001:
                GenWall(25, 1350, 50, 2700, 0, 0);
                GenWall(515, 1350, 50, 2700, 0, 0);
                GenCircle(270, 250, 190, 180, 175, 1, 1);
                GenCircle(270, 500, 190, 0, 175, -1, 1);
                GenCircle(270, 750, 190, 180, 175, 1, 1);
                GenCircle(270, 1000, 190, 0, 175, -1, 1);
                GenCircle(270, 1250, 190, 180, 175, 1, 1);
                GenCircle(270, 1500, 190, 0, 175, -1, 1);
                GenCircle(270, 1750, 190, 180, 175, 1, 1);
                GenCircle(270, 2000, 190, 0, 175, -1, 1);
                GenCircle(270, 2250, 190, 180, 175, 1, 1);
                GenCircle(270, 2500, 190, 0, 175, -1, 1);
                GenBorder(2900);
                break;
            case 1002:
                GenCircle(270, 270, 180, 0, 180, 1, 0);
                GenCircle(270, 270, 180, 180, 180, 1, 0);
                GenCircle(270, 270, 180, 0, 0, 0, 1);
                GenCircle(270, 630, 180, 0, 180, -1, 0);
                GenCircle(270, 630, 180, 180, 180, -1, 0);
                GenCircle(270, 630, 180, 0, 0, 0, 1);
                GenCircle(270, 990, 180, 0, 180, 1, 0);
                GenCircle(270, 990, 180, 180, 180, 1, 0);
                GenCircle(270, 990, 180, 0, 0, 0, 1);
                GenCircle(270, 1350, 180, 0, 180, -1, 0);
                GenCircle(270, 1350, 180, 180, 180, -1, 0);
                GenCircle(270, 1350, 180, 0, 0, 0, 1);
                GenBorder(1600);
                break;
        }
    }
}