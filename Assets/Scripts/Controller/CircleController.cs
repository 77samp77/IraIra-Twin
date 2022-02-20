using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    float cx, cy, r;
    int fangle, tr;
    float tspeed;

    float x, y;
    int fCount = 0;

    float fs;
    GameObject gameManager;
    GameManagerScript gms;

    // Start is called before the first frame update
    void Start()
    {
        cx = transform.position.x;
        cy = transform.position.y;
        r = transform.localScale.y / 2;

        gameManager = GameObject.Find("GameManager");
        gms = gameManager.GetComponent<GameManagerScript>();
        fs = gms.fs;
    }

    public void Inst(int _angle, int _tr, float _tspeed)
    {
        fangle = _angle;
        tr = _tr;
        tspeed = _tspeed;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Mathf.Approximately(Time.timeScale, 0f)) return;
        if(gms.isStop) return;

        cy -= fs;
        float angle = ((fCount * tspeed + fangle)  % 360) * (Mathf.PI / 180);
        x = cx + tr * Mathf.Cos(angle);
        y = cy + tr * Mathf.Sin(angle);
        transform.position = new Vector3(x, y, 0);
        fCount++;

        if(transform.position.y < -Screen.height / 2 - r - tr) Destroy(gameObject);
    }
}
