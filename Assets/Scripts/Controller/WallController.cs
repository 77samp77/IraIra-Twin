using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    float w, h;
    
    float fs;
    GameObject gameManager;
    GameManagerScript gms;

    int mode;   // 0...停止,　1...左右移動　2...回転
    float vx, tspeed;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        w = transform.localScale.x / 2;
        h = transform.localScale.y / 2;

        gameManager = GameObject.Find("GameManager");
        gms = gameManager.GetComponent<GameManagerScript>();
        fs = gms.fs;
    }

    bool isLeft;
    int angle;

    public void FixedInst(int _angle, bool _iL)
    {
        isLeft = _iL;
        mode = 0;
        angle = _angle;

        if(angle != 0) transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void MoveInst(float _vx, float _tspeed, int _angle, bool _iL)
    {
        vx = _vx;
        tspeed = _tspeed;
        angle = _angle;
        if(angle != 0) transform.rotation = Quaternion.Euler(0, 0, angle);
        isLeft = _iL;

        if(vx != 0) mode = 1;
        if(tspeed != 0) mode = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(gms.isStop) return;

        pos = transform.position;
        switch(mode)
        {
            case 0:
                FixedWall();
                break;
            case 1:
                MoveWall();
                break;
            case 2:
                RotateWall();
                break;
        }
    }

    void FixedWall()
    {
        transform.position = new Vector3(pos.x, pos.y - fs, pos.z);
        if(transform.position.y < -Screen.height / 2 - h) Destroy(gameObject);
    }

    float x, px;

    void MoveWall()
    {
        x = pos.x + vx;

        if(isLeft) px = x + 540;
        else px = x;

        if(px + w > 540)
        {
            px = 540 - w;
            vx = -vx;
        }
        else if(px - w < 0)
        {
            px = w;
            vx = -vx;
        }

        if(isLeft) x = px - 540;
        else x = px;

        transform.position = new Vector3(x, pos.y - fs, pos.z);

        if(angle == 0 && transform.position.y < -Screen.height / 2 - h) Destroy(gameObject);
        else if(angle != 0 && transform.position.y < -Screen.height / 2 - Mathf.Max(w, h))
        {
            Debug.Log("eyo");
            Destroy(gameObject);
        }
    }

    void RotateWall()
    {
        transform.rotation = Quaternion.Euler(0, 0, (transform.localEulerAngles.z + tspeed) % 360);

        transform.position = new Vector3(pos.x, pos.y - fs, pos.z);
        if(transform.position.y < -Screen.height / 2 - Mathf.Max(w, h)) Destroy(gameObject);
    }
}
