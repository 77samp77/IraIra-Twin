using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int px;
    Vector3 scl;

    GameObject gameManager;
    GameManagerScript gms;
    int gameMode;

    Vector3 firstmouse;
    Vector3 premouse;
    Vector3 mouse;
    bool canmove;

    GameObject player1;
    GameObject player2;

    Vector3 pos;
    float fwh;

    void Start()
    {
        Application.targetFrameRate = 60;
        scl = this.transform.lossyScale;

        gameManager = GameObject.Find("GameManager");
        gms = gameManager.GetComponent<GameManagerScript>();
        gameMode = GameManagerScript.gameMode;
        if(gameMode == 2) fwh = 360;
        else fwh = 0;

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        if(gameMode == 2)
        {
            Vector3 temp = transform.position;
            temp.y = 0;
            transform.position = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gms.isStop)
        {
            canmove = false;
            return;
        }
        pos = this.transform.position;

        if(Application.isEditor)
        {
            if(this.gameObject.name == "Player1") EditorMove();
        }
        else
        {
            var touchCount = Input.touchCount;
            var touch = Input.GetTouch(0);
            if(touch.fingerId == 0 && this.gameObject.name == "Player1")
            {
                Move(touch);
            }
        }
                
        if(this.gameObject.name == "Player2") Synchronize();
    }

    void Move(Touch touch)
    {
        if(touch.phase == TouchPhase.Began)
        {
            Vector3 temp = touch.position;
            temp.z = -100;
            firstmouse = Camera.main.ScreenToWorldPoint(temp);
        }
        if(touch.phase == TouchPhase.Moved)
        {
            premouse = mouse;
            Vector3 temp = touch.position;
            temp.z = -100;
            Vector3 temp2 = Camera.main.ScreenToWorldPoint(temp);
            mouse = new Vector3(temp2.x - firstmouse.x, temp2.y - firstmouse.y, -100);

            if(canmove)
            {
                float nx = mouse.x - premouse.x;
                float ny = mouse.y - premouse.y;
                float nx2, ny2;

                if(nx < 0) nx2 = Mathf.Max(-540 + scl.x / 2 + 2, pos.x + nx);
                else nx2 = Mathf.Min(-scl.x / 2 - 2, pos.x + nx);

                if(ny < 0) ny2 = Mathf.Max(-Screen.height / 2 + scl.y / 2 + fwh, pos.y + ny);
                else ny2 = Mathf.Min(Screen.height / 2 - scl.y / 2, pos.y + ny);

                transform.position = new Vector3(nx2, ny2, 0);
            }
            else canmove = true;
        }
        if(touch.phase == TouchPhase.Ended) canmove = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Obstacle" && !gms.isGameOver)
        {
            GetComponent<Renderer>().material.color = Color.red;
            gms.GameOver();
        }
        else if(coll.gameObject.tag == "Goal")
        {
            if(this.gameObject.name == "Player1") gms.Clear();
        }
    }

    void Synchronize()
    {
        Vector3 p1pos = player1.transform.position;
        transform.position = new Vector3(p1pos.x + 540, p1pos.y, p1pos.z);
    }

    public void Reset()
    {
        transform.position = new Vector3(-270 + px, -500, 0);
        GetComponent<Renderer>().material.color = Color.black;
    }

    void EditorMove()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 temp = Input.mousePosition;
            temp.z = -100;
            firstmouse = Camera.main.ScreenToWorldPoint(temp);
        }
        if(Input.GetMouseButton(0))
        {
            premouse = mouse;
            Vector3 temp = Input.mousePosition;
            temp.z = -100;
            Vector3 temp2 = Camera.main.ScreenToWorldPoint(temp);
            mouse = new Vector3(temp2.x - firstmouse.x, temp2.y - firstmouse.y, -100);

            if(canmove)
            {
                float nx = mouse.x - premouse.x;
                float ny = mouse.y - premouse.y;
                float nx2, ny2;

                if(nx < 0) nx2 = Mathf.Max(-540 + scl.x / 2 + 2, pos.x + nx);
                else nx2 = Mathf.Min(-scl.x / 2 - 2, pos.x + nx);

                if(ny < 0) ny2 = Mathf.Max(-Screen.height / 2 + scl.y / 2 + fwh, pos.y + ny);
                else ny2 = Mathf.Min(Screen.height / 2 - scl.y / 2, pos.y + ny);

                transform.position = new Vector3(nx2, ny2, 0);
            }
            else canmove = true;
        }
        if(Input.GetMouseButtonUp(0)) canmove = false;
    }
}